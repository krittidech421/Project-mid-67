using UnityEngine;

public class PendulumTrap : MonoBehaviour
{
    [Header("การตั้งค่าลูกตุ้ม")]
    public float speed = 2f;       // ความเร็วในการแกว่ง
    public float maxAngle = 60f;   // องศาที่แกว่งไปซ้ายสุด-ขวาสุด (เช่น 60 องศา)

    private float startAngle;

    void Start()
    {
        // เก็บค่ามุมเริ่มต้นของแกนหมุน (ส่วนใหญ่เกม 2D จะหมุนรอบแกน Z)
        startAngle = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        // คำนวณมุมการแกว่งโดยใช้ Mathf.Sin 
        float currentAngle = maxAngle * Mathf.Sin(Time.time * speed);

        // อัปเดตการหมุน (ถ้าเป็นเกม 3D และต้องการให้หมุนแกนอื่น ให้เปลี่ยนตำแหน่งแกน Z เป็นแกน X หรือ Y แทน)
        transform.rotation = Quaternion.Euler(0f, 0f, startAngle + currentAngle);
    }
}
