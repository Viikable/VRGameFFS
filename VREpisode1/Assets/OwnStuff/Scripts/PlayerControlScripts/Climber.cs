using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Climber : MonoBehaviour
{
    ActionBasedContinuousMoveProvider mover;
    ActionBasedSnapTurnProvider snapper;

    CharacterController character;
    //public InputActionReference handVelocityLeft;
    //public InputActionReference handVelocityRight;

    LeftControllerVelocityCalculator leftHandcalc;
    RightControllerVelocityCalculator rightHandcalc;

    Vector3 groundingVelocity = Vector3.zero;
    public static bool grounded;
    XRRig XRrig;

    Vector3 controllerSpeed;
    Vector3 controllerAngularSpeed;

    PositionRewindTaneli posrew;

    public static ActionBasedController climbingHand;

    private void OnEnable()
    {
        character = GetComponent<CharacterController>();
        leftHandcalc = GameObject.Find("LeftControllerVelocityCalculator").GetComponent<LeftControllerVelocityCalculator>();
        rightHandcalc = GameObject.Find("RightControllerVelocityCalculator").GetComponent<RightControllerVelocityCalculator>();
        mover = FindObjectOfType<ActionBasedContinuousMoveProvider>();
        snapper = FindObjectOfType<ActionBasedSnapTurnProvider>();
        XRrig = FindObjectOfType<XRRig>();
        grounded = true;
        posrew = FindObjectOfType<PositionRewindTaneli>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(handVelocityLeft.action.ReadValue<Vector3>() + "left");
        if (climbingHand != null)
        {        
            Climb();
            mover.enabled = false;
            snapper.enabled = false;
            grounded = false;
            posrew.enabled = false;
        }
        else
        {
            mover.enabled = true;
            snapper.enabled = true;
            posrew.enabled = true;
            //if (!grounded)
            //{
            //    //character.enabled = false;
            //    XRrig.GetComponent<Rigidbody>().isKinematic = false;
            //    XRrig.GetComponent<BoxCollider>().isTrigger = false;
            //}
            //else
            //{
            //    XRrig.GetComponent<Rigidbody>().isKinematic = true;
            //    //character.enabled = true;
            //    XRrig.GetComponent<BoxCollider>().isTrigger = true;
            //    mover.enabled = true;
            //    snapper.enabled = true;
            //    posrew.enabled = true;
            //}
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.CompareTag("Floor"))
    //    {
    //        Debug.Log("collisionfloor");
    //        grounded = true;
    //    }
    //}

    private void GroundPlayer(Vector3 translationInWorldSpace)
    {       
        if (XRrig == null)
        {
            return;
        }

        var motion = translationInWorldSpace;

        if (character != null && character.enabled)
        {
            // Step vertical velocity from gravity
            if (character.isGrounded)
            {
                groundingVelocity = Vector3.zero;
                grounded = true;
                mover.enabled = true;
                snapper.enabled = true;
            }
            else
            {
                groundingVelocity += Physics.gravity * Time.deltaTime;
            }

            motion += groundingVelocity * Time.deltaTime;
            // Note that calling Move even with Vector3.zero will have an effect by causing isGrounded to update
            character.Move(motion);
        }       
    }
    void Climb()
    {
        if (climbingHand.name == "LeftBaseController")
        {
            //controllerSpeed = handVelocityLeft.action.ReadValue<Vector3>();
            controllerSpeed = leftHandcalc.linearVelocity;
            controllerAngularSpeed = leftHandcalc.angularVelocity;
            //Debug.Log("left");
            //Debug.Log(handVelocityLeft.action.ReadValue<Vector3>());
        }
        else if (climbingHand.name == "RightBaseController")
        {
            //controllerSpeed = handVelocityRight.action.ReadValue<Vector3>();
            controllerSpeed = rightHandcalc.linearVelocity;
            controllerAngularSpeed = rightHandcalc.angularVelocity;
            //Debug.Log("right");
        }
        //InputDevices.GetDeviceAtXRNode(climbingHand.control).TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out Vector3 velocity);
        //Debug.Log(controllerSpeed);
        character.Move(transform.rotation * -controllerSpeed * Time.deltaTime);
    }
}
