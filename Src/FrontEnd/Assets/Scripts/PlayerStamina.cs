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

    [Header("Levels")]
    public int nivelMaxStamina = 1;
    public int nivelRegen = 1;

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

    public void AumentarMaxStamina(int valor)
    {
        nivelMaxStamina++;

        maxStamina += valor;
        currentStamina += valor;

        UpdateStaminaBar();

        Debug.Log("Max stamina aumentada! Nivel: " + nivelMaxStamina);
    }

    public void MelhorarRegen(float reducao)
    {
        nivelRegen++;

        regenInterval -= reducao;
        regenInterval = Mathf.Clamp(regenInterval, 0.1f, 10f);

        Debug.Log("Regen melhorada! Nivel: " + nivelRegen);
    }
}
