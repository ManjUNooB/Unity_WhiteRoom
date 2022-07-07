using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    //  しきい値
    //  地面からの最大距離の設定らしい？
    //  レイキャストを地面に飛ばしてそれと比較してチェックするのかな？
    [SerializeField] float distanceThreshold = 0.15f;

    //  地面に接地しているか
    [SerializeField] bool isGrounded = true;

    //  コールバック関数?らしい
    //  地面に再設置したときに呼び出される
    public event System.Action Grounded;

    //  トランスフォームの初期値
    const float originOffset = 0.001f;

    //--レイキャスト用--//
    //  => : C#のラムダ式の書き方らしい。初めて見た。
    Vector3 RaycastOrigin => transform.position + Vector3.up * originOffset;
    float RaycastDistance => distanceThreshold + originOffset;

    void LastUpdate()
	{
        //  レイキャストを地面に飛ばして接地しているかをチェック
        bool isGroundedNow = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);

        //  空中にいて、地面に触れている場合のイベントの呼び出し。
        if (isGroundedNow && !isGrounded) Grounded?.Invoke();

        //  フラグの更新
        isGrounded = isGroundedNow;
	}

    void OnDrawGizmosSelected()
	{
        //  線を引いて地面に接地しているかどうかを確かめる
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, isGrounded ? Color.white : Color.red);
	}
}
