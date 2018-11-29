using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;

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
        if (WaterRises)
        {
            this.transform.Translate(Vector3.up * 0.005f);
            Debug.Log("waterup");
        }
        else
        {
            this.transform.Translate(Vector3.up * 0f);
            //Debug.Log("waterdown");
        }
        
	}
}
