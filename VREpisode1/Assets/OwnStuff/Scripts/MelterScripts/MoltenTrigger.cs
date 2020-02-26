using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MoltenTrigger : MonoBehaviour
{

    public GameObject Pliers;
    VRTK_SnapDropZone PlierZone;

    private void Awake()
    {
        Pliers = GameObject.Find("Melter_Pliers1.1_opened");
        PlierZone = GameObject.Find("PliersSnapZone").GetComponent<VRTK_SnapDropZone>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JanitorBroom") && other.GetComponent<JanitorBroomTransformer>() != null)
        {           
            other.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider1" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("FirstPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider2" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("SecondPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider3" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("ThirdPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider4" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("FourthPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider5" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("FifthPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider6" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("SixthPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider7" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("SeventhPart").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
        if (other.name == "BroomCollider8" && PlierZone.GetCurrentSnappedObject().CompareTag("JanitorBroom"))
        {
            PlierZone.GetCurrentSnappedObject().transform.GetChild(0).transform.Find("Bottom").gameObject.GetComponent<JanitorBroomTransformer>().changeBroomColour = true;
        }
    }
}
