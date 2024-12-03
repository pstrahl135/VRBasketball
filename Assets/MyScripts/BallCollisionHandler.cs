using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI leftDigitText;  
    public TextMeshProUGUI rightDigitText; 
    private int score = 0;

    private void Start()
    {

        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Target")) 
        {
            IncreaseScore(); 
        }
    }

  
    private void IncreaseScore()
    {
        score++; 
        UpdateScoreText(); 
    }


    private void UpdateScoreText()
    {
        
        int leftDigit = score / 10;  
        int rightDigit = score % 10; 

        
        if (leftDigitText != null)
        {
            leftDigitText.text = leftDigit.ToString();
        }

        if (rightDigitText != null)
        {
            rightDigitText.text = rightDigit.ToString();
        }
    }
}