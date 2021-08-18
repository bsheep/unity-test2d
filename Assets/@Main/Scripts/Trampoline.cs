using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float m_jumpHeight = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Player"))
        {
            var motor = collision.GetComponent<PlatformerMotor2D>();
            motor.ForceJump(m_jumpHeight);

            var animator = GetComponent<Animator>();
            animator.Play("Jump");
        }
    }
}
