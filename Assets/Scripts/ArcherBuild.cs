using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherBuild : MonoBehaviour
{
    public GameObject player;

    public Text archerStoneCountText;
    public Text archerCountText;
    public Image archerImage;   

    int archerStoneCount;
    int archerStoneNeedCount = 5;
    int archerCount = 0;

    float playerToArcherBuild;

    bool archerCompleted = false;
    private void Start()
    {
        archerStoneCountText.text = archerStoneCount + "" + " / " + archerStoneNeedCount;
    }
    private void Update()
    {
        playerToArcherBuild = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(playerToArcherBuild);
        if (archerStoneCount == archerStoneNeedCount)
        {
            archerCount++;
            archerCountText.text = "" + archerCount;
            archerStoneCount = 0;
            if (archerImage.fillAmount == 0)
            {
                archerImage.fillAmount = 1;
            }
        }
        if (archerCount > 0)
        {
            if (archerImage.fillAmount > 0f)
            {
                archerImage.fillAmount -= Time.deltaTime / 8f;
            }
            else
            {
                archerCount--;
                archerCountText.text = "" + archerCount;
                archerImage.fillAmount = 1;
            }
        }
        else
        {
            archerImage.fillAmount = 0;
        }
        StartCoroutine(Lerp());
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
    IEnumerator Lerp()
    {
        yield return new WaitForSeconds(1);
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
}
