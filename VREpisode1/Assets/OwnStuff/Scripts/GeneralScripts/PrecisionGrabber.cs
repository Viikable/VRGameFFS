using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrecisionGrabber : XRGrabInteractable
{
    ActionBasedController grabbingController;
    bool updateLeftPosition;
    bool updateRightPosition;
    GameObject handModelLeft;
    GameObject handModelRight;
    Transform originalAttachTransform;
    protected override void OnEnable()
    {
        base.OnEnable();
        handModelLeft = GameObject.Find("LeftBaseController/Model");
        handModelRight = GameObject.Find("RightBaseController/Model");
        updateLeftPosition = false;
        updateRightPosition = false;
        attachTransform = transform;
        originalAttachTransform = attachTransform;
    }
    void FixedUpdate()
    {
        //if (updateLeftPosition)
        //{
        //    attachTransform = handModelLeft.transform;
        //    attachTransform.position = handModelLeft.transform.position;
        //    attachTransform.rotation = handModelLeft.transform.rotation;
        //}
        //if (updateRightPosition)
        //{
        //    attachTransform = handModelRight.transform;
        //    attachTransform.position = handModelRight.transform.position;
        //    attachTransform.rotation = handModelRight.transform.rotation;
        //}
    }
    private void UpdateRightHandAttachTransform()
    {
        var handModelRightPos = handModelRight.transform.GetChild(0).gameObject;
        attachTransform = handModelRightPos.transform;
        //attachTransform.position = handModelRightPos.transform.position;
        //attachTransform.rotation = handModelRightPos.transform.rotation;
    }

    private void UpdateLeftHandAttachTransform()
    {
        var handModelLeftPos = handModelLeft.transform.GetChild(0).gameObject;
        attachTransform = handModelLeftPos.transform;
        //attachTransform.position = handModelLeftPos.transform.position;
        //attachTransform.rotation = handModelLeftPos.transform.rotation;
    }
    private void ResetHandAttachTransform()
    {
        attachTransform = originalAttachTransform;
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        grabbingController = args.interactorObject.transform.gameObject.GetComponent<ActionBasedController>();
        if (grabbingController.gameObject.name.Equals("LeftBaseController"))
        {
            UpdateLeftHandAttachTransform();
            Debug.Log("updated left");
        }
        else if (grabbingController.gameObject.name.Equals("RightBaseController"))
        {
            UpdateRightHandAttachTransform();
            Debug.Log("updated right");
        }
        base.OnSelectEntering(args);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        grabbingController = args.interactorObject.transform.gameObject.GetComponent<ActionBasedController>();
        if (grabbingController.gameObject.name.Equals("LeftBaseController"))
        {
            ResetHandAttachTransform();
            Debug.Log("reseted left");
        }
        else if (grabbingController.gameObject.name.Equals("RightBaseController"))
        {
            ResetHandAttachTransform();
            Debug.Log("reseted right");
        }
        base.OnSelectExiting(args);
    }
}
