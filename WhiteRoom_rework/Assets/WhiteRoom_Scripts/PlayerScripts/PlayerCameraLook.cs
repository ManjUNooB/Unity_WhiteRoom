using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------//
//	Contents	:PlayerCameraLook
//				 �v���C���[�̎��_�ړ��X�N���v�g
//	Author		:Ryuga Sakakibara
//				 �匴����
//				 HAL���É��Q�[������4�N
//				 HALnagoya GameCreate 4th grade
//	LastUpdate	:2022/05/03
//	Since		:2022/05/03
//	Detailes	:Asset(MiniFPSController)���Q�l�ɐ���
//------------------------------------------------------------------//
public class PlayerCameraLook : MonoBehaviour
{
	//--�ϐ��錾--//
	[SerializeField] Transform charactor;
	[SerializeField] float Sensitivity = 2.0f;
	[SerializeField] float Smoothing = 1.5f;

	Vector2 velocity;
	Vector2 frameVelocity;

	/**
     * Reset()
     * �G�f�B�^�ŃR���|�[�l���g�������̂Ƃ��ɌĂ΂��֐��炵��
     * AddComponent�����Ƃ���������ɌĂ΂��
     */
	private void Reset()
	{
		//�v���C���[�̃g�����X�t�H�[�����擾
		charactor = GetComponentInParent<PlayerMove>().transform;
	}

	// Start is called before the first frame update
	void Start()
	{
		//  �}�E�X�J�[�\�����Q�[����ʂɃ��b�N
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		//  �}�E�X����̓��͂��擾�E���_�ړ�
		Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * Sensitivity);
		frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / Smoothing);
		velocity += frameVelocity;
		velocity.y = Mathf.Clamp(velocity.y, -90, 90);

		//	���_�ړ��̑��x����J�������㉺�ɁA�R���g���[���[�����E�ɉ�]������B
		//	�Ȃ�قǁA�킩���B
		transform.localRotation = Quaternion.AngleAxis(velocity.y, Vector3.right);
		charactor.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
	}

}
