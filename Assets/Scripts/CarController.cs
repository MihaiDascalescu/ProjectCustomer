﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
        private float horizontalInput;
        private float verticalInput;
        private float steeringAngle;

        public WheelCollider CFrontRight, CBackRight;
        public WheelCollider CFrontLeft, CBackLeft;

        public Transform TFrontRight, TFrontLeft;
        public Transform TBackRight, TBackLeft;
        
        

        public float maxSteerAngle = 30;
        public float motorForce = 50;
        private void GetInput()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

        }
        private void Steer()
        {
            steeringAngle = maxSteerAngle * horizontalInput;
            CFrontRight.steerAngle = steeringAngle;
            CFrontLeft.steerAngle = steeringAngle;
        }
        private void Accelerate()
        {
            CFrontLeft.motorTorque = verticalInput * motorForce;
            CFrontRight.motorTorque = verticalInput * motorForce;
        }
        private void UpdateWheelPoses()
        {
            UpdateWheelPose(CFrontRight, TFrontRight);
            UpdateWheelPose(CFrontLeft, TFrontLeft);
            UpdateWheelPose(CBackRight, TBackRight);
            UpdateWheelPose(CBackLeft, TBackLeft);
        }
        private void UpdateWheelPose(WheelCollider collider, Transform transform)
        {
            Vector3 _pos = transform.position;
            Quaternion _quat = transform.rotation;
            
            collider.GetWorldPose(out _pos, out _quat);
           
            transform.position = _pos;
            transform.rotation = _quat;
           
    }
        private void FixedUpdate()
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
            //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection() * moveSpeed * Time.deltaTime);
    }
        /*public WheelCollider WheelFL;//the wheel colliders
        public WheelCollider WheelFR;
        public WheelCollider WheelBL;
        public WheelCollider WheelBR;

        public GameObject FL;//the wheel gameobjects
        public GameObject FR;
        public GameObject BL;
        public GameObject BR;

        public float topSpeed = 250f;//the top speed
        public float maxTorque = 200f;//the maximum torque to apply to wheels
        public float maxSteerAngle = 45f;
        public float currentSpeed;
        public float maxBrakeTorque = 2200;


        private float Forward;//forward axis
        private float Turn;//turn axis
        private float Brake;//brake axis

        private Rigidbody rb;//rigid body of car


        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate() //fixed update is more physics realistic
        {
            Forward = Input.GetAxis("Vertical");
            Turn = Input.GetAxis("Horizontal");
            Brake = Input.GetAxis("Jump");

            WheelFL.steerAngle = maxSteerAngle * Turn;
            WheelFR.steerAngle = maxSteerAngle * Turn;

            currentSpeed = 2 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; //formula for calculating speed in kmph

            if (currentSpeed < topSpeed)
            {
                WheelBL.motorTorque = maxTorque * Forward;//run the wheels on back left and back right
                WheelBR.motorTorque = maxTorque * Forward;
            }//the top speed will not be accurate but will try to slow the car before top speed

            WheelBL.brakeTorque = maxBrakeTorque * Brake;
            WheelBR.brakeTorque = maxBrakeTorque * Brake;
            WheelFL.brakeTorque = maxBrakeTorque * Brake;
            WheelFR.brakeTorque = maxBrakeTorque * Brake;

        }
        void Update()//update is called once per frame
        {
            Quaternion flq;//rotation of wheel collider
            Vector3 flv;//position of wheel collider
            WheelFL.GetWorldPose(out flv, out flq);//get wheel collider position and rotation
            FL.transform.position = flv;
            //FL.transform.rotation = flq; 

            Quaternion Blq;//rotation of wheel collider
            Vector3 Blv;//position of wheel collider
            WheelBL.GetWorldPose(out Blv, out Blq);//get wheel collider position and rotation
            BL.transform.position = Blv;
            //BL.transform.rotation = Blq; 

             Quaternion fRq;//rotation of wheel collider
            Vector3 fRv;//position of wheel collider
            WheelFR.GetWorldPose(out fRv, out fRq);//get wheel collider position and rotation
            FR.transform.position = fRv;
            //FR.transform.rotation = fRq;

            Quaternion BRq;//rotation of wheel collider
            Vector3 BRv;//position of wheel collider
            WheelBR.GetWorldPose(out BRv, out BRq);//get wheel collider position and rotation
            BR.transform.position = BRv;
            //BR.transform.rotation = BRq; 

        }*/
}