using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager instance;

    [Header("Fade")]
    public Image fadeImage;
    public float fadeSpeed = 6f; 

    [Header("Objetos")]
    public GameObject player;
    public GameObject interfaceUI;
    public Transform barco;

    [Header("Cameras")]
    public CinemachineCamera gameplayCamera;
    public CinemachineCamera cutsceneCamera;

    [Header("Movimento do barco")]
    public float velocidadeBarco = 3f;
    public float duracaoMovimento = 6f;
    public Vector3 direcao = new Vector3(1, 0, 0);

    private bool cutsceneAtiva = false;

    void Awake()
    {
        instance = this;
    }

    public void IniciarCutsceneFinal()
    {
        if (cutsceneAtiva) return;

        StartCoroutine(CutsceneFinal());
    }

    IEnumerator CutsceneFinal()
    {
        cutsceneAtiva = true;

        yield return StartCoroutine(Fade(0f, 1f, 1f));

        if (player != null)
            player.SetActive(false);

        if (interfaceUI != null)
            interfaceUI.SetActive(false);

        if (gameplayCamera != null)
            gameplayCamera.Priority = 1;

        if (cutsceneCamera != null)
            cutsceneCamera.Priority = 100;

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(Fade(1f, 0f, 1f));

        float timer = 0f;

        while (timer < duracaoMovimento)
        {
            if (barco != null)
                barco.position += direcao * velocidadeBarco * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Fim da cutscene");
    }

    IEnumerator Fade(float inicio, float fim, float duracao)
    {
        float tempo = 0f;
        Color cor = fadeImage.color;

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;

            cor.a = Mathf.Lerp(inicio, fim, tempo / duracao);
            fadeImage.color = cor;

            yield return null;
        }

        cor.a = fim;
        fadeImage.color = cor;
    }
}