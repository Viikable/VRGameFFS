using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Triggered : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger")
        {
            this.GetComponent<Button>().stayPressed = true;          
        }
    }
}
