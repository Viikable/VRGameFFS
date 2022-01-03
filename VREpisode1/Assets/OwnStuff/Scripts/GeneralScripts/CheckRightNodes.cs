using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
	
	void Update () {
        Node1CurrentObject = GameObject.Find("SnapDropZone").GetComponent<XRSocketInteractor>().firstInteractableSelected.transform.gameObject;
        Node2CurrentObject = GameObject.Find("SnapDropZone2").GetComponent<XRSocketInteractor>().firstInteractableSelected.transform.gameObject;
        Node3CurrentObject = GameObject.Find("SnapDropZone3").GetComponent<XRSocketInteractor>().firstInteractableSelected.transform.gameObject;

        if(firstNodeRightObject == Node1CurrentObject && secondNodeRightObject == Node2CurrentObject && thirdNodeRightObject == Node3CurrentObject) {
            Debug.Log("Right Order");
        }
	}
}
