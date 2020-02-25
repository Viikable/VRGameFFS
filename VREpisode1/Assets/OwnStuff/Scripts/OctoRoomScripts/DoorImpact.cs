using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorImpact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == (WaterMovement.body || WaterMovement.head || WaterMovement.feet))
        {
            ToxicGasPush.PlayerBody.AddForce(new Vector3(0f, 0, 100f), ForceMode.Impulse);
            Debug.Log("Playercollision");
        }
        else if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0, 50f), ForceMode.Impulse);
        }
        else if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.transform.parent.GetComponentInParent<Rigidbody>().AddForce(new Vector3(50f, 0, 50f) * 25, ForceMode.Impulse);
        }
    }  
}
