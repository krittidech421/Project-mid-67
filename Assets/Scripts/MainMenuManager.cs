using UnityEngine;
using UnityEngine.SceneManagement; // จำเป็นต้องใช้เพื่อสลับ Scene

public class MainMenuManager : MonoBehaviour
{
    // ฟังก์ชันสำหรับเริ่มเกม
    public void PlayGame()
    {
        // โหลด Scene ถัดไปใน Build Settings (ปกติคือหน้าเล่นเกม)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // ฟังก์ชันสำหรับออกจากเกม
    public void QuitGame()
    {
        // คำสั่งปิดโปรแกรม (ใช้ได้เมื่อ Build เป็นไฟล์ .exe หรือแอปแล้ว)
        Application.Quit();

        // ใส่ไว้เพื่อให้เห็นใน Console ว่าปุ่มทำงานขณะทดสอบใน Editor
        Debug.Log("Game is exiting...");
    }
}