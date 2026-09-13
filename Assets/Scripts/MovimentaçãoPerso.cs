using UnityEngine;

public class MovimentaçãoPerso : MonoBehaviour
{
    public float velocidade = 5f;
    public float forçaPulo = 5f;
    public float sensibilidadeMouse = 2f;
    public Transform cameraTransform;

    [Header("Interação")]
    public Transform lobo;
    public float distanciaInteracao = 3f;

    private Rigidbody rb;
    private float rotacaoX = 0f;

    DialogueSystem dialogueSystem;

    private void Awake()
    {
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        transform.Rotate(Vector3.up * mouseX);

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direcao = transform.right * x + transform.forward * z;
        Vector3 velocidadeFinal = direcao * velocidade;
        rb.linearVelocity = new Vector3(velocidadeFinal.x, rb.linearVelocity.y, velocidadeFinal.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forçaPulo, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            float distancia = Vector3.Distance(transform.position, lobo.position);

            if (distancia <= distanciaInteracao)
            {
                dialogueSystem.Next();
            }
        }
    }
}