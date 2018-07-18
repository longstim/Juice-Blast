using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeBar : MonoBehaviour {

	public float timer = 30;
	public float currentTime = 0;
	public bool conditionGameOver = false;
	public Sprite barMerah;
	public GameObject bar;
	Image image;
	Sprite barPutih;
	void Start()
	{
		currentTime = timer;
		//image.GetComponent<Image>().sprite = barHijau;
	}
	
	void Update () {
		barPutih = bar.GetComponent<Image> ().sprite;
		image = GetComponent<Image>();
		
		if (Singleton<PlayManager>.Instance.StatusPowerUp != 1) 
		{
			currentTime = currentTime - Time.deltaTime;
		}
		
		image.fillAmount = currentTime / timer;
		
		if (image.fillAmount < 0.3) 
		{
			image.sprite = barPutih;
		}
		else
		{
			image.sprite = barPutih;
		}
		
		if (currentTime <= 0) //kondisi ketika waktu sudah habis
		{
			currentTime = 0;
			conditionGameOver = true;
		}
		
		if(currentTime >= timer) //kondisi untuk membuat maksimal waktu
		{
			currentTime = timer;
		}
	}
}
