using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    public static bool WaterRises;
	// Use this for initialization
	void Start () {
        WaterRises = false;
	}
    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");
        
    }
  
    // Update is called once per frame
    void Update () {
        if (WaterRises)
        {
            this.transform.Translate(Vector3.up * 0.005f);
        }
        
	}
}
