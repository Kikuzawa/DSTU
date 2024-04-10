package com.kiku.javalangprogproject;

import javafx.scene.media.AudioClip;

import java.util.Objects;

/**
 * Перечисление, которое содержит все звуки для приложения.
 */
public enum SOUND {
    ;
    public final static AudioClip HOVER = new AudioClip(Objects.requireNonNull(SOUND.class.getResource("hover.mp3")).toExternalForm());
    public final static AudioClip CLICK = new AudioClip(Objects.requireNonNull(SOUND.class.getResource("click.mp3")).toExternalForm());
    public final static AudioClip NOTIFICATION = new AudioClip(Objects.requireNonNull(SOUND.class.getResource("click.mp3")).toExternalForm());

}
