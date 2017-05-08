using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3 playerPos;
    Transform position;
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;


	void Awake ()
    {
        position = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(position.position,player.position)<3000)
        {
            nav.SetDestination(player.position);
        }

    }
}
