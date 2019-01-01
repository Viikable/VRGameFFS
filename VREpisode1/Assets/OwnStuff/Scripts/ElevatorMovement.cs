
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;


public class ElevatorMovement : MonoBehaviour
    {

    [Header("Elevator Sounds")]

    public AudioSource elevatorStops;

    public AudioSource elevatorUp;

    public AudioSource elevatorDown;

    public AudioSource elevatorOpens;

    public AudioSource elevatorCloses;

    private Animator elevAnim;

    [SerializeField]
    [Tooltip("is Octocode correct")]
    private bool codeIsCorrect;

    [SerializeField]
    [Tooltip("is door animation finished")]
    private bool doorHasOpened;

    [SerializeField]
    [Tooltip("do we wanna go back to octoroom")]
    private bool weWannaGoBackUp;

    [SerializeField]
    [Tooltip("can we move up with elevator or not atm")]
    private bool canGoUp;

    [SerializeField]
    [Tooltip("can we move down with elevator or not atm")]
    private bool canMoveDown;

    [SerializeField]
    [Tooltip("are we up or down")]
    private bool positionChecked;
    
    public GameObject ElevatorButton1;

    public GameObject ElevatorButton2;

    public void CheckButtonPress()
    {
        if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().PressedDown && Game_Manager.instance.ElevatorMoving == 0)
        {
            if (canGoUp)
            {
                Game_Manager.instance.ElevatorMoving = 2;        //moves UP
            }
            if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("elevator1when2");
            }
        }
        if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().PressedDown && Game_Manager.instance.ElevatorMoving == 0)
        {
            if (canMoveDown)
            {
                Game_Manager.instance.ElevatorMoving = 1;      //moves DOWN
                Debug.Log("elevator2");
            }
            if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            }
        }
    }

    void Start()
        {
            canGoUp = false;
            canMoveDown = true;
            positionChecked = true;
            elevAnim = this.GetComponent<Animator>();
            weWannaGoBackUp = false;
            codeIsCorrect = true;
            doorHasOpened = false;
            ElevatorButton1 = GameObject.Find("ElevatorButton1");
            ElevatorButton2 = GameObject.Find("ElevatorButton2");

    }
        public bool CanGoUp
        {
            get { return canGoUp; }
            set { canGoUp = value; }
        }
        public bool CanMoveDown
        {
            get { return canMoveDown; }
        }
     
        void Update()
        {
            CheckButtonPress();      //checks whether the buttons are currently being pressed or not

            if (Game_Manager.instance.ElevatorMoving == 1 && canMoveDown)
            {
                //Debug.Log("elevatorMovingdown");
                elevAnim.SetBool("Open", false);
                elevAnim.SetBool("Close", true);          //door opens with the code and closes when button pressed inside
                StartCoroutine("WaitForDoor");
                if (doorHasOpened)
                {
                    elevatorDown.Play();
                    this.transform.Translate(Vector3.down * 1f * Time.deltaTime, Space.World);
                    positionChecked = false;
                }
            }
            else if (Game_Manager.instance.ElevatorMoving == 2 && canGoUp)
            {

                //Debug.Log("elevatorMovingUp");
                elevAnim.SetBool("Open", false);
                elevAnim.SetBool("BackClose", true);
                elevAnim.SetBool("Close", false);
                StartCoroutine("WaitForDoor");
                if (doorHasOpened)
                {
                    elevatorUp.Play();
                    this.transform.Translate(Vector3.up * 1f * Time.deltaTime, Space.World);
                    canMoveDown = false;
                    positionChecked = false;
                }

            }
            else if (Game_Manager.instance.ElevatorMoving == 0 && !positionChecked)
            {
                //Debug.Log("elevatorStill");
                if (canMoveDown)
                {
                    canMoveDown = false;
                }
                else
                {
                    canMoveDown = true;
                }

                if (canGoUp)
                {
                    canGoUp = false;                 
                }
                else
                {
                    canGoUp = true;
                }
                positionChecked = true;
                doorHasOpened = false;
            }
            else
            {
                //Debug.Log("no checks for elevator");
                return;
            }

            if (codeIsCorrect)
            {
            Debug.Log("koodi oikein");
                elevAnim.SetBool("Open", true);
                codeIsCorrect = false;
            }
            if (weWannaGoBackUp)
            {
                elevAnim.SetBool("BackOpen", true);
                weWannaGoBackUp = false;
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "ElevatorStopper" && Game_Manager.instance.ElevatorMoving != 0)
            {
                elevatorStops.Play();
                Debug.Log("stopped");
                if (canMoveDown)
                {
                    Debug.Log("Backdoor opens");                  
                    elevAnim.SetBool("BackClose", false);
                    elevAnim.SetBool("BackOpen", true);
                    //StartCoroutine("WaitForDoor");
                }
                else if (canGoUp)
                {
                    Debug.Log("Front door opens");                   
                    elevAnim.SetBool("Close", false);
                    elevAnim.SetBool("Open", true);
                    //StartCoroutine("WaitForDoor");
                }
                Game_Manager.instance.ElevatorMoving = 0;
            }
        }
        IEnumerator WaitForDoor()
        {
            yield return new WaitForSeconds(4);
            doorHasOpened = true;
        }
    }

