using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class BoxDetecter : MonoBehaviour
    {
        VRTK_SnapDropZone boxSnap;


        // Use this for initialization
        void Start()
        {
            boxSnap = GetComponent<VRTK_SnapDropZone>();
        }

        // Update is called once per frame
        void Update()
        {
            if (boxSnap.GetCurrentSnappedObject().CompareTag("WoodenBox"))
            {
                boxSnap.GetCurrentSnappedObject().GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                = boxSnap.GetCurrentSnappedObject().GetComponent<GrabAttachMechanics.VRTK_ClimbableGrabAttach>();
            }
        }
    }
}
