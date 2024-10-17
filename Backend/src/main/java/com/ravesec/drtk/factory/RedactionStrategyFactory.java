package com.ravesec.drtk.factory;

import com.ravesec.drtk.strategy.PDFRedactor;
import com.ravesec.drtk.strategy.RedactionStrategy;
import com.ravesec.drtk.strategy.TextFileRedactor;
import com.ravesec.drtk.strategy.WordFileRedactor;

import java.util.HashMap;
import java.util.Map;

public class RedactionStrategyFactory {
    private static final Map<String, RedactionStrategy> strategyMap = new HashMap<>();

    static {
        strategyMap.put(".txt", new TextFileRedactor());
//        strategyMap.put(".pdf", new PDFRedactor());
//
//        strategyMap.put(".docx", new WordFileRedactor());
//        strategyMap.put(".doc", new WordFileRedactor());
//        strategyMap.put(".odt", new PDFRedactor());
    }

    public static RedactionStrategy getRedactionStrategy(String filePath) {
        String fileExtension = getFileExtension(filePath);
        RedactionStrategy redactionStrategy = strategyMap.get(fileExtension);

        if (redactionStrategy == null) {
            throw new IllegalArgumentException("No redaction strategy found for file extension: " + fileExtension);
        }

        return redactionStrategy;
    }

    private static String getFileExtension(String filePath) {
        int dotIndex = filePath.lastIndexOf('.');

        if (dotIndex != -1 && dotIndex != filePath.length() - 1) {
            return filePath.substring(dotIndex).toLowerCase();
        } else {
            throw new IllegalArgumentException("Invalid file extension for file: " + filePath);
        }
    }
}