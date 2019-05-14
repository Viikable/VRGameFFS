using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MagneticFence : MonoBehaviour {

    bool gg = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ResearchObject"))
        {
            gg = true;
            Debug.Log("collided");
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null)
            {
                Game_Manager.instance.LeftGrab.ForceRelease();
            }
            else if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null)
            {
                Game_Manager.instance.RightGrab.ForceRelease();

            }
        }
    }
    
    void Update () {
       
    }
}
