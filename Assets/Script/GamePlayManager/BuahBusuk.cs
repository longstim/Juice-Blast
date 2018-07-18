using UnityEngine;
using System.Collections;

public class BuahBusuk : MonoBehaviour {
	public Animator anim;
	bool changeGravity = false;
	bool statusTekan = false;
	public GameObject PrefSplash;
	private GameObject Splash;

	float myGravity = 0;
	
	void Start () {
		myGravity = this.gameObject.rigidbody2D.gravityScale;		
	}
	
	// Update is called once per frame
	void Update () {
		cekStatus ();
		if (Singleton<PlayManager>.Instance.StatusPowerUp != 0) {
			destroy();
		}
	}
	
	void cekStatus() //mengurang waktu dan mendestroy object jika kejahatan melewati batas bawah
	{
		if (this.transform.localPosition.y < Singleton<PlayManager>.Instance.batasBawah.transform.localPosition.y && statusTekan == false) 
		{
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
	
	public void BuahBusukDiClick()
	{
		if (statusTekan == false) 
		{
			statusTekan = true;
			Handheld.Vibrate ();
			Singleton<PlayManager>.Instance.kurangWaktu ();
			Splash = Instantiate (PrefSplash, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
			Splash.transform.SetParent (Singleton<PlayManager>.Instance.SplashParent.gameObject.transform, false);
			anim.SetTrigger ("Pecah");
			Handheld.Vibrate ();
		}

	}
}
