
        namespace VRTK
    {
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using VRTK.Controllables.PhysicsBased;

        public class OpeningSounds : MonoBehaviour {
            GameObject Crate;
            GameObject DoorLid;
            public AudioSource crateSound;
            public AudioSource doorSlam;

            // Use this for initialization
            void Start() {
                Crate = GameObject.Find("CrateContainer");
                DoorLid = GameObject.Find("Lid2");
                crateSound = GameObject.Find("CrateSound").GetComponent<AudioSource>();
                doorSlam = GameObject.Find("DoorSlam").GetComponent<AudioSource>();
            }

            // Update is called once per frame
            void Update() {
                if (GameObject.Find("LeftController").GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Crate
                    || GameObject.Find("RightController").GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Crate)
                {
                    crateSound.Play();
                }
                else
                {
                    crateSound.Stop();
                }
                if (GameObject.Find("LeftController").GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == DoorLid
                    || GameObject.Find("RightController").GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == DoorLid
                    && DoorLid.GetComponent<VRTK_PhysicsRotator>().IsResting())
                {
                doorSlam.Play();
                }

            }
        }
    }
