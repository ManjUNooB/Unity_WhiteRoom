using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    //  �������l
    //  �n�ʂ���̍ő勗���̐ݒ�炵���H
    //  ���C�L���X�g��n�ʂɔ�΂��Ă���Ɣ�r���ă`�F�b�N����̂��ȁH
    [SerializeField] float distanceThreshold = 0.15f;

    //  �n�ʂɐڒn���Ă��邩
    [SerializeField] bool isGrounded = true;

    //  �R�[���o�b�N�֐�?�炵��
    //  �n�ʂɍĐݒu�����Ƃ��ɌĂяo�����
    public event System.Action Grounded;

    //  �g�����X�t�H�[���̏����l
    const float originOffset = 0.001f;

    //--���C�L���X�g�p--//
    //  => : C#�̃����_���̏������炵���B���߂Č����B
    Vector3 RaycastOrigin => transform.position + Vector3.up * originOffset;
    float RaycastDistance => distanceThreshold + originOffset;

    void LastUpdate()
	{
        //  ���C�L���X�g��n�ʂɔ�΂��Đڒn���Ă��邩���`�F�b�N
        bool isGroundedNow = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);

        //  �󒆂ɂ��āA�n�ʂɐG��Ă���ꍇ�̃C�x���g�̌Ăяo���B
        if (isGroundedNow && !isGrounded) Grounded?.Invoke();

        //  �t���O�̍X�V
        isGrounded = isGroundedNow;
	}

    void OnDrawGizmosSelected()
	{
        //  ���������Ēn�ʂɐڒn���Ă��邩�ǂ������m���߂�
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, isGrounded ? Color.white : Color.red);
	}
}
