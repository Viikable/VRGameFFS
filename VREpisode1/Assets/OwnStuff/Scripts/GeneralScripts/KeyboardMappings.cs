using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;

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
            //This takes the last char and compares if it is _ by changing text and _ to CharArray first
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length-1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length-1);
            }
            if (caps)
            {
                MonitorScreen.text += "A";
            }
            else
            {
                MonitorScreen.text += "a";
            }
            buttonBeingPressed = true;
            latestAddition = "A";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (B.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "B";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (C.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "C";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (D.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "D";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (E.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "E";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (F.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "F";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (G.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "G";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (H.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "H";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (I.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "I";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (J.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "J";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (K.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "K";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (L.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "L";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (M.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "M";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (N.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "N";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (O.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "O";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (P.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "P";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Q.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Q";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (R.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "R";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (S.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "S";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (T.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "T";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (U.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "U";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (V.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "V";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (W.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "W";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (X.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "X";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Y.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Y";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Z.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Z";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Å.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Å";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Ä.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Ä";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        if (Ö.AtMaxLimit() && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
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
            buttonBeingPressed = true;
            latestAddition = "Ö";
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
        //Special control buttons
        if ((BackSpace.AtMaxLimit() || Delete.AtMaxLimit()) && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character
            MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length-1);
            buttonBeingPressed = true;
            StopCoroutine("IdleCheck");         
            StartCoroutine("IdleCheck");          
        }
        if ((Space.AtMaxLimit() || Enter.AtMaxLimit()) && !buttonBeingPressed)
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            
            MonitorScreen.text += " ";
            buttonBeingPressed = true;
            StopCoroutine("IdleCheck");
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
            StopCoroutine("IdleCheck");
            StartCoroutine("IdleCheck");
        }
    }

    //creates a line which appears and disappears like waiting for more text
    IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed)
        {
            MonitorScreen.text += "_";
            yield return new WaitForSecondsRealtime(0.35f);
            if (!buttonBeingPressed)
            {               
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);              
            }
            yield return new WaitForSecondsRealtime(0.35f);
            //idle = false;
        }
        if (buttonBeingPressed)  
        {
            idle = false;
        }
    }
    //waits for 3 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        buttonBeingPressed = false;
        idle = false;
    }   
}
