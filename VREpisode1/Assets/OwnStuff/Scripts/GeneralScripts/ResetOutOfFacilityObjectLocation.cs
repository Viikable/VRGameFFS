using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ResetOutOfFacilityObjectLocation : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VRTK_InteractableObject>() != null)
        {
            if (other.GetComponent<LocationReset>() != null)
            {
            other.GetComponent<LocationReset>().ResetLocation();
            }
        }
        else if (other.transform.parent.GetComponent<VRTK_InteractableObject>() != null)
        {
            other.transform.parent.GetComponent<LocationReset>().ResetLocation();
        }
    }
}
