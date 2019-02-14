using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
    }

    public void ChangeText(string newText)
    {
        myText.text = newText;
    }
}
