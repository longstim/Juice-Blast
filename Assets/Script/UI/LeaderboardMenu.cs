using UnityEngine;
using System.Collections;

public class LeaderboardMenu : Singleton<LeaderboardMenu> {

	public Animator LeaderboardMenuAnim;
	
	public string ShowState = "Show";
	public string HideState = "Hide";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Show()
	{
		LeaderboardMenuAnim.SetTrigger(ShowState);
	}
	
	public void Hide()
	{
		LeaderboardMenuAnim.SetTrigger(HideState);
	}
	
	public bool IsShowing
	{
		get 
		{
			return LeaderboardMenuAnim.GetCurrentAnimatorStateInfo (0).IsName (ShowState);
		}
		
	}
}
