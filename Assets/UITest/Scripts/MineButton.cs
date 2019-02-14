using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MineButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    public Image image = null;
    public Text text = null;
    Color originalImageColor;
    Color originalTextColor;

    protected override void Start()
    {
        image = GetComponent<Image>();
        text =  GetComponentInChildren<Text>();

        originalImageColor = image.color;
        originalTextColor = text.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Do something!!!

        changeColor(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        changeColor(false);
    }
    private void changeColor(bool pushed)
    {
        image.color = pushed ? Color.gray : originalImageColor;
        text.color = pushed ? Color.white : originalTextColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entrando");
    }
}
