using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.IO;
public class  ShareScreenshotButton : MonoBehaviour,IPointerClickHandler {
    
    private bool isProcessing = false;
	public GameObject BackImage;
	//private string shareText  = "Hi! Ayo mainkan game Harmony Box dan mari jaga kerukunan antar umat beragama!";
    // Use this for initialization
    void Start () {
#if !UNITY_ANDROID
        gameObject.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update () {
        if (isProcessing)
        {
			BackImage.transform.localScale = Vector3.zero;
            transform.localScale = Vector3.zero;
        }
        else {
            transform.localScale = new Vector3(1, 1, 1);
			BackImage.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator ShareScreenshot()
    {

        yield return new WaitForEndOfFrame();

#if UNITY_ANDROID
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);

        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);

        screenTexture.Apply();

        byte[] dataToSave = screenTexture.EncodeToPNG();

        string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");

        File.WriteAllBytes(destination, dataToSave);

        Singleton<ScreenshotPreview>.Instance.Show(screenTexture, 1f);

        yield return new WaitForSeconds(1);

        if(!Application.isEditor)
        {
        //block to open the file and share it ————START
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareText);
		//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");
        intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "testo");
        //intentObject.Call<AndroidJavaObject>("setType", "text/html");

        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

        // option one:
        //currentActivity.Call("startActivity", intentObject);

        // option two:
        AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Let people to know by :");
        currentActivity.Call("startActivity", jChooser);

        // block to open the file and share it ————END
        }
#endif
        isProcessing = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            StartCoroutine(ShareScreenshot());
        }
    }

}