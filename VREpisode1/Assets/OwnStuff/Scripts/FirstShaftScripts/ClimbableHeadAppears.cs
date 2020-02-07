using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClimbableHeadAppears : MonoBehaviour {
    //handles the juhanihead's attaching to the gasleak
    VRTK_SnapDropZone WallCrack;
    GameObject JuhaniMouthCollider;
    GameObject JuhaniHeadCollider1;
    GameObject JuhaniHeadCollider2;
    ParticleSystem ToxicGas;
    ParticleSystem ToxicGasMouth;
    GameObject ToxicGasLeak;
    bool notDone;
    [Header("This tells whether Juhanihead has been attached to the leak or not, it cannot be removed after attaching")]
    public static bool toxicLeakChanged;

    void Start () {
        WallCrack = GetComponent<VRTK_SnapDropZone>();
        JuhaniHeadCollider1 = GameObject.Find("JuhaniClimbableHeadCollider1");
        JuhaniHeadCollider2 = GameObject.Find("JuhaniClimbableHeadCollider2");
        JuhaniMouthCollider = GameObject.Find("JuhaniUnClimbableMouthCollider");
        ToxicGasLeak = GameObject.Find("ToxicGasLeak");
        ToxicGas = ToxicGasLeak.GetComponent<ParticleSystem>();
        ToxicGasMouth = GameObject.Find("ToxicGasLeakMouth").GetComponent<ParticleSystem>();
        ToxicGasMouth.Stop();
        notDone = true;
        toxicLeakChanged = false;
    }
    void Update()
    {
        if (WallCrack.GetCurrentSnappedObject() != null)
        {
            JuhaniHeadCollider1.GetComponent<Collider>().enabled = true;
            JuhaniHeadCollider2.GetComponent<Collider>().enabled = true;
            JuhaniMouthCollider.GetComponent<Collider>().enabled = true;
            GameObject.Find("JuhaniHeadClimbableHeadset").GetComponent<MeshRenderer>().enabled = true;
            if (notDone)
            {
                notDone = false;
                StartCoroutine("WaitForHead");
            }
        }
    }
    IEnumerator WaitForHead()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        Destroy(WallCrack.GetCurrentSnappedObject());
        ToxicGas.Stop();
        foreach (Collider tox in ToxicGasLeak.GetComponentsInChildren<Collider>())
        {
            tox.enabled = false;
        }
        ToxicGasMouth.Play();
        toxicLeakChanged = true;
    }
}

