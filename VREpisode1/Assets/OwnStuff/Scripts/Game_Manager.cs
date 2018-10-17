using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //just gonna collect loads of static variables here pm

    [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
    public bool IsBroom1Snapped;

    [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
    public bool IsBroom2Snapped;

    [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
    public bool IsBroom3Snapped;

    [Tooltip("checks if our player has snapped the broom to the janitor door in order to jank it open")]
    public bool IsBroom4Snapped;

    [Tooltip("checks if broom is still wood or not")]
    public bool IsBroom1Metallic;

    [Tooltip("checks if broom is still wood or not")]
    public bool IsBroom2Metallic;

    [Tooltip("checks if broom is still wood or not")]
    public bool IsBroom3Metallic;

    [Tooltip("checks if broom is still wood or not")]
    public bool IsBroom4Metallic;

    [Tooltip("checks if broom is ready to start the door cracking animation")]
    public bool PlayBroomAnimation;

    public GameObject Broom1;

    public GameObject Broom2;

    public GameObject Broom3;

    public GameObject Broom4;

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

        IsBroom1Snapped = false;

        IsBroom2Snapped = false;

        IsBroom3Snapped = false;

        IsBroom4Snapped = false;

        IsBroom1Metallic = false;

        IsBroom2Metallic = false;

        IsBroom3Metallic = false;

        IsBroom4Metallic = false;

        PlayBroomAnimation = false;

        Broom1 = GameObject.Find("BroomInTheJanitorHouse1");

        Broom2 = GameObject.Find("BroomInTheJanitorHouse2");

        Broom3 = GameObject.Find("BroomInTheJanitorHouse3");

        Broom4 = GameObject.Find("BroomInTheJanitorHouse4");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool GetIsBroomSnapped(int numberOfTheBroom)
    {
        if (numberOfTheBroom == 1)
        {
            return IsBroom1Snapped;
        }
        else if (numberOfTheBroom == 2)
        {
            return IsBroom2Snapped;
        }
        else if (numberOfTheBroom == 3)
        {
            return IsBroom3Snapped;
        }
        else if (numberOfTheBroom == 4)
        {
            return IsBroom4Snapped;
        }
        else
        {
            Debug.Log("No Broom with this number exists");
            return false;
        }
    }
    public bool GetIsBroomMetallic(int numberOfTheBroom)
    {
        if (numberOfTheBroom == 1)
        {
            return IsBroom1Metallic;
        }
        else if (numberOfTheBroom == 2)
        {
            return IsBroom2Metallic;
        }
        else if (numberOfTheBroom == 3)
        {
            return IsBroom3Metallic;
        }
        else if (numberOfTheBroom == 4)
        {
            return IsBroom4Metallic;
        }
        else
        {
            Debug.Log("No Broom with this number exists");
            return false;
        }
    }
    public void SetBroomSnapped(int numberOfTheBroom, bool SnappedOrNot)
    {
        if (numberOfTheBroom == 1)
        {
            IsBroom1Snapped = SnappedOrNot;
        }
        else if (numberOfTheBroom == 2)
        {
            IsBroom2Snapped = SnappedOrNot;
        }
        else if (numberOfTheBroom == 3)
        {
            IsBroom3Snapped = SnappedOrNot;
        }
        else if (numberOfTheBroom == 4)
        {
            IsBroom4Snapped = SnappedOrNot;
        }
        else
        {
            Debug.Log("No Broom with this number exists");
            return;
        }
    }
    public void SetBroomMetallic(int numberOfTheBroom, bool MetallicOrNot)
    {
        if (numberOfTheBroom == 1)
        {
            IsBroom1Metallic = MetallicOrNot;
        }
        else if (numberOfTheBroom == 2)
        {
            IsBroom2Metallic = MetallicOrNot;
        }
        else if (numberOfTheBroom == 3)
        {
            IsBroom3Metallic = MetallicOrNot;
        }
        else if (numberOfTheBroom == 4)
        {
            IsBroom4Metallic = MetallicOrNot;
        }
        else
        {
            Debug.Log("No Broom with this number exists");
            return;
        }
    }
    public bool GetPlayBroomAnimation(int numberOfTheBroom)
    {
        return PlayBroomAnimation;
    }
    public void StartBroomAnimation(int numberOfTheBroom)
    {
        if (PlayBroomAnimation)
        {
            switch (numberOfTheBroom)
            {
                case 1:
                    Destroy(Broom1);
                    break;
                case 2:
                    Destroy(Broom2);
                    break;
                case 3:
                    Destroy(Broom2);
                    break;
                case 4:
                    Destroy(Broom2);
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
                Destroy(Broom1);
                break;
            case 2:
                Destroy(Broom2);
                break;
            case 3:
                Destroy(Broom2);
                break;
            case 4:
                Destroy(Broom2);
                break;
            default:
                Debug.Log("NoBroomhere");
                break;
        }

    }

}

