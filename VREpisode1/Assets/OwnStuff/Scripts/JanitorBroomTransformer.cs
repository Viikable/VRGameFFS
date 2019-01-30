using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorBroomTransformer : MonoBehaviour {

    [Header("Textures for changing the broom into")]
    [Tooltip("Texture we will change the broom into")]
    public Texture2D CharredBroom;
    public bool changeBroomColour;
    Renderer rend;
    GameObject Bottom;
    GameObject FirstPart;
    GameObject SecondPart;
    GameObject ThirdPart;
    GameObject FourthPart;
    GameObject FifthPart;
    GameObject SixthPart;
    GameObject SeventhPart;

    void Start () {
        rend = GetComponent<MeshRenderer>();
        //rend.material.EnableKeyword("_NORMALMAP");
        //rend.material.EnableKeyword("_METALLICGLOSSMAP");
        changeBroomColour = false;
        Bottom = GameObject.Find("Bottom");
        FirstPart = GameObject.Find("FirstPart");
        SecondPart = GameObject.Find("SecondPart");
        ThirdPart = GameObject.Find("ThirdPart");
        FourthPart = GameObject.Find("FourthPart");
        FifthPart = GameObject.Find("FifthPart");
        SixthPart = GameObject.Find("SixthPart");
        SeventhPart = GameObject.Find("SeventhPart");
    }

    // Update is called once per frame
    void Update()
    {
        if (changeBroomColour)
        {
            switch (name)
            {
                case "SeventhPart":
                    Bottom.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    Bottom.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    Bottom.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "SixthPart":
                    SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    SeventhPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FifthPart":
                    SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    SixthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FourthPart":
                    FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    FifthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "ThirdPart":
                    FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    FourthPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "SecondPart":
                    ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    ThirdPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                case "FirstPart":
                    SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", CharredBroom);
                    SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", CharredBroom);
                    SecondPart.GetComponent<MeshRenderer>().material.SetTexture("_MetallicGlossMap", CharredBroom);
                    break;
                default:
                    Debug.Log("Bottom or firstpart");
                    break;
            }
            //rend.material.SetTexture("_MainTex", CharredBroom);
            //rend.material.SetTexture("_BumpMap", CharredBroom);
            //rend.material.SetTexture("_MetallicGlossMap", CharredBroom);
            changeBroomColour = false;
        }
    }
}
