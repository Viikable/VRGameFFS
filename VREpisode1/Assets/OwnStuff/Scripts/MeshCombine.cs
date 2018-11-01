using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshCombine : ScriptableWizard {

    public GameObject meshToCombine;

    [MenuItem("My Tools/Combine Meshes")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Combine Mesh", typeof(MeshCombine));
    }

    void OnWizardCreate()
    {
        if (meshToCombine != null)
        {



            MeshFilter[] meshFilters = meshToCombine.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                //meshFilters[i].gameObject.active = false;
                i++;
            }

            GameObject combinedMesh = new GameObject("CombinedMesh");



            combinedMesh.AddComponent<MeshFilter>();
            combinedMesh.AddComponent<MeshRenderer>();
            combinedMesh.GetComponent<MeshFilter>().sharedMesh = new Mesh();
            combinedMesh.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);


            Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/" + "CombinedMesh" + ".prefab");
            PrefabUtility.ReplacePrefab(combinedMesh, prefab, ReplacePrefabOptions.ConnectToPrefab);




        }

    }



}