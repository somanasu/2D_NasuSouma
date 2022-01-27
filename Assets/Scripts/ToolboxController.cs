using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolboxController : MonoBehaviour
{
	//取得フラグ
	private bool isGet = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//物理演算を無視する衝突　※普段と違うので注意
	void OnTriggerEnter2D(Collider2D other) {
		//プレイヤー？
		if( other.gameObject.tag == "Player" && isGet == false) {
			//ツールボックスの数を加算
			PlayerController.Toolbox++;

			//効果音
			GetComponent<AudioSource>().Play();

			//取得した
			isGet = true;

			//破棄 ※0.5秒を遅れて消える
			Destroy( this.gameObject, 0.5f);
		}
	}
}
