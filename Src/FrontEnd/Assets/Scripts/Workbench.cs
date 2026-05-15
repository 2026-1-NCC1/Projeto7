using UnityEngine;
using UnityEngine.EventSystems;

public class Workbench : MonoBehaviour
{
    [Header("Ponto onde o player vai parar")]
    public Transform pontoDeInteracao;

    public void Interagir(ClickToMove player)
    {
        player.IrParaWorkbench(this);
    }

    public void Abrir()
    {
        WorkbenchManager.instance.AbrirWorkbench();
    }

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
}