using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // ค่าของเหรียญที่จะเพิ่มให้กับผู้เล่น
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player") // เช็คว่าเหรียญชนกับผู้เล่นหรือไม่
        {
            GameManager.instance.IncreaseScore(coinValue); // เรียกใช้ GameManager เพื่อเพิ่มคะแนน
            Destroy(gameObject); // ทำลายเหรียญหลังจากที่เก็บรวบรวมแล้ว
            Debug.Log("true");
        }
    }
}
