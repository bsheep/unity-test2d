using UnityEngine;
// 針 を 制 御 す る ス ク リ プ ト
public class Spike : MonoBehaviour
{
    // 他 の オ ブ ジ ェ ク ト と 当 た っ た 時 に 呼 び 出 さ れ る 関 数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 名 前 に 「P l a y e r」 が 含 ま れ る オ ブ ジ ェ ク ト と 当 た っ た ら
        if (other.name.Contains(" Player "))
        {
            // プ レ イ ヤ ー の オ ブ ジ ェ ク ト を 削 除 す る
            Destroy(other.gameObject);

            // -- ★ こ こ か ら 追 加 -- //
            // シ ー ン に 存 在 す る CameraShaker ス ク リ プ ト を 検 索 す る
            var cameraShaker = FindObjectOfType<CameraShaker>();
            // CameraShaker を 使 用 し て カ メ ラ を 揺 ら す
            cameraShaker.Shake();
            // -- ★ こ こ ま で 追 加 -- //
        }
    }
}
