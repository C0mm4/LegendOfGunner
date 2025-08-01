using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextOnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI targetText;
    public Color hoverColor = Color.cyan;
    private Color originalColor;

    void Start()
    {
        if (targetText == null)
            targetText = GetComponent<TextMeshProUGUI>();

        originalColor = targetText.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetText.color = originalColor;
    }
}