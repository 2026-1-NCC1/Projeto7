using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [Header("UI")]
    public GameObject painelLoja;

    void Awake() => instance = this;

    public void AbrirLoja()
    {
        painelLoja.SetActive(true);
    }

    public void FecharLoja()
    {
        painelLoja.SetActive(false);
    }

    public void ComprarUpgrade1(Button botao)
    {
        ComprarInterno(botao, 10);
    }

    public void ComprarUpgrade2(Button botao)
    {
        ComprarInterno(botao, 25);
    }

    public void ComprarUpgrade3(Button botao)
    {
        ComprarInterno(botao, 50);
    }

    void ComprarInterno(Button botao, int custo)
    {
        if (UIManager.instance.dinheiro >= custo)
        {
            UIManager.instance.AdicionarDinheiro(-custo);

            botao.interactable = false;

            TextMeshProUGUI texto = botao.GetComponentInChildren<TextMeshProUGUI>();
            if (texto != null)
            {
                texto.text = "Comprado";
            }
        }
    }
}