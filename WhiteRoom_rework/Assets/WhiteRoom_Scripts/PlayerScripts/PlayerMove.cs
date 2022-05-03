using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------//
//	Contents	: PlayerMove
//				  プレイヤーの移動スクリプト
//				  Asset(MiniFPSController)を参考に制作
//	Author		: Ryuga Sakakibara
//				  榊原龍我
//				  HAL名古屋ゲーム制作4年
//				  HALnagoya GameCreate 4th grade
//	Detailes	: Asset(MiniFPSController)を参考に制作
//	Log			: 2022/04/22
//				  スクリプト作成
//				  2022/05/03
//				  ジャンプ処理をPlayerMoveに統合
//------------------------------------------------------------------//
public class PlayerMove : MonoBehaviour
{
	//--変数宣言--//
	[SerializeField] float moveSpeed = 5;


	[Header("RunningConfig")]
	public bool canRun = true;
	public bool IsRunning{ get; private set; }
	[SerializeField] float runningSpeed = 9;
	[SerializeField] KeyCode runningKey = KeyCode.LeftShift;

	[Header("JumpConfig")]
	[SerializeField] float jumpStrength = 2;
	[SerializeField] event System.Action playerJumped;
	[Tooltip("空中ジャンプの防止")]
	[SerializeField] PlayerGroundCheck groundCheck;
	[SerializeField] KeyCode jumpKey = KeyCode.Space;

	Rigidbody rigidbody;

	void Reset()
	{
		//	GroundCheckの取得
		groundCheck = GetComponentInChildren<PlayerGroundCheck>();	
	}

	//	Rigidbodyの取得
	//	AwakeのほうがStartより先に呼ばれるらしい
	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody>();
	}

	//	プレイヤーの移動(歩く・走る)処理
	//	一定時間ごとによばれるUpdateらしい
	//	物理演算前の呼び出し
	void FixedUpdate()
	{
		//	フラグとキー入力が有効な場合のみ
		if (canRun && Input.GetKey(runningKey)){
			IsRunning = true;
			Debug.Log("IsRunning:" + IsRunning);
		}
		else{
			IsRunning = false;
			Debug.Log("IsRunning:" + IsRunning);
		}

		float targetMovingSpeed;

		if(IsRunning){
			targetMovingSpeed = runningSpeed;
			Debug.Log("targetMovingSpeed:" + targetMovingSpeed);
		}
		else{
			targetMovingSpeed = moveSpeed;
			Debug.Log("targetMovingSpeed:" + targetMovingSpeed);
		}

		//プレイヤー移動
		Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
		rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x,rigidbody.velocity.y,targetVelocity.y);

	}

	//	各計算が終わったあとによばれるUpdateらしい
	void LateUpdate()
	{
		if (Input.GetButtonDown("Jump"))// && !groundCheck || groundCheck.isGrounded)
		{
			rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
			playerJumped.Invoke();
		}
	}
}
