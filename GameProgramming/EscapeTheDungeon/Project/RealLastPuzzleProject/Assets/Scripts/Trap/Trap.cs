using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public AudioClip boomSound1;                //1 of 2 audio clips that play when the wall is attacked by the player.
    public AudioClip throwSound1;
    private AudioSource source;
    public Transform Player;
    public GameObject TrapObject;
    private Animator animator;
    public Text BoomText;

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

        if (Input.GetKeyDown(KeyCode.Z) && install == true)
        {
            BoomText.text = "";
            pos = Player.transform.position;
            Instantiate(TrapObject, Player.transform.position, Quaternion.identity);
            source.clip = throwSound1;
            source.Play();
            install = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("SkeletonKing"))
        {
            animator.SetTrigger("TrapBoom");
            source.clip = boomSound1;
            source.Play();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.5f);
            foreach (Collider2D hit in colliders)
            {
                if(hit.gameObject.tag == "Enemy")
                {
                    Enemy EnemyHp = hit.gameObject.GetComponent<Enemy>();
                    EnemyHp.enemyHp -= 3;
                }
                else if (hit.gameObject.tag == "Player")
                {
                    PlayerController PlayerHp = hit.gameObject.GetComponent<PlayerController>();
                    PlayerHp.PlayerHp -= 3;
                    PlayerHp.CheckIfGameOver();
                }
                else if (hit.gameObject.tag == "Wall")
                {
                    Destroy(hit.gameObject);
                }
                else if (hit.gameObject.tag == "Wall_Unbroken")
                {
                    Destroy(hit.gameObject);
                }
                else if (hit.gameObject.tag == "wizard")
                {
                    Destroy(hit.gameObject);
                }
                else if (hit.gameObject.tag == "Skeleton")
                {
                    Destroy(hit.gameObject);
                }
                else if (hit.gameObject.tag == "SkeletonKing")
                {
                    hit.gameObject.GetComponent<Boss>().EnemyHit(5);
                }
            }

            Destroy(gameObject, 0.5f);
        }
    }

}
