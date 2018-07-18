using UnityEngine;
using System.Collections;

public class BuahGolden : MonoBehaviour {

	public GameObject PrefSplash;
	private GameObject Splash;
	bool statusTekan = false;

	/// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cekStatus ();
	}
	
	void cekStatus() //mengurang waktu dan mendestroy object jika kejahatan melewati batas bawah
	{
		if (this.transform.localPosition.y < Singleton<PlayManager>.Instance.batasBawah.transform.localPosition.y) 
		{
			destroy();
		}
		if (Singleton<timeBar>.Instance.currentTime == 0) 
		{
			destroy();
		}
	}
	
	public void destroy()
	{
		Destroy (this.gameObject);
	}
	
	public void BuahGoldenDiClick()
	{
		if (statusTekan == false) 
		{
			statusTekan = true;
			Singleton<PlayManager>.Instance.SetGolden ();
			Singleton<PlayManager>.Instance.showGoldenCover();
            Singleton<GoldenShow>.Instance.Show();
			Splash = Instantiate (PrefSplash, new Vector2 (this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Quaternion.identity) as GameObject;
			Splash.transform.SetParent (Singleton<PlayManager>.Instance.KKParent.gameObject.transform, false);
			destroy ();
		}
	}
}
