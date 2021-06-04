using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class ArrowCreatController : MonoBehaviour
{
    [EventID]
    public string eventID;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public static int totalArrow;

    void Start()
    {
        totalArrow = 0;
        Koreographer.Instance.RegisterForEvents(eventID, CreatArrow);
    }

    private void CreatArrow(KoreographyEvent evt)
    {
        GameObject TopCreatPoint = GameObject.Find("Top");
        GameObject nextArrow;
        int arrowDir = Random.Range(1, 5);
        switch (arrowDir)
        {
            case 1:
                nextArrow = Instantiate(upArrow, new Vector3(upArrow.transform.position.x, TopCreatPoint.transform.position.y, 0), upArrow.transform.rotation);
                nextArrow.transform.parent = upArrow.transform.parent;
                nextArrow.tag = "CloneArrow";
                //print("Up");
                //print(GetComponents<NoteObject>().Length);
                break;
            case 2:
                nextArrow = Instantiate(downArrow, new Vector3(downArrow.transform.position.x, TopCreatPoint.transform.position.y, 0), downArrow.transform.rotation);
                nextArrow.transform.parent = downArrow.transform.parent;
                nextArrow.tag = "CloneArrow";
                //print("Down");
                //print(GetComponents<NoteObject>().Length);
                break;
            case 3:
                nextArrow = Instantiate(leftArrow, new Vector3(leftArrow.transform.position.x, TopCreatPoint.transform.position.y, 0), leftArrow.transform.rotation);
                nextArrow.transform.parent = leftArrow.transform.parent;
                nextArrow.tag = "CloneArrow";
                //print("Left");
                //print(GetComponents<NoteObject>().Length);
                break;
            case 4:
                nextArrow = Instantiate(rightArrow, new Vector3(rightArrow.transform.position.x, TopCreatPoint.transform.position.y, 0), rightArrow.transform.rotation);
                nextArrow.transform.parent = rightArrow.transform.parent;
                nextArrow.tag = "CloneArrow";
                //print("Right");
                //print(GetComponents<NoteObject>().Length);
                break;
            default:
                break;
        }
        totalArrow++;
    }
    private void OnDestroy()
    {
        // Sometimes the Koreographer Instance gets cleaned up before hand.
        //  No need to worry in that case.
        if (Koreographer.Instance != null)
        {
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }
}
