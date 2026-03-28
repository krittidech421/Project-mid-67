using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("ตั้งค่ารถ")]
    public float motorForce = 1500f;
    public float breakForce = 3000f;
    public float maxSteerAngle = 30f;

    [Header("ระบบกู้รถ (Flip/Reset)")]
    public KeyCode resetKey = KeyCode.R; // กด R เพื่อพลิกกลับ
    public float resetHeight = 2f;      // ระยะยกตัวขึ้นจากพื้นเล็กน้อยตอนรีเซ็ต

    [Header("อ้างอิงวัตถุ (Wheel Colliders)")]
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;
    private Rigidbody rb; // เก็บค่า Rigidbody ไว้จัดการเรื่องน้ำหนัก

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.9f, 0);
    }

    void Update() // เช็ค Input ปุ่ม Reset ใน Update จะแม่นยำกว่า FixedUpdate
    {
        if (Input.GetKeyDown(resetKey))
        {
            FlipCar();
        }
    }

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;

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
        float currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle = currentSteerAngle;
    }

    // ฟังก์ชันพลิกรถ
    private void FlipCar()
    {
        // 1. ทำให้รถตั้งตรง (Reset Rotation)
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // 2. ยกตัวรถขึ้นเล็กน้อยเพื่อไม่ให้ล้อจมดิน
        transform.position += Vector3.up * resetHeight;

        // 3. ล้างค่าแรงเฉื่อยเดิมทิ้ง (Velocity) เพื่อไม่ให้รถพุ่งต่อตอนพลิก
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}