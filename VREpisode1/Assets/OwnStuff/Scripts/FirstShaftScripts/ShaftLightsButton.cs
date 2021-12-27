using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ShaftLightsButton : MonoBehaviour {
    Button shaftlightButton;
    GameObject MaintenanceLight;
    Light MaintenanceSpot;
    bool lightOn;
    bool processing;
    bool scared;
    AudioSource ShaftLightSound;
    AudioSource ScarySound;
	
	void Start () {
        shaftlightButton = GetComponent<Button>();
        MaintenanceLight = GameObject.Find("MaintenanceSpotLight");
        MaintenanceSpot = MaintenanceLight.GetComponent<Light>();
        lightOn = false;
        processing = false;
        ShaftLightSound = GetComponent<AudioSource>();
        ScarySound = GameObject.Find("ScarySound").GetComponent<AudioSource>();
        scared = false;
    }

    void Update()
    {
        if (shaftlightButton.isPressedDown && shaftlightButton.stayPressed && !lightOn && !processing)
        {
            processing = true;
            MaintenanceSpot.enabled = true;
            ShaftLightSound.Play();
            lightOn = true;
            StartCoroutine("Wait");
            ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.FirstShaft;
        }
        else if (shaftlightButton.isPressedDown && shaftlightButton.stayPressed && lightOn && !processing)
        {
            processing = true;
            MaintenanceSpot.enabled = false;
            ShaftLightSound.Play();
            lightOn = false;
            StartCoroutine("Wait");
        }

        if (lightOn && !scared)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            foreach (Collider col in GameObject.Find("JuhaniHead").GetComponentsInChildren<Collider>())
            {

                if (GeometryUtility.TestPlanesAABB(planes, col.bounds))
                {
                    ScarySound.Play();
                    scared = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("wait");
        yield return new WaitForSecondsRealtime(0.5f);
        shaftlightButton.stayPressed = false;
        StartCoroutine("Back");
    }
    IEnumerator Back()
    {
        Debug.Log("back");
        yield return new WaitForSecondsRealtime(0.5f);
        shaftlightButton.stayPressed = true;
        processing = false;
    }
}
