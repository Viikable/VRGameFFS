using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class Rope_Climb_Toggler : MonoBehaviour {
        
        void Update() {

            if (Game_Manager.instance.RopeClimb)
            {
                GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                    = GetComponent<GrabAttachMechanics.VRTK_ClimbableGrabAttach>();
            }
            else
            {
                GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                    = GetComponent<GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
            }

        }
    }
}
