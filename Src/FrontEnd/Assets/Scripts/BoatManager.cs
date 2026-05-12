using UnityEngine;

public class BoatManager : MonoBehaviour
{
    public static BoatManager instance;

    [Header("Modelos")]
    public GameObject barcoQuebrado;
    public GameObject barcoPequeno;
    public GameObject barcoGrande;

    [Header("Progressao")]
    public int nivelBarco = 0;

    void Awake()
    {
        instance = this;
        AtualizarVisual();
    }

    public void MelhorarBarco()
    {
        nivelBarco++;
        AtualizarVisual();

        Debug.Log("Nivel barco: " + nivelBarco);

        if (nivelBarco >= 2)
        {
            Debug.Log("Tentando iniciar cutscene");

            CutsceneManager.instance.IniciarCutsceneFinal();
        }
    }

    void AtualizarVisual()
    {
        barcoQuebrado.SetActive(false);
        barcoPequeno.SetActive(false);
        barcoGrande.SetActive(false);

        switch (nivelBarco)
        {
            case 0:
                barcoQuebrado.SetActive(true);
                break;

            case 1:
                barcoPequeno.SetActive(true);
                break;

            default:
                barcoGrande.SetActive(true);
                break;
        }
    }
}