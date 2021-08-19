using UnityEngine;
// フ ル ー ツ を 制 御 す る ス ク リ プ ト
public class Fruit : MonoBehaviour
{
    public GameObject m_collectedPrefab;

    public AudioClip m_collectedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            var collected = Instantiate
            (
                m_collectedPrefab,
                transform.position,
                Quaternion.identity
            );
            var animator = collected.GetComponent<Animator>();
            var info = animator.GetCurrentAnimatorStateInfo(0);
            var time = info.length;
            Destroy(collected, time);
            Destroy(gameObject);

            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_collectedClip);
        }
    }
}
