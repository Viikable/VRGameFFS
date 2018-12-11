namespace VRTK
{


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GravityModifier : MonoBehaviour
    { /*
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
        //The rigidbody which is created into this gameobject and which is used as the playerobject
        public Rigidbody headsetbody;

        void Start()
        {
            headsetbody = this.GetComponent<Rigidbody>();
            TouchedWater = false;
            oxygenTimer = 30f;

        }

        private void OnTriggerEnter(Collider water)
        {
            GameObject footCollider = GameObject.Find("[VRTK][AUTOGEN][FootColliderContainer]");

            if (water.name == "GrabbableWater")       //just to check which object the rigidbody attached to the camerarig collided with
            {
                timeWhenGotUnderwater = Time.time;
                Debug.Log(timeWhenGotUnderwater);
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
        void Update()
        {          
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
                
                //if (headsetbody.velocity.y >= 0)
                //{
                //    Debug.Log("now changes");
                //    headsetbody.AddForce(new Vector3(0,-3,0));
                //}
                //else
                //{
                //    return;
                //}

            }
            else
            {
                headsetbody.useGravity = true;
            }
        } */
    } 
}
