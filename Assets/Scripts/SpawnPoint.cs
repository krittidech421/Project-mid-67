using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;  // ตัว Player
    public Transform spawnPoint;     // จุดเกิด

    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}