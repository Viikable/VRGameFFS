using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class Triggered : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger")
        {
            this.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;          
        }
    }
}
