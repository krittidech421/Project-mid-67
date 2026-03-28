using UnityEngine;

public class PistonObstacle : MonoBehaviour
{
    public enum MoveAxis { X, Y, Z } // เลือกแกนใน Inspector ได้เลย
    public MoveAxis targetAxis = MoveAxis.X;

    public float speed = 5f;      // ความเร็วในการพุ่ง
    public float distance = 3f;   // ระยะที่พุ่งออกมา
    public float waitTime = 1f;   // เวลาหยุดรอ (ถ้าต้องการให้หยุดพัก)

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ใช้ Mathf.PingPong เพื่อให้เคลื่อนที่ไป-กลับ
        float move = Mathf.PingPong(Time.time * speed, distance);

        Vector3 nextPos = startPos;

        // เลือกขยับเฉพาะแกนที่กำหนด
        switch (targetAxis)
        {
            case MoveAxis.X: nextPos.x += move; break;
            case MoveAxis.Y: nextPos.y += move; break;
            case MoveAxis.Z: nextPos.z += move; break;
        }

        transform.position = nextPos;
    }
}
