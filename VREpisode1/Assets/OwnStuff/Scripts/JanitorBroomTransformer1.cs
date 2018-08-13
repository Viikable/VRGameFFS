using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorBroomTransformer1 : MonoBehaviour {

    [Header("Textures for changing the broom into")]
    [Tooltip("Texture we will change the broom into")]
    public Texture2D CharredBroom;
    public static bool ChangeBroomColour1 = false;
    Renderer rend;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "PoolOfMoltenMetal")
    //    {
    //        Debug.Log("Did touch the lava");
    //        rend.material.SetTexture("_MainTex", CharredBroom);
    //        rend.material.SetTexture("_BumpMap", CharredBroom);
    //        rend.material.SetTexture("_MetallicGlossMap", CharredBroom);
    //    }
    //}
    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
        rend.material.EnableKeyword("_NORMALMAP");
        rend.material.EnableKeyword("_METALLICGLOSSMAP");
        
	}

    // Update is called once per frame
    void Update()
    {
        if (ChangeBroomColour1)
        {
            rend.material.SetTexture("_MainTex", CharredBroom);
            rend.material.SetTexture("_BumpMap", CharredBroom);
            rend.material.SetTexture("_MetallicGlossMap", CharredBroom);
            ChangeBroomColour1 = false;
        }
    }
}
