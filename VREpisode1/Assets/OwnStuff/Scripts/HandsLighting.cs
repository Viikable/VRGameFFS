using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsLighting : MonoBehaviour {
    GameObject LeftHandModel;
    GameObject RightHandModel;
    Material LeftHandMat;
    Material RightHandMat;
    public static bool insideObject;

    void Start () {
        LeftHandModel = GameObject.Find("LeftController").transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        RightHandModel = GameObject.Find("RightController").transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        LeftHandMat = LeftHandModel.GetComponent<SkinnedMeshRenderer>().material;
        RightHandMat = RightHandModel.GetComponent<SkinnedMeshRenderer>().material;
        LeftHandMat.EnableKeyword("_EMISSION");
        RightHandMat.EnableKeyword("_EMISSION");
        insideObject = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (insideObject)
        {
        LeftHandMat.SetColor("_EmissionColor", Color.green * 50f);
        RightHandMat.SetColor("_EmissionColor", Color.green * 50f);
        }
        else
        {
            LeftHandMat.SetColor("_EmissionColor", Color.green * -25f);
            RightHandMat.SetColor("_EmissionColor", Color.green * -25f);
        }
    }
}
