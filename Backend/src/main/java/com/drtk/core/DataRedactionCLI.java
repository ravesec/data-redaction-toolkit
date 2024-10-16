package com.drtk.core;

import com.drtk.redactor.FileRedactor;
import picocli.CommandLine;
import picocli.CommandLine.Parameters;
import picocli.CommandLine.Option;

public class DataRedactionCLI implements Runnable {

    @Parameters(index = "0", description = "The path to the un-redacted file")
    private String filePath;

    @Option(names = {"-d", "--data"}, required = true, description = "The comma-seperated data to be redacted (ex: \"Jane Doe\",859-555-5555)")
    private String[] sensitiveData;

    @Option(names = {"-l", "--level"}, required = true, description = "The redaction level. (LOW, MEDIUM, HIGH)")
    private RedactionLevel level;

    public static void main(String[] args) {
        CommandLine.run(new DataRedactionCLI(), args);
    }

    @Override
    public void run() {
        try {
            // Use the factory to get the relevant redactor
            FileRedactor redactor = new FileRedactor(filePath);
            redactor.redactFile(filePath, sensitiveData, level);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
