using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneToogle : MonoBehaviour
{
    [Tooltip("The UI Text element used to display plane detection messages.")]
    private ARPlaneManager planeManager;
    [SerializeField] TextMeshProUGUI m_TogglePlaneDetectionText;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        m_TogglePlaneDetectionText.text = "Disable";
    }
    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;

        string planeDetectionMessage = "";
        if (planeManager.enabled)
        {
            planeDetectionMessage = "Disable Plane Detection";
            SetAllPlanesActive(true);
        }
        else
        {
            planeDetectionMessage = "Enable Plane Detection";
            SetAllPlanesActive(false);
        }

        m_TogglePlaneDetectionText.text = planeDetectionMessage;
    }

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in planeManager.trackables)
            plane.gameObject.SetActive(value);
    }
}
