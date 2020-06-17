using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageKey : MonoBehaviour
{
    public AudioClip getSound1;
    private AudioSource source;
    public Text stageKeyText;
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
            stageKeyText.text = "Stage Key";
            source.clip = getSound1;
            source.Play();
            PlayerController key = GameObject.Find("Player").GetComponent<PlayerController>();
            key.Key = true;
            Destroy(gameObject, 0.2f);
        }
    }
}
