package com.kiku.javalangprogproject.config;

import javafx.scene.media.AudioClip;

import java.nio.file.Path;
import java.util.Objects;

/**
 * Перечисление, которое содержит все звуки для приложения.
 */
public enum SOUND {
    ;
    public final static AudioClip HOVER = new AudioClip(Objects.requireNonNull(SOUND.class.getResource(Paths.PATH_SOUNDS + "hover.mp3")).toExternalForm());
    public final static AudioClip CLICK = new AudioClip(Objects.requireNonNull(SOUND.class.getResource(Paths.PATH_SOUNDS + "click.mp3")).toExternalForm());
    public final static AudioClip ERROR = new AudioClip(Objects.requireNonNull(SOUND.class.getResource(Paths.PATH_SOUNDS + "error.mp3")).toExternalForm());

}
