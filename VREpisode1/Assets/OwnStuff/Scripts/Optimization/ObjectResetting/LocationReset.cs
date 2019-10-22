using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour {
    Transform original;
    Vector3 positionToBeResetTo;
    Quaternion rotationToBeResetTo;

    // Use this for initialization
    void Start () {
        original = transform;
        positionToBeResetTo = original.position;
        rotationToBeResetTo = original.rotation;
    }
	
	public void ResetLocation()
    {
        transform.position = positionToBeResetTo;
        transform.rotation = rotationToBeResetTo;
        Debug.Log("Lcoationreste");
    }
}
