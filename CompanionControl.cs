using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionControl : MonoBehaviour
{
	public GameObject warrior;
	private GameObject[] companions;


	// Use this for initialization
	void Start ()
	{
		companions = new GameObject[transform.childCount];
		
		for(int i=0; i<transform.childCount;i++)
		{
			Transform position = transform.GetChild(i);
			companions[i] = Instantiate(warrior, position.position, position.rotation);
			companions[i].GetComponent<WarriorBehavior>()._position = position.gameObject;
		}
	}

	private void Awake()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public GameObject[] GetCompanions()
	{
		return companions;
	}
}
