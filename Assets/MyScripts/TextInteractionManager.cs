using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TextInteractionManager : MonoBehaviour
{
    public TextMeshPro firstLevel;
    public TextMeshPro textRules1;
    public TextMeshPro textTimer;
    public TextMeshPro secondLevel;
    public TextMeshPro thirdLevel;
    public GameObject[] punktObjects; 
    public GameObject ringBoard;
    public Transform pointA;
    public Transform pointB;
    public float speed = 0.3f;

    private bool isXPressed = false;
    private bool isTimerRunning = false;
    private bool isMoving = false;
    private float currentTime = 100f;
    private Transform targetPoint;

    void Start()
    {
        
        if (punktObjects != null)
        {
            foreach (GameObject punkt in punktObjects)
            {
                if (punkt != null)
                {
                    punkt.SetActive(false);
                }
            }
        }

        
        if (ringBoard != null && pointA != null)
        {
            targetPoint = pointA;
        }

       
        if (secondLevel != null)
        {
            secondLevel.gameObject.SetActive(true);
        }
    }

    void Update()
    {
     
        InputDevice controller = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (controller.TryGetFeatureValue(CommonUsages.primaryButton, out bool xValue))
        {
            isXPressed = xValue;
        }

  
        if (isXPressed && firstLevel != null && firstLevel.gameObject.activeSelf)
        {
            HideTextAndShowRules();
        }

 
        if (isXPressed && textRules1 != null && textRules1.gameObject.activeSelf && !isTimerRunning)
        {
            StartTimer();
        }

 
        if (isXPressed && secondLevel != null && secondLevel.gameObject.activeSelf)
        {
            HideSecondLevelAndStartMoving();
        }

    
        if (isXPressed && thirdLevel != null && thirdLevel.gameObject.activeSelf)
        {
            OnThirdLevelInteraction();
        }

      
        if (isMoving && ringBoard != null && targetPoint != null)
        {
            MoveObject();
        }
    }

    private void HideTextAndShowRules()
    {
        firstLevel.gameObject.SetActive(false);
        if (textRules1 != null)
        {
            textRules1.gameObject.SetActive(true);
        }
    }

    private void StartTimer()
    {
        isTimerRunning = true;
        StartCoroutine(CountdownCoroutine());
    }

    private System.Collections.IEnumerator CountdownCoroutine()
    {
        while (currentTime > 0)
        {
            currentTime -= 1f;
            UpdateTimerText();
            yield return new WaitForSeconds(1f);
        }

        TimerComplete();
    }

    private void UpdateTimerText()
    {
        if (textTimer != null)
        {
            textTimer.text = Mathf.Ceil(currentTime).ToString();
        }
    }

    private void TimerComplete()
    {
        isTimerRunning = false;
        Debug.Log("Таймер завершен!");
    }

    private void HideSecondLevelAndStartMoving()
    {
        secondLevel.gameObject.SetActive(false);
        isMoving = true; 
    }

    private void MoveObject()
    {
        ringBoard.transform.position = Vector3.MoveTowards(
            ringBoard.transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(ringBoard.transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    private void OnThirdLevelInteraction()
    {
        if (thirdLevel != null && thirdLevel.gameObject.activeSelf)
        {
            
            isMoving = false;

          
            if (firstLevel != null) firstLevel.gameObject.SetActive(false);
            if (secondLevel != null) secondLevel.gameObject.SetActive(false);
            thirdLevel.gameObject.SetActive(false);

           
            if (punktObjects != null)
            {
                foreach (GameObject punkt in punktObjects)
                {
                    if (punkt != null)
                    {
                        punkt.SetActive(true);
                    }
                }
            }
        }
    }
}

