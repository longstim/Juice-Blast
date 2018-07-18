using UnityEngine;
using System.Collections;

public class ContentLoader : MonoBehaviour {

    public delegate void Callback();

    AsyncOperation loadingProcess;

    /// <summary>
    /// Operasi asyncronous yang melakukan loading content
    /// </summary>
    public AsyncOperation LoadingProcess
    {
        get { return loadingProcess; }
    }

    /// <summary>
    /// Progress operasi asyncronous yang melakukan loading content
    /// </summary>
    public float Progress
    {
        get { return loadingProcess != null ? loadingProcess.progress : 0; }
    }

    /// <summary>
    /// Status apakah loading content telah selesai. Progress >= 0.9
    /// </summary>
    public bool IsFinished {
        get { return loadingProcess != null && loadingProcess.progress >= 0.9f; }
    }

    /// <summary>
    /// Status apakah loading content telah dimulai
    /// </summary>
    public bool IsStarted
    {
        get { return loadingProcess != null; }
    }

    Callback callback;

	// Update is called once per frame
	void Update () {
        if (IsStarted && IsFinished && callback != null)    // Finish : loading progress >= 0.9
        {
            if (loadingProcess.isDone)                      // Done : loading progress == 1 because of loadingProcess.allowSceneActivation had been true
            {
                Reset();
            }
            else if (callback != null){
                callback();
                callback=null;
            }
        }
	}

    /// <summary>
    /// Fungsi untuk me-load content dari scene tertentu
    /// </summary>
    /// <param name="sceneName">Nama scene</param>
    /// <param name="callback">Callback ketika loading berhasil</param>
    public void Load(SceneName sceneName, Callback callback)
    {
        StartCoroutine(LoadNow(sceneName.ToString()));
        this.callback = callback;
    }

    public void Load(string sceneName, Callback callback)
    {
        StartCoroutine(LoadNow(sceneName));
        this.callback = callback;
    }

    IEnumerator LoadNow(string sceneName)
    {
        loadingProcess = Application.LoadLevelAsync(sceneName);
        loadingProcess.allowSceneActivation = false;
        yield return loadingProcess;
    }

    public void Activate()
    {
        loadingProcess.allowSceneActivation = true;
    }

    void Reset()
    {
        loadingProcess = null;
        callback = null;
    }
}

