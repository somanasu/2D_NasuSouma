using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NezumiController : MonoBehaviour
{
    //�ړ�������R���|�[�l���g������
    private Rigidbody2D myRigidbody;

    // �ړ���
    private float velocity = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for (velocity = 2.2f; velocity == 2.2f; velocity = 2.2f)
        {
            //���֌���
            this.transform.localScale = new Vector2(-0.25f, 0.25f);

            // �E�֌���
            this.transform.localScale = new Vector2(0.25f, 0.25f);
        }
    }
}
