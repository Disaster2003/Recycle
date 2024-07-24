using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // クラスのインスタンス

    // Start is called before the first frame update
    void Start()
    {
        // インスタンスに何も代入されていない場合
        if (instance == null)
            // 自身を代入する
            instance = this;
        else
            // 自身を破棄する
            Destroy(gameObject);

        // オブジェクトのシーン移行による削除を防ぐ
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static GameManager GetInstance() { return instance; }
}
