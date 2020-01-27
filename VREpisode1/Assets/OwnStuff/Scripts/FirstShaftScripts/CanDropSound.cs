using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CanDropSound : CollisionSound {
 
	public override void Start ()
    {
       //canDropSound
        collisionSound = transform.GetChild(0).transform.Find("CanDropSound").GetComponent<AudioSource>();
	}  
}
