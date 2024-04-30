package com.kiku.formallanguagemachineteaching;

public class Word {

    public Word(String word, Integer spam, Integer noSpam, Double pSpam, Double pNoSpam) {
        this.word = word;
        this.spam = spam;
        this.noSpam = noSpam;
        this.pSpam = pSpam;
        this.pNoSpam = pNoSpam;
    }



    public String getWord() {
        return word;
    }

    public Integer getSpam() {
        return spam;
    }

    public Integer getNoSpam() {
        return noSpam;
    }

    public Double getpSpam() {
        return pSpam;
    }

    public Double getpNoSpam() {
        return pNoSpam;
    }

    public Double getPSpam() {
        return pSpam;
    }

    public Double getPNoSpam() {
        return pNoSpam;
    }

    String word;
    Integer spam;
    Integer noSpam;
    Double pSpam;
    Double pNoSpam;
}
