using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagneticFence : MonoBehaviour
{

    //bool gg = false;
    AudioSource Electricity;

    private void Start()
    {
        Electricity = transform.Find("ElectricSound").gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("ResearchObject") || collision.collider.gameObject.name == "Marker")
        //{
        //    gg = true;
        Debug.Log("collided");
        if (Game_Manager.instance.LeftDirectInteractor.firstInteractableSelected != null)
        {
            Game_Manager.instance.LeftDirectInteractor.EndManualInteraction();
        }
        else if (Game_Manager.instance.RightDirectInteractor.firstInteractableSelected != null)
        {
            Game_Manager.instance.RightDirectInteractor.EndManualInteraction();
        }
        if (!Electricity.isPlaying)
        {
            Electricity.Play();
        }
    }
}
