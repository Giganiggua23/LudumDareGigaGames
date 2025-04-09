using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerSmoothly : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private string playerTag = "Player"; 

    private Transform playerTransform;

    void Start()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the correct tag.");
        }
    }

    void Update()
    {
        if (playerTransform == null)
            return;

        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0; 

       
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
