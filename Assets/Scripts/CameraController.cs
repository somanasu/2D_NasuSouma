using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//プレイヤー
	private GameObject Player;

	//移動量（上下）
	private float delta_y = 0.0f;

	//カメラオフセット
	private float offset = 2.25f;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの取得
		Player = GameObject.Find( "Player");
    }

    // Update is called once per frame
    void Update()
    {
		// 座標の取得
        Vector3 position = this.transform.position;
		
		// カメラの移動
		delta_y = (Player.transform.position.y + offset) - position.y;

		// デルタ加算
		position.y += (delta_y * Time.deltaTime);

		// 座標の更新
        this.transform.position = position;
    }
}