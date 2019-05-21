using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldParticle : MonoBehaviour {
    public float _moveSpeed;
    public int _audioBand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<RightHauki>() != null && _moveSpeed > 0)
        {
            this.transform.position += transform.up * _moveSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
        else if (_moveSpeed > 0)
        {
            this.transform.position += transform.up * _moveSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(-90, 0, -90);
            
        }
        else
        {
            //Debug.Log("zeromvspd");
            return;
        }
        
        //if (transform.rotation.x <= -140)
        //{
        //    transform.rotation = Quaternion.Euler(-110, 0, -90);
        //}
        //if (transform.rotation.x >= -30)
        //{
        //    transform.rotation = Quaternion.Euler(-60, 0, -90);
        //}
    }

    public void ApplyRotation(Vector3 rotation, float rotateSpeed)
    {
        Quaternion targetRotation = Quaternion.LookRotation(rotation.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        
    }
}
