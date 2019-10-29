using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackFunctionality : MonoBehaviour {
    public BoxCollider backpack;
	
	void Start ()
    {
        backpack = gameObject.AddComponent<BoxCollider>();      
    }
		
	void Update ()
    {       
        backpack.size.Set(0.4651778f, 0.3159705f, 0.2534145f);
        backpack.center.Set(-0.004954896f, -0.08685094f, -0.02765928f);
        Debug.Log(backpack.size.x.ToString());
        Debug.Log("wat");
    }
}
