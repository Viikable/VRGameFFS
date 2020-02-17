using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WaterMovement : MonoBehaviour
{
    public static VRTK_HeadsetFade fader;  //this is used to create drowning effect when the headset slowly gets darker

    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;

    [Tooltip("Just to check if rope is unaffected by gravity yet in LessRealisticWaterPuzzle")]
    bool ropeCheck;

    [SerializeField]
    [Tooltip("Is the water level at the top of the shaft")]
    public bool reachedTopPuzzle;

    [SerializeField]
    [Tooltip("Has the player drowned")]
    public static bool notDrownedYet;

    [SerializeField]
    [Tooltip("Have we touched the water surface yet or not")]
    public static bool touchedWater;

    [SerializeField]
    [Tooltip("Has the floating box hit the water surface on one of its sides yet")]
    private bool boxDetected;

    [SerializeField]
    [Tooltip("Have we left the water or not")]
    private static bool exitedWater;

    [SerializeField]
    [Tooltip("Is player's head underwater currently")]
    public static bool headIsUnderWater;

    [SerializeField]
    [Tooltip("Time when player enters the water")]
    public static float timeWhenGotUnderwater;

    [SerializeField]
    [Tooltip("How much oxygen the player has left")]
    private static float oxygenTimer;

    [Header("Water sounds")]
    [Tooltip("The water hitting sound")]
    public AudioSource Splash;
    [Tooltip("Drowning sound")]
    public AudioSource Drowned;
    [Tooltip("24s oxygen left sounds")]
    public AudioSource DrowningAlertSounds;

    //ambient water sounds while underwater
    public AudioSource UnderwaterAmbience1;
    public AudioSource UnderwaterAmbience2;
    public AudioSource UnderwaterAmbience3;
    public AudioSource UnderwaterAmbience4;

    private BoxFloat floatingBox;

    [Header("Colliders")]
    public GameObject headSet;
    public Rigidbody headsetbody;
    public static Collider feet;
    public static Collider head;
    public static Collider body;
    public GameObject HeadsetFollower;
    //Light UnderWaterHeadLight;
    GameObject LeftController;
    GameObject RightController;



    void Start()
    {
        boxDetected = false;
        floatingBox = GameObject.Find("FloatingBox").GetComponent<BoxFloat>();
        LeftController = GameObject.Find("LeftController");
        RightController = GameObject.Find("RightController");
        touchedWater = false;
        oxygenTimer = 60f;
        waterRises = false;
        headIsUnderWater = false;
        reachedTopPuzzle = false;
        notDrownedYet = true;
        headSet = GameObject.Find("[VRTK_SDKManager]").transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        headsetbody = null;
        feet = null;
        head = null;
        ropeCheck = true;
        fader = GameObject.Find("PlayArea").GetComponent<VRTK_HeadsetFade>();
        UnderwaterAmbience1 = transform.Find("UnderwaterAmbience1").GetComponent<AudioSource>();
        UnderwaterAmbience2 = transform.Find("UnderwaterAmbience2").GetComponent<AudioSource>();
        UnderwaterAmbience3 = transform.Find("UnderwaterAmbience3").GetComponent<AudioSource>();
        UnderwaterAmbience4 = transform.Find("UnderwaterAmbience4").GetComponent<AudioSource>();
        //UnderWaterHeadLight = headSet.transform.GetChild(2).GetChild(2).GetComponent<Light>();
        //sManager = GameObject.Find("[VRTK_SDKManager]").GetComponent<VRTK_SDKManager>();
    }

    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");

    }

    void FixedUpdate()
    {

        if (Time.time >= 0.25f && GameObject.Find("SteamVR") != null && VRTK_SDKManager.GetLoadedSDKSetup() == GameObject.Find("SteamVR").GetComponent<VRTK_SDKSetup>())   //this because the first check gives error as the colliders are created at runtime + don't wanna use this in the simulator
        {
            if (feet == null && head == null)   //to prevent error when system button is pressed
            {
                feet = headSet.transform.GetChild(3).GetChild(0).GetComponent<Collider>();   //finds the collider child for feet
                Debug.Log(feet);
                body = headSet.transform.GetChild(3).GetComponent<Collider>();
                Debug.Log(body);
                if (HeadsetFollower.activeSelf)
                {
                    head = headSet.transform.GetChild(2).GetChild(4).GetComponent<Collider>();    //finds the collider child for head
                    Debug.Log(head);
                }
                else
                {
                    head = headSet.transform.GetChild(2).GetChild(3).GetComponent<Collider>();
                    Debug.Log(head);
                }
            }
            headsetbody = headSet.GetComponent<Rigidbody>();
        }

        if (touchedWater)
        {
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + oxygenTimer * 3 / 4 && headIsUnderWater)
            {
                //Debug.Log("3/4 oxygen left");
            }
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + oxygenTimer / 2 && headIsUnderWater)
            {
                //Debug.Log("half oxygen left");
            }
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + 24f && headIsUnderWater && notDrownedYet)
            {
                //Debug.Log("24s oxygen left");
                if (!DrowningAlertSounds.isPlaying)
                {
                    DrowningAlertSounds.Play();
                }
            }
            if (!UnderwaterAmbience1.isPlaying)
            {
                UnderwaterAmbience1.Play();
                UnderwaterAmbience2.Play();
                UnderwaterAmbience3.Play();
                UnderwaterAmbience4.Play();
            }
            //plays underwater ambience only when head is actually underwater
            if (headIsUnderWater)
            {
                UnderwaterAmbience1.volume = 1;
                UnderwaterAmbience2.volume = 1;
                UnderwaterAmbience3.volume = 1;
                UnderwaterAmbience4.volume = 1;
            }
            else
            {
                UnderwaterAmbience1.volume = 0.5f;
                UnderwaterAmbience2.volume = 0.5f;
                UnderwaterAmbience3.volume = 0.5f;
                UnderwaterAmbience4.volume = 0.5f;
            }

            if (oxygenTimer < Time.time - timeWhenGotUnderwater && headIsUnderWater && notDrownedYet)
            {
                DrowningAlertSounds.Stop();
                notDrownedYet = false;
                Drowned.Play();
                Debug.Log("drowned");
                //Debug.Log(Time.time);
                LeftController.GetComponent<VRTK_InteractGrab>().enabled = false;
                LeftController.GetComponent<VRTK_ControllerEvents>().enabled = false;
                RightController.GetComponent<VRTK_InteractGrab>().enabled = false;
                RightController.GetComponent<VRTK_ControllerEvents>().enabled = false;
                head.GetComponent<Rigidbody>().isKinematic = false;
                //player dies here, lose control, sink to bottom, fade to black
                fader.Fade(Color.black, 3f);                      
            }
            //Debug.Log("nogravity");
            //headsetbody.useGravity = false;
            if (headIsUnderWater)
            {
                Physics.gravity = new Vector3(0, -2.5f, 0);
            }
            else
            {
                Physics.gravity.Set(0, -9.81f, 0);
            }
            //headsetbody.AddForce(Physics.gravity * headsetbody.mass / 4);

            //if (headsetbody.velocity.y >= 0)
            //{
            //    Debug.Log("now changes");
            //    headsetbody.AddForce(new Vector3(0, -9, 0));
            //}
            //else
            //{
            //    return;
            //}
        }
        else if (headsetbody != null)
        {
            Physics.gravity.Set(0, -9.81f, 0);
            //headsetbody.useGravity = true;
            //Debug.Log("gravity");
        }

        if (WaterRises)
        {
            //while the water hasn't hit the top of the ceiling the speed remains the same
            if (!reachedTopPuzzle)
            {
                transform.Translate(Vector3.up * 0.2f * Time.deltaTime, Space.World);
                //Debug.Log("waterup");
            }
            //after hitting the ceiling the speed slows down until stopping eventually when it reaches the air lock to octoroom
            else
            {
                transform.Translate(Vector3.up * 0.005f * Time.deltaTime, Space.World);
            }
        }
    }
    public bool WaterRises
    {
        get { return waterRises; }

        set { waterRises = value; }
    }
}


