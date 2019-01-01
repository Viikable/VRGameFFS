using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WaterMovement : MonoBehaviour
{
    VRTK_HeadsetFade fader;  //this is used to create drowning effect when the headset slowly gets darker

    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;

    [SerializeField]
    [Tooltip("Have we touched the water surface yet or not")]
    private bool touchedWater;

    [SerializeField]
    [Tooltip("Have we left the water or not")]
    private bool exitedWater;

    [SerializeField]
    [Tooltip("Is player's head underwater currently")]
    private bool headIsUnderWater;

    [SerializeField]
    [Tooltip("Time when player enters the water")]
    private float timeWhenGotUnderwater;

    [SerializeField]
    [Tooltip("How much oxygen the player has left")]
    private float oxygenTimer;

    [Header("Water Hitting sound")]
    [Tooltip("The water hitting sound")]
    public AudioSource Splash;

    //[SerializeField]
    //[Tooltip("VRTK_SDK manager in scene")]
    //private VRTK_SDKManager sManager;

    public GameObject headSet;
    public Rigidbody headsetbody;
    public Collider feet;
    public Collider head;

    

    void Start()
    {
        touchedWater = false;
        oxygenTimer = 30f;
        waterRises = false;
        headIsUnderWater = false;
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
        
        if (hitCollider == feet)       //just to check which object the rigidbody attached to the camerarig collided with
        {          
            touchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
            Debug.Log("feet entered water");
            Splash.Play();
        }
        if (hitCollider == head)
        {
            headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
            touchedWater = true;
            Debug.Log("head entered water");
            timeWhenGotUnderwater = Time.time;
            headIsUnderWater = true;
            //Debug.Log(timeWhenGotUnderwater);
            fader.Fade(Color.black, 70f);
        }
    }
    private void OnTriggerExit(Collider hitCollider)
    {
        if (hitCollider == feet)
        {           
            Debug.Log("feet exited water");
            touchedWater = false;
        }
        if (hitCollider == head)
        {
            headIsUnderWater = false;
            Debug.Log("head exited water");
            headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
            //touchedWater = false;
            fader.Unfade(5f);
        }
    }
    void Update()
    {
        
        if (Time.time >= 0.25f && GameObject.Find("SteamVR") != null && VRTK_SDKManager.GetLoadedSDKSetup() == GameObject.Find("SteamVR").GetComponent<VRTK_SDKSetup>())   //this because the first check gives error as the colliders are created at runtime + don't wanna use this in the simulator
        {
            if (feet == null && head == null)   //to prevent error when system button is pressed
            {
                feet = headSet.transform.GetChild(3).GetChild(0).GetComponent<Collider>();   //finds the collider child for feet
                head = headSet.transform.GetChild(2).GetChild(3).GetComponent<Collider>();    //finds the collider child for head
            }
            headsetbody = headSet.GetComponent<Rigidbody>();
            if (headsetbody.velocity.y > 0.5) {
                //Debug.Log(headsetbody.velocity.y);
            }
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

            if (oxygenTimer < Time.time - timeWhenGotUnderwater && headIsUnderWater)
            {
                Debug.Log("drowned");
                //Debug.Log(Time.time);
                GameObject.Find("LeftController").GetComponent<VRTK_InteractGrab>().enabled = false;
                GameObject.Find("LeftController").GetComponent<VRTK_ControllerEvents>().enabled = false;
                GameObject.Find("RightController").GetComponent<VRTK_InteractGrab>().enabled = false;
                GameObject.Find("RightController").GetComponent<VRTK_ControllerEvents>().enabled = false;
                headSet.transform.GetChild(2).GetChild(3).GetComponent<Rigidbody>().isKinematic = false;
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
            this.transform.Translate(Vector3.up * 0.005f);
            Debug.Log("waterup");
        }
        else
        {
            this.transform.Translate(Vector3.up * 0f);
            //Debug.Log("waterdown");
        }
    }
    public bool WaterRises
    {
        get { return waterRises; }

        set { waterRises = value; }
    }
}
    

