using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public Text StatusText;

    // Start is called before the first frame update
    public void ShowScore(int score) {
        ScoreText.text = "Score : " + score.ToString();
    }

    public void ShowStatus(string status)
    {
        StatusText.text = status;
    }
}
