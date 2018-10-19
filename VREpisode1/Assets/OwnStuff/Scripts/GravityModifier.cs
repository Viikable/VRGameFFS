namespace VRTK
{


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GravityModifier : MonoBehaviour
    {
        [Tooltip("Have we touched the water surface yet or not")]
        public bool TouchedWater;

        [Tooltip("Have we left the water or not")]
        public bool ExitedWater;

        [Header("Water Hitting sound")]
        [Tooltip("The water hitting sound")]
        public AudioSource Splash;
        //The rigidbody which is created into this gameobject and which is used as the playerobject
        Rigidbody headsetbody;

        void Start()
        {
            headsetbody = this.GetComponent<Rigidbody>();
            TouchedWater = false;
       

        }

        private void OnTriggerEnter(Collider water)
        {
            if (water.name == "GrabbableWater")       //just to check which object the rigidbody attached to the camerarig collided with
            {
                TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
                Debug.Log("Touched the water");
                
                Splash.Play();

            }
        }
        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.name == "GrabbableWater")
        //    {
        //        TouchedWater = false;
        //        Debug.Log("exited water");

        //    }
        //}
        // Update is called once per frame
        void Update()
        {


            if (TouchedWater)
            {
                headsetbody.useGravity = false;

                headsetbody.AddForce(Physics.gravity * headsetbody.mass / 10);
                //GameObject.Find("Either Controller - X Axis Slide - Y Axis Slide").GetComponent<VRTK_SlideObjectControlAction>().maximumSpeed = 0.5f;
                if (headsetbody.velocity.y >= 0)
                {
                    headsetbody.AddForce(Vector3.down*5f);
                }
                else
                {
                    return;
                }

            }
            else
            {
                headsetbody.useGravity = true;
            }
        }
    }
}
