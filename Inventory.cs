using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Inventory : MonoBehaviour
{
    public ScriptAnim _scriptAnim;


    // Use items
    public bool Hook;
    [SerializeField] private bool pistol_Walther_P38;
    public bool metal_stick;

    [SerializeField] private GameObject _hands;


    [SerializeField] private GameObject _Hook;
    [SerializeField] private GameObject _pistol_Walter_P38;
    [SerializeField] private GameObject _metal_stick;

    [SerializeField] private GameObject _Hook_Item;
    [SerializeField] private GameObject _pistol_Walter_P38_Item;
    [SerializeField] private GameObject _metal_stick_Item;


    [SerializeField] private GameObject flashligth;

    [SerializeField] private VideoPlayer videoPlayer1;
    [SerializeField] private VideoPlayer videoPlayer2;
    [SerializeField] private GameObject Tut2;
    [SerializeField] private GameObject Tut3;
    [SerializeField] private GameObject Tut4;
    private int tutint= 0;


    void Inv()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _hands.SetActive(false);
            _Hook.SetActive(false);
            _pistol_Walter_P38.SetActive(false);
            _metal_stick.SetActive(false);
            _scriptAnim.states = 0;
            Tut4.SetActive(false);

        }


        if (Input.GetKeyDown(KeyCode.Alpha1) && Hook == true)
        {
            _hands.SetActive(true);
            _Hook.SetActive(true);
            _pistol_Walter_P38.SetActive(false);
            _metal_stick.SetActive(false);
            _scriptAnim.states = 1;
            _scriptAnim.TakeIt();
            Tut4.SetActive(false);

        }

        //###########################################

        if (Input.GetKeyDown(KeyCode.Alpha2) && pistol_Walther_P38 == true )
        {
            _hands.SetActive(true);
            _Hook.SetActive(false);
            _pistol_Walter_P38.SetActive(true);
            _metal_stick.SetActive(false);
            _scriptAnim.states = 2;
            _scriptAnim.TakeIt();
            Tut4.SetActive(true);
        }

        //###########################################

        if (Input.GetKeyDown(KeyCode.Alpha3) && metal_stick == true)
        {
            _hands.SetActive(true);
            _Hook.SetActive(false);
            _pistol_Walter_P38.SetActive(false);
            _metal_stick.SetActive(true);
            _scriptAnim.states = 3;
            _scriptAnim.TakeIt();
            Tut4.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            flashligth.SetActive(!flashligth.activeSelf);
        }
    }


    void Start()
    {
        _hands.SetActive(false);
        _Hook.SetActive(false);
        _Hook_Item.SetActive(true);
        _pistol_Walter_P38.SetActive(false);
        _pistol_Walter_P38_Item.SetActive(true);
        _metal_stick.SetActive(false);
        _metal_stick_Item.SetActive(true);
    }

    
    void Update()
    {
        Inv();
        if (Input.GetKeyDown(KeyCode.E) && tutint == 2)
        {

            Tut2.SetActive(false);
            Tut3.SetActive(false);
            tutint++;
        }

        if (Input.GetKeyDown(KeyCode.E) && tutint == 1)
        {
            videoPlayer2.Play();
            Tut3.SetActive(true);
            tutint++;

        }

        if (Input.GetKeyDown(KeyCode.E) && tutint == 0)
        {
            videoPlayer1.Play();
            
            tutint++;

        }
        
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hook") && Input.GetKey(KeyCode.E))
        {
            Hook = true;
            _Hook_Item.SetActive(false);
            // _Hook.SetActive(true);
        }
        if (other.CompareTag("pistol_Walther_P38") && Input.GetKey(KeyCode.E))
        {
            pistol_Walther_P38 = true;
            _pistol_Walter_P38_Item.SetActive(false);
            // _pistol_Walter_P38.SetActive(true);
        }
        if (other.CompareTag("metal_stick") && Input.GetKey(KeyCode.E))
        {
            metal_stick = true;
            _metal_stick_Item.SetActive(false);
            // _metal_stick.SetActive(true);
        }
    }

    
    

}
