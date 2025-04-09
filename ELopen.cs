using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELopen : MonoBehaviour
{
    [SerializeField] private Inventory _Inv;

    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _Inv.Hook == true && Input.GetKeyDown(KeyCode.E))
        {
            animator1.SetTrigger("OpenDoor");
            animator2.SetTrigger("OpenDoor");
        }
    }

    
    void Close()
    {
        animator1.SetTrigger("CloseDoor");
        animator2.SetTrigger("CloseDoor");
    }
}
