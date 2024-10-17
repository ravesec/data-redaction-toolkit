package com.ravesec.drtk.strategy;

public interface RedactionStrategy {
    void redact(String filePath, String[] keywords, int redactionLevel) throws Exception;
}
