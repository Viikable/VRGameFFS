using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;



public class TalosSnap : MonoBehaviour
{
    VRTK_SnapDropZone TalosSnapZone;
    private int x;
    private int y;
    char X;
    char Y;
    static bool Green;
    static bool Red;
    static bool Yellow;
    bool stayTrue;
    public Material RedValid;
    public Material RedMat;
    public Material GreenValid;
    public Material GreenMat;
    AudioSource OneCorrect;
    AudioSource AllCorrect;

    //L-shape   
    static bool lShape;
    bool lShapeXOne;
    bool lShapeXOneOneY;
    bool lShapeXOneTwoY;
    bool lShapeXTwo;
    bool lShapeXTwoOneY;
    bool lShapeXTwoTwoY;
    bool lShapeXTwoOneNegY;
    bool lShapeXTwoTwoNegY;
    bool lShapeXTwoThreeNegY;   //to be added
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
    bool lShapeYTwoOneX;
    bool lShapeYTwoTwoX;
    bool lShapeYTwoThreeX;     //to be added
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
    static bool uShape;
    // U-shape ends

    //threerow shape
    static bool threeRow;
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

    void Start()
    {
        TalosSnapZone = GetComponent<VRTK_SnapDropZone>();
        X = name[13];
        Y = name[15];
        x = Convert.ToInt32(new string(X, 1));
        y = Convert.ToInt32(new string(Y, 1));
        currentLocation = ("TalosSnapZone" + x + "_" + y).ToString();
        Green = false;
        Red = false;
        Yellow = false;
        stayTrue = false;
        GreenMat = GameObject.Find("TalosCube_ThreeRow1").GetComponent<MeshRenderer>().material;
        RedMat = GameObject.Find("TalosCube_L_ShapePart1").GetComponent<MeshRenderer>().material;
        GreenValid = GameObject.Find("GreenValid").GetComponent<MeshRenderer>().material;
        RedValid = GameObject.Find("RedValid").GetComponent<MeshRenderer>().material;
        OneCorrect = GameObject.Find("OneCorrectSound").GetComponent<AudioSource>();
        AllCorrect = GameObject.Find("AllCorrectSound").GetComponent<AudioSource>();

        //L-Shape starts
        lShape = false;
        lShapeXOne = false;
        lShapeXOneOneY = false;
        lShapeXOneTwoY = false;
        lShapeXTwo = false;
        lShapeXTwoOneY = false;
        lShapeXTwoTwoY = false;
        lShapeXTwoOneNegY = false;
        lShapeXTwoTwoNegY = false;
        lShapeXTwoThreeNegY = false;
        lShapeXThree = false;
        lShapeXThreeOneY = false;
        lShapeXThreeTwoY = false;
        lShapeXNegOne = false;
        lShapeXNegOneOneNegY = false;
        lShapeXNegOneTwoNegY = false;
        lShapeXNegTwo = false;
        lShapeXNegTwoOneNegY = false;
        lShapeXNegTwoTwoNegY = false;
        lShapeXNegThree = false;
        lShapeXNegThreeOneNegY = false;
        lShapeXNegThreeTwoNegY = false;
        lShapeYOne = false;                     //L-shape cannot be turned around
        lShapeYOneOneNegX = false;
        lShapeYOneTwoNegX = false;
        lShapeYTwo = false;
        lShapeYTwoOneX = false;
        lShapeYTwoTwoX = false;
        lShapeYTwoThreeX = false;
        lShapeYTwoOneNegX = false;
        lShapeYTwoTwoNegX = false;
        lShapeYThree = false;
        lShapeYThreeOneNegX = false;
        lShapeYThreeTwoNegX = false;
        lShapeYNegOne = false;
        lShapeYNegOneOneX = false;
        lShapeYNegOneTwoX = false;
        lShapeYNegTwo = false;
        lShapeYNegTwoOneX = false;
        lShapeYNegTwoTwoX = false;
        lShapeYNegThree = false;
        lShapeYNegThreeOneX = false;
        lShapeYNegThreeTwoX = false;
        // L_shape ends


        //U-shape
        uShape = false;
        // U-shape ends

        //threerow shape
        threeRow = false;
        threeRowXOne = false;
        threeRowXNegOne = false;
        threeRowXTwo = false;
        threeRowXNegTwo = false;
        threeRowYOne = false;
        threeRowYNegOne = false;
        threeRowYTwo = false;
        threeRowYNegTwo = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptGreen>() != null)
        {
            Green = true;
        }

