using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {
	
	bool allowBack = true;
	bool leaderboardshow = false;
	bool aboutshow = false;
	bool exitshow = false;
	public AudioSource soundMenu;
	public GameObject SoundOnObj;
	public GameObject SoundOffObj;

	public Animator LoginButton;
	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("PlaySound") == 0) {
			SoundOnObj.SetActive(true);
			SoundOffObj.SetActive(false);
			soundMenu.Play ();
		} else {
			SoundOnObj.SetActive(false);
			SoundOffObj.SetActive(true);
			soundMenu.Stop ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		leaderboardshow = Singleton<LeaderboardPopup>.Instance.IsShowing;
		aboutshow = Singleton<AboutPopup>.Instance.IsShowing;
		exitshow = Singleton<ExitConfirmation>.Instance.IsShowing;
		checkOnPopup ();

		if (allowBack && Input.GetKey (KeyCode.Escape) && leaderboardshow) {
			Singleton<LeaderboardPopup>.Instance.Hide ();
			Singleton<LeaderboardMenu>.Instance.Hide ();
			LoginButton.SetTrigger("Hide");
			DisallowBackPopUp ();
		} else if (allowBack && Input.GetKey (KeyCode.Escape) && aboutshow) {
			Singleton<AboutPopup>.Instance.Hide ();
			DisallowBackPopUp ();
		} else if (allowBack && Input.GetKey (KeyCode.Escape) && exitshow) {
			Singleton<ExitConfirmation>.Instance.Hide ();
			DisallowBackPopUp ();
		} else if (!allowBack && Input.GetKey (KeyCode.Escape)) {
			Singleton<ExitConfirmation>.Instance.Show();
		}
	}

	public void checkOnPopup()
	{
		if(leaderboardshow || aboutshow || exitshow)
		{
			AllowBackPopUp();
		}
		else
		{
			DisallowBackPopUp();
		}
	}

	public void AllowBackPopUp()
	{
		allowBack = true;
	}
	
	public void DisallowBackPopUp()
	{
		allowBack = false;
	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void SoundOn()
	{
		PlayerPrefs.SetInt ("PlaySound", 1);
		soundMenu.Stop();
		
	}
	
	public void SoundOff()
	{
		PlayerPrefs.SetInt ("PlaySound", 0);
		soundMenu.Play();
	}
}
