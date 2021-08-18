using UnityEngine;
// 背 景 を 制 御 す る ス ク リ プ ト
public class Background : MonoBehaviour
{
    // 背 景 が ス ク ロ ー ル す る 速 さ
    public Vector2 m_speed;
    // 毎 フ レ ー ム 呼 び 出 さ れ る 関 数
    private void Update()
    {
        // 背 景 の ス プ ラ イ ト を 表 示 す る 機 能 を 取 得 す る
        var spriteRenderer = GetComponent<SpriteRenderer>();
        // 背 景 の テ ク ス チ ャ を 表 示 す る マ テ リ ア ル を 取 得 す る
        var material = spriteRenderer.material;
        // 背 景 の テ ク ス チ ャ を ス ク ロ ー ル す る
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}
