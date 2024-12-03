using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(LineRenderer))]
public class BallController : MonoBehaviour
{
    public Transform handTransform; 
    public float attractionSpeed = 5f; 
    public float launchForce = 10f; 
    public int arcResolution = 20;
    public float arcHeight = 1.5f; 

    private Rigidbody ballRigidbody; 
    private LineRenderer lineRenderer; 
    private bool isGripPressed = false; 
    private bool isTriggerPressed = false; 

    void Start()
{
    ballRigidbody = GetComponent<Rigidbody>();
    lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.positionCount = arcResolution; 
    lineRenderer.enabled = false; 

    lineRenderer.startWidth = 0.1f; 
    lineRenderer.endWidth = 0.1f; 
    lineRenderer.startColor = Color.white; 
    lineRenderer.endColor = Color.white; 
    

    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
}

    void Update()
    {
        InputDevice controller = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

   
        if (controller.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue))
        {
            isGripPressed = gripValue;
        }

        if (isGripPressed)
        {
            AttractToHand();
        }

    
        if (controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue))
        {
            if (triggerValue && !isTriggerPressed)
            {
                isTriggerPressed = true;
                lineRenderer.enabled = true;
            }
            else if (!triggerValue && isTriggerPressed)
            {
                isTriggerPressed = false;
                lineRenderer.enabled = false; 
                LaunchBall(); 
            }
        }


        if (isTriggerPressed)
        {
            UpdateArc();
        }
    }

    private void AttractToHand()
    {
        Vector3 direction = (handTransform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, handTransform.position);

        if (distance > 0.1f) 
        {
            ballRigidbody.MovePosition(transform.position + direction * attractionSpeed * Time.deltaTime);
        }
        else
        {

            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
            ballRigidbody.isKinematic = true;
            transform.position = handTransform.position;
        }
    }

    private void UpdateArc()
    {
        Vector3 startPosition = transform.position;
        Vector3 launchDirection = handTransform.forward; 
        Vector3 initialVelocity = launchDirection * launchForce;


        for (int i = 0; i < arcResolution; i++)
        {
            float t = i / (float)(arcResolution - 1); 
            float time = t * 2f * Mathf.Sqrt(2f * arcHeight / Mathf.Abs(Physics.gravity.y)); 
            Vector3 point = startPosition + initialVelocity * time + 0.5f * Physics.gravity * time * time; 
            lineRenderer.SetPosition(i, point);
        }
    }

    private void LaunchBall()
    {

        ballRigidbody.isKinematic = false;
        ballRigidbody.velocity = handTransform.forward * launchForce;
    }
}