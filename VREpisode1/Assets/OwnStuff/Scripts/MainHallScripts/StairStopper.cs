using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StairStopper : MonoBehaviour {

    GameObject PlayArea;

    private void Awake()
    {
        PlayArea = GameObject.Find("PlayArea");
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<VRTK_PlayerObject>() != null)
        //{
        //    PlayArea.GetComponent<VRTK_BodyPhysics>().stepUpYOffset = 0.28f;
        //    Debug.Log("exitedStairs");
        //}
    }
}
