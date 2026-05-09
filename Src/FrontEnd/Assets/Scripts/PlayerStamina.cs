using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina")]
    [SerializeField] private int maxStamina = 100;
    [SerializeField] private int currentStamina = 100;

    [Header("Regeneracao")]
    [SerializeField] private float regenInterval = 0.5f;
    [SerializeField] private int regenAmount = 1;

    [Header("UI")]
    [SerializeField] private Slider staminaBar;

    private Coroutine regenCoroutine;

    public bool HasStamina => currentStamina > 0;

    private void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    public bool TryUseStamina(int amount)
    {
        if (currentStamina <= 0)
        {
            StartRegenIfNeeded();
            return false;
        }

        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        UpdateStaminaBar();

        StartRegenIfNeeded();

        return true;
    }

    private void StartRegenIfNeeded()
    {
        if (currentStamina < maxStamina && regenCoroutine == null)
        {
            regenCoroutine = StartCoroutine(RegenerateStamina());
        }
    }

    private IEnumerator RegenerateStamina()
    {
        while (currentStamina < maxStamina)
        {
            yield return new WaitForSeconds(regenInterval);

            currentStamina += regenAmount;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

            UpdateStaminaBar();
        }

        regenCoroutine = null;
    }

    private void UpdateStaminaBar()
    {
        if (staminaBar != null)
        {
            staminaBar.minValue = 0;
            staminaBar.maxValue = maxStamina;
            staminaBar.value = currentStamina;
        }
    }
}
