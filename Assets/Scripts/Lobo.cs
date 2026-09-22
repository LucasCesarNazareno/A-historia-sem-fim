using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobo : MonoBehaviour
{
    public Animator animator;
    public Image fade;

    public void IniciarCutscene()
    {
        animator.enabled = true;
        animator.Play("LoboAtaque");

        StartCoroutine(TrocarCena());
    }

    IEnumerator TrocarCena()
    {
        yield return new WaitForSeconds(0.1f);

        Color cor = fade.color;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime * 10f;
            fade.color = cor;
            yield return null;
        }

        SceneManager.LoadScene("Fase2");
    }
}