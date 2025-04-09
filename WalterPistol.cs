using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalterPistol : MonoBehaviour
{
    public ScriptAnim _scriptAnim;


    [SerializeField] private float damage = 60f;          // Урон за выстрел
    [SerializeField] private float rayLength = 100f;         // Дальность стрельбы
    [SerializeField] private float fireRate = 3f;        // Скорострельность
    // private float impactForce = 30f;     // Отдача при попадании



    [SerializeField] private GameObject hitEffect;

    [SerializeField] private AudioClip shootSound;        // Звук выстрела

    private float nextTimeToFire = 0f;
    [SerializeField]  private AudioSource audioSource;


    [SerializeField] private Camera cam;

    [SerializeField] private string targetTag = "Enemy";


    
    void Start()
    {
        
    }



    void Update()
    {


        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            _scriptAnim.AnimFire();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shootSound);



        if (cam == null) cam = Camera.main;

        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        bool isHit = Physics.Raycast(ray, out RaycastHit hit, rayLength);

        if (isHit && hit.collider.CompareTag(targetTag))
        {
            Debug.Log("Найден объект с тегом '" + targetTag + "': " + hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point, Color.green, 100f); // Зелёный луч

            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

            }
        }
        else
        {
            Debug.Log("Объект с тегом '" + targetTag + "' не найден!");
            Debug.DrawLine(ray.origin, isHit ? hit.point : ray.origin + ray.direction * rayLength,Color.red,100f); // Красный луч
        }


        GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 1f);
    }
}
