using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    using VRTK.Controllables.PhysicsBased;
    

    public class MarkerReset : MonoBehaviour
    {
        public VRTK_PhysicsPusher MarkerResetButton;
        public GameObject Marker;
        public Transform ResetLocation;
        bool reseted;
        VRTK_SnapDropZone storedSnapZone;

        private void Awake()
        {
            MarkerResetButton = GetComponentInChildren<VRTK_PhysicsPusher>();
            Marker = GameObject.Find("Marker");
            ResetLocation = gameObject.transform.Find("ResetLocation").transform;
            reseted = false;
            storedSnapZone = null;
        }
       
        void Update()
        {
            if (MarkerResetButton.AtMaxLimit() && !reseted)
            {
                reseted = true;
                Marker.transform.position = ResetLocation.transform.position;
                storedSnapZone = Marker.GetComponent<VRTK_InteractableObject>().GetStoredSnapDropZone();
                if (storedSnapZone != null)
                {
                storedSnapZone.ForceUnsnap();
                }
                Marker.GetComponent<Rigidbody>().isKinematic = true;
                Game_Manager.instance.beingUnSnapped = true;
                StartCoroutine("WaitForReset");
            }           
        }
        IEnumerator WaitForReset()
        {
            yield return new WaitForSecondsRealtime(0.05f);
            Marker.GetComponent<Rigidbody>().isKinematic = false;
            yield return new WaitForSecondsRealtime(0.5f);
            Game_Manager.instance.beingUnSnapped = false;
            reseted = false;
        }
    }
}
