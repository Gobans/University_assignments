using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator animator;
    public Transform Player;
    public float ChaseSpeed = 5f;
    public float Range = 5f;
    public float AttackRange = 1f;
    public int enemyDamage = 1;
    public int enemyHp = 3;
    float timer = 0;
    public int waitingTime = 2;
    bool Stop = false;


    float CurrentSpeed;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(9,10, true);
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
            Player.gameObject.GetComponent<PlayerController>().PlayerHit(enemyDamage);
            animator.SetTrigger("EnemyAttack");
            Stop = true;
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
        if(enemyHp <=0)
        {
            gameObject.SetActive(false);
        }
    }


}