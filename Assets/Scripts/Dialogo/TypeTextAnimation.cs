using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypeTextAnimation : MonoBehaviour
{
    public Action TypeFinished;
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;

    public string fullText;

    public void StartTyping()
    {
        StopAllCoroutines();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;

        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        TypeFinished?.Invoke();
    }
}