using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 15f; // Скорость подъема/спуска по лестнице

    public bool isanimclimp;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LadderClimping player = other.GetComponent<LadderClimping>();
            if (player != null)
            {
                player.isClimbing = true; // Включаем режим подъема
                player.currentLadder = this; // Устанавливаем текущую лестницу

                isanimclimp = true; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LadderClimping player = other.GetComponent<LadderClimping>();
            if (player != null)
            {
                player.isClimbing = false;
                player.currentLadder = null;
                player.GetComponent<Rigidbody>().useGravity = true; // Включаем гравитацию

                isanimclimp = false;
            }
        }
    }
}
