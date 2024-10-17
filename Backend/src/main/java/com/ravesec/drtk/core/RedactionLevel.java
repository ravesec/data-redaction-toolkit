package com.ravesec.drtk.core;

public enum RedactionLevel {
    LOW {
        @Override
        public String applyRedaction(String content, String[] keywords) {
            return "";
        }
    },
    MEDIUM {
        @Override
        public String applyRedaction(String content, String[] keywords) {
            return "";
        }
    },
    HIGH {
        @Override
        public String applyRedaction(String content, String[] keywords) {
            return "";
        }
    };

    public abstract String applyRedaction(String content, String[] keywords);
}
