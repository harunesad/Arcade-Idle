using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherBuild : MonoBehaviour
{
    public GameObject player;

    public Text archerStoneCountText;

    int archerStoneCount;
    int archerStoneNeedCount = 5;

    float playerToArcherBuild;

    bool archerCompleted = false;
    private void Start()
    {
        archerStoneCountText.text = archerStoneCount + "" + " / " + archerStoneNeedCount;
    }
    private void Update()
    {
        playerToArcherBuild = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(playerToArcherBuild);
        if (archerStoneCount == archerStoneNeedCount)
        {
            archerStoneCount = 0;
        }
        if (StackControl.instance.stackObjects.Count > 0 && !archerCompleted)
        {
            Transform stackTransform = StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform;
            if (playerToArcherBuild < 2.5f)
            {
                stackTransform.transform.parent = null;
                stackTransform.position = Vector3.Lerp(stackTransform.transform.position, transform.position, Time.deltaTime * 5);
            }
            if (stackTransform.transform.parent == null)
            {
                stackTransform.position = Vector3.Lerp(stackTransform.transform.position, transform.position, Time.deltaTime * 5);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!archerCompleted)
        {
            archerStoneCount++;
            archerStoneCountText.text = archerStoneCount + "" + " / " + archerStoneNeedCount;
            StackControl.instance.stackObjects.Remove(other.gameObject);
            Destroy(other.gameObject, 1);
            Transform playerStackClone = NewStack.instance.playerStack.transform;
            playerStackClone.position = new Vector3(playerStackClone.position.x, playerStackClone.position.y - 0.15f, playerStackClone.position.z);
        }
    }
}
