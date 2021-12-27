using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MelterPoolUnSnapTrigger : MonoBehaviour {

    XRSocketInteractor ResearchPoolSnap;

    Button MarkerReleaseButton;

    GameObject Marker;

    bool markerCanSnap;

    void Start()
    {
        ResearchPoolSnap = GetComponent<XRSocketInteractor>();
        Marker = GameObject.Find("Marker");

        MarkerReleaseButton = GameObject.Find("MarkerReleaseButton").GetComponent<Button>();

        markerCanSnap = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker") && markerCanSnap)
        {
            ResearchPoolSnap.StartManualInteraction(Marker.GetComponent<XRGrabInteractable>());
            if (!OctopusLightCode.MarkerAttachSound.isPlaying)
            {
                OctopusLightCode.MarkerAttachSound.Play();
            }
            MarkerReleaseButton.stayPressed = true;  //remember to set this true so the release button gets activated again after releasing marker
        }
    }

    private void Update()
    {

        if (ResearchPoolSnap.firstInteractableSelected != null && ResearchPoolSnap.firstInteractableSelected.Equals(Marker)
            && MarkerReleaseButton.isPressedDown && MarkerReleaseButton.stayPressed)
        {
            Game_Manager.instance.beingUnSnapped = true;
            ResearchPoolSnap.EndManualInteraction();
            if (markerCanSnap)
            {
                markerCanSnap = false;
                StartCoroutine("WaitForMarker");
            }
        }
    }
    IEnumerator WaitForMarker()
    {
        yield return new WaitForSecondsRealtime(2f);
        markerCanSnap = true;
        MarkerReleaseButton.stayPressed = false;
        Game_Manager.instance.beingUnSnapped = false;
    }
}
