using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManeger : MonoBehaviour {

    [SerializeField]
    private int gridSize = 1;

	// Use this for initialization
	void Start () {
        RectTransform rt = GetComponent<RectTransform>();

        rt.sizeDelta = new Vector2(gridSize, gridSize);
	}
	
	void Update () {
		
	}
}
