using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI highScore;

    private int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        score = 0;
        currentScore.text = score.ToString();

        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    public void AddPoint()
    {
        score++;
        currentScore.text = score.ToString();
        RefreshHighScore();
    }

    void RefreshHighScore()
    {
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScore.text = score.ToString();
        }
    }
}