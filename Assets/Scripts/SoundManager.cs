using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
    CLICK = 0,
    PICK = 1,
    SOLVED = 2,
}

public class SoundCollection {
    private AudioClip[] clips;

    public SoundCollection(params string[] audioNames) {
        clips = new AudioClip[audioNames.Length];
        for (int i = 0; i < clips.Length; i++) {
            clips[i] = Resources.Load(audioNames[i]) as AudioClip;
            if (clips[i] == null) {
                Debug.LogWarning($"Couldn't find clip {audioNames[i]}");
            }
        }
    }

    public AudioClip GetRandClip() {
        if (clips.Length == 0) {
            Debug.LogWarning($"No clips found");
            return null;
        }
        else if (clips.Length == 1) {
            return clips[0];
        }
        else {
            int index = UnityEngine.Random.Range(0, clips.Length);
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;

    public static SoundManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    void Start() {
        audioSrc = GetComponent<AudioSource>();
        sounds = new Dictionary<SoundType, SoundCollection>()
        {
            {SoundType.CLICK, new SoundCollection("clicks/click_1") },
            {SoundType.PICK, new SoundCollection("picks/picks_1", "picks/picks_2", "picks/picks_3", "picks/picks_4", "picks/picks_5", "picks/picks_6", "picks/picks_7", "picks/picks_8", "picks/picks_9") },
            {SoundType.SOLVED, new SoundCollection("solved")}
        };
    }

    public void Play(SoundType type, AudioSource audioSrc = null) {
        if (sounds.ContainsKey(type)) {
            if (audioSrc == null) {
                this.audioSrc.clip = sounds[type].GetRandClip();
                this.audioSrc.Play();
            }
            else {
                audioSrc.clip = sounds[type].GetRandClip();
                audioSrc.Play();
            }
        }
    }

    public void Play(string type, AudioSource audioSrc) {
        SoundType soundType = Enum.Parse<SoundType>(type, true);
        Play(soundType, audioSrc);
    }

    public void Play(string type) {
        Play(type, audioSrc);
    }

    public void Play(int type) {
        Play((SoundType)type, audioSrc);
    }
}
