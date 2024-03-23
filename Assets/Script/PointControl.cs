using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointControl : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI ScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") 
        {
            score += 1;
            ScoreNumber.text = "" + score;
            Destroy(other.gameObject);
        }
        if (score >= 7)
        {
            SceneManager.LoadScene(4);
        }
    }
}
