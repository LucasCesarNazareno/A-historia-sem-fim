using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManeger : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;

    public void Jogar()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Sair()
    { 
        Application.Quit();
    }

}
