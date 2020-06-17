using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_sound : MonoBehaviour
{
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public GameObject soundManager;         //SoundManager prefab to instantiate.
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(GameObject.Find("SoundManager(Clone)"));
        Instantiate(soundManager);
    }
}
