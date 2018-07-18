using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour {

	public SceneName myScene;
	public Animator popupScore;
	public GameObject BgMenu;
	public GameObject FrozenCover;
	public GameObject GoldenCover;

	public Text txtScore;
	public Text myScore;
	public Text txtHighScore;
	public GameObject batasKanan;
	public GameObject batasKiri;
	public GameObject batasBawah;
	public GameObject batasAtas;
	
	public GameObject PrefBuahBaik;
	public GameObject PrefBuahBusuk;
	private GameObject Baik;
	private GameObject Busuk;
	public GameObject KKParent;
	public GameObject SplashParent;

	public int probBuahBaik;
	public int probBuahBusuk;
	public int probBuahFrozen;
	public int probBuahGolden;

	int probTempBuahFrozen;
	int probTempBuahGolden;

	private GameObject Frozen;
	private GameObject Golden;
	
	public float minTimeSpawn = 0.01f;
	
	private float posX;

	//Buah Golden
	public GameObject Buah_Frozen;

	//Buah Frozen
	public GameObject Buah_Golden;

	//BuahBusuk
	public GameObject Buah_Apel_Busuk;
	public GameObject Buah_Jeruk_Busuk;
	public GameObject Buah_Mangga_Busuk;
	public GameObject Buah_Markisa_Busuk;
	public GameObject Buah_Pear_Busuk;
	public GameObject Buah_Semangka_Busuk;
	public GameObject Buah_Strawberry_Busuk;

	//BuahBaik
	public GameObject Buah_Anggur_Baik;
	public GameObject Buah_Apel_Baik;
	public GameObject Buah_Jambu_Baik;
	public GameObject Buah_Jeruk_Baik;
	public GameObject Buah_Mangga_Baik;
	public GameObject Buah_Markisa_Baik;
	public GameObject Buah_Melon_Baik;
	public GameObject Buah_Pear_Baik;
	public GameObject Buah_Semangka_Baik;
	public GameObject Buah_Strawberry_Baik;

	public AudioSource soundPlay;
	public AudioSource soundOver;

	//public Animator popupScore;
	
	//int count = 0;
	int score = 0;
	float spawn = 0;
	public float fastSpawn = 1;
	int RandomKK;
	public float gravity = 0.1f;
	
	bool flagGameOver = false;
	public int HasilScore = 0;

	public float MaxFrozenTime = 0;
	float FrozenTime = 0;

	public float MaxGoldenTime = 0;
	float GoldenTime = 0;

	float checkTimePowerUp = 0;
	bool checkPowerUp = true;

	public float setTimePowerUp = 10.5f;

	[HideInInspector]
	public int StatusPowerUp = 0; // 0 = Biasa, 1 = Frozen, 2 = Golden
	
	public void Restart()
	{
		BgMenu.SetActive (true);
		fastSpawn = 1;
		Singleton<timeBar>.Instance.currentTime = Singleton<timeBar>.Instance.timer;
		Singleton<timeBar>.Instance.conditionGameOver = false;
		flagGameOver = false;
		gravity = 0.1f;
		score = 0;
		txtScore.text = "0";
		popupScore.SetTrigger("hide");
		checkPowerUp = true;
		checkTimePowerUp = 0;
		GoldenTime = 0;
		FrozenTime = 0;
		StatusPowerUp = 0;
		Debug.Log ("Current time = "+Singleton<timeBar>.Instance.currentTime);
		Debug.Log ("Current time = "+Singleton<timeBar>.Instance.timer);
		Debug.Log ("Current time = "+Singleton<timeBar>.Instance.conditionGameOver);
		if (PlayerPrefs.GetInt("PlaySound") == 0) 
		{
			soundPlay.Play ();
		}
	}
	
	// Use this for initialization
	void Start () {
		//txtHighScore.text = PlayerPrefs.GetInt ("score").ToString ();
		if (PlayerPrefs.GetInt("PlaySound") == 0) 
		{
			soundPlay.Play ();
		}
		probTempBuahFrozen = probBuahFrozen;
		probTempBuahGolden = probBuahGolden;
	}
	// Update is called once per frame
	void Update () {
		removeFrozen ();
		removeGolden ();
		backtoMain ();
		spawn = spawn + Time.deltaTime;
		checkTimePowerUp = checkTimePowerUp + Time.deltaTime;
		if (checkTimePowerUp >= setTimePowerUp && checkPowerUp == true) 
		{
			Debug.Log(checkTimePowerUp);
			checkPowerUp = false;
			checkTimePowerUp = 0;
		}
		if (spawn >= fastSpawn && Singleton<timeBar>.Instance.currentTime != 0) 
		{
			if(gravity <= 1.0f)
			{
				gravity = gravity + 0.01f;
			}
			spawn = 0;
			if(fastSpawn >= 0.45f)
			{
				fastSpawn = fastSpawn - minTimeSpawn;
			}
			RandomKK = Random.Range(1, (probBuahBaik+probBuahBusuk+probTempBuahFrozen+probTempBuahGolden+1));
			if(RandomKK <= probBuahBaik)
			{
				//Instantiate Kebaikan

				int RandomBuahBaik = Random.Range(1, 11);
				//Random.Range(1, 10);

				if(RandomBuahBaik == 1)
				{
					Baik = Instantiate (Buah_Anggur_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 2)
				{
					Baik = Instantiate (Buah_Apel_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 3)
				{
					Baik = Instantiate (Buah_Jambu_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 4)
				{
					Baik = Instantiate (Buah_Jeruk_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 5)
				{
					Baik = Instantiate (Buah_Mangga_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 6)
				{
					Baik = Instantiate (Buah_Markisa_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 7)
				{
					Baik = Instantiate (Buah_Melon_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 8)
				{
					Baik = Instantiate (Buah_Pear_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBaik == 9)
				{
					Baik = Instantiate (Buah_Semangka_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else
				{
					Baik = Instantiate (Buah_Strawberry_Baik, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}

				Baik.transform.SetParent (KKParent.gameObject.transform, false);
				if(StatusPowerUp == 1)
				{
					Baik.rigidbody2D.gravityScale = 0.1f;
				}
				else
				{
					Baik.rigidbody2D.gravityScale = gravity;
				}
			}
			else if(RandomKK > probBuahBaik && RandomKK <= probBuahBaik + probBuahBusuk && StatusPowerUp == 0)
			{
				//Instantiate Kejahatan
				int RandomBuahBusuk = Random.Range(1, 8);
				if(RandomBuahBusuk == 1)
				{
					Busuk = Instantiate (Buah_Apel_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBusuk == 2)
				{
					Busuk = Instantiate (Buah_Jeruk_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBusuk == 3)
				{
					Busuk = Instantiate (Buah_Mangga_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBusuk == 4)
				{
					Busuk = Instantiate (Buah_Markisa_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBusuk == 5)
				{
					Busuk = Instantiate (Buah_Pear_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else if(RandomBuahBusuk == 6)
				{
					Busuk = Instantiate (Buah_Semangka_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				else
				{
					Busuk = Instantiate (Buah_Strawberry_Busuk, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				}
				
				Busuk.transform.SetParent (KKParent.gameObject.transform, false);
				if(StatusPowerUp == 1)
				{
					Busuk.rigidbody2D.gravityScale = 0.1f;
				}
				else
				{
					Busuk.rigidbody2D.gravityScale = gravity;
				}

			}
			else if(RandomKK > probBuahBaik + probBuahBusuk && RandomKK <= probBuahBaik + probBuahBusuk + probTempBuahFrozen && checkPowerUp == false)
			{
				checkPowerUp = true;
				Frozen = Instantiate (Buah_Frozen, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
				Frozen.transform.SetParent (KKParent.gameObject.transform, false);
				if(StatusPowerUp == 1)
				{
					Frozen.rigidbody2D.gravityScale = 0.1f;
				}
				else
				{
					Frozen.rigidbody2D.gravityScale = gravity;
				}
			}
			else
			{
				if(checkPowerUp == false)
				{
					checkPowerUp = true;
					Golden = Instantiate (Buah_Golden, new Vector2 (Random.Range (batasKiri.transform.localPosition.x + 100.0f, batasKanan.transform.localPosition.x - 100.0f), batasAtas.transform.localPosition.y), Quaternion.identity) as GameObject;
					Golden.transform.SetParent (KKParent.gameObject.transform, false);
					if(StatusPowerUp == 1)
					{
						Golden.rigidbody2D.gravityScale = 0.1f;
					}
					else
					{
						Golden.rigidbody2D.gravityScale = gravity;
					}
				}
			}
		}
		if (Singleton<timeBar>.Instance.currentTime == 0) 
		{
			if(flagGameOver == false)
			{
				if(PlayerPrefs.GetInt("PlaySound") == 0)
				{
					soundPlay.Stop();
					soundOver.Play();
				}
				if(int.Parse(txtScore.text) >= PlayerPrefs.GetInt("score"))
				{
					myScore.text = txtScore.text;
					txtHighScore.text = txtScore.text;
				}
				else{
					myScore.text = txtScore.text;
					txtHighScore.text = PlayerPrefs.GetInt("score").ToString();
				}
				HasilScore = int.Parse(txtScore.text);
				Singleton<FacebookAPIManager>.Instance.PublishScore((int)HasilScore);
				Singleton<ScorePopup>.Instance.isShown = true;
				popupScore.SetTrigger("show");
				flagGameOver = true;
			}
		}
	}
	
	public void kurangWaktu() //method untuk mengurangi waktu ketika salah tekan
	{
		Singleton<timeBar>.Instance.currentTime = Singleton<timeBar>.Instance.currentTime - 3.0f;
	}
	
	public void tambahWaktu() //method untuk menambah waktu ketika menekan dengan benar
	{
		if (Singleton<timeBar>.Instance.conditionGameOver != true)
		{
			Singleton<timeBar>.Instance.currentTime = Singleton<timeBar>.Instance.currentTime + 1.0f;
			tambahScore();
		}
	}
	
	public void tambahScore() //method untuk menambah score ketika benar
	{
		if (Singleton<timeBar>.Instance.conditionGameOver != true) 
		{
			if(StatusPowerUp == 2)
			{
				score = score + 20;
				Debug.Log (score);
				txtScore.text = score.ToString();
			}
			else
			{
				score = score + 10;
				Debug.Log (score);
				txtScore.text = score.ToString();
			}
		}
	}

	public void SetGolden()
	{
		StatusPowerUp = 2;
	}

	void removeGolden()
	{
		if (StatusPowerUp == 2) 
		{
			probTempBuahGolden = 0;
			GoldenTime = GoldenTime + Time.deltaTime;
			if(GoldenTime >= MaxGoldenTime)
			{
				probTempBuahGolden = probBuahGolden;
				StatusPowerUp = 0;
				GoldenTime = 0.0f;
                Singleton<GoldenShow>.Instance.Hide();
				GoldenCover.SetActive(false);
			}
		}
	}

	public void SetFrozen()
	{
		StatusPowerUp = 1;
	}

	void removeFrozen()
	{
		if (StatusPowerUp == 1) 
		{
			probTempBuahFrozen = 0;
			FrozenTime = FrozenTime + Time.deltaTime;
			if(FrozenTime >= MaxFrozenTime)
			{
				StatusPowerUp = 0;
				FrozenTime = 0.0f;
				if(gravity <= 0.5f)
				{
					gravity = 0.15f;
				}
				else if(gravity <= 0.75f)
				{
					gravity = 0.25f;
				}
				else
				{
					gravity = 0.5f;
				}
				probTempBuahFrozen = probBuahFrozen;
				Singleton<FrozenShow>.Instance.Hide ();
				FrozenCover.SetActive(false);
			}
		}
	}

	void backtoMain()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel (myScene.ToString ());
		}
	}

	public void showFrozenCover()
	{
		FrozenCover.SetActive (true);
	}
	public void showGoldenCover()
	{
		GoldenCover.SetActive (true);
	}
}
