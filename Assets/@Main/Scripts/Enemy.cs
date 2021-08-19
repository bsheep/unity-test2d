using PC2D;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlatformerMotor2D m_motor;
    SpriteRenderer m_renderer;
    BoxCollider2D m_collider;

    public GameObject m_hitPrefab;

    private void Awake()
    {
        m_motor = GetComponent<PlatformerMotor2D>();
        m_motor.normalizedXMovement = -1;
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.flipX = false;
        m_collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // 現 在 の 進 行 方 向 を 取 得 す る
        var dir = 0 < m_motor.normalizedXMovement
            ? Vector3.right
            : Vector3.left;
        // 進 行 方 向 に タ イ ル マ ッ プ が 存 在 す る か ど う か を 確 認 す る
        var offset = m_collider.size.y * 0.5f;
        var hit = Physics2D.Raycast
        (
            transform.position - new Vector3(0, offset, 0),
            dir,
            m_collider.size.x * 0.55f,
            Globals.ENV_MASK
        );
        // 進 行 方 向 に タ イ ル マ ッ プ が 存 在 す る 場 合
        if (hit.collider != null)
        {
            // 移 動 方 向 を 反 転 さ せ る
            m_motor.normalizedXMovement = -m_motor.normalizedXMovement;
            // 画 像 の 向 き を 反 転 さ せ る
            m_renderer.flipX = !m_renderer.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            var motor = other.GetComponent<PlatformerMotor2D>();

            if (motor.IsFalling())
            {
                Destroy(gameObject);
                motor.ForceJump();
                
                var cameraShake = FindObjectOfType<CameraShaker>();
                cameraShake.Shake();

                Instantiate(m_hitPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                var player = other.GetComponent<Player>();
                player.Dead();
            }
        }
    }
}
