using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BodySounds : CollisionSound
{     
    public override void Start()
    {
        collisionSound = GameObject.Find("BodyDropsSound").GetComponent<AudioSource>();       
    }
}
