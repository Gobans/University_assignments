using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : MonoBehaviour
{
    public int enemyDamage = 2;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("dd");
            other.gameObject.GetComponent<PlayerController>().PlayerHit(enemyDamage);
            animator.SetTrigger("EnemyAttack");
            Invoke("OnTriggerEnter2D", 5f);
        }
    }
}

