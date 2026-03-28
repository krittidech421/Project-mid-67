using UnityEngine;
using System.Collections; // จำเป็นต้องมีบรรทัดนี้เพื่อใช้งาน Coroutine

public class SpeedBoost : MonoBehaviour
{
    [Header("การตั้งค่า Speed Boost")]
    [Tooltip("แรงผลักที่จะเพิ่มให้กับรถอย่างต่อเนื่อง")]
    public float boostForce = 50f;

    [Tooltip("ระยะเวลาที่รถจะได้รับความเร็ว (วินาที)")]
    public float boostDuration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();

            if (carRigidbody != null)
            {
                // เรียกใช้ Coroutine เพื่อเริ่มผลักรถตามเวลาที่กำหนด
                StartCoroutine(BoostRoutine(carRigidbody, other.transform));
            }
        }
    }

    // ฟังก์ชัน Coroutine สำหรับจัดการเวลา
    private IEnumerator BoostRoutine(Rigidbody rb, Transform carTransform)
    {
        float timer = 0f;
        Debug.Log("เริ่มบูสต์ความเร็ว 1 วินาที!");

        // วนลูปทำงานจนกว่าเวลาจะครบกำหนด 1 วินาที (หรือค่าใน boostDuration)
        while (timer < boostDuration)
        {
            // ตรวจสอบเผื่อว่ารถถูกทำลายออกจากฉากไประหว่างนั้น
            if (rb == null) yield break;

            // เพิ่มแรงผลักไปข้างหน้าอย่างต่อเนื่อง
            // ใช้ ForceMode.Acceleration เพื่อให้การเร่งความเร็วดูนุ่มนวลและต่อเนื่อง
            rb.AddForce(carTransform.forward * boostForce, ForceMode.Acceleration);

            // นับเวลาเพิ่มขึ้นตามจังหวะเวลาของระบบฟิสิกส์
            timer += Time.fixedDeltaTime;

            // รอให้ถึงรอบอัปเดตฟิสิกส์รอบถัดไป (เพื่อให้เกมไม่ค้างและแรงผลักคงที่)
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("หมดเวลาบูสต์ความเร็วแล้ว!");
    }
}
