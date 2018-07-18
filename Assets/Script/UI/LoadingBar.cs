using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ContentLoaderAdditive))]
[RequireComponent(typeof(ContentLoader))]
public class LoadingBar : Singleton<LoadingBar> {

    public SceneName MainScene;
    public bool AutoStart = false;
    public bool AutoActivation = false;
    [Range(1, 10)] public float DelayStart = 1f;
    [Range(1, 10)] public float DelayActivate = 3f;
    public Image ProgressBar;

    float finishWidth;

    bool tryToActivate = false;

    RectTransform rectProgressBar;
    ContentLoader contentLoader;

	// Use this for initialization
	void Start () {
        rectProgressBar = ProgressBar.GetComponent<RectTransform>();
        contentLoader = GetComponent<ContentLoader>();

        finishWidth = rectProgressBar.rect.width;
        
        if (AutoStart)
        {
            Invoke("StartLoadMainScene", 2);
        }
	}
	
	// Update is called once per frame
	void Update () {
        rectProgressBar.sizeDelta = new Vector2(((contentLoader.Progress / 0.9f) * finishWidth), rectProgressBar.rect.height);
        if (tryToActivate)
        {
            StartActivate();
        }
	}

    public void StartLoadMainScene()
    {
        contentLoader.Load(MainScene, Activate);
    }

    void Activate()
    {
        Invoke("StartActivate", DelayActivate);
    }

    void StartActivate()
    {
        Debug.Log("Finish");
        tryToActivate = true;
      
       	contentLoader.Activate();
    }
}
