using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameObject deadview;


    public int startingHealth = 1;
    public int currentHealth;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.5f);

    bool damaged;
    bool isDead;

    AudioSource playerAudio;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        deadview = GameObject.FindGameObjectWithTag("Dead");
        
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            //damageImage.color = flashColour;
        }
        damaged = false;
    }
    
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
            deadview.SetActive(true);
        }
    }


    void Death()
    {
        isDead = true;



        //anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

    }
    








}