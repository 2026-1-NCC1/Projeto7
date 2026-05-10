using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkbenchManager : MonoBehaviour
{
    public static WorkbenchManager instance;

    [Header("UI")]
    public GameObject painelWorkbench;

    [Header("Upgrade Barco")]
    public Button botaoUpgradeBarco;
    public TextMeshProUGUI textoBotao;

    private int custoBarco = 250;
    private int nivelMaxBarco = 2;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AtualizarBotao();
    }

    public void AbrirWorkbench()
    {
        painelWorkbench.SetActive(true);
    }

    public void FecharWorkbench()
    {
        painelWorkbench.SetActive(false);
    }

    public void ComprarUpgradeBarco()
    {
        if (BoatManager.instance.nivelBarco >= nivelMaxBarco)
        {
            textoBotao.text = "Barco MAX";
            botaoUpgradeBarco.interactable = false;
            return;
        }

        if (UIManager.instance.dinheiro >= custoBarco)
        {
            UIManager.instance.AdicionarDinheiro(-custoBarco);

            BoatManager.instance.MelhorarBarco();

            custoBarco = Mathf.RoundToInt(custoBarco * 2f);

            AtualizarBotao();
        }
    }

    void AtualizarBotao()
    {
        if (BoatManager.instance.nivelBarco >= nivelMaxBarco)
        {
            textoBotao.text = "Barco MAX";
            botaoUpgradeBarco.interactable = false;
        }
        else
        {
            textoBotao.text =
                "Barco Lv." + BoatManager.instance.nivelBarco +
                "\n$" + custoBarco;
        }
    }
}