using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TrocarCena : MonoBehaviour
{
    public Image fade;

    public AudioSource musica;
    public float tempoFadeMusica = 3f;

    private bool trocandoCena = false;

    private void OnTriggerEnter(Collider other)
    {
        if (trocandoCena)
            return;

        if (other.CompareTag("Player"))
        {
            trocandoCena = true;
            StartCoroutine(TrocarCenaComFade());
        }
    }

    IEnumerator TrocarCenaComFade()
    {
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(FadeTela());

        StartCoroutine(FadeMusica());

        yield return new WaitForSeconds(tempoFadeMusica);

        musica.Stop();

        SceneManager.LoadScene("Creditos");
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