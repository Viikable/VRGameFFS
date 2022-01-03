﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OctopusLightCode : MonoBehaviour
{
    Button RedLight;
    Button GreenLight;
    Button CyanLight;
    Button YellowLight;
    Button OctopusAttention;
  
    MeshRenderer RedButtonMeshMaterial;
    MeshRenderer GreenButtonMeshMaterial;
    MeshRenderer CyanButtonMeshMaterial;
    MeshRenderer YellowButtonMeshMaterial;
    MeshRenderer OctopusAttentionButtonMeshMaterial;

    Material ButtonCyan;
    Material ButtonRed;
    Material ButtonGreen;
    Material ButtonYellow;
   
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
    [Tooltip("This describes the object/location where the marker is attached to atm")]
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
    [Tooltip("Indicates whether octopus response animation is currently playing or not")]
    bool octoAnimInProgress;

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
    XRSocketInteractor OpenBoxSnapZone1;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    XRSocketInteractor OpenBoxSnapZone2;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    XRSocketInteractor OpenBoxSnapZone3;

    [Tooltip("One of the areas where the marker can snap to in the OpenBox object. This area is signaled to the player via a symbol in the OpenBox.")]
    XRSocketInteractor OpenBoxSnapZone4;

    [SerializeField]
    [Tooltip("A research object that teaches the player verb LOWER")]
    GameObject ResearchPool;

    [Tooltip("One of the areas where the marker can snap to in the ResearchPool object.")]
    XRSocketInteractor PoolSnapZone;

    [SerializeField]
    [Tooltip("A research object that teaches the word PLAY")]
    GameObject Siren;

    [SerializeField]
    [Tooltip("Magnetic Fences which keep the reserach objects in the research area until turned off by the player")]
    GameObject MagneticFenceContainer;

    [Tooltip("One of the areas where the marker can snap to in the Siren object.")]
    XRSocketInteractor SirenSnapZone;

    [SerializeField]
    [Tooltip("A research object that lets the player turn it ON to test how it works")]
    GameObject ConveyorBelt;

    [Tooltip("One of the areas where the marker can snap to in the ConveyorBelt object.")]
    XRSocketInteractor ConveyorSnapZone1;

    [Tooltip("One of the areas where the marker can snap to in the ConveyorBelt object.")]
    XRSocketInteractor ConveyorSnapZone2;

    [Tooltip("One of the areas where the marker can snap to somewhere near the Magnetic Fence.")]
    XRSocketInteractor MagneticFenceSnapZone;

    [Tooltip("Area on the research table where OpenBox can be snapped into")]
    XRSocketInteractor ResearchSnapZoneOpenBox;

    [Tooltip("Area on the research table where Pool can be snapped into")]
    XRSocketInteractor ResearchSnapZonePool;

    [Tooltip("Area on the research table where ConveyorBelt can be snapped into")]
    XRSocketInteractor ResearchSnapZoneConveyor;

    [Tooltip("Area on the research table where Siren can be snapped into")]
    XRSocketInteractor ResearchSnapZoneSiren;

    Animator OpenBoxAnim;

    Animator ConveyorAnim;

    Animator PoolAnim;

    Animator SirenAnim;

    Animator OctopusAnim;

    //Audio
    [Header("Audio")]
    public AudioSource YellowButtonSound;

    public AudioSource CyanButtonSound;

    public AudioSource RedButtonSound;

    public AudioSource GreenButtonSound;

    public AudioSource OctopusAttentionButtonSound;

    public AudioSource HologramAppearsSound;

    public AudioSource HologramDisappearsSound;

    public static AudioSource MarkerAttachSound;

    //these colliders will be activated when the marker snaps to a given snapzone, creating the illusory colliders for it
    [Header("Ghostcolliders")]
    public GameObject OpenBoxMarkerGhostColliderContainer1;

    public GameObject OpenBoxMarkerGhostColliderContainer2;

    public GameObject OpenBoxMarkerGhostColliderContainer3;

    public GameObject OpenBoxMarkerGhostColliderContainer4;

    public GameObject ConveyorMarkerGhostCollider1Container;

    public GameObject ConveyorMarkerGhostCollider2Container;

    public GameObject SirenMarkerGhostColliderContainer;

    public GameObject MelterMarkerGhostColliderContainer;

    public GameObject MagneticFenceMarkerGhostColliderContainer;

    void Start()
    {
        ButtonCyan = GameObject.Find("OctoCyan").GetComponent<MeshRenderer>().material;
        ButtonYellow = GameObject.Find("OctoYellow").GetComponent<MeshRenderer>().material;
        ButtonGreen = GameObject.Find("OctoGreen").GetComponent<MeshRenderer>().material;
        ButtonRed = GameObject.Find("OctoRed").GetComponent<MeshRenderer>().material;

        RedLight = transform.Find("RedLight").GetChild(0).GetComponent<Button>();
        RedButtonMeshMaterial = transform.Find("RedLight").GetChild(0).GetComponentInChildren<MeshRenderer>();
        RedButtonMeshMaterial.material.EnableKeyword("_EMISSION");
        GreenLight = transform.Find("GreenLight").GetChild(0).GetComponent<Button>();
        GreenButtonMeshMaterial = transform.Find("GreenLight").GetChild(0).GetComponentInChildren<MeshRenderer>();
        GreenButtonMeshMaterial.material.EnableKeyword("_EMISSION");
        CyanLight = transform.Find("CyanLight").GetChild(0).GetComponent<Button>();
        CyanButtonMeshMaterial = transform.Find("CyanLight").GetChild(0).GetComponentInChildren<MeshRenderer>();
        CyanButtonMeshMaterial.material.EnableKeyword("_EMISSION");
        YellowLight = transform.Find("YellowLight").GetChild(0).GetComponent<Button>();
        YellowButtonMeshMaterial = transform.Find("YellowLight").GetChild(0).GetComponentInChildren<MeshRenderer>();
        YellowButtonMeshMaterial.material.EnableKeyword("_EMISSION");
        OctopusAttention = transform.Find("OctopusAttention").GetChild(0).GetComponent<Button>();
        OctopusAttentionButtonMeshMaterial = transform.Find("OctopusAttention").GetChild(0).GetComponentInChildren<MeshRenderer>();
        OctopusAttentionButtonMeshMaterial.material.EnableKeyword("_EMISSION");

        combinationNumber = 0;
        colourCode = new string[4];
        currentMarkedLocation = null;
        currentTableObject = null;
        codeEntered = false;
        buttonRegistering = false;
        hologramInProgress = false;
        octoAnimInProgress = false;
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

        MagneticFenceContainer = GameObject.Find("MagneticFenceContainer");

        OpenBoxSnapZone1 = OpenBox.transform.Find("OpenBoxSnapZone1").GetComponent<XRSocketInteractor>();
        OpenBoxSnapZone2 = OpenBox.transform.Find("OpenBoxSnapZone2").GetComponent<XRSocketInteractor>();
        OpenBoxSnapZone3 = OpenBox.transform.Find("OpenBoxSnapZone3").GetComponent<XRSocketInteractor>();
        OpenBoxSnapZone4 = OpenBox.transform.Find("OpenBoxSnapZone4").GetComponent<XRSocketInteractor>();

        ConveyorSnapZone1 = ConveyorBelt.transform.Find("ResearchConveyorSnapZone1").GetComponent<XRSocketInteractor>();
        ConveyorSnapZone2 = ConveyorBelt.transform.Find("ResearchConveyorSnapZone2").GetComponent<XRSocketInteractor>();

        MagneticFenceSnapZone = GameObject.Find("MagneticFenceSnapZone").GetComponent<XRSocketInteractor>();

        PoolSnapZone = ResearchPool.transform.Find("ResearchPoolSnapzone").GetComponent<XRSocketInteractor>();

        SirenSnapZone = Siren.transform.Find("SirenSnapzone").GetComponent<XRSocketInteractor>();

        ResearchSnapZoneOpenBox = GameObject.Find("ResearchSnapZoneOpenBox").GetComponent<XRSocketInteractor>();

        ResearchSnapZonePool = GameObject.Find("ResearchSnapZonePool").GetComponent<XRSocketInteractor>();

        ResearchSnapZoneConveyor = GameObject.Find("ResearchSnapZoneConveyor").GetComponent<XRSocketInteractor>();

        ResearchSnapZoneSiren = GameObject.Find("ResearchSnapZoneSiren").GetComponent<XRSocketInteractor>();

        OpenBoxAnim = GameObject.Find("OpenBoxAnimated").GetComponent<Animator>();

        ConveyorAnim = GameObject.Find("Research_Conveyor_Animated").GetComponent<Animator>();

        PoolAnim = GameObject.Find("Research_Pool_Lid_Animated").GetComponent<Animator>();

        SirenAnim = GameObject.Find("Research_siren_Animated").GetComponent<Animator>();

        OctopusAnim = GameObject.Find("OCTOPUS").GetComponent<Animator>();

        YellowButtonSound = transform.Find("YellowLight/YellowButton").GetComponent<AudioSource>();

        RedButtonSound = transform.Find("RedLight/RedButton").GetComponent<AudioSource>();

        CyanButtonSound = transform.Find("CyanLight/CyanButton").GetComponent<AudioSource>();

        GreenButtonSound = transform.Find("GreenLight/GreenButton").GetComponent<AudioSource>();

        OctopusAttentionButtonSound = transform.Find("OctopusAttention/AttentionButton").GetComponent<AudioSource>();

        MarkerAttachSound = Marker.GetComponent<AudioSource>();

        OpenBoxMarkerGhostColliderContainer1 = OpenBox.transform.Find("MarkerGhostCollider1").gameObject;
        OpenBoxMarkerGhostColliderContainer2 = OpenBox.transform.Find("MarkerGhostCollider2").gameObject;
        OpenBoxMarkerGhostColliderContainer3 = OpenBox.transform.Find("MarkerGhostCollider3").gameObject;
        OpenBoxMarkerGhostColliderContainer4 = OpenBox.transform.Find("MarkerGhostCollider4").gameObject;

        ConveyorMarkerGhostCollider1Container = ConveyorBelt.transform.Find("ConveyorMarkerGhostCollider1").gameObject;
        ConveyorMarkerGhostCollider2Container = ConveyorBelt.transform.Find("ConveyorMarkerGhostCollider2").gameObject;

        SirenMarkerGhostColliderContainer = Siren.transform.Find("SirenMarkerGhostCollider").gameObject;

        MelterMarkerGhostColliderContainer = ResearchPool.transform.Find("MelterMarkerGhostCollider").gameObject;

        MagneticFenceMarkerGhostColliderContainer = MagneticFenceSnapZone.transform.Find("MagneticFenceMarkerGhostCollider").gameObject;
    }

    void Update()
    {
        CheckMarkerLocation();
        CheckResearchTable();
        CheckColourCombination();
    }

    //Checks what object if any is snapped to the research table snap zone(s) currently
    public void CheckResearchTable()
    {
        if (ResearchSnapZoneOpenBox.firstInteractableSelected != null)
        {
            if (ResearchSnapZoneOpenBox.firstInteractableSelected.Equals(OpenBox))
            {
                currentTableObject = "OpenBox";
                //so that cannot snap multiple objects at the same time
                ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = false;       
                ResearchSnapZonePool.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZoneConveyor.firstInteractableSelected != null)
        {
            if (ResearchSnapZoneConveyor.firstInteractableSelected.Equals(ConveyorBelt))
            {
                Debug.Log("Conveyorsnap");
                currentTableObject = "ConveyorBelt";
                ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = false;
                ResearchSnapZonePool.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZonePool.firstInteractableSelected != null)
        {
            if (ResearchSnapZonePool.firstInteractableSelected.Equals(ResearchPool))
            {
                currentTableObject = "Pool";
                ResearchSnapZoneConveyor.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneOpenBox.GetComponent<Collider>().enabled = false;
                ResearchSnapZoneSiren.GetComponent<Collider>().enabled = false;
            }
        }
        else if (ResearchSnapZoneSiren.firstInteractableSelected != null)
        {
            if (ResearchSnapZoneSiren.firstInteractableSelected.Equals(Siren))
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
        if (!hologramInProgress && !octoAnimInProgress && combinationNumber == 0)
        {
            if (currentTableObject == "OpenBox" && currentMarkedLocation == "OpenBox")
            {
                OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 1f);
                OctopusAttention.stayPressed = true;
                if (OctopusAttention.isPressedDown && OctopusAttention.stayPressed)
                {
                    OctopusAttention.stayPressed = false;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    AnimateHologram("OpenBox");
                    AnimateOctopus("OCTO_CLOSE");
                    DisplayCode("CLOSE");
                }
            }
            else if (currentTableObject == "ConveyorBelt" && currentMarkedLocation == "ConveyorBelt")
            {
                Debug.Log("conveyor");
                OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 1f);
                OctopusAttention.stayPressed = true;
                if (OctopusAttention.isPressedDown && OctopusAttention.stayPressed)
                {
                    OctopusAttention.stayPressed = false;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    AnimateHologram("ConveyorBelt");
                    AnimateOctopus("OCTO_TURNON");
                    DisplayCode("ON");
                }
            }
            else if (currentTableObject == "Pool" && currentMarkedLocation == "Pool")
            {
                Debug.Log("pool");
                OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 1f);
                OctopusAttention.stayPressed = true;
                if (OctopusAttention.isPressedDown && OctopusAttention.stayPressed)
                {
                    OctopusAttention.stayPressed = false;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    AnimateHologram("Pool");
                    AnimateOctopus("OCTO_LOWER");
                    DisplayCode("LOWER");
                }
            }
            else if (currentTableObject == "Siren" && currentMarkedLocation == "Siren")
            {
                Debug.Log("siren");
                OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 1f);
                OctopusAttention.stayPressed = true;
                if (OctopusAttention.isPressedDown && OctopusAttention.stayPressed)
                {
                    OctopusAttention.stayPressed = false;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    AnimateHologram("Siren");
                    AnimateOctopus("OCTO_CLOSE");
                    DisplayCode("PLAY");
                }
            }
        }
    }

    //Animates the given hologram of the research object, showing an action
    public void AnimateHologram(string objectToBeAnimated)
    {     
        hologramInProgress = true;
        HologramAppearsSound.Play();
        if (objectToBeAnimated == "OpenBox")
        {
            OpenBoxAnim.SetBool("Close", true);
            StartCoroutine("HologramFinish", 5f);
        }
        else if (objectToBeAnimated == "ConveyorBelt")
        {
            ConveyorAnim.SetBool("On", true);
            StartCoroutine("HologramFinish", 7.5f);
        }
        else if (objectToBeAnimated == "Pool")
        {
            PoolAnim.SetBool("Lower", true);
            StartCoroutine("HologramFinish", 5f);          
        }
        else if (objectToBeAnimated == "Siren")
        {
            SirenAnim.SetBool("Play", true);
            StartCoroutine("HologramFinish", 5f);
        }
    }

    //Displays the first colour of the code for the player
    public void DisplayCode(string actionVerb)
    {
        ColourReset();
        if (actionVerb == "CLOSE")
        {
            CodeCube1.GetComponent<MeshRenderer>().material = ButtonRed;

            StartCoroutine("DisplayCodeColour", "CLOSE");          
        }
        else if (actionVerb == "ON")
        {
            CodeCube1.GetComponent<MeshRenderer>().material = ButtonGreen;
            StartCoroutine("DisplayCodeColour", "ON");
        }
        else if (actionVerb == "LOWER")
        {
            CodeCube1.GetComponent<MeshRenderer>().material = ButtonYellow;
            StartCoroutine("DisplayCodeColour", "LOWER");
        }
        else if (actionVerb == "PLAY")
        {
            CodeCube1.GetComponent<MeshRenderer>().material = ButtonCyan;
            StartCoroutine("DisplayCodeColour", "PLAY");
        }
    }

    //this displays the rest of the colour code based on the verb entered
    IEnumerator DisplayCodeColour(string actionVerb)
    {
        if (actionVerb == "CLOSE")
        {
            yield return new WaitForSecondsRealtime(1f);
            CodeCube2.GetComponent<MeshRenderer>().material = ButtonCyan;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube3.GetComponent<MeshRenderer>().material = ButtonGreen;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube4.GetComponent<MeshRenderer>().material = ButtonGreen;
        }
        else if (actionVerb == "ON")
        {
            yield return new WaitForSecondsRealtime(1f);
            CodeCube2.GetComponent<MeshRenderer>().material = ButtonRed;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube3.GetComponent<MeshRenderer>().material = ButtonRed;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube4.GetComponent<MeshRenderer>().material = ButtonRed;
        }
        else if (actionVerb == "LOWER")
        {
            yield return new WaitForSecondsRealtime(1f);
            CodeCube2.GetComponent<MeshRenderer>().material = ButtonYellow;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube3.GetComponent<MeshRenderer>().material = ButtonGreen;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube4.GetComponent<MeshRenderer>().material = ButtonRed;
        }
        else if (actionVerb == "PLAY")
        {
            yield return new WaitForSecondsRealtime(1f);
            CodeCube2.GetComponent<MeshRenderer>().material = ButtonYellow;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube3.GetComponent<MeshRenderer>().material = ButtonRed;
            yield return new WaitForSecondsRealtime(1f);
            CodeCube4.GetComponent<MeshRenderer>().material = ButtonGreen;
        }
    }

    //with this method we can decide the duration of the animation based on the animated object
    IEnumerator HologramFinish(float animationTime)
    {
        yield return new WaitForSecondsRealtime(animationTime);
        OpenBoxAnim.SetBool("Close", false);
        ConveyorAnim.SetBool("On", false);
        PoolAnim.SetBool("Lower", false);
        SirenAnim.SetBool("Play", false);
        hologramInProgress = false;
        HologramDisappearsSound.Play();
    }

    //checking what colour combination has been entered
    public void CheckColourCombination()  
    { 
        if (RedLight.isPressedDown && combinationNumber <= 3 && !codeEntered && !buttonRegistering && !hologramInProgress && !octoAnimInProgress)            
        {
            //this so that if player starts pressing the buttons after a hologram has showed a code it resets
            if (combinationNumber == 0)
            {
                ColourReset();
            }
            colourCode[combinationNumber] = "Red";
            combinationNumber++;
            buttonRegistering = true;
            RedButtonMeshMaterial.material.SetColor("_EmissionColor", ButtonRed.color * 0.75f);
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material = ButtonRed;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material = ButtonRed;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material = ButtonRed;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material = ButtonRed;
            }
            RedButtonSound.Play();
            StartCoroutine("WaitForPress");
        }
        if (GreenLight.isPressedDown && combinationNumber <= 3 && !codeEntered && !buttonRegistering && !hologramInProgress && !octoAnimInProgress)
        {
            if (combinationNumber == 0)
            {
                ColourReset();
            }
            colourCode[combinationNumber] = "Green";
            combinationNumber++;
            buttonRegistering = true;
            GreenButtonMeshMaterial.material.SetColor("_EmissionColor", ButtonGreen.color * 0.75f);
            if (combinationNumber == 1)
            {              
                CodeCube1.GetComponent<MeshRenderer>().material = ButtonGreen;              
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material = ButtonGreen;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material = ButtonGreen;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material = ButtonGreen;
            }
            GreenButtonSound.Play();
            StartCoroutine("WaitForPress");
        }
        if (YellowLight.isPressedDown && combinationNumber <= 3 && !codeEntered && !buttonRegistering && !hologramInProgress && !octoAnimInProgress)
        {
            if (combinationNumber == 0)
            {
                ColourReset();
            }
            colourCode[combinationNumber] = "Yellow";
            combinationNumber++;
            buttonRegistering = true;
            YellowButtonMeshMaterial.material.SetColor("_EmissionColor", ButtonYellow.color * 0.75f);
            if (combinationNumber == 1)
            {              
                CodeCube1.GetComponent<MeshRenderer>().material = ButtonYellow;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material = ButtonYellow;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material = ButtonYellow;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material = ButtonYellow;
            }
            YellowButtonSound.Play();
            StartCoroutine("WaitForPress");
        }
        if (CyanLight.isPressedDown && combinationNumber <= 3 && !codeEntered && !buttonRegistering && !hologramInProgress && !octoAnimInProgress)
        {
            if (combinationNumber == 0)
            {
                ColourReset();
            }
            colourCode[combinationNumber] = "Cyan";
            combinationNumber++;
            buttonRegistering = true;
            CyanButtonMeshMaterial.material.SetColor("_EmissionColor", ButtonCyan.color * 0.75f);
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material = ButtonCyan;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material = ButtonCyan;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material = ButtonCyan;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material = ButtonCyan;
            }
            CyanButtonSound.Play();
            StartCoroutine("WaitForPress");
        }
        if (combinationNumber == 4 && !codeEntered)
        {
            OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 1f);
            OctopusAttention.stayPressed = true;
            CheckCodeValidity();
        }
    }   

    IEnumerator WaitForPress()
    {
        //Waits for the button to register being pressed and lifted up so it's only registered once
        yield return new WaitForSecondsRealtime(1);
        buttonRegistering = false;
        RedButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
        GreenButtonMeshMaterial.material.SetColor("_EmissionColor", Color.green * 0f);
        CyanButtonMeshMaterial.material.SetColor("_EmissionColor", Color.cyan * 0f);
        YellowButtonMeshMaterial.material.SetColor("_EmissionColor", Color.yellow * 0f);
    }

    public void ColourReset()
    {
        CodeCube1.GetComponent<MeshRenderer>().material.color = Color.black;
        CodeCube2.GetComponent<MeshRenderer>().material.color = Color.black;
        CodeCube3.GetComponent<MeshRenderer>().material.color = Color.black;
        CodeCube4.GetComponent<MeshRenderer>().material.color = Color.black;
        colourCode[0] = null;
        colourCode[1] = null;
        colourCode[2] = null;
        colourCode[3] = null;
        codeEntered = false;
    }

    public void CheckMarkerLocation()      //checks where the marker is snapped currently, if nowhere, resets location to null
    {
        //as keyword performs a cast, so we check here if there is a selecting interactor typeof XRSocketInteractor, I think
        var snapInteractor = Marker.GetComponent<XRGrabInteractable>().firstInteractorSelecting;
        if (snapInteractor as XRSocketInteractor != null) 
        {
            //Debug.Log(Marker.GetComponent<XRGrabInteractable>().GetStoredSnapDropZone());
            if (ConveyorSnapZone1.firstInteractableSelected.Equals(Marker) || ConveyorSnapZone2.firstInteractableSelected.Equals(Marker))
            {
                Debug.Log("conveyormarker");
                currentMarkedLocation = "ConveyorBelt";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                if (snapInteractor.Equals(ConveyorSnapZone1))
                {
                    foreach (Collider col in ConveyorMarkerGhostCollider1Container.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (snapInteractor.Equals(ConveyorSnapZone2))
                {
                    foreach (Collider col in ConveyorMarkerGhostCollider2Container.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
            }
            else if (OpenBoxSnapZone1.firstInteractableSelected.Equals(Marker) || OpenBoxSnapZone2.firstInteractableSelected.Equals(Marker)
                || OpenBoxSnapZone3.firstInteractableSelected.Equals(Marker) || OpenBoxSnapZone4.firstInteractableSelected.Equals(Marker))
            {
                Debug.Log("OpenBoxmarked");
                currentMarkedLocation = "OpenBox";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                if (snapInteractor.Equals(OpenBoxSnapZone1))
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer1.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (snapInteractor.Equals(OpenBoxSnapZone2))
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer2.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (snapInteractor.Equals(OpenBoxSnapZone3))
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer3.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
                else if (snapInteractor.Equals(OpenBoxSnapZone4))
                {
                    foreach (Collider col in OpenBoxMarkerGhostColliderContainer4.GetComponentsInChildren<Collider>())
                    {
                        col.enabled = true;
                    }
                }
            }
            else if (PoolSnapZone.firstInteractableSelected.Equals(Marker))
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
            else if (SirenSnapZone.firstInteractableSelected.Equals(Marker))
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
            else if (MagneticFenceSnapZone.firstInteractableSelected.Equals(Marker))
            {
                currentMarkedLocation = "MagneticFence";
                foreach (Collider col in Marker.GetComponentsInChildren<Collider>())
                {
                    col.enabled = false;
                }
                foreach (Collider col in MagneticFenceMarkerGhostColliderContainer.GetComponentsInChildren<Collider>())
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
    }

    //checks whether the code is valid and if it is then possibly starts an action
    public void CheckCodeValidity()
    {
        if (OctopusAttention.isPressedDown && OctopusAttention.stayPressed)
        {
            if (!OctopusAttentionButtonSound.isPlaying)
            {
            OctopusAttentionButtonSound.Play();
            }
            if (colourCode[0] == "Red")
            {
                if (colourCode[1] == "Cyan" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    Debug.Log("CLOSE");
                    //This word is CLOSE
                    //here we can write what we can close and what happens if we type close and then ask the octopus about it
                    if (currentTableObject == "OpenBox")
                    {
                        AnimateHologram("OpenBox");
                        AnimateOctopus("OCTO_CLOSE");
                        //we play the animation which closes the box like a hologram on the table separate from the actual box
                    }
                    else
                    {
                        AnimateOctopus("OCTO_CLOSE");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place or that the object needs to be on the table
                }
                else if (colourCode[1] == "Green" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    //This word is OPEN, this is the KEY word to open the elevator
                    if (currentMarkedLocation == "Elevator")
                    {
                        AnimateOctopus("OCTO_OPEN");
                        //OPENS THE ELEVATOR
                    }
                    else
                    {
                        AnimateOctopus("OCTO_OPEN");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    AnimateOctopus("OCTO_CONFUSED");
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
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
                        AnimateOctopus("OCTO_MUTE");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
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
                        AnimateOctopus("OCTO_PLAY");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    AnimateOctopus("OCTO_CONFUSED");
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Yellow")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Green" && colourCode[3] == "Yellow")
                {
                    //This one is LIFT, can only be got from octopus, this starts octopusLiftAnimation
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Green" && colourCode[3] == "Red")
                {
                    //This one is LOWER, also used only with research objects
                    if (currentTableObject == "Pool")
                    {
                        AnimateHologram("Pool");
                        AnimateOctopus("OCTO_LOWER");
                        //we play the animation which closes pool lid on the table separate from the actual lid
                    }
                    else
                    {
                        AnimateOctopus("OCTO_LOWER");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    AnimateOctopus("OCTO_CONFUSED");
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Green")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Red" && colourCode[3] == "Red")
                {
                    // This one is ON and that is got from turning ON the conveyor belt, 
                    // it can be used to turn on some research items and the monitor
                    if (currentTableObject == "ConveyorBelt")
                    {
                        AnimateHologram("ConveyorBelt");
                        AnimateOctopus("OCTO_TURNON");
                        //we play the animation which starts the conveyor belt on the table
                    }
                    else
                    {
                        AnimateOctopus("OCTO_TURNON");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Yellow" && colourCode[3] == "Yellow")
                {
                    //This one is OFF, and it is used to turn the magnetic gate off and some research items like the LAMP can give this verb
                    if (currentMarkedLocation == "MagneticFence")
                    {
                        //turns the magnetic gate off
                        MagneticFenceContainer.transform.Find("MagneticFence1").GetComponent<Collider>().enabled = false;
                        MagneticFenceContainer.transform.Find("MagneticFence1").GetComponent<AudioSource>().Stop();
                        MagneticFenceContainer.transform.Find("MagneticFence2").GetComponent<Collider>().enabled = false;
                        MagneticFenceContainer.transform.Find("MagneticFence2").GetComponent<AudioSource>().Stop();
                        MagneticFenceContainer.transform.Find("OctoMagneticWallParticles1").GetComponent<ParticleSystem>().Stop();
                        MagneticFenceContainer.transform.Find("OctoMagneticWallParticles1").GetComponent<ParticleSystem>().Clear();
                        MagneticFenceContainer.transform.Find("OctoMagneticWallParticles2").GetComponent<ParticleSystem>().Stop();
                        MagneticFenceContainer.transform.Find("OctoMagneticWallParticles2").GetComponent<ParticleSystem>().Clear();
                        AnimateOctopus("OCTO_TURNOFF");
                    }
                    else
                    {
                        AnimateOctopus("OCTO_TURNOFF");
                    }
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    AnimateOctopus("OCTO_CONFUSED");
                    combinationNumber = 0;
                    OctopusAttentionButtonMeshMaterial.material.SetColor("_EmissionColor", Color.red * 0f);
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

    //a specific method for animating the octopus
    //here we can confirm the opposites of the words we get from research objects
    public void AnimateOctopus(string animationName)
    {
        octoAnimInProgress = true;
        if (animationName == "OCTO_CONFUSED")
        {
            OctopusAnim.SetBool("CONFUSED", true);
            StartCoroutine("OctoAnimationFinish", 3f);
        }
        else if (animationName == "OCTO_LOWER")
        {
            OctopusAnim.SetBool("LOWER", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
        else if (animationName == "OCTO_LIFT")
        {
            OctopusAnim.SetBool("LIFT", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
        else if (animationName == "OCTO_TURNOFF")
        {
            OctopusAnim.SetBool("OFF", true);
            StartCoroutine("OctoAnimationFinish", 3f);

        }
        else if (animationName == "OCTO_TURNON")
        {
            OctopusAnim.SetBool("ON", true);
            StartCoroutine("OctoAnimationFinish", 3f);
        }
        else if (animationName == "OCTO_OPEN")
        {
            OctopusAnim.SetBool("OPEN", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
        else if (animationName == "OCTO_CLOSE")
        {
            OctopusAnim.SetBool("CLOSE", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
        else if (animationName == "OCTO_PLAY")  //play sound
        {
            OctopusAnim.SetBool("PLAY", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
        else if (animationName == "OCTO_MUTE")
        {
            OctopusAnim.SetBool("MUTE", true);
            StartCoroutine("OctoAnimationFinish", 4f);
        }
    }
    IEnumerator OctoAnimationFinish(float animationtime)
    {
        yield return new WaitForSecondsRealtime(animationtime);
        OctopusAnim.SetBool("CONFUSED", false);
        OctopusAnim.SetBool("LOWER", false);
        OctopusAnim.SetBool("LIFT", false);
        OctopusAnim.SetBool("OFF", false);
        OctopusAnim.SetBool("ON", false);
        OctopusAnim.SetBool("OPEN", false);
        OctopusAnim.SetBool("CLOSE", false);
        OctopusAnim.SetBool("PLAY", false);
        OctopusAnim.SetBool("MUTE", false);
        octoAnimInProgress = false;
    }
}

