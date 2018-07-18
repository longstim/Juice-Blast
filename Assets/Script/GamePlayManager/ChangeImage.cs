using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeImage : MonoBehaviour {

	public Sprite imgNormal;
	public Sprite imgFreeze;
	public Sprite imgGolden;

	public Image imgBuah;

	void Start () {
		if (Singleton<PlayManager>.Instance.StatusPowerUp == 0) 
		{
			imgBuah.GetComponent<Image>().sprite = imgNormal;
		}
		else if (Singleton<PlayManager>.Instance.StatusPowerUp == 1) 
		{
			imgBuah.GetComponent<Image>().sprite = imgFreeze;
		}
		else if (Singleton<PlayManager>.Instance.StatusPowerUp == 2) 
		{
			imgBuah.GetComponent<Image>().sprite = imgGolden;
		}
		imgBuah.SetNativeSize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Singleton<PlayManager>.Instance.StatusPowerUp == 0) 
		{
			imgBuah.GetComponent<Image>().sprite = imgNormal;
		}
		else if (Singleton<PlayManager>.Instance.StatusPowerUp == 1) 
		{
			imgBuah.GetComponent<Image>().sprite = imgFreeze;
		}
		else if (Singleton<PlayManager>.Instance.StatusPowerUp == 2) 
		{
			imgBuah.GetComponent<Image>().sprite = imgGolden;
		}
		imgBuah.SetNativeSize ();
	}
}
