using UnityEngine;
using UnityEngine.UI; // Necessário para manipular Image e Slider
using TMPro;

public class UIManager : MonoBehaviour
{
    // Singleton: permite que qualquer outro script (como o ItemQuebravel) 
    // acesse o UIManager sem precisar de uma referência direta.
    public static UIManager instance;

    [Header("Referências da Interface")]
    public GameObject painelQuebrar;      // O painel que contém a UI de quebra
    public Image imagemPedraGrande;       // A imagem que muda conforme o item clicado
    public Slider barraVida;              // A barra visual de progresso/vida

    [Header("Dinheiro")]
    public int dinheiro = 0; // < dinheiro
    public TextMeshProUGUI textoDinheiro; // texto do dinheiro :D

    private ItemQuebravel itemAtual;      // Guarda a referência do item que estamos quebrando
    private int vidaAtual;                // Vida local para controle da UI

    // Executado antes do Start; ideal para configurar o Singleton
    void Awake() => instance = this;

    void Start()
    {
        AtualizarUI();
    }

    /// <summary>
    /// Configura e exibe o painel de quebra com os dados do item clicado.
    /// </summary>
    public void AbrirPainelQuebrar(ItemQuebravel item)
    {
        itemAtual = item;
        vidaAtual = item.vidaMaxima; 
    
        // Atualiza o visual da UI com as propriedades do objeto 3D
        imagemPedraGrande.sprite = item.iconeGrande;

        // Configura a barra de vida (Slider)
        barraVida.maxValue = item.vidaMaxima;
        barraVida.value = item.vidaMaxima;

        // Ativa o painel para o jogador começar a clicar
        painelQuebrar.SetActive(true);
    }

    /// <summary>
    /// Método chamado por um botão invisível ou pela própria imagem no clique.
    /// </summary>
    public void DarClique()
    {
        vidaAtual--;
        barraVida.value = vidaAtual;

        // Se a vida chegar a zero, o item é destruído
        if (vidaAtual <= 0)
        {
            QuebrarItem();
        }
    }

    /// <summary>
    /// Finaliza o processo de quebra e solicita um novo spawn.
    /// </summary>
    void QuebrarItem()
    {
        // Esconde a interface
        painelQuebrar.SetActive(false);

        // Destrói o objeto no mundo 3D
        if (itemAtual != null)
        {
            itemAtual.DropItem();
            Destroy(itemAtual.gameObject);
        }

        // Comunicação entre scripts: busca o Spawner e pede um novo item
        SpawnerManager spawner = FindFirstObjectByType<SpawnerManager>();
        if(spawner != null) 
        {
            spawner.GerarUmNovoItem();
        }
    }

    //função pra adicionar dinheiro
    public void AdicionarDinheiro(int valor)
    {
        dinheiro += valor;
        AtualizarUI();
    }
    //função que atualiza o ui pra mostrar o dinheiro
    void AtualizarUI()
    {
        if (textoDinheiro != null)
        {
            textoDinheiro.text = "$ " + dinheiro.ToString();
        }
    }

}
