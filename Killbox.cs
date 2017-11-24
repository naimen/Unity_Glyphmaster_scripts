using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Killbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		string layername = LayerMask.LayerToName(other.gameObject.layer);
		if (layername != "Heros")
		{
			Destroy(other.gameObject);	
		}
		
	}
}
