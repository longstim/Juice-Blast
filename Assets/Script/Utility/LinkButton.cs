using UnityEngine;
using System.Collections;

public class LinkButton : MonoBehaviour {

    public string url;

    public void OnClick() {
        Application.OpenURL(url);
    }
}
