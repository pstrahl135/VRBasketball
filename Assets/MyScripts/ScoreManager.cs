using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText; 
    private int score = 0; 

    
    public void IncreaseScore()
    {
        score++; 
        UpdateScoreText(); 
    }

    
    private void UpdateScoreText()
    {
        scoreText.text = "Счет: " + score; 
    }
}
