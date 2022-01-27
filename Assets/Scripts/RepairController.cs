using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{
	//差し替える画像
	public Sprite defImages;

	//修理できた？
	private bool isRepair = false;

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
		if( other.gameObject.tag == "Player" && isRepair == false) {
			//プレイヤーが工具持っている
			if( PlayerController.Toolbox > 0) {
				//画像の差し替え（修理OK)
				GetComponent<SpriteRenderer>().sprite = defImages;

				//プレイヤーの工具を減らす
				PlayerController.Toolbox--;

				//効果音
				GetComponent<AudioSource>().Play();
				//完了
				isRepair = true;

				//プレイヤー、修理の数を加算
				PlayerController.Repair++;
			}
		}
	}
}
