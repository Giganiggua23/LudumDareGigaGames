using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damage = 10f; // Урон, наносимый пулей

    private void OnTriggerEnter(Collider other)
    {
        // Проверка, есть ли у объекта компонент здоровья
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject); // Уничтожить пулю после попадания
        }
    }
}
