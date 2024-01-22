using PupilLabs;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGazeInteractorBridge : MonoBehaviour
{
    [SerializeField]
    private XRGazeInteractor target;
    [SerializeField]
    private Transform reference;

    public void OnGazeDataReady(GazeDataProvider gazeDataProvider)
    {
        if (reference == null)
        {
            reference = Camera.main.transform;
        }
        target.transform.position = reference.TransformPoint(gazeDataProvider.GazeRay.origin);
        target.transform.forward = reference.TransformDirection(gazeDataProvider.GazeRay.direction);
    }
}
