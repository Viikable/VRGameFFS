using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class BoxDetecter : MonoBehaviour
    {
        VRTK_SnapDropZone boxSnap;
        bool notSnapped;
        GameObject previouslySnapped;
        static int boxCounter;

        // Use this for initialization
        void Start()
        {
            boxSnap = GetComponent<VRTK_SnapDropZone>();
            notSnapped = true;
            previouslySnapped = null;
            boxCounter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (boxSnap.GetCurrentSnappedObject() != null && boxSnap.GetCurrentSnappedObject().CompareTag("WoodenBox"))
            {
                previouslySnapped = boxSnap.GetCurrentSnappedObject();
                previouslySnapped.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript
                = previouslySnapped.GetComponent<GrabAttachMechanics.VRTK_ClimbableGrabAttach>();
                previouslySnapped.GetComponentInParent<BoxCollider>().enabled = true;
                if (notSnapped)
                {
                    notSnapped = false;
                    StartCoroutine("Wait");
                }
            }
            if (boxCounter >= 4 && previouslySnapped != null)
            {
                previouslySnapped.GetComponentInChildren<MeshCollider>().enabled = true;
            }
        }
        IEnumerator Wait()
        {
            Debug.Log("enteredwait");
            yield return new WaitForSecondsRealtime(0.27f);
            Debug.Log("Waited");
            Destroy(boxSnap);
            previouslySnapped.GetComponent<Rigidbody>().isKinematic = true;
            previouslySnapped.GetComponent<Rigidbody>().useGravity = false;
            boxCounter++;
        }
    }
}
