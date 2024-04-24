using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 90f;

    [SerializeField] Text countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        Score scoreScript = FindObjectOfType<Score>();
        if (scoreScript == null)
        {
            Debug.LogWarning("Score script not found in the scene.");
        }
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0f)
        {
            currentTime = startingTime;

            Score scoreScript = FindObjectOfType<Score>();
            if (scoreScript != null)
            {
                scoreScript.currentScore = 0;
                scoreScript.UpdateScoreText();
            }
            else
            {
                Debug.LogWarning("Score script not found in the scene.");
            }
        }
    }
}
