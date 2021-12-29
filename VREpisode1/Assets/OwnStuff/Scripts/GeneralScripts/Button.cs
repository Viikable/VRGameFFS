using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class Button : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    [Tooltip("Ignored colliders")]
    public List<Collider> ignoredCollisions;
    //determines if button reaches press point, gotta add the stay pressed here later for door usage maybe
    public bool isPressedDown { get; private set; }
    public bool isAtStartPosition { get; private set; }
    public bool stayPressed { get; set; }
    Collider buttonCol;

    [Tooltip("Default is half of the collider length, increase up to total of collider length")]
    [Range(0.0f, 0.5f)]
    public float pressedDistance = 0.0f;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;
    protected override void Awake()
    {
        base.Awake();       
        hoverEntered.AddListener(StartPress);
        hoverExited.AddListener(EndPress);
        buttonCol = GetComponent<Collider>();
        isAtStartPosition = true;
        foreach (Collider col in ignoredCollisions)
        {
            Physics.IgnoreCollision(col, buttonCol);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        hoverEntered.RemoveListener(StartPress);
        hoverExited.RemoveListener(EndPress);
    }

    private void StartPress(HoverEnterEventArgs args)
    {
        //think about this too
        hoverInteractor = (XRBaseInteractor)args.interactorObject;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
    }

    private void EndPress(HoverExitEventArgs args)
    {
        if (!stayPressed)
        {
            hoverInteractor = null;
            previousHandHeight = 0.0f;

            previousPress = false;
            SetYPosition(yMax);
            isAtStartPosition = true;
            isPressedDown = false;
        }
        //think about this
        else
        {
            hoverInteractor = null;
        }
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {        
        yMin = transform.localPosition.y - (buttonCol.bounds.size.y * (0.5f + pressedDistance));
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }
    //checks world y positions and transfers it to local space
    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);      
        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
            isPressedDown = true;
            isAtStartPosition = false;
        }
        previousPress = inPosition;
    }

    private bool InPosition()  //in pressed position or not
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);  //checks if this y position is between yMin and yMin +0.01f and if is returns it
        return transform.localPosition.y == inRange;
    }
}
