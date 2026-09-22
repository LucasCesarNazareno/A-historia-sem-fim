using UnityEngine;

public class SpawnerMeteoros : MonoBehaviour
{
    public GameObject meteoroPrefab;
    public float tempoSpawn = 2f;

    void Start()
    {
        InvokeRepeating(
            nameof(CriarMeteoro),
            1f,
            tempoSpawn
        );
    }

    void CriarMeteoro()
    {
        Instantiate(
            meteoroPrefab,
            transform.position,
            transform.rotation
        );
    }
}