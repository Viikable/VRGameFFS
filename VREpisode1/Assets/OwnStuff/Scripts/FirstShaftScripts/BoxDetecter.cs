using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BoxDetecter : MonoBehaviour
{
    //handles stacking boxes in first shaft by enabling invisible boxes to the place of the snapped box in order to make them stay on still while on top of each other
    XRSocketInteractor boxSnap;
    bool notSnapped;
    GameObject previouslySnapped;
    GameObject invisible;
    static int boxCounter;
    AudioSource BoxStackingSound;

    void Start()
    {
        boxSnap = GetComponent<XRSocketInteractor>();
        notSnapped = true;
        previouslySnapped = null;
        boxCounter = 0;
        invisible = null;
        BoxStackingSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (boxSnap.firstInteractableSelected != null && boxSnap.firstInteractableSelected.transform.gameObject.CompareTag("WoodenBox"))
        {
            previouslySnapped = boxSnap.firstInteractableSelected.transform.gameObject;
            boxCounter++;
            invisible = GameObject.Find("InvisibleBox" + boxCounter.ToString());
            invisible.GetComponent<Collider>().enabled = true;
            invisible.GetComponent<MeshRenderer>().enabled = true;
            Destroy(previouslySnapped);
            GetComponent<Collider>().enabled = false;
            if (!BoxStackingSound.isPlaying)
            {
                BoxStackingSound.Play();
            }
            if (boxCounter < 5)
            {
                GameObject.Find("WoodenSnapZone" + boxCounter.ToString()).GetComponent<Collider>().enabled = true;
            }
        }

    }
}
