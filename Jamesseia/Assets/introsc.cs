using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introsc : MonoBehaviour
{
    public float speed = 1f; // Velocidade de movimento do texto
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move o texto para cima
        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        // Verifica se o texto saiu da tela, se sim, reinicia sua posição
        if (rectTransform.anchoredPosition.y > Screen.height)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -rectTransform.rect.height);
        }
    }
}
