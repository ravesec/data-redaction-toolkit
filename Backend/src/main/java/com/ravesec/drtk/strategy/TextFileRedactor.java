package com.ravesec.drtk.strategy;

import com.ravesec.drtk.core.RedactionLevel;

import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.charset.MalformedInputException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class TextFileRedactor implements RedactionStrategy {
    @Override
    public void redact(String filePath, String[] keywords, RedactionLevel redactionLevel) throws Exception {
//        Path path = Paths.get(filePath);
//        String content = Files.readString(path, StandardCharsets.UTF_8);
//        content = redactionLevel.applyRedaction(content, keywords);
//        Files.writeString(path, content, StandardCharsets.UTF_8);
        Path path = Paths.get(filePath);
        String content = null;
        Charset correctCharset = null;

        Charset[] charsets = new Charset[]{
                StandardCharsets.UTF_8,
                StandardCharsets.ISO_8859_1,
                StandardCharsets.US_ASCII,
                StandardCharsets.UTF_16BE,
                StandardCharsets.UTF_16,
                StandardCharsets.UTF_16LE,
        };

        for (Charset charset : charsets) {
            try {
                content = Files.readString(path, charset);
                correctCharset = charset;
                break;
            } catch (MalformedInputException ignored) {
                ;
            }
        }

        if (content == null) {
            throw new IOException("Unable to redact text file: " + filePath);
        }

        content = redactionLevel.applyRedaction(content, keywords, correctCharset);

        try (BufferedWriter writer = Files.newBufferedWriter(path, correctCharset)) {
            writer.write(content);
        }
    }
}
