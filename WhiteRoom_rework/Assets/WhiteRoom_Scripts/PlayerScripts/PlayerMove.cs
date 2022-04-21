using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5;

	[Header("Running")]
	[SerializeField] float runningSpeed = 9;
	[SerializeField] KeyCode runningKey = KeyCode.LeftShift;
	public bool canRun = true;
	public bool IsRunning{ get; private set; }

	Rigidbody rigidbody;

	//	Awake�̂ق���Start����ɌĂ΂��炵��
	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//	�t���O�ƃL�[���͂��L���ȏꍇ�̂�
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

		//�v���C���[�ړ�
		Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
		rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x,rigidbody.velocity.y,targetVelocity.y);

	}
}
