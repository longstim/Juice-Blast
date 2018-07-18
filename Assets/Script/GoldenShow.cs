using UnityEngine;
using System.Collections;

public class GoldenShow : Singleton<GoldenShow>
{

    public Animator goldenAnim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        goldenAnim.SetTrigger("Show");
    }

    public void Hide()
    {
        goldenAnim.SetTrigger("Hide");
    }
}
