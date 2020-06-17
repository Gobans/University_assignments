using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awl : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip AttackSound1;
    private AudioSource source;
    private int Awldmg = 1;
    Animator animator;
    void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            source.clip = AttackSound1;
            source.Play();
            other.GetComponent<PlayerController>().PlayerHit(Awldmg);
            animator.SetTrigger("AwlAttack");
        }
    }
}
