using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    [Header("sound clip")]
    public AudioClip audio;
    [Header("sound name (BGM = Scene Name)")]
    public string audioName;
}

public class SoundManager : MonoBehaviour
{
    public AudioData[] audioDatas;

    public static Dictionary<string, AudioClip> audioDictionary;

    [SerializeField] private static AudioSource[] audioSources;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        audioDictionary = new Dictionary<string, AudioClip>();
        for(int i = 0; i < audioDatas.Length; i++)
        {
            audioDictionary.Add(audioDatas[i].audioName, audioDatas[i].audio);
        }
        audioSources = new AudioSource[2];

        audioSources = GetComponentsInChildren<AudioSource>();
    }

    public static void Play(string name, bool _isBgm,  float volume = 1.0f, float pitch = 1.0f)
    {
        if (!audioDictionary.ContainsKey(name)) return;

        AudioClip audio = audioDictionary[name];

        if (_isBgm)
        {
            if (audioSources[0].isPlaying) audioSources[0].Stop();

            audioSources[0].pitch = pitch;
            audioSources[0].volume = volume;
            audioSources[0].clip = audio;
            audioSources[0].Play();
        }
        else
        {
            audioSources[1].pitch = pitch;
            audioSources[1].volume = volume;
            audioSources[1].PlayOneShot(audio);
        }
    }
}
