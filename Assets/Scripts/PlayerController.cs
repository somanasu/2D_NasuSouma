using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//�A�j���[�V�������邽�߂̃R���|�[�l���g������
	private Animator myAnimator;

	//�ړ�������R���|�[�l���g������
	private Rigidbody2D myRigidbody;

	//�ړ���
	private float velocity = 2.2f;

	//�W�����v��
	private float jumppower = 5.0f;

	//�n�ʂɐڐG
	private bool isGround = false;

	//�g�����|����
	private float trampolinepower = 8.0f;

	//���L���Ă���c�[���{�b�N�X�̐� ������ static�^
	static public int Toolbox;

	//�C���������̃J�E���^�[ ������ static�^
	static public int Repair;

	//�\��̃I�u�W�F�N�g
	public GameObject faceNormal;
	public GameObject faceSmile;
	public GameObject facePien;
	public GameObject faceDamage;

	//�\��̃^�C�}�[
	private float faceTimer = 0f;

	//�c�[���{�b�N�X��UI
	public GameObject uiToolbox1;
	public GameObject uiToolbox2;
	public GameObject uiToolbox3;

	// Start is called before the first frame update
	void Start()
	{
		//�A�j���[�^�R���|�[�l���g���擾
		this.myAnimator = GetComponent<Animator>();

		//Rigidbody�R���|�[�l���g���擾
		this.myRigidbody = GetComponent<Rigidbody2D>();

		//static�^�̕ϐ��ŕs��������邱�Ƃ�����̂ŁA�����ōŏ��ɏ���������B
		Toolbox = 0;

		//static�^�̕ϐ��ŕs��������邱�Ƃ�����̂ŁA�����ōŏ��ɏ���������B
		Repair = 0;
	}

	// Update is called once per frame
	void Update()
	{
		//�ړ�
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			//���֌���
			this.transform.localScale = new Vector2(-0.25f, 0.25f);

			//�W�����v
			if (Input.GetKey(KeyCode.Space) && isGround)
			{
				this.myRigidbody.velocity = new Vector2(-velocity, jumppower);
			}
			else
			{
				this.myRigidbody.velocity = new Vector2(-velocity, this.myRigidbody.velocity.y);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			//�E�֌���
			this.transform.localScale = new Vector2(0.25f, 0.25f);

			//�W�����v
			if (Input.GetKey(KeyCode.Space) && isGround)
			{
				this.myRigidbody.velocity = new Vector2(velocity, jumppower);
			}
			else
			{
				this.myRigidbody.velocity = new Vector2(velocity, this.myRigidbody.velocity.y);
			}
		}
		else
		{
			//�W�����v
			if (Input.GetKey(KeyCode.Space) && isGround)
			{
				this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
			}
		}
		//�\��̃^�C�}�[�i�o�ߎ��Ԃ̕b�j
		faceTimer += Time.deltaTime;
		//�\����m�[�}���֖߂�
		if (faceTimer > 1.0f)
		{
			//�\��
			faceNormal.SetActive(true);
			faceSmile.SetActive(false);
			facePien.SetActive(false);
			faceDamage.SetActive(false);
		}
		//�c�[���{�b�N�X��UI
		if (Toolbox == 0)
		{
			uiToolbox1.SetActive(false);
			uiToolbox2.SetActive(false);
			uiToolbox3.SetActive(false);
		}
		else if (Toolbox == 1)
		{
			uiToolbox1.SetActive(true);
			uiToolbox2.SetActive(false);
			uiToolbox3.SetActive(false);
		}
		else if (Toolbox == 2)
		{
			uiToolbox1.SetActive(true);
			uiToolbox2.SetActive(true);
			uiToolbox3.SetActive(false);
		}
		else if (Toolbox == 3)
		{
			uiToolbox1.SetActive(true);
			uiToolbox2.SetActive(true);
			uiToolbox3.SetActive(true);
		}
	}

	//�Փ˂���
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionEnter2D: " + other.gameObject.tag);

		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if (other.gameObject.tag == "Untagged")
		{
			isGround = true;
		}

		//�g�����|����
		if (other.gameObject.tag == "Trampoline")
		{
			this.myRigidbody.velocity = new Vector2(0.0f, trampolinepower);
		}

		//�G�i�˂��݁j
		if (other.gameObject.tag == "Enemy")
		{
			//�\��
			faceNormal.SetActive(false);
			faceSmile.SetActive(false);
			facePien.SetActive(true);
			faceDamage.SetActive(false);
			//�\��̃^�C�}�[�����Z�b�g
			faceTimer = 0f;
		}
	}

	//�Փ˂����i�⋭�j
	void OnCollisionStay2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionStay2D: " + other.gameObject.tag);

		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if (other.gameObject.tag == "Untagged")
		{
			isGround = true;
		}

		//�g�����|����
		if (other.gameObject.tag == "Trampoline")
		{
			this.myRigidbody.velocity = new Vector2(0.0f, trampolinepower);

			//���ʉ�
			GetComponent<AudioSource>().Play();
		}
	}

	//�Փ˂��痣�ꂽ
	void OnCollisionExit2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionExit2D: " + other.gameObject.tag);

		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if (other.gameObject.tag == "Untagged")
		{
			isGround = false;
		}
	}

		//�Փˁi�g���K�[�j���c�[���{�b�N�X�A�C���ӏ��Ȃ�
	void OnTriggerEnter2D(Collider2D other)
	{
		//�c�[���{�b�N�X
		if (other.gameObject.tag == "ToolBox")
		{
		        //�\��
		        faceNormal.SetActive(false);
		        faceSmile.SetActive(true);
				facePien.SetActive(false);
				faceDamage.SetActive(false);
				//�\��̃^�C�}�[�����Z�b�g
				faceTimer = 0f;
			}
	}
	}
