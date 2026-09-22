using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public float velocidade = 40f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.back * velocidade * Time.deltaTime);
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