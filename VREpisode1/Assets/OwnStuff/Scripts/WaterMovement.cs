using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
<<<<<<< HEAD
    public static bool WaterRises;
	// Use this for initialization
	void Start () {
        WaterRises = false;
=======
    [SerializeField]
    [Tooltip("Is the water rising right now")]
    private bool waterRises;

	void Start () {
        waterRises = false;
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061
	}
    public void TouchedLantern()
    {
        Debug.Log("Lantern is touched, let the waters rise!");
        
    }
<<<<<<< HEAD
	// Update is called once per frame
	void Update () {
        if (WaterRises)
        {
            this.transform.Translate(Vector3.up * 0.005f);
=======

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
            Debug.Log("waterdown");
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061
        }
        
	}
}
