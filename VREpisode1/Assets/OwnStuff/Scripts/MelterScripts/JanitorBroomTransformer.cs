using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class JanitorBroomTransformer : MonoBehaviour
{

    [Header("Textures for changing the broom into")]
    [Tooltip("Texture we will change the broom into")]
    public Material CharredBroom;
    public bool changeBroomColour;
    Renderer rend;   
    public GameObject Bottom;
    public GameObject FirstPart;
    public GameObject SecondPart;
    public GameObject ThirdPart;
    public GameObject FourthPart;
    public GameObject FifthPart;
    public GameObject SixthPart;
    public GameObject SeventhPart;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        //rend.material.EnableKeyword("_NORMALMAP");
        //rend.material.EnableKeyword("_METALLICGLOSSMAP");
        changeBroomColour = false;
        Bottom = transform.parent.Find("Bottom").gameObject;
        FirstPart = transform.parent.Find("FirstPart").gameObject;
        SecondPart = transform.parent.Find("SecondPart").gameObject;
        ThirdPart = transform.parent.Find("ThirdPart").gameObject;
        FourthPart = transform.parent.Find("FourthPart").gameObject;
        FifthPart = transform.parent.Find("FifthPart").gameObject;
        SixthPart = transform.parent.Find("SixthPart").gameObject;
        SeventhPart = transform.parent.Find("SeventhPart").gameObject;      
    }

    // Update is called once per frame
    void Update()
    {
        if (changeBroomColour)
        {
            switch (name)
            {
                case "SeventhPart":
                    Bottom.GetComponent<MeshRenderer>().material = Bottom.GetComponent<JanitorBroomTransformer>().CharredBroom;
                   
                    break;
                case "SixthPart":
                    SeventhPart.GetComponent<MeshRenderer>().material = SeventhPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                    
                    break;
                case "FifthPart":
                    SixthPart.GetComponent<MeshRenderer>().material = SixthPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                   
                    break;
                case "FourthPart":
                    FifthPart.GetComponent<MeshRenderer>().material = FifthPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                   
                    break;
                case "ThirdPart":
                    FourthPart.GetComponent<MeshRenderer>().material = FourthPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                   
                    break;
                case "SecondPart":
                    ThirdPart.GetComponent<MeshRenderer>().material = ThirdPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                    
                    break;
                case "FirstPart":
                    SecondPart.GetComponent<MeshRenderer>().material = SecondPart.GetComponent<JanitorBroomTransformer>().CharredBroom;
                    FirstPart.GetComponent<MeshRenderer>().material = FirstPart.GetComponent<JanitorBroomTransformer>().CharredBroom;      //looks a bit awkward sometimes
                    break;
                default:                   
                    break;
            }            
        }
    }    
}
