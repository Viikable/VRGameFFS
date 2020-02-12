using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class BoxFloat : MonoBehaviour
{
    //goal, make the box float with physics and get up to the water level if pushed down by objects
    private bool startMoving;
    private bool notTouched;
    public int whatSideofTheBoxDown;

    float rotationSpeed;
    //Animator FloatAnim;
    private Collider BoxFloatUpsideMarker1;
    private Collider BoxFloatUpsideMarker2;
    private Collider BoxFloatUpsideMarker3;
    private Collider BoxFloatUpsideMarker4;
    private Collider BoxFloatUpsideMarker5;
    private Collider BoxFloatUpsideMarker6;

    //Vector3 Marker1Rotation;
    //Vector3 Marker2Rotation;
    //Vector3 Marker3Rotation;
    //Vector3 Marker4Rotation;
    //Vector3 Marker5Rotation;
    //Vector3 Marker6Rotation;

    Transform x90;
    Transform y90;
    Transform z90;
    Transform x90Neg;
    Transform y90Neg;
    Transform z90Neg;

    int futureXRotation;
    int futureYRotation;
    int futureZRotation;

    private void Start()
    {
        whatSideofTheBoxDown = 0;
        startMoving = false;
        notTouched = true;
        rotationSpeed = 20f;
        //FloatAnim = transform.parent.GetComponent<Animator>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker1").GetComponent<Collider>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker2").GetComponent<Collider>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker3").GetComponent<Collider>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker4").GetComponent<Collider>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker5").GetComponent<Collider>();
        BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker6").GetComponent<Collider>();

        //Marker1Rotation = BoxFloatUpsideMarker1.transform.rotation.eulerAngles;
        //Marker2Rotation = BoxFloatUpsideMarker2.transform.rotation.eulerAngles;
        //Marker3Rotation = BoxFloatUpsideMarker3.transform.rotation.eulerAngles;
        //Marker4Rotation = BoxFloatUpsideMarker4.transform.rotation.eulerAngles;
        //Marker5Rotation = BoxFloatUpsideMarker5.transform.rotation.eulerAngles;
        //Marker6Rotation = BoxFloatUpsideMarker6.transform.rotation.eulerAngles;

        x90 = transform.Find("90x");
        y90 = transform.Find("90y");
        z90 = transform.Find("90z");
        x90Neg = transform.Find("90xNeg");
        y90Neg = transform.Find("90yNeg");
        z90Neg = transform.Find("90zNeg");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && notTouched)
        {
            notTouched = false;
            StartCoroutine("WaitForRealism");
        }
        if (other.name == "WaterSlower")
        {
            startMoving = false;
        }
    }

    IEnumerator WaitForRealism()
    {
        yield return new WaitForSeconds(1.5f);
        startMoving = true;
    }

    void FixedUpdate()
    {
        RotationFixer();

        if (startMoving)
        {
            MovementStart();

        }
    }
    public void MovementStart()
    {
        if (startMoving)
        {
            GetComponent<Rigidbody>().useGravity = false;
            //FloatAnim.SetBool("Float", true);
            GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = GetComponent<VRTK_ClimbableGrabAttach>();
            //GetComponent<VRTK_InteractableObject>().isGrabbable = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().isKinematic = true;
            //if (whatSideofTheBoxDown == 0)
            //{
            transform.Translate(Vector3.up * 0.2f * Time.deltaTime, Space.World);
        }
    }
    //check whether any axis rotation is not "straight" and fixes it
    public void RotationFixer()
    {
        var step = rotationSpeed * Time.deltaTime;
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        if (transform.rotation.eulerAngles.x % 90 != 0 && transform.rotation.eulerAngles.x != 0)
        {
            int totalRotations = Mathf.FloorToInt(transform.rotation.eulerAngles.x / 90);
            float realRotation = transform.rotation.eulerAngles.x - totalRotations;

            if (realRotation >= 0)
            {
                if (realRotation >= 45f)
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
                if (realRotation <= -45f)
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
        //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
        if (transform.rotation.eulerAngles.y % 90 != 0 && transform.rotation.eulerAngles.y != 0)
        {
            int totalRotations = Mathf.FloorToInt(transform.rotation.eulerAngles.y / 90);
            float realRotation = transform.rotation.eulerAngles.y - totalRotations;

            if (realRotation >= 0)
            {
                if (realRotation >= 45f)
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
                if (realRotation <= -45f)
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
        //ZZZZZZZZZZZZZZZZZZZZZZZZZZZZ
        if (transform.rotation.eulerAngles.z % 90 != 0 && transform.rotation.eulerAngles.z != 0)
        {
            int totalRotations = Mathf.FloorToInt(transform.rotation.eulerAngles.z / 90);
            float realRotation = transform.rotation.eulerAngles.z - totalRotations;

            if (realRotation >= 0)
            {
                if (realRotation >= 45f)
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
                if (realRotation <= -45f)
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

                }
                else
                {

                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }

            }

            if (futureZRotation == 0)
            {

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

                }
                else
                {

                }
            }
            else if (futureXRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            //if futureXRotation is -90
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

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

                }
                else
                {

                }
            }
            else if (futureYRotation == 90)
            {
                if (futureXRotation == 0)
                {

                }
                else if (futureXRotation == 90)
                {

                }
                else
                {

                }
            }
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }

            }

            if (futureZRotation == 0)
            {

            }
        }




        // Rotate our transform a step closer to the target's.
    }
}

