using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_soundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
