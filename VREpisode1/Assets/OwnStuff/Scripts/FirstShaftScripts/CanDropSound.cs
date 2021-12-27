using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CanDropSound : CollisionSound {
 
	public override void Start ()
    {
       //canDropSound
        collisionSound = transform.GetChild(0).transform.Find("CanDropSound").GetComponent<AudioSource>();
	}  
}
