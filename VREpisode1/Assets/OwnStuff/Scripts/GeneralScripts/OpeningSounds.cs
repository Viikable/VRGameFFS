
  using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;


public class OpeningSounds : MonoBehaviour
{
    public GameObject Crate;
    public GameObject DoorLid;
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

        if (LeftController.GetComponent<XRBaseInteractor>().firstInteractableSelected != null)
        {

            if (LeftController.GetComponent<XRBaseInteractor>().firstInteractableSelected.Equals(Crate) && !crateSound.isPlaying)
            {
                crateSound.Play();
                Debug.Log("cratesoundleft");
            }
            if (LeftController.GetComponent<XRBaseInteractor>().firstInteractableSelected.Equals(DoorLid))
            {
                doorActivator = true;
            }
        }
        if (RightController.GetComponent<XRBaseInteractor>().firstInteractableSelected != null)
        {
            if (RightController.GetComponent<XRBaseInteractor>().firstInteractableSelected.Equals(Crate) && !crateSound.isPlaying)
            {
                crateSound.Play();
                Debug.Log("cratesoundright");
            }
            if (RightController.GetComponent<XRBaseInteractor>().firstInteractableSelected.Equals(DoorLid))
            {
                doorActivator = true;
            }
        }
        //doorlid is resting, aka static
        if (doorActivator && DoorLid.GetComponent<HingeJoint>().velocity.Equals(0f) && !doorSlam.isPlaying)
        {
            Debug.Log("doorslam");
            doorSlam.Play();
            doorActivator = false;
        }
    }
}

