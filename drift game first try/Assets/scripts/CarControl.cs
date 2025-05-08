using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarControl : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct wheel
    { 
        public GameObject wheelModel;
        public WheelCollider wheelCollider; 
        public Axel axel;
    }

    public float maxAccelaration = 30.0f; 
    public float brakeAcceleration = 50.0f;

    public List<wheel> wheels;

    float moveInput;

    private Rigidbody carRb; 

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void GetInputs()
    {   
        moveInput = Input.GetAxis("Vertical");
    }

    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel . wheelCollider . motorTorque = moveInput*maxAccelaration*Time.deltaTime;
        }
    }
}
