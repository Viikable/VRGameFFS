using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR 

public class OptimizeOrganizer : ScriptableWizard {

    public string searchScript= "Your tag here";

    [MenuItem("My Tools/Select all of not script...")]

    static void SelectAllOfNotScriptWizard()
    {
        ScriptableWizard.DisplayWizard("Select All Of Not Script...", typeof(OptimizeOrganizer));
    }

    void OnWizardCreate()
    {      
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        GameObject[] correctGameObjects = null;
        int i = 0;
        foreach (GameObject gameobject in gameObjects)
        {
            if (!gameobject.GetComponent(typeof (MelterObject)))
            {
                correctGameObjects[i] = gameobject; 
                i++;
            }
        }
        Selection.objects = correctGameObjects;
    }
}
#endif