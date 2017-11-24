using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	private float speed;

	private Vector2 _direction;
	// Use this for initialization
	private void Awake()
	{
		speed = 5; 
	}

	public void setDirection(Vector2 direction)
	{
		_direction = direction.normalized;
	}
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody2D>().velocity = _direction * speed;
	}
}
