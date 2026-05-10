using UnityEngine;
using UnityEngine.EventSystems;

public class Workbench : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        WorkbenchManager.instance.AbrirWorkbench();
    }
}