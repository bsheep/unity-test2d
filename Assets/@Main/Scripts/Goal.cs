using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool m_isGoal;

    public AudioClip m_goalClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!m_isGoal)
        {
            if (other.name.Contains("Player"))
            {
                var cameraShake = FindObjectOfType<CameraShaker>();
                cameraShake.Shake();

                m_isGoal = true;

                var animator = GetComponent<Animator>();
                animator.Play("Pressed");

                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.PlayOneShot(m_goalClip);
            }
        }
    }
}
