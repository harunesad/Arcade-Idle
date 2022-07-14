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

    int childCount;
    int needCount = 60;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //count.text = childCount + "" + " / " + needCount;
    }
    void Update()
    {
        childCount = stack.transform.childCount - 1;
        count.text = childCount + "" + " / " + needCount;

    }
    public void StackFinish()
    {
        if (childCount == needCount)
        {
            Instantiate(archerBuild, archerBuild.transform.position + new Vector3(0, 4, 0), Quaternion.identity);
            stack.transform.DetachChildren();
            NewStack.instance.isCompleted = true;
        }
    }
}
