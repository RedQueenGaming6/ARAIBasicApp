using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NewInputSystem : MonoBehaviour
{
    ARRaycastManager m_ARRaycastManager;
    List<ARRaycastHit> raycast_hit = new List<ARRaycastHit>();

    public GameObject placePrefab;
    private GameObject spawnPrefab;

    bool isPressed;
    TouchControls controls;
    bool isObjectSpawned = false; // Flag to check if the object is already spawned

    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
        controls = new TouchControls();
        controls.control.touch.performed += _ => isPressed = true;
        controls.control.touch.canceled += _ => isPressed = false;
    }

    private void Update()
    {
        if (Pointer.current == null || isPressed == false)
        {
            return;
        }

        var touchposition = Pointer.current.position.ReadValue();

        if (m_ARRaycastManager.Raycast(touchposition, raycast_hit, TrackableType.PlaneWithinPolygon))
        {
            var pose = raycast_hit[0].pose;

            if (spawnPrefab == null)
            {
                spawnPrefab = Instantiate(placePrefab, pose.position, pose.rotation);
                isObjectSpawned = true; // Set the flag to true once the object is spawned
            }
            else if (!isObjectSpawned) // Only update position and rotation if the object is not already spawned
            {
                spawnPrefab.transform.position = pose.position;
                spawnPrefab.transform.rotation = pose.rotation;

                // makes it face the camera/person
                Vector3 lookpos = Camera.main.transform.position - spawnPrefab.transform.position;
                lookpos.y = 0;
                spawnPrefab.transform.rotation = Quaternion.LookRotation(lookpos);
            }
        }
    }

    void OnEnable()
    {
        controls.control.Enable();
    }

    void OnDisable()
    {
        controls.control.Disable();
    }
}
