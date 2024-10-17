package com.ravesec.drtk.strategy;

import com.ravesec.drtk.core.RedactionLevel;

public interface RedactionStrategy {
    void redact(String filePath, String[] keywords, RedactionLevel redactionLevel) throws Exception;
}
