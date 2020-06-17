using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{

    public float MoveSpeed; // 미사일이 날라가는 속도 public 
    public float DestroyYPos; // 미사일 사라지는 지점
    public float DestroyTime = 4f;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().PlayerHit(1);
        }
    }
}
