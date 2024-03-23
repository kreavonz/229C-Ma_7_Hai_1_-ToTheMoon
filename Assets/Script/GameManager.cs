using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ���ҧ����� static �����������ö��Ҷ֧�ҡ�ء�����
    public Text scoreText; // ���������Ѻ�ʴ���ṹ

    private int score = 0; // ��ṹ�Ѩ�غѹ

    private void Awake()
    {
        if (instance == null)
            instance = this; // ��˹������ instance �繵���ͧ�ҡ����� instance ���㹷����
        else
            Destroy(gameObject); // ����� GameObject ��蹷����������ͧ
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // ������ṹ����ӹǹ����к�
        UpdateScoreUI(); // �ѻവ UI �ͧ��ṹ
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // �ʴ���ṹ�� UI
    }
}
