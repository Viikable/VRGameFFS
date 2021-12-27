using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SirenUnSnapTrigger : MonoBehaviour {

    XRSocketInteractor SirenSnap;

    Button MarkerReleaseButton;

    GameObject Marker;

    bool markerCanSnap;

    void Start()
    {
        SirenSnap = GetComponent<XRSocketInteractor>();
        Marker = GameObject.Find("Marker");

        MarkerReleaseButton = GameObject.Find("MarkerReleaseButton").GetComponent<Button>();

        markerCanSnap = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker") && markerCanSnap)
        {
            SirenSnap.StartManualInteraction(Marker.GetComponent<XRGrabInteractable>());
            if (!OctopusLightCode.MarkerAttachSound.isPlaying)
            {
            OctopusLightCode.MarkerAttachSound.Play();
            }
            MarkerReleaseButton.stayPressed = true;  //remember to set this true so the release button gets activated again after releasing marker
        }
    }

    private void Update()
    {

        if (SirenSnap.firstInteractableSelected != null && SirenSnap.firstInteractableSelected.Equals(Marker)
            && MarkerReleaseButton.isPressedDown && MarkerReleaseButton.stayPressed)
        {
            Game_Manager.instance.beingUnSnapped = true;
            SirenSnap.EndManualInteraction();
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
