using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PliersSnapZone : MonoBehaviour {
    VRTK_SnapDropZone PlierZone;
    VRTK_SnapDropZone PlierZoneBox;

    void Awake () {
        PlierZone = GetComponentInChildren<VRTK_SnapDropZone>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JanitorBroom"))
        {
            PlierZone.ForceSnap(other.gameObject);
            Debug.Log("forcesnap");
        }
    }   
}
