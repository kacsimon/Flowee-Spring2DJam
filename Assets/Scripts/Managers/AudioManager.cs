using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;
    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        #endregion
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        PlayAudio("Theme");
    }
    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
        s.source.Play();
    }
}
