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
    public static bool buttonBeingPressed;

    [Tooltip("This character is the one most recently added to the screen")]
    public static string latestAddition;

    bool idle;


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

    VRTK_PhysicsPusher BackSpace;


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
        if (A.AtMaxLimit())
        {
            //This takes the last char and compares if it is _ by changing text and _ to CharArray first
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length-1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length-1);
            }
            MonitorScreen.text += "A";
            buttonBeingPressed = true;
            latestAddition = "A";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (B.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "B";
            buttonBeingPressed = true;
            latestAddition = "B";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (C.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "C";
            buttonBeingPressed = true;
            latestAddition = "C";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (D.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "D";
            buttonBeingPressed = true;
            latestAddition = "D";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (E.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "E";
            buttonBeingPressed = true;
            latestAddition = "E";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (F.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "F";
            buttonBeingPressed = true;
            latestAddition = "F";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (G.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "G";
            buttonBeingPressed = true;
            latestAddition = "G";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (H.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "H";
            buttonBeingPressed = true;
            latestAddition = "H";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (I.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "I";
            buttonBeingPressed = true;
            latestAddition = "I";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (J.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "J";
            buttonBeingPressed = true;
            latestAddition = "J";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (K.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "K";
            buttonBeingPressed = true;
            latestAddition = "K";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (L.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "L";
            buttonBeingPressed = true;
            latestAddition = "L";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (M.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "M";
            buttonBeingPressed = true;
            latestAddition = "M";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (N.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "N";
            buttonBeingPressed = true;
            latestAddition = "N";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (O.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "O";
            buttonBeingPressed = true;
            latestAddition = "O";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (P.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "P";
            buttonBeingPressed = true;
            latestAddition = "P";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Q.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Q";
            buttonBeingPressed = true;
            latestAddition = "Q";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (R.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "R";
            buttonBeingPressed = true;
            latestAddition = "R";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (S.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "S";
            buttonBeingPressed = true;
            latestAddition = "S";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (T.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "T";
            buttonBeingPressed = true;
            latestAddition = "T";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (U.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "U";
            buttonBeingPressed = true;
            latestAddition = "U";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (V.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "V";
            buttonBeingPressed = true;
            latestAddition = "V";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (W.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "W";
            buttonBeingPressed = true;
            latestAddition = "W";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (X.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "X";
            buttonBeingPressed = true;
            latestAddition = "X";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Y.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Y";
            buttonBeingPressed = true;
            latestAddition = "Y";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Z.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Z";
            buttonBeingPressed = true;
            latestAddition = "Z";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Å.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Å";
            buttonBeingPressed = true;
            latestAddition = "Å";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Ä.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Ä";
            buttonBeingPressed = true;
            latestAddition = "Ä";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
        if (Ö.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text += "Ö";
            buttonBeingPressed = true;
            latestAddition = "Ö";
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }

        if (BackSpace.AtMaxLimit())
        {
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character
            MonitorScreen.text.Remove(MonitorScreen.text.Length-1);
            buttonBeingPressed = true;
            StopAllCoroutines();
            StartCoroutine("IdleCheck");
        }
    }

    //creates a line which appears and disappears like waiting for more text
    IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            MonitorScreen.text += "_";
            yield return new WaitForSecondsRealtime(0.1f);
            if (!buttonBeingPressed)
            {
                MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                Debug.Log("removechar");
            }
            yield return new WaitForSecondsRealtime(0.1f);         
        }
        if (buttonBeingPressed)  
        {
            idle = false;
        }
    }
    //waits for 3 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(3f);
        buttonBeingPressed = false;
        idle = false;
    }
}
