using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float attackDelay = 0.5f;
    public int attackDmg = 10;

    GameObject player;
    PlayerHealth playerHealth;
    bool inRange;
    float timer;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            inRange = true;
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            inRange = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer>=attackDelay && inRange)
        {
            Attack();
        }
	}

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDmg(attackDmg);
        }
    }
}
