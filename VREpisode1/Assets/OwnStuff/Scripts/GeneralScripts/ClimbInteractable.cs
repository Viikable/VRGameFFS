using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class ClimbInteractable : XRBaseInteractable
{ 
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);     
        if (args.interactor is XRDirectInteractor)
        {
            Climber.climbingHand = args.interactor.GetComponent<ActionBasedController>();
            Debug.Log(Climber.climbingHand);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (args.interactor is XRDirectInteractor)
        {
            if (Climber.climbingHand != null && Climber.climbingHand.name == args.interactor.name)
            {
                Climber.climbingHand = null;             
            }
        }
    }
}
