using UnityEngine;
using System.Collections;

public class ExitConfirmation : Singleton<ExitConfirmation> {

	public Animator ExitConfirmationAnim;
	 
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
		ExitConfirmationAnim.SetTrigger(ShowState);
	}

	public void Hide()
	{
		ExitConfirmationAnim.SetTrigger(HideState);
	}

	public bool IsShowing
	{
		get
		{
			return ExitConfirmationAnim.GetCurrentAnimatorStateInfo(0).IsName(ShowState);
		}
	}
}
