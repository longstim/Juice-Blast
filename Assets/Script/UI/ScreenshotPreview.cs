using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenshotPreview : Singleton<ScreenshotPreview> {

    public Image border;
    public RawImage image;

	//Use this for initialization
	void Start () {

        Hide();
	}

    public void Show(Texture2D texture, float time)
    {
        image.texture = texture;
        image.enabled = true;
        border.enabled = true;
        Invoke("Hide", time);
    }

    void Hide()
    {
        image.enabled = false;
        border.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
