using UnityEngine;
using TMPro;

public class CountdownTrigger : MonoBehaviour
{
    public float countdownTime = 90f; // Total time in seconds (1:30 mins)
    private float remainingTime;

    public TMP_Text timerText; // Reference to the TextMeshPro component for displaying the timer

    private bool isCountdownActive = false;

    void Start()
    {
        remainingTime = countdownTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (isCountdownActive)
        {
            // Update the countdown timer
            remainingTime -= Time.deltaTime;

            // Check if the timer has run out
            if (remainingTime <= 0f)
            {
                EndCountdown();
            }

            UpdateTimerText();
        }

        // Check for "F" key press outside the trigger zone
        if (Input.GetKeyDown(KeyCode.C))
        {
            ActivateCountdown();
        }
    }

    void UpdateTimerText()
    {
        // Convert remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        // Update the TMP text
        if (timerText != null)
        {
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    void EndCountdown()
    {
        // Add logic for what should happen when the countdown ends
        Debug.Log("Countdown Ended!");
        // You can put additional logic here for post-countdown actions
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone");
        }
    }

    void ActivateCountdown()
    {
        // Start the countdown when activated
        isCountdownActive = true;
        Debug.Log("Countdown activated");
    }

    void OnDestroy()
    {
        // Clean up when the GameObject is destroyed (optional)
        // You might want to stop the countdown or handle other clean-up tasks
    }
}
