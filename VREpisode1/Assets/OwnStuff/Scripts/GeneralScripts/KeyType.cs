using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyType : MonoBehaviour {

    public int clearanceLevel;

	
	void Start ()
    {
        if (gameObject.name == "FirstLevelKey")
        {
            clearanceLevel = 1;
        }
        else if (gameObject.name == "ThirdLevelKey")
        {
            clearanceLevel = 3;
        }
        else if (gameObject.name == "UnactivatedKey")
        {
            clearanceLevel = 0;
        }
    }
	
}
