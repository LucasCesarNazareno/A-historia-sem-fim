using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJogador : MonoBehaviour
{
    public int vidas = 3;

    public Image coracao1;
    public Image coracao2;
    public Image coracao3;

    public void PerderVida()
    {
        vidas--;

        if (vidas <= 2)
            coracao3.enabled = false;

        if (vidas <= 1)
            coracao2.enabled = false;

        if (vidas <= 0)
        {
            coracao1.enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}