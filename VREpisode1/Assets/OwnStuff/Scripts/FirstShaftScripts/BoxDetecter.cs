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
        GameObject invisible;
        static int boxCounter;
      
        void Start()
        {
            boxSnap = GetComponent<VRTK_SnapDropZone>();
            notSnapped = true;
            previouslySnapped = null;
            boxCounter = 0;
            invisible = null;
        }
        
        void Update()
        {
           
            if (boxSnap.GetCurrentSnappedObject() != null && boxSnap.GetCurrentSnappedObject().CompareTag("WoodenBox"))
            {
                previouslySnapped = boxSnap.GetCurrentSnappedObject();
                boxCounter++;
                invisible = GameObject.Find("InvisibleBox" + boxCounter.ToString());
                invisible.GetComponent<Collider>().enabled = true;
                invisible.GetComponent<MeshRenderer>().enabled = true;
                Destroy(previouslySnapped);
                GetComponent<Collider>().enabled = false;
                if (boxCounter < 5)
                {
                GameObject.Find("WoodenSnapZone" + boxCounter.ToString()).GetComponent<Collider>().enabled = true;
                }
            }
            
        }
        
    }
}
