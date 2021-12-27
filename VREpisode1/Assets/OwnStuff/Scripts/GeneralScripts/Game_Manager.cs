using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class Game_Manager : MonoBehaviour
{
    //just gonna collect loads of static variables here pm
    [Header("Events")]

    //[Tooltip("an event which takes care of water movement starting")]
    //public UnityEngine.Events.UnityEvent WaterComes;

    [Header("Booleans")]

    [SerializeField]
    [Tooltip("checks if the touchpad is pressed for locomotion")]
    private bool locomotionOn;

    [SerializeField]
    [Tooltip("checks if the octomarker is being unsnapped from a snapzone")]
    public bool beingUnSnapped;

    [SerializeField]
    [Tooltip("checks if broom is ready to start the door cracking animation")]
    private bool playBroomAnimation;

    [SerializeField]
    [Tooltip("checks if the water has started moving or not")]
    private bool invoked;

    [SerializeField]
    [Tooltip("checks if the lantern is grabbed by the player or not")]
    private bool lanternIsGrabbedFirstTime;

    [SerializeField]
    [Tooltip("checks if the lantern light is on or not")]
    private bool lanternLightIsOn;

    [SerializeField]
    [Tooltip("Toggles between climbable rope and grabbable rope")]
    private bool ropeClimb;

    //[Header("Integers")]
    //[SerializeField]
    //private int numberOfTheBroom;

    //[SerializeField]
    [Tooltip("Toggles between climbable rope and grabbable rope")]
    private int elevatorMoving;

    private bool objectNotGrabbedYetRight;

    private bool objectNotGrabbedYetLeft;

    private bool playerPositionChanged;

    private float playerPositionChangeAmount;

    private Vector3 currentPlayerPosition;

    private Vector3 currentGrabbedObjectLocalPosition;

    AudioSource LeftWaterPush;
    AudioSource RightWaterPush;

    [Header("Gameobjects")]


    public GameObject Lantern;

    public GameObject GrabbableWater;

    public GameObject JuhaniHead;

    public GameObject JuhaniBody;

    public GameObject JuhaniHand1;

    public GameObject JuhaniHand2;

    public GameObject JuhaniLeg1;

    public GameObject JuhaniLeg2;

    public GameObject Noose;

    public GameObject RightController;

    public GameObject LeftController;

    public GameObject RightHand;

    public GameObject LeftHand;

    public GameObject previousLeftGrabbedObject;

    public GameObject previousRightGrabbedObject;

    [Header("Other")]

    [SerializeField]
    private WaterMovement water;

    public ParticleSystem WaterBubbles;

    public XRDirectInteractor RightGrab;

    public XRDirectInteractor LeftGrab;

    public static Game_Manager instance = null;

    [Header("Audio")]

    public AudioSource RopeCreak;

    public AudioSource WaterBreakingSound;

    bool notIgnoredYet;

    public Transform GrabAttachPointRight;

    public Transform GrabAttachPointLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

        //WaterComes.AddListener(WaterIsRising);

        if (GameObject.Find("Water") != null)
        {

            WaterBubbles = GameObject.Find("Water").GetComponentInChildren<ParticleSystem>();

            WaterBubbles.Pause();

            LeftWaterPush = GameObject.Find("LeftWaterPush").GetComponent<AudioSource>();

            RightWaterPush = GameObject.Find("RightWaterPush").GetComponent<AudioSource>();

            Lantern = GameObject.Find("Lantern");

            GrabbableWater = GameObject.Find("GrabbableWater");

            water = GameObject.Find("Water").GetComponent<WaterMovement>();
        }

        ropeClimb = true;

        playBroomAnimation = false;

        lanternIsGrabbedFirstTime = false;

        lanternLightIsOn = false;

        beingUnSnapped = false;

        invoked = true;

        elevatorMoving = 0;

        //numberOfTheBroom = 0;

        playerPositionChanged = false;

        playerPositionChangeAmount = 0f;

        locomotionOn = false;

        objectNotGrabbedYetRight = true;

        objectNotGrabbedYetLeft = true;

        currentGrabbedObjectLocalPosition = new Vector3(0, 0, 0);

        if (GameObject.Find("JuhaniBody") != null)
        {
            JuhaniBody = GameObject.Find("JuhaniBody");

            JuhaniHead = GameObject.Find("JuhaniHead");

            JuhaniHand1 = GameObject.Find("JuhaniHand1");

            JuhaniHand2 = GameObject.Find("JuhaniHand2");

            JuhaniLeg1 = GameObject.Find("JuhaniLeg1");

            JuhaniLeg2 = GameObject.Find("JuhaniLeg2");
        }

        Noose = GameObject.Find("NOOSE");

        if (Noose != null)
        {
            RopeCreak = Noose.GetComponent<AudioSource>();
        }

        WaterBreakingSound = GetComponent<AudioSource>();

        RightController = GameObject.Find("RightController");

        LeftController = GameObject.Find("LeftController");

        RightHand = RightController.transform.GetChild(0).gameObject;

        LeftHand = LeftController.transform.GetChild(0).gameObject;

        RightGrab = RightController.GetComponent<XRDirectInteractor>();

        LeftGrab = LeftController.GetComponent<XRDirectInteractor>();

        notIgnoredYet = true;

        GrabAttachPointLeft = LeftGrab.transform.GetChild(0).GetChild(1).transform;

        GrabAttachPointRight = RightGrab.transform.GetChild(0).GetChild(1).transform;
    }


    /// <summary>
    /// /ENABLED FUNCTIONALITY OF EVENTS
    /// </summary>
    /// this all needs to be changed to use input actions
    protected void OnEnable()
    {
        //if (LeftController != null)
        //{
        //    leftController.TouchpadPressed += LocomotionOn;
        //    leftController.TouchpadReleased += LocomotionOff;
        //}

        //if (RightController != null)
        //{
        //    rightController.TouchpadPressed += LocomotionOn;
        //    rightController.TouchpadReleased += LocomotionOff;
        //}
        //if (LeftGrab != null)
        //{
        //    LeftGrab.ControllerGrabInteractableObject += RegisterGrabbedObjectLocalPositionWhenGrabbingLeft;
        //    LeftGrab.ControllerUngrabInteractableObject += RegisterObjectDropLeft;
        //}
        //if (RightGrab != null)
        //{
        //    RightGrab.ControllerGrabInteractableObject += RegisterGrabbedObjectLocalPositionWhenGrabbingRight;
        //    RightGrab.ControllerUngrabInteractableObject += RegisterObjectDropRight;
        //}
    }
    //OTHER METHODS THAN GETTERS AND SETTERS OR ANIMATION STARTERS HERE!
    private void FixedUpdate()
    {
        //CheckGrabbedObjects();

        //if (locomotionOn)
        //{
        //    //Debug.Log("resettingLocalpos");
        //    CheckGrabbedObjectLocalPositionStays();
        //}

        //if (Time.time >= 0.75f && notIgnoredYet)
        //{
        //    notIgnoredYet = false;
        //    IgnoreObjectCollisionsWithPlayer();
        //}
    }
    private void IgnoreObjectCollisionsWithPlayer()
    {
        //foreach (XRGrabInteractable inter in FindObjectsOfType<XRGrabInteractable>())
        //{
        //    if (inter.GetComponent<Collider>() != null && WaterMovement.feet != null)
        //    {
        //        Physics.IgnoreCollision(WaterMovement.feet, inter.GetComponent<Collider>());
        //        Physics.IgnoreCollision(WaterMovement.body, inter.GetComponent<Collider>());
        //        Physics.IgnoreCollision(WaterMovement.head, inter.GetComponent<Collider>());
        //    }
        //    if (inter.GetComponentsInChildren<Collider>() != null && WaterMovement.feet != null)
        //    {
        //        foreach (Collider col in inter.GetComponentsInChildren<Collider>())
        //        {
        //            Physics.IgnoreCollision(WaterMovement.feet, col);                    //testing reasons
        //            Physics.IgnoreCollision(WaterMovement.body, col);
        //            Physics.IgnoreCollision(WaterMovement.head, col);
        //            //Debug.Log(col.gameObject.name);
        //        }
        //    }
        //}
    }

    private void WaterIsRising()
    {
        water.WaterRises = true;
    }
    public void CheckGrabbedObjects()
    {
        //RIGHT HAND GRABBED OBJECTS
        if (RightGrab.firstInteractableSelected != null)
        {
            previousRightGrabbedObject = RightGrab.firstInteractableSelected.transform.gameObject;
            if (RightGrab.firstInteractableSelected.Equals(Lantern))
            {
                lanternIsGrabbedFirstTime = true;
                if (invoked)
                {
                    WaterBreakingSound.Play();
                    WaterBubbles.Play();
                    water.UnderwaterAmbience1.Play();
                    water.UnderwaterAmbience2.Play();
                    water.UnderwaterAmbience3.Play();
                    water.UnderwaterAmbience4.Play();
                    water.WaterRises = true;
                    invoked = false;
                    ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.SecondShaft;
                }
            }
            else if (RightGrab.firstInteractableSelected.Equals( JuhaniBody && JuhaniHead.GetComponent<ConfigurableJoint>() != null))
            {
                RightGrab.EndManualInteraction();
                ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.FirstShaft;
                foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
                {
                    Destroy(juhaniJoin);
                }
                foreach (ConfigurableJoint headNoose in Noose.GetComponents<ConfigurableJoint>())
                {
                    if (headNoose.connectedBody.name == "JuhaniHead" || headNoose.connectedBody.name == "Bone_chest")
                    {
                        Destroy(headNoose);
                    }
                }
                RopeClimb = false;
                RopeCreak.Stop();
                JuhaniBody.GetComponent<Rigidbody>().mass = 1000;
                JuhaniBody.GetComponent<Rigidbody>().drag = 1.5f;
                JuhaniBody.GetComponent<Rigidbody>().angularDrag = 1.5f;
                foreach (Rigidbody Juhanirigidpart in JuhaniBody.GetComponentsInChildren<Rigidbody>())
                {
                    Juhanirigidpart.mass = 1000;
                    Juhanirigidpart.drag = 1.5f;
                    Juhanirigidpart.angularDrag = 1.5f;
                }
            }
            else if (RightGrab.firstInteractableSelected.Equals(GrabbableWater))
            {
                if (!RightWaterPush.isPlaying)
                {
                    RightWaterPush.Play();
                }
                StartCoroutine(WaitForSecondsRealtimeRight());
            }
            else if (RightGrab.firstInteractableSelected.transform.gameObject.CompareTag("FloatingObject"))
            {
                //the floating object goes down but less if other hand was already grabbing it
                if (previousLeftGrabbedObject != RightGrab.firstInteractableSelected.transform.gameObject)
                {
                    if (RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                    else if (RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                    else if (RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                }
                else
                {
                    if (RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                    else if (RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                    else if (RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>() != null)
                    {
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //RightGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        RightGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                }
            }
        }
        //LEFT HAND GRABBED OBJECTS
        if (LeftGrab.firstInteractableSelected.transform.gameObject != null)
        {
            previousLeftGrabbedObject = LeftGrab.firstInteractableSelected.transform.gameObject;
            if (LeftGrab.firstInteractableSelected.Equals(Lantern))
            {
                lanternIsGrabbedFirstTime = true;
                if (invoked)
                {
                    WaterBreakingSound.Play();
                    WaterBubbles.Play();
                    water.UnderwaterAmbience1.Play();
                    water.UnderwaterAmbience2.Play();
                    water.UnderwaterAmbience3.Play();
                    water.UnderwaterAmbience4.Play();
                    water.WaterRises = true;
                    invoked = false;
                    ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.SecondShaft;
                }
            }
            else if (LeftGrab.firstInteractableSelected.Equals( JuhaniBody && JuhaniHead.GetComponent<ConfigurableJoint>() != null))
            {
                LeftGrab.EndManualInteraction();
                ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.FirstShaft;
                foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
                {
                    Destroy(juhaniJoin);
                }
                foreach (ConfigurableJoint headNoose in Noose.GetComponents<ConfigurableJoint>())
                {
                    if (headNoose.connectedBody.name == "JuhaniHead" || headNoose.connectedBody.name == "Bone_chest")
                    {
                        Destroy(headNoose);
                    }
                }
                RopeClimb = false;
                RopeCreak.Stop();
                JuhaniBody.GetComponent<Rigidbody>().mass = 1000;
                JuhaniBody.GetComponent<Rigidbody>().drag = 1.5f;
                JuhaniBody.GetComponent<Rigidbody>().angularDrag = 1.5f;
                foreach (Rigidbody Juhanirigidpart in JuhaniBody.GetComponentsInChildren<Rigidbody>())
                {
                    Juhanirigidpart.mass = 1000;
                    Juhanirigidpart.drag = 1.5f;
                    Juhanirigidpart.angularDrag = 1.5f;
                }
            }
            else if (LeftGrab.firstInteractableSelected.Equals( GrabbableWater))
            {
                if (!LeftWaterPush.isPlaying)
                {
                    LeftWaterPush.Play();
                }
                StartCoroutine(WaitForSecondsRealtimeLeft());
            }
            else if (LeftGrab.firstInteractableSelected.transform.gameObject.CompareTag("FloatingObject"))
            {
                if (previousRightGrabbedObject != LeftGrab.firstInteractableSelected.transform.gameObject)
                {
                    if (LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                    else if (LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                    else if (LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 3.5f, ForceMode.Impulse);
                    }
                }
                else
                {
                    if (LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                    else if (LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                    else if (LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>() != null)
                    {
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        //LeftGrab.firstInteractableSelected.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        LeftGrab.firstInteractableSelected.transform.gameObject.transform.parent.parent.GetComponent<Rigidbody>().AddForce(Vector3.down * 1.5f, ForceMode.Impulse);
                    }
                }
            }
        }         
    }
    
    IEnumerator WaitForSecondsRealtimeRight()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        StartCoroutine(ReleaseOrNotRight());
    }
    IEnumerator WaitForSecondsRealtimeLeft()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        StartCoroutine(ReleaseOrNotLeft());
    }
    IEnumerator ReleaseOrNotRight()
    {
        if (RightGrab.firstInteractableSelected.transform.gameObject != null && RightGrab.firstInteractableSelected.Equals(GrabbableWater))
        {
            Debug.Log("ReleasedWater");
            RightGrab.EndManualInteraction();          
            ToxicGasPush.PlayerBody.AddForce(Vector3.down * 7.5f, ForceMode.Impulse);
        }
        else
        {
            ToxicGasPush.PlayerBody.AddForce(Vector3.down * 7.5f, ForceMode.Impulse);
            yield return null;
        }
    }
    IEnumerator ReleaseOrNotLeft()
    {
        if (LeftGrab.firstInteractableSelected.transform.gameObject != null && LeftGrab.firstInteractableSelected.Equals(GrabbableWater))
        {
            ToxicGasPush.PlayerBody.AddForce(Vector3.down * 7.5f, ForceMode.Impulse);
            LeftGrab.EndManualInteraction();           
        }
        else
        {
            ToxicGasPush.PlayerBody.AddForce(Vector3.down * 7.5f, ForceMode.Impulse);
            yield return null;
        }      
    }
    //get grabbed object position
   
    //GETTERS AND SETTERS PART BELOW HERE!

    public int ElevatorMoving
    {
        get { return elevatorMoving; }

        set { elevatorMoving = value; }
    }

    public bool RopeClimb
    {
        get { return ropeClimb; }

        set { ropeClimb = value; }
    }

    public bool IsLanternGrabbed
    {
        get { return lanternIsGrabbedFirstTime; }

        set { lanternIsGrabbedFirstTime = value; }
    }

    public bool LanternLightIsOn
    {
        get { return lanternLightIsOn; }

        set { LanternLightIsOn = value; }
    }

    public bool Invoked
    {
        get { return invoked; }

        set { invoked = value; }
    }
}


