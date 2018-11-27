namespace VRTK
{


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GravityModifier : MonoBehaviour
    {
        [Tooltip("Have we touched the water surface yet or not")]
        public bool TouchedWater;
<<<<<<< HEAD
        [Header("The water which forms around the player")]
        GameObject WaterPiece1;
        GameObject WaterPiece2;
        GameObject WaterPiece3;
        GameObject WaterPiece4;
        [Header("Water Hitting sound")]
        [Tooltip("The water hitting sound")]
        public AudioSource Splash;
        Renderer rend1;
        Renderer rend2;
        Renderer rend3;
        Renderer rend4;
        //The rigidbody which is created into this gameobject and which is used as the playerobject
        Rigidbody headsetbody;
=======

        [Tooltip("Have we left the water or not")]
        public bool ExitedWater;

        [Header("Water Hitting sound")]
        [Tooltip("The water hitting sound")]
        public AudioSource Splash;
        //The rigidbody which is created into this gameobject and which is used as the playerobject
        public Rigidbody headsetbody;
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061

        void Start()
        {
            headsetbody = this.GetComponent<Rigidbody>();
            TouchedWater = false;
<<<<<<< HEAD
            //rend1 = WaterPiece1.GetComponent<MeshRenderer>();
            //rend2 = WaterPiece2.GetComponent<MeshRenderer>();
            //rend3 = WaterPiece3.GetComponent<MeshRenderer>();
            //rend4 = WaterPiece4.GetComponent<MeshRenderer>();
=======
       
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061

        }

        private void OnTriggerEnter(Collider water)
        {
<<<<<<< HEAD
            if (water.name == "Grabbable water")       //just to check which object the rigidbody attached to the camerarig collided with
            {
                TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
                Debug.Log("Touched the water");
                //rend1.enabled = true;
                //rend2.enabled = true;
                //rend3.enabled = true;
                //rend4.enabled = true;
                Splash.Play();

            }
        }
        // Update is called once per frame
        void Update()
        {


=======
            if (water.name == "GrabbableWater")       //just to check which object the rigidbody attached to the camerarig collided with
            {
                TouchedWater = true;                            //whenever we want the gravity to return to normal we can just change the bool back to false
                Debug.Log("Touched the water");
                
                Splash.Play();
                this.GetComponentInChildren<UnderWaterEffect>().enabled = true;

            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "GrabbableWater")
            {
                TouchedWater = false;
                Debug.Log("exited water");
                this.GetComponentInChildren<UnderWaterEffect>().enabled = false;
            }
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            //Debug.Log(headsetbody.velocity.y+ "Y");
            //Debug.Log(headsetbody.velocity.x +"X");
            //Debug.Log(headsetbody.velocity.z+ "Z");
           
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061
            if (TouchedWater)
            {
                headsetbody.useGravity = false;

<<<<<<< HEAD
                headsetbody.AddForce(Physics.gravity * headsetbody.mass / 24);
                GameObject.Find("Either Controller - X Axis Slide - Y Axis Slide").GetComponent<VRTK_SlideObjectControlAction>().maximumSpeed = 0.5f;
    

        }
=======
                headsetbody.AddForce(Physics.gravity * headsetbody.mass / 10);
                //GameObject.Find("Either Controller - X Axis Slide - Y Axis Slide").GetComponent<VRTK_SlideObjectControlAction>().maximumSpeed = 0.5f;
                if (headsetbody.velocity.y >= 0)
                {
                    Debug.Log("now changes");
                    headsetbody.AddForce(new Vector3(0,3,0));
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
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061
        }
    }
}
