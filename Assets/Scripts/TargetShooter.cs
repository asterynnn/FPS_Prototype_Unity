using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] int maxAmmo = 10;
    [SerializeField] float reloadTime = 2f;

    private int currentAmmo;
    private bool isReloading = false;

    public bool IsReloading()
    {
        return isReloading;
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            currentAmmo--;
            if (currentAmmo > 0)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Target target = hit.collider.gameObject.GetComponent<Target>();
                    if (target != null)
                    {
                        target.Hit();
                        
                    }
                }
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
