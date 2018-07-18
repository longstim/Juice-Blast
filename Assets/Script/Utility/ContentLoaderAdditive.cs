using UnityEngine;
using System.Collections;

public class ContentLoaderAdditive : MonoBehaviour {
   
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
        get { return loadingProcess != null ? loadingProcess.progress : 0 ; }
    }

    /// <summary>
    /// Status apakah loading content telah selesai
    /// </summary>
    public bool IsDone
    {
        get { return loadingProcess != null && loadingProcess.isDone; }
    }

    /// <summary>
    /// Status apakah loading content telah dimulai
    /// </summary>
    public bool IsStarted
    {
        get { return loadingProcess != null; }
    }

    Callback callback;
    bool hadCalledCallback;

    // Update is called once per frame
    void Update()
    {
        if (!hadCalledCallback && IsDone && callback != null)    // Finish : loading progress >= 0.9
        {
            this.callback();
            this.hadCalledCallback = true;
        }
    }

    /// <summary>
    /// Fungsi untuk me-load content dari scene tertentu
    /// </summary>
    /// <param name="sceneName">Nama scene</param>
    /// <param name="callback">Callback ketika loading berhasil</param>
    public void Load(SceneName sceneName, Callback callback)
    {
        StartCoroutine(LoadNow(sceneName));
        this.callback = callback;
        this.hadCalledCallback = false;
    }

    IEnumerator LoadNow(SceneName sceneName)
    {
        loadingProcess = Application.LoadLevelAdditiveAsync(sceneName.ToString());
        loadingProcess.allowSceneActivation = true;
        yield return loadingProcess;
    }
}
