using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
 

    public void playSound()
    {
        source.Play();
    }
}
