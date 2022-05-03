using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------//
//	Contents	: PlayerMove
//				  �v���C���[�̈ړ��X�N���v�g
//				  Asset(MiniFPSController)���Q�l�ɐ���
//	Author		: Ryuga Sakakibara
//				  �匴����
//				  HAL���É��Q�[������4�N
//				  HALnagoya GameCreate 4th grade
//	Detailes	: Asset(MiniFPSController)���Q�l�ɐ���
//	Log			: 2022/04/22
//				  �X�N���v�g�쐬
//				  2022/05/03
//				  �W�����v������PlayerMove�ɓ���
//------------------------------------------------------------------//
public class PlayerMove : MonoBehaviour
{
	//--�ϐ��錾--//
	[SerializeField] float moveSpeed = 5;


	[Header("RunningConfig")]
	public bool canRun = true;
	public bool IsRunning{ get; private set; }
	[SerializeField] float runningSpeed = 9;
	[SerializeField] KeyCode runningKey = KeyCode.LeftShift;

	[Header("JumpConfig")]
	[SerializeField] float jumpStrength = 2;
	[SerializeField] event System.Action playerJumped;
	[Tooltip("�󒆃W�����v�̖h�~")]
	[SerializeField] PlayerGroundCheck groundCheck;
	[SerializeField] KeyCode jumpKey = KeyCode.Space;

	Rigidbody rigidbody;

	void Reset()
	{
		//	GroundCheck�̎擾
		groundCheck = GetComponentInChildren<PlayerGroundCheck>();	
	}

	//	Rigidbody�̎擾
	//	Awake�̂ق���Start����ɌĂ΂��炵��
	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody>();
	}

	//	�v���C���[�̈ړ�(�����E����)����
	//	��莞�Ԃ��Ƃɂ�΂��Update�炵��
	//	�������Z�O�̌Ăяo��
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

	//	�e�v�Z���I��������Ƃɂ�΂��Update�炵��
	void LateUpdate()
	{
		if (Input.GetButtonDown("Jump"))// && !groundCheck || groundCheck.isGrounded)
		{
			rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
			playerJumped.Invoke();
		}
	}
}
