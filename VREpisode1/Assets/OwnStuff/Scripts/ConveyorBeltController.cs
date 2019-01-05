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

    GameObject ConveyorStartButton;

    GameObject ConveyorDownButton;

    GameObject ConveyorStopButton;

    [SerializeField]
    [Tooltip("Is the conveyor belt animation playing or not")]
    private bool NotPlaying;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belts")]
    private bool Beltsmoving;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belt so it lowers down to the pool")]
    private bool BeltMovingDown;
    [SerializeField]
    [Tooltip("Has the player paused the movement of the conveyor belts")]
    private bool BeltsPaused;
    private bool runCoRoutine;
    private bool checkStart;
    private bool check;
    private bool runCoRoutineStart;
    // Use this for initialization
    void Start()
    {
        runCoRoutineStart = false;
        check = false;
        checkStart = false;
        runCoRoutine = false;
        NotPlaying = true;
        Beltsmoving = false;
        BeltMovingDown = false;
        BeltsPaused = false;
        //StartCoroutine("JustASec");
        ConveyorAudio = GameObject.Find("ConveyorAudio").GetComponent<AudioSource>();
        ConveyorAudio2 = GameObject.Find("ConveyorAudio2").GetComponent<AudioSource>();
        ConveyorAudio3 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        ConveyorAudio4 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        anim = GameObject.Find("Conveyor_belt_Animated").GetComponent<Animator>();
        anim2 = GameObject.Find("Conveyor_belt_Animated2").GetComponent<Animator>();
        anim3 = GameObject.Find("Conveyor_belt_Animated3").GetComponent<Animator>();
        anim4 = GameObject.Find("Conveyor_belt_Animated4").GetComponent<Animator>();
        animDown = GameObject.Find("Conveyor_belt_AnimatedDown").GetComponent<Animator>();
        ConveyorStartButton = GameObject.Find("ConveyorStartButton");
        ConveyorDownButton = GameObject.Find("ConveyorDownButton");
        ConveyorStopButton = GameObject.Find("ConveyorStopButton");
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
        Beltsmoving = true;
    }
    public bool GetPressedScreen1()
    {
        return Beltsmoving;
    }
    public void SetPressedScreen2On()
    {
        BeltMovingDown = true;
    }
    public bool GetPressedScreen3()
    {
        return BeltsPaused;
    }
    public void SetPressedScreen3On()
    {
        BeltsPaused = true;
    }
    public void CheckButtonPress()    //to see when the buttons controlling the conveyor belts are pressed down
    {
        if (!Beltsmoving && ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {
            
            Debug.Log("pressed1");
            Beltsmoving = true;
            ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                Debug.Log("pressed1while3");
                ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            }
        }
        else if (!BeltsPaused && ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {
           
            Debug.Log("pressed3");
            BeltsPaused = true;
            ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("pressed3while1");
            }
        }
        if (!BeltMovingDown && ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().PressedDown)
        {
            Debug.Log("pressed2");
            if (Beltsmoving)
            {
                BeltMovingDown = true;
            }
        }
    }    
    void Update()
    {       
        CheckButtonPress();
       
    

        if (Beltsmoving)
        {

            ConveyorDownButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            //starts the sound and movement for all normal conveyorbelts
            if (NotPlaying)
            {
                NotPlaying = false;
                ConveyorAudio.Play();
                ConveyorAudio2.Play();
                ConveyorAudio3.Play();
                ConveyorAudio4.Play();

                anim.SetBool("Start", true);
                anim2.SetBool("Start", true);
                anim3.SetBool("Start", true);
                anim4.SetBool("Start", true);
                anim.speed = 2f;
                anim2.speed = 2f;
                anim3.speed = 2f;
                anim4.speed = 2f;
                animDown.speed = 2f;
                BeltsPaused = false;
                
                Debug.Log("changedxptrue");
            }
        }

        if (BeltMovingDown && Beltsmoving)
        {
            //makes the middle conveyor belt go down 
            anim.SetBool("Open", true);
            animDown.SetBool("Open", true);

        }
        if (BeltsPaused)
        {            
            //stops the sound and movement of all conveyorbelts
            if (!NotPlaying)
            {
                Debug.Log("changedxdtrue");
                anim.speed = 0f;
                anim2.speed = 0f;
                anim3.speed = 0f;
                anim4.speed = 0f;
                animDown.speed = 0f;
                ConveyorAudio.Stop();
                ConveyorAudio2.Stop();
                ConveyorAudio3.Stop();
                ConveyorAudio4.Stop();
                NotPlaying = true;
                Beltsmoving = false;
               
            }
        }
        //CheckButtonPress();
        //if (Beltsmoving && ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed == false)
        //{
        //    runCoRoutine = true;
        //    StartCoroutine("Check");           
        //}
        //else if (BeltsPaused && ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed == false)
        //{
        //    runCoRoutineStart = true;
        //    StartCoroutine("CheckStart");           
        //}

        //if (checkStart)
        //{
        //    checkStart = false;
        //    ConveyorStartButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        //    runCoRoutineStart = false;
        //}

        //if (check)
        //{
        //    check = false;
        //    ConveyorStopButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        //    runCoRoutine = false;
        //}
        //if (PressedScreen3)
        //{
        //   //melt the metal animation

        //}
    } 
    //IEnumerator Check()
    //{
    //    if (runCoRoutine)
    //    {
    //        yield return new WaitForSeconds(1);
    //        check = true;
    //        Debug.Log("waited");
    //        yield return null;
    //    }
    //    else
    //    {
    //        yield return null;
    //    }
    //}
    //IEnumerator CheckStart()
    //{
    //    if (runCoRoutineStart)
    //    {
    //        yield return new WaitForSeconds(1);
    //        checkStart = true;
    //        Debug.Log("waited");
    //        yield return null;
    //    }
    //    else
    //    {
    //        yield return null;
    //    }
    //}
}

