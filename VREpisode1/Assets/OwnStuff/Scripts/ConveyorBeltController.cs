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
    [Tooltip("Is the conveyor belt animation playing or not")]
    public static bool NotPlaying = true;
    [Tooltip("Has the player triggered the moving of the conveyor belts")]
    public static bool PressedScreen1 = true;
    [Tooltip("Has the player triggered the moving of the conveyor belt so it lowers down to the pool")]
    public static bool PressedScreen2 = false;
    [Tooltip("Has the player paused the movement of the conveyor belts")]
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
    }
    public bool GetNotPlaying()
    {
        return NotPlaying;
    }
    public void SetNotPlaying(bool wtf)
    {
        NotPlaying = wtf;
    }
    public void SetPressedScreen1On()
    {
        PressedScreen1 = true;
    }
    public bool GetPressedScreen1()
    {
        return PressedScreen1;
    }
    public void SetPressedScreen2On()
    {
        PressedScreen2 = true;
    }
    public bool GetPressedScreen3()
    {
        return PressedScreen1;
    }
    public void SetPressedScreen3On()
    {
        PressedScreen1 = true;
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

                anim.SetBool("Start", true);
                anim2.SetBool("Start", true);
                anim3.SetBool("Start", true);
                anim.speed = 2f;
                anim2.speed = 2f;
                anim3.speed = 2f;
                animDown.speed = 2f;
                PressedScreen3 = false;
            }
        }
        
        if (PressedScreen2)
        {
            //makes the middle conveyor belt go down 
            anim.SetBool("Open", true);
            animDown.SetBool("Open", true);
            
        }
        if (PressedScreen3)
        {
            //stops the sound and movement of all conveyorbelts
            if (!NotPlaying)
            {
                anim.speed = 0f;
                anim2.speed = 0f;
                anim3.speed = 0f;
                animDown.speed = 0f;
                ConveyorAudio.Stop();
                ConveyorAudio2.Stop();
                ConveyorAudio3.Stop();
                NotPlaying = true;
                PressedScreen1 = false;
            }
           
            
        }
        if (PressedScreen3)
        {
           //melt the metal animation

        }
    }
}
