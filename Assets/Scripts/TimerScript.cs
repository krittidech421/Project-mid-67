using UnityEngine;
using TMPro; // สำคัญมาก: ต้องใช้ตัวนี้เพื่อคุม TextMeshPro

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ลากตัวหนังสือมาใส่ตรงนี้
    private float startTime;

    void Start()
    {
        // เริ่มนับเวลาจาก 0
        startTime = 0;
    }

    void Update()
    {
        // เพิ่มเวลาตามเวลาจริงที่ผ่านไปในแต่ละเฟรม
        startTime += Time.deltaTime;

        // คำนวณ นาที และ วินาที
        int minutes = Mathf.FloorToInt(startTime / 60);
        int seconds = Mathf.FloorToInt(startTime % 60);

        // แสดงผลในรูปแบบ 00:00
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
