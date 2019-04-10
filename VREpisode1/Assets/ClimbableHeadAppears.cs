using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClimbableHeadAppears : MonoBehaviour {
    VRTK_SnapDropZone WallCrack;
    GameObject JuhaniMouthCollider;
    GameObject JuhaniHeadCollider1;
    GameObject JuhaniHeadCollider2;

    void Start () {
        WallCrack = GetComponent<VRTK_SnapDropZone>();
        JuhaniHeadCollider1 = GameObject.Find("JuhaniClimbableHeadCollider1");
        JuhaniHeadCollider2 = GameObject.Find("JuhaniClimbableHeadCollider2");
        JuhaniMouthCollider = GameObject.Find("JuhaniClimbableMouthCollider");
    }
	
	
	void Update () {
		if (WallCrack.GetCurrentSnappedObject() != null)
        {
            JuhaniHeadCollider1.GetComponent<Collider>().enabled = true;           
            JuhaniHeadCollider2.GetComponent<Collider>().enabled = true;            
            JuhaniMouthCollider.GetComponent<Collider>().enabled = true;
            GameObject.Find("JuhaniHeadClimbableMouth").GetComponent<MeshRenderer>().enabled = true;
            Destroy(WallCrack.GetCurrentSnappedObject());
        }
	}
}
