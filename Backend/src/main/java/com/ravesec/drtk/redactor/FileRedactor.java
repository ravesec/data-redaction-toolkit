package com.ravesec.drtk.redactor;

import com.ravesec.drtk.core.RedactionLevel;
import com.ravesec.drtk.factory.RedactionStrategyFactory;
import com.ravesec.drtk.strategy.RedactionStrategy;

public class FileRedactor {
    private final RedactionStrategy strategy;

    public FileRedactor(String filePath) {
        this.strategy = RedactionStrategyFactory.getRedactionStrategy(filePath);
    }

    public void redactFile(String filePath, String[] sensitiveData, RedactionLevel level) throws Exception {
        strategy.redact(filePath, sensitiveData, level);
    }
}
