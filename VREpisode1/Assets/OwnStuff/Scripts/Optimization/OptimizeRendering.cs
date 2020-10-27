using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeRendering : MonoBehaviour
{

    [Tooltip("If inside melter then doesn't render other areas")]
    public static bool insideMelterArea;

    [Tooltip("If inside MainHall then doesn't render other areas")]
    public static bool insideMainHall;

    [Tooltip("If inside Shafts then doesn't render other areas")]
    public static bool insideShafts;

    [Tooltip("If inside OctoRoom then doesn't render other areas")]
    public static bool insideOctoRoom;

    [Tooltip("If inside OctoRoom then doesn't render other areas")]
    public static bool insideBonsaiRoom;

    public static GameObject[] MelterObjects = new GameObject[500];

    public static GameObject[] MainHallObjects = new GameObject[500];

    public static GameObject[] ShaftsObjects = new GameObject[500];

    public static GameObject[] OctoRoomObjects = new GameObject[500];

    public static GameObject[] BonsaiRoomObjects = new GameObject[500];

    public static bool renderingChanged;

    int counter;

    // Use this for initialization
    void Awake()
    {
        insideMelterArea = false;
        insideMainHall = false;       //we start here
        insideShafts = false;
        insideOctoRoom = true;
        renderingChanged = false;
        insideBonsaiRoom = false;
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
        counter = 0;
        foreach (BonsaiRoomObject scriptObject in GameObject.FindObjectsOfType<BonsaiRoomObject>())
        {
            BonsaiRoomObjects[counter] = scriptObject.gameObject;
            counter++;
        }
    }

    void Update()
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

                        //if (melterObject.GetComponent<Collider>() != null)
                        //{
                        //    melterObject.GetComponent<Collider>().enabled = true;
                        //}
                        //if (melterObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in melterObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = true;
                        //    }
                        //}
                        //after colliders are on, turn the rigidbody on as well
                        //if (melterObject.GetComponent<MeshCollider>() != null && melterObject.GetComponent<MeshCollider>().convex
                        //        || melterObject.GetComponent<MeshCollider>() == null)
                        //{
                        //    if (melterObject.GetComponent<Rigidbody>() != null)
                        //    {
                        //        melterObject.GetComponent<Rigidbody>().isKinematic = false;
                        //    }
                        //}
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
                        //Kinematic so that the object wont move from its location while not having a collider
                        //    if (melterObject.GetComponent<Rigidbody>() != null)
                        //    {
                        //        Debug.Log("melterKinematics");
                        //        melterObject.GetComponent<Rigidbody>().isKinematic = true;
                        //    }
                        //    if (melterObject.GetComponent<Collider>() != null)
                        //    {
                        //        melterObject.GetComponent<Collider>().enabled = false;
                        //    }
                        //    if (melterObject.GetComponentsInChildren<Collider>() != null)
                        //    {
                        //        foreach (Collider childCollider in melterObject.GetComponentsInChildren<Collider>())
                        //        {
                        //            childCollider.enabled = false;
                        //        }
                        //    }
                        //}
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

                        //if (MainHallObject.GetComponent<Collider>() != null)
                        //{
                        //    MainHallObject.GetComponent<Collider>().enabled = true;
                        //}
                        //if (MainHallObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in MainHallObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = true;
                        //    }
                        //}
                        //if (MainHallObject.GetComponent<MeshCollider>() != null && MainHallObject.GetComponent<MeshCollider>().convex
                        //        || MainHallObject.GetComponent<MeshCollider>() == null)
                        //{
                        //    if (MainHallObject.GetComponent<Rigidbody>() != null)
                        //    {
                        //        MainHallObject.GetComponent<Rigidbody>().isKinematic = false;
                        //    }
                        //}
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
                        //Kinematic so that the object wont move from its location while not rendering collider or mesh renderer
                        //    if (MainHallObject.GetComponent<Rigidbody>() != null)
                        //    {
                        //        MainHallObject.GetComponent<Rigidbody>().isKinematic = true;
                        //    }

                        //    if (MainHallObject.GetComponent<Collider>() != null)
                        //    {
                        //        MainHallObject.GetComponent<Collider>().enabled = false;
                        //    }
                        //    if (MainHallObject.GetComponentsInChildren<Collider>() != null)
                        //    {
                        //        foreach (Collider childCollider in MainHallObject.GetComponentsInChildren<Collider>())
                        //        {
                        //            childCollider.enabled = false;
                        //        }
                        //    }
                        //}
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

                        //if (ShaftsObject.GetComponent<Collider>() != null)
                        //{
                        //    ShaftsObject.GetComponent<Collider>().enabled = true;
                        //}
                        //if (ShaftsObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in ShaftsObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = true;
                        //    }
                        //}
                        //if (ShaftsObject.GetComponent<MeshCollider>() != null && ShaftsObject.GetComponent<MeshCollider>().convex
                        //        || ShaftsObject.GetComponent<MeshCollider>() == null)
                        //{
                        //    if (ShaftsObject.GetComponent<Rigidbody>() != null)
                        //    {
                        //        ShaftsObject.GetComponent<Rigidbody>().isKinematic = false;
                        //    }
                        //}
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
                        //if (ShaftsObject.GetComponent<Rigidbody>() != null)
                        //{
                        //    ShaftsObject.GetComponent<Rigidbody>().isKinematic = true;
                        //}

                        //if (ShaftsObject.GetComponent<Collider>() != null)
                        //{
                        //    ShaftsObject.GetComponent<Collider>().enabled = false;
                        //}
                        //if (ShaftsObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in ShaftsObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = false;
                        //    }
                        //}
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

                        //if (OctoRoomObject.GetComponent<Collider>() != null)
                        //{
                        //    OctoRoomObject.GetComponent<Collider>().enabled = true;
                        //}
                        //if (OctoRoomObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in OctoRoomObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = true;
                        //    }
                        //}
                        //if (OctoRoomObject.GetComponent<Rigidbody>() != null)
                        //{
                        //    if (OctoRoomObject.GetComponent<MeshCollider>() != null && OctoRoomObject.GetComponent<MeshCollider>().convex
                        //        || OctoRoomObject.GetComponent<MeshCollider>() == null)
                        //    {
                        //        if (OctoRoomObject.GetComponent<Rigidbody>() != null)
                        //        {
                        //            OctoRoomObject.GetComponent<Rigidbody>().isKinematic = false;
                        //        }
                        //    }                                
                        //}
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

                        //if (OctoRoomObject.GetComponent<Rigidbody>() != null)
                        //{
                        //    OctoRoomObject.GetComponent<Rigidbody>().isKinematic = true;
                        //}
                        //if (OctoRoomObject.GetComponent<Collider>() != null)
                        //{
                        //    OctoRoomObject.GetComponent<Collider>().enabled = false;
                        //}
                        //if (OctoRoomObject.GetComponentsInChildren<Collider>() != null)
                        //{
                        //    foreach (Collider childCollider in OctoRoomObject.GetComponentsInChildren<Collider>())
                        //    {
                        //        childCollider.enabled = false;
                        //    }
                        //}
                    }
                }
            }
            if (insideBonsaiRoom)
            {
                foreach (GameObject BonsaiRoomObject in BonsaiRoomObjects)
                {
                    if (BonsaiRoomObject != null && BonsaiRoomObject.GetComponent<MeshRenderer>() != null)
                    {
                        BonsaiRoomObject.GetComponent<MeshRenderer>().enabled = true;                       
                    }
                }
            }
            else
            {
                foreach (GameObject BonsaiRoomObject in BonsaiRoomObjects)
                {
                    if (BonsaiRoomObject != null && BonsaiRoomObject.GetComponent<MeshRenderer>() != null)
                    {
                        BonsaiRoomObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
            renderingChanged = true;
        }
    }
}

