using UnityEngine;

public class CarController : MonoBehaviour
{
    // for colliders
    [SerializeField] WheelCollider wheelFL, wheelFR, wheelRL, wheelRR;
    // for meshes
    [SerializeField] Transform wheelFLModel, wheelFRModel, wheelRLModel, wheelRRModel;

    [SerializeField] float motorTorque = 1500f, maxSteerAngle = 30f;

    void FixedUpdate()
    {
        // get axis
        float motor = Input.GetAxis("Vertical") * motorTorque;
        float steer = Input.GetAxis("Horizontal") * maxSteerAngle;

        wheelRL.motorTorque = motor;
        wheelRR.motorTorque = motor;

        wheelFL.steerAngle = steer;
        wheelFR.steerAngle = steer;

        // model rotations for visual
        UpdateWheelPose(wheelFL, wheelFLModel);
        UpdateWheelPose(wheelFR, wheelFRModel);
        UpdateWheelPose(wheelRL, wheelRLModel);
        UpdateWheelPose(wheelRR, wheelRRModel);
    }

    void UpdateWheelPose(WheelCollider collider, Transform model)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        model.position = pos;
        model.rotation = rot;
    }
}
