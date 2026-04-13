using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para trocar de cenas
using UnityEngine.UI;              // Essencial para manipular componentes de UI (Button)

public class MenuManager : MonoBehaviour
{
    [Header("Configurações de UI")]
    public Button startButton;
    public Button quitButton;

    [Header("Configurações da Cena")]
    public string gameSceneName = "sceneOne"; // Nome da cena que será carregada

    void Start()
    {
        // Configura os botões via código. 
        // Isso é útil porque evita que você esqueça de arrastar a função no Inspector.
        
        if (startButton != null)
        {
            // Adiciona um "ouvinte": quando clicar, executa o método StartGame
            startButton.onClick.AddListener(StartGame);
        }

        if (quitButton != null)
        {
            // Quando clicar, executa o método QuitGame
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    // Método para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena definida na variável gameSceneName
        // IMPORTANTE: A cena deve estar no 'Build Settings' para funcionar.
        SceneManager.LoadScene(gameSceneName);
    }

    // Método de exemplo para o menu de opções
    public void OpenOptions()
    {
        // Por enquanto, apenas exibe uma mensagem no console
        Debug.Log("Abrir menu de opções");
    }

    // Método para fechar o aplicativo
    public void QuitGame()
    {
        Debug.Log("O jogo está fechando...");
        
        // Fecha o jogo (Só funciona no jogo compilado/Build)
        Application.Quit();

        // Nota: No Editor da Unity, este comando é ignorado.
    }

    // Update não é necessário para menus simples, 
    // a menos que você tenha animações ou entradas de teclado.
    /* void Update()
    {
    }
    */
}
