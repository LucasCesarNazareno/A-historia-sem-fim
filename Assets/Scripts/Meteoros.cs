using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public float velocidade = 40f;
    public float oscilacao = 15f;
    public float frequencia = 3f;

    private float offset;

    void Start()
    {
        Destroy(gameObject, 10f);

        offset = Random.Range(0f, 100f);
    }

    void Update()
    {
        transform.Translate(Vector3.back * velocidade * Time.deltaTime);

        float movimentoX =
            Mathf.Sin(Time.time * frequencia + offset) *
            oscilacao *
            Time.deltaTime;

        float movimentoY =
            Mathf.Sin(Time.time * frequencia + offset) *
            oscilacao *
            Time.deltaTime;

        transform.Translate(
            new Vector3(movimentoX, movimentoY, 0f)
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        VidaJogador vida = other.GetComponent<VidaJogador>();

        if (vida != null)
        {
            vida.PerderVida();
            Destroy(gameObject);
        }
    }
}