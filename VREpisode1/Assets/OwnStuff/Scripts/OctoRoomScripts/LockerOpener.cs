using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class LockerOpener : MonoBehaviour
{
    //possibly inherit this for many lockers
    //place this script into the RotatinParent gameobject and set its rotation to (0,0,0)

    public bool open;
    public bool close;
    protected VRTK_PhysicsPusher Button;
    //this gameobject will be the parent of the button and it should be placed to a hinge's position in order to cause smooth rotation
    public Transform RotatingJoint;
    [Tooltip("Set this to the desired rotation when the locker is in open position")]
    public float targetOpenRotation;
 	
	protected virtual void Start()
    {
        Button = GetComponentInChildren<VRTK_PhysicsPusher>();
        open = false;
        close = false;
        RotatingJoint = gameObject.transform;
    }
		
	void Update ()
    {     
        if (!open && !close && Button.AtMaxLimit() && Button.stayPressed)
        {
            open = true;
        }
        if (open)
        {
            // try Quaternion.Euler here next time as quaternions have negative values
            if (targetOpenRotation < 0f && ((RotatingJoint.localRotation.eulerAngles.y > 360f + targetOpenRotation) || RotatingJoint.localRotation.eulerAngles.y == 0f))
            {
                RotatingJoint.RotateAround(RotatingJoint.position, new Vector3(0f, -1f, 0f), 30 * Time.deltaTime);               
            }
            else if (targetOpenRotation >= 0f && RotatingJoint.localRotation.y < targetOpenRotation)
            {
                RotatingJoint.RotateAround(RotatingJoint.position, new Vector3(0f, 1f, 0f), 30 * Time.deltaTime);
            }
            else
            {
                Button.stayPressed = false;
                open = false;
                close = true;
                StartCoroutine("WaitForPress");
            }
        }
        else if (close)
        {
            if (Button.AtMaxLimit() && Button.stayPressed)
            {
                if (targetOpenRotation < 0f && RotatingJoint.localRotation.eulerAngles.y > 0.25f)
                {
                    RotatingJoint.RotateAround(RotatingJoint.position, new Vector3(0f, 1f, 0f), 30 * Time.deltaTime);
                }
                else if (targetOpenRotation > 0f && RotatingJoint.localRotation.eulerAngles.y > 0f)
                {
                    RotatingJoint.RotateAround(RotatingJoint.position, new Vector3(0f, -1f, 0f), 30 * Time.deltaTime);
                }
                else
                {
                    close = false;
                    Button.stayPressed = false;
                    StartCoroutine("WaitForPress");
                }
            }
        }
    }
    IEnumerator WaitForPress()
    {
        yield return new WaitForSecondsRealtime(1f);
        Button.stayPressed = true;
    }
}
