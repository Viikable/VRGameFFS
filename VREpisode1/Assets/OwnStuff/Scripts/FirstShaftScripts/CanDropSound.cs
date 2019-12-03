using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CanDropSound : MonoBehaviour {

    public AudioSource canDropSound;
   
	void Start ()
    {
       
        canDropSound = transform.GetChild(0).transform.Find("CanDropSound").GetComponent<AudioSource>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!canDropSound.isPlaying && !gameObject.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
            Debug.Log("candrops");
            if (collision.relativeVelocity.magnitude - 2f >= 0.1f)
            {
                canDropSound.volume = collision.relativeVelocity.magnitude - 2f;
                Debug.Log("highlevelCollision");
            }
            else if (collision.relativeVelocity.magnitude - 2f <= 0.1f && collision.relativeVelocity.magnitude - 2f >= -0.5f)
            {
                canDropSound.volume = 0.1f;
                Debug.Log("lowlevelCollision");
            }
            else
            {
                canDropSound.volume = 0f;
            }
            canDropSound.Play();
        }
    }
}
