using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BodySounds : CollisionSound
{     
    public override void Start()
    {
        collisionSound = GameObject.Find("BodyDropsSound").GetComponent<AudioSource>();       
    }
}
