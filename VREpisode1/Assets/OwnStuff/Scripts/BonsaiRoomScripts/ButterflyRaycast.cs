using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyRaycast : MonoBehaviour {

    float closestDistance;
    float correctionSpeed;
    //float rotSpeed;
    float moveSpeed;  // USE Levy flight!
    int levyFactorial;  // amount of repetitions for the movement
    int levyCounter;  //this calculates an amount of moves after which the next move will be repeated a few times
    int substitute; //this will save the random value of x so it can be repeated
    int direction;  // a random int to decide movement direction
    bool levyFlight; //is the long movement ongoing or not
    public LayerMask activeLayers;
    bool rayHit;

	void Start ()
    {

        closestDistance = 0.35f;
        rayHit = false;
        correctionSpeed = 0.04f;
        //rotSpeed = 0.2f;
        moveSpeed = 0.02f;
        levyFactorial = 50;
        levyCounter = 0;
        substitute = 0;
        direction = 1;
        levyFlight = false;
	}
	
	
	void Update ()
    {
        //RotateRandomly();
        RightRayCheck();
        LeftRayCheck();
        UpRayCheck();
        DownRayCheck();
        DiagonalLuodeRayCheck();
        DiagonalLounasRayCheck();
        DiagonalKaakkoRayCheck();
        DiagonalKoillinenRayCheck();
        DiagonalLuode2RayCheck();
        DiagonalLounas2RayCheck();
        DiagonalKaakko2RayCheck();
        DiagonalKoillinen2RayCheck();
        MoveRandomly();
    }

    private void MoveRandomly()
    {
        //if (!rayHit)
        //{
            direction = Random.Range(1, 7);          
            if (levyCounter < levyFactorial + direction && !levyFlight)
            {
                levyCounter++;
            }
            else if (levyCounter >= levyFactorial + direction && !levyFlight)
            {
                //initiate long movement in the same random direction
                levyFlight = true;
                substitute = direction;
            }
            else if (levyCounter < levyFactorial * 2 + direction)
            {
                direction = substitute;
                levyCounter++;             
            }
            else
            {
                levyCounter = 0;
                levyFlight = false;
            }
            switch (direction)
            {
                case 1:
                    transform.Translate(Vector3.forward * moveSpeed);                   
                    break;
                case 2:
                    transform.Translate(Vector3.back * moveSpeed);                   
                    break;
                case 3:
                    transform.Translate(Vector3.up * moveSpeed);                   
                    break;
                case 4:
                    transform.Translate(Vector3.down * moveSpeed);                  
                    break;
                case 5:
                    transform.Translate(Vector3.left * moveSpeed);                 
                    break;
                case 6:
                    transform.Translate(Vector3.right * moveSpeed);                   
                    break;
                default:
                    break;
            }
            levyFactorial = 0;
        }
    //}

    //private void RotateRandomly()
    //{
    //    int x = Random.Range(1, 4);
    //    //int x = 1;
    //    //if (!rayHit)
    //    //{
    //        switch (x)
    //        {
    //            case 1:
    //                transform.Rotate(Vector3.forward * rotSpeed, Space.Self);
    //                Debug.Log("forwardrot");
    //                break;
    //            case 2:
    //                transform.Rotate(Vector3.back * rotSpeed, Space.Self);
    //                Debug.Log("backrot");
    //                break;
    //            case 3:
    //                transform.Rotate(Vector3.up * rotSpeed, Space.Self);
    //                Debug.Log("upwardsrot");
    //                break;
    //            case 4:
    //                transform.Rotate(Vector3.down * rotSpeed, Space.Self);
    //                Debug.Log("downwardsrot");
    //                break;
    //            default:
    //                break;
    //        //}
    //    }
    //}

    private void RightRayCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.right * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.right * closestDistance, Color.red);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(Vector3.left * correctionSpeed);           
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void LeftRayCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.left * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.left * closestDistance, Color.red);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(Vector3.right * correctionSpeed);         
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }

    private void UpRayCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.up * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.up * closestDistance, Color.red);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(Vector3.down * correctionSpeed);            
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DownRayCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.down * closestDistance, Color.red);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(Vector3.up * correctionSpeed);          
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalLuodeRayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, 1, 1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(1, 1, 1) * closestDistance, Color.green);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(-1, -1, -1) * correctionSpeed);           
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalLounasRayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, -1, 1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(1, -1, 1) * closestDistance, Color.magenta);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(-1, 1, -1) * correctionSpeed);          
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalKaakkoRayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, -1, -1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(1, -1, -1) * closestDistance, Color.magenta);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(-1, 1, 1) * correctionSpeed);          
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalKoillinenRayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, 1, -1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(1, 1, -1) * closestDistance, Color.white);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(-1, -1, 1) * correctionSpeed);         
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }

    private void DiagonalLuode2RayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(-1, 1, 1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(-1, 1, 1) * closestDistance, Color.yellow);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(1, -1, -1) * correctionSpeed);           
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalLounas2RayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(-1, -1, 1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(-1, -1, 1) * closestDistance, Color.yellow);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(1, 1, -1) * correctionSpeed);           
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalKaakko2RayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(-1, -1, -1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(-1, -1, -1) * closestDistance, Color.yellow);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(1, 1, 1) * correctionSpeed);        
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }
    private void DiagonalKoillinen2RayCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(-1, 1, -1) * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + new Vector3(-1, 1, -1) * closestDistance, Color.yellow);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(new Vector3(1, -1, 1) * correctionSpeed);           
            if (!rayHit)
            {
                rayHit = true;
                StartCoroutine(WaitForCorrections());
            }
        }
    }

    IEnumerator WaitForCorrections()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        rayHit = false;
    }
}
