namespace VRTK.Examples
{
    using VRTK.Controllables.PhysicsBased;
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class CleaningBroomLeverControl : MonoBehaviour
    {
        //public VRTK_BaseControllable controllable;
        //public Text displayText;
        //public string outputOnMax = "Maximum Reached";
        //public string outputOnMin = "Minimum Reached";
        //protected int random;
        //[Tooltip("Whether the consequence for this switch has already happened or not")]
        //public bool AlreadyDid;
        //GameObject LeverAudio;                  //Sweeping sounds
        //GameObject LeverAudio2;
        //GameObject LeverAudio3;
        //GameObject LeverAudio4;
        //[Header("AudioSources")]
        //public AudioSource LeverSource;
        //public AudioSource LeverSource2;
        //public AudioSource LeverSource3;
        //public AudioSource LeverSource4;       
        //[Tooltip("The amount of times the broom has been moved from one end to the other")]
        //public int BroomSwings;

        //private void Awake()
        //{
        //    AlreadyDid = false;
        //    LeverAudio = GameObject.Find("LeverAudioSource");
        //    LeverAudio2 = GameObject.Find("LeverAudioSource2");
        //    LeverAudio3 = GameObject.Find("LeverAudioSource3");
        //    LeverAudio4 = GameObject.Find("LeverAudioSource4");
        //    LeverSource = LeverAudio.GetComponent<AudioSource>();
        //    LeverSource2 = LeverAudio2.GetComponent<AudioSource>();
        //    LeverSource3 = LeverAudio3.GetComponent<AudioSource>();
        //    LeverSource4 = LeverAudio4.GetComponent<AudioSource>();          
        //    BroomSwings = 0;
        //    random = Random.Range(0, 2);
        //}



        //private void Update()                             //added by Taneli, basically controls what happens after the lever reaches a certain point
        //{

        //    //VRTK_SDKManager sdkmanager = VRTK_SDKManager.instance;
        //    //sdkmanager.loadedSetup.modelAliasLeftController.transform.localPosition = Vector3.zero;
        //    //sdkmanager.loadedSetup.modelAliasRightController.transform.localPosition = Vector3.zero;


        //    int random = Random.Range(0, 2);

        //    if (displayText.text == "3.0" && BroomSwings % 2 == 0 && !AlreadyDid) //counts the broom swings from end to the other one at a time
        //    {
        //        if (BroomSwings == 0)
        //        {
        //            if (random == 0)
        //            {
        //                Debug.Log("played0");
        //                LeverSource.Play();
        //            }
        //            else
        //            {
        //                Debug.Log("played2");
        //                LeverSource2.Play();
        //            }
        //        }
        //        if (BroomSwings == 2)
        //        {
        //            if (random == 1)
        //            {
        //                LeverSource4.Play();
        //            }
        //            else
        //            {
        //                LeverSource3.Play();
        //            }
        //        }
        //        if (BroomSwings == 4)
        //        {
        //            if (random == 1)
        //            {
        //                LeverSource.Play();
        //            }
        //            else
        //            {
        //                LeverSource3.Play();
        //            }
        //        }
        //        BroomSwings += 1;

        //    }
        //    if (displayText.text == "0.0" && BroomSwings % 2 == 1 && !AlreadyDid)
        //    {
        //        Debug.Log("bch");
        //        if (BroomSwings == 1)
        //        {
        //            if (random == 0)
        //            {
        //                Debug.Log("played0");
        //                LeverSource.Play();
        //            }
        //            else
        //            {
        //                LeverSource2.Play();
        //            }
        //        }
        //        if (BroomSwings == 3)
        //        {
        //            if (random == 0)
        //            {
        //                LeverSource3.Play();
        //            }
        //            else
        //            {
        //                LeverSource4.Play();
        //            }
        //        }

        //        BroomSwings += 1;

        //    }
        //    if (displayText.text == "1.5" && !AlreadyDid)
        //    {
        //        if (random == 0)
        //        {
        //            LeverSource3.Play();
        //        }
        //        else
        //        {
        //            LeverSource4.Play();
        //        }

        //    }


        //    if (BroomSwings == 5 && !AlreadyDid)
        //    {
        //        Debug.Log("Cleaning Complete!");
        //        AlreadyDid = true;
        //        if (random == 0)
        //        {
        //            LeverSource3.Play();
        //            LeverSource.Play();
        //        }
        //        else
        //        {
        //            LeverSource4.Play();
        //            LeverSource2.Play();
        //        }
        //        VRTK_PhysicsRotator.ThisNeedsToStop = true;
        //    }


        //}
        ////    protected virtual void OnEnable()
        ////    {
        ////        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        ////        controllable.ValueChanged += ValueChanged;
        ////        controllable.MaxLimitReached += MaxLimitReached;
        ////        controllable.MinLimitReached += MinLimitReached;
        ////    }

        ////    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        ////    {
        ////        if (displayText != null)
        ////        {
        ////            displayText.text = e.value.ToString("F1");

        ////        }
        ////    }

        ////    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        ////    {
        ////        if (outputOnMax != "")
        ////        {

        ////            Debug.Log(outputOnMax);
        ////        }
        ////    }

        ////    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        ////    {
        ////        if (outputOnMin != "")
        ////        {
        ////            Debug.Log(outputOnMin);
        ////        }
        ////    }
        ////}
    }
}