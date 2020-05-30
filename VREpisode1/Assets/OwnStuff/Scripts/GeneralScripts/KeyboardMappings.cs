using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;
using System;
using System.Text;
using UnityEngine.UI;

public class KeyboardMappings : MonoBehaviour {

    //Is the current monitor going to be active based on fusebox setting or not
    protected static bool machineryActive;

    //MONITOR SCREEN
    protected TextMeshProUGUI MonitorScreen;

    protected Scrollbar bar;

    //CONTROL VARIABLES
    [Tooltip("Indicates if any buttons are currently being pressed," +
    "this so that the monitor can go to sleep mode or do an idle animation when a certain time occurs without presses")]
    public bool buttonBeingPressed;

    [SerializeField]
    [Tooltip("Stores all the characters which are added to the current command, resetted and checked by pressing Enter")]
    public StringBuilder addedCharacters;

    [Tooltip("Indexes the characters in the addedCharacters StringBuilder so that the commands can be easily interperated no matter how much text on screen")]
    public int characterCount;

    [Tooltip("This tells whether the terminal is on idle mode or not, in idle mode the _ starts showing on and off")]
    public bool idle;

    [Tooltip("CAPS on or off")]  //commands are not case-sensitive currently, like in a real terminal
    public bool caps; 
 
    //ALPHABET
    protected VRTK_PhysicsPusher A;
    protected VRTK_PhysicsPusher B;
    protected VRTK_PhysicsPusher C;
    protected VRTK_PhysicsPusher D;
    protected VRTK_PhysicsPusher E;
    protected VRTK_PhysicsPusher F;
    protected VRTK_PhysicsPusher G;
    protected VRTK_PhysicsPusher H;
    protected VRTK_PhysicsPusher I;
    protected VRTK_PhysicsPusher J;
    protected VRTK_PhysicsPusher K;
    protected VRTK_PhysicsPusher L;
    protected VRTK_PhysicsPusher M;
    protected VRTK_PhysicsPusher N;
    protected VRTK_PhysicsPusher O;
    protected VRTK_PhysicsPusher P;
    protected VRTK_PhysicsPusher Q;
    protected VRTK_PhysicsPusher R;
    protected VRTK_PhysicsPusher S;
    protected VRTK_PhysicsPusher T;
    protected VRTK_PhysicsPusher U;
    protected VRTK_PhysicsPusher V;
    protected VRTK_PhysicsPusher W;
    protected VRTK_PhysicsPusher X;
    protected VRTK_PhysicsPusher Y;
    protected VRTK_PhysicsPusher Z;
    protected VRTK_PhysicsPusher Å;
    protected VRTK_PhysicsPusher Ä;
    protected VRTK_PhysicsPusher Ö;


    //Special control buttons
    protected VRTK_PhysicsPusher BackSpace;
    protected VRTK_PhysicsPusher Enter;
    protected VRTK_PhysicsPusher CapsLock;
    protected VRTK_PhysicsPusher Tab;
    protected VRTK_PhysicsPusher Space;
    protected VRTK_PhysicsPusher Shift_Left;
    protected VRTK_PhysicsPusher Shift_Right;
    protected VRTK_PhysicsPusher Delete;
    protected VRTK_PhysicsPusher Escape;

    // for scrolling the expanded command list
    protected VRTK_PhysicsPusher Down;
    protected VRTK_PhysicsPusher Up;


