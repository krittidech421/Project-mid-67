using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // สร้าง Instance เพื่อให้เรียกใช้จากสคริปต์อื่นได้ง่าย (เช่น LevelManager.instance.FinishLevel())
    public static LevelManager instance;

    [Header("คะแนนและเวลา")]
    public float maxScore = 5000f;
    public float timePenalty = 10f;

    [Header("อ้างอิง UI")]
    public GameObject winPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timeUsedText;

    [Header("การเปลี่ยนด่าน")]
    public string nextLevelName;

    private bool isFinished = false;
    private float startTime;

    void Awake()
    {
        // ตั้งค่า Singleton
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isFinished = false;
        startTime = Time.time;

        if (winPanel != null) winPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ส่วนที่มักจะมีปัญหา: สคริปต์นี้ต้องวางไว้ที่วัตถุ "เส้นชัย" ที่มี Collider เท่านั้น
    void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบ Tag และเช็คว่ายังไม่จบด่าน
        if (other.CompareTag("Player") && !isFinished)
        {
            Debug.Log("รถเหยียบเส้นชัยแล้ว!"); // เช็คใน Console ว่าข้อความนี้ขึ้นไหม
            FinishLevel();
        }
    }

    public void FinishLevel()
    {
        if (isFinished) return; // กันการทำงานซ้ำ

        isFinished = true;
        float timeTaken = Time.time - startTime;

        // คำนวณคะแนน (ไม่ให้ต่ำกว่า 0)
        int finalScore = Mathf.Max(0, Mathf.RoundToInt(maxScore - (timeTaken * timePenalty)));

        // แสดงผล UI
        if (winPanel != null) winPanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Score: " + finalScore.ToString("N0");

        if (timeUsedText != null)
        {
            int minutes = (int)timeTaken / 60;
            int seconds = (int)timeTaken % 60;
            timeUsedText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }

        // หยุดเกม
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ฟังก์ชันสำหรับปุ่มกด (UI Buttons)
    public void NextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextLevelName);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}