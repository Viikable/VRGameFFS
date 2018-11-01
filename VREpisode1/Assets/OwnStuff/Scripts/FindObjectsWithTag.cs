using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FindObjectsWithTag : ScriptableWizard {

    public string searchTag = "Your tag here";

    [MenuItem("My Tools/Select All Of Tag...")]

    static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard("Select All Of Tag...", typeof(FindObjectsWithTag));
    }

    void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
        Selection.objects = gameObjects;
    }
}
