using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public void Dead()
    {
        gameObject.SetActive(false);

        var cameraShake = FindObjectOfType<CameraShaker>();
        cameraShake.Shake();

        Invoke("OnRetry", 2);
    }

    void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
