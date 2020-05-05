using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownShop : MonoBehaviour, IPointerDownHandler {
    [SerializeField] private int IdButton;

    private PageShop pageShop;
    private void OnEnable() {
        pageShop = GameObject.FindGameObjectWithTag("Pags").transform.GetChild(1).GetComponent<PageShop>();
    }

    public virtual void OnPointerDown(PointerEventData eventData) {
        pageShop.BuyShopMaps(IdButton, gameObject);
    }
}
