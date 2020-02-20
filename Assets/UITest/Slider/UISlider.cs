using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
public class UISlider : Selectable
{
    public float value = 0;     // DELETE
   
    

    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [SerializeField]
    RectTransform selector = null;
    [SerializeField]
    RectTransform bar = null;

    bool pushActive = false;

    float leftCoord, rightCoord = 0;

    #region DELEGATE
    public delegate void voidDelegate(float value); // Between 0 - 1
    private voidDelegate _voidFunc = null;

    public void setSliderFunction(voidDelegate voidFunc)
    {
        this._voidFunc = voidFunc;
    }
    #endregion

    protected override void Start()
    {
        // Get boundaries
        leftCoord = bar.position.x - bar.rect.width * transform.root.localScale.x / 2;
        rightCoord = bar.position.x + bar.rect.width * transform.root.localScale.x / 2;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        pushActive = true;
        StartCoroutine(whileClick());
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        pushActive = false;
    }
    // Value [0, 1]
    float currentValueFromPosition()
    {
        return selector.localPosition.x / bar.rect.width + 0.5f;
    }

    public void moveSelectorFromValue(float value)
    {
        if (value > 1) value = 1;
        else if (value < 0) value = 0;
        selector.localPosition = new Vector3((value - 0.5f) * bar.rect.width, selector.localPosition.y);
    }

    IEnumerator whileClick()
    {
        while (pushActive)
        {
            if (Input.mousePosition.x > rightCoord)
                selector.position = new Vector3(rightCoord, selector.position.y);
            else if(Input.mousePosition.x <leftCoord)
                selector.position = new Vector3(leftCoord, selector.position.y);
            else
            selector.position =  new Vector3(Input.mousePosition.x, selector.position.y);

            if (_voidFunc != null)
                _voidFunc(currentValueFromPosition());
            value = currentValueFromPosition();         // DELETE
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}
