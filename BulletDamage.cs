using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damage = 10f; // ����, ��������� �����

    private void OnTriggerEnter(Collider other)
    {
        // ��������, ���� �� � ������� ��������� ��������
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject); // ���������� ���� ����� ���������
        }
    }
}
