using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class EquipmentPlacement : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject equipmentPrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedEquipment;

    private void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began) return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedEquipment == null)
            {
                spawnedEquipment = Instantiate(equipmentPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedEquipment.transform.position = hitPose.position;
            }
        }
    }

    public void ChangeEquipment(GameObject newEquipmentPrefab)
    {
        equipmentPrefab = newEquipmentPrefab;
        if (spawnedEquipment != null)
        {
            Destroy(spawnedEquipment);
            spawnedEquipment = null;
        }
    }
}