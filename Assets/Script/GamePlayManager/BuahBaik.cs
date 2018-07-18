using UnityEngine;
using System.Collections;

public class BuahBaik : MonoBehaviour {

	float myGravity = 0;
	bool changeGravity = false;
	bool statusTekan = false;
	public Animator buahBaikAnim;
	public GameObject PrefSplash;
	public GameObject PrefSplashFrozen;
	public GameObject PrefSplashGolden;
	private GameObject Splash;

	void Start () {
		myGravity = this.gameObject.rigidbody2D.gravityScale;		
	}
	
	// Update is called once per frame
	void Update () {
		cekStatus ();
	}
	
	void cekStatus()
	{
		if (this.transform.localPosition.y < Singleton<PlayManager>.Instance.batasBawah.transform.localPosition.y && statusTekan == false) 
		{
			//coinAudio.Play ();
			Singleton<PlayManager>.Instance.kurangWaktu();
			destroy();
		}
		if (Singleton<timeBar>.Instance.currentTime == 0) 
		{
			destroy();
		}
		if (Singleton<PlayManager>.Instance.StatusPowerUp != 1 && changeGravity == true) 
		{
			this.gameObject.rigidbody2D.gravityScale = Singleton<PlayManager>.Instance.gravity;
			changeGravity = false;
		}
		else if (Singleton<PlayManager>.Instance.StatusPowerUp == 1 && changeGravity == false) 
		{
			this.gameObject.rigidbody2D.gravityScale = (Singleton<PlayManager>.Instance.gravity/2);
			changeGravity = true;
		}
	}
	
	public void destroy()
	{
		Destroy (this.gameObject);
	}

	public void BuahBaikDiClick()
	{
		if (statusTekan == false) 
		{
			statusTekan = true;
			Singleton<PlayManager>.Instance.tambahWaktu ();
			Splash = Instantiate (PrefSplash, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
			Splash.transform.SetParent (Singleton<PlayManager>.Instance.SplashParent.gameObject.transform, false);
			buahBaikAnim.SetTrigger ("Pecah");

			/*if (Singleton<PlayManager>.Instance.StatusPowerUp == 0) 
			{
				Splash = Instantiate (PrefSplash, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
				Splash.transform.SetParent (Singleton<PlayManager>.Instance.SplashParent.gameObject.transform, false);
			}
			else if (Singleton<PlayManager>.Instance.StatusPowerUp == 1) 
			{
				Splash = Instantiate (PrefSplashFrozen, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
				Splash.transform.SetParent (Singleton<PlayManager>.Instance.SplashParent.gameObject.transform, false);
			}
			else if (Singleton<PlayManager>.Instance.StatusPowerUp == 2) 
			{
				Splash = Instantiate (PrefSplashGolden, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
				Splash.transform.SetParent (Singleton<PlayManager>.Instance.SplashParent.gameObject.transform, false);
			}*/
		}
	}

}
