using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.tag == "JanitorBroom")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer.ChangeBroomColour = true;
        }
        if (other.tag == "JanitorBroom1")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer1.ChangeBroomColour1 = true;
        }
        if (other.tag == "JanitorBroom2")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer2.ChangeBroomColour2 = true;
        }
        if (other.tag == "JanitorBroom3")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer3.ChangeBroomColour3 = true;
        }

    }
}
