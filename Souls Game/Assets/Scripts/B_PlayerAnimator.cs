using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_PlayerAnimator : MonoBehaviour
{

    public Animator b_animator;
    public bool pickedanimation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("PickAnimation", 2f);
        PickAnimation();
        Invoke("GoToIdleInBattle", 2f);
        Invoke("EndOfBattle", 2f);
    }

    void PickAnimation()
    {
        if (PlayerStats.IsAttacker)
        {
            switch (BattleSystem.letter1)
            {
                case 'w':
                    b_animator.SetBool("MagAttk", true);
                    pickedanimation = true;
                    break;
                case 's':
                    b_animator.SetBool("RandomBuff", true);
                    pickedanimation = true;
                    break;
                case 'd':
                    b_animator.SetBool("ComboAttk", true);
                    pickedanimation = true;
                    break;
               case 'x':

                   break;
            }
        }
        else
        {
            switch (BattleSystem.letter1)
            {
                case 'w':
                    b_animator.SetBool("MagDef", true);
                    pickedanimation = true;
                    break;
                case 's':
                    b_animator.SetBool("RandomBuff", true);
                    pickedanimation = true;
                    break;
                case 'd':
                    if (BattleSystem.letter2 == 'l')
                    {
                        b_animator.SetBool("CounterS", true);
                        pickedanimation = true;
                    }
                    else
                    {
                        b_animator.SetBool("CounterF", true);
                        pickedanimation = true;
                    }
                    break;
                case 'x':
                   
                   break;
            }
        }

    }
    void GoToIdleInBattle()
    {
        if(pickedanimation)
        {
            b_animator.SetBool("MagAttk", false);
            b_animator.SetBool("RandomBuff", false);
            b_animator.SetBool("ComboAttk", false);
            b_animator.SetBool("MagDef", false);
            b_animator.SetBool("CounterS", false);
            b_animator.SetBool("CounterF", false);
            pickedanimation = false;
        }

    }

    void EndOfBattle()
    {
        if (!PlayerStats.InBattle)
        {
            b_animator.SetBool("MagAttk", false);
            b_animator.SetBool("RandomBuff", false);
            b_animator.SetBool("ComboAttk", false);
            b_animator.SetBool("MagDef", false);
            b_animator.SetBool("CounterS", false);
            b_animator.SetBool("CounterF", false);
        }
    }
}
/*
 * switch(BattleSystem.letter1)
        {
            case 'w':
                b_animator.SetBool("")
        }
 */
