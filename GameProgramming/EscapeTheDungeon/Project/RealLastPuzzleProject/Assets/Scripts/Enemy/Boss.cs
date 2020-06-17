using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator animator;
    public Transform Player;
    public float ChaseSpeed = 5f;
    public float Range = 5f;
    public float AttackRange = 2f;
    public int enemyDamage = 1;
    public int enemyHp = 12;
    float timer = 0;
    public int waitingTime = 2;
    bool Stop = false;
    public GameObject bullet;
    public GameObject StageKey;
    public int bu_x = -1;
    public int bu_y = 0;
    bool Pattern = true;
    private AudioSource source;
    public AudioClip hitsound;
    public AudioClip attacksound;



    float CurrentSpeed;
    void Start()
    {
        source = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= Range && Stop == false)
        {
            CurrentSpeed = ChaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, CurrentSpeed);
        }

        if (Vector3.Distance(transform.position, Player.position) <= AttackRange && Stop == false)
        {
            if (Pattern == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        bu_x = -1;
                        bu_y = 0;
                    }
                    if (i == 1)
                    {
                        bu_x = 0;
                        bu_y = 1;
                    }
                    if (i == 2)
                    {
                        bu_x = 1;
                        bu_y = 0;
                    }
                    if (i == 3)
                    {
                        bu_x = 0;
                        bu_y = -1;
                    }

                    animator.SetTrigger("EnemyAttack");
                    source.clip = attacksound;
                    source.Play();
                    GameObject obj;
                    obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
                    Vector3 targetPosFlattened = new Vector3(bu_x, bu_y, 0);
                    obj.GetComponent<Rigidbody2D>().AddForce(targetPosFlattened * 2, ForceMode2D.Impulse);

                    if (i == 4)
                    {
                        Stop = true;
                        Pattern = false;
                    }

                }
            }
            else //Pattern = false
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        bu_x = -1;
                        bu_y = -1;
                    }
                    if (i == 1)
                    {
                        bu_x = -1;
                        bu_y = 1;
                    }
                    if (i == 2)
                    {
                        bu_x = 1;
                        bu_y = 1;
                    }
                    if (i == 3)
                    {
                        bu_x = 1;
                        bu_y = -1;
                    }

                    animator.SetTrigger("EnemyAttack");
                    source.clip = attacksound;
                    source.Play();
                    GameObject obj;
                    obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
                    Vector3 targetPosFlattened = new Vector3(bu_x, bu_y, 0);
                    obj.GetComponent<Rigidbody2D>().AddForce(targetPosFlattened * 2, ForceMode2D.Impulse);

                    if (i == 4)
                    {
                        Stop = true;
                        Pattern = true;
                    }

                }
            }
           
        }

        if (Stop == true)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                Stop = false;
                timer = 0;
            }
        }
    }
    
    public void EnemyHit(int enemydmg)
    {
        animator.SetTrigger("EnemyHit");
        source.clip = hitsound;
        source.Play();
        enemyHp -= enemydmg;
        if (enemyHp <= 0)
        {
            Instantiate(StageKey, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


}
