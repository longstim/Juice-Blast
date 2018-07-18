using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemLeaderboard : MonoBehaviour {

	public Text Number;
	public RawImage Photo;
	public Text Name;
	public Text Score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Set(int number, string UserId, string UserName, int score)
	{
		Number.text = number.ToString();
		StartCoroutine(UserImage(UserId));
		Name.text = UserName;
		Score.text = score.ToString();
	}

	IEnumerator UserImage(string UserId)
	{
		WWW url = new WWW("https" + "://graph.facebook.com/" + UserId + "/picture?type=large");
		Texture2D textFb2 = new Texture2D(130, 130, TextureFormat.DXT1, false); //TextureFormat must be DXT5
		yield return url;
		url.LoadImageIntoTexture(textFb2);
		Photo.texture = textFb2;
	}
}
