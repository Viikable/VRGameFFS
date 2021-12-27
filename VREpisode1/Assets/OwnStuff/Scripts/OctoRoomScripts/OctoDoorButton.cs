using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class OctoDoorButton : MonoBehaviour {
    //can be used for all similar doors, just drag the animator and sounds into the script which is on the button
    public Animator OctoDoorAnim;
    Button OctoDoorbutton;    
    public AudioSource DoorOpeningSound;
    public AudioSource DoorClosingSound;
    bool doorMoving;

    void Start ()
    {
        OctoDoorbutton = GetComponent<Button>();
        doorMoving = false;
	}

    void Update()
    {
        if (OctoDoorbutton.isPressedDown && OctoDoorbutton.stayPressed && OctoDoorAnim.GetBool("Close") && !doorMoving)
        {
            doorMoving = true;
            OctoDoorAnim.SetBool("Close", false);
            OctoDoorAnim.SetBool("Open", true);
            DoorOpeningSound.Play();
            StartCoroutine("WaitForDoor");
        }
        else if (OctoDoorbutton.isPressedDown && OctoDoorbutton.stayPressed && OctoDoorAnim.GetBool("Open") && !doorMoving)
        {
            doorMoving = true;
            OctoDoorAnim.SetBool("Close", true);
            OctoDoorAnim.SetBool("Open", false);
            DoorClosingSound.Play();
            StartCoroutine("WaitForDoor");
        }
    }
    IEnumerator WaitForDoor()
    {
        yield return new WaitForSecondsRealtime(2f);
        OctoDoorbutton.stayPressed = false;
        doorMoving = false;
        yield return new WaitForSecondsRealtime(0.5f);
        OctoDoorbutton.stayPressed = true;
    }
}
