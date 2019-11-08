using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeRendering : MonoBehaviour {

    [Tooltip("If inside melter then doesn't render other areas")]
    public static bool insideMelterArea;

    [Tooltip("If inside MainHall then doesn't render other areas")]
    public static bool insideMainHall;

    [Tooltip("If inside Shafts then doesn't render other areas")]
    public static bool insideShafts;

    [Tooltip("If inside OctoRoom then doesn't render other areas")]
    public static bool insideOctoRoom;

    public static GameObject[] MelterObjects = new GameObject[1000];

    public static GameObject[] MainHallObjects = new GameObject[1000];

    public static GameObject[] ShaftsObjects = new GameObject[1000];

    public static GameObject[] OctoRoomObjects = new GameObject[1000];

    public static bool renderingChanged;

    int counter;

    // Use this for initialization
    void Awake () {
        insideMelterArea = false;
        insideMainHall = true;       //we start here
        insideShafts = false;
        insideOctoRoom = true;
        renderingChanged = false;
        counter = 0;

        foreach (MelterObject scriptObject in GameObject.FindObjectsOfType<MelterObject>())
        {          
            MelterObjects[counter] = scriptObject.gameObject;
            counter++;
        }
        counter = 0;
        foreach (MainHallObject scriptObject in GameObject.FindObjectsOfType<MainHallObject>())
        {
            MainHallObjects[counter] = scriptObject.gameObject;
            counter++;
        }
        counter = 0;
        foreach (ShaftsObject scriptObject in GameObject.FindObjectsOfType<ShaftsObject>())
        {
            ShaftsObjects[counter] = scriptObject.gameObject;
            counter++;
        }
        counter = 0;
        foreach (OctoRoomObject scriptObject in GameObject.FindObjectsOfType<OctoRoomObject>())
        {
            OctoRoomObjects[counter] = scriptObject.gameObject;
            counter++;
        }
    }
		
	void Update ()
    {
		if (!renderingChanged)
        {
            if (insideMelterArea)
            {
                foreach (GameObject melterObject in MelterObjects)
                {
                    if (melterObject != null && melterObject.GetComponent<MeshRenderer>() != null)
                    {
                        melterObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
            else
            {
                foreach (GameObject melterObject in MelterObjects)
                {
                    if (melterObject != null && melterObject.GetComponent<MeshRenderer>() != null)
                    {
                    melterObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
            if (insideMainHall)
            {
                foreach (GameObject MainHallObject in MainHallObjects)
                {
                    if (MainHallObject != null && MainHallObject.GetComponent<MeshRenderer>() != null)
                    {
                        MainHallObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
            else
            {
                foreach (GameObject MainHallObject in MainHallObjects)
                {
                    if (MainHallObject != null && MainHallObject.GetComponent<MeshRenderer>() != null)
                    {
                        MainHallObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
            if (insideShafts)
            {
                foreach (GameObject ShaftsObject in ShaftsObjects)
                {
                    if (ShaftsObject != null && ShaftsObject.GetComponent<MeshRenderer>() != null)
                    {
                        ShaftsObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
            else
            {
                foreach (GameObject ShaftsObject in ShaftsObjects)
                {
                    if (ShaftsObject != null && ShaftsObject.GetComponent<MeshRenderer>() != null)
                    {
                        ShaftsObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
            if (insideOctoRoom)
            {
                foreach (GameObject OctoRoomObject in OctoRoomObjects)
                {
                    if (OctoRoomObject != null && OctoRoomObject.GetComponent<MeshRenderer>() != null)
                    {
                        OctoRoomObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
            else
            {
                foreach (GameObject OctoRoomObject in OctoRoomObjects)
                {
                    if (OctoRoomObject != null && OctoRoomObject.GetComponent<MeshRenderer>() != null)
                    {
                        OctoRoomObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
            renderingChanged = true;
        }
	}
}
