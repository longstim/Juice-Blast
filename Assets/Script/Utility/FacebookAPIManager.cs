using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook;
using Facebook.MiniJSON;

public class FacebookAPIManager : Singleton<FacebookAPIManager> {
	
	public string Permission = "email,user_friends,public_profile";
	public delegate void LoginCallback(bool status);
	public delegate void PublishScoreCallback(bool status);
	public delegate void LeaderboardCallback(bool status,List<Dictionary<string, string>> friends);
	
	public LoginCallback OnLogin;
	public PublishScoreCallback OnPublishScore;
	public LeaderboardCallback OnLeaderboardUpdate;
	
	void Awake()
	{
		if (FindObjectsOfType<FacebookAPIManager>().Length > 2)
			Destroy(gameObject);
	}
	
	// Use this for initialization
	void Start () 
	{
		if(!FB.IsInitialized)
			FB.Init(SetInit, OnHideUnity);
	}
	
	private void SetInit()
	{
		enabled = true;
		
		if (FB.IsLoggedIn)
		{
			LoginSuccess();
		}
		else {
			
		}
		
		// "enabled" is a magic global; this lets us wait for FB before we start rendering
	}
	
	
	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			// pause the game - we will need to hide
			Time.timeScale = 0;
		}
		else
		{
			// start the game back up - we're getting focus again
			Time.timeScale = 1;
		}
	}
	
	public void Login()
	{
		FB.Login(Permission, AuthCallback);
	}
	
	void AuthCallback(FBResult result)
	{
		if (FB.IsLoggedIn)
		{
			LoginSuccess();
		}
		else
		{
			LoginFailed();
		}            
	}
	
	void LoginSuccess()
	{
		Debug.Log ("Login success! User Id :" + FB.UserId);
		if (OnLogin != null)
			OnLogin(true);
		
		#if UNITY_ANDROID || UNITY_IOS
		FB.ActivateApp();
		#endif
	}
	
	void LoginFailed()
	{
		if (OnLogin != null)
			OnLogin(false);
	}
	
	public void PublishScore(int score)
	{ 
		if(PlayerPrefs.HasKey("score"))
		{
			if(score > PlayerPrefs.GetInt("score"))
			{
				Debug.Log("Score Timpa");
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.Save();
			}
		}
		else{
			Debug.Log("Score Baru");
			PlayerPrefs.SetInt("score",score);
			PlayerPrefs.Save();
		}
		
		if (FB.IsLoggedIn)
		{
			Singleton<App42APIManager>.Instance.PublishScore(PlayerPrefs.GetInt("score"),OnPublishScore);
		}
	}
	
	public void GetLeaderboard()
	{
		if (FB.IsLoggedIn)
		{
			Singleton<App42APIManager>.Instance.GetLeaderboard(50, OnLeaderboardUpdate);
			//FB.API(FB.AppId + "/scores?fields=score", HttpMethod.GET, LeaderbackCallback);
		}
	}
	
	void LeaderbackCallback(FBResult result)
	{
		List<Dictionary<string, string>> friends = new List<Dictionary<string,string>>();
		if (result.Error == null)
		{
			Debug.Log("Publish score true!");
			Debug.Log(result.Text);
			var dict = Json.Deserialize(result.Text) as Dictionary<string, object>;
			List<object> data = dict["data"] as List<object>;
			
			foreach (object obj in data)
			{
				Dictionary<string, string> friend = new Dictionary<string, string>();
				Dictionary<string, object> DataUser = obj as Dictionary<string, object>;
				Dictionary<string, object> user = DataUser["user"] as Dictionary<string, object>;
				friend.Add("id", user["id"].ToString());
				friend.Add("name", user["name"].ToString());
				friend.Add("score", DataUser["score"].ToString());
				
				friends.Add(friend);
			}			
		}
		else 
		{
			Debug.Log("Publish score false!");
		}
		
		if (OnLeaderboardUpdate != null)
		{
			OnLeaderboardUpdate(result.Error == null, friends);
		}
	}
}
