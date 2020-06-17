using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickaxe : MonoBehaviour
{
    public Text PickaxeText;
    public AudioClip getSound1;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {

            source.clip = getSound1;
            source.Play();
            PlayerController PickaxeDura = GameObject.Find("Player").GetComponent<PlayerController>();
            PickaxeDura.PickaxeDura += 6;
            PickaxeText.text = "Pickaxe: " + PickaxeDura.PickaxeDura;
            Destroy(gameObject, 0.2f);
        }
    }
}
