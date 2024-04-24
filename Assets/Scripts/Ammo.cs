using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int ammo = 10;
    public int currentAmmo = 0;

    [SerializeField] Text ammoText;

    void Start()
    {
        currentAmmo = ammo;
        UpdateAmmoText(); 
    }

    void UpdateAmmoText()
    {
        ammoText.text = currentAmmo.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 1)
            {
                currentAmmo--;
                UpdateAmmoText(); 
            }
            else
            {
                StartCoroutine(ReloadAmmo());
            }
        }
    }

    System.Collections.IEnumerator ReloadAmmo()
    {
        ammoText.text = "Reloadin"; 

        yield return new WaitForSeconds(2f); 

        currentAmmo = ammo; 
        UpdateAmmoText();
    }
}
