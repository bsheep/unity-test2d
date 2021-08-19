using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioClip m_jumpClip;
    public AudioClip m_hitClip;

    public bool IsSkipJumpSE;

    private void Awake()
    {
        var motor = GetComponent<PlatformerMotor2D>();
        motor.onJump += OnJump;
    }

    void OnJump()
    {
        if (IsSkipJumpSE)
        {
            IsSkipJumpSE = false;
        }
        else
        {
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_jumpClip);
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);

        var cameraShake = FindObjectOfType<CameraShaker>();
        cameraShake.Shake();

        Invoke("OnRetry", 2);

        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(m_hitClip);
    }

    void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
