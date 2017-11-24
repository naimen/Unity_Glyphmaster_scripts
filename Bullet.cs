using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed=7;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (transform.childCount <= 0)
		{
			Destroy(gameObject);
		}
	}

}
