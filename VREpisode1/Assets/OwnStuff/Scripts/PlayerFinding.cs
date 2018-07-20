namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerFinding : MonoBehaviour
    {
        protected Transform headset;
        protected Transform playArea;

        // Use this for initialization
        void Start()
        {
            VRTK_PlayerObject.SetPlayerObject(gameObject, VRTK_PlayerObject.ObjectTypes.CameraRig);
            headset = VRTK_SharedMethods.AddCameraFade();
            playArea = VRTK_DeviceFinder.PlayAreaTransform();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
