using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Game_Manager : MonoBehaviour
{
    //just gonna collect loads of static variables here pm
    [Header("Events")]

    //[Tooltip("an event which takes care of water movement starting")]
    //public UnityEngine.Events.UnityEvent WaterComes;

    [Header("Booleans")]

    [SerializeField]
    [Tooltip("checks if the octomarker is being unsnapped from a snapzone")]
    public bool beingUnSnapped;

    [SerializeField]
    [Tooltip("checks if broom is ready to start the door cracking animation")]
    private bool playBroomAnimation;

    [SerializeField]
    [Tooltip("checks if the water has started moving or not")]
    private bool invoked;

    [SerializeField]
    [Tooltip("checks if the lantern is grabbed by the player or not")]
    private bool lanternIsGrabbed;

    [SerializeField]
    [Tooltip("checks if the lantern light is on or not")]
    private bool lanternLightIsOn;

    [SerializeField]
    [Tooltip("Toggles between climbable rope and grabbable rope")]
    private bool ropeClimb;

    [Header("Integers")]
    [SerializeField]
    private int numberOfTheBroom;

    [SerializeField]
    [Tooltip("Toggles between climbable rope and grabbable rope")]
    private int elevatorMoving;

    AudioSource LeftWaterPush;
    AudioSource RightWaterPush;

    [SerializeField]
    private WaterMovement water;

    [Header("Gameobjects")]

    public ParticleSystem WaterBubbles;

    public GameObject Lantern;

    public GameObject GrabbableWater;

    public GameObject JuhaniHead;

    public GameObject JuhaniBody;

    public GameObject JuhaniHand1;

    public GameObject JuhaniHand2;

    public GameObject JuhaniLeg1;

    public GameObject JuhaniLeg2;

    public GameObject RightController;

    public GameObject LeftController;

    public VRTK_InteractGrab RightGrab;

    public VRTK_InteractGrab LeftGrab;

    public static Game_Manager instance = null;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

        //WaterComes.AddListener(WaterIsRising);

        if (GameObject.Find("Water") != null)
        {
        WaterBubbles = GameObject.Find("Water").GetComponentInChildren<ParticleSystem>();

        WaterBubbles.Pause();

        LeftWaterPush = GameObject.Find("LeftWaterPush").GetComponent<AudioSource>();

        RightWaterPush = GameObject.Find("RightWaterPush").GetComponent<AudioSource>();

        Lantern = GameObject.Find("Lantern");

        GrabbableWater = GameObject.Find("GrabbableWater");

        water = GameObject.Find("Water").GetComponent<WaterMovement>();
        }

        ropeClimb = true;

        playBroomAnimation = false;

        lanternIsGrabbed = false;

        lanternLightIsOn = false;      

        beingUnSnapped = false;

        invoked = true;

        elevatorMoving = 0;

        numberOfTheBroom = 0;

        if (GameObject.Find("JuhaniBody") != null)
        {
        JuhaniBody = GameObject.Find("JuhaniBody");

        JuhaniHead = GameObject.Find("JuhaniHead");

        JuhaniHand1 = GameObject.Find("JuhaniHand1");

        JuhaniHand2 = GameObject.Find("JuhaniHand2");

        JuhaniLeg1 = GameObject.Find("JuhaniLeg1");

        JuhaniLeg2 = GameObject.Find("JuhaniLeg2");
        }

        RightController = GameObject.Find("RightController");

        LeftController = GameObject.Find("LeftController");

        RightGrab = RightController.GetComponent<VRTK_InteractGrab>();

        LeftGrab = LeftController.GetComponent<VRTK_InteractGrab>();

    }
    //OTHER METHODS THAN GETTERS AND SETTERS OR ANIMATION STARTERS HERE!
    private void FixedUpdate()
    {
        CheckGrabbedObjects();
    }
    private void WaterIsRising()
    {

        water.WaterRises = true;
    }
    public void CheckGrabbedObjects()
    {
        if (RightGrab.GetGrabbedObject() != null)
        {
            if (RightGrab.GetGrabbedObject() == Lantern)
            {
                lanternIsGrabbed = true;
                if (invoked)
                {
                    WaterBubbles.Play();
                    water.WaterRises = true;
                    invoked = false;
                    Debug.Log("invoked");
                    ResetOutOfFacilityObjectLocation.PlayerResetLocation = "SecondShaft";
                }
            }
        }
        else if (LeftGrab.GetGrabbedObject() != null)
        {
            if (LeftGrab.GetGrabbedObject() == Lantern)
            {
                lanternIsGrabbed = true;
                if (invoked)
                {
                    water.WaterRises = true;
                    invoked = false;
                    Debug.Log("invoked");
                    ResetOutOfFacilityObjectLocation.PlayerResetLocation = "SecondShaft";
                }
            }
        }
        else
        {
            lanternIsGrabbed = false;
        }
        if (RightGrab.GetGrabbedObject() != null && RightGrab.GetGrabbedObject().name == "JuhaniBody" && JuhaniHead.GetComponent<ConfigurableJoint>() != null)
        {
            RightGrab.ForceRelease();
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "FirstShaft";
            foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
            {
                Destroy(juhaniJoin);
            }
            foreach (ConfigurableJoint headNoose in GameObject.Find("NOOSE").GetComponents<ConfigurableJoint>())
            {
                if (headNoose.connectedBody.name == "JuhaniHead" || headNoose.connectedBody.name == "Bone_chest")
                {
                    Destroy(headNoose);
                }
            }
            RopeClimb = false;
            GameObject.Find("JuhaniBody").GetComponent<Rigidbody>().mass = 300;
            foreach (Rigidbody Juhanirigidpart in GameObject.Find("JuhaniBody").GetComponentsInChildren<Rigidbody>())
            {
                Juhanirigidpart.mass = 500;
                Juhanirigidpart.drag = 0.5f;
                Juhanirigidpart.angularDrag = 0.5f;
            }
        }
        else if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject().name == "JuhaniBody" && JuhaniHead.GetComponent<ConfigurableJoint>() != null)
        {
            LeftGrab.ForceRelease();
            ResetOutOfFacilityObjectLocation.PlayerResetLocation = "FirstShaft";
            foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
            {
                Destroy(juhaniJoin);
            }
            foreach (ConfigurableJoint headNoose in GameObject.Find("NOOSE").GetComponents<ConfigurableJoint>())
            {
                if (headNoose.connectedBody.name == "JuhaniHead" || headNoose.connectedBody.name == "Bone_chest")
                {
                    Destroy(headNoose);
                }
            }
            GameObject.Find("JuhaniBody").GetComponent<Rigidbody>().mass = 300;
            foreach (Rigidbody Juhanirigidpart in GameObject.Find("JuhaniBody").GetComponentsInChildren<Rigidbody>())
            {
                Juhanirigidpart.mass = 500;
                Juhanirigidpart.drag = 0.5f;
                Juhanirigidpart.angularDrag = 0.5f;
            }
            RopeClimb = false;
        }
        if (RightGrab.GetGrabbedObject() != null && RightGrab.GetGrabbedObject() == GrabbableWater)
        {
            Debug.Log("grabbedWater");
            if (!RightWaterPush.isPlaying)
            {
                RightWaterPush.Play();
            }
            StartCoroutine(WaitForSecondsRealtimeRight());
        }
        else if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject() == GrabbableWater)
        {
            if (!LeftWaterPush.isPlaying)
            {
                LeftWaterPush.Play();
            }
            Debug.Log("grabbedWater");
            StartCoroutine(WaitForSecondsRealtimeLeft());
        }
    }
    IEnumerator WaitForSecondsRealtimeRight()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        StartCoroutine(ReleaseOrNotRight());
    }
    IEnumerator WaitForSecondsRealtimeLeft()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        StartCoroutine(ReleaseOrNotLeft());
    }
    IEnumerator ReleaseOrNotRight()
    {
        if (RightGrab.GetGrabbedObject() != null && RightGrab.GetGrabbedObject() == GrabbableWater)
        {
            Debug.Log("ReleasedWater");
            RightGrab.ForceRelease();
        }
        else
        {
            yield return null;
        }
    }
    IEnumerator ReleaseOrNotLeft()
    {
        if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject() == GrabbableWater)
        {
            LeftGrab.ForceRelease();
        }
        else
        {
            yield return null;
        }
    }

    //GETTERS AND SETTERS PART BELOW HERE!

    public int ElevatorMoving
    {
        get { return elevatorMoving; }

        set { elevatorMoving = value; }
    }

    public bool RopeClimb
    {
        get { return ropeClimb; }

        set { ropeClimb = value; }
    }


    public bool IsLanternGrabbed
    {
        get { return lanternIsGrabbed; }

        set { lanternIsGrabbed = value; }
    }

    public bool LanternLightIsOn
    {
        get { return lanternLightIsOn; }

        set { LanternLightIsOn = value; }
    }

    public bool Invoked
    {
        get { return invoked; }

        set { invoked = value; }
    }
}


