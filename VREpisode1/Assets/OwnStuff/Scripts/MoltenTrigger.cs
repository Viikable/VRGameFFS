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
<<<<<<< HEAD
=======
        if (other.tag == "JanitorBroom4")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer4.ChangeBroomColour4 = true;
        }
        if (other.tag == "JanitorBroom5")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer5.ChangeBroomColour5 = true;
        }
        if (other.tag == "JanitorBroom6")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer6.ChangeBroomColour6 = true;
        }
        if (other.tag == "JanitorBroom7")
        {
            Debug.Log("collidedJanitor");
            JanitorBroomTransformer7.ChangeBroomColour7 = true;
        }
>>>>>>> 7ad8228db9665294832f741dae0c99bc21950061

    }
}
