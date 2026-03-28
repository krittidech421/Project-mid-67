using UnityEngine;

public class WindArea : MonoBehaviour
{
    [Header("ตั้งค่าลม")]
    public float windStrength = 50f; // ความแรงของลม (ยิ่งเยอะยิ่งต้านหนัก)

    // เลือกโหมดการทำงาน
    public bool isAlwaysOn = true;    // เปิดตลอดเวลา
    public bool isPulsing = false;   // ลมพัดเป็นจังหวะ (On/Off)
    public float pulseInterval = 2f; // ระยะเวลาเปิด/ปิด (วินาที)

    private float pulseTimer;
    private bool isCurrentlyBlowing;

    void Start()
    {
        isCurrentlyBlowing = isAlwaysOn;
        pulseTimer = pulseInterval;
    }

    void Update()
    {
        // จัดการระบบลมพัดเป็นจังหวะ (ถ้าเปิดใช้)
        if (isPulsing)
        {
            pulseTimer -= Time.deltaTime;
            if (pulseTimer <= 0f)
            {
                isCurrentlyBlowing = !isCurrentlyBlowing;
                pulseTimer = pulseInterval;
            }
        }
    }

    // ฟังก์ชันนี้จะทำงานตลอดเวลาที่มีวัตถุ (รถ) อยู่ใน Trigger ของลม
    void OnTriggerStay(Collider other)
    {
        if (!isCurrentlyBlowing) return;

        Rigidbody carRb = other.attachedRigidbody;

        if (carRb != null)
        {
            // ทิศทางลม (ถ้าอยากให้ถอยหลัง ลมต้องพัดสวนหน้ารถ)
            Vector3 windDirection = transform.forward;

            // ใช้ Acceleration จะช่วยให้รถค่อยๆ เร่งความเร็วถอยหลังได้ดีขึ้น
            carRb.AddForce(windDirection * windStrength, ForceMode.Acceleration);
        }
    }

    // (เลือกใส่) เพื่อให้เห็นทิศทางลมในหน้า Scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawFrustum(Vector3.zero, 60, transform.lossyScale.z, 0.1f, 1);
    }
}