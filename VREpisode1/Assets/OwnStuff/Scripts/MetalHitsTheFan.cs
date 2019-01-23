using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class MetalHitsTheFan : MonoBehaviour {
    AudioSource MetalSounds1;
    AudioSource MetalSounds2;
    AudioSource MetalSounds3;
    AudioSource MetalSounds4;
    AudioSource MetalSounds5;
    AudioSource MetalSounds6;
    Animator LavaAnim;
    GameObject Lava;
    MelterEnterTrigger trigger;
    int randomizer;
    int lavaWaiter;
    int randomLavaValue;
    float lavaMizer;
    float lavaFrequencyMizer;
    float lavaIncrement;
    bool insideTheMelter;
    bool goingBig;
    bool goingSmall;
    static float meltingTime = 0.0f;
    public static bool melterIsReady = false;
    public bool begone = false; //indicates when we get rid of the original metal
   
    private void Awake()
    {              
        MetalSounds1 = transform.Find("MetalSounds1").GetComponent<AudioSource>();
        MetalSounds2 = transform.Find("MetalSounds2").GetComponent<AudioSource>();
        MetalSounds3 = transform.Find("MetalSounds3").GetComponent<AudioSource>();
        MetalSounds4 = transform.Find("MetalSounds4").GetComponent<AudioSource>();
        MetalSounds5 = transform.Find("MetalSounds5").GetComponent<AudioSource>();
        MetalSounds6 = transform.Find("MetalSounds6").GetComponent<AudioSource>();
        goingBig = true;
        goingSmall = false;
        randomizer = 0;
        lavaWaiter = 0;
        randomLavaValue = 0;
        lavaMizer = 0.7f;
        lavaFrequencyMizer = 0.7f;
        lavaIncrement = 0.025f;
        insideTheMelter = false;
        Lava = GameObject.Find("LavaSurface");
        LavaAnim = GameObject.Find("LavaSurface").GetComponent<Animator>();
        trigger = GameObject.Find("MelterObjectRegistererCollider").GetComponent<MelterEnterTrigger>();
        begone = false;
    }

    public bool InsideTheMelter
    {
        get { return insideTheMelter; }
        set { insideTheMelter = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyorPart")
        {
            if (randomizer == 1)
            {
                MetalSounds1.Play();
            }
            if (randomizer == 2)
            {
                MetalSounds2.Play();
            }
            if (randomizer == 3)
            {
                MetalSounds3.Play();
            }
            if (randomizer == 4)
            {
                MetalSounds4.Play();
            }
            if (randomizer == 5)
            {
                MetalSounds5.Play();
            }
            if (randomizer == 6)
            {
                MetalSounds6.Play();
            }
        }
    }      
    private void Update()
    {
        Debug.Log(begone);
        if (trigger.notMeltedYet == false)
        {
            begone = true;
        }
        randomizer = Random.Range(1,7);      //so between 1-6
        float newScale = Mathf.Lerp(0.23f, 0f, meltingTime); //kinda unnecessary but left here for practice reasons
        if (melterIsReady) 
        {
            Lava.GetComponent<MeshRenderer>().material.SetFloat("_NoiseScale", lavaMizer);
            Lava.GetComponent<MeshRenderer>().material.SetFloat("_NoiseFrequency", lavaFrequencyMizer);
            //Lava.GetComponent<MeshRenderer>().material.SetVector("_NoiseOffset", new Vector4(lavaFrequencyMizer, lavaFrequencyMizer, lavaFrequencyMizer, 0));
            //Debug.Log("lavachange");
            lavaMizer += lavaIncrement / 2;
            lavaFrequencyMizer += lavaIncrement / 8;
            if (lavaMizer >= 0.9f && goingBig && lavaWaiter >= 20)
            {
                //Debug.Log("going bigger");
                
                lavaIncrement = -0.01f;
                
                goingBig = false;
                goingSmall = true;
                lavaWaiter = 0;                
            }
            else if (lavaMizer <= 0.5f && goingSmall && lavaWaiter >= 20)
            {
                //Debug.Log("going smaller");
               
                lavaIncrement = 0.01f;                
                goingBig = true;
                goingSmall = false;
                lavaWaiter = 0;               
            }            
            
            lavaWaiter++;
            if (insideTheMelter && this.name == "MetalPiece1" || this.name == "MetalPiece2" || this.name == "MetalPiece3"
                || this.name == "MetalPiece4" || this.name == "MetalPiece5" || this.name == "MetalPiece6")
            {
                insideTheMelter = false;
            }
            //scale this specific piece of scrap metal slowly down and at the same time another animation rises the lava
            if ((this.name == "MetalPiece1" || this.name == "MetalPiece2" || this.name == "MetalPiece3"
            || this.name == "MetalPiece4" || this.name == "MetalPiece5" || this.name == "MetalPiece6") && begone == true)
            {
                Debug.Log("Useless");
                transform.localScale = new Vector3(newScale, newScale, newScale);                
                meltingTime += 0.1f * Time.deltaTime;       //makes the object disappear 
                this.tag = "Useless";
            }
            if (this.name == "PressedMetal1" || this.name == "PressedMetal2" || this.name == "PressedMetal3" || this.name == "PressedMetal4" || this.name == "PressedMetal5" || this.name == "PressedMetal6")
            {
                insideTheMelter = true;
            }
        }
    }
}
