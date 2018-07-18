using UnityEngine;
using System.Collections;

public class FruitShadowController : Singleton<FruitShadowController> {

	public Transform batasbawah;
	public Transform bataskiri;
	public Transform bataskanan;
	public GameObject fruitshadow;

	void Start () 
	{
		BuahInvoke ();
	}

	void buah()
	{
		float rangePosition = Random.Range (bataskiri.localPosition.x, bataskanan.localPosition.x);
		GameObject fruitObj = GameObject.Instantiate (fruitshadow, new Vector2 (rangePosition, fruitshadow.transform.localPosition.y), Quaternion.identity) as GameObject;
		fruitObj.transform.SetParent (transform, false);
		BuahInvoke ();
	}

	void BuahInvoke()
	{
		if(!IsInvoking("buah"))
		{
			Invoke ("buah",Random.Range(0.5f, 2f));
		}
	}
}
