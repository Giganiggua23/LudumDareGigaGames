using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelController : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform playerTarget; // ���� 
    public float attackRange = 20f; // ��������� �����

    [Header("Rotation Settings")]
    public Transform horizontalRotator; // ��������������� ��������
    public Transform verticalRotator;   // ������������� ��������
    public float rotationSpeed = 5f;    // �������� ��������

    [Header("Attack Settings")]
    public GameObject projectilePrefab; // ������ �������
    public Transform firePoint;         // ����� ��������
    public float fireRate = 1f;         // ���������������� (��������� � �������)
    private float nextFireTime = 0f;    // ����� ���������� ��������
    private float projectileSpeed = 50f; // �������� �������

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    [Header("Animation Settings")]
    public float idleVerticalAmplitude = 5f; // ��������� ������������� ������� � ������ ��������
    public float idleVerticalSpeed = 1f;     // �������� ������������� �������
    public float idleHorizontalAmplitude = 10f; // ��������� ��������������� �������
    public float idleHorizontalSpeed = 0.5f;    // �������� ��������������� �������

    private bool isPlayerInRange = false;

    void Update()
    {
        if (playerTarget == null) return;

        
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
        isPlayerInRange = distanceToPlayer <= attackRange;

        if (isPlayerInRange)
        {
            
            RotateTowardsTarget();

            
            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            
            IdleAnimation();
        }
    }

    void RotateTowardsTarget()
    {
        if (horizontalRotator != null)
        {
            
            Vector3 horizontalDirection = playerTarget.position - horizontalRotator.position;
            horizontalDirection.y = 0; 
            Quaternion horizontalRotation = Quaternion.LookRotation(horizontalDirection);
            horizontalRotator.rotation = Quaternion.Slerp(horizontalRotator.rotation, horizontalRotation, rotationSpeed * Time.deltaTime);
        }

        if (verticalRotator != null)
        {
            
            Vector3 verticalDirection = playerTarget.position - verticalRotator.position;
            Quaternion verticalRotation = Quaternion.LookRotation(verticalDirection);
            verticalRotator.rotation = Quaternion.Slerp(verticalRotator.rotation, verticalRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void IdleAnimation()
    {
        if (horizontalRotator != null)
        {
            
            float horizontalAngle = Mathf.Sin(Time.time * idleHorizontalSpeed) * idleHorizontalAmplitude;
            horizontalRotator.localRotation = Quaternion.Euler(0, horizontalAngle, 0);
        }

        if (verticalRotator != null)
        {
            
            float verticalAngle = Mathf.Sin(Time.time * idleVerticalSpeed) * idleVerticalAmplitude;
            verticalRotator.localRotation = Quaternion.Euler(verticalAngle, 0, 0);
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(shootSound);
        if (projectilePrefab == null || firePoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

         projectile.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeed;

        Destroy(projectile, 5f);
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
