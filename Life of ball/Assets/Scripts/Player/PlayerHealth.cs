using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text healthText;

    bool isDead;
    bool damage;

	// Use this for initialization
	void Start ()
    {
        currentHealth = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthSlider.value = 30;
        healthText.text = currentHealth.ToString();
	}

    public void TakeDmg(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <=0 && !isDead)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
    }
}
