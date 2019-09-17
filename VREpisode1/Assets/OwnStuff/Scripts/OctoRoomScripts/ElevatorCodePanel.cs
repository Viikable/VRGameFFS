using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class ElevatorCodePanel : MonoBehaviour {
    VRTK_PhysicsPusher FirstCodeButton;

    VRTK_PhysicsPusher SecondCodeButton;

    VRTK_PhysicsPusher ThirdCodeButton;

    VRTK_PhysicsPusher FourthCodeButton;

    MeshRenderer ElevatorCodePart1;

    MeshRenderer ElevatorCodePart2;

    MeshRenderer ElevatorCodePart3;

    MeshRenderer ElevatorCodePart4;

    public Material OctoRed;

    public Material OctoCyan;

    public Material OctoYellow;

    public Material OctoGreen;

    int counter1;

    int counter2;

    int counter3;

    int counter4;

    bool pressed1;

    bool pressed2;

    bool pressed3;

    bool pressed4;


    void Start () {
        FirstCodeButton = GameObject.Find("FirstElevatorCodeButtonContainer").transform.GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        SecondCodeButton = GameObject.Find("SecondElevatorCodeButtonContainer").transform.GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        ThirdCodeButton = GameObject.Find("ThirdElevatorCodeButtonContainer").transform.GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        FourthCodeButton = GameObject.Find("FourthElevatorCodeButtonContainer").transform.GetChild(0).GetComponent<VRTK_PhysicsPusher>();

        ElevatorCodePart1 = transform.GetChild(0).GetComponent<MeshRenderer>();
        ElevatorCodePart2 = transform.GetChild(1).GetComponent<MeshRenderer>();
        ElevatorCodePart3 = transform.GetChild(2).GetComponent<MeshRenderer>();
        ElevatorCodePart4 = transform.GetChild(3).GetComponent<MeshRenderer>();

        counter1 = 0;
        counter2 = 0;
        counter3 = 0;
        counter4 = 0;

        pressed1 = false;
        pressed2 = false;
        pressed3 = false;
        pressed4 = false;


    }
	
	// Update is called once per frame
	void Update () {

		if (FirstCodeButton.AtMaxLimit() && !pressed1)
        {
            pressed1 = true;

            if (counter1 == 4)
            {
                counter1 = 0;
            }
            if (counter1 == 0)
            {
                ElevatorCodePart1.material = OctoRed;                
            }
            else if (counter1 == 1)
            {
                ElevatorCodePart1.material = OctoCyan;                
            }
            else if (counter1 == 2)
            {
                ElevatorCodePart1.material = OctoYellow;               
            }
            else if (counter1 == 3)
            {
                ElevatorCodePart1.material = OctoGreen;
            }
            StartCoroutine("WaitForButton",1);               
        }
        if (SecondCodeButton.AtMaxLimit() && !pressed2)
        {
            pressed2 = true;

            if (counter2 == 4)
            {
                counter2 = 0;
            }
            if (counter2 == 0)
            {
                ElevatorCodePart2.material = OctoRed;               
            }
            else if (counter2 == 1)
            {
                ElevatorCodePart2.material = OctoCyan;               
            }
            else if (counter2 == 2)
            {
                ElevatorCodePart2.material = OctoYellow;              
            }
            else if (counter2 == 3)
            {
                ElevatorCodePart2.material = OctoGreen;
            }
            StartCoroutine("WaitForButton", 2);
        }
        if (ThirdCodeButton.AtMaxLimit() && !pressed3)
        {
            pressed3 = true;

            if (counter3 == 4)
            {
                counter3 = 0;
            }
            if (counter3 == 0)
            {
                ElevatorCodePart3.material = OctoRed;
            }
            else if (counter3 == 1)
            {
                ElevatorCodePart3.material = OctoCyan;               
            }
            else if (counter3 == 2)
            {
                ElevatorCodePart3.material = OctoYellow;              
            }
            else if (counter3 == 3)
            {
                ElevatorCodePart3.material = OctoGreen;
            }
            StartCoroutine("WaitForButton", 3);
        }
        if (FourthCodeButton.AtMaxLimit() && !pressed4)
        {
            pressed4 = true;

            if (counter4 == 4)
            {
                counter4 = 0;
            }
            if (counter4 == 0)
            {
                ElevatorCodePart4.material = OctoRed;               
            }
            else if (counter4 == 1)
            {
                ElevatorCodePart4.material = OctoCyan;              
            }
            else if (counter4 == 2)
            {
                ElevatorCodePart4.material = OctoYellow;               
            }
            else if (counter4 == 3)
            {
                ElevatorCodePart4.material = OctoGreen;
            }
            StartCoroutine("WaitForButton", 4);
        }
        if (ElevatorCodePart1.sharedMaterial == OctoRed && ElevatorCodePart2.sharedMaterial == OctoGreen 
            && ElevatorCodePart3.sharedMaterial == OctoGreen && ElevatorCodePart4.sharedMaterial == OctoGreen)
        {
            Debug.Log("Correct");
        }
    }

    IEnumerator WaitForButton(int button)
    {
        yield return new WaitForSecondsRealtime(1f);
        if (button == 1)
        {
            counter1++;
            pressed1 = false;
        }
        else if (button == 2)
        {
            counter2++;
            pressed2 = false;
        }
        else if (button == 3)
        {
            counter3++;
            pressed3 = false;
        }
        else if (button == 4)
        {
            counter4++;
            pressed4 = false;
        }
    }
}
