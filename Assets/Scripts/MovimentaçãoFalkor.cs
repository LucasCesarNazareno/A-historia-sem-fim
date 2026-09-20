using UnityEngine;

public class MovimentacaoDragao : MonoBehaviour
{
    public float velocidade = 5f;
    public float sensibilidadeMouse = 2f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
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

        transform.position += direcao.normalized * velocidade * Time.deltaTime;
    }
}