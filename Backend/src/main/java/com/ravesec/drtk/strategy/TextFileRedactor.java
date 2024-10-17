package com.ravesec.drtk.strategy;

import com.ravesec.drtk.core.RedactionLevel;

import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class TextFileRedactor implements RedactionStrategy {
    @Override
    public void redact(String filePath, String[] keywords, RedactionLevel redactionLevel) throws Exception {
        Path path = Paths.get(filePath);
        String content = Files.readString(path);
        content = redactionLevel.applyRedaction(content, keywords);
        Files.writeString(path, content);
    }
}
