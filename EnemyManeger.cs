using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
	public GameObject enemy_melee;
	public GameObject enemy_ranged;

	private float spawnTime=5f;
	// Use this for initialization
	void Start () {
		Invoke("SpawnEnemy",spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint( new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint( new Vector2(0.65f,1));

		if (Random.value > 0.8)
		{
			Instantiate(enemy_ranged, new Vector2(Random.Range(min.x, max.x), max.y), Quaternion.identity);
		}
		Instantiate(enemy_melee, new Vector2(Random.Range(min.x, max.x), max.y), Quaternion.identity);
		Instantiate(enemy_melee, new Vector2(Random.Range(min.x, max.x), max.y), Quaternion.identity);
		Instantiate(enemy_melee, new Vector2(Random.Range(min.x, max.x), max.y), Quaternion.identity);

		NextEnemySpawn();
		
	}

	private void NextEnemySpawn()
	{
		float spawnInSec;
		if (spawnTime > 1f)
		{
			spawnInSec = Random.Range(1f, spawnTime);
		}
		else
		{
			spawnInSec = 1f;
		}
		Invoke("SpawnEnemy",spawnInSec);
	}
}
