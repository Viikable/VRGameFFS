using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class OpenBoxUnSnapTrigger : MonoBehaviour
{
    VRTK_SnapDropZone OpenBoxSnap;

    VRTK_PhysicsPusher MarkerReleaseButton;

    GameObject Marker;
  
    bool markerCanSnap;
   
    void Start()
    {
        OpenBoxSnap = GetComponent<VRTK_SnapDropZone>();
        Marker = GameObject.Find("Marker");

        MarkerReleaseButton = GameObject.Find("MarkerReleaseButton").GetComponent<VRTK_PhysicsPusher>();

        markerCanSnap = true;
       
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.name == "Marker" && markerCanSnap)
        {
            OpenBoxSnap.ForceSnap(Marker);         
            MarkerReleaseButton.stayPressed = true;  //remember to set this true so the release button gets activated again after releasing marker
        }      
    }

    private void Update()
    {
      
        if (OpenBoxSnap.GetCurrentSnappedObject() != null && OpenBoxSnap.GetCurrentSnappedObject() ==
           Marker && MarkerReleaseButton.AtMaxLimit() && MarkerReleaseButton.stayPressed)
        {          
            Game_Manager.instance.beingUnSnapped = true;
            OpenBoxSnap.ForceUnsnap();
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