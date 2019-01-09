using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

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

    private float time;    //time to check when conveyor belt is down
    private float timeUp;
    private bool runCoRoutine;
    private bool checkStart;
    private bool check;
    private bool runCoRoutineStart;
    private bool oddPress;
    private bool evenPress;
    private GameObject MiddleConveyorBelt;
    private GameObject VinoConveyorBelt;
    private GameObject DownConveyorBelt;
    private bool pressedIt;
    private bool pressedIt2;
    private bool yep;
    private bool yep2;

    void Start()
    {
        yep = true;
        yep2 = true;
        pressedIt = true;
        pressedIt2 = true;
        evenPress = false;
        oddPress = true;
        time = 0f;
        timeUp = 0f;
        runCoRoutineStart = false;
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
        if (!beltsMoving && ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {

            Debug.Log("pressed1");
            beltsMoving = true;
            ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                Debug.Log("pressed1while3");
                ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            }
        }
        else if (!beltsPaused && ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {

            Debug.Log("pressed3");
            beltsPaused = true;
            ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("pressed3while1");
            }
        }
        if (ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {            
           
            if (beltsMoving)
            {
               
                if (oddPress && !beltMovingUp)
                {
                    Debug.Log("Oddpress");
                    beltMovingUp = false;
                    beltMovingDown = true;
                    oddPress = false;                    
                }
                else if (evenPress && !beltMovingDown)
                {
                    Debug.Log("evenpress");
                    beltMovingDown = false;
                    beltMovingUp = true;
                    evenPress = false;                   
                }
            }
        }
    }

    public void BeltDownCheck()
    {
        if (beltMovingDown && beltsMoving)
        {
            time++;
        }
        if (time > 180)
        {
            beltHasMovedDown = true;
            time = 0f;
            beltMovingDown = false;
        }
    }

    public void BeltUpCheck()
    {
        if (beltMovingUp && beltsMoving)
        {
            timeUp++;
        }
        if (timeUp > 210)
        {
            Debug.Log("belt has moved up");
            beltHasMovedUp = true;
            timeUp = 0f;
            beltMovingUp = false;
        }
    }
    void Update()
    {
        CheckButtonPress();
        BeltDownCheck();
        BeltUpCheck();
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

        if (beltMovingUp)
            {
            //beltHasMovedDown = false;
           
            animDown.SetBool("Up", true);
            foreach (Collider col in DownConveyorBelt.GetComponentsInChildren<Collider>())
            {
                col.enabled = true;
            }
            foreach (MeshRenderer rend in DownConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = true;
            }
            foreach (Collider col in VinoConveyorBelt.GetComponentsInChildren<Collider>()) {
                col.enabled = false;
            }
            foreach (MeshRenderer rend in VinoConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = false;
            }
            animVino.SetBool("Start", false);
            //animVino.SetBool("Disappear", true);      //replaced
            }                                                                
        if (beltHasMovedDown && pressedIt)
        {
            Debug.Log("DOWN");
            ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
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
            ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;            
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
                col.enabled = false;
            }
            foreach (MeshRenderer rend in DownConveyorBelt.GetComponentsInChildren<MeshRenderer>())
            {
                rend.enabled = false;
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
        if (beltHasMovedDown) {            
            yield return new WaitForSecondsRealtime(0.35f);
            evenPress = true;
            beltHasMovedDown = false;
            pressedIt = true;
            
           

            //StartCoroutine("OkayThen2");
        }
    }
    IEnumerator WaitUp()
    {
        Debug.Log("waitupcor");
        if (beltHasMovedUp)
        {
        yield return new WaitForSecondsRealtime(0.35f);
           
            oddPress = true;
            beltHasMovedUp = false;
            pressedIt2 = true;
           
            //StartCoroutine("OkayThen");
        }
    }
    IEnumerator OkayThen()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        if (yep)
        {
            Debug.Log("stayPressed");
            ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            yep = false;
        }
    }
    IEnumerator OkayThen2()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        if (yep2)
        {
            Debug.Log("stayPressed");
            ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            yep2 = false;
        }
    }                      
}

