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

    int childCount;
    int needCount = 5;

    Renderer rnd;
    private void Awake()
    {
        instance = this;
        rnd = archerBuild.GetComponent<Renderer>();
        destroyObject = GameObject.Find("Plane");
    }
    void Start()
    {
        //count.text = childCount + "" + " / " + needCount;
    }
    void Update()
    {
        if (stack != null)
        {
            childCount = stack.transform.childCount - 1;
        }
        count.text = childCount + "" + " / " + needCount;

    }
    public void StackFinish()
    {
        if (childCount == needCount)
        {
            //Instantiate(archerBuild, archerBuild.transform.position + new Vector3(0, 4, 0), Quaternion.identity);
            //stack.transform.DetachChildren();
            rnd.enabled = true;
            //NewStack.instance.isCompleted = true;
            Destroy(destroyObject);
        }
    }
}
