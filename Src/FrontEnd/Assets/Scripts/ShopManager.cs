using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [Header("UI")]
    public GameObject painelLoja;

    public PlayerStamina playerStamina;

    [Header("Picareta Upgrade")]
    public Button botaoPicareta;
    public TextMeshProUGUI textoBotaoPicareta;

    private int custoPicareta = 10;
    private int nivelMaxPicareta = 5;

    [Header("Stamina Upgrade")]
    public Button botaoStamina;
    public TextMeshProUGUI textoBotaoStamina;

    private int custoStamina = 25;
    private int nivelMaxUpgradeStamina = 5;

    [Header("Regen Upgrade")]
    public Button botaoRegen;
    public TextMeshProUGUI textoBotaoRegen;

    private int custoRegen = 50;
    private int nivelMaxUpgradeRegen = 5;

    void Awake() => instance = this;

    public void AbrirLoja()
    {
        painelLoja.SetActive(true);
    }

    public void FecharLoja()
    {
        painelLoja.SetActive(false);
    }
    void Start()
    {
        AtualizarBotaoPicareta();
        AtualizarBotaoStamina();
        AtualizarBotaoRegen();
    }

    public void ComprarUpgrade1()
    {
        if (UIManager.instance.nivelPicareta >= nivelMaxPicareta)
        {
            textoBotaoPicareta.text = "MAX";
            botaoPicareta.interactable = false;
            return;
        }

        if (UIManager.instance.dinheiro >= custoPicareta)
        {
            UIManager.instance.AdicionarDinheiro(-custoPicareta);
            UIManager.instance.MelhorarPicareta();

            custoPicareta = Mathf.RoundToInt(custoPicareta * 1.5f);

            AtualizarBotaoPicareta();
        }
    }

    void AtualizarBotaoPicareta()
    {
        if (UIManager.instance.nivelPicareta >= nivelMaxPicareta)
        {
            textoBotaoPicareta.text = "Picareta MAX";
            botaoPicareta.interactable = false;
        }
        else
        {
            textoBotaoPicareta.text =
                "Picareta Lv." + UIManager.instance.nivelPicareta +
                "\n$" + custoPicareta;
        }
    }

    public void ComprarUpgrade2()
    {
        if (playerStamina.nivelMaxStamina >= nivelMaxUpgradeStamina)
        {
            textoBotaoStamina.text = "Stamina MAX";
            botaoStamina.interactable = false;
            return;
        }

        if (UIManager.instance.dinheiro >= custoStamina)
        {
            UIManager.instance.AdicionarDinheiro(-custoStamina);

            playerStamina.AumentarMaxStamina(20);

            custoStamina = Mathf.RoundToInt(custoStamina * 1.4f);

            AtualizarBotaoStamina();
        }
    }

    public void ComprarUpgrade3()
    {
        if (playerStamina.nivelRegen >= nivelMaxUpgradeRegen)
        {
            textoBotaoRegen.text = "Regen MAX";
            botaoRegen.interactable = false;
            return;
        }

        if (UIManager.instance.dinheiro >= custoRegen)
        {
            UIManager.instance.AdicionarDinheiro(-custoRegen);

            playerStamina.MelhorarRegen(0.05f);

            custoRegen = Mathf.RoundToInt(custoRegen * 1.5f);

            AtualizarBotaoRegen();
        }
    }

    void AtualizarBotaoStamina()
    {
        if (playerStamina.nivelMaxStamina >= nivelMaxUpgradeStamina)
        {
            textoBotaoStamina.text = "Stamina MAX";
            botaoStamina.interactable = false;
        }
        else
        {
            textoBotaoStamina.text =
                "Stamina Lv." + playerStamina.nivelMaxStamina +
                "\n$" + custoStamina;
        }
    }

    void AtualizarBotaoRegen()
    {
        if (playerStamina.nivelRegen >= nivelMaxUpgradeRegen)
        {
            textoBotaoRegen.text = "Regen MAX";
            botaoRegen.interactable = false;
        }
        else
        {
            textoBotaoRegen.text =
                "Regen Lv." + playerStamina.nivelRegen +
                "\n$" + custoRegen;
        }
    }
}