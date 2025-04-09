using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimping : MonoBehaviour
{
    [HideInInspector] public bool isClimbing = false; // ����, ������������, �� �������� �� �����
    [HideInInspector] public Ladder currentLadder; // ������� ��������, � ������� ��������������� �����

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>(); // ������������, ��� �������� ��������� � �������� �������
    }

    private void Update()
    {
        if (isClimbing && currentLadder != null)
        {
            HandleClimbing(); // ���������� ��������/������� �� ��������
        }
    }

    private void HandleClimbing()
    {
        float vertical = Input.GetAxis("Vertical");

        if (isClimbing && currentLadder != null)
        {
            rb.useGravity = false; // ��������� ����������, ����� ����� �� �����
            rb.velocity = new Vector3(0, vertical * currentLadder.climbSpeed, 0); // ������� ������ ����� ��� ���� �� ��������

            // ��������� �������� �����������, �� ������������� ������������ ��������
            if (vertical > 0 && !IsWithinLadderBounds())
            {
                rb.velocity = Vector3.zero; // ������������� ������, ���� �� ������� �� ������� �������� �����
            }
        }
        else
        {
            rb.useGravity = true; // �������� ����������, ����� ����� �� �� ��������
        }

        // ����� � �������� ��� ������� �������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopClimbing();
        }
    }

    private bool IsWithinLadderBounds()
    {
        // ���������, ��������� �� ����� � �������� ������ ��������
        if (currentLadder == null) return false;

        Collider ladderCollider = currentLadder.GetComponent<Collider>();
        float playerYPosition = transform.position.y;

        return playerYPosition >= ladderCollider.bounds.min.y && playerYPosition <= ladderCollider.bounds.max.y;
    }

    public void StartClimbing(Ladder ladder)
    {
        isClimbing = true;
        currentLadder = ladder;
        rb.velocity = Vector3.zero; // ������������� ����� ���������� ��������

        // ����� ����� �������� �������� ������ �������
        if (animator != null)
        {
            animator.SetBool("isClimbing", true);
        }
    }

    public void StopClimbing()
    {
        isClimbing = false;
        currentLadder = null;
        rb.useGravity = true; // �������� ����������

        // ����� ����� �������� �������� ��������� �������
        if (animator != null)
        {
            animator.SetBool("isClimbing", false);
        }
    }

    // ��� �������������� � ��������� (���������� �� ��������)
    public void SetCurrentLadder(Ladder ladder)
    {
        currentLadder = ladder;
    }
}
