using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NezumiController : MonoBehaviour
{
    //移動させるコンポーネントを入れる
    private Rigidbody2D myRigidbody;

    // 移動量
    private float velocity = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for (velocity = 2.2f; velocity == 2.2f; velocity = 2.2f)
        {
            //左へ向く
            this.transform.localScale = new Vector2(-0.25f, 0.25f);

            // 右へ向く
            this.transform.localScale = new Vector2(0.25f, 0.25f);
        }
    }
}
