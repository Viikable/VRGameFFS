using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    public static bool waterRises;
	// Use this for initialization
	void Start () {
        waterRises = false;
	}
    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");
        
    }

    public bool WaterRises
    {
        get { return waterRises;  }

        set { waterRises = value;  }
    }
  
    // Update is called once per frame
    void Update () {
        if (waterRises)
        {
            this.transform.Translate(Vector3.up * 0.005f);
        }
        
	}
}
