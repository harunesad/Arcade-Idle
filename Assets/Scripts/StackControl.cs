using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackControl : MonoBehaviour
{
    public static StackControl instance;

    public List<GameObject> stackObjects;
    public GameObject stoneBuild;

    public Transform stackTransform;

    public bool isStack = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (stackObjects[stackObjects.Count - 1].transform.position != stoneBuild.transform.position && !isStack)
        {
            //stackTransform = stackObjects[stackObjects.Count - 1].transform;
            stackObjects[stackObjects.Count - 1].transform.position = Vector3.Lerp(stackObjects[stackObjects.Count - 1].transform.position, stackTransform.transform.position, Time.deltaTime * 1);
        }
        //gameObject.transform.rotation = Quaternion.identity;
    }
}
