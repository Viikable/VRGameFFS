﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConveyorBeltController : MonoBehaviour
{
    Animator anim;

    Animator anim2;

    Animator anim3;

    Animator anim4;

    AudioSource ConveyorAudio;

    AudioSource ConveyorAudio2;

    AudioSource ConveyorAudio3;

    AudioSource ConveyorAudio4;

    Animator animDown;

    Animator animVino;

    GameObject ConveyorStartButton;

    GameObject ConveyorDownButton;

    GameObject ConveyorStopButton;

    [SerializeField]
    [Tooltip("Is the conveyor belt animation playing or not")]
    private bool notPlaying;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belts")]
    private bool beltsMoving;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belt so it lowers down to the pool")]
    private bool beltMovingDown;
    [SerializeField]
    [Tooltip("Has the player paused the movement of the conveyor belts")]
    private bool beltsPaused;
    [SerializeField]
    [Tooltip("Has the player pressed the moving trigger(yellow) again so that the belt moves up")]
    private bool beltMovingUp;
    [SerializeField]
    [Tooltip("Has the conveyor belt finished moving down yet")]
    private bool beltHasMovedDown;
    [SerializeField]
    [Tooltip("Has the conveyor belt finished moving up yet")]
    private bool beltHasMovedUp;

    //private float time;    //time to check when conveyor belt is down
    //private float timeUp;
    private bool runCoRoutine;
    private bool checkStart;
    private bool check;    
    private bool oddPress;
    private bool evenPress;
    private GameObject MiddleConveyorBelt;
    private GameObject VinoConveyorBelt;
    private GameObject DownConveyorBelt;
    private bool pressedIt;
    private bool pressedIt2;     
    private bool notDown;
    private bool notUp;

    void Start()
    {
        notDown = true;
        notUp = true;           
        pressedIt = true;
        pressedIt2 = true;
        evenPress = false;
        oddPress = true;
        //time = 0f;
        //timeUp = 0f;       
        check = false;
        checkStart = false;
        runCoRoutine = false;
        notPlaying = true;
        beltsMoving = false;
        beltMovingDown = false;
        beltsPaused = false;
        beltMovingUp = false;
        beltHasMovedDown = false;
        ConveyorAudio = GameObject.Find("ConveyorAudio").GetComponent<AudioSource>();
        ConveyorAudio2 = GameObject.Find("ConveyorAudio2").GetComponent<AudioSource>();
        ConveyorAudio3 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        ConveyorAudio4 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        MiddleConveyorBelt = GameObject.Find("Conveyor_belt_Animated");
        anim = MiddleConveyorBelt.GetComponent<Animator>();
        DownConveyorBelt = GameObject.Find("Conveyor_belt_AnimatedDown");
        animDown = DownConveyorBelt.GetComponent<Animator>();
        VinoConveyorBelt = GameObject.Find("Conveyor_belt_AnimatedVino");
        animVino = VinoConveyorBelt.GetComponent<Animator>();
        anim2 = GameObject.Find("Conveyor_belt_Animated2").GetComponent<Animator>();
        anim3 = GameObject.Find("Conveyor_belt_Animated3").GetComponent<Animator>();
        anim4 = GameObject.Find("Conveyor_belt_Animated4").GetComponent<Animator>();
        ConveyorStartButton = GameObject.Find("ConveyorStartButton");
        ConveyorDownButton = GameObject.Find("ConveyorDownButton");
        ConveyorStopButton = GameObject.Find("ConveyorStopButton");
    }
    public bool GetNotPlaying()
    {
        return notPlaying;
    }
    public void SetNotPlaying(bool wtf)
    {
        notPlaying = wtf;
    }
    public void SetPressedScreen1On()
    {
        beltsMoving = true;
    }
    public bool GetPressedScreen1()
    {
        return beltsMoving;
    }
    public void SetPressedScreen2On()
    {
        beltMovingDown = true;
    }
    public bool GetPressedScreen3()
    {
        return beltsPaused;
    }
    public void SetPressedScreen3On()
    {
        beltsPaused = true;
    }
    public void CheckButtonPress()    //to see when the buttons controlling the conveyor belts are pressed down
    {
        if (!beltsMoving && ConveyorStartButton.GetComponent<Button>().isPressedDown == true)
        {

            Debug.Log("pressed1");
            beltsMoving = true;
            ConveyorStartButton.GetComponent<Button>().stayPressed = true;
            if (ConveyorStopButton.GetComponent<Button>().isPressedDown == true)
            {
                Debug.Log("pressed1while3");
                ConveyorStopButton.GetComponent<Button>().stayPressed = false;
            }
        }
        else if (!beltsPaused && ConveyorStopButton.GetComponent<Button>().isPressedDown == true)
        {
            if (!beltMovingUp && !beltMovingDown)   //this here means can't stop when moving the belt down or up as it causes counting problems
            {
                Debug.Log("pressed3");
                beltsPaused = true;
                ConveyorStopButton.GetComponent<Button>().stayPressed = true;
                if (ConveyorStartButton.GetComponent<Button>().isPressedDown == true)
                {
                    ConveyorStartButton.GetComponent<Button>().stayPressed = false;
                    Debug.Log("pressed3while1");
                }
            }
            else
            {
                ConveyorStopButton.GetComponent<Button>().stayPressed = false;
                StartCoroutine("Return");
            }
        }
        if (ConveyorDownButton.GetComponent<Button>().isPressedDown == true && ConveyorDownButton.GetComponent<Button>().stayPressed)
        {

            if (beltsMoving)
            {

                if (oddPress && !beltMovingUp)
                {
                    Debug.Log("Oddpress");                    
                    beltMovingDown = true;
                    oddPress = false;
                }
                else if (evenPress && !beltMovingDown)
                {
                    Debug.Log("evenpress");                    
                    beltMovingUp = true;
                    evenPress = false;
                }
            }
        }
    }
    IEnumerator Return()
    {
        yield return new WaitForSecondsRealtime(1);
        ConveyorStopButton.GetComponent<Button>().stayPressed = true;
    }

    public void BeltDownCheck()
    {
        if (notDown)
        {
            notDown = false;
            StartCoroutine("BeltDownTime");
        }
    }

    IEnumerator BeltDownTime()
    {       
        yield return new WaitForSecondsRealtime(5.95f);
        Debug.Log("belt has moved down");
        beltHasMovedDown = true;      
        beltMovingDown = false;
        notDown = true;
    }

    public void BeltUpCheck()
    {
        if (notUp)
        {
            StartCoroutine("BeltUpTime");
            notUp = false;
        }
    }
    IEnumerator BeltUpTime()
    {
        yield return new WaitForSecondsRealtime(5.95f);
        Debug.Log("belt has moved up");
        beltHasMovedUp = true;
        notUp = true;
        beltMovingUp = false;
    }
    
    void Update()
    {
        CheckButtonPress();
        
        if (beltsMoving)
        {
            //starts the sound and movement for all normal conveyorbelts
            if (notPlaying)
            {
                notPlaying = false;
                ConveyorAudio.Play();
                ConveyorAudio2.Play();
                ConveyorAudio3.Play();
                anim.SetBool("Start", true);
                anim2.SetBool("Start", true);
                anim3.SetBool("Start", true);
                anim4.SetBool("Start", true);
                anim.speed = 2f;
                anim2.speed = 2f;
                anim3.speed = 2f;
                anim4.speed = 2f;
                animVino.speed = 2f;
                animDown.speed = 1f;

                beltsPaused = false;

                Debug.Log("belt movement continues");
            }
        }

        if (beltMovingDown && beltsMoving)
        {
            BeltDownCheck();
            foreach (Collider col in MiddleConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (MeshRenderer rend in MiddleConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = false;
            }
            ConveyorAudio4.Play();
            //makes the middle conveyor belt go down            
            animDown.SetBool("Open", true);
            anim.SetBool("Open", false);
        }
        else
        {
            ConveyorAudio4.Stop();
        }
        if (beltsPaused)
        {
            //stops the sound and movement of all conveyorbelts
            if (!notPlaying)
            {

                anim.speed = 0f;
                anim2.speed = 0f;
                anim3.speed = 0f;
                anim4.speed = 0f;
                animVino.speed = 0f;
                animDown.speed = 0f;
                ConveyorAudio.Stop();
                ConveyorAudio2.Stop();
                ConveyorAudio3.Stop();
                ConveyorAudio4.Stop();
                notPlaying = true;
                beltsMoving = false;
            }
        }

        if (beltMovingUp && beltsMoving)
        {            
            BeltUpCheck();
            animDown.SetBool("Up", true);
            foreach (Collider col in DownConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = true;
            }
            foreach (MeshRenderer rend in DownConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = true;
            }
            foreach (Collider col in VinoConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (MeshRenderer rend in VinoConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = false;
            }
            animVino.SetBool("Start", false);
            
        }
        if (beltHasMovedDown && pressedIt)
        {
            Debug.Log("DOWN");
            ConveyorDownButton.GetComponent<Button>().stayPressed = false;
            animVino.SetBool("Start", true);
            foreach (Collider col in VinoConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = true;
            }
            foreach (MeshRenderer rend in VinoConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = true;
            }
            evenPress = false;
            if (pressedIt)
            {
                pressedIt = false;
                StartCoroutine("WaitDown");
            }
        }
        if (beltHasMovedUp && pressedIt2)
        {
            Debug.Log("UP");
            ConveyorDownButton.GetComponent<Button>().stayPressed = false;
            anim.SetBool("Start", true);
            foreach (Collider col in MiddleConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = true;
            }
            foreach (MeshRenderer rend in MiddleConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = true;
            }
            foreach (Collider col in DownConveyorBelt.GetComponentsInChildren<Collider>())
            {
                if (col.name != "railing" && col.name != "railing2")
                {
                    col.enabled = false;
                }
            }
            foreach (MeshRenderer rend in DownConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                if (rend.name != "railing" && rend.name != "railing2")
                {
                    rend.enabled = false;
                }
            }
            animDown.SetBool("Up", false);
            animDown.SetBool("Open", false);
            oddPress = false;
            //beltHasMovedUp = false;           
            if (pressedIt2)
            {
                pressedIt2 = false;
                StartCoroutine("WaitUp");
            }
        }
    }
    IEnumerator WaitDown()
    {
        Debug.Log("waitdowncor");
        yield return new WaitForSecondsRealtime(0.15f);
        if (beltHasMovedDown)
        {
            evenPress = true;
            beltHasMovedDown = false;
            pressedIt = true;          
        }
    }
    IEnumerator WaitUp()
    {
        Debug.Log("waitupcor");
        yield return new WaitForSecondsRealtime(0.15f);
        if (beltHasMovedUp)
        {

            oddPress = true;
            beltHasMovedUp = false;
            pressedIt2 = true;         
        }
    }
}

