using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorController
{

    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator animator;

        private AnimationParameters currentState;

        private void Start()
        {
            currentState = AnimationParameters.Idle;
            animator = GetComponent<Animator>();
            if (animator == null)
                throw new NullReferenceException();
        }

        public void SwitchState(AnimationParameters parameter)
        {

            if (currentState == parameter)
                return;

            ResetTriggers();

            switch (parameter)
            {
                case AnimationParameters.Attack:
                    animator.SetTrigger("Attack");
                    break;

                case AnimationParameters.TakeDamage:
                    animator.SetTrigger("Hurt");
                    break;

                case AnimationParameters.StartBattle:
                    animator.SetTrigger("Start Battle");
                    break;

                case AnimationParameters.Dying:
                    animator.SetBool("Low Health", true);
                    break;

                case AnimationParameters.Idle:
                    animator.SetBool("Low Health", false);
                    break;

                case AnimationParameters.Dead:
                    animator.SetBool("Dead", true);
                    break;

                default:
                    throw new Exception();
            }

            currentState = parameter;

        }


        private void ResetTriggers()
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Hurt");
            animator.ResetTrigger("Start Battle");
        }



    }

}