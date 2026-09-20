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

    public bool podeMover = true;

    private Rigidbody rb;
    private Animator animator;
    private float rotacaoX = 0f;
    private bool estaNoChao = true;

    DialogueSystem dialogueSystem;

    private void Awake()
    {
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Permite apertar E mesmo com movimento bloqueado
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distancia = Vector3.Distance(transform.position, lobo.position);

            if (distancia <= distanciaInteracao)
            {
                dialogueSystem.Next();
            }
        }

        if (!podeMover)
        {
            animator.SetBool("Andando", false);
            return;
        }

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

        // Ativa a animação quando estiver andando
        bool andando = x != 0 || z != 0;
        animator.SetBool("Andando", andando);

        Vector3 direcao = transform.right * x + transform.forward * z;
        Vector3 velocidadeFinal = direcao * velocidade;

        rb.linearVelocity = new Vector3(
            velocidadeFinal.x,
            rb.linearVelocity.y,
            velocidadeFinal.z
        );

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(Vector3.up * forçaPulo, ForceMode.Impulse);
            estaNoChao = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }
}