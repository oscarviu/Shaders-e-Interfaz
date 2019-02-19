using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSoundBehaviour : MonoBehaviour
{
    public AudioClip File1 = null;
    public AudioClip File2 = null;

    public AudioSource source = null;   // I will add the audiosource by this script
    
    // Start is called before the first frame update
    void Start()
    {
        // Add AudioSource component
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;


        source.clip = File1;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            source.clip = source.clip == File1 ? File2 : File1;
            source.Play();
        }
    }
}
