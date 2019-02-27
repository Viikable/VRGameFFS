using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;



public class TalosSnap : MonoBehaviour {
    VRTK_SnapDropZone TalosSnapZone;
    private int x;
    private int y;
    char X;
    char Y;
    bool threeRow;
    bool lShape;
    bool uShape;
    bool threeRowXOne;
    bool threeRowXNegOne;
    bool threeRowXTwo;
    bool threeRowXNegTwo;
    bool threeRowYOne;
    bool threeRowYNegOne;
    bool threeRowYTwo;
    bool threeRowYNegTwo;
    private string currentLocation;  //location in puzzle grid in x and y coordinates

    void Start () {
        TalosSnapZone = GetComponent<VRTK_SnapDropZone>();
        X = name[13];
        Y = name[15];        
        x = Convert.ToInt32(new string(X, 1));
        y = Convert.ToInt32(new string(Y, 1));
        currentLocation = ("TalosSnapZone" + x + "_" + y).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptRed>() != null)
        {
            
        }
        if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptYellow>() != null)
        {
            
        }       
    }
    private void Update()
    {
        if ((threeRowXOne && threeRowXNegOne) || (threeRowXOne && threeRowXTwo) || (threeRowXNegOne && threeRowXNegTwo)
            || (threeRowYOne && threeRowYNegOne) || (threeRowYOne && threeRowYTwo) || (threeRowYNegOne && threeRowYNegTwo))
        {
            threeRow = true;
            Debug.Log("yee");
        }    
        else
        {
            threeRow = false;
        }
        if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null)
        {
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            threeRowXOne = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1 )+ "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null 
                && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((x + 1) <= 4);
            
            threeRowXNegOne = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null 
                && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((x - 1) >= 1);

            threeRowXTwo = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null 
               && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((x + 2) <= 4);

            threeRowXNegTwo = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null 
                && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((x - 2) >= 1);
            //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
            threeRowYOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null 
                && ((y + 1) <= 4);

            threeRowYNegOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((y - 1) >= 1);

            threeRowYTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null && ((y + 2) <= 4);

            threeRowYNegTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null && ((y - 2) >= 1);                       
        }
    }
}
