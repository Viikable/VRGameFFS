using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class OctopusLightCode : MonoBehaviour
{
    VRTK_PhysicsPusher RedLight;
    VRTK_PhysicsPusher GreenLight;
    VRTK_PhysicsPusher CyanLight;
    VRTK_PhysicsPusher YellowLight;
    VRTK_PhysicsPusher OctopusAttention;

    [SerializeField]
    [Tooltip("This lights the attention button once a code has been entered")]
    Light AttentionLight;

    [SerializeField]
    [Tooltip("This lights the red button once a red button has been pressed")]
    Light RedLightSource;

    [SerializeField]
    [Tooltip("This lights the red button once a green button has been pressed")]
    Light GreenLightSource;

    [SerializeField]
    [Tooltip("This lights the red button once a cyan button has been pressed")]
    Light CyanLightSource;

    [SerializeField]
    [Tooltip("This lights the red button once a yellow button has been pressed")]
    Light YellowLightSource;

    [SerializeField]
    [Tooltip("This shows how many colours have been entered into the combination, ranges from 0-4")]
    int combinationNumber;

    [SerializeField]
    [Tooltip("This is a list containing all the currently stored colour names in a combination")]
    string[] colourCode;

    [SerializeField]
    [Tooltip("This describes the object where the marker is attatched to atm")]
    string currentMarkedLocation;

    [SerializeField]
    [Tooltip("This tells which object is on the reserach table")]
    string currentTableObject;

    [SerializeField]
    [Tooltip("Indicates whether code has been entered and the octopus notified of this in order to make buttons remain inactive until possible animations have concluded")]
    bool codeEntered;

    [SerializeField]
    [Tooltip("Indicates whether a button has just been pressed or not to avoid accidental double pressing")]
    bool buttonRegistering;

    [SerializeField]
    [Tooltip("Indicates whether a research object with a marker on it is attached to the research table and its hologram is currently playing")]
    bool hologramInProgress;

    [SerializeField]
    [Tooltip("Shows the player the colour which has been entered first into the code")]
    GameObject CodeCube1;

    [SerializeField]
    [Tooltip("Shows the player the colour which has been entered second into the code")]
    GameObject CodeCube2;

    [SerializeField]
    [Tooltip("Shows the player the colour which has been entered third into the code")]
    GameObject CodeCube3;

    [SerializeField]
    [Tooltip("Shows the player the colour which has been entered fourth into the code")]
    GameObject CodeCube4;

    [SerializeField]
    [Tooltip("Snaps to objects so that the Octopus recognizes we want to apply the code with them or get a code from them")]
    GameObject Marker;

    [SerializeField]
    [Tooltip("A research object that teaches the player the verb CLOSE when put on the research table with a marker on it and Octopusattentionbutton is pressed")]
    GameObject OpenBox;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    VRTK_SnapDropZone OpenBoxSnapZone1;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    VRTK_SnapDropZone OpenBoxSnapZone2;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    VRTK_SnapDropZone OpenBoxSnapZone3;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    VRTK_SnapDropZone OpenBoxSnapZone4;

    [SerializeField]
    [Tooltip("A research object that teaches the player verb LOWER")]
    GameObject ResearchPool;

    [Tooltip("One of the areas where the marker can snap to in the ResearchPool object.")]
    VRTK_SnapDropZone PoolSnapZone;

    [SerializeField]
    [Tooltip("A research object that teaches the word PLAY")]
    GameObject Siren;

    [Tooltip("One of the areas where the marker can snap to in the Siren object.")]
    VRTK_SnapDropZone SirenSnapZone;

    [SerializeField]
    [Tooltip("A research object that lets the player turn it ON to test how it works")]
    GameObject ConveyorBelt;

    [Tooltip("One of the areas where the marker can snap to in the ConveyorBelt object.")]
    VRTK_SnapDropZone ConveyorSnapZone1;

    [Tooltip("One of the areas where the marker can snap to in the ConveyorBelt object.")]
    VRTK_SnapDropZone ConveyorSnapZone2;

    [Tooltip("Area on the research table where OpenBox can be snapped into")]
    VRTK_SnapDropZone ResearchSnapZoneOpenBox;

    [Tooltip("Area on the research table where Pool can be snapped into")]
    VRTK_SnapDropZone ResearchSnapZonePool;

    [Tooltip("Area on the research table where ConveyorBelt can be snapped into")]
    VRTK_SnapDropZone ResearchSnapZoneConveyor;

    [Tooltip("Area on the research table where Siren can be snapped into")]
    VRTK_SnapDropZone ResearchSnapZoneSiren;

    Animator OpenBoxAnim;

    //these colliders will be activated when the marker snaps to a given snapzone, creating the illusory colliders for it
    public GameObject OpenBoxMarkerGhostColliderContainer1;

    public GameObject OpenBoxMarkerGhostColliderContainer2;

    public GameObject OpenBoxMarkerGhostColliderContainer3;

    public GameObject OpenBoxMarkerGhostColliderContainer4;

    public GameObject ConveyorMarkerGhostCollider1Container;

    public GameObject ConveyorMarkerGhostCollider2Container;

    public GameObject SirenMarkerGhostColliderContainer;

    public GameObject MelterMarkerGhostColliderContainer;
  
    void Start()
    {
        RedLight = transform.Find("RedLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        GreenLight = transform.Find("GreenLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        CyanLight = transform.Find("CyanLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        YellowLight = transform.Find("YellowLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        OctopusAttention = transform.Find("OctopusAttention").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        combinationNumber = 0;
        colourCode = new string[4];
        currentMarkedLocation = null;
        currentTableObject = null;
        codeEntered = false;
        buttonRegistering = false;
        hologramInProgress = false;       
        AttentionLight = transform.Find("AttentionLight").GetComponent<Light>();
        RedLightSource = transform.Find("RedLightSource").GetComponent<Light>();
        YellowLightSource = transform.Find("YellowLightSource").GetComponent<Light>();
        GreenLightSource = transform.Find("GreenLightSource").GetComponent<Light>();
        CyanLightSource = transform.Find("CyanLightSource").GetComponent<Light>();
        CodeCube1 = transform.Find("CodeCube1").gameObject;
        CodeCube2 = transform.Find("CodeCube2").gameObject;
        CodeCube3 = transform.Find("CodeCube3").gameObject;
        CodeCube4 = transform.Find("CodeCube4").gameObject;

        Marker = GameObject.Find("Marker");

        OpenBox = GameObject.Find("OpenBox");

        ResearchPool = GameObject.Find("Research_melterpool");

        ConveyorBelt = GameObject.Find("Research_Conveyor_belt");

        Siren = GameObject.Find("Research_siren");

        OpenBoxSnapZone1 = OpenBox.transform.Find("OpenBoxSnapZone1").GetComponent<VRTK_SnapDropZone>();
        OpenBoxSnapZone2 = OpenBox.transform.Find("OpenBoxSnapZone2").GetComponent<VRTK_SnapDropZone>();
        OpenBoxSnapZone3 = OpenBox.transform.Find("OpenBoxSnapZone3").GetComponent<VRTK_SnapDropZone>();
        OpenBoxSnapZone4 = OpenBox.transform.Find("OpenBoxSnapZone4").GetComponent<VRTK_SnapDropZone>();

        ConveyorSnapZone1 = ConveyorBelt.transform.Find("ResearchConveyorSnapZone1").GetComponent<VRTK_SnapDropZone>();
        ConveyorSnapZone2 = ConveyorBelt.transform.Find("ResearchConveyorSnapZone2").GetComponent<VRTK_SnapDropZone>();

        PoolSnapZone = ResearchPool.transform.Find("ResearchPoolSnapzone").GetComponent<VRTK_SnapDropZone>();

        SirenSnapZone = Siren.transform.Find("SirenSnapzone").GetComponent<VRTK_SnapDropZone>();

        ResearchSnapZoneOpenBox = GameObject.Find("ResearchSnapZoneOpenBox").GetComponent<VRTK_SnapDropZone>();

        ResearchSnapZonePool = GameObject.Find("ResearchSnapZonePool").GetComponent<VRTK_SnapDropZone>();

        ResearchSnapZoneConveyor = GameObject.Find("ResearchSnapZoneConveyor").GetComponent<VRTK_SnapDropZone>();

        ResearchSnapZoneSiren = GameObject.Find("ResearchSnapZoneSiren").GetComponent<VRTK_SnapDropZone>();

        OpenBoxAnim = GameObject.Find("OpenBoxAnimated").GetComponent<Animator>();

        OpenBoxMarkerGhostColliderContainer1 = OpenBox.transform.Find("MarkerGhostCollider1").gameObject;
        OpenBoxMarkerGhostColliderContainer2 = OpenBox.transform.Find("MarkerGhostCollider2").gameObject;
        OpenBoxMarkerGhostColliderContainer3 = OpenBox.transform.Find("MarkerGhostCollider3").gameObject;
        OpenBoxMarkerGhostColliderContainer4 = OpenBox.transform.Find("MarkerGhostCollider4").gameObject;

        ConveyorMarkerGhostCollider1Container = ConveyorBelt.transform.Find("ConveyorMarkerGhostCollider1").gameObject;
        ConveyorMarkerGhostCollider2Container = ConveyorBelt.transform.Find("ConveyorMarkerGhostCollider2").gameObject;

        SirenMarkerGhostColliderContainer = Siren.transform.Find("SirenMarkerGhostCollider").gameObject;

        MelterMarkerGhostColliderContainer = ResearchPool.transform.Find("MelterMarkerGhostCollider").gameObject;
    }

    void Update()
    {
        CheckMarkerLocation();
        CheckResearchTable();
        CheckColourCombination();
    }

    //Checks what object if any is snapped to the research table snap zone currently
    public void CheckResearchTable()
    {
        if (ResearchSnapZoneOpenBox.GetCurrentSnappedObject() != null)
        {
            if (ResearchSnapZoneOpenBox.GetCurrentSnappedObject() == OpenBox)
            {
                currentTableObject = "OpenBox";
                //so that cannot snap multiple objects at the same time
                ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = false;       
                ResearchSnapZonePool.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZoneConveyor.GetCurrentSnappedObject() != null)
        {
            if (ResearchSnapZoneConveyor.GetCurrentSnappedObject() == ConveyorBelt)
            {
                currentTableObject = "ConveyorBelt";
                ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = false;
                ResearchSnapZonePool.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZonePool.GetCurrentSnappedObject() != null)
        {
            if (ResearchSnapZonePool.GetCurrentSnappedObject() == ResearchPool)
            {
                currentTableObject = "Pool";
                ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZoneSiren.GetCurrentSnappedObject() != null)
        {
            if (ResearchSnapZoneSiren.GetCurrentSnappedObject() == Siren)
            {
                currentTableObject = "Siren";
                ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = false;
                ResearchSnapZonePool.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            currentTableObject = null;
            ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = true;
            ResearchSnapZonePool.GetComponent<Collider>().enabled = true;
            ResearchSnapZoneSiren.GetComponent<Collider>().enabled = true;
            ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = true;
        }
        //enables the attention button in order to play hologram and get code
        if (!hologramInProgress)
        {
            if (currentTableObject == "OpenBox" && currentMarkedLocation == "OpenBox")
            {
                AttentionLight.enabled = true;
                OctopusAttention.stayPressed = true;
                if (OctopusAttention.AtMaxLimit() && OctopusAttention.stayPressed)
                {
                    OctopusAttention.stayPressed = false;
                    AttentionLight.enabled = false;
                    AnimateHologram("OpenBox");
                    DisplayCode("CLOSE");
                }
            }
        }
    }

    //Animates the given hologram of the research object, showing an action
    public void AnimateHologram(string objectToBeAnimated)
    {
        Debug.Log("animationHologram");
        if (objectToBeAnimated == "OpenBox")
        {
            hologramInProgress = true;
            OpenBoxAnim.SetBool("Close", true);
            StartCoroutine("HologramFinish", 5f);
        }
    }

    //Displays the first colour of the code for the player
    public void DisplayCode(string actionVerb)
    {
        Debug.Log("DisplayCode");
        if (actionVerb == "CLOSE")
        {
            CodeCube1.GetComponent<MeshRenderer>().material.color = Color.red;

            StartCoroutine("DisplayCodeColour", "CLOSE");          
        }
    }
    //this displays the rest of the colour code based on the verb entered
    IEnumerator DisplayCodeColour(string actionVerb)
    {
        if (actionVerb == "CLOSE")
        {
            yield return new WaitForSecondsRealtime(1f);
            CodeCube2.GetComponent<MeshRenderer>().material.color = Color.green;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube3.GetComponent<MeshRenderer>().material.color = Color.green;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube4.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    //with this method we can decide the duration of the animation based
    IEnumerator HologramFinish(float animationTime)
    {
        yield return new WaitForSecondsRealtime(animationTime);
        hologramInProgress = false;
        OpenBoxAnim.SetBool("Close", false);
    }

    //checking what colour combination has been entered
    public void CheckColourCombination()  
    { 
        if (RedLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)            
        {
            colourCode[combinationNumber] = "Red";
            combinationNumber++;
            buttonRegistering = true;
            RedLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            StartCoroutine("WaitForPress");
        }
        if (GreenLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Green";
            combinationNumber++;
            buttonRegistering = true;
            GreenLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            StartCoroutine("WaitForPress");
        }
        if (YellowLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Yellow";
            combinationNumber++;
            buttonRegistering = true;
            YellowLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            StartCoroutine("WaitForPress");
        }
        if (CyanLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Cyan";
            combinationNumber++;
            buttonRegistering = true;
            CyanLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            StartCoroutine("WaitForPress");
        }
        if (combinationNumber == 4 && !codeEntered)
        {
            AttentionLight.enabled = true;
            OctopusAttention.stayPressed = true;
            CheckCodeValidity();
        }
    }   
    IEnumerator WaitForPress()
    {
        //Waits for the button to register being pressed and lifted up so it's only registered once
        yield return new WaitForSecondsRealtime(1);
        buttonRegistering = false;
        RedLightSource.enabled = false;
        GreenLightSource.enabled = false;
        YellowLightSource.enabled = false;
        CyanLightSource.enabled = false;
    }
    public void ColourReset()
    {
        CodeCube1.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube2.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube3.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube4.GetComponent<MeshRenderer>().material.color = Color.grey;
        codeEntered = false;
    }

    public void CheckMarkerLocation()      //checks where the marker is snapped currently, if nowhere, resets location to null
    {
        if (Marker.GetComponent<VRTK_InteractableObject>().IsInSnapDropZone() && !Game_Manager.instance.beingUnSnapped)
        {
            if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == (OpenBoxSnapZone1 || OpenBoxSnapZone2 || OpenBoxSnapZone3
                || OpenBoxSnapZone4))
            {
                currentMarkedLocation = "OpenBox";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == OpenBoxSnapZone1)
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer1.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == OpenBoxSnapZone2)
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer2.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == OpenBoxSnapZone3)
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer3.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == OpenBoxSnapZone4)
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer4.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
            }
            else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == (ConveyorSnapZone1 || ConveyorSnapZone2))
            {
                currentMarkedLocation = "ConveyorBelt";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == ConveyorSnapZone1)
                {
                    foreach (Collider col in ConveyorMarkerGhostCollider1Container.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == ConveyorSnapZone2)
                {
                    foreach (Collider col in ConveyorMarkerGhostCollider2Container.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
            }
            else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == (PoolSnapZone))
            {
                currentMarkedLocation = "Pool";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                foreach (Collider col in MelterMarkerGhostColliderContainer.GetComponentsInChildren<Collider>())
                {
                    col.enabled = true;
                }
            }
            else if (Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone() == (SirenSnapZone))
            {
                currentMarkedLocation = "Siren";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                foreach (Collider col in SirenMarkerGhostColliderContainer.GetComponentsInChildren<Collider>())
                {
                    col.enabled = true;
                }
            }
        }
        else if (Game_Manager.instance.beingUnSnapped)
        {
            foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
            {
                col.enabled = true;
            }
            foreach (Collider col in OpenBoxMarkerGhostColliderContainer1.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in OpenBoxMarkerGhostColliderContainer2.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in OpenBoxMarkerGhostColliderContainer3.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in OpenBoxMarkerGhostColliderContainer4.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in ConveyorMarkerGhostCollider1Container.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in ConveyorMarkerGhostCollider2Container.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in MelterMarkerGhostColliderContainer.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            foreach (Collider col in SirenMarkerGhostColliderContainer.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            currentMarkedLocation = null;
            //Marker.transform.position -= transform.forward * Time.deltaTime * 0.5f;         
        }
        else
        {
            return;
        }
    }

    public void CheckCodeValidity()
    {
        if (OctopusAttention.AtMaxLimit() && OctopusAttention.stayPressed)
        {
            if (colourCode[0] == "Red")
            {
                if (colourCode[1] == "Green" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    Debug.Log("CLOSE");
                    //This word is CLOSE
                    //here we can write what we can close and what happens if we type close and then ask the octopus about it
                    if (currentMarkedLocation == "OpenBox" /* && the OpenBox is on the research table snapped */)
                    {
                        OpenBox.GetComponent<MeshRenderer>().material.color = Color.green;
                        //we play the animation which closes the box like a hologram on the table separate from the actual box
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place or that the object needs to be on the table
                }
                else if (colourCode[1] == "Cyan" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    //This word is OPEN, this is the KEY word to open the elevator
                    if (currentMarkedLocation == "Elevator")
                    {
                        //Gives the code to unlock the elevator panel to the player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Cyan")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Yellow" && colourCode[3] == "Green")
                {
                    //This one is MUTE, which the player can see at the start paper, it is used to shut down the music player at least
                    if (currentMarkedLocation == "MusicPlayer")
                    {
                        //Mutes the music player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Red" && colourCode[3] == "Green")
                {
                    //This one is PLAY and it can be used to enable the music player, as long as it has the marker on it first
                    if (currentMarkedLocation == "MusicPlayer")
                    {
                        //Starts the music player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Yellow")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Green" && colourCode[3] == "Yellow")
                {
                    //This one is LIFT, used only with the research objects most likely
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Green" && colourCode[3] == "Red")
                {
                    //This one is LOWER, also used only with research objects
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Green")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Red" && colourCode[3] == "Red")
                {
                    // This one is ON and that is also known at the start paper, 
                    // it can be used to turn on some research items and the monitor
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Yellow" && colourCode[3] == "Yellow")
                {
                    //This one is OFF, and it is used to turn the magnetic gate off and some research items like the LAMP can give this verb
                    if (currentMarkedLocation == "MagneticGate")
                    {
                        //turn the magnetic gate off
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            ColourReset();
        }
        else
        {
            //attention button hasn't been pressed
            return;
        }
    }
}

