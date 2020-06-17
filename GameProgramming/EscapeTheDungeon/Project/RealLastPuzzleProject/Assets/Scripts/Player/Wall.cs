using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Wall : MonoBehaviour
    {
        // Start is called before the first frame update
        public AudioClip chopSound1;                //1 of 2 audio clips that play when the wall is attacked by the player.
        public AudioClip chopSound2;                //2 of 2 audio clips that play when the wall is attacked by the player.
        public Sprite dmgSprite;                    //Alternate sprite to display after Wall has been attacked by player.
        public int hp = 3;                          //hit points for the wall.
        private AudioSource source; 


        private SpriteRenderer spriteRenderer;      //Store a component reference to the attached SpriteRenderer.


        void Awake()
        {
            //Get a component reference to the SpriteRenderer.
            spriteRenderer = GetComponent<SpriteRenderer>();
            source = GetComponent<AudioSource>();
    }


        //DamageWall is called when the player attacks a wall.
        public void DamageWall(int loss)
        {

            //Set spriteRenderer to the damaged wall sprite.
            spriteRenderer.sprite = dmgSprite;
            source.clip = chopSound1;
            source.Play();

        //Subtract loss from hit point total.
        hp -= loss;

            //If hit points are less than or equal to zero:
            if (hp <= 0)
                //Disable the gameObject.
                gameObject.SetActive(false);
        }

        public void ExplosionWall()
        {
        gameObject.SetActive(false);
        }

    }
