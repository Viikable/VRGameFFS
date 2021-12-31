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
            if (Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected != null && Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected.Equals(gameObject))
            {
                Game_Manager.instance.LeftDirectInteractor.EndManualInteraction();
            }
            else if (Game_Manager.instance.RightDirectInteractor.firstInteractableSelected != null && Game_Manager.instance.RightDirectInteractor.firstInteractableSelected.Equals(gameObject))
            {
                Game_Manager.instance.RightDirectInteractor.EndManualInteraction();
            }
        }
    }
    private void Update()
    {
        CheckIfBoxBeingMoved();      
    }

    public void CheckIfBoxBeingMoved()
    {
        if (Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected != null && Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected.Equals(gameObject) 
            || (Game_Manager.instance.RightDirectInteractor.firstInteractableSelected != null && Game_Manager.instance.RightDirectInteractor.firstInteractableSelected.Equals(gameObject)))
        {
            if (!DraggingSound.isPlaying)
            {
                DraggingSound.Play();
            }
        }
        if (Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected == null && Game_Manager.instance.RightDirectInteractor.firstInteractableSelected == null)
        {
            DraggingSound.Stop();
        }
    }
}
