using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDragging : MonoBehaviour {

    AudioSource DraggingSound;

    private void Start()
    {
        DraggingSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == WaterMovement.head || collision.collider == WaterMovement.feet || collision.collider == WaterMovement.body)
        {
            if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject() == gameObject)
            {
                Game_Manager.instance.LeftGrab.ForceRelease();
            }
            else if (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == gameObject)
            {
                Game_Manager.instance.RightGrab.ForceRelease();
            }
        }
    }
    private void Update()
    {
        CheckIfBoxBeingMoved();      
    }

    public void CheckIfBoxBeingMoved()
    {
        if (Game_Manager.instance.LeftGrab.GetGrabbedObject() != null && Game_Manager.instance.LeftGrab.GetGrabbedObject() == gameObject 
            || (Game_Manager.instance.RightGrab.GetGrabbedObject() != null && Game_Manager.instance.RightGrab.GetGrabbedObject() == gameObject))
        {
            if (!DraggingSound.isPlaying)
            {
                DraggingSound.Play();
            }
        }
        if (Game_Manager.instance.LeftGrab.GetGrabbedObject() == null && Game_Manager.instance.RightGrab.GetGrabbedObject() == null)
        {
            DraggingSound.Stop();
        }
    }
}
