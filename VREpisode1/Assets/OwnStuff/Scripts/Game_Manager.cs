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

        public GameObject RightController;

        public GameObject LeftController;

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

            ropeClimb = false;

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

            RightController = GameObject.Find("RightController");

            LeftController = GameObject.Find("LeftController");

            Lantern = GameObject.Find("Lantern");

            GrabbableWater = GameObject.Find("GrabbableWater");

            water = GameObject.Find("Water").GetComponent<WaterMovement>();
        }


        //void FixedUpdate()          //currently not in use
        //{
        //    //Debug.Log(ropeIsAttatchedToManual);
        //    if (RopeIsAttachedToManual)
        //    {
        //        AttachedRopeToManual.SetActive(true);
        //        //Debug.Log("active");
        //    }
        //    else
        //    {
        //        AttachedRopeToManual.SetActive(false);
        //        //Debug.Log("inactive");
        //    }
        //}

        //OTHER METHODS THAN GETTERS AND SETTERS OR ANIMATION STARTERS HERE!
        private void Update()
        {
            //StopAllCoroutines();
            //CheckGrabbedObjects();
        }
        //private void WaterIsRising()
        //{

        //    water.WaterRises = true;
        //}

        //public void LightUpLantern()
        //{
        //    if (lanternIsGrabbed && !LanternLightIsOn)
        //    {
        //        Lantern.GetComponentInChildren<Light>().enabled = true;
        //        LanternLightIsOn = true;
        //        Debug.Log("Light");
        //    }
        //    else if (lanternIsGrabbed && LanternLightIsOn)
        //    {
        //        Lantern.GetComponentInChildren<Light>().enabled = false;
        //        LanternLightIsOn = false;
        //        Debug.Log("Dark");
        //    }           
        //}

        //public void CheckGrabbedObjects()
        //{
        //    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Lantern)
        //        {
        //            lanternIsGrabbed = true;
        //            if (invoked)
        //            {
        //                water.WaterRises = true;
        //                invoked = false;
        //                Debug.Log("invoked");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lanternIsGrabbed = false;
        //    }
        //    if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == Lantern)
        //        {
        //            lanternIsGrabbed = true;
        //            if (invoked)
        //            {
        //                water.WaterRises = true;
        //                invoked = false;
        //                Debug.Log("invoked");
        //            }
        //        }
        //    }        
        //    else
        //    {
        //        lanternIsGrabbed = false;
        //    }           

        //    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null && RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject().name == "KeyRope")
        //    {           //this checks to see if we want to change rope from grabbable to climbable
        //        RopeClimb = true;
        //        RightController.GetComponent<VRTK_InteractGrab>().ForceRelease();
        //    }
        //    else if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null && LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject().name == "KeyRope")
        //    {
        //        RopeClimb = true;
        //        LeftController.GetComponent<VRTK_InteractGrab>().ForceRelease();
        //    }

        //    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == GrabbableWater) 
        //        {

        //            Debug.Log("grabbedWater");
        //            StartCoroutine(WaitForSecondsRealtime());
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == GrabbableWater)
        //        {
        //            Debug.Log("grabbedWater");
        //            StartCoroutine(WaitForSecondsRealtime());
        //        }
        //    }
        //}       

        //IEnumerator WaitForSecondsRealtime()
        //{
        //    yield return new WaitForSecondsRealtime(0.5f);
        //    StartCoroutine(ReleaseOrNot());
        //}
        //IEnumerator ReleaseOrNot()
        //{
        //    if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (RightController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == GrabbableWater)
        //        {
        //            Debug.Log("ReleasedWater");
        //            RightController.GetComponent<VRTK_InteractGrab>().ForceRelease();
        //        }
        //    }
        //    else if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() != null)
        //    {
        //        if (LeftController.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == GrabbableWater)
        //        {
        //            LeftController.GetComponent<VRTK_InteractGrab>().ForceRelease();
        //        }
        //    }
        //    else
        //    {
        //        yield return null;
        //    }                
        //}

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

        public int NumberOfTheBroom
        {
            get { return numberOfTheBroom; }

            set { numberOfTheBroom = value; }
        }


        public bool IsBroomSnapped
        {
            get
            {
                if (numberOfTheBroom == 1)
                {
                    return isBroom1Snapped;
                }
                else if (numberOfTheBroom == 2)
                {
                    return isBroom2Snapped;
                }
                else if (numberOfTheBroom == 3)
                {
                    return isBroom3Snapped;
                }
                else if (numberOfTheBroom == 4)
                {
                    return isBroom4Snapped;
                }
                else
                {
                    Debug.Log("No Broom with this number exists");
                    throw new System.Exception("Invalid broom ID");
                }
            }
            set
            {
                if (numberOfTheBroom == 1)
                {
                    isBroom1Snapped = value;
                }
                else if (numberOfTheBroom == 2)
                {
                    isBroom2Snapped = value;
                }
                else if (numberOfTheBroom == 3)
                {
                    isBroom3Snapped = value;
                }
                else if (numberOfTheBroom == 4)
                {
                    isBroom4Snapped = value;
                }
                else
                {
                    Debug.Log("No Broom with this number exists");
                    throw new System.Exception("Invalid broom ID");
                }
            }
        }
        public bool IsBroomMetallic
        {
            get
            {

                if (numberOfTheBroom == 1)
                {
                    return isBroom1Metallic;
                }
                else if (numberOfTheBroom == 2)
                {
                    return isBroom2Metallic;
                }
                else if (numberOfTheBroom == 3)
                {
                    return isBroom3Metallic;
                }
                else if (numberOfTheBroom == 4)
                {
                    return isBroom4Metallic;
                }
                else
                {
                    Debug.Log("No Broom with this number exists");
                    throw new System.Exception("Invalid broom ID");
                }
            }
            set
            {
                if (numberOfTheBroom == 1)
                {
                    isBroom1Metallic = value;
                }
                else if (numberOfTheBroom == 2)
                {
                    isBroom2Metallic = value;
                }
                else if (numberOfTheBroom == 3)
                {
                    isBroom3Metallic = value;
                }
                else if (numberOfTheBroom == 4)
                {
                    isBroom4Metallic = value;
                }
                else
                {
                    Debug.Log("No Broom with this number exists");
                    throw new System.Exception("Invalid broom ID");
                }

            }
        }

        public bool PlayBroomAnimation
        {
            get { return playBroomAnimation; }

            set { playBroomAnimation = value; }
        }

        public bool RopeIsAttachedToManual
        {
            get { return ropeIsAttatchedToManual; }

            set { ropeIsAttatchedToManual = value; }
        }


        //ANIMATION METHODS

        public void StartBroomAnimation(int numberOfTheBroom)
        {
            if (playBroomAnimation)
            {
                switch (numberOfTheBroom)
                {
                    case 1:
                        Debug.Log("Broom1AnimationHere");
                        break;
                    case 2:
                        Debug.Log("Broom2AnimationHere");
                        break;
                    case 3:
                        Debug.Log("Broom3AnimationHere");
                        break;
                    case 4:
                        Debug.Log("Broom4AnimationHere");
                        break;
                    default:
                        Debug.Log("NoBroomhere");
                        break;
                }
                //play the animation that opens the door with the broom;

            }
        }
        public void StartBroomBrokenAnimation(int numberOfTheBroom)
        {
            //play the animation that breaks the broom;
            switch (numberOfTheBroom)
            {
                case 1:
                    Debug.Log("Broom1BreakAnimationHere");
                    break;
                case 2:
                    Debug.Log("Broom2BreakAnimationHere");
                    break;
                case 3:
                    Debug.Log("Broom3BreakAnimationHere");
                    break;
                case 4:
                    Debug.Log("Broom4BreakAnimationHere");
                    break;
                default:
                    Debug.Log("NoBroomhere");
                    break;
            }

        }
    }
}

