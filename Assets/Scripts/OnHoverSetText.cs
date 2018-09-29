using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class OnHoverSetText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public Text textArea;

    private string defaultText;

    void Start()
    {
        defaultText = textArea.text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textArea.text = text;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textArea.text = defaultText;
    }
}
