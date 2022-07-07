using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAreaCS : MonoBehaviour
{
	GameObject Door;
	
	[Header ("接触した相手のタグ")]
	[SerializeField] private string pairTag = "Player";

	//	エリア内フラグ
	private bool isArea = false;
	
	// Start is called before the first frame update
	void Start()
	{
		//	親オブジェクトの取得
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
