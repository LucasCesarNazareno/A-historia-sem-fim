using UnityEngine;

public class Lobo : MonoBehaviour
{
    private bool jogadorPerto = false;
    private DialogueSystem dialogueSystem;

    private void Start()
    {
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }

    private void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            dialogueSystem.Next();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}