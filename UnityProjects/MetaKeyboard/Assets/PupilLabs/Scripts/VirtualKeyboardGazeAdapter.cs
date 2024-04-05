using PupilLabs;
using UnityEngine;

public class VirtualKeyboardGazeAdapter : MonoBehaviour
{
    [SerializeField]
    private OVRVirtualKeyboard virtualKeyboard;
    [SerializeField]
    private Transform reference;
    [SerializeField]
    private OVRHand hand;
    [SerializeField]
    private Transform inputTransform;

    private Vector3 localGazeOrigin = Vector3.zero;
    private Vector3 localGazeDirection = Vector3.forward;

    public void OnGazeDataReady(GazeDataProvider gazeDataProvider)
    {
        localGazeOrigin = gazeDataProvider.GazeRay.origin;
        localGazeDirection = gazeDataProvider.GazeRay.direction;
    }

    protected virtual void Update()
    {
        if (reference == null)
        {
            reference = Camera.main.transform;
        }

        if (inputTransform == null)
        {
            inputTransform = transform;
        }

        var worldOrigin = reference.TransformPoint(localGazeOrigin);
        var worldDirection = reference.TransformDirection(localGazeDirection);
        inputTransform.position = worldOrigin;
        inputTransform.forward = worldDirection;

        virtualKeyboard.SendVirtualKeyboardRayInput(inputTransform, OVRVirtualKeyboard.InputSource.HandRight, hand.GetFingerIsPinching(OVRHand.HandFinger.Index));
    }
}
