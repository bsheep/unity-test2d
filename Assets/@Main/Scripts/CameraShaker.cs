using System.Collections;
using UnityEngine;
// カ メ ラ を 揺 ら す ス ク リ プ ト
public class CameraShaker : MonoBehaviour
{
    // カ メ ラ を 揺 ら す 時 間 （ 秒 ）
    public float m_duration = 0.25f;
// カ メ ラ を 揺 ら す 強 さ
public float m_magnitude = 0.1f;
// カ メ ラ を 揺 ら す
public void Shake()
    {
        StartCoroutine(DoShake());
    }
    // カ メ ラ を 揺 ら す 処 理 を コ ル ー チ ン で 実 装 す る 関 数
    private IEnumerator DoShake()
    {
        // カ メ ラ の 位 置 を 記 憶 し て お く
        var pos = transform.localPosition;
        // カ メ ラ を 揺 ら し 始 め て か ら の 経 過 時 間
        var elapsed = 0f;
        // ま だ カ メ ラ を 揺 ら す 時 間 内 の 場 合
        while (elapsed < m_duration)
        {
            // カ メ ラ を 揺 ら す た め に 位 置 を ラ ン ダ ム に 動 か す
            var x = pos.x + Random.Range(-1f, 1f) * m_magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * m_magnitude;
            transform.localPosition = new Vector3(x, y, pos.z);
            // カ メ ラ を 揺 ら し 始 め て か ら の 経 過 時 間 を 進 め る
            elapsed += Time.deltaTime;
            // こ の フ レ ー ム で の 処 理 を 一 旦 中 断 す る
            yield return null;
        }
        // カ メ ラ を 揺 ら し 終 わ っ た ら 初 期 位 置 に 戻 す
        transform.localPosition = pos;
    }
}
