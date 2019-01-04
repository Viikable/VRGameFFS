namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        //public bool AlreadyDid;
        GameObject LeverAudio;
        AudioSource LeverSource;
        [Tooltip("The game object which happens to move when we flip the switch")]
        public GameObject MovingObject;

        //private void Awake()
        //{
        //    AlreadyDid = false;
        //    LeverAudio = GameObject.Find("LeverAudioSource");
        //    LeverSource = LeverAudio.GetComponent<AudioSource>();
        //    MovingObject = GameObject.Find("MovingObject");
        //}

        //private void Update()                             //added by Taneli, basically controls what happens after the lever reaches a certain point
        //{
        //    if (displayText.text == "2.0" && AlreadyDid == false)
        //    {
        //        Debug.Log("We can do anything now!");
        //        AlreadyDid = true;
        //        LeverSource.Play();
        //        MovingObject.transform.Translate(Vector3.forward);
        //    }
        //}
        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
              
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {

                //Debug.Log(outputOnMax);
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                //Debug.Log(outputOnMin);
            }
        }
    }
   
   
}