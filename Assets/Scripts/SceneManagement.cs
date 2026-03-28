using UnityEngine;
using UnityEngine.SceneManagement; // ใช้สำหรับการเปลี่ยน Scene

public class CreditScroll : MonoBehaviour
{
    public float speed = 50f; // ความเร็วในการเลื่อน ปรับเพิ่มลดได้
    public string mainMenuSceneName = "MainMenu"; // ชื่อ Scene เมนูหลักของคุณ

    void Update()
    {
        // สั่งให้ Object เลื่อนขึ้นไปด้านบน (แกน Y) ตามความเร็วที่ตั้งไว้
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // หากผู้เล่นต้องการข้าม Credit ให้กด Spacebar หรือคลิกเมาส์ซ้าย
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}