using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] trash;
    //private float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        // nullチェック
        if (trash == null)
        {
            Debug.Log("ゴミのオブジェクトが未設定です");
            return;
        }

        // 定期的(第三引数の値s)に関数を実行
        // 止める場合は、CancelInvoke()
        InvokeRepeating(nameof(SpawnTrash), 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //// ↓条件が付随するなら、このやり方
        //// スポーンさせる
        //if (timer <= 0)
        //{
        //    timer = 3;
        //    SpawnTrash();
        //}
        //// 時間計測
        //timer -= Time.deltaTime;
    }

    /// <summary>
    /// スポーン処理
    /// </summary>
    private void SpawnTrash()
    {
        // ゴミの生成
        Instantiate(trash[Random.Range(0, trash.Length)]);
    }
}
