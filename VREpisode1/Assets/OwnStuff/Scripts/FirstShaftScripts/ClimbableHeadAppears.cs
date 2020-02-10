using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClimbableHeadAppears : MonoBehaviour {
    VRTK_SnapDropZone WallCrack;
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
        WallCrack = GetComponent<VRTK_SnapDropZone>();
        JuhaniHeadCollider1 = GameObject.Find("JuhaniClimbableHeadCollider1");
        JuhaniHeadCollider2 = GameObject.Find("JuhaniClimbableHeadCollider2");
        JuhaniMouthCollider = GameObject.Find("JuhaniUnClimbableMouthCollider");
        JuhaniClimbableHeadset = GameObject.Find("JuhaniHeadClimbableHeadset");
        ToxicGasLeak = GameObject.Find("ToxicGasLeaks");
        ToxicGas = ToxicGasLeak.GetComponent<ParticleSystem>();
        ToxicGasMouth = GameObject.Find("ToxicGasLeakMouth").GetComponent<ParticleSystem>();
        ToxicGasUnderWater = GameObject.Find("ToxicGasLeakUnderWater").GetComponent<ParticleSystem>();
        ToxicGasMouth.Stop();
        notDone = true;
    }
    void Update()
    {
        if (WallCrack.GetCurrentSnappedObject() != null && notDone)
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
        Destroy(WallCrack.GetCurrentSnappedObject());
        ToxicGas.Stop();
        foreach (Collider col in ToxicGasLeak.GetComponentsInChildren<Collider>())
        {
            col.enabled = false;
        }
        ToxicGasMouth.Play();
    }
}

