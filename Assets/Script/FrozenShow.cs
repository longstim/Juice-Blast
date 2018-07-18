using UnityEngine;
using System.Collections;

public class FrozenShow : Singleton<FrozenShow> {

	public Animator frozenAnim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		frozenAnim.SetTrigger ("Show");
	}

	public void Hide()
	{
		frozenAnim.SetTrigger ("Hide");
	}
}
