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
            if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(gameObject))
            {
                Game_Manager.instance.LeftGrab.EndManualInteraction();
            }
            else if (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(gameObject))
            {
                Game_Manager.instance.RightGrab.EndManualInteraction();
            }
        }
    }
    private void Update()
    {
        CheckIfBoxBeingMoved();      
    }

    public void CheckIfBoxBeingMoved()
    {
        if (Game_Manager.instance.LeftGrab.firstInteractableSelected != null && Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(gameObject) 
            || (Game_Manager.instance.RightGrab.firstInteractableSelected != null && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(gameObject)))
        {
            if (!DraggingSound.isPlaying)
            {
                DraggingSound.Play();
            }
        }
        if (Game_Manager.instance.LeftGrab.firstInteractableSelected.Equals(null) && Game_Manager.instance.RightGrab.firstInteractableSelected.Equals(null))
        {
            DraggingSound.Stop();
        }
    }
}
