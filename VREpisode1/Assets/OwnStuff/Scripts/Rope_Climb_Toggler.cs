using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {

    public class Rope_Climb_Toggler : MonoBehaviour {



        // Update is called once per frame
        void Update() {

            if (Game_Manager.instance.RopeClimb)
            {
                this.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                    = this.GetComponent<GrabAttachMechanics.VRTK_ClimbableGrabAttach>();
            }
            else
            {
                this.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                    = this.GetComponent<GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
            }

        }
    }
}
