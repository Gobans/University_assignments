using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapNormal : MonoBehaviour
{
    public AudioClip boomSound1;                //1 of 2 audio clips that play when the wall is attacked by the player.
    public AudioClip throwSound1;
    private AudioSource source;
    public Transform Player;
    public GameObject TrapObject;
    private Animator animator;
    public Text TrapText;

    Vector3 pos;
    public bool install;

    void Start()
    {
        install = false;
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.X) && install == true)
        {
            TrapText.text = "";
            pos = Player.transform.position;
            Instantiate(TrapObject, Player.transform.position, Quaternion.identity);
            source.clip = throwSound1;
            source.Play();
            install = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            animator.SetTrigger("TrapBoom");
            source.clip = boomSound1;
            source.Play();
            Enemy EnemyHp = other.gameObject.GetComponent<Enemy>();
            EnemyHp.enemyHp -= 3;
            Destroy(gameObject, 0.5f);
        }
        else if (other.gameObject.tag == ("SkeletonKing"))
        {
            animator.SetTrigger("TrapBoom");
            source.clip = boomSound1;
            source.Play();
            other.gameObject.GetComponent<Boss>().EnemyHit(3);
            Destroy(gameObject, 0.5f);
        }
    }
}
