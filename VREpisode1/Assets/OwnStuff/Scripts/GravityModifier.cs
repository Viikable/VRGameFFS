using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Tooltip("Have we touched the water surface yet or not")]
    public bool TouchedWater;
    //The rigidbody which is created into this gameobject and which is used as the playerobject
    Rigidbody headsetbody;
    
    void Start()
    {
        headsetbody = this.GetComponent<Rigidbody>();
        TouchedWater = false;
        
    }

    private void OnTriggerEnter(Collider water)
    {
       if (water.name == "Water")       //just to check which object the rigidbody attached to the camerarig collided with
        {
            TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
            Debug.Log("Touched the water");
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
