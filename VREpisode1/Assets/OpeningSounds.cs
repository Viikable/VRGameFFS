﻿
namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK.Controllables.PhysicsBased;

    public class OpeningSounds : MonoBehaviour
    {
        GameObject Crate;
        GameObject DoorLid;
        GameObject LeftController;
        GameObject RightController;
        bool doorActivator;
        public AudioSource crateSound;
        public AudioSource doorSlam;

        // Use this for initialization
        void Start()
        {
            Crate = GameObject.Find("CrateContainer");
            DoorLid = GameObject.Find("Lid2");
            crateSound = GameObject.Find("CrateSound").GetComponent<AudioSource>();
            doorSlam = GameObject.Find("DoorSlam").GetComponent<AudioSource>();
            LeftController = GameObject.Find("LeftController");
            RightController = GameObject.Find("RightController");
            doorActivator = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
            {

                if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Crate && !crateSound.isPlaying)
                {
                    crateSound.Play();
                }
                if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == DoorLid)
                {
                    doorActivator = true;
                }
                if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
                {
                    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Crate && !crateSound.isPlaying)
                    {
                        crateSound.Play();
                    }
                    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == DoorLid)
                    {
                        doorActivator = true;
                    }
                }
            }
            if (doorActivator && DoorLid.GetComponent<VRTK_PhysicsRotator>().IsResting() && !doorSlam.isPlaying)
            {
                doorSlam.Play();
                doorActivator = false;
            }
        }
    }
}