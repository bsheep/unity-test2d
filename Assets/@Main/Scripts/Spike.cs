using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    // 他 の オ ブ ジ ェ ク ト と 当 た っ た 時 に 呼 び 出 さ れ る 関 数
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            var player = other.GetComponent<Player>();
            player.Dead();
        }
    }
}
