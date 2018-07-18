using UnityEngine;
using System.Collections;

public class LeaderboardPopup : Singleton<LeaderboardPopup> {

	public Animator LeaderboardAnim;

	public string ShowState = "show";
	public string HideState = "hide";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		LeaderboardAnim.SetTrigger(ShowState);
	}

	public void Hide()
	{
		LeaderboardAnim.SetTrigger(HideState);
	}

	public bool IsShowing
	{
		get 
		{
			return LeaderboardAnim.GetCurrentAnimatorStateInfo (0).IsName (ShowState);
		}

	}
}
