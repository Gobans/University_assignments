using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 MoveVelocity;
    private Animator animator;
    private AudioSource source;
    public int wallDamage = 1;					//How much damage a player does to a wall when chopping it.
    public int PlayerHp = 3;
    public AudioClip hitsound;                //1 of 2 Audio clips to play when player moves.
    private bool moving;
    public Text HpText;
    public Text gameOverText;
    public Text PickaxeText;
    public int PickaxeDura = 0;
    public bool Key;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        HpText.text = "Hp:" + PlayerHp;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        MoveVelocity = moveinput.normalized * moveSpeed;

    }


    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + MoveVelocity * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag.Equals("Wall") && PickaxeDura>0)

        {
            PickaxeDura -= 1;
            PickaxeText.text = "Pickaxe :" + PickaxeDura;
            other.gameObject.GetComponent<Wall>().DamageWall(wallDamage);
            animator.SetTrigger("PlayerAttack");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Key") && Key == true)
        {
            other.gameObject.GetComponent<StageMove>().MoveNext();
        }
    }

    public void PlayerHit(int enemyDamage)
    {
        PlayerHp -= enemyDamage;
        source.clip = hitsound;
        source.Play();
        HpText.text = "Hp:" + PlayerHp ;
        animator.SetTrigger("PlayerHit");

        CheckIfGameOver();

    }

    public void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (PlayerHp <= 0)
        {
            gameOverText.text = "GameOver\n"+ "\n"+ " press R to restart";
            HpText.text = null;
            GameManager.instance.GameOver();
            gameObject.SetActive(false);

        }
    }

}
