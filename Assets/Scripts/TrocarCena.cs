using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TrocarCena : MonoBehaviour
{
    public Image fade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TrocarCenaComFade());
        }
    }

    IEnumerator TrocarCenaComFade()
    {
        yield return new WaitForSeconds(0.1f);

        Color cor = fade.color;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime * 4f;
            fade.color = cor;
            yield return null;
        }

        SceneManager.LoadScene("Creditos");
    }
}