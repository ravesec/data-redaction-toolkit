package com.ravesec.drtk.strategy;

import com.ravesec.drtk.core.RedactionLevel;

public sealed interface RedactionStrategy permits CSVRedactor, PDFRedactor, TextFileRedactor, WordFileRedactor {
    void redact(String filePath, String[] keywords, RedactionLevel redactionLevel) throws Exception;
}
