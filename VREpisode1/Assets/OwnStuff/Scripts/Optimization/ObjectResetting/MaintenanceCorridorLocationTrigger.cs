using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceCorridorLocationTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            ResetOutOfFacilityObjectLocation.playerLocation = ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.MaintenanceCorridor;
        }
    }
}
