using UnityEngine;
// フ ル ー ツ を 制 御 す る ス ク リ プ ト
public class Fruit : MonoBehaviour
{
    // 獲 得 演 出 の プ レ ハ ブ
    public GameObject m_collectedPrefab;
    // 他 の オ ブ ジ ェ ク ト と 当 た っ た 時 に 呼 び 出 さ れ る 関 数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 名 前 に 「P l a y e r」 が 含 ま れ る オ ブ ジ ェ ク ト と 当 た っ た ら
        if (other.name.Contains(" Player "))
        {
            // 獲 得 演 出 の オ ブ ジ ェ ク ト を 作 成 す る
            var collected = Instantiate
            (
                m_collectedPrefab,
                transform.position,
                Quaternion.identity
            );
            // 獲 得 演 出 の オ ブ ジ ェ ク ト か ら ア ニ メ ー タ ー の 情 報 を 取 得 す る
            var animator = collected.GetComponent<Animator>();
            // 現 在 再 生 中 の ア ニ メ ー シ ョ ン の 情 報 を 取 得 す る
            var info = animator.GetCurrentAnimatorStateInfo(0);
            // 現 在 再 生 中 の ア ニ メ ー シ ョ ン の 再 生 時 間 （ 秒 ） を 取 得 す る
            var time = info.length;
            // ア ニ メ ー シ ョ ン の 再 生 が 完 了 し た ら
            // 獲 得 演 出 を 削 除 す る よ う に 登 録 す る
            Destroy(collected, time);
            // 自 分 自 身 を 削 除 す る
            Destroy(gameObject);
        }
    }
}
