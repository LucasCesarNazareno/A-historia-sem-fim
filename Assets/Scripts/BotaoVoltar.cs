using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    [SerializeField] private GameObject painelGameOver;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase2");
    }
}