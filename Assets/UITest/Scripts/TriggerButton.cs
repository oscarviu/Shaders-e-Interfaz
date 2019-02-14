using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerButton : MonoBehaviour
{
    public Image image = null;
    public Text text = null;
    Color originalImageColor;
    Color originalTextColor;

    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();

        originalImageColor = image.color;
        originalTextColor = text.color;
    }

    private void changeColor(bool pushed)
    {
        image.color = pushed ? Color.gray : originalImageColor;
        text.color = pushed ? Color.white : originalTextColor;
    }
}
