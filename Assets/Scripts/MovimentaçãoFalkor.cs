using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MovimentacaoDragao : MonoBehaviour
{
    public float velocidade = 50f;
    public float sensibilidadeMouse = 2f;
    public float distanciaTrocaCena = 50f;

    public Image fade;

    public AudioSource musica;
    public float tempoFadeMusica = 3f;

    private bool trocandoCena = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (trocandoCena)
            return;

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;

        transform.Rotate(0f, -mouseX, 0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direcao = transform.forward * x - transform.right * -z;

        if (Input.GetKey(KeyCode.Space))
        {
            direcao += Vector3.up;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            direcao += Vector3.down;
        }

        Vector3 velocidadeFinal = direcao.normalized * velocidade;

        rb.linearVelocity = new Vector3(
            velocidadeFinal.x,
            velocidadeFinal.y,
            velocidadeFinal.z
        );

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaTrocaCena))
        {
            Debug.Log("Acertou: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "ParedeInvisivel")
            {
                trocandoCena = true;
                StartCoroutine(TrocarCenaComFade());
            }
        }
    }

    IEnumerator TrocarCenaComFade()
    {
        StartCoroutine(FadeTela());

        StartCoroutine(FadeMusica());

        yield return new WaitForSeconds(tempoFadeMusica);

        musica.Stop();

        SceneManager.LoadScene("Fase3");
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