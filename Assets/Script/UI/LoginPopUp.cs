using UnityEngine;
using UnityEngine.UI;
using Facebook;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class LoginPopUp : MonoBehaviour {

	public Text Name;
	public RawImage Photo;
	public Animator loginPopUpAnim;

	// Use this for initialization
	void Start()
	{
		Singleton<FacebookAPIManager>.Instance.OnLogin += ShowNow;
		ShowNow(FB.IsLoggedIn);
	}
	
	public void ShowNow(bool isLogin)
	{

		if (isLogin && PlayerPrefs.GetInt ("flagLogin") == 1)
		{
			PlayerPrefs.SetInt("flagLogin",0);
			StartCoroutine (UserImage (FB.UserId));
			Debug.Log (FB.UserId);
			FB.API ("me?fields=id,name", HttpMethod.GET, Callback);
		} else {
		
		}
	}

	void Callback(FBResult result)
	{
		if (result.Error == null)
		{
			var dict = Json.Deserialize(result.Text) as Dictionary<string, object>;
			Name.text = dict["name"] as string;
			Show ();
		}
	}

	IEnumerator UserImage(string UserId)
	{
		WWW url = new WWW("https" + "://graph.facebook.com/" + UserId + "/picture?type=large");
		Texture2D textFb2 = new Texture2D(100, 100, TextureFormat.DXT1, false); //TextureFormat must be DXT5
		yield return url;
		url.LoadImageIntoTexture(textFb2);
		Photo.texture = textFb2;
	}

	void Show()
	{
		loginPopUpAnim.SetTrigger("Show");
	}

	void Hide()
	{
		loginPopUpAnim.SetTrigger("Hide");
	}

}
