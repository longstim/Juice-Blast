using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SplashLogo : Singleton<SplashLogo>
{
	public delegate void Callback();
	public event Callback OnFinished;

	[Range(0,5)] public float delayTime=0;
	// Use this for initialization
	void Start () 
	{
		Callcallback ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Callcallback()
	{
		if(!IsInvoking("Finish"))
		{
			Invoke("Finish", delayTime);
		}
	}

	private void Finish()
	{
		if(OnFinished != null)
		{
			OnFinished();
		}
	}
}
