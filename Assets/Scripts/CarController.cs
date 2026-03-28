using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("ตั้งค่ารถ")]
    public float motorForce = 1500f;    // แรงขับเคลื่อน
    public float breakForce = 3000f;    // แรงเบรก
    public float maxSteerAngle = 30f;   // มุมเลี้ยวสูงสุด

    [Header("อ้างอิงวัตถุ (Wheel Colliders)")]
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    void FixedUpdate()
    {
        GetInput();      // 1. รับค่าจากคีย์บอร์ด
        HandleMotor();   // 2. สั่งให้ล้อหมุน (วิ่ง)
        HandleSteering(); // 3. สั่งให้ล้อเลี้ยว
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        // ส่งแรงไปที่ล้อคู่หน้า (ขับเคลื่อนล้อหน้า)
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;

        // ระบบเบรก
        float currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking(currentbreakForce);
    }

    private void ApplyBreaking(float force)
    {
        frontLeftWheel.brakeTorque = force;
        frontRightWheel.brakeTorque = force;
        rearLeftWheel.brakeTorque = force;
        rearRightWheel.brakeTorque = force;
    }

    private void HandleSteering()
    {
        // เลี้ยวล้อคู่หน้า
        float currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle = currentSteerAngle;
    }
}