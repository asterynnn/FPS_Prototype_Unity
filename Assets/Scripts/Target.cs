using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Reference to the Score script
    Score scoreScript;

    void Start()
    {
        scoreScript = GameObject.FindObjectOfType<Score>();
    }

    public void Hit()
    {
        scoreScript.IncreaseScore();

        transform.position = TargetBounds.instance.GetRandomPosition();
    }
}