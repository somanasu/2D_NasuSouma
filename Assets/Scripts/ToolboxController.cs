using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolboxController : MonoBehaviour
{
	//�擾�t���O
	private bool isGet = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//�������Z�𖳎�����Փˁ@�����i�ƈႤ�̂Œ���
	void OnTriggerEnter2D(Collider2D other) {
		//�v���C���[�H
		if( other.gameObject.tag == "Player" && isGet == false) {
			//�c�[���{�b�N�X�̐������Z
			PlayerController.Toolbox++;

			//���ʉ�
			GetComponent<AudioSource>().Play();

			//�擾����
			isGet = true;

			//�j�� ��0.5�b��x��ď�����
			Destroy( this.gameObject, 0.5f);
		}
	}
}
