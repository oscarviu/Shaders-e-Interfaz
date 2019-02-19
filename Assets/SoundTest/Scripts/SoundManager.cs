using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SoundManager : MonoBehaviour
{
    public AudioClip MainMusic = null;
    public AudioClip FxSound1 = null;
    public AudioClip FxSound2 = null;
    public AudioClip FxSound3 = null;

    AudioSource sourceMusic = null;
    AudioSource sourceFx1 = null;
    AudioSource sourceFx2 = null;
    AudioSource sourceFx3 = null;
    AudioSource sourceFx4 = null;

    public AudioMixerSnapshot pauseSnapshot;
    public AudioMixerSnapshot normalSnapshot;

  
    [SerializeField]
    GameObject PausePanel = null;

    // Start is called before the first frame update
    void Start()
    {
        sourceMusic = GetComponent<AudioSource>();

        sourceFx1 = GetComponents<AudioSource>()[1];
        sourceFx2 = GetComponents<AudioSource>()[2];
        sourceFx3 = GetComponents<AudioSource>()[3];
        sourceFx4 = gameObject.AddComponent<AudioSource>();

        // Music Audio Source
        sourceMusic.clip = MainMusic;
        sourceMusic.loop = true;
    }

    public void playMusic()
    {
        sourceMusic.PlayDelayed(0.5f); 
    }

    public void stopMusic()
    {
        sourceMusic.Stop();
    }

    public void playSound(int id)
    {
        AudioClip current;
        if (id == 0)
            current = FxSound1;
        else if (id == 1)
            current = FxSound2;
        else
            current = FxSound3;


        if (!sourceFx1.isPlaying)
        {
            sourceFx1.clip = current;
            sourceFx1.Play();
        }
        else if (!sourceFx2.isPlaying)
        {
            sourceFx2.clip = current;
            sourceFx2.Play();

        }
        else
        {
            sourceFx3.clip = current;
            sourceFx3.Play();
        }
    }

    public void pause(bool paused)
    {
        if (paused)
        {
            // Show Pause Panel
            PausePanel.SetActive(true);
            // Switch mixer mode pause
            pauseSnapshot.TransitionTo(0.5f);
        }
        else
        {
            // Hide Pause Panel
            PausePanel.SetActive(false);
            // Switch mixer mode pause
            normalSnapshot.TransitionTo(0.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
