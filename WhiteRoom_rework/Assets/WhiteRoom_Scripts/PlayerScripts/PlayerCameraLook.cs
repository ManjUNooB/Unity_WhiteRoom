using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------//
//	Contents	:PlayerCameraLook
//				 プレイヤーの視点移動スクリプト
//	Author		:Ryuga Sakakibara
//				 榊原龍我
//				 HAL名古屋ゲーム制作4年
//				 HALnagoya GameCreate 4th grade
//	LastUpdate	:2022/05/03
//	Since		:2022/05/03
//	Detailes	:Asset(MiniFPSController)を参考に制作
//------------------------------------------------------------------//
public class PlayerCameraLook : MonoBehaviour
{
	//--変数宣言--//
	[SerializeField] Transform charactor;
	[SerializeField] float Sensitivity = 2.0f;
	[SerializeField] float Smoothing = 1.5f;

	Vector2 velocity;
	Vector2 frameVelocity;

	/**
     * Reset()
     * エディタでコンポーネント初期化のときに呼ばれる関数らしい
     * AddComponentしたときだったりに呼ばれる
     */
	private void Reset()
	{
		//プレイヤーのトランスフォームを取得
		charactor = GetComponentInParent<PlayerMove>().transform;
	}

	// Start is called before the first frame update
	void Start()
	{
		//  マウスカーソルをゲーム画面にロック
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		//  マウスからの入力を取得・視点移動
		Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * Sensitivity);
		frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / Smoothing);
		velocity += frameVelocity;
		velocity.y = Mathf.Clamp(velocity.y, -90, 90);

		//	視点移動の速度からカメラを上下に、コントローラーを左右に回転させる。
		//	なるほど、わからん。
		transform.localRotation = Quaternion.AngleAxis(velocity.y, Vector3.right);
		charactor.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
	}

}
