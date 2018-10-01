using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour {
    Animator anim;
    Animator anim2;
    Animator anim3;
    Animator animDown;
    Animation Animation;
    public static bool OddPress = true;
    public static bool EvenPress = false;
    public static bool PressedScreen1 = true;
    public bool PressedScreen2 = false;
    public static bool PressedScreen3 = false;
    // Use this for initialization
    void Start () {
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
            anim.SetBool("Start", true);
            anim2.SetBool("Start", true);
            anim3.SetBool("Start", true);
        }
        
        if (PressedScreen2)
        {
            anim.SetBool("Open", true);
            animDown.SetBool("Open", true);
        }
        if (PressedScreen3 && OddPress)
        {
            OddPress = false;
            EvenPress = true;
            Animation["ConveyorBeltMovement"].speed = 0f;
            Animation["ConveyorDisappear"].speed = 0f;
            Animation["ConveyorMovementDown"].speed = 0f;
            
        }
        if (PressedScreen3 && EvenPress)
        {
            OddPress = true;
            EvenPress = false;
            Animation["ConveyorBeltMovement"].speed = 1f;
            Animation["ConveyorDisappear"].speed = 1f;
            Animation["ConveyorMovementDown"].speed = 1f;

        }
    }
}
