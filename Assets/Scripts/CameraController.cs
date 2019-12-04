using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float yaw;
    float pitch;
    public float sensitivity = 10f;
    public Transform target;
    public float distanceFromTarget = 2f;
    public Vector2 pitchMinMax = new Vector2 (-35, 30);

    public float rotSmoothTime = .12f;
    Vector3 rotSmoothVelo;
    Vector3 currentRot;

    private void LateUpdate() {
        yaw += Input.GetAxis ("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRot = Vector3.SmoothDamp(currentRot, new Vector3 (pitch, yaw), ref rotSmoothVelo, rotSmoothTime);
        transform.eulerAngles = currentRot;

        transform.position = target.position - transform.forward * distanceFromTarget;

    }
}
