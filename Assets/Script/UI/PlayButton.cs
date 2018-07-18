using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public SceneName nextscene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void gotoNextScene()
	{
		Singleton<MainPacker>.Instance.Hide ();
	}

	public void continuetoNextScene()
	{
		PlayerPrefs.SetInt("flagAnim",1);
		Application.LoadLevel (nextscene.ToString ());
	}
}
