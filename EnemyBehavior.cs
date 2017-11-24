using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
	public float speed;
	public float attackDelay;
	public float health;
	public GameObject _bullet;
	

	public GameObject player;


	public void Move(Vector2 direction)
	{
		GetComponent<Rigidbody2D>().velocity += speed * direction;
		GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized;
	}

	public void TakeDamage()
	{
		health--;
		if (health<=0)
		{
			Destroy(gameObject);
		}
	}

	public void shoot(Transform origin,Vector2 direction)
	{
		GameObject aBullet = Instantiate(_bullet, origin.position, origin.rotation);
		aBullet.GetComponent<EnemyBullet>().setDirection(direction);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (LayerMask.LayerToName(other.gameObject.layer) == "Bullet(heros)")
		{
			TakeDamage();
			Destroy(other.gameObject);
		}
	}
}
