using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneChildCount : MonoBehaviour
{
    public static StoneChildCount instance;

    public Text count;

    public GameObject stack;
    public GameObject archerBuild;

    GameObject destroyObject;
    public GameObject archerBuildCount;

    int childCount;
    int needCount = 2;

    Renderer rnd;
    private void Awake()
    {
        instance = this;
        rnd = archerBuild.GetComponent<Renderer>();
        destroyObject = GameObject.Find("Plane");
    }
    void Update()
    {
        if (stack != null)
        {
            childCount = stack.transform.childCount - 1;
        }
        count.text = childCount + "" + " / " + needCount;
        //print(archerBuildCount.name);
    }
    public void StackFinish()
    {
        if (childCount == needCount)
        {
            archerBuild.SetActive(true);
            rnd.enabled = true;
            Destroy(destroyObject);
            archerBuildCount.SetActive(true);
        }
    }
}
