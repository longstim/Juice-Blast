using UnityEngine;
using System.Collections;

public class AboutPopup : Singleton<AboutPopup> {

	public Animator AboutPopupAnim;
	
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
		AboutPopupAnim.SetTrigger(ShowState);
	}
	
	public void Hide()
	{
		AboutPopupAnim.SetTrigger(HideState);
	}

	public bool IsShowing
	{
		get
		{
			return AboutPopupAnim.GetCurrentAnimatorStateInfo(0).IsName(ShowState);
		}
	}
}
