using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShaftTopOpening : MonoBehaviour
{
    XRSocketInteractor ShaftTopZone;
    Animator TopShaftHatch;
    bool notOpen;
    SkeletonKey SecondShaftKeyCard;
    AudioSource DamagedKeyCardSound;
    public Light TalosPuzzleLight;

    void Start()
    {
        ShaftTopZone = GetComponent<XRSocketInteractor>();
        TopShaftHatch = GameObject.Find("GateShaftEnd").GetComponent<Animator>();
        notOpen = true;
        SecondShaftKeyCard = GameObject.Find("ShaftKey").GetComponent<SkeletonKey>();
        DamagedKeyCardSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ShaftTopZone.firstInteractableSelected != null && notOpen)
        {
            if (!SecondShaftKeyCard.IsDamagedByWater())
            {
                TopShaftHatch.SetBool("Open", true);
                notOpen = false;
                TalosPuzzleLight.enabled = true;
            }
            else
            {
                DamagedKeyCardSound.Play();
            }
        }
    }
}
