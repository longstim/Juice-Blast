using UnityEngine;
using System.Collections;

public class ScorePopup : Singleton<ScorePopup> {

	public GameObject MenuBar;
	public GameObject parentInformasi;
	public Animator myAnimator;
	public GameObject informasi1;
	public GameObject informasi2;
	public GameObject informasi3;
	public GameObject informasi4;
	public GameObject informasi5;
	public GameObject informasi6;
	public GameObject informasi7;
	public GameObject informasi8;
	public GameObject informasi9;
	public GameObject informasi10;
	private GameObject informasi;

	public bool isShown;

	void Start()
	{

	}

	void Update()
	{
		HideMenuBar ();
		ShowInformasi ();
	}

	public void HideMenuBar()
	{
		if (IsShowing)
		{
			MenuBar.SetActive (false);
		} 
	}

	void ShowInformasi()
	{
		if (IsShowing && isShown)
		{
			RandomInformasi();
			isShown=false;
		}
	}

	public void DestroyInformasi()
	{
		if (informasi != null) 
		{
			Destroy(informasi.gameObject);
		}
	}

	void RandomInformasi()
	{
		int rand = Random.Range (1, 11);

		if (rand == 1)
		{
			informasi = Instantiate(informasi1) as GameObject;
		}
		else if (rand == 2)
		{
			informasi = Instantiate(informasi2) as GameObject;
		}
		else if (rand == 3)
		{
			informasi = Instantiate(informasi3) as GameObject;
		}
		else if (rand == 4)
		{
			informasi = Instantiate(informasi4) as GameObject;
		}
		else if (rand == 5)
		{
			informasi = Instantiate(informasi5) as GameObject;
		}
		else if (rand == 6)
		{
			informasi = Instantiate(informasi6) as GameObject;
		}
		else if (rand == 7)
		{
			informasi = Instantiate(informasi7) as GameObject;
		}
		else if (rand == 8)
		{
			informasi = Instantiate(informasi8) as GameObject;
		}
		else if (rand == 9)
		{
			informasi = Instantiate(informasi9) as GameObject;
		}
		else
		{
			informasi = Instantiate(informasi10) as GameObject;
		}
		informasi.transform.SetParent (parentInformasi.gameObject.transform, false);
	}

	public bool IsShowing
	{
		get 
		{
			return myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("show");
		}
		
	}
}
