using UnityEngine;
using System.Collections;

public class MenuPlay : MonoBehaviour {

	public SceneName backscene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backtoMain()
	{
		Application.LoadLevel (backscene.ToString ());
	}
}
