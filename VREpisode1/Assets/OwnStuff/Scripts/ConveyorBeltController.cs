using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour {
    Animator anim;
    Animator anim2;
    Animator anim3;
    AudioSource ConveyorAudio;
    AudioSource ConveyorAudio2;
    AudioSource ConveyorAudio3;
    Animator animDown;
    Animation Animation;
    public static bool NotPlaying = true;
    public static bool PressedScreen1 = true;
    public bool PressedScreen2 = false;
    public static bool PressedScreen3 = false;
    // Use this for initialization
    void Start () {
        ConveyorAudio = GameObject.Find("ConveyorAudio").GetComponent<AudioSource>();
        ConveyorAudio2 = GameObject.Find("ConveyorAudio2").GetComponent<AudioSource>();
        ConveyorAudio3 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        anim = GameObject.Find("Conveyor_belt_Animated").GetComponent<Animator>();
        anim2 = GameObject.Find("Conveyor_belt_Animated2").GetComponent<Animator>();
        anim3 = GameObject.Find("Conveyor_belt_Animated3").GetComponent<Animator>();
        animDown = GameObject.Find("Conveyor_belt_AnimatedDown").GetComponent<Animator>();
        //ConveyorMovement = anim.GetComponent<Animation>();
    }
   
    // Update is called once per frame
    void Update () {
		if (PressedScreen1)
        {
            //starts the sound and movement for all normal conveyorbelts
            if (NotPlaying)
            {
                NotPlaying = false;
                ConveyorAudio.Play();
                ConveyorAudio2.Play();
                ConveyorAudio3.Play();
            }
            anim.SetBool("Start", true);
            anim2.SetBool("Start", true);
            anim3.SetBool("Start", true);
            Animation["ConveyorBeltMovement"].speed = 2f;
            Animation["ConveyorDisappear"].speed = 2f;
            Animation["ConveyorMovementDown"].speed = 2f;
        }
        
        if (PressedScreen2)
        {
            //makes the middle conveyor belt go down and sets it speed to normal if it was stopped
            anim.SetBool("Open", true);
            animDown.SetBool("Open", true);
            Animation["ConveyorMovementDown"].speed = 1f;
        }
        if (PressedScreen3)
        {
            //stops the sound and movement of all conveyorbelts
            if (!NotPlaying)
            {
                ConveyorAudio.Stop();
                ConveyorAudio2.Stop();
                ConveyorAudio3.Stop();
                NotPlaying = true;
            }
            Animation["ConveyorBeltMovement"].speed = 0f;
            Animation["ConveyorDisappear"].speed = 0f;
            Animation["ConveyorMovementDown"].speed = 0f;
            
        }
        if (PressedScreen3)
        {
           //melt the metal animation

        }
    }
}
