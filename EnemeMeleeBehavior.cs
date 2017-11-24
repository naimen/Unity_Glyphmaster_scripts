using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMeleeBehavior : EnemyBehavior {

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null)
		{
			Vector3 direction = player.transform.position - transform.position;
			Move(direction);
		}
		
	}
}
