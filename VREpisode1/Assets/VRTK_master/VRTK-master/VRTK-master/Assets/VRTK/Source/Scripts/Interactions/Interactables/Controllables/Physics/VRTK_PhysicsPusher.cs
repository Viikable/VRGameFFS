// Physics Pusher|PhysicsControllables|110020
namespace VRTK.Controllables.PhysicsBased
{
    using UnityEngine;
    using System.Collections;

    /// <summary>
    /// A physics based pushable pusher.
    /// </summary>
    /// <remarks>
    /// **Required Components:**
    ///  * `Collider` - A Unity Collider to determine when an interaction has occured. Can be a compound collider set in child GameObjects. Will be automatically added at runtime.
    ///  * `Rigidbody` - A Unity Rigidbody to allow the GameObject to be affected by the Unity Physics System. Will be automatically added at runtime.
    ///
    /// **Optional Components:**
    ///  * `VRTK_ControllerRigidbodyActivator` - A Controller Rigidbody Activator to automatically enable the controller rigidbody upon touching the pusher.
    /// 
    /// **Script Usage:**
    ///  * Create a pusher container GameObject and set the GameObject that is to become the pusher as a child of the newly created container GameObject.
    ///  * Place the `VRTK_PhysicsPusher` script onto the GameObject that is to become the pusher.
    ///
    ///   > The Physics Pusher script must not be on a root level GameObject. Any runtime world positioning of the pusher must be set on the parent container GameObject.
    /// </remarks>
    [AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Physics/VRTK_PhysicsPusher")]
    public class VRTK_PhysicsPusher : VRTK_BasePhysicsControllable
    {
        [Header("Pusher Settings")]

        
        [Tooltip("The local space distance along the `Operate Axis` until the pusher reaches the pressed position.")]
        public float pressedDistance = 0.1f;
        [Tooltip("If this is checked then the pusher will stay in the pressed position when it reaches the maximum position.")]
        public bool stayPressed = false;
        [Tooltip("The threshold in which the pusher's current normalized position along the `Operate Axis` has to be within the minimum and maximum limits of the pusher.")]
        [Range(0f, 1f)]
        public float minMaxLimitThreshold = 0.01f;
        [Tooltip("The normalized position of the pusher between the original position and the pressed position that will be considered as the resting position for the pusher.")]
        [Range(0f, 1f)]
        public float restingPosition = 0f;
        [Tooltip("The normalized value that the pusher can be from the `Resting Position` before the pusher is considered to be resting when not being interacted with.")]
        [Range(0f, 1f)]
        public float restingPositionThreshold = 0.01f;
        [Tooltip("The normalized position of the pusher between the original position and the pressed position. `0f` will set the pusher position to the original position, `1f` will set the pusher position to the pressed position.")]
        [Range(0f, 1f)]
        public float positionTarget = 0f;
        [Tooltip("The amount of force to apply to push the pusher towards the intended target position.")]
        public float targetForce = 10f;

        protected ConfigurableJoint controlJoint;
        protected bool createControlJoint;
        protected Vector3 previousLocalPosition;
        protected bool pressedDown;
        protected float previousPositionTarget;

        /// <summary>
        /// The GetValue method returns the current position value of the pusher.
        /// </summary>
        /// <returns>The actual position of the pusher.</returns>
        public override float GetValue()
        {
            return transform.localPosition[(int)operateAxis];
        }

        /// <summary>
        /// The GetNormalizedValue method returns the current position value of the pusher normalized between `0f` and `1f`.
        /// </summary>
        /// <returns>The normalized position of the pusher.</returns>
        public override float GetNormalizedValue()
        {
            return VRTK_SharedMethods.NormalizeValue(GetValue(), originalLocalPosition[(int)operateAxis], PressedPosition()[(int)operateAxis]);
        }

        /// <summary>
        /// The SetValue method is not implemented as the pusher resets automatically.
        /// </summary>
        /// <param name="value">Not used.</param>
        public override void SetValue(float value)
        {
        }

        /// <summary>
        /// The IsResting method returns whether the pusher is currently at it's resting position.
        /// </summary>
        /// <returns>Returns `true` if the pusher is currently at the resting position.</returns>
        public override bool IsResting()
        {
            float normalizedValue = GetNormalizedValue();
            return (interactingCollider == null && (normalizedValue < (restingPosition + restingPositionThreshold) && normalizedValue > (restingPosition - restingPositionThreshold)));
        }

        /// <summary>
        /// The GetControlJoint method returns the joint associated with the control.
        /// </summary>
        /// <returns>The joint associated with the control.</returns>
        public virtual ConfigurableJoint GetControlJoint()
        {
            return controlJoint;
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Vector3 objectHalf = AxisDirection(true) * (transform.lossyScale[(int)operateAxis] * 0.5f);
            Vector3 initialPoint = transform.position + (objectHalf * Mathf.Sign(pressedDistance));
            Vector3 destinationPoint = initialPoint + (AxisDirection(true) * pressedDistance);
            Gizmos.DrawLine(initialPoint, destinationPoint);
            Gizmos.DrawSphere(destinationPoint, 0.01f);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetupJoint();
            previousLocalPosition = Vector3.one * float.MaxValue;
            pressedDown = false;
        }

        protected override void OnDisable()
        {
            if (stayPressed && pressedDown)
            {
                previousPositionTarget = positionTarget;
                positionTarget = 1f;
            }

            if (createControlJoint)
            {
                Destroy(controlJoint);
            }
            base.OnDisable();
        }

        protected virtual void FixedUpdate()
        {
            SetRigidbodyVelocity(Vector3.zero);
            ForceLocalPosition();
        }
        //private int firstTimeError = 0;
        protected virtual void Update()
        {
            if (elev.Set1ToFreezeOnly)
            {
                ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
                ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().positionTarget = 0f;
                elev.Set1ToFreezeOnly = false;
            }
            if (elev.Set2ToFreezeOnly)
            {
                ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
                ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().positionTarget = 0f;
                elev.Set2ToFreezeOnly = false;
            }
            CheckUnpress();
            SetTargetPosition();
            EmitEvents();
            if (!pressedDown && stayPressed && AtMaxLimit())
            {
                //Debug.Log("maxlimit?");
                StayPressed();
            }
        }

        protected override void ConfigueRigidbody()
        {
            SetRigidbodyGravity(false);
            SetRigidbodyCollisionDetectionMode(CollisionDetectionMode.ContinuousDynamic);
            SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation);
        }

        protected override void EmitEvents()
        {
            bool positionChanged = !VRTK_SharedMethods.Vector3ShallowCompare(transform.localPosition, previousLocalPosition, equalityFidelity);

            //Force the position to the max position if it should be there but isn't
            if (!positionChanged && positionTarget == 1f && !VRTK_SharedMethods.Vector3ShallowCompare(transform.localPosition, transform.localPosition + (pressedDistance * AxisDirection()), equalityFidelity))
            {
                Vector3 fixedPosition = Vector3.zero;
                for (int axis = 0; axis < 3; axis++)
                {
                    fixedPosition[axis] = (axis == (int)operateAxis ? originalLocalPosition[axis] + pressedDistance : transform.localPosition[axis]);
                }
                transform.localPosition = fixedPosition;
                positionChanged = true;
            }

            if (positionChanged)
            {
                //Debug.Log("position changed");
                float currentPosition = GetNormalizedValue();
                ControllableEventArgs payload = EventPayload();
                OnValueChanged(payload);
                float minThreshold = minMaxLimitThreshold;
                float maxThreshold = 1f - minMaxLimitThreshold;

                if (currentPosition >= maxThreshold && !AtMaxLimit())
                {
                    atMaxLimit = true;
                    OnMaxLimitReached(payload);
                    //Debug.Log("currpos greater than maxThreshhold");
                    StayPressed();
                }
                else if (currentPosition <= minThreshold && !AtMinLimit())
                {
                    //Debug.Log("minlimit");
                    atMinLimit = true;
                    OnMinLimitReached(payload);
                }
                else if (currentPosition > minThreshold && currentPosition < maxThreshold)
                {
                    if (AtMinLimit())
                    {
                        OnMinLimitExited(payload);
                    }
                    if (AtMaxLimit())
                    {
                        OnMaxLimitExited(payload);
                    }

                    atMinLimit = false;
                    atMaxLimit = false;
                }
            }

            if (IsResting())
            {
                OnRestingPointReached(EventPayload());
            }
            previousLocalPosition = transform.localPosition;
        }

        protected virtual void ForceLocalPosition()
        {
            float xPos = (operateAxis == OperatingAxis.xAxis ? transform.localPosition.x : originalLocalPosition.x);
            float yPos = (operateAxis == OperatingAxis.yAxis ? transform.localPosition.y : originalLocalPosition.y);
            float zPos = (operateAxis == OperatingAxis.zAxis ? transform.localPosition.z : originalLocalPosition.z);
            transform.localPosition = new Vector3(xPos, yPos, zPos);
        }

        protected virtual void CheckUnpress()
        {
            if (this.name == "Screen1Button" || this.name == "Screen2Button" || this.name == "Screen3Button"
                || this.name == "ElevatorButton1" || this.name == "ElevatorButton2" && !stayPressed)             //TANELIMOD
            {
                positionTarget = 0f;
            }
            else if (!stayPressed && pressedDown)
            {
                SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation);
                positionTarget = previousPositionTarget;
                pressedDown = false;
            }
        }

