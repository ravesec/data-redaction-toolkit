package com.ravesec.drtk.factory;

import com.ravesec.drtk.strategy.PDFRedactor;
import com.ravesec.drtk.strategy.RedactionStrategy;
import com.ravesec.drtk.strategy.TextFileRedactor;
import com.ravesec.drtk.strategy.WordFileRedactor;
import com.ravesec.drtk.utils.FileUtils;

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
        String fileExtension = FileUtils.getFileExtension(filePath);
        RedactionStrategy redactionStrategy = strategyMap.get(fileExtension);

        if (redactionStrategy == null) {
            throw new IllegalArgumentException("No redaction strategy found for file extension: " + fileExtension);
        }

        return redactionStrategy;
    }
}