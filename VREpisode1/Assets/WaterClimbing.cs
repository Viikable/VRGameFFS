namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;

    public class WaterClimbing : VRTK_InteractableObject
    {
        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            //ToggleKinematics(false);
            StartCoroutine(UngrabQuickly());
            Debug.Log("grabbedwater");
        }
        IEnumerator UngrabQuickly()
        {
            Debug.Log("beforewait");
            print(Time.time);
            yield return new WaitForSeconds(0.5f);
            print(Time.time);
            Debug.Log("afterwait");
            base.Ungrabbed();
        }

        //public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
        //{
        //    base.Ungrabbed(previousGrabbingObject);
        //    ToggleKinematics(true);
        //}

        //private void ToggleKinematics(bool state)
        //{
        //    foreach (Rigidbody rigid in transform.parent.GetComponentsInChildren<Rigidbody>())
        //    {
        //        rigid.isKinematic = state;
        //    }
        //}
    }
}