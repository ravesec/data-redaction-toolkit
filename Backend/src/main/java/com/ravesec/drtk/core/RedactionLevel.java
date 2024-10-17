package com.ravesec.drtk.core;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public enum RedactionLevel {
    LOW {
        // This redaction level simply redacts each keyword.
        @Override
        public String applyRedaction(String content, String[] keywords) {
            for (String keyword : keywords) {
                String replacement = keyword.replaceAll(".", "█");
                content = content.replaceAll("(?i)" + Pattern.quote(keyword), replacement);
            }
            return content;
        }
    },
    MEDIUM {
        // This redaction level redacts entire sentences if they contain a keyword.
        @Override
        public String applyRedaction(String content, String[] keywords) {
            for (String keyword : keywords) {
                content = RedactionLevel.redactWithPattern(content, keyword, "\\b[^.]*" + Pattern.quote(keyword) + "[^.]*\\b");
            }
            return content;
        }
    },
    HIGH {
        // This redaction level redacts entire paragraphs if they contain a keyword.
        @Override
        public String applyRedaction(String content, String[] keywords) {
            for (String keyword : keywords) {
                content = RedactionLevel.redactWithPattern(content, keyword, "\\b.*" + Pattern.quote(keyword) + ".*\\b");
            }
            return content;
        }
    };

    public abstract String applyRedaction(String content, String[] keywords);

    private static String redactWithPattern(String content, String keyword, String pattern) {
        Pattern compiledPattern = Pattern.compile("(?i)" + pattern, Pattern.DOTALL);
        Matcher matcher = compiledPattern.matcher(content);
        StringBuilder sb = new StringBuilder();
        int lastEnd = 0;
        while (matcher.find()) {
            sb.append(content, lastEnd, matcher.start());
            sb.append(matcher.group().replaceAll(".", "█")); // Redact the matched text
            lastEnd = matcher.end();
        }
        sb.append(content.substring(lastEnd));
        return sb.toString();
    }
}
