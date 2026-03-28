using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float speed = 2f;      // ความเร็วในการยก
    public float distance = 3f;   // ระยะทางที่ยกขึ้นจากจุดเริ่ม
    private Vector3 startPos;

    void Start()
    {
        // จำตำแหน่งเริ่มต้นไว้
        startPos = transform.position;
    }

    void Update()
    {
        // ใช้ Mathf.PingPong เพื่อให้ค่าขยับไป-กลับระหว่าง 0 ถึง distance
        float newY = Mathf.PingPong(Time.time * speed, distance);

        // อัปเดตตำแหน่งเฉพาะแกน Y
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}