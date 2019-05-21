using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRightNodes : MonoBehaviour {

    [SerializeField]
    private GameObject firstNodeRightObject;
    [SerializeField]
    private GameObject secondNodeRightObject;
    [SerializeField]
    private GameObject thirdNodeRightObject;

    [SerializeField]
    private GameObject Node1CurrentObject;
    [SerializeField]
    private GameObject Node2CurrentObject;
    [SerializeField]
    private GameObject Node3CurrentObject;
	
	// Update is called once per frame
	void Update () {
        Node1CurrentObject = GameObject.Find("SnapDropZone").GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
        Node2CurrentObject = GameObject.Find("SnapDropZone2").GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
        Node3CurrentObject = GameObject.Find("SnapDropZone3").GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();

        if(firstNodeRightObject == Node1CurrentObject && secondNodeRightObject == Node2CurrentObject && thirdNodeRightObject == Node3CurrentObject) {
            Debug.Log("Right Order");
        }
	}
}
