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
    //L-shape
    bool lShape;
    bool lShapeXOne;
    bool lShapeXOneOneY;
    bool lShapeXOneTwoY;
    bool lShapeXTwo;
    bool lShapeXTwoOneY;
    bool lShapeXTwoTwoY;
    bool lShapeXThree;
    bool lShapeXThreeOneY;
    bool lShapeXThreeTwoY;
    bool lShapeXNegOne;
    bool lShapeXNegOneOneNegY;
    bool lShapeXNegOneTwoNegY;
    bool lShapeXNegTwo;
    bool lShapeXNegTwoOneNegY;
    bool lShapeXNegTwoTwoNegY;
    bool lShapeXNegThree;
    bool lShapeXNegThreeOneNegY;
    bool lShapeXNegThreeTwoNegY;
    bool lShapeYOne;                     //L-shape cannot be turned around
    bool lShapeYOneOneNegX;
    bool lShapeYOneTwoNegX;
    bool lShapeYTwo;
    bool lShapeYTwoOneNegX;
    bool lShapeYTwoTwoNegX;
    bool lShapeYThree;
    bool lShapeYThreeOneNegX;
    bool lShapeYThreeTwoNegX;
    bool lShapeYNegOne;
    bool lShapeYNegOneOneX;
    bool lShapeYNegOneTwoX;
    bool lShapeYNegTwo;
    bool lShapeYNegTwoOneX;
    bool lShapeYNegTwoTwoX;
    bool lShapeYNegThree;
    bool lShapeYNegThreeOneX;
    bool lShapeYNegThreeTwoX;
    // L_shape ends


        //U-shape
    bool uShape;
    // U-shape ends

    //threerow shape
    bool threeRow;
    bool threeRowXOne;
    bool threeRowXNegOne;
    bool threeRowXTwo;
    bool threeRowXNegTwo;
    bool threeRowYOne;
    bool threeRowYNegOne;
    bool threeRowYTwo;
    bool threeRowYNegTwo;
    //threerow Shape ends
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

        if ((lShapeXOne && lShapeXTwo && lShapeXThree &&) || )

        if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null)
        {
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX     x and y are actually not in logical positions in the puzzle
            threeRowXOne = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
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
                && ((y + 1) <= 5);

            threeRowYNegOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((y - 1) >= 1);

            threeRowYTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
               && ((y + 2) <= 5);

            threeRowYNegTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null
                && ((y - 2) >= 1);
        }
        if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null)
        {
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            lShapeXOne = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 1) <= 4);

            lShapeXOneOneY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 1) <= 4) && ((y + 1) <= 5);

            lShapeXOneTwoY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 1) <= 4) && ((y + 2) <= 5);

            lShapeXNegOne = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 1) >= 1);

            lShapeXNegOneOneNegY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 1) >= 1) && ((y - 1) >= 1);

            lShapeXNegOneTwoNegY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 1) >= 1) && ((y - 2) >= 1);

            lShapeXTwo = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 2) <= 4);

            lShapeXTwoOneY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
              && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x + 2) <= 4) && ((y + 1) <= 5);

            lShapeXTwoTwoY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
              && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x + 2) <= 4) && ((y + 2) <= 5);

            lShapeXNegTwo = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 2) >= 1);

            lShapeXNegTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x - 2) >= 1) && ((y - 1) >= 1);

            lShapeXNegTwoTwoNegY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x - 2) >= 1) && ((y - 2) >= 1);

            lShapeXThree = GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + y).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + y).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 3) <= 4);

            lShapeXThreeOneY = GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 1)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 3) <= 4) && ((y + 1) <= 5);

            lShapeXThreeOneY = GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x + 3) <= 4) && ((y + 2) <= 5);

            lShapeXNegThree = GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + y).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + y).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + y).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 3) >= 1);

            lShapeXNegThreeOneNegY = GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 1)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 3) >= 1) && ((y - 1) >= 1);

            lShapeXNegThreeTwoNegY = GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x - 3) + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((x - 3) >= 1) && ((y - 2) >= 1);
           
            //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
            lShapeYOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y + 1) <= 5);

            lShapeYOneOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y + 1) <= 5) && ((x - 1) >= 1);

            lShapeYOneTwoNegX = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y + 1) <= 5) && ((x - 2) >= 1);

            lShapeYNegOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                && GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y - 1) >= 1);

            lShapeYNegOneOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y - 1) >= 1) && ((x + 1) <= 4);

            lShapeYNegOneTwoX = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
               && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y - 1) >= 1) && ((x + 2) <= 4);

            lShapeYTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y + 2) <= 5);

            lShapeYTwoOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y + 2) <= 5) && ((x - 1) >= 1);

            lShapeYTwoTwoNegX = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 2)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y + 2) <= 5) && ((x - 2) >= 1);

            lShapeYNegTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y - 2) >= 1);

            lShapeYThree = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y + 3) <= 5);

            lShapeYNegThree = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y - 3) <= 5);
        }
    }
}
