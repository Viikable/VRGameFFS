using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorBroomTransformer : MonoBehaviour {

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

    void Start ()
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
                    Bottom.GetComponent<MeshRenderer>().material = CharredBroom;
                    //Bottom.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //Bottom.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //Bottom.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "SixthPart":
                    SeventhPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FifthPart":
                    SixthPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FourthPart":
                    FifthPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "ThirdPart":
                    FourthPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "SecondPart":
                    ThirdPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FirstPart":
                    SecondPart.GetComponent<MeshRenderer>().material = CharredBroom;
                    //SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    //SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    //SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                default:
                    Debug.Log("Bottom or firstpart");
                    break;
            }
            //rend.material.SetTexture("_MainTex", CharredBroom);
            //rend.material.SetTexture("_BumpMap", CharredBroom);
            //rend.material.SetTexture("_MetallicGlossMap", CharredBroom);
            //changeBroomColour = false;
        }
    }
}
