using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyRaycast : MonoBehaviour {

    public float closestDistance;
    float correctionSpeed;
    float rotSpeed;
    float moveSpeed;
    public LayerMask activeLayers;
    bool rayHit;

	void Start ()
    {

        closestDistance = 0.5f;
        rayHit = false;
        correctionSpeed = 0.06f;
        rotSpeed = 0.2f;
        moveSpeed = 0.03f;
	}
	
	
	void Update ()
    {
        MoveRandomly();
        RotateRandomly();
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
    }

    private void MoveRandomly()
    {
        int x = Random.Range(1, 4);
        //int x = 1;
        if (!rayHit)
        {
            switch (x)
            {
                case 1:
                    transform.Translate(Vector3.forward * moveSpeed);
                    Debug.Log("forward");
                    break;
                case 2:
                    transform.Translate(Vector3.back * moveSpeed);
                    Debug.Log("back");
                    break;
                case 3:
                    transform.Translate(Vector3.up * moveSpeed);
                    Debug.Log("upwards");
                    break;
                case 4:
                    transform.Translate(Vector3.down * moveSpeed);
                    Debug.Log("downwards");
                    break;
                default:
                    break;
            }
        }
    }

    private void RotateRandomly()
    {
        int x = Random.Range(1, 4);
        //int x = 1;
        //if (!rayHit)
        //{
            switch (x)
            {
                case 1:
                    transform.Rotate(Vector3.forward * rotSpeed, Space.Self);
                    Debug.Log("forwardrot");
                    break;
                case 2:
                    transform.Rotate(Vector3.back * rotSpeed, Space.Self);
                    Debug.Log("backrot");
                    break;
                case 3:
                    transform.Rotate(Vector3.up * rotSpeed, Space.Self);
                    Debug.Log("upwardsrot");
                    break;
                case 4:
                    transform.Rotate(Vector3.down * rotSpeed, Space.Self);
                    Debug.Log("downwardsrot");
                    break;
                default:
                    break;
            //}
        }
    }

    private void RightRayCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.right * closestDistance);
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.right * closestDistance, Color.red);

        if (Physics.Raycast(ray, out hit, closestDistance, activeLayers))
        {
            transform.Translate(Vector3.left * correctionSpeed);
            Debug.Log("left");
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
            Debug.Log("right");
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
            Debug.Log("down");
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
            Debug.Log("up");
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
            Debug.Log("kaakko");
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
            Debug.Log("koillinen");
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
            Debug.Log("luode");
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
            Debug.Log("lounas");
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
            Debug.Log("kaakko2");
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
            Debug.Log("koillinen2");
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
            Debug.Log("luode2");
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
            Debug.Log("lounas2");
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
