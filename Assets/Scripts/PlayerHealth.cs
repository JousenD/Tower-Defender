﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamagedSFX;


    private void Start()
    {
        healthText.text= health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamagedSFX);
        health = health - healthDecrease;
        healthText.text = health.ToString();
        if (health < 0) { Destroy(gameObject); }
    }
}
