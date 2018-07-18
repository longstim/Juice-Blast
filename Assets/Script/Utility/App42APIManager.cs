using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using System;
using System.Collections.Generic;

public class App42APIManager : Singleton <App42APIManager> {

	public string gameName = "JuiceBlast";

	ServiceAPI serviceAPI;
	ScoreBoardService scoreBoardService;

	// Use this for initialization
	void Start () 
	{
		serviceAPI = new ServiceAPI("fe6cc83f6e00dd566a8244a8fbf88e90e63fd57095c22202f0acbee30f3c8cdc", "c093765482582b568d052b3be7abfa515326dfe371654fd7f9a6693d94565478");
		scoreBoardService = serviceAPI.BuildScoreBoardService();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void PublishScore(int score, FacebookAPIManager.PublishScoreCallback OnPublishScore)
	{
		if (PlayerPrefs.HasKey("score"))
		{
			if (score > PlayerPrefs.GetInt("score"))
			{
				PlayerPrefs.SetInt("score", score);
				PlayerPrefs.Save();
			}
		}
		else
		{
			PlayerPrefs.SetInt("score", score);
			PlayerPrefs.Save();
		}
		
		if (FB.IsLoggedIn)
		{
			scoreBoardService.SaveUserScore(gameName, FB.UserId, PlayerPrefs.GetInt("score"), new Publish42Callback(OnPublishScore));  
			Debug.Log ("berhasil save score");
		}
	}

	public class Publish42Callback : App42CallBack
	{
		FacebookAPIManager.PublishScoreCallback callback;
		
		public Publish42Callback(FacebookAPIManager.PublishScoreCallback callback)
		{
			this.callback = callback;
		}
		
		public void OnSuccess(object response)
		{
			Game game = (Game)response;
			App42Log.Console("gameName is " + game.GetName());
			for (int i = 0; i < game.GetScoreList().Count; i++)
			{
				App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
				App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());
				App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());
			}
			callback(true);
		}
		public void OnException(Exception e)
		{
			App42Log.Console("Exception : " + e);
			if(callback != null)
				callback(false);
		}
	} 

	public void GetLeaderboard(int max, FacebookAPIManager.LeaderboardCallback OnLeaderboardUpdate)
	{
		if (FB.IsLoggedIn)
		{
			scoreBoardService.GetTopNRankersFromFacebook(gameName, FB.AccessToken,max, new Leaderboard42Callback(OnLeaderboardUpdate));  
		}
	}

	public class Leaderboard42Callback : App42CallBack  
	{
		FacebookAPIManager.LeaderboardCallback callback;
		
		public Leaderboard42Callback(FacebookAPIManager.LeaderboardCallback callback)
		{ 
			this.callback = callback;
		}
		
		public void OnSuccess(object response)  
		{
			List<Dictionary<string, string>> friends = new List<Dictionary<string, string>>();
			Game game = (Game) response;       
			App42Log.Console("gameName is " + game.GetName());   
			for(int i = 0;i < game.GetScoreList().Count; i++)  
			{
				Dictionary<string, string> friend = new Dictionary<string, string>();
				friend.Add("id", game.GetScoreList()[i].GetFacebookProfile().GetId());
				friend.Add("name", game.GetScoreList()[i].GetFacebookProfile().GetName());
				friend.Add("score", game.GetScoreList()[i].GetValue().ToString());
				friends.Add(friend);
			}
			if(callback != null)
				callback(true,friends);
		}  
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);
			if(callback != null)
				callback(false, new List<Dictionary<string, string>>());
		}  
	}  
}
