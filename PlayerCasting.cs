using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
	public GameObject spells;

	public GameObject castingPos;

	private bool cooldown;
	private readonly MagicKeyCombo bulletMagicKeyCombo = new MagicKeyCombo(new string[]{"[1]","[2]","[3]"});

	private void Start()
	{
		cooldown = false;
	}

	IEnumerator BulletCasting()
	{
		int count = 0;
		cooldown = true;
		while (count < 10) {
			Instantiate (spells, castingPos.transform.position, castingPos.transform.rotation);
			count++;
			yield return new WaitForSeconds(0.05f);
			
		}
		yield return new WaitForSeconds(1f);
		cooldown = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (bulletMagicKeyCombo.check() && !cooldown)
		{
			StartCoroutine("BulletCasting");
		}
		
	}

}
