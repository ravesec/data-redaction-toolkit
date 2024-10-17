package com.ravesec.drtk.utils;

public class FileUtils {
    public static String getFileExtension(String filePath) {
        int dotIndex = filePath.lastIndexOf('.');

        if (dotIndex != -1 && dotIndex != filePath.length() - 1) {
            return filePath.substring(dotIndex).toLowerCase();
        } else {
            throw new IllegalArgumentException("Invalid file extension for file: " + filePath);
        }
    }
}
