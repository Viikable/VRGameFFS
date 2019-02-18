using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BroomTrigger : MonoBehaviour {
    public GameObject Pliers;
    VRTK_SnapDropZone PlierZone;

    private void Awake()
    {
        Pliers = GameObject.Find("Melter_Pliers1.1_opened");
        PlierZone = GameObject.Find("PliersSnapZone").GetComponent<VRTK_SnapDropZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlierZone.GetCurrentSnappedInteractableObject() != null && PlierZone.GetCurrentSnappedInteractableObject() == this.GetComponentInParent<VRTK_InteractableObject>())
        {
            if (other.transform.parent != null && other.transform.parent.name == "HandColliders")
            {
                PlierZone.ForceUnsnap();
                foreach (MeshCollider col in Pliers.transform.GetComponentsInChildren<MeshCollider>())
                {
                    col.enabled = false;
                    Debug.Log("broomcollidersoffTriggerEnt");
                }
                //foreach (MeshCollider col in gameObject.transform.parent.GetComponentsInChildren<MeshCollider>())
                //{
                //    col.enabled = true;
                //    Debug.Log("plierbroomcollidersTriggerEnt");
                //}
            }
        }       
    }
    
}