    protected virtual void Start ()
    {
        machineryActive = false;

        //MONITOR SCREEN
        MonitorScreen = GameObject.Find("MonitorCanvas/Scrollparent/Viewport/MonitorScreen").GetComponent<TextMeshProUGUI>();

        bar = GameObject.Find("MonitorCanvas/Scrollparent/Scrollbar").GetComponent<Scrollbar>();

        //CONTROL VARIABLES
        buttonBeingPressed = false;
      
        characterCount = 0;

        addedCharacters = new StringBuilder();

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


        //CONTROL BUTTONS
        BackSpace = transform.Find("BACKSPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        CapsLock = transform.Find("CAPSLOCK_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Enter = transform.Find("ENTER_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Space = transform.Find("SPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Delete = transform.Find("DELETE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Escape = transform.Find("ESC_Container").GetComponentInChildren<VRTK_PhysicsPusher>();

        Down = transform.Find("DOWN_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Up = transform.Find("UP_Container").GetComponentInChildren<VRTK_PhysicsPusher>();

        //STARTLINE fixes text lining up correctly
        MonitorScreen.text = "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
    }
	
	
	protected virtual void Update ()
    {
        //if machinery is off then shows no text and doesn't react to buttonpresses
        if (machineryActive)
        {
            MonitorButtonPressCheck();
            if (!buttonBeingPressed && !idle)
            {
                idle = true;
                StartCoroutine("IdleAnimation");
            }           
        }
        else
        {
            StopAllCoroutines();
            MonitorScreen.text = "";
        }
	}

    protected void MonitorButtonPressCheck()
    {
        if (A.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            //This takes the last char and compares if it is _ by changing text and _ to CharArray first
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "A";
            }
            else
            {
                MonitorScreen.text += "a";
            }
            addedCharacters.Append("A");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (B.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("B");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (C.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("C");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (D.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("D");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (E.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("E");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (F.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("F");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (G.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("G");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (H.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("H");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (I.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("I");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (J.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("J");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (K.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("K");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (L.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("L");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (M.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("M");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (N.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("N");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (O.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("O");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (P.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("P");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Q.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Q");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (R.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("R");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (S.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("S");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (T.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("T");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (U.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("U");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (V.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("V");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (W.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("W");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (X.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("X");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Y.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Y");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Z.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Z");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Å.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Å");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Ä.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Ä");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (Ö.AtMaxLimit() && !buttonBeingPressed)
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
            addedCharacters.Append("Ö");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        //Special control buttons
        else if ((BackSpace.AtMaxLimit() || Delete.AtMaxLimit()) && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character, but keeps a space between the start and § 
            if (MonitorScreen.text.Length != 0 && addedCharacters.Length > 0)
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character and shortens characterCount to match
            if (addedCharacters.Length > 0)
            {
            addedCharacters.Remove(addedCharacters.Length - 1, 1);
            characterCount--;
            }
            StartCoroutine("IdleCheck");
        }
        else if (Space.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }

            MonitorScreen.text += " ";
            addedCharacters.Append(" ");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        else if (CapsLock.AtMaxLimit() && !buttonBeingPressed)
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
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            StartCoroutine("IdleCheck");
        }
        else if (Enter.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }                     
            MonitorScreen.text += Environment.NewLine;
            CodeCheck();
            StartCoroutine("BarDown");
            StartCoroutine("IdleCheck");
        }
        else if (Escape.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            MonitorScreen.text = "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ".ToString();
            StartCoroutine("IdleCheck");
        }
        else if (Down.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            bar.value -= 0.1f;        
            StartCoroutine("IdleCheck");
        }
        else if (Up.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            bar.value += 0.1f;
            StartCoroutine("IdleCheck");
        }
    }

    protected virtual void CodeCheck()
    {
        //no need to worry about CAPS as the characters are stored only as upper keys
        if (addedCharacters.ToString() == "CONSTART")
        {
            //starts the conveyorbelt
            MonitorScreen.text += " " + "CONVEYOR BELT STARTING..";
            MonitorScreen.text += Environment.NewLine + "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
        }
        else
        {
            MonitorScreen.text += " " + "COMMAND NOT FOUND";
            MonitorScreen.text += Environment.NewLine + "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
        }
        characterCount = 0;
        //clears the stringbuilder
        addedCharacters.Clear();       
    }

    //creates a line which appears and disappears like waiting for more text
    protected IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed && idle)
        {
            MonitorScreen.text += "_";
            
            yield return new WaitForSecondsRealtime(0.35f);

            if (!buttonBeingPressed && MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {               
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);              
            }
            yield return new WaitForSecondsRealtime(0.35f);           
        }   
    }
    //waits for 0.25 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    protected IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        buttonBeingPressed = false;
        idle = false;         //actually makes idle true as there is a clause in update for that, looks slightly confusing have to admit
    }  
    protected IEnumerator BarDown()
    {
        yield return new WaitForEndOfFrame();
        bar.value = 0f;
    }

    public static void ActivateMonitor()
    {
        machineryActive = true;
    }

    public static void DeactivateMonitor()
    {
        machineryActive = false;
    }
}
