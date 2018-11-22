using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < GetComponent<Transform>().childCount; i++) {
            GameObject childObject = GetComponent<Transform>().GetChild(i).gameObject;
            Debug.Log(childObject.name);
            Debug.Log(childObject.GetComponent<RectTransform>().localPosition);
        }


    }

    // Update is called once per frame
    void Update () {
	}
}
