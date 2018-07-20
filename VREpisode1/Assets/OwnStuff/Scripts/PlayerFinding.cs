namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerFinding : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            VRTK_PlayerObject.SetPlayerObject(gameObject, VRTK_PlayerObject.ObjectTypes.CameraRig);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
