using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;
using System;

public class KeyboardMappings : MonoBehaviour {

    //MONITOR SCREEN
    TextMeshPro MonitorScreen;

    //CONTROL VARIABLES
    [Tooltip("Indicates if any buttons are currently being pressed," +
    " this so that the monitor can go to sleep mode or do an idle animation when a certain time occurs without presses")]
    public bool buttonBeingPressed;

    [Tooltip("This character is the one most recently added to the screen")]
    public static string latestAddition;

    public bool idle;

    public bool caps; 
 
    //ALPHABET
    VRTK_PhysicsPusher A;
    VRTK_PhysicsPusher B;
    VRTK_PhysicsPusher C;
    VRTK_PhysicsPusher D;
    VRTK_PhysicsPusher E;
    VRTK_PhysicsPusher F;
    VRTK_PhysicsPusher G;
    VRTK_PhysicsPusher H;
    VRTK_PhysicsPusher I;
    VRTK_PhysicsPusher J;
    VRTK_PhysicsPusher K;
    VRTK_PhysicsPusher L;
    VRTK_PhysicsPusher M;
    VRTK_PhysicsPusher N;
    VRTK_PhysicsPusher O;
    VRTK_PhysicsPusher P;
    VRTK_PhysicsPusher Q;
    VRTK_PhysicsPusher R;
    VRTK_PhysicsPusher S;
    VRTK_PhysicsPusher T;
    VRTK_PhysicsPusher U;
    VRTK_PhysicsPusher V;
    VRTK_PhysicsPusher W;
    VRTK_PhysicsPusher X;
    VRTK_PhysicsPusher Y;
    VRTK_PhysicsPusher Z;
    VRTK_PhysicsPusher Å;
    VRTK_PhysicsPusher Ä;
    VRTK_PhysicsPusher Ö;


    //Special control buttons
    VRTK_PhysicsPusher BackSpace;
    VRTK_PhysicsPusher Enter;
    VRTK_PhysicsPusher CapsLock;
    VRTK_PhysicsPusher Tab;
    VRTK_PhysicsPusher Space;
    VRTK_PhysicsPusher Shift_Left;
    VRTK_PhysicsPusher Shift_Right;
    VRTK_PhysicsPusher Delete;


