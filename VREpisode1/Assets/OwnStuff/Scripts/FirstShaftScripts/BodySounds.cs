using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySounds : MonoBehaviour
{
    AudioSource BodyHitsGroundSound;
   
    void Start()
    {
        BodyHitsGroundSound = GameObject.Find("BodyDropsSound").GetComponent<AudioSource>();       
    }

    void OnCollisionEnter(Collision collision)
    {               
        if (!BodyHitsGroundSound.isPlaying)
        {
            if (collision.relativeVelocity.magnitude - 1.5f >= 0.1f)
            {
                BodyHitsGroundSound.volume = collision.relativeVelocity.magnitude - 1.5f;
                Debug.Log("highlevelCollision");
            }
            else if (collision.relativeVelocity.magnitude - 1.5f <= 0.1f && collision.relativeVelocity.magnitude - 1.5f >= -0.5f)
            {
                BodyHitsGroundSound.volume = 0.1f;
                Debug.Log("lowlevelCollision");
            }
            else
            {
                BodyHitsGroundSound.volume = 0f;
            }
            BodyHitsGroundSound.Play();
        }
    }
}
