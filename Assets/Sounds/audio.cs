using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private TargetShooter targetShooter;

    void Start()
    {
        // Find the TargetShooter script attached to any GameObject in the scene
        targetShooter = FindObjectOfType<TargetShooter>();

        if (targetShooter == null)
        {
            Debug.LogError("TargetShooter script not found in the scene.");
        }
    }

    void Update()
    {
        if (targetShooter != null && !targetShooter.IsReloading() && Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(clip);
        }
    }
}
