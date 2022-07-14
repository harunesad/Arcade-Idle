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

    float posZ;

    int stepOne = 10;
    int stepTwo = 15;
    int stepThree = 23;
    int stepFour = 28;

    public bool isCompleted = false;
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
        if (StackControl.instance.stackObjects.Count > 0 && !isCompleted)
        {
            Transform stack = StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform;
            if (distanceToStack < 1.5f)
            {
                stack.transform.parent = parent.transform;
                distanceToStackCollision = Vector3.Distance(stack.localPosition, stackPointBuild.transform.localPosition);
                stack.position = Vector3.Lerp(stack.position, stackPointBuild.transform.position, Time.deltaTime * 3);
                if (parent.transform.childCount < stepOne)
                {
                    StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                else if (parent.transform.childCount >= stepOne && parent.transform.childCount < stepTwo)
                {
                    StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                else if (parent.transform.childCount >= stepTwo && parent.transform.childCount < stepThree)
                {
                    StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                else if (parent.transform.childCount >= stepThree && parent.transform.childCount < stepFour)
                {
                    StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                if (distanceToStackCollision < 0.2f)
                {
                    Transform endChild = parent.transform.GetChild(parent.transform.childCount - 1).transform;
                    Transform lastChild = parent.transform.GetChild(parent.transform.childCount - 1 - 1).transform;
                    endChild.position = new Vector3(stackPointBuild.transform.position.x, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z);
                }

                if (distanceToStackCollision < 0.001f)
                {
                    StackControl.instance.stackObjects.RemoveAt(StackControl.instance.stackObjects.Count - 1);
                    if (parent.transform.childCount < stepOne)
                    {
                        if (parent.transform.childCount < stepOne - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z + 0.41f);
                        }
                        if (parent.transform.childCount == stepOne - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x + 0.15f, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z + 0.26f);
                        }
                    }
                    else if (parent.transform.childCount >= stepOne && parent.transform.childCount < stepTwo)
                    {
                        if (parent.transform.childCount < stepTwo - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x + 0.41f, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z);
                        }
                        else if (parent.transform.childCount == stepTwo - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x + 0.15f, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z - 0.26f);
                        }
                    }
                    else if (parent.transform.childCount >= stepTwo && parent.transform.childCount < stepThree)
                    {
                        if (parent.transform.childCount < stepThree - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z - 0.41f);
                        }
                        else if (parent.transform.childCount == stepThree - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x - 0.15f, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z - 0.26f);
                        }
                    }
                    else if (parent.transform.childCount >= stepThree && parent.transform.childCount < stepFour)
                    {
                        if (parent.transform.childCount < stepFour - 1)
                        {
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x - 0.41f, stackPointBuild.transform.position.y, stackPointBuild.transform.position.z);
                        }
                        else if (parent.transform.childCount == stepFour - 1)
                        {
                            stepOne += 26;
                            stepTwo += 26;
                            stepThree += 26;
                            stepFour += 26;
                            stackPointBuild.transform.position = new Vector3(stackPointBuild.transform.position.x - 0.15f, stackPointBuild.transform.position.y + 0.11f, stackPointBuild.transform.position.z + 0.26f);
                        }
                    }
                    playerStack.transform.position = new Vector3(playerStack.transform.position.x, playerStack.transform.position.y - 0.15f, playerStack.transform.position.z);
                    StoneChildCount.instance.StackFinish();
                }
            }
            if (stack.transform.parent == parent.transform)
            {
                stack.position = Vector3.Lerp(stack.position, stackPointBuild.transform.position, Time.deltaTime * 3);
            }
        }
        Debug.Log(distanceToStackCollision);
    }
}
