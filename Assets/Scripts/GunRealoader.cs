using System.Collections;
using UnityEngine;
using TMPro;

public class GunReloader : MonoBehaviour
{
    public int maxAmmo = 10;
    public float reloadTime = 2f;

    private int currentAmmo;
    private bool isReloading = false;

    public TMP_Text ammoText; // UI Text for displaying ammo count
    public TMP_Text reloadText; // UI Text for displaying reload status

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        // Check for the "R" key press to manually reload
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    public bool TryShoot()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            currentAmmo--;
            UpdateAmmoText();
            return true;
        }

        if (currentAmmo <= 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }

        return false;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadText.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoText();

        reloadText.gameObject.SetActive(false);
        isReloading = false;
    }

    void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
        }
    }
}
