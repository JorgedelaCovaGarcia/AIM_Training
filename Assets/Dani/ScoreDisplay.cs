using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateScore();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Puntuaci�n: " + gameManager.score;
    }
}