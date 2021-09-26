using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlay : MonoBehaviour
{
    public AudioSource AudioSource;
    public Slider volumeSLider;
    public GameObject ObjectMusic;
    private float MusicVolume = 1;

    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSLider.value = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }
}
