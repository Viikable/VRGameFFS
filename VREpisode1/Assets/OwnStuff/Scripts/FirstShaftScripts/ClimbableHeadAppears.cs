using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbableHeadAppears : MonoBehaviour {
    XRSocketInteractor WallCrack;
    GameObject JuhaniMouthCollider;
    GameObject JuhaniHeadCollider1;
    GameObject JuhaniHeadCollider2;
    GameObject JuhaniClimbableHeadset;
    GameObject ToxicGasLeak;
    ParticleSystem ToxicGas;
    ParticleSystem ToxicGasMouth;
    ParticleSystem ToxicGasUnderWater;
    bool notDone;

    void Start () {
        WallCrack = GetComponent<XRSocketInteractor>();
        JuhaniHeadCollider1 = GameObject.Find("JuhaniClimbableHeadCollider1");
        JuhaniHeadCollider2 = GameObject.Find("JuhaniClimbableHeadCollider2");
        JuhaniMouthCollider = GameObject.Find("JuhaniUnClimbableMouthCollider");
        JuhaniClimbableHeadset = GameObject.Find("JuhaniHeadClimbableHeadset");
        ToxicGasLeak = GameObject.Find("ToxicGasLeak");
        ToxicGas = ToxicGasLeak.GetComponent<ParticleSystem>();
        ToxicGasMouth = GameObject.Find("ToxicGasLeakMouth").GetComponent<ParticleSystem>();
        ToxicGasUnderWater = GameObject.Find("ToxicGasLeakUnderWater").GetComponent<ParticleSystem>();       
        notDone = true;
    }
    void Update()
    {
        if (WallCrack.firstInteractableSelected != null && notDone)
        {
            JuhaniHeadCollider1.GetComponent<Collider>().enabled = true;
            JuhaniHeadCollider2.GetComponent<Collider>().enabled = true;
            JuhaniMouthCollider.GetComponent<Collider>().enabled = true;
            JuhaniClimbableHeadset.GetComponent<MeshRenderer>().enabled = true;
            notDone = false;
            StartCoroutine("WaitForHead");
        }
    }
    IEnumerator WaitForHead()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        Destroy(WallCrack.firstInteractableSelected.transform.gameObject);
        ToxicGas.Stop();
        foreach (Collider col in ToxicGasLeak.GetComponentsInChildren<Collider>())
        {
            col.enabled = false;
        }
        ToxicGasMouth.Play();
    }
}

