using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
	private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			GetComponentInParent<WarriorBehavior>().SetTarget(target);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName(other.gameObject.layer)== "Enemy" && target == null)
		{
			target = other.gameObject;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		target = null;
	}
}
