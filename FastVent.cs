using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastVent : MonoBehaviour
{
    public ScriptAnim _scriptAnim;

    [Header("Настройки вентилятора")]
    [SerializeField] private float rotationSpeed = 10000f;
    [SerializeField] private GameObject Colision_;
    

    [Header("Настройки взаимодействия")]
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    private bool isRotating = true;
    private Inventory _Inv; 

    private void Start()
    {
        
        _Inv = FindObjectOfType<Inventory>();

        if (_Inv == null)
        {
            Debug.LogError("Не найден скрипт PlayerInventory на сцене!");
        }
    }

    private void Update()
    {
        
        if (isRotating)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }

        
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _Inv != null && _Inv.metal_stick && Input.GetKeyDown(interactionKey))
        {
            _scriptAnim.ArmtUse();
            ToggleFan();

        }
    }

    private void ToggleFan()
    {
        isRotating = !isRotating;

        
        if (Colision_ != null)
        {
            
            Colision_.SetActive(false);
        }
    }

}
