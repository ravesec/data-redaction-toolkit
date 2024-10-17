package com.ravesec.drtk.core;

import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public enum RedactionLevel {
    LOW {
        // This redaction level simply redacts each keyword.
        @Override
        public String applyRedaction(String content, String[] keywords, Charset charset) {
            String replacementCharacter = RedactionLevel.getReplacementCharacterFromCharset(charset);

            for (String keyword : keywords) {
                String replacement = keyword.replaceAll(".", replacementCharacter);
                content = content.replaceAll("(?i)" + Pattern.quote(keyword), replacement);
            }
            return content;
        }
    },
    MEDIUM {
        // This redaction level redacts entire sentences if they contain a keyword.
        @Override
        public String applyRedaction(String content, String[] keywords, Charset charset) {
            String replacementCharacter = RedactionLevel.getReplacementCharacterFromCharset(charset);

            for (String keyword : keywords) {
                content = RedactionLevel.redactWithPattern(content, keyword, "\\b[^.]*" + Pattern.quote(keyword) + "[^.]*\\b", replacementCharacter);
            }
            return content;
        }
    },
    HIGH {
        // This redaction level redacts entire paragraphs if they contain a keyword.
        @Override
        public String applyRedaction(String content, String[] keywords, Charset charset) {
            String replacementCharacter = RedactionLevel.getReplacementCharacterFromCharset(charset);

            // Using split-based redaction

            // Identify the line-ending style based on the presence of carriage return characters
            String[] paragraphs;
            String newlineSeparator;

            if (content.contains("\r")) {
                // Windows style line endings
                paragraphs = content.split("\\r\\n");
                newlineSeparator = "\r\n";
            } else {
                // Unix style line endings
                paragraphs = content.split("\\n\\n");
                newlineSeparator = "\n\n";
            }

            for (int i = 0; i < paragraphs.length; i++) {
                for (String keyword : keywords) {
                    if (paragraphs[i].toLowerCase().contains(keyword.toLowerCase())) {
                        // Redact the entire paragraph
                        paragraphs[i] = paragraphs[i].replaceAll(".", replacementCharacter);
                    }
                }
            }
            return String.join(newlineSeparator, paragraphs);
        }
    };

    public abstract String applyRedaction(String content, String[] keywords, Charset charset);

    public static String getReplacementCharacterFromCharset(Charset charset) {
        // Given a charset, return the best supported redaction character
        Map<Charset, String> charsetRedactionCharacterMap = new HashMap<>();
        charsetRedactionCharacterMap.put(StandardCharsets.UTF_8, "█");
        charsetRedactionCharacterMap.put(StandardCharsets.ISO_8859_1, "#");
        charsetRedactionCharacterMap.put(StandardCharsets.US_ASCII, "*");

        return charsetRedactionCharacterMap.getOrDefault(charset, "*");
    }

    private static String redactWithPattern(String content, String keyword, String pattern, String replacementCharacter) {
        Pattern compiledPattern = Pattern.compile("(?i)" + pattern, Pattern.DOTALL);
        Matcher matcher = compiledPattern.matcher(content);
        StringBuilder sb = new StringBuilder();
        int lastEnd = 0;
        while (matcher.find()) {
            sb.append(content, lastEnd, matcher.start());
            sb.append(matcher.group().replaceAll(".", replacementCharacter)); // Redact the matched text
            lastEnd = matcher.end();
        }
        sb.append(content.substring(lastEnd));
        return sb.toString();
    }
}
