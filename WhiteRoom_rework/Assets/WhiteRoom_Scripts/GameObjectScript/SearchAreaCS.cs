using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAreaCS : MonoBehaviour
{
	GameObject Door;
	
	[Header ("�ڐG��������̃^�O")]
	[SerializeField] private string pairTag = "Player";

	//	�G���A���t���O
	private bool isArea = false;
	
	// Start is called before the first frame update
	void Start()
	{
		//	�e�I�u�W�F�N�g�̎擾
		Door = transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == pairTag)
		{

		}
	}
}
