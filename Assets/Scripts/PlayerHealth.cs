﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 1;
    public int currentHealth;
    //public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.5f);

    bool damaged;

    void Awake()
    {
        //playerAudio = GetComponent<AudioSource>();
        //playerControl = GetComponent<PlayerControl>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;*/
    }
    
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        //playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    */
    /*
    void Death()
    {
        isDead = true;

        playerControl.DisableEffects();

        //anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        //playerAudio.Play();

        playerControl.enabled = false;
    }
    */








}