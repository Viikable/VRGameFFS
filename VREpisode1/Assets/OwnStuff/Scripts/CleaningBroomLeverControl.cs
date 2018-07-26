namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class CleaningBroomLeverControl : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        [Tooltip("Whether the consequence for this switch has already happened or not")]
        public bool AlreadyDid;
        GameObject LeverAudio;                  //we could make this activate the announcer to tell you to stop cleaning now
        AudioSource LeverSource;
        [Tooltip("The game object which happens to move when we flip the switch")]
        public GameObject MovingObject;
        [Tooltip("The amount of times the broom has been moved from one end to")]
        public int BroomSwings;

        private void Awake()
        {
            AlreadyDid = false;
            LeverAudio = GameObject.Find("LeverAudioSource");
            LeverSource = LeverAudio.GetComponent<AudioSource>();
            MovingObject = GameObject.Find("MovingObject");
            BroomSwings = 0;
        }

        private void Update()                             //added by Taneli, basically controls what happens after the lever reaches a certain point
        {
           
            if (displayText.text == "3.0" && BroomSwings % 2 == 0 && !AlreadyDid) //counts the broom swings from end to the other one at a time
            {
                BroomSwings += 1;
            }
            if (displayText.text == "0.0" && BroomSwings % 2 == 1 && !AlreadyDid)
            {
                BroomSwings += 1;

            }
            if (BroomSwings == 5) { 
                Debug.Log("Cleaning Complete!");
                AlreadyDid = true;
            }
         
        }
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

                Debug.Log(outputOnMax);
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }
    }
}