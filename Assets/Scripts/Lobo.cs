using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobo : MonoBehaviour
{
    public Animator animator;
    public Image fade;

    public AudioSource musica;
    public float tempoFadeMusica = 3f;

    public void IniciarCutscene()
    {
        animator.enabled = true;
        animator.Play("LoboAtaque");

        StartCoroutine(TrocarCena());
    }

    IEnumerator TrocarCena()
    {
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(FadeTela());

        StartCoroutine(FadeMusica());

        yield return new WaitForSeconds(tempoFadeMusica);

        musica.Stop();

        SceneManager.LoadScene("Fase2");
    }

    IEnumerator FadeTela()
    {
        Color cor = fade.color;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime * 10f;
            fade.color = cor;

            yield return null;
        }
    }

    IEnumerator FadeMusica()
    {
        float volumeInicial = musica.volume;
        float tempo = 0f;

        while (tempo < tempoFadeMusica)
        {
            tempo += Time.deltaTime;

            musica.volume = Mathf.Lerp(
                volumeInicial,
                0f,
                tempo / tempoFadeMusica
            );

            yield return null;
        }

        musica.volume = 0f;
    }
}