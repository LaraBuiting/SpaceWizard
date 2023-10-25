using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score : " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D star)
    {
        if (star.tag == "Item")
        {
            ScoreNum++;
            Destroy(star.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
    }
}