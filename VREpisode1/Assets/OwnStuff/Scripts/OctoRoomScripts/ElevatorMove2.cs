
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;


public class ElevatorMove2 : MonoBehaviour
{

    [Header("Elevator Sounds")]

    public AudioSource elevatorStops;

    public AudioSource elevatorUp;

    public AudioSource elevatorDown;

    public AudioSource elevatorOpens;

    public AudioSource elevatorCloses;

    private Animator elevAnim;

    bool wtf;

    bool elevatorMovingDown;

    bool elevatorMovingUp;

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
        wtf = true;
        elevatorMovingDown = false;
        elevatorMovingUp = false;

    }
    public void CheckButtonPress()
    {
        if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed && Game_Manager.instance.ElevatorMoving == 0 && !elevatorMovingDown && canGoUp)
        {           
            Game_Manager.instance.ElevatorMoving = 2;        //moves UP                       
            if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
            {
                ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("elevator1when2");
            }
        }
        else if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            StartCoroutine("niceCoding");
        }
        if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed && Game_Manager.instance.ElevatorMoving == 0 && !elevatorMovingUp && canMoveDown)
        {          
                Game_Manager.instance.ElevatorMoving = 1;      //moves DOWN
                Debug.Log("elevator2");                         
            if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
            {
                ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            }
        }
        else if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            StartCoroutine("niceCoding");
        }
    }
    IEnumerator niceCoding()
    {
        yield return new WaitForSecondsRealtime(1f);
        ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
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

        if (Game_Manager.instance.ElevatorMoving == 0 && !positionChecked)
        {
            Debug.Log("elevatorStill");
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
        else if (Game_Manager.instance.ElevatorMoving == 1 && canMoveDown)
        {
            Debug.Log("elevatorMovingdown");
            elevatorMovingDown = true;
            elevAnim.SetBool("Open", false);
            elevAnim.SetBool("Close", true);          //door opens with the code and closes when button pressed inside
            if (wtf)
            {
                wtf = false;
                elevatorCloses.Play();
                StartCoroutine("WaitForDoor");
            }
            if (doorHasOpened)
            {
                if (!elevatorDown.isPlaying)
                {
                    elevatorDown.Play();
                }
                this.transform.Translate(Vector3.up * 3.85f * Time.deltaTime, Space.World);
                positionChecked = false;
                StopAllCoroutines();
            }
        }
        else if (Game_Manager.instance.ElevatorMoving == 2 && canGoUp)
        {

            Debug.Log("elevatorMovingUp");
            elevatorMovingUp = true;
            elevAnim.SetBool("Open", false);
            elevAnim.SetBool("BackClose", true);
            elevAnim.SetBool("Close", false);
            StartCoroutine("WaitForDoor");
            if (doorHasOpened)
            {
                if (!elevatorUp.isPlaying)
                {
                    elevatorUp.Play();
                }
                this.transform.Translate(Vector3.down * 3.85f * Time.deltaTime, Space.World);
                positionChecked = false;
                StopAllCoroutines();
            }
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
            elevatorDown.Stop();
            elevatorUp.Stop();
            elevatorMovingDown = false;
            elevatorMovingUp = false;
            Debug.Log("stopped");
            if (canMoveDown)
            {
                ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                Debug.Log("Backdoor opens");
                elevAnim.SetBool("BackClose", false);
                elevAnim.SetBool("BackOpen", true);
                elevAnim.SetBool("Open", false);
                StartCoroutine("WaitForDoor2");
            }
            else if (canGoUp)
            {
                ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                Debug.Log("Front door opens");
                elevAnim.SetBool("Close", false);
                elevAnim.SetBool("Open", true);
                elevAnim.SetBool("BackOpen", false);
                StartCoroutine("WaitForDoor2");
            }
            Game_Manager.instance.ElevatorMoving = 0;
        }
    }
    IEnumerator WaitForDoor()
    {
        yield return new WaitForSeconds(4);
        doorHasOpened = true;       
    }
    IEnumerator WaitForDoor2()
    {
        yield return new WaitForSeconds(1);
        elevatorOpens.Play();       
    }
}

