using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class MelterPoolUnSnapTrigger : MonoBehaviour {

    VRTK_SnapDropZone ResearchPoolSnap;

    VRTK_PhysicsPusher MarkerReleaseButton;

    GameObject Marker;

    bool markerCanSnap;

    void Start()
    {
        ResearchPoolSnap = GetComponent<VRTK_SnapDropZone>();
        Marker = GameObject.Find("Marker");

        MarkerReleaseButton = GameObject.Find("MarkerReleaseButton").GetComponent<VRTK_PhysicsPusher>();

        markerCanSnap = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker") && markerCanSnap)
        {
            ResearchPoolSnap.ForceSnap(Marker);
            if (!OctopusLightCode.MarkerAttachSound.isPlaying)
            {
                OctopusLightCode.MarkerAttachSound.Play();
            }
            MarkerReleaseButton.stayPressed = true;  //remember to set this true so the release button gets activated again after releasing marker
        }
    }

    private void Update()
    {

        if (ResearchPoolSnap.GetCurrentSnappedObject() != null && ResearchPoolSnap.GetCurrentSnappedObject() ==
           Marker && MarkerReleaseButton.AtMaxLimit() && MarkerReleaseButton.stayPressed)
        {
            Game_Manager.instance.beingUnSnapped = true;
            ResearchPoolSnap.ForceUnsnap();
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