    void Start ()
    {
        //MONITOR SCREEN
        MonitorScreen = transform.Find("MonitorScreen").GetComponent<TextMeshPro>();


        //CONTROL VARIABLES
        buttonBeingPressed = false;

        latestAddition = "";

        idle = false;
                  
        //ALPHABET
        A = transform.Find("A_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        B = transform.Find("B_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        C = transform.Find("C_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        D = transform.Find("D_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        E = transform.Find("E_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        F = transform.Find("F_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        G = transform.Find("G_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        H = transform.Find("H_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        I = transform.Find("I_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        J = transform.Find("J_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        K = transform.Find("K_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        L = transform.Find("L_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        M = transform.Find("M_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        N = transform.Find("N_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        O = transform.Find("O_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        P = transform.Find("P_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Q = transform.Find("Q_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        R = transform.Find("R_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        S = transform.Find("S_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        T = transform.Find("T_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        U = transform.Find("U_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        V = transform.Find("V_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        W = transform.Find("W_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        X = transform.Find("X_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Y = transform.Find("Y_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Z = transform.Find("Z_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Å = transform.Find("Å_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Ä = transform.Find("Ä_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Ö = transform.Find("Ö_Container").GetComponentInChildren<VRTK_PhysicsPusher>();

        BackSpace = transform.Find("BACKSPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        CapsLock = transform.Find("CAPSLOCK_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Enter = transform.Find("ENTER_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Space = transform.Find("SPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Delete = transform.Find("DELETE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
    }
	
	
	void Update ()
    {      
        MonitorButtonPressCheck();        
        if (!buttonBeingPressed && !idle)
        {
            idle = true;
            StartCoroutine("IdleAnimation");
        }
	}

    private void MonitorButtonPressCheck()
    {
        if (A.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            //This takes the last char and compares if it is _ by changing text and _ to CharArray first
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length-1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length-1);
            }
            if (caps)
            {
                MonitorScreen.text += "A";
            }
            else
            {
                MonitorScreen.text += "a";
            }
            latestAddition = "A";
            StartCoroutine("IdleCheck");
        }
        if (B.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "B";
            }
            else
            {
                MonitorScreen.text += "b";
            }
            latestAddition = "B";
            StartCoroutine("IdleCheck");
        }
        if (C.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "C";
            }
            else
            {
                MonitorScreen.text += "c";
            }
            latestAddition = "C";
            StartCoroutine("IdleCheck");
        }
        if (D.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "D";
            }
            else
            {
                MonitorScreen.text += "d";
            }
            latestAddition = "D";
            StartCoroutine("IdleCheck");
        }
        if (E.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "E";
            }
            else
            {
                MonitorScreen.text += "e";
            }
            latestAddition = "E";
            StartCoroutine("IdleCheck");
        }
        if (F.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "F";
            }
            else
            {
                MonitorScreen.text += "f";
            }
            latestAddition = "F";
            StartCoroutine("IdleCheck");
        }
        if (G.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "G";
            }
            else
            {
                MonitorScreen.text += "g";
            }
            latestAddition = "G";
            StartCoroutine("IdleCheck");
        }
        if (H.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "H";
            }
            else
            {
                MonitorScreen.text += "h";
            }
            latestAddition = "H";
            StartCoroutine("IdleCheck");
        }
        if (I.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "I";
            }
            else
            {
                MonitorScreen.text += "i";
            }
            latestAddition = "I";
            StartCoroutine("IdleCheck");
        }
        if (J.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "J";
            }
            else
            {
                MonitorScreen.text += "j";
            }
            latestAddition = "J";
            StartCoroutine("IdleCheck");
        }
        if (K.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "K";
            }
            else
            {
                MonitorScreen.text += "k";
            }
            latestAddition = "K";
            StartCoroutine("IdleCheck");
        }
        if (L.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "L";
            }
            else
            {
                MonitorScreen.text += "l";
            }
            latestAddition = "L";
            StartCoroutine("IdleCheck");
        }
        if (M.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "M";
            }
            else
            {
                MonitorScreen.text += "m";
            }
            latestAddition = "M";
            StartCoroutine("IdleCheck");
        }
        if (N.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "N";
            }
            else
            {
                MonitorScreen.text += "n";
            }
            latestAddition = "N";
            StartCoroutine("IdleCheck");
        }
        if (O.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "O";
            }
            else
            {
                MonitorScreen.text += "o";
            }
            latestAddition = "O";
            StartCoroutine("IdleCheck");
        }
        if (P.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "P";
            }
            else
            {
                MonitorScreen.text += "p";
            }
            latestAddition = "P";
            StartCoroutine("IdleCheck");
        }
        if (Q.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Q";
            }
            else
            {
                MonitorScreen.text += "q";
            }
            latestAddition = "Q";
            StartCoroutine("IdleCheck");
        }
        if (R.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "R";
            }
            else
            {
                MonitorScreen.text += "r";
            }
            latestAddition = "R";
            StartCoroutine("IdleCheck");
        }
        if (S.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "S";
            }
            else
            {
                MonitorScreen.text += "s";
            }
            latestAddition = "S";
            StartCoroutine("IdleCheck");
        }
        if (T.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "T";
            }
            else
            {
                MonitorScreen.text += "t";
            }
            latestAddition = "T";
            StartCoroutine("IdleCheck");
        }
        if (U.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "U";
            }
            else
            {
                MonitorScreen.text += "u";
            }
            latestAddition = "U";
            StartCoroutine("IdleCheck");
        }
        if (V.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "V";
            }
            else
            {
                MonitorScreen.text += "v";
            }
            latestAddition = "V";
            StartCoroutine("IdleCheck");
        }
        if (W.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "W";
            }
            else
            {
                MonitorScreen.text += "w";
            }
            latestAddition = "W";
            StartCoroutine("IdleCheck");
        }
        if (X.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "X";
            }
            else
            {
                MonitorScreen.text += "x";
            }
            latestAddition = "X";
            StartCoroutine("IdleCheck");
        }
        if (Y.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Y";
            }
            else
            {
                MonitorScreen.text += "y";
            }
            latestAddition = "Y";
            StartCoroutine("IdleCheck");
        }
        if (Z.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Z";
            }
            else
            {
                MonitorScreen.text += "z";
            }
            latestAddition = "Z";
            StartCoroutine("IdleCheck");
        }
        if (Å.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Å";
            }
            else
            {
                MonitorScreen.text += "å";
            }
            latestAddition = "Å";
            StartCoroutine("IdleCheck");
        }
        if (Ä.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Ä";
            }
            else
            {
                MonitorScreen.text += "ä";
            }
            latestAddition = "Ä";
            StartCoroutine("IdleCheck");
        }
        if (Ö.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Ö";
            }
            else
            {
                MonitorScreen.text += "ö";
            }
            latestAddition = "Ö";
            StartCoroutine("IdleCheck");
        }
        //Special control buttons
        if ((BackSpace.AtMaxLimit() || Delete.AtMaxLimit()) && !buttonBeingPressed)
        {
            StopAllCoroutines();         
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character
            if (MonitorScreen.text.Length != 0)
            {
            MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            StartCoroutine("IdleCheck");          
        }
        if ((Space.AtMaxLimit() || Enter.AtMaxLimit()) && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            
            MonitorScreen.text += " ";
            StartCoroutine("IdleCheck");
        }
        if (CapsLock.AtMaxLimit() && !buttonBeingPressed)
        {          
           //changes keys to capital or not
           if (caps)
            {
                caps = false;
            }
           else
            {
                caps = true;
            }          
            buttonBeingPressed = true;
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Enter.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += Environment.NewLine;           
            StartCoroutine("IdleCheck");
        }
    }

    //creates a line which appears and disappears like waiting for more text
    IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed && idle)
        {
            MonitorScreen.text += "_";
            Debug.Log("addedline");
            yield return new WaitForSecondsRealtime(0.35f);
            if (!buttonBeingPressed && MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                Debug.Log("removedline");
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);              
            }
            yield return new WaitForSecondsRealtime(0.35f);           
        }   
    }
    //waits for 0.25 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        buttonBeingPressed = false;
        idle = false;
    }   
}
