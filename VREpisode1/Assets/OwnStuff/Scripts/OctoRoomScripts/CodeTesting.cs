using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeTesting : MonoBehaviour {

    Button TestingButton;
    MeshRenderer testingRenderer;
    int currentMaterial;
    bool colorSwitching;

    public Material ButtonCyan;
    public Material ButtonGreen;
    public Material ButtonRed;
    public Material ButtonYellow;
    public Material WhiteUnLit;


    void Start () {
        TestingButton = GetComponent<Button>();
        testingRenderer = transform.Find("TestingCube").GetComponent<MeshRenderer>();
        currentMaterial = 0;
        colorSwitching = false;
	}
	
	
	void Update ()
    {

		if (TestingButton.isPressedDown && !colorSwitching)
        {
            if (currentMaterial == 0)
            {
                testingRenderer.material = ButtonRed;
                currentMaterial++;
                colorSwitching = true;
                StartCoroutine("WaitForSwitch");
            }
            else if (currentMaterial == 1)
            {
                testingRenderer.material = ButtonCyan;
                currentMaterial++;
                colorSwitching = true;
                StartCoroutine("WaitForSwitch");
            }
            else if (currentMaterial == 2)
            {
                testingRenderer.material = ButtonYellow;
                currentMaterial++;
                colorSwitching = true;
                StartCoroutine("WaitForSwitch");
            }
            else if (currentMaterial == 3)
            {
                testingRenderer.material = ButtonGreen;
                currentMaterial++;
                colorSwitching = true;
                StartCoroutine("WaitForSwitch");
            }
            else if (currentMaterial == 4)
            {
                testingRenderer.material = WhiteUnLit;
                currentMaterial = 0;
                colorSwitching = true;
                StartCoroutine("WaitForSwitch");
            }
        }
	}
    IEnumerator WaitForSwitch()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        colorSwitching = false;
    }
}
