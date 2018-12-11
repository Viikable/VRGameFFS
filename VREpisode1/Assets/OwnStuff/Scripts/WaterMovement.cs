using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;
    [Tooltip("Have we touched the water surface yet or not")]
    public bool TouchedWater;

    [Tooltip("Have we left the water or not")]
    public bool ExitedWater;

    [SerializeField]
    [Tooltip("Time when player enters the water")]
    float timeWhenGotUnderwater;

    [SerializeField]
    [Tooltip("How much oxygen the player has left")]
    float oxygenTimer;

    [Header("Water Hitting sound")]
    [Tooltip("The water hitting sound")]
    public AudioSource Splash;

    public GameObject headSet;
    public Rigidbody headsetbody;
    public Collider feet;
    public Collider head;

    void Start()
    {
        TouchedWater = false;
        oxygenTimer = 30f;
        waterRises = false;
        headSet = GameObject.Find("[VRTK_SDKManager]").transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        headsetbody = null;
        feet = null;
        head = null;
    }

    //   void Start () {
    //       waterRises = false;
    //}
    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");

    }
    private void OnTriggerEnter(Collider hitCollider)
    {
        
        if (hitCollider == feet)       //just to check which object the rigidbody attached to the camerarig collided with
        {          
            TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
            Debug.Log("feet entered water");
            Splash.Play();
            headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;

        }
        if (hitCollider = head)
        {
            Debug.Log("head entered water");
            timeWhenGotUnderwater = Time.time;
            Debug.Log(timeWhenGotUnderwater);
        }
    }
    private void OnTriggerExit(Collider hitCollider)
    {
        if (hitCollider == feet)
        {           
            Debug.Log("feet exited water");
            headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
        }
        if (hitCollider == head)
        {
            Debug.Log("head exited water");
            TouchedWater = false;
        }
    }
    void Update()
    {
        if (Time.time >= 0.5f)
        {
            feet = headSet.transform.GetChild(3).GetChild(0).GetComponent<Collider>();   //finds the collider child for feet
            head = headSet.transform.GetChild(2).GetChild(3).GetComponent<Collider>();    //finds the collider child for head
        }
        headsetbody = headSet.GetComponent<Rigidbody>();
        if (TouchedWater)
        {
            if (oxygenTimer < Time.time - timeWhenGotUnderwater)
            {
                Debug.Log("drowned");
                Debug.Log(Time.time);
                //player dies here, lose control, sink to bottom, fade to black

            }

            headsetbody.useGravity = false;

            headsetbody.AddForce(Physics.gravity * headsetbody.mass / 10);
        }
        else if (headsetbody != null)
        {
            headsetbody.useGravity = true;
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
    // Update is called once per frame
 //   void Update () {
 //       if (WaterRises)
 //       {
 //           this.transform.Translate(Vector3.up * 0.005f);
 //           Debug.Log("waterup");
 //       }
 //       else
 //       {
 //           this.transform.Translate(Vector3.up * 0f);
 //           //Debug.Log("waterdown");
 //       }
        
	//}

