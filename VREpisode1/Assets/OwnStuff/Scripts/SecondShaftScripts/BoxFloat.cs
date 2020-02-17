using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class BoxFloat : MonoBehaviour
{
    //goal, make the box float with physics and get up to the water level if pushed down by objects
    public static bool startMoving;
    public static bool tooDeep;
    public static Rigidbody boxBody;
    
    float rotationSpeed;

    float totalRotationsX;
    float totalRotationsY;
    float totalRotationsZ;

    [Tooltip("This detects if the box is underwater too much and lifts it up automatically")]
    Collider MiddleMark;

    Transform x0y0z0;

    //if no x, y or z it is 0

    // only one non-zero
    Transform x90;
    Transform y90;
    Transform z90;
    Transform x90Neg;
    Transform y90Neg;
    Transform z90Neg;

    //two non-zero
    Transform x90y90;
    Transform x90z90;
    Transform y90z90;

    Transform x90y90Neg;
    Transform x90Negy90;
    Transform x90Negy90Neg;

    Transform x90z90Neg;
    Transform x90Negz90;
    Transform x90Negz90Neg;
   
    Transform y90z90Neg;
    Transform y90Negz90;
    Transform y90Negz90Neg;

    //all three non-zero
    Transform x90y90z90;

    Transform x90y90Negz90;
    Transform x90y90z90Neg;
    Transform x90y90Negz90Neg;

    Transform x90Negy90z90;

    Transform x90Negy90Negz90;
    Transform x90Negy90z90Neg;
    Transform x90Negy90Negz90Neg;

    int futureXRotation;
    int futureYRotation;
    int futureZRotation;

    private void Start()
    {
        startMoving = false;
        tooDeep = false;       
        rotationSpeed = 14f;
        totalRotationsX = 0;
        totalRotationsY = 0;
        totalRotationsZ = 0;
        boxBody = GetComponent<Rigidbody>();

        MiddleMark = transform.Find("BoxFloatMiddleMark").GetComponent<Collider>();
       
        x0y0z0 = transform.Find("x0y0z0");

        x90 = transform.Find("x90");
        y90 = transform.Find("y90");
        z90 = transform.Find("z90");
        x90Neg = transform.Find("x90Neg");
        y90Neg = transform.Find("y90Neg");
        z90Neg = transform.Find("z90Neg");

        x90y90 = transform.Find("x90y90");
        x90z90 = transform.Find("x90z90");
        y90z90 = transform.Find("y90z90");

        x90y90Neg = transform.Find("x90y90Neg");
        x90Negy90 = transform.Find("x90Negy90");
        x90Negy90Neg = transform.Find("x90Negy90Neg");


        x90z90Neg = transform.Find("x90z90Neg");
        x90Negz90 = transform.Find("x90Negz90");
        x90Negz90Neg = transform.Find("x90Negz90Neg");


        y90z90Neg = transform.Find("y90z90Neg");
        y90Negz90 = transform.Find("y90Negz90");
        y90Negz90Neg = transform.Find("y90Negz90Neg");
     
        x90y90z90 = transform.Find("x90y90z90");

        x90y90z90Neg = transform.Find("x90y90z90Neg");
        x90y90Negz90 = transform.Find("x90y90Negz90");
        x90y90Negz90Neg = transform.Find("x90y90Negz90Neg");

        x90Negy90z90 = transform.Find("x90Negy90z90");

        x90Negy90Negz90 = transform.Find("x90Negy90Negz90");
        x90Negy90z90Neg = transform.Find("x90Negy90z90Neg");
        x90Negy90Negz90Neg = transform.Find("x90Negy90Negz90Neg");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "GrabbableWater" && notTouched)
    //    {
    //        notTouched = false;
    //        StartCoroutine("WaitForRealism");
    //    }
    //    if (other.name == "WaterSlower")
    //    {
    //        startMoving = false;
    //    }
    //}

    //IEnumerator WaitForRealism()
    //{
    //    yield return new WaitForSecondsRealtime(1.5f);
    //    startMoving = true;
    //}

    void FixedUpdate()
    {
        if (startMoving)
        {
            MovementStart();
            RotationFixer();
        }
    }
    public void MovementStart()
    {
        if (startMoving)
        {
            GetComponent<Rigidbody>().useGravity = false;
            
            GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = GetComponent<VRTK_ClimbableGrabAttach>();

            if (!tooDeep)
            {
                //GetComponent<Rigidbody>().AddForce(Vector3.up * 1500 * Time.deltaTime);                
                transform.Translate(Vector3.up * 0.2f * Time.deltaTime, Space.World);
            }
            else
            {
                boxBody.AddForce(Vector3.up * 2.5f, ForceMode.Acceleration);
            }           
        }
    }
    //check whether any axis rotation is not "straight" and fixes it
    public void RotationFixer()
    {
        var step = rotationSpeed * Time.deltaTime;
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        if (transform.rotation.eulerAngles.x % 90 != 0 && transform.rotation.eulerAngles.x != 0)
        {
            totalRotationsX = Mathf.FloorToInt(transform.rotation.eulerAngles.x / 90);
            float realRotationX = transform.rotation.eulerAngles.x - totalRotationsX;

            if (realRotationX >= 0)
            {
                if (realRotationX >= 45f)
                {
                    futureXRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureXRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationX <= -45f)
                {
                    futureXRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureXRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        else
        {
            futureXRotation = Mathf.FloorToInt(transform.rotation.eulerAngles.x);
        }
        //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
        if (transform.rotation.eulerAngles.y % 90 != 0 && transform.rotation.eulerAngles.y != 0)
        {
            totalRotationsY = Mathf.FloorToInt(transform.rotation.eulerAngles.y / 90);
            float realRotationY = transform.rotation.eulerAngles.y - totalRotationsY;

            if (realRotationY >= 0)
            {
                if (realRotationY >= 45f)
                {
                    futureYRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureYRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationY <= -45f)
                {
                    futureYRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureYRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        else
        {
            futureXRotation = Mathf.FloorToInt(transform.rotation.eulerAngles.y);
        }
        //ZZZZZZZZZZZZZZZZZZZZZZZZZZZZ
        if (transform.rotation.eulerAngles.z % 90 != 0 && transform.rotation.eulerAngles.z != 0)
        {
            totalRotationsZ = Mathf.FloorToInt(transform.rotation.eulerAngles.z / 90);
            float realRotationZ = transform.rotation.eulerAngles.z - totalRotationsZ;

            if (realRotationZ >= 0)
            {
                if (realRotationZ >= 45f)
                {
                    futureZRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureZRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationZ <= -45f)
                {
                    futureZRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureZRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        else
        {
            futureXRotation = Mathf.FloorToInt(transform.rotation.eulerAngles.z);
        }
        //FUTURE

        //Xstart
        if (futureXRotation == 90)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90Neg.localRotation, step);
                }
            }
            else //if futureYRotation == -90
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90Neg.localRotation, step);
                }
            }
        }
        if (futureXRotation == -90)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negz90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90Neg.localRotation, step);
                }
            }
            else
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90Neg.localRotation, step);
                }
            }
        }
        if (futureXRotation == 0)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x0y0z0.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90Neg.localRotation, step);
                }
            }
            else
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90Neg.localRotation, step);
                }
            }
        }
        //YStart
        if (futureYRotation == 90)
        {
            if (futureXRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90Neg.localRotation, step);
                }
            }
            else if (futureXRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90Neg.localRotation, step);
                }
            }
            //if futureXRotation is -90
            else
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90Neg.localRotation, step);
                }
            }
        }
        else if (futureYRotation == -90)
        {
            if (futureXRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90Neg.localRotation, step);
                }
            }
            else if (futureXRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90Neg.localRotation, step);
                }
            }
            //if futureXRotation is -90
            else
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90Neg.localRotation, step);
                }
            }
        }
        else if (futureYRotation == 0)
        {
            if (futureXRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x0y0z0.localRotation, step);                
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90Neg.localRotation, step);
                }
            }
            else if (futureXRotation == 90)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90Neg.localRotation, step);
                }
            }
            //if futureXRotation is -90
            else
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negz90Neg.localRotation, step);
                }
            }
        }
        //Zstart
        if (futureZRotation == 90)
        {
            if (futureYRotation == 0)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90.localRotation, step);
                }
            }
            else
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90.localRotation, step);
                }
            }
        }
        else if (futureZRotation == -90)
        {
            if (futureYRotation == 0)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, z90Neg.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90Neg.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negz90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90z90Neg.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90z90Neg.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90z90Neg.localRotation, step);
                }
            }
            else
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Negz90Neg.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Negz90Neg.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Negz90Neg.localRotation, step);
                }
            }
        }
        else if (futureZRotation == 0)
        {
            if (futureYRotation == 0)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x0y0z0.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90.localRotation, step);
                }
            }
            else
            {
                if (futureXRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Neg.localRotation, step);
                }
                else if (futureXRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90y90Neg.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Negy90Neg.localRotation, step);
                }
            }
        }
    }
}

