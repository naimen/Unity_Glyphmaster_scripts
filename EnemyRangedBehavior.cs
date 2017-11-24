using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedBehavior : EnemeMeleeBehavior
{
	private int randint;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		
		StartCoroutine("Shooting");
		
		randint = Random.Range(-1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Move(new Vector2(randint,-1));
		
	}

	IEnumerator Shooting()
	{
		while (true)
		{
			for(int i=0; i<transform.childCount;i++)
			{
				Transform shotposition = transform.GetChild(i);
				if (player != null)
				{
					shoot(shotposition, player.transform.position - transform.position);
					GetComponent<AudioSource>().Play();
				}
				
			}
			yield return new WaitForSeconds(attackDelay);
		}
	}
}
