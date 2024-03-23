using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // ��Ңͧ����­�����������Ѻ������
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player") // ���������­���Ѻ�������������
        {
            GameManager.instance.IncreaseScore(coinValue); // ���¡�� GameManager ����������ṹ
            Destroy(gameObject); // ���������­��ѧ�ҡ������Ǻ�������
            Debug.Log("true");
        }
    }
}
