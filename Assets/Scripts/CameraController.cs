using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//�v���C���[
	private GameObject Player;

	//�ړ��ʁi�㉺�j
	private float delta_y = 0.0f;

	//�J�����I�t�Z�b�g
	private float offset = 2.25f;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̎擾
		Player = GameObject.Find( "Player");
    }

    // Update is called once per frame
    void Update()
    {
		// ���W�̎擾
        Vector3 position = this.transform.position;
		
		// �J�����̈ړ�
		delta_y = (Player.transform.position.y + offset) - position.y;

		// �f���^���Z
		position.y += (delta_y * Time.deltaTime);

		// ���W�̍X�V
        this.transform.position = position;
    }
}