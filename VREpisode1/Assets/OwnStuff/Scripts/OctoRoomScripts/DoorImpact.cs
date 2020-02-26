using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorImpact : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider == (WaterMovement.body || WaterMovement.head || WaterMovement.feet))
    //    {
    //        ToxicGasPush.PlayerBody.AddForce(new Vector3(0f, 0, 100f), ForceMode.Impulse);
    //        Debug.Log("Playercollision");
    //    }
    //    else if (collision.gameObject.GetComponent<Rigidbody>() != null)
    //    {
    //        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0, 50f), ForceMode.Impulse);
    //    }
    //    else if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
    //    {
    //        collision.gameObject.transform.parent.GetComponentInParent<Rigidbody>().AddForce(new Vector3(50f, 0, 50f) * 25, ForceMode.Impulse);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "BackpackCollider")
        {
            if (other == WaterMovement.head || other == WaterMovement.feet || other == WaterMovement.body)
            {
                ToxicGasPush.PlayerBody.AddForce(new Vector3(0f, 0f, -200f), ForceMode.Impulse);
                Debug.Log("Playercollision");
            }
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0, -10f), ForceMode.Impulse);
                Debug.Log("objectcollision");
            }
            else if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
            {
                other.transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0, -10f), ForceMode.Impulse);
                Debug.Log("objectcollisionp");
            }
            else
            {
                return;
            }
        }
    }
}
