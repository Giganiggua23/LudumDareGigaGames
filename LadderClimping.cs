using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimping : MonoBehaviour
{
    [HideInInspector] public bool isClimbing = false; // Флаг, определяющий, на лестнице ли игрок
    [HideInInspector] public Ladder currentLadder; // Текущая лестница, с которой взаимодействует игрок

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>(); // Предполагаем, что аниматор находится в дочернем объекте
    }

    private void Update()
    {
        if (isClimbing && currentLadder != null)
        {
            HandleClimbing(); // Управление подъемом/спуском по лестнице
        }
    }

    private void HandleClimbing()
    {
        float vertical = Input.GetAxis("Vertical");

        if (isClimbing && currentLadder != null)
        {
            rb.useGravity = false; // Отключаем гравитацию, чтобы игрок не падал
            rb.velocity = new Vector3(0, vertical * currentLadder.climbSpeed, 0); // Двигаем игрока вверх или вниз по лестнице

            // Оставляем коллизии включенными, но предотвращаем некорректное движение
            if (vertical > 0 && !IsWithinLadderBounds())
            {
                rb.velocity = Vector3.zero; // Останавливаем игрока, если он выходит за пределы лестницы вверх
            }
        }
        else
        {
            rb.useGravity = true; // Включаем гравитацию, когда игрок не на лестнице
        }

        // Выход с лестницы при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopClimbing();
        }
    }

    private bool IsWithinLadderBounds()
    {
        // Проверяем, находится ли игрок в пределах высоты лестницы
        if (currentLadder == null) return false;

        Collider ladderCollider = currentLadder.GetComponent<Collider>();
        float playerYPosition = transform.position.y;

        return playerYPosition >= ladderCollider.bounds.min.y && playerYPosition <= ladderCollider.bounds.max.y;
    }

    public void StartClimbing(Ladder ladder)
    {
        isClimbing = true;
        currentLadder = ladder;
        rb.velocity = Vector3.zero; // Останавливаем любое предыдущее движение

        // Здесь можно добавить анимацию начала лазания
        if (animator != null)
        {
            animator.SetBool("isClimbing", true);
        }
    }

    public void StopClimbing()
    {
        isClimbing = false;
        currentLadder = null;
        rb.useGravity = true; // Включаем гравитацию

        // Здесь можно добавить анимацию окончания лазания
        if (animator != null)
        {
            animator.SetBool("isClimbing", false);
        }
    }

    // Для взаимодействия с лестницей (вызывается из триггера)
    public void SetCurrentLadder(Ladder ladder)
    {
        currentLadder = ladder;
    }
}
