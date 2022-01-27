using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//アニメーションするためのコンポーネントを入れる
	private Animator myAnimator;

	//移動させるコンポーネントを入れる
	private Rigidbody2D myRigidbody;

	//移動量
	private float velocity = 2.2f;

	//ジャンプ量
	private float jumppower = 5.0f;

	//地面に接触
	private bool isGround = false;

	//トランポリン
	private float trampolinepower = 8.0f;

	//所有しているツールボックスの数 ※注意 static型
	static public int Toolbox;

	//修理した個所のカウンター ※注意 static型
	static public int Repair;

	//表情のオブジェクト
	public GameObject faceNormal;
	public GameObject faceSmile;
	public GameObject facePien;
	public GameObject faceDamage;

	//表情のタイマー
	private float faceTimer = 0f;

	//ツールボックスのUI
	public GameObject uiToolbox1;
	public GameObject uiToolbox2;
	public GameObject uiToolbox3;

	// Start is called before the first frame update
	void Start()
	{
		//アニメータコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();

		//Rigidbodyコンポーネントを取得
		this.myRigidbody = GetComponent<Rigidbody2D>();

		//static型の変数で不具合が生じることがあるので、ここで最初に初期化する。
		Toolbox = 0;

		//static型の変数で不具合が生じることがあるので、ここで最初に初期化する。
		Repair = 0;
	}

	// Update is called once per frame
	void Update()
	{
		//移動
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			//左へ向く
			this.transform.localScale = new Vector2(-0.25f, 0.25f);

			//ジャンプ
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
			//右へ向く
			this.transform.localScale = new Vector2(0.25f, 0.25f);

			//ジャンプ
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
			//ジャンプ
			if (Input.GetKey(KeyCode.Space) && isGround)
			{
				this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
			}
		}
		//表情のタイマー（経過時間の秒）
		faceTimer += Time.deltaTime;
		//表情をノーマルへ戻す
		if (faceTimer > 1.0f)
		{
			//表情
			faceNormal.SetActive(true);
			faceSmile.SetActive(false);
			facePien.SetActive(false);
			faceDamage.SetActive(false);
		}
		//ツールボックスのUI
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

	//衝突した
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionEnter2D: " + other.gameObject.tag);

		//地面 ※床が多いので床は全て Untaggedで実装する。
		if (other.gameObject.tag == "Untagged")
		{
			isGround = true;
		}

		//トランポリン
		if (other.gameObject.tag == "Trampoline")
		{
			this.myRigidbody.velocity = new Vector2(0.0f, trampolinepower);
		}

		//敵（ねずみ）
		if (other.gameObject.tag == "Enemy")
		{
			//表情
			faceNormal.SetActive(false);
			faceSmile.SetActive(false);
			facePien.SetActive(true);
			faceDamage.SetActive(false);
			//表情のタイマーをリセット
			faceTimer = 0f;
		}
	}

	//衝突した（補強）
	void OnCollisionStay2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionStay2D: " + other.gameObject.tag);

		//地面 ※床が多いので床は全て Untaggedで実装する。
		if (other.gameObject.tag == "Untagged")
		{
			isGround = true;
		}

		//トランポリン
		if (other.gameObject.tag == "Trampoline")
		{
			this.myRigidbody.velocity = new Vector2(0.0f, trampolinepower);

			//効果音
			GetComponent<AudioSource>().Play();
		}
	}

	//衝突から離れた
	void OnCollisionExit2D(Collision2D other)
	{
		//Debug.Log( "OnCollisionExit2D: " + other.gameObject.tag);

		//地面 ※床が多いので床は全て Untaggedで実装する。
		if (other.gameObject.tag == "Untagged")
		{
			isGround = false;
		}
	}

		//衝突（トリガー）※ツールボックス、修理箇所など
	void OnTriggerEnter2D(Collider2D other)
	{
		//ツールボックス
		if (other.gameObject.tag == "ToolBox")
		{
		        //表情
		        faceNormal.SetActive(false);
		        faceSmile.SetActive(true);
				facePien.SetActive(false);
				faceDamage.SetActive(false);
				//表情のタイマーをリセット
				faceTimer = 0f;
			}
	}
	}
