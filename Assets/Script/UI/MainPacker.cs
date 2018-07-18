using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainPacker : Singleton<MainPacker> 
{
	public Animator mainAnim;
	public SceneName nextscene;
	public GameObject Tutorial;

	public void goToNextscene()
	{
		Application.LoadLevel (nextscene.ToString ());
	}

	public void Show()
	{
		mainAnim.SetTrigger ("Show");
	}

	public void Hide()
	{
		mainAnim.SetTrigger ("Hide");
	}

	public void showTutorial()
	{
		if (PlayerPrefs.GetInt ("flagAnim") == 0)
		{
			Tutorial.SetActive (true);
		} 
		else
		{
			goToNextscene ();
		}
	}
}
