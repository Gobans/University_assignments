using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagNormal : MonoBehaviour
{
    public AudioClip getSound1;
    private AudioSource source;
    public Text TrapText;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            TrapText.text = "Normal Trap(X)";
            source.clip = getSound1;
            source.Play();
            TrapNormal install = GameObject.Find("Trap_normal").GetComponent<TrapNormal>();
            install.install = true;
            Destroy(gameObject, 0.2f);
        }
    }
}
