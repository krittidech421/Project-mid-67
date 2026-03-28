using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndCredit : MonoBehaviour
{
    public void LoadEndCredit()
    {
        SceneManager.LoadScene("End Credit"); // 👈 ชื่อตรงกับใน Build Profiles
    }
}