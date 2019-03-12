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
    static bool Blue;
    bool stayTrue;
    public Material RedValid;
    public Material RedMat;
    public Material GreenValid;
    public Material GreenMat;
    public Material YellowMat;
    public Material YellowValid;
    public Material BlueMat;
    public Material BlueValid;
    AudioSource OneCorrect;
    AudioSource AllCorrect;
    GameObject ThreeRow1;
    GameObject ThreeRow2;
    GameObject ThreeRow3;

    GameObject LShape1;
    GameObject LShape2;
    GameObject LShape3;
    GameObject LShape4;
    GameObject LShape5;
    GameObject LShape6;

    GameObject uShape1;
    GameObject uShape2;
    GameObject uShape3;
    GameObject uShape4;
    GameObject uShape5;

    GameObject squarePlus1;
    GameObject squarePlus2;
    GameObject squarePlus3;
    GameObject squarePlus4;
    GameObject squarePlus5;
    GameObject squarePlus6;

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
    bool uShapeXOne;
    bool uShapeXOneOneY;
    bool uShapeXOneOneNegY;
    bool uShapeXNegOne;
    bool uShapeXNegOneOneY;
    bool uShapeXNegOneOneNegY;
    bool uShapeXTwo;
    bool uShapeXTwoOneY;
    bool uShapeXTwoOneNegY;
    bool uShapeXNegTwo;
    bool uShapeXNegTwoOneY;
    bool uShapeXNegTwoOneNegY;
    bool uShapeYOne;
    bool uShapeYOneOneX;
    bool uShapeYOneOneNegX;
    bool uShapeYNegOne;
    bool uShapeYNegOneOneX;
    bool uShapeYNegOneOneNegX;
    bool uShapeYTwo;
    bool uShapeYTwoOneX;
    bool uShapeYTwoOneNegX;
    bool uShapeYNegTwo;
    bool uShapeYNegTwoOneX;
    bool uShapeYNegTwoOneNegX;
    // U-shape ends

    //SquarePlus-shape
    static bool squarePlus;
    bool squarePlusXOne;
    bool squarePlusXOneOneY;
    bool squarePlusXOneOneNegY;
    bool squarePlusXNegOne;
    bool squarePlusXNegOneOneY;
    bool squarePlusXNegOneOneNegY;
    bool squarePlusXTwo;
    bool squarePlusXTwoOneY;
    bool squarePlusXTwoOneNegY;
    bool squarePlusXNegTwo;
    bool squarePlusXNegTwoOneY;
    bool squarePlusXNegTwoOneNegY;
    bool squarePlusYOne;
    bool squarePlusYOneOneX;
    bool squarePlusYOneOneNegX;
    bool squarePlusYNegOne;
    bool squarePlusYNegOneOneX;
    bool squarePlusYNegOneOneNegX;
    bool squarePlusYTwo;
    bool squarePlusYTwoOneX;
    bool squarePlusYTwoOneNegX;
    bool squarePlusYNegTwo;
    bool squarePlusYNegTwoOneX;
    bool squarePlusYNegTwoOneNegX;   
    //SquarePlus-shape ends

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
        YellowMat = GameObject.Find("TalosCube_U_ShapedPiece1").GetComponent<MeshRenderer>().material;
        BlueMat = GameObject.Find("TalosCube_SquarePlusShape1").GetComponent<MeshRenderer>().material;
        GreenValid = GameObject.Find("GreenValid").GetComponent<MeshRenderer>().material;
        RedValid = GameObject.Find("RedValid").GetComponent<MeshRenderer>().material;
        YellowValid = GameObject.Find("YellowValid").GetComponent<MeshRenderer>().material;
        BlueValid = GameObject.Find("BlueValid").GetComponent<MeshRenderer>().material;
        OneCorrect = GameObject.Find("OneCorrectSound").GetComponent<AudioSource>();
        AllCorrect = GameObject.Find("AllCorrectSound").GetComponent<AudioSource>();
        ThreeRow1 = GameObject.Find("TalosCube_ThreeRow1");
        ThreeRow2 = GameObject.Find("TalosCube_ThreeRow2");
        ThreeRow3 = GameObject.Find("TalosCube_ThreeRow3");

        LShape1 = GameObject.Find("TalosCube_L_ShapePart1");
        LShape2 = GameObject.Find("TalosCube_L_ShapePart2");
        LShape3 = GameObject.Find("TalosCube_L_ShapePart3");
        LShape4 = GameObject.Find("TalosCube_L_ShapePart4");
        LShape5 = GameObject.Find("TalosCube_L_ShapePart5");
        LShape6 = GameObject.Find("TalosCube_L_ShapePart6");

        uShape1 = GameObject.Find("TalosCube_U_ShapedPiece1");
        uShape2 = GameObject.Find("TalosCube_U_ShapedPiece2");
        uShape3 = GameObject.Find("TalosCube_U_ShapedPiece3");
        uShape4 = GameObject.Find("TalosCube_U_ShapedPiece4");
        uShape5 = GameObject.Find("TalosCube_U_ShapedPiece5");

        squarePlus1 = GameObject.Find("TalosCube_SquarePlusShape1");
        squarePlus2 = GameObject.Find("TalosCube_SquarePlusShape2");
        squarePlus3 = GameObject.Find("TalosCube_SquarePlusShape3");
        squarePlus4 = GameObject.Find("TalosCube_SquarePlusShape4");
        squarePlus5 = GameObject.Find("TalosCube_SquarePlusShape5");
        squarePlus6 = GameObject.Find("TalosCube_SquarePlusShape6");

        //sqplus-shape
        squarePlus = false;
        squarePlusXOne = false;
        squarePlusXOneOneY = false;
        squarePlusXOneOneNegY = false;
        squarePlusXNegOne = false;
        squarePlusXNegOneOneY = false;
        squarePlusXNegOneOneNegY = false;
        squarePlusXTwo = false;
        squarePlusXTwoOneY = false;
        squarePlusXTwoOneNegY = false;
        squarePlusXNegTwo = false;
        squarePlusXNegTwoOneY = false;
        squarePlusXNegTwoOneNegY = false;
        squarePlusYOne = false;
        squarePlusYOneOneX = false;
        squarePlusYOneOneNegX = false;
        squarePlusYNegOne = false;
        squarePlusYNegOneOneX = false;
        squarePlusYNegOneOneNegX = false;
        squarePlusYTwo = false;
        squarePlusYTwoOneX = false;
        squarePlusYTwoOneNegX = false;
        squarePlusYNegTwo = false;
        squarePlusYNegTwoOneX = false;
        squarePlusYNegTwoOneNegX = false;
        //sqplusshape ends

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
        uShapeXOne = false;
        uShapeXOneOneY = false;
        uShapeXOneOneNegY = false;
        uShapeXNegOne = false;
        uShapeXNegOneOneY = false;
        uShapeXNegOneOneNegY = false;
        uShapeXTwo = false;
        uShapeXTwoOneY = false;
        uShapeXTwoOneNegY = false;
        uShapeXNegTwo = false;
        uShapeXNegTwoOneY = false;
        uShapeXNegTwoOneNegY = false;
        uShapeYOne = false;
        uShapeYOneOneX = false;
        uShapeYOneOneNegX = false;
        uShapeYNegOne = false;
        uShapeYNegOneOneX = false;
        uShapeYNegOneOneNegX = false;
        uShapeYTwo = false;
        uShapeYTwoOneX = false;
        uShapeYTwoOneNegX = false;
        uShapeYNegTwo = false;
        uShapeYNegTwoOneX = false;
        uShapeYNegTwoOneNegX = false;
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
        if (other.CompareTag("TalosCube") && other.GetComponent<TalosColourScriptBlue>() != null)
        {
            Blue = true;
        }
    }

    private void Update()
    {
        if (TalosSnapZone.GetCurrentSnappedObject() == null)
        {
            threeRowXOne = false;
            threeRowXNegOne = false;
            threeRowXTwo = false;
            threeRowXNegTwo = false;
            threeRowYOne = false;
            threeRowYNegOne = false;
            threeRowYTwo = false;
            threeRowYNegTwo = false;

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

            uShapeXOne = false;
            uShapeXOneOneY = false;
            uShapeXOneOneNegY = false;
            uShapeXNegOne = false;
            uShapeXNegOneOneY = false;
            uShapeXNegOneOneNegY = false;
            uShapeXTwo = false;
            uShapeXTwoOneY = false;
            uShapeXTwoOneNegY = false;
            uShapeXNegTwo = false;
            uShapeXNegTwoOneY = false;
            uShapeXNegTwoOneNegY = false;
            uShapeYOne = false;
            uShapeYOneOneX = false;
            uShapeYOneOneNegX = false;
            uShapeYNegOne = false;
            uShapeYNegOneOneX = false;
            uShapeYNegOneOneNegX = false;
            uShapeYTwo = false;
            uShapeYTwoOneX = false;
            uShapeYTwoOneNegX = false;
            uShapeYNegTwo = false;
            uShapeYNegTwoOneX = false;
            uShapeYNegTwoOneNegX = false;

            squarePlusXOne = false;
            squarePlusXOneOneY = false;
            squarePlusXOneOneNegY = false;
            squarePlusXNegOne = false;
            squarePlusXNegOneOneY = false;
            squarePlusXNegOneOneNegY = false;
            squarePlusXTwo = false;
            squarePlusXTwoOneY = false;
            squarePlusXTwoOneNegY = false;
            squarePlusXNegTwo = false;
            squarePlusXNegTwoOneY = false;
            squarePlusXNegTwoOneNegY = false;
            squarePlusYOne = false;
            squarePlusYOneOneX = false;
            squarePlusYOneOneNegX = false;
            squarePlusYNegOne = false;
            squarePlusYNegOneOneX = false;
            squarePlusYNegOneOneNegX = false;
            squarePlusYTwo = false;
            squarePlusYTwoOneX = false;
            squarePlusYTwoOneNegX = false;
            squarePlusYNegTwo = false;
            squarePlusYNegTwoOneX = false;
            squarePlusYNegTwoOneNegX = false;
        }
        CheckPiecePositions(); //checks are specific snapzones near the currently snapped object(s) vacant or not        //ORDER OF EXECUTION IS VERY IMPORTANT
        CheckCorrectPieceCombinations(); //checks whether the non-vacant snapzones form the required shapes
    }
    public void CheckCorrectPieceCombinations()
    {

        if (threeRow)
        {
            ThreeRow1.GetComponent<MeshRenderer>().material = GreenValid;
            ThreeRow2.GetComponent<MeshRenderer>().material = GreenValid;
            ThreeRow3.GetComponent<MeshRenderer>().material = GreenValid;            
        }
        else
        {
            ThreeRow1.GetComponent<MeshRenderer>().material = GreenMat;
            ThreeRow2.GetComponent<MeshRenderer>().material = GreenMat;
            ThreeRow3.GetComponent<MeshRenderer>().material = GreenMat;            
        }
        if (lShape)
        {
            LShape1.GetComponent<MeshRenderer>().material = RedValid;
            LShape2.GetComponent<MeshRenderer>().material = RedValid;
            LShape3.GetComponent<MeshRenderer>().material = RedValid;
            LShape4.GetComponent<MeshRenderer>().material = RedValid;
            LShape5.GetComponent<MeshRenderer>().material = RedValid;
            LShape6.GetComponent<MeshRenderer>().material = RedValid;
        }
        else
        {
            LShape1.GetComponent<MeshRenderer>().material = RedMat;
            LShape2.GetComponent<MeshRenderer>().material = RedMat;
            LShape3.GetComponent<MeshRenderer>().material = RedMat;
            LShape4.GetComponent<MeshRenderer>().material = RedMat;
            LShape5.GetComponent<MeshRenderer>().material = RedMat;
            LShape6.GetComponent<MeshRenderer>().material = RedMat;
        }
        if (uShape)
        {
            uShape1.GetComponent<MeshRenderer>().material = YellowValid;
            uShape2.GetComponent<MeshRenderer>().material = YellowValid;
            uShape3.GetComponent<MeshRenderer>().material = YellowValid;
            uShape4.GetComponent<MeshRenderer>().material = YellowValid;
            uShape5.GetComponent<MeshRenderer>().material = YellowValid;
        }
        else
        {
            uShape1.GetComponent<MeshRenderer>().material = YellowMat;
            uShape2.GetComponent<MeshRenderer>().material = YellowMat;
            uShape3.GetComponent<MeshRenderer>().material = YellowMat;
            uShape4.GetComponent<MeshRenderer>().material = YellowMat;
            uShape5.GetComponent<MeshRenderer>().material = YellowMat;
        }
        if (squarePlus)
        {
            squarePlus1.GetComponent<MeshRenderer>().material = BlueValid;
            squarePlus2.GetComponent<MeshRenderer>().material = BlueValid;
            squarePlus3.GetComponent<MeshRenderer>().material = BlueValid;
            squarePlus4.GetComponent<MeshRenderer>().material = BlueValid;
            squarePlus5.GetComponent<MeshRenderer>().material = BlueValid;
            squarePlus6.GetComponent<MeshRenderer>().material = BlueValid;
        }
        else
        {
            squarePlus1.GetComponent<MeshRenderer>().material = BlueMat;
            squarePlus2.GetComponent<MeshRenderer>().material = BlueMat;
            squarePlus3.GetComponent<MeshRenderer>().material = BlueMat;
            squarePlus4.GetComponent<MeshRenderer>().material = BlueMat;
            squarePlus5.GetComponent<MeshRenderer>().material = BlueMat;
            squarePlus6.GetComponent<MeshRenderer>().material = BlueMat;
        }

        //Checkpart
        if ((threeRowXOne && threeRowXNegOne) || (threeRowXOne && threeRowXTwo) || (threeRowXNegOne && threeRowXNegTwo)
            || (threeRowYOne && threeRowYNegOne) || (threeRowYOne && threeRowYTwo) || (threeRowYNegOne && threeRowYNegTwo))
        {
            threeRow = true;
            if (!OneCorrect.isPlaying && Green && !(lShape && uShape && squarePlus))
            {
                Debug.Log("greencorrect");
                Green = false;
                OneCorrect.Play();
            }
            Debug.Log("threerow");
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptGreen>() != null && Green)
        {
            threeRow = false;
           
        }

        if ((lShapeXOne && lShapeXTwo && lShapeXThree && ((lShapeXThreeOneY && lShapeXThreeTwoY) || (lShapeYNegOne && lShapeYNegTwo)))
            || (lShapeXNegOne && lShapeXNegTwo && lShapeXNegThree && ((lShapeXNegThreeOneNegY && lShapeXNegThreeTwoNegY) || (lShapeYOne && lShapeYTwo)))
            || (lShapeXOne && lShapeXTwo && lShapeXNegOne && ((lShapeXTwoOneY && lShapeXTwoTwoY) || (lShapeXNegOneOneNegY && lShapeXNegOneTwoNegY)))
                || (lShapeXOne && lShapeXNegTwo && lShapeXNegOne && ((lShapeXNegTwoOneNegY && lShapeXNegTwoTwoNegY) || (lShapeXOneOneY && lShapeXOneTwoY)))
                || (lShapeXOne && lShapeXTwo && ((lShapeXTwoOneNegY && lShapeXTwoTwoNegY && lShapeXTwoThreeNegY) || (lShapeYOne && lShapeYTwo && lShapeYThree)))
                || (lShapeYOne && lShapeYTwo && lShapeYThree && ((lShapeYThreeOneNegX && lShapeYThreeTwoNegX) || (lShapeXOne && lShapeXTwo)))
                || (lShapeYNegOne && lShapeYNegTwo && lShapeYNegThree && ((lShapeYNegThreeOneX && lShapeYNegThreeTwoX) || (lShapeXNegOne && lShapeXNegTwo)))
                || (lShapeYOne && lShapeYTwo && lShapeYNegOne && ((lShapeYTwoOneNegX && lShapeYTwoTwoNegX) || (lShapeYNegOneOneX && lShapeYNegOneTwoX)))
                || (lShapeYOne && lShapeYNegTwo && lShapeYNegOne && ((lShapeYNegTwoOneX && lShapeYNegTwoTwoX) || (lShapeYOneOneNegX && lShapeYOneTwoNegX)))
                || (lShapeYOne && lShapeYTwo && ((lShapeYTwoOneX && lShapeYTwoTwoX && lShapeYTwoThreeX) || (lShapeXNegOne && lShapeXNegTwo && lShapeXNegThree))))
        {
            lShape = true;
            if (!OneCorrect.isPlaying && Red && !(threeRow && uShape && squarePlus))
            {
                Debug.Log("redcorrect");
                Red = false;
                OneCorrect.Play();
            }
            Debug.Log("truered");
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptRed>() != null && Red)
        {
            lShape = false;          
        }
        if ((uShapeXOne && uShapeXNegOne && ((uShapeXOneOneY && uShapeXNegOneOneY) || (uShapeXOneOneNegY && uShapeXNegOneOneNegY)))
            || (uShapeXOne && uShapeXTwo && ((uShapeYOne && uShapeXTwoOneY) || (uShapeYNegOne && uShapeXTwoOneNegY)))
            || (uShapeXNegOne && uShapeXNegTwo && ((uShapeYOne && uShapeXNegTwoOneY) || (uShapeYNegOne && uShapeXNegTwoOneNegY)))
            || (uShapeXTwo && ((uShapeXTwoOneY && uShapeYOne & uShapeYOneOneX) || (uShapeXTwoOneNegY && uShapeYNegOne & uShapeYNegOneOneX)))
            || (uShapeXNegTwo && ((uShapeXNegTwoOneY && uShapeYOne & uShapeYOneOneX) || (uShapeXNegTwoOneNegY && uShapeYNegOne & uShapeYNegOneOneX)))
            || (uShapeYOne && uShapeYNegOne && ((uShapeYOneOneX && uShapeYNegOneOneX) || (uShapeYOneOneNegX && uShapeYNegOneOneNegX)))
            || (uShapeYOne && uShapeYTwo && ((uShapeXOne && uShapeYTwoOneX) || (uShapeXNegOne && uShapeYTwoOneNegX)))
            || (uShapeYNegOne && uShapeYNegTwo && ((uShapeXOne && uShapeYNegTwoOneX) || (uShapeXNegOne && uShapeYNegTwoOneNegX)))
            || (uShapeYTwo && ((uShapeYTwoOneX && uShapeXOne & uShapeXOneOneY) || (uShapeYTwoOneNegX && uShapeXNegOne & uShapeXNegOneOneY)))
            || (uShapeYNegTwo && ((uShapeYNegTwoOneX && uShapeXOne & uShapeXOneOneY) || (uShapeYNegTwoOneNegX && uShapeXNegOne & uShapeXNegOneOneY))))
        {
            Debug.Log("UShape");

            uShape = true;
            if (!OneCorrect.isPlaying && Yellow && !(threeRow && lShape && squarePlus))
            {
                Debug.Log("yellowcorrect");
                Yellow = false;
                OneCorrect.Play();
            }
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null && Yellow)
        {
            uShape = false;          
        }
        if ((squarePlusXOne && squarePlusXTwo && ((squarePlusYNegOne && squarePlusXOneOneNegY && squarePlusXOneOneY) || (squarePlusXOneOneNegY && squarePlusXOneOneY && squarePlusXTwoOneY)))
            || (squarePlusXNegOne && squarePlusXNegTwo && ((squarePlusYOne && squarePlusXNegOneOneNegY && squarePlusXNegOneOneY) || (squarePlusXNegOneOneNegY && squarePlusXNegOneOneY && squarePlusXNegTwoOneNegY)))
            || (squarePlusXOne && squarePlusXNegOne && ((squarePlusYOne && squarePlusYNegOne && squarePlusXNegOneOneNegY) || (squarePlusYOne && squarePlusYNegOne && squarePlusYOne && squarePlusXOneOneY)))
            || (squarePlusXOne && squarePlusXTwo && ((squarePlusYOne && squarePlusXOneOneNegY && squarePlusXOneOneY) || (squarePlusXOneOneNegY && squarePlusXOneOneY && squarePlusXTwoOneNegY)))
            || (squarePlusXNegOne && squarePlusXNegTwo && ((squarePlusYNegOne && squarePlusXNegOneOneNegY && squarePlusXNegOneOneY) || (squarePlusXNegOneOneNegY && squarePlusXNegOneOneY && squarePlusXNegTwoOneY)))
            || (squarePlusXOne && squarePlusYOne && squarePlusXOneOneY && squarePlusXTwoOneY && squarePlusYTwoOneX)
            || (squarePlusXNegOne && squarePlusYOne && squarePlusYOneOneNegX && squarePlusXNegTwoOneY && squarePlusYTwoOneNegX)
            || (squarePlusXNegOne && squarePlusYNegOne && squarePlusYNegOneOneNegX && squarePlusYNegTwoOneNegX && squarePlusXNegTwoOneNegY)
            || (squarePlusXOne && squarePlusYNegOne && squarePlusXOneOneNegY && squarePlusXTwoOneNegY && squarePlusYNegTwoOneX))
        {
            squarePlus = true;
            if (!OneCorrect.isPlaying && Blue && !(threeRow && lShape && uShape))
            {
                Debug.Log("bluecorrect");
                Blue = false;
                OneCorrect.Play();
            }
        }
        else if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null && Blue)
        {
            squarePlus = false;
        }


        if (threeRow && lShape && uShape && squarePlus && !AllCorrect.isPlaying && (Red || Green || Yellow || Blue))
        {
            AllCorrect.Play();
            Red = false;
            Green = false;
            Yellow = false;
            Blue = false;
            Debug.Log("allcorrect");
        }
    }
    public void CheckPiecePositions()
    {
        if (Green)
        {
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
        }
        if (Red)
        {
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
        if (Yellow)
        {
            if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null)
            {
                uShapeXOne = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()) != null &&
                       GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                       && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                       && ((x + 1) <= 4);

                uShapeXOneOneY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()) != null &&
                       GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                       && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                       && ((x + 1) <= 4) && ((y + 1) <= 5);

                uShapeXOneOneNegY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()) != null &&
                      GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                      GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                      && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                      GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                      && ((x + 1) <= 4) && ((y - 1) >= 1);

                uShapeXNegOne = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((x - 1) >= 1);

                uShapeXNegOneOneY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((x - 1) >= 1) && ((y + 1) <= 5);

                uShapeXNegOneOneNegY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                  && ((x - 1) >= 1) && ((y - 1) >= 1);

                uShapeXTwo = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((x + 2) <= 4);

                uShapeXTwoOneY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((x + 2) <= 4) && ((y + 1) <= 5);

                uShapeXTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((x + 2) <= 4) && ((y - 1) >= 1);

                uShapeXNegTwo = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((x - 2) >= 1);

                uShapeXNegTwoOneY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                  && ((x - 2) >= 1) && ((y + 1) <= 5);

                uShapeXNegTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                  && ((x - 2) >= 1) && ((y - 1) >= 1);
                //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
                uShapeYOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y + 1) <= 5);

                uShapeYOneOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y + 1) <= 5) && ((x + 1) <= 4);

                uShapeYOneOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y + 1) <= 5) && ((x - 1) >= 1);

                uShapeYNegOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y - 1) >= 1);

                uShapeYNegOneOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y - 1) >= 1) && ((x + 1) <= 4);

                uShapeYNegOneOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((y - 1) >= 1) && ((x - 1) <= 4);

                uShapeYTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                   GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((y + 2) <= 5);

                uShapeYTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                  && ((y + 2) <= 5) && ((x + 1) <= 4);

                uShapeYTwoOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()) != null &&
                 GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
                 GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                 GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
                 GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                 && ((y + 2) <= 5) && ((x - 1) >= 1);

                uShapeYNegTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                    && ((y - 2) >= 1);

                uShapeYNegTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                   && ((y - 2) >= 1) && ((x + 1) <= 4);

                uShapeYNegTwoOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptYellow>() != null
                  && ((y - 2) >= 1) && ((x - 1) >= 1);

            }
        }
        if (Blue)
        {
            if (TalosSnapZone.GetCurrentSnappedObject() != null && TalosSnapZone.GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null)
            {
                squarePlusXOne = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()) != null &&
                       GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                       && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + y).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                       && ((x + 1) <= 4);

                squarePlusXOneOneY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()) != null &&
                       GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                       && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                       GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                       && ((x + 1) <= 4) && ((y + 1) <= 5);

                squarePlusXOneOneNegY = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()) != null &&
                      GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                      GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                      && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                      GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                      && ((x + 1) <= 4) && ((y - 1) >= 1);

                squarePlusXNegOne = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((x - 1) >= 1);

                squarePlusXNegOneOneY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((x - 1) >= 1) && ((y + 1) <= 5);

                squarePlusXNegOneOneNegY = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                  && ((x - 1) >= 1) && ((y - 1) >= 1);

                squarePlusXTwo = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + y).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((x + 2) <= 4);

                squarePlusXTwoOneY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((x + 2) <= 4) && ((y + 1) <= 5);

                squarePlusXTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x + 2) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((x + 2) <= 4) && ((y - 1) >= 1);

                squarePlusXNegTwo = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + y).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((x - 2) >= 1);

                squarePlusXNegTwoOneY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y + 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                  && ((x - 2) >= 1) && ((y + 1) <= 5);

                squarePlusXNegTwoOneNegY = GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                  && GameObject.Find(("TalosSnapZone" + (x - 2) + "_" + (y - 1)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                  && ((x - 2) >= 1) && ((y - 1) >= 1);
                //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
                squarePlusYOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y + 1) <= 5);

                squarePlusYOneOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y + 1) <= 5) && ((x + 1) <= 4);

                squarePlusYOneOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y + 1) <= 5) && ((x - 1) >= 1);

                squarePlusYNegOne = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + x + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y - 1) >= 1);

                squarePlusYNegOneOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                    && GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 1)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y - 1) >= 1) && ((x + 1) <= 4);

                squarePlusYNegOneOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null
                   && GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 1)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((y - 1) >= 1) && ((x - 1) <= 4);

                squarePlusYTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                   GameObject.Find(("TalosSnapZone" + x + "_" + (y + 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((y + 2) <= 5);

                squarePlusYTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                  GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y + 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                  && ((y + 2) <= 5) && ((x + 1) <= 4);

                squarePlusYTwoOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()) != null &&
                 GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
                 GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                 GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y + 2)).ToString()).
                 GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                 && ((y + 2) <= 5) && ((x - 1) >= 1);

                squarePlusYNegTwo = GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()) != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                    GameObject.Find(("TalosSnapZone" + x + "_" + (y - 2)).ToString()).
                    GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                    && ((y - 2) >= 1);

                squarePlusYNegTwoOneX = GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()) != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                   GameObject.Find(("TalosSnapZone" + (x + 1) + "_" + (y - 2)).ToString()).
                   GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                   && ((y - 2) >= 1) && ((x + 1) <= 4);

                squarePlusYNegTwoOneNegX = GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()) != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject() != null &&
                  GameObject.Find(("TalosSnapZone" + (x - 1) + "_" + (y - 2)).ToString()).
                  GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject().GetComponent<TalosColourScriptBlue>() != null
                  && ((y - 2) >= 1) && ((x - 1) >= 1);           
            }
        }
    }
}
    
   
