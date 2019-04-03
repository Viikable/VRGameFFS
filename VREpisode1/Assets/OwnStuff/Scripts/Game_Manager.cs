namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Game_Manager : MonoBehaviour
    {
        //just gonna collect loads of static variables here pm
        [Header("Events")]

        //[Tooltip("an event which takes care of water movement starting")]
        //public UnityEngine.Events.UnityEvent WaterComes;

        [Header("Booleans")]
        [SerializeField]
        [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
        private bool isBroom1Snapped;

        [SerializeField]
        [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
        private bool isBroom2Snapped;

        [SerializeField]
        [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
        private bool isBroom3Snapped;

        [SerializeField]
        [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
        private bool isBroom4Snapped;

        [SerializeField]
        [Tooltip("checks if broom is still wood or not")]
        private bool isBroom1Metallic;

        [SerializeField]
        [Tooltip("checks if broom is still wood or not")]
        private bool isBroom2Metallic;

        [SerializeField]
        [Tooltip("checks if broom is still wood or not")]
        private bool isBroom3Metallic;

        [SerializeField]
        [Tooltip("checks if broom is still wood or not")]
        private bool isBroom4Metallic;

        [SerializeField]
        [Tooltip("checks if broom is ready to start the door cracking animation")]
        private bool playBroomAnimation;

        [SerializeField]
        [Tooltip("checks if the water has started moving or not")]
        private bool invoked;

        [SerializeField]
        [Tooltip("checks if the lantern is grabbed by the player or not")]
        private bool lanternIsGrabbed;

        [SerializeField]
        [Tooltip("checks if the lantern light is on or not")]
        private bool lanternLightIsOn;

        [SerializeField]
        [Tooltip("checks if rope is currently attatched to the manual or not")]
        private bool ropeIsAttatchedToManual;

        [SerializeField]
        [Tooltip("Toggles between climbable rope and grabbable rope")]
        private bool ropeClimb;

        [Header("Integers")]
        [SerializeField]
        private int numberOfTheBroom;

        [SerializeField]
        [Tooltip("Toggles between climbable rope and grabbable rope")]
        private int elevatorMoving;


        [SerializeField]
        private WaterMovement water;

        [Header("Gameobjects")]

        public GameObject Lantern;

        public GameObject GrabbableWater;

        public GameObject Broom1;

        public GameObject Broom2;

        public GameObject Broom3;

        public GameObject Broom4;

        public GameObject AttachedRopeToManual;

        public GameObject JuhaniHead;

        public GameObject JuhaniBody;

        public GameObject JuhaniHand1;

        public GameObject JuhaniHand2;

        public GameObject JuhaniLeg1;

        public GameObject JuhaniLeg2;

        public GameObject RightController;

        public GameObject LeftController;

        VRTK_InteractGrab RightGrab;

        VRTK_InteractGrab LeftGrab;

        public static Game_Manager instance = null;

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

            ropeClimb = true;

            isBroom1Snapped = false;

            isBroom2Snapped = false;

            isBroom3Snapped = false;

            isBroom4Snapped = false;

            isBroom1Metallic = false;

            isBroom2Metallic = false;

            isBroom3Metallic = false;

            isBroom4Metallic = false;

            playBroomAnimation = false;

            lanternIsGrabbed = false;

            lanternLightIsOn = false;

            ropeIsAttatchedToManual = false;

            invoked = false;

            elevatorMoving = 0;

            numberOfTheBroom = 0;

            Broom1 = GameObject.Find("BroomInTheJanitorHouse1");

            Broom2 = GameObject.Find("BroomInTheJanitorHouse2");

            Broom3 = GameObject.Find("BroomInTheJanitorHouse3");

            Broom4 = GameObject.Find("BroomInTheJanitorHouse4");

            JuhaniBody = GameObject.Find("JuhaniBody");

            JuhaniHead = GameObject.Find("JuhaniHead");

            JuhaniHand1 = GameObject.Find("JuhaniHand1");

            JuhaniHand2 = GameObject.Find("JuhaniHand2");

            JuhaniLeg1 = GameObject.Find("JuhaniLeg1");

            JuhaniLeg2 = GameObject.Find("JuhaniLeg2");

            RightController = GameObject.Find("RightController");

            LeftController = GameObject.Find("LeftController");

            RightGrab = RightController.GetComponent<VRTK_InteractGrab>();

            LeftGrab = LeftController.GetComponent<VRTK_InteractGrab>();

            Lantern = GameObject.Find("Lantern");

            GrabbableWater = GameObject.Find("GrabbableWater");

            water = GameObject.Find("Water").GetComponent<WaterMovement>();
        }
        //OTHER METHODS THAN GETTERS AND SETTERS OR ANIMATION STARTERS HERE!
        private void Update()
        {          
            CheckGrabbedObjects();
        }
        private void WaterIsRising()
        {

            water.WaterRises = true;
        }       
        public void CheckGrabbedObjects()
        {
            if (RightGrab.GetGrabbedObject() != null)
            {
                if (RightGrab.GetGrabbedObject() == Lantern)
                {
                    lanternIsGrabbed = true;
                    if (invoked)
                    {
                        water.WaterRises = true;
                        invoked = false;
                        Debug.Log("invoked");
                    }
                }
            }          
            else if (LeftGrab.GetGrabbedObject() != null)
            {
                if (LeftGrab.GetGrabbedObject() == Lantern)
                {
                    lanternIsGrabbed = true;
                    if (invoked)
                    {
                        water.WaterRises = true;
                        invoked = false;
                        Debug.Log("invoked");
                    }
                }
            }
            else
            {
                lanternIsGrabbed = false;
            }       
            if (RightGrab.GetGrabbedObject() != null && RightGrab.GetGrabbedObject().name == "JuhaniBody" && JuhaniHead.GetComponent<ConfigurableJoint>() != null)
            {
                RightGrab.ForceRelease();
                foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
                {
                Destroy(juhaniJoin);
                }                                                         
                RopeClimb = false;
            }
            else if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject().name == "JuhaniBody" && JuhaniHead.GetComponent<ConfigurableJoint>() != null)
            {
                LeftGrab.ForceRelease();
                foreach (ConfigurableJoint juhaniJoin in JuhaniHead.GetComponents<ConfigurableJoint>())
                {
                    Destroy(juhaniJoin);
                }
                RopeClimb = false;
            }
            if (RightGrab.GetGrabbedObject() != null  && RightGrab.GetGrabbedObject() == GrabbableWater)
            {               
                    Debug.Log("grabbedWater");
                    StartCoroutine(WaitForSecondsRealtime());               
            }           
            else if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject() == GrabbableWater)
            {               
                    Debug.Log("grabbedWater");
                    StartCoroutine(WaitForSecondsRealtime());               
            }
        }
        IEnumerator WaitForSecondsRealtime()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            StartCoroutine(ReleaseOrNot());
        }
        IEnumerator ReleaseOrNot()
        {
            if (RightGrab.GetGrabbedObject() != null && RightGrab.GetGrabbedObject() == GrabbableWater)
            {
                    Debug.Log("ReleasedWater");
                    RightGrab.ForceRelease();               
            }
            else if (LeftGrab.GetGrabbedObject() != null && LeftGrab.GetGrabbedObject() == GrabbableWater)
            {               
                    LeftGrab.ForceRelease();                
            }
            else
            {
                yield return null;
            }
        }

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
            get { return lanternIsGrabbed; }

            set { lanternIsGrabbed = value; }
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
}

