using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemScore : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Gems : " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D gem)
    {
        if (gem.tag == "gem")
        {
            ScoreNum++;
            Destroy(gem.gameObject);
            MyscoreText.text = "Gems : " + ScoreNum;
        }
    }
}
