using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFloat : MonoBehaviour {
    private bool startMoving;
    private bool notTouched;
    public int whatSideofTheBoxDown;
    Animator FloatAnim;

    private void Awake()
    {
        whatSideofTheBoxDown = 0;
        startMoving = false;
        notTouched = true;
        FloatAnim = transform.parent.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && notTouched)
        {
            notTouched = false;
            StartCoroutine("WaitForRealism");            
        }
        //if (other.name == "ShaftCeiling")
        //{
        //    stop = true;
        //}
    }
    IEnumerator WaitForRealism()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        startMoving = true;
    }

    void Update () {

    if (startMoving)
        {
            GetComponent<Rigidbody>().useGravity = false;
            FloatAnim.SetBool("Float", true); 
            if (whatSideofTheBoxDown == 0)
            {
                transform.Translate(new Vector3(0, 0, 1) * 0.005f);
            }
            if (whatSideofTheBoxDown == 1)
            {
                transform.Translate(new Vector3(0, 0, -1) * 0.005f);
            }
            if (whatSideofTheBoxDown == 2)
            {
                transform.Translate(new Vector3(0, 1, 0) * 0.005f);
            }
            if (whatSideofTheBoxDown == 3)
            {
                transform.Translate(new Vector3(0, -1, 0) * 0.005f);
            }
            if (whatSideofTheBoxDown == 4)
            {
                transform.Translate(new Vector3(-1, 0, 0) * 0.005f);
            }
            if (whatSideofTheBoxDown == 5)
            {
                transform.Translate(new Vector3(1, 0, 0) * 0.005f);
            }
        }
    //if (Random.Range(0,2) == 1)
    //    {
    //        FloatAnim.SetBool("Mirror", true);
    //    }
    //else
    //    {
    //        FloatAnim.SetBool("Mirror", false);
    //    }
    }
}
