using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Referências da Interface")]
    public GameObject painelQuebrar;
    public Image imagemPedraGrande;
    public Slider barraVida;

    [Header("Stamina")]
    public PlayerStamina stamina;

    [Header("Dinheiro")]
    public int dinheiro = 0;
    public TextMeshProUGUI textoDinheiro;

    private ItemQuebravel itemAtual;
    private int vidaAtual;

    void Awake() => instance = this;

    void Start()
    {
        if (stamina == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
            {
                stamina = playerObj.GetComponent<PlayerStamina>();
            }
        }

        AtualizarUI();
    }

    public void AbrirPainelQuebrar(ItemQuebravel item)
    {
        itemAtual = item;
        vidaAtual = item.vidaMaxima;

        imagemPedraGrande.sprite = item.iconeGrande;

        barraVida.maxValue = item.vidaMaxima;
        barraVida.value = item.vidaMaxima;

        painelQuebrar.SetActive(true);
    }

    public void DarClique()
    {
        if (stamina == null)
        {
            Debug.LogWarning("PlayerStamina nao encontrado no UIManager.");
            return;
        }

        if (!stamina.TryUseStamina(1))
        {
            Debug.Log("Sem stamina para quebrar item.");
            return;
        }

        vidaAtual--;
        barraVida.value = vidaAtual;

        if (vidaAtual <= 0)
        {
            QuebrarItem();
        }
    }

    void QuebrarItem()
    {
        painelQuebrar.SetActive(false);

        if (itemAtual != null)
        {
            itemAtual.DropItem();
            Destroy(itemAtual.gameObject);
            itemAtual = null;
        }

        SpawnerManager spawner = FindFirstObjectByType<SpawnerManager>();

        if (spawner != null)
        {
            spawner.GerarUmNovoItem();
        }
    }

    public void AdicionarDinheiro(int valor)
    {
        dinheiro += valor;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textoDinheiro != null)
        {
            textoDinheiro.text = "$ " + dinheiro.ToString();
        }
    }
}
