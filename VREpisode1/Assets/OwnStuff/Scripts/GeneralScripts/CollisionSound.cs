using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CollisionSound : MonoBehaviour {

    [Tooltip("Place the AudioSource component on the object which has this script")]
    public AudioSource collisionSound;

    public virtual void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (!collisionSound.isPlaying && !gameObject.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
            if (collision.relativeVelocity.magnitude - 1.5f >= 0.1f)
            {
                collisionSound.volume = collision.relativeVelocity.magnitude - 1.5f;
            }
            else if (collision.relativeVelocity.magnitude - 1.5f <= 0.1f)
            {
                collisionSound.volume = 0.1f;
            }
            else
            {
                collisionSound.volume = 0f;
            }
            collisionSound.Play();
        }
        else if (!collisionSound.isPlaying && gameObject.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
            collisionSound.Play();
        }
    }
}
