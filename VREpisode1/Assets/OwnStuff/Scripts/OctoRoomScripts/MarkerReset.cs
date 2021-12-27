using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MarkerReset : MonoBehaviour
{
    public Button MarkerResetButton;
    public GameObject Marker;
    public Transform ResetLocation;
    bool reseted;
    XRSocketInteractor storedSnapZone;

    private void Awake()
    {
        MarkerResetButton = GetComponentInChildren<Button>();
        Marker = GameObject.Find("Marker");
        ResetLocation = gameObject.transform.Find("ResetLocation").transform;
        reseted = false;
        storedSnapZone = null;
    }

    void Update()
    {
        if (MarkerResetButton.isPressedDown && !reseted)
        {
            reseted = true;
            Marker.transform.position = ResetLocation.transform.position;
            storedSnapZone = Marker.GetComponent<XRGrabInteractable>().firstInteractorSelecting as XRSocketInteractor;
            if (storedSnapZone != null)
            {
                storedSnapZone.EndManualInteraction();
            }
            Marker.GetComponent<Rigidbody>().isKinematic = true;
            Game_Manager.instance.beingUnSnapped = true;
            StartCoroutine("WaitForReset");
        }
    }
    IEnumerator WaitForReset()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        Marker.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSecondsRealtime(0.5f);
        Game_Manager.instance.beingUnSnapped = false;
        reseted = false;
    }
}

