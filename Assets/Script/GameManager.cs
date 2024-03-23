using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // สร้างตัวแปร static เพื่อให้สามารถเข้าถึงจากทุกที่ได้
    public Text scoreText; // ตัวแปรสำหรับแสดงคะแนน

    private int score = 0; // คะแนนปัจจุบัน

    private void Awake()
    {
        if (instance == null)
            instance = this; // กำหนดตัวแปร instance เป็นตัวเองหากไม่มี instance อื่นในที่นี้
        else
            Destroy(gameObject); // ทำลาย GameObject อื่นที่ไม่ใช่ตัวเอง
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // เพิ่มคะแนนตามจำนวนที่ระบุ
        UpdateScoreUI(); // อัปเดต UI ของคะแนน
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // แสดงคะแนนบน UI
    }
}
