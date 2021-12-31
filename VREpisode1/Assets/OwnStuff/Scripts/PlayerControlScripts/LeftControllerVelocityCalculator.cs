using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class LeftControllerVelocityCalculator : MonoBehaviour
{
    private Transform leftHandRig;   
    Transform leftHand;
   
    Vector3 previousPosition;

    Quaternion previousRotation;
    public Vector3 linearVelocity { get; private set; }
    public Vector3 angularVelocity { get; private set; }
    
    Vector3 axis;

    float angle;
    // Start is called before the first frame update
    private void OnEnable()
    {
        leftHand = transform;
        previousPosition = transform.position;
        previousRotation = transform.rotation;
        XROrigin rig = FindObjectOfType<XROrigin>();
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand/LeftBaseController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MapPosition(leftHand, leftHandRig);    
        var newRot = transform.rotation;
        Quaternion dif = previousRotation * Quaternion.Inverse(newRot);
        dif.ToAngleAxis(out angle, out axis);
        angularVelocity = axis * angle * Time.deltaTime;
        previousRotation = newRot;

        var NewPos = transform.position;
        linearVelocity = (NewPos - previousPosition) / Time.deltaTime;
        previousPosition = NewPos;
    }
}
