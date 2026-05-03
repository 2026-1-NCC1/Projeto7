using UnityEngine;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        ShopManager.instance.AbrirLoja();
    }
}