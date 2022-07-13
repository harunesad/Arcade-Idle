using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStack : MonoBehaviour
{
    public static NewStack instance;

    public GameObject player;
    public GameObject stackPointBuild;
    public GameObject parent;
    public GameObject playerStack;

    float distanceToStack;
    float distanceToStackCollision;

    public float posZ;

    public bool isMove = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        posZ = 0;
    }
    void Update()
    {
        distanceToStack = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distanceToStack);
        if (distanceToStack < 2)
        {
            if (StackControl.instance.stackObjects.Count > 0)
            {
                Transform stack = StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform;
                stack.transform.parent = parent.transform;
                distanceToStackCollision = Vector3.Distance(stack.localPosition, stackPointBuild.transform.localPosition);
                stack.position = Vector3.Lerp(stack.position, stackPointBuild.transform.position, Time.deltaTime * 3);

                if (distanceToStackCollision < 0.2f)
                {
                    Transform endChild = parent.transform.GetChild(parent.transform.childCount - 1).transform;
                    Transform lastChild = parent.transform.GetChild(parent.transform.childCount - 1 - 1).transform;
                    endChild.position = new Vector3(stackPointBuild.transform.position.x, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z);
                }

                if (distanceToStackCollision < 0.001f)
                {
                    StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.rotation = Quaternion.Euler(0, 90, 0);
                    StackControl.instance.stackObjects.RemoveAt(StackControl.instance.stackObjects.Count - 1);
                    stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z + 0.41f);
                    playerStack.transform.position = new Vector3(playerStack.transform.position.x, playerStack.transform.position.y - 0.15f, playerStack.transform.position.z);
                }
            }
        }
        Debug.Log(distanceToStackCollision);
    }
}
