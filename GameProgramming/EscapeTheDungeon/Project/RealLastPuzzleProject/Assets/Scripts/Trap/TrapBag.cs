using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapBag : MonoBehaviour
{
    public AudioClip getSound1;
    private AudioSource source;
    public Text BoomText;
    public Text ChestText;
    public bool ChestKey;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player") && ChestKey == true)
        {
            BoomText.text = "Boom Trap(Z)";
            ChestText.text = "";
            source.clip = getSound1;
            source.Play();
            Trap install = GameObject.Find("Trap").GetComponent<Trap>();
            install.install = true;
            ChestKey = false;
            Debug.Log("hihi");
            Destroy(gameObject, 0.2f);
        }
    }

}
