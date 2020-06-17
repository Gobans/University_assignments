using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChestKey : MonoBehaviour
{
    public AudioClip getSound1;
    private AudioSource source;
    public Text ChestKeyText;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            ChestKeyText.text = "Chest Key";
            source.clip = getSound1;
            source.Play();
            TrapBag key = GameObject.Find("chest").GetComponent<TrapBag>();
            key.ChestKey = true;
            Destroy(gameObject, 0.2f);
        }
    }
}
