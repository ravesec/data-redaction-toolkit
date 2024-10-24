package com.ravesec.drtk.strategy;

import com.ravesec.drtk.core.RedactionLevel;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import org.apache.poi.xwpf.usermodel.XWPFParagraph;
import org.apache.poi.xwpf.usermodel.XWPFRun;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.nio.charset.Charset;

public final class WordFileRedactor implements RedactionStrategy {
    @Override
    public void redact(String filePath, String[] keywords, RedactionLevel redactionLevel) throws Exception {
        try (FileInputStream fis = new FileInputStream(filePath)) {
            XWPFDocument document = new XWPFDocument(fis);

            // Iterate through the paragraphs in the document
            for (XWPFParagraph paragraph : document.getParagraphs()) {
                String paragraphText = paragraph.getText();

                // Redact data
                String redactedText = redactionLevel.applyRedaction(paragraphText, keywords, Charset.defaultCharset());

                // Replace the original paragraph with the redacted one
                replaceParagraphText(paragraph, redactedText);
            }

            // Save the document
            try (FileOutputStream fos = new FileOutputStream(filePath)) {
                document.write(fos);
            }
        }
    }

    private void replaceParagraphText(XWPFParagraph paragraph, String redactedText) {
        // Clear existing runs in the paragraph
        for (int i = paragraph.getRuns().size() - 1; i >= 0; i--) {
            paragraph.removeRun(i);
        }

        // Add the redacted text as a new run
        XWPFRun newRun = paragraph.createRun();
        newRun.setText(redactedText);
    }
}