        if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptRed>() != null)
        {
            Red = true;

        }
        if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptYellow>() != null)
        {
            Yellow = true;
        }
    }

    private void Update()
    {
        //Checkpart
        if ((threeRowXOne && threeRowXNegOne) || (threeRowXOne && threeRowXTwo) || (threeRowXNegOne && threeRowXNegTwo)
            || (threeRowYOne && threeRowYNegOne) || (threeRowYOne && threeRowYTwo) || (threeRowYNegOne && threeRowYNegTwo))
        {
            threeRow = true;
            if (!OneCorrect.isPlaying && Green && !lShape)
            {
                OneCorrect.Play();
                Green = false;
            }
            Debug.Log("threerow");
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null)
        {
            threeRow = false;
            Debug.Log("nothreerow");
        }

        if ((lShapeXOne && lShapeXTwo && lShapeXThree && ((lShapeXThreeOneY && lShapeXThreeTwoY) || (lShapeYNegOne && lShapeYNegTwo)))
            || (lShapeXNegOne && lShapeXNegTwo && lShapeXNegThree && ((lShapeXNegThreeOneNegY && lShapeXNegThreeTwoNegY) || (lShapeYOne && lShapeYTwo)))
            || (lShapeXOne && lShapeXTwo && lShapeXNegOne && ((lShapeXTwoOneY && lShapeXTwoTwoY) || (lShapeXNegOneOneNegY && lShapeXNegOneTwoNegY)))
                || (lShapeXOne && lShapeXNegTwo && lShapeXNegOne && ((lShapeXNegTwoOneNegY && lShapeXNegTwoTwoNegY) || (lShapeXOneOneY && lShapeXOneTwoY)))
                || (lShapeXOne && lShapeXTwo && ((lShapeXTwoOneNegY && lShapeXTwoTwoNegY && lShapeXTwoThreeNegY) || (lShapeYOne && lShapeYTwo && lShapeYThree))))
        {
            lShape = true;
            if (!OneCorrect.isPlaying && Red && !threeRow)
            {
                OneCorrect.Play();
                Red = false;
            }
            Debug.Log("truered");
        }
        else if ((lShapeYOne && lShapeYTwo && lShapeYThree && ((lShapeYThreeOneNegX && lShapeYThreeTwoNegX) || (lShapeXOne && lShapeXTwo)))
                || (lShapeYNegOne && lShapeYNegTwo && lShapeYNegThree && ((lShapeYNegThreeOneX && lShapeYNegThreeTwoX) || (lShapeXNegOne && lShapeXNegTwo)))
                || (lShapeYOne && lShapeYTwo && lShapeYNegOne && ((lShapeYTwoOneNegX && lShapeYTwoTwoNegX) || (lShapeYNegOneOneX && lShapeYNegOneTwoX)))
                || (lShapeYOne && lShapeYNegTwo && lShapeYNegOne && ((lShapeYNegTwoOneX && lShapeYNegTwoTwoX) || (lShapeYOneOneNegX && lShapeYOneTwoNegX)))
                || (lShapeYOne && lShapeYTwo && ((lShapeYTwoOneX && lShapeYTwoTwoX && lShapeYTwoThreeX) || (lShapeXNegOne && lShapeXNegTwo && lShapeXNegThree))))
        {
            lShape = true;
            if (!OneCorrect.isPlaying && Red && !threeRow)
            {
                OneCorrect.Play();
                Red = false;
            }
            Debug.Log("truered");
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null)
        {
            lShape = false;
            Debug.Log("nored");
        }
        if (threeRow && lShape && !AllCorrect.isPlaying && (Red || Green))
        {
            AllCorrect.Play();
            Red = false;
            Green = false;
            Debug.Log("allcorrect");
        }
        if (threeRow)
        {
            GameObject.Find("TalosCube_ThreeRow1").GetComponent<MeshRenderer>().material = GreenValid;
            GameObject.Find("TalosCube_ThreeRow2").GetComponent<MeshRenderer>().material = GreenValid;
            GameObject.Find("TalosCube_ThreeRow3").GetComponent<MeshRenderer>().material = GreenValid;
            Debug.Log("greenvalid");
        }
        else
        {
            GameObject.Find("TalosCube_ThreeRow1").GetComponent<MeshRenderer>().material = GreenMat;
            GameObject.Find("TalosCube_ThreeRow2").GetComponent<MeshRenderer>().material = GreenMat;
            GameObject.Find("TalosCube_ThreeRow3").GetComponent<MeshRenderer>().material = GreenMat;
            Debug.Log("greeninvalid");
        }
        if (lShape)
        {
            GameObject.Find("TalosCube_L_ShapePart1").GetComponent<MeshRenderer>().material = RedValid;
            GameObject.Find("TalosCube_L_ShapePart2").GetComponent<MeshRenderer>().material = RedValid;
            GameObject.Find("TalosCube_L_ShapePart3").GetComponent<MeshRenderer>().material = RedValid;
            GameObject.Find("TalosCube_L_ShapePart4").GetComponent<MeshRenderer>().material = RedValid;
            GameObject.Find("TalosCube_L_ShapePart5").GetComponent<MeshRenderer>().material = RedValid;
            GameObject.Find("TalosCube_L_ShapePart6").GetComponent<MeshRenderer>().material = RedValid;
        }
        else
        {
            GameObject.Find("TalosCube_L_ShapePart1").GetComponent<MeshRenderer>().material = RedMat;
            GameObject.Find("TalosCube_L_ShapePart2").GetComponent<MeshRenderer>().material = RedMat;
            GameObject.Find("TalosCube_L_ShapePart3").GetComponent<MeshRenderer>().material = RedMat;
            GameObject.Find("TalosCube_L_ShapePart4").GetComponent<MeshRenderer>().material = RedMat;
            GameObject.Find("TalosCube_L_ShapePart5").GetComponent<MeshRenderer>().material = RedMat;
            GameObject.Find("TalosCube_L_ShapePart6").GetComponent<MeshRenderer>().material = RedMat;
        }
        //if (Green)
        //{
        if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null)
        {

            //Green = false;
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
        //}
        //if (Red)
        //{
        if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null)
        {
            //Red = false;
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

            lShapeXTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
              && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x + 2) <= 4) && ((y - 1) >= 1);

            lShapeXTwoTwoNegY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
              && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((x + 2) <= 4) && ((y - 2) >= 1);

            lShapeXTwoThreeNegY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()) != null &&
             GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()).
             GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
             && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((x + 2) <= 4) && ((y - 3) >= 1);

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

            lShapeXThreeTwoY = GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()) != null &&
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

            lShapeYTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y + 2) <= 5) && ((x + 1) <= 5);

            lShapeYTwoTwoX = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()) != null &&
             GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()).
             GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
             GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 2)).ToString()).
             GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
             && ((y + 2) <= 5) && ((x + 2) <= 5);

            lShapeYTwoThreeX = GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()) != null &&
             GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()).
             GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
             GameObject.Find(("TalosSnapZone" + (x + 3) + "_" + (y + 2)).ToString()).
             GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
             && ((y + 2) <= 5) && ((x + 3) <= 5);

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

            lShapeYNegTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()) != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
                && ((y - 2) >= 1) && ((x + 1) <= 4);

            lShapeYNegTwoTwoX = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 2)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y - 2) >= 1) && ((x + 2) <= 4);

            lShapeYThree = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y + 3) <= 5);

            lShapeYThreeOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 3)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y + 3) <= 5) && ((x - 1) >= 1);

            lShapeYThreeTwoNegX = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 3)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y + 3) <= 5) && ((x - 2) >= 1);

            lShapeYNegThree = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()) != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
               GameObject.Find(("TalosSnapZone" + x + "_" + (y - 3)).ToString()).
               GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
               && ((y - 3) <= 5);

            lShapeYNegThreeOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 3)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y - 3) <= 5) && ((x + 1) <= 4);

            lShapeYNegThreeTwoX = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()) != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
              GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 3)).ToString()).
              GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null
              && ((y - 3) <= 5) && ((x + 2) <= 4);
        }
    }
}
    
   
