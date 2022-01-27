using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{
	//�����ւ���摜
	public Sprite defImages;

	//�C���ł����H
	private bool isRepair = false;

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
		if( other.gameObject.tag == "Player" && isRepair == false) {
			//�v���C���[���H����Ă���
			if( PlayerController.Toolbox > 0) {
				//�摜�̍����ւ��i�C��OK)
				GetComponent<SpriteRenderer>().sprite = defImages;

				//�v���C���[�̍H������炷
				PlayerController.Toolbox--;

				//���ʉ�
				GetComponent<AudioSource>().Play();
				//����
				isRepair = true;

				//�v���C���[�A�C���̐������Z
				PlayerController.Repair++;
			}
		}
	}
}
