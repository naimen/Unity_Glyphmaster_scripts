using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBehavior : MonoBehaviour
{
	public GameObject _position;
	private Vector3 _direction;


	private float speed = 1f;

	private GameObject _target;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_target == null && _position != null)
		{
			transform.position = _position.transform.position;
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if ( other.gameObject.Equals(_target))
		{
			Vector3 direction = other.transform.position - transform.position;
			_direction = direction / direction.magnitude;
			GetComponent<Rigidbody2D>().velocity = speed * _direction;
			other.GetComponent<EnemyBehavior>().Invoke("TakeDamage",1f);
			
		}
	}


	public void SetTarget(GameObject target)
	{
		_target = target;
	}
}
