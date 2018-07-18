using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FruitShadow : MonoBehaviour {

	public Image imageFruit;

	public Sprite image1;
	public Sprite image2;
	public Sprite image3;
	public Sprite image4;
	public Sprite image5;
	public Sprite image6;
	public Sprite image7;
	public Sprite image8;
	public Sprite image9;
	public Sprite image10;
	// Use this for initialization
	void Start () 
	{
		randomImage ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Destroy ();
	}

	void Destroy()
	{
		if(this.transform.localPosition.y < Singleton<FruitShadowController>.Instance.batasbawah.transform.localPosition.y)
		{
			Destroy (gameObject);
		}
	}	

	void randomImage()
	{
		int rand = Random.Range (1, 10);
		if (rand == 1) 
		{
			imageFruit.GetComponent<Image> ().sprite = image1;
		}
		else if (rand == 2) 
		{
			imageFruit.GetComponent<Image> ().sprite = image2;
		}
		else if(rand == 3)
		{
			imageFruit.GetComponent<Image>().sprite = image3;	
		}
		else if(rand == 4)
		{
			imageFruit.GetComponent<Image>().sprite = image4;
		}
		else if(rand == 5)
		{
			imageFruit.GetComponent<Image>().sprite = image5;
		}
		else if(rand == 6)
		{
			imageFruit.GetComponent<Image>().sprite = image6;
		}
		else if(rand == 7)
		{
			imageFruit.GetComponent<Image>().sprite = image7;
		}
		else if(rand == 8)
		{
			imageFruit.GetComponent<Image>().sprite = image8;
		}
		else if(rand == 9)
		{
			imageFruit.GetComponent<Image>().sprite = image9;
		}
		else if(rand == 10)
		{
			imageFruit.GetComponent<Image>().sprite = image10;
		}

		imageFruit.SetNativeSize ();
	}
}