        protected virtual void SetTargetPosition()
        {
            if (controlJoint != null)
            {
                controlJoint.targetPosition = (AxisDirection() * Mathf.Sign(pressedDistance)) * Mathf.Lerp(controlJoint.linearLimit.limit, -controlJoint.linearLimit.limit, positionTarget);
            }
        }

        protected virtual Vector3 PressedPosition()
        {
            return originalLocalPosition + (AxisDirection() * pressedDistance);
        }

        protected virtual void SetupJoint()
        {
            //move transform towards activation distance
            transform.localPosition = originalLocalPosition + (AxisDirection() * (pressedDistance * 0.5f));

            controlJoint = GetComponent<ConfigurableJoint>();
            createControlJoint = false;
            if (controlJoint == null)
            {
                controlJoint = gameObject.AddComponent<ConfigurableJoint>();
                createControlJoint = true;

                controlJoint.angularXMotion = ConfigurableJointMotion.Locked;
                controlJoint.angularYMotion = ConfigurableJointMotion.Locked;
                controlJoint.angularZMotion = ConfigurableJointMotion.Locked;

                controlJoint.xMotion = (operateAxis == OperatingAxis.xAxis ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
                controlJoint.yMotion = (operateAxis == OperatingAxis.yAxis ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
                controlJoint.zMotion = (operateAxis == OperatingAxis.zAxis ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);

                JointDrive snapDriver = new JointDrive();
                snapDriver.positionSpring = 1000f;
                snapDriver.positionDamper = 10f;
                snapDriver.maximumForce = targetForce;

                controlJoint.xDrive = snapDriver;
                controlJoint.yDrive = snapDriver;
                controlJoint.zDrive = snapDriver;

                SoftJointLimit linearLimit = new SoftJointLimit();
                linearLimit.limit = Mathf.Abs(pressedDistance * 0.5f);
                controlJoint.linearLimit = linearLimit;
                controlJoint.connectedBody = connectedTo;
            }
        }
        private void Start()
        {
            Screen1Button = GameObject.Find("Screen1Button");
            Screen2Button = GameObject.Find("Screen2Button");
            Screen3Button = GameObject.Find("Screen3Button");
            ElevatorButton1 = GameObject.Find("ElevatorButton1");
            ElevatorButton2 = GameObject.Find("ElevatorButton2");
            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
            elev = GameObject.Find("ELEVATOR2.0").GetComponent<ElevatorMovement>();
            ElevatorButton1.GetComponent<ConfigurableJoint>().connectedBody = elev.GetComponent<Rigidbody>();
            ElevatorButton2.GetComponent<ConfigurableJoint>().connectedBody = elev.GetComponent<Rigidbody>();

        }

        private ElevatorMovement elev;
        GameObject Screen1Button;
        GameObject Screen2Button;
        GameObject Screen3Button;
        public GameObject ElevatorButton1;
        public GameObject ElevatorButton2;
        

        protected virtual void StayPressed()
        {
            if (this.name == "ElevatorButton1" || this.name == "ElevatorButton2")
            {
                if (this.name == "ElevatorButton1" && !ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().pressedDown && Game_Manager.instance.ElevatorMoving == 0)
                {
                    if (elev.CanGoUp)
                    {
                        Game_Manager.instance.ElevatorMoving = 2;        //moves UP
                        ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                        ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
                        ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().pressedDown = true;
                        Debug.Log("elevator1");
                        if (ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().pressedDown)
                        {
                            Debug.Log("elevator1when2");
                            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().pressedDown = false;
                            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().positionTarget = 0f;
                            ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
                        }
                    }
                    else
                    {
                        //Debug.Log("can't go up");
                    }
                }
                if (this.name == "ElevatorButton2" && !ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().pressedDown && Game_Manager.instance.ElevatorMoving == 0)
                {
                    if (elev.CanMoveDown)
                    {
                        Game_Manager.instance.ElevatorMoving = 1;      //moves DOWN
                        Debug.Log("elevator2");
                        ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                        ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
                        ElevatorButton2.GetComponent<VRTK_PhysicsPusher>().pressedDown = true;
                        if (ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().pressedDown)
                        {
                            Debug.Log("elevator2when1");
                            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;                           
                            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().pressedDown = false;
                            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().positionTarget = 0f;
                            ElevatorButton1.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraintsPlus(RigidbodyConstraints.FreezePositionY, RigidbodyConstraints.FreezeRotation, RigidbodyConstraints.FreezePositionX);
                        }
                    }
                    else
                    {
                        //Debug.Log("can't move down");
                    }
                }               
            }

            //write here any code that needs to happen after the button is pressed and stays pressed              

            if (/*stayPressed && */this.name == "Screen1Button" && !Screen1Button.GetComponent<VRTK_PhysicsPusher>().pressedDown)
            {
                Debug.Log("pressed1");
                ConveyorBeltController.PressedScreen1 = true;

                Screen1Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                Screen1Button.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
                Screen1Button.GetComponent<VRTK_PhysicsPusher>().pressedDown = true;
                if (ConveyorBeltController.PressedScreen3)
                {
                    Debug.Log("pressed1while3");
                    Screen3Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                    Screen3Button.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation); 
                    Screen3Button.GetComponent<VRTK_PhysicsPusher>().pressedDown = false;
                }
            }
            else if (/*stayPressed && */this.name == "Screen2Button" && !Screen2Button.GetComponent<VRTK_PhysicsPusher>().pressedDown)
            {
                Debug.Log("pressed2");
                ConveyorBeltController.PressedScreen2 = true;
                Screen2Button.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
                Screen2Button.GetComponent<VRTK_PhysicsPusher>().pressedDown = true;
            }
            else if (/*stayPressed && */this.name == "Screen3Button" && !Screen3Button.GetComponent<VRTK_PhysicsPusher>().pressedDown)
            {
                Debug.Log("pressed3");
                ConveyorBeltController.PressedScreen3 = true;
                Screen3Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
                Screen3Button.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
                Screen3Button.GetComponent<VRTK_PhysicsPusher>().pressedDown = true;
                if (ConveyorBeltController.PressedScreen1)
                {
                    Debug.Log("pressed3while1");
                    Screen1Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                    Screen1Button.GetComponent<VRTK_PhysicsPusher>().SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation); 
                    Screen1Button.GetComponent<VRTK_PhysicsPusher>().pressedDown = false;
                }
            }
            //else if (stayPressed && this.name != "ScreenButton1" && this.name != "ScreenButton2" && this.name != "ScreenButton3"
            //    && this.name != "ElevatorButton1" && this.name != "ElevatorButton2")
            //{
            //    Debug.Log("defaulted?");
            //    SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
            //    pressedDown = true;
            //    //default method              
            //}
            else if (this.name != "ElevatorButton1" && this.name != "ElevatorButton2")
            {
                Debug.Log("wtfhappened");
                return;               
            }
        }
    }
}
