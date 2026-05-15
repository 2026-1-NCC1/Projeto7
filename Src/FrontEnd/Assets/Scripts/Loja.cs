using UnityEngine;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
    [Header("Ponto onde o player vai parar")]
    public Transform pontoDeInteracao;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        ClickToMove player = FindFirstObjectByType<ClickToMove>();

        if (player != null)
        {
            Interagir(player);
        }
    }
    public void Interagir(ClickToMove player)
    {
        player.IrParaLoja(this);
    }
    public void Abrir()
    {
        ShopManager.instance.AbrirLoja();
    }


}