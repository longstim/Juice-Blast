using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {

	public SceneName myScene;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("flagLogin", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable()
	{
		Singleton<SplashLogo>.Instance.OnFinished += OnSplashFinished;
	}

	void OnSplashFinished()
	{
		Application.LoadLevel (myScene.ToString ());
	}
}
