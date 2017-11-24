using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter: MonoBehaviour
{

	public GameObject[] waves;

	private int currentWave;

	private void Start()
	{
		Invoke("beginWave",10f);
		
	}

	IEnumerator Emit()
	{
		if (waves.Length == 0)
		{
			yield break;
		}
		
		while (true)
		{
			GameObject wave = Instantiate(waves[currentWave], transform.position, Quaternion.identity);
			wave.transform.parent = transform;

			while (wave.transform.childCount !=0)
			{
				yield return new WaitForEndOfFrame();
			}
			Destroy(wave);

			if (waves.Length <= ++currentWave)
			{
				currentWave = 0;
				yield break;
			}
		}
	}

	void beginWave()
	{
		StartCoroutine("Emit");
	}
}
