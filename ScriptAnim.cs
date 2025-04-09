using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnim : MonoBehaviour
{
    public Animator animator;
    public Animator ClimAnim;
    public Animator EndSceneAnim;

    public GameObject ArmsClim;

    public int states = 0;


  

    public Ladder ladder;

    void Start()
    {

    }

    void Update()
    {
        RopeUse();
    }
    public void TakeIt()
    {
        animator.SetTrigger("IsTake");
    }
    public void AnimWalk()
    {
        //int states 0 - noting , 1 - crossbar , 2 - pistol , 3 - metal stick

        
        switch (states)
        {
            case 0:
                animator.SetBool("WalkCrowbar", false);
                animator.SetBool("WalkPistol", false);
                animator.SetBool("WalkArmature", false);
             break;
            case 1:
                animator.SetBool("WalkCrowbar", true);
                animator.SetBool("WalkPistol", false);
                animator.SetBool("WalkArmature", false);

             break;
            case 2:
                animator.SetBool("WalkCrowbar", false);
                animator.SetBool("WalkPistol", true);
                animator.SetBool("WalkArmature", false);
             break;
            case 3:
                animator.SetBool("WalkCrowbar", false);
                animator.SetBool("WalkPistol", false);
                animator.SetBool("WalkArmature", true);
             break;
        }

        
    }

    public void LiftFall()
    {
        animator.SetTrigger("LiftFall");
    }
    public void ArmtUse()
    {
        animator.SetTrigger("ArmtUse");
    }


    public void AnimFire()
    {
        animator.SetTrigger("Shoot");
    }



    public void RopeUse()
    {
        if (ladder.isanimclimp == true)
        {
            ArmsClim.SetActive(true);
            ClimAnim.SetBool("Rope", true);
            
        }
        else
        {
            ClimAnim.SetBool("Rope", false);
            ArmsClim.SetActive(false);
        }
    }


    public void EndScene()
    {
        EndSceneAnim.SetBool("EndingSceneAnim", true);
    }

}
