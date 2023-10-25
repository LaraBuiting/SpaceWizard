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

    private void OnTriggerEnter2D(Collider2D Item)
    {
        if (Item.tag == "Item")
        {
            ScoreNum++;
            Destroy(Item.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
    }
}