using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sinstance;
    public AudioClip sndExplosion;
    AudioSource mAudio;
    void Awake()
    {
        if(sinstance == null)
        {
            sinstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        mAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        mAudio.PlayOneShot(sndExplosion);
    }
}
