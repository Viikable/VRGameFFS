using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WaterMovement : MonoBehaviour
{
    public VRTK_HeadsetFade fader;  //this is used to create drowning effect when the headset slowly gets darker

    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;

    [SerializeField]
    [Tooltip("Is the water level at the top of the shaft")]
    public bool reachedTopPuzzle;

    [SerializeField]
    [Tooltip("Have we touched the water surface yet or not")]
    public bool touchedWater;

    [SerializeField]
    [Tooltip("Has the floating box hit the water surface on one of its sides yet")]
    private bool boxDetected;

    [SerializeField]
    [Tooltip("Have we left the water or not")]
    private bool exitedWater;

    [SerializeField]
    [Tooltip("Is player's head underwater currently")]
    public bool headIsUnderWater;

    [SerializeField]
    [Tooltip("Time when player enters the water")]
    public float timeWhenGotUnderwater;

    [SerializeField]
    [Tooltip("How much oxygen the player has left")]
    private float oxygenTimer;

    [Header("Water Hitting sound")]
    [Tooltip("The water hitting sound")]
    public AudioSource Splash;

    //[SerializeField]
    //[Tooltip("VRTK_SDK manager in scene")]
    //private VRTK_SDKManager sManager;

    private BoxFloat floatingBox;
    public GameObject headSet;
    public Rigidbody headsetbody;
    public Collider feet;
    public Collider head;
    public GameObject HeadsetFollower;
    GameObject LeftController;
    GameObject RightController;

    

    void Start()
    {
        boxDetected = false;
        floatingBox = GameObject.Find("FloatingBox").GetComponent<BoxFloat>();
        LeftController = GameObject.Find("LeftController");
        RightController = GameObject.Find("RightController");
        touchedWater = false;
        oxygenTimer = 45f;
        waterRises = false;
        headIsUnderWater = false;
        reachedTopPuzzle = false;
        headSet = GameObject.Find("[VRTK_SDKManager]").transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        headsetbody = null;
        feet = null;
        head = null;
        fader = GameObject.Find("PlayArea").GetComponent<VRTK_HeadsetFade>();
        //sManager = GameObject.Find("[VRTK_SDKManager]").GetComponent<VRTK_SDKManager>();
    }
    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");

    }
    private void OnTriggerEnter(Collider hitCollider)
    {
        //    boxDetected = true;
        //    floatingBox.whatSideofTheBoxDown = 5;
        //}

        //if (hitCollider == feet)       //just to check which object the rigidbody attached to the camerarig collided with
        //{          
        //    touchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
        //    Debug.Log("feet entered water");
        //    Splash.Play();
        //}
        //if (hitCollider == head)
        //{
        //    headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
        //    touchedWater = true;
        //    Debug.Log("head entered water");
        //    timeWhenGotUnderwater = Time.time;
        //    headIsUnderWater = true;
        //    //Debug.Log(timeWhenGotUnderwater);
        //    fader.Fade(Color.black, 60f);
        //}
    }
    //private void OnTriggerExit(Collider hitCollider)
    //{
    //    if (hitCollider == feet)
    //    {           
    //        Debug.Log("feet exited water");
    //        touchedWater = false;
    //    }
    //    if (hitCollider == head)
    //    {
    //        headIsUnderWater = false;
    //        Debug.Log("head exited water");
    //        headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
    //        //touchedWater = false;
    //        fader.Unfade(5f);
    //    }
    //}
   
    void Update()
    {        
        if (Time.time >= 0.25f && GameObject.Find("SteamVR") != null && VRTK_SDKManager.GetLoadedSDKSetup() == GameObject.Find("SteamVR").GetComponent<VRTK_SDKSetup>())   //this because the first check gives error as the colliders are created at runtime + don't wanna use this in the simulator
        {
            if (feet == null && head == null)   //to prevent error when system button is pressed
            {
                feet = headSet.transform.GetChild(3).GetChild(0).GetComponent<Collider>();   //finds the collider child for feet
                if (HeadsetFollower.activeSelf)
                {
                    head = headSet.transform.GetChild(2).GetChild(3).GetComponent<Collider>();    //finds the collider child for head
                }
                else
                {
                    head = headSet.transform.GetChild(2).GetChild(2).GetComponent<Collider>();
                }
            }
            headsetbody = headSet.GetComponent<Rigidbody>();           
        }
       
        if (touchedWater)
        {
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + oxygenTimer*3/4 && headIsUnderWater)
            {
                Debug.Log("3/4 oxygen left");
            }
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + oxygenTimer/2 && headIsUnderWater)
            {
                Debug.Log("half oxygen left");
            }
            if (oxygenTimer < Time.time - timeWhenGotUnderwater + oxygenTimer*1/4 && headIsUnderWater)
            {
                Debug.Log("1/4 oxygen left");
            }

            if (oxygenTimer < Time.time - timeWhenGotUnderwater && headIsUnderWater && LeftController != null && RightController != null)
            {
                Debug.Log("drowned");
                //Debug.Log(Time.time);
                LeftController.GetComponent<VRTK_InteractGrab>().enabled = false;
                LeftController.GetComponent<VRTK_ControllerEvents>().enabled = false;
                RightController.GetComponent<VRTK_InteractGrab>().enabled = false;
                RightController.GetComponent<VRTK_ControllerEvents>().enabled = false;
                head.GetComponent<Rigidbody>().isKinematic = false;
                //player dies here, lose control, sink to bottom, fade to black
                Light [] lights = FindObjectsOfType<Light>();
                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].enabled = false;
                }               
            }
            Debug.Log("nogravity");
            //headsetbody.useGravity = false;
            Physics.gravity = new Vector3(0, -3, 0);
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
            if (!reachedTopPuzzle)
            {
                transform.Translate(Vector3.up * 0.005f);
            Debug.Log("waterup");
            }
            else
            {
                transform.Translate(Vector3.up * 0.00025f);
            }
        }      
    }
    public bool WaterRises
    {
        get { return waterRises; }

        set { waterRises = value; }
    }
}
    

