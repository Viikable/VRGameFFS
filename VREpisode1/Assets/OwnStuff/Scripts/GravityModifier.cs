using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Tooltip("Have we touched the water surface yet or not")]
    public bool TouchedWater;
    [Header("The water which forms around the player")]
    public GameObject WaterPiece1;
    public GameObject WaterPiece2;
    public GameObject WaterPiece3;
    public GameObject WaterPiece4;
    [Header("Water Hitting sound")]
    [Tooltip("The water hitting sound")]
    public AudioSource Splash;
    Renderer rend1;
    Renderer rend2;
    Renderer rend3;
    Renderer rend4;
    //The rigidbody which is created into this gameobject and which is used as the playerobject
    Rigidbody headsetbody;
    
    void Start()
    {
        headsetbody = this.GetComponent<Rigidbody>();
        TouchedWater = false;
        rend1 = WaterPiece1.GetComponent<MeshRenderer>();
        rend2 = WaterPiece1.GetComponent<MeshRenderer>();
        rend3 = WaterPiece1.GetComponent<MeshRenderer>();
        rend4 = WaterPiece1.GetComponent<MeshRenderer>();

    }

    private void OnTriggerEnter(Collider water)
    {
       if (water.name == "Water")       //just to check which object the rigidbody attached to the camerarig collided with
        {
            TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
            Debug.Log("Touched the water");
            rend1.enabled = true;
            rend2.enabled = true;
            rend3.enabled = true;
            rend4.enabled = true;
            Splash.Play();

        } 
    }
    // Update is called once per frame
    void Update()
    {
       

        if (TouchedWater)
        {
            headsetbody.useGravity = false;

            headsetbody.AddForce(Physics.gravity * headsetbody.mass/12);
           
        }
    }
}
