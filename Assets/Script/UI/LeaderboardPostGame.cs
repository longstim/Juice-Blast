using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardPostGame : MonoBehaviour 
{
	public GameObject LoginButton;
	public GameObject ShareButton;

	public Transform ParentItem;
	public GameObject itemLeaderboardScore;
	public GameObject itemLeaderboardMyScore;
	public int Limit = 50;
	// Use this for initialization
	void Start ()
	{	
		Singleton<FacebookAPIManager>.Instance.OnLeaderboardUpdate += RefreshLeaderboardCallback;
		Singleton<FacebookAPIManager>.Instance.OnPublishScore += PublishScoreCallback;
		Singleton<FacebookAPIManager>.Instance.OnLogin += OnLogin;
		LoginButton.SetActive(!FB.IsLoggedIn);	
		ShareButton.SetActive(FB.IsLoggedIn);	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void loginFB()
	{
		Singleton<FacebookAPIManager>.Instance.Login ();
	}

	void OnLogin(bool isLogin)
	{
		RefreshLeaderboard();
		Debug.Log("Status: " + isLogin.ToString());
		for (int i = 0; i < ParentItem.childCount; i++)
		{

			Destroy(ParentItem.GetChild(i).gameObject);
		}

		LoginButton.SetActive(!isLogin);
		ShareButton.SetActive(isLogin);	

		if (isLogin)
			Refresh();
	}

	public void Refresh()
	{ 
		Singleton<FacebookAPIManager>.Instance.PublishScore((int)PlayerPrefs.GetInt("score"));
		Debug.Log ("berhasil" + PlayerPrefs.GetInt("score"));
	}

	public void RefreshLeaderboard()
	{
		if (FB.IsLoggedIn)
		{
			Singleton<FacebookAPIManager>.Instance.GetLeaderboard();
		}
	}

	void PublishScoreCallback(bool status)
	{
		if (status)
			Singleton<FacebookAPIManager>.Instance.GetLeaderboard();
		else
			Debug.Log("Failed publish score!");
	}

	void RefreshLeaderboardCallback(bool status, List<Dictionary<string, string>> friends)
	{
		if (status)
		{
			for (int i = 0; i < ParentItem.childCount; i++)
			{
				Destroy(ParentItem.GetChild(i).gameObject);
			}
			
			int counter = 1;
			foreach (Dictionary<string, string> friend in friends)
			{
				GameObject itemLeaderboard;
				if (FB.UserId == friend["id"])
				{
					itemLeaderboard = (GameObject)Instantiate(itemLeaderboardMyScore);
					if (int.Parse(friend["score"]) >= PlayerPrefs.GetInt("score"))
					{
						PlayerPrefs.SetInt("score", int.Parse(friend["score"]));
						PlayerPrefs.Save();
					}
					else {
						Singleton<FacebookAPIManager>.Instance.PublishScore(PlayerPrefs.GetInt("score"));
					}
				}
				else
				{
					itemLeaderboard = (GameObject)Instantiate(itemLeaderboardScore);
				}
				
				itemLeaderboard.transform.SetParent(ParentItem);
				itemLeaderboard.transform.localScale = new Vector3(1, 1, 1);
				ItemLeaderboard itemController = itemLeaderboard.GetComponent<ItemLeaderboard>();
				itemController.Set(counter, friend["id"], friend["name"], int.Parse(friend["score"]));
				
				counter++;
				if (counter > Limit)
				{
					break;
				}
			}
		}
		else{
		}
	}
}
