using UnityEngine;
using UnityEngine.SceneManagement; // ใช้สำหรับเปลี่ยนฉาก

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;

    // 1. เริ่มเกม
    public void PlayGame()
    {
        // โหลดฉากถัดไป (ต้องไปเพิ่ม Scene ใน Build Settings ก่อน)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // 2. เปิดหน้าตั้งค่า
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }

    // 3. ปิดหน้าตั้งค่ากลับไปหน้าหลัก
    public void CloseSettings()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }

    // 4. ออกจากเกม
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // แสดงใน Console ว่ากดออกแล้ว
        Application.Quit(); // ปิดโปรแกรม (เห็นผลเฉพาะตอน Build ออกไปแล้ว)
    }
}