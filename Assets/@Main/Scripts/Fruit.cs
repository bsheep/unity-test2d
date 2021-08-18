using UnityEngine;
// フ ル ー ツ を 制 御 す る ス ク リ プ ト
public class Fruit : MonoBehaviour
{
    // 他 の オ ブ ジ ェ ク ト と 当 た っ た 時 に 呼 び 出 さ れ る 関 数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 名 前 に 「P l a y e r」 が 含 ま れ る オ ブ ジ ェ ク ト と 当 た っ た ら
        if (other.name.Contains(" Player "))
        {
            // 自 分 自 身 を 削 除 す る
            Destroy(gameObject);
        }
    }
}
