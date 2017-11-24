using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public int health;
	public AudioClip hit;

	public GameObject death;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
		movePlayer(direction);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy" ||
		    LayerMask.LayerToName(other.gameObject.layer) == "Bullet(enemy)")
		{
			TakeDamage(other);
		}

	}

	void movePlayer(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint( new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint( new Vector2(0.65f,1));

		max.x = max.x - 0.40f;
		max.y = max.y - 0.65f;
		
		min.x = min.x + 0.63f;
		min.y = min.y + 0.18f;

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		transform.position = pos;
	
	}

	void TakeDamage( Collider2D other)
	{
		GetComponent<AudioSource>().PlayOneShot(hit);
		if (health <= 0)
		{
			Destroy(other.gameObject);
			Instantiate(death,transform.position,transform.rotation);
			Destroy(gameObject);
		}
		else
		{
			Destroy(GetComponentInChildren<CompanionControl>().GetCompanions()[health - 1]);
			health--;
		}
		
	}
}
