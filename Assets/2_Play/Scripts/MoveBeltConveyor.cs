using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBeltConveyor : MonoBehaviour
{
    private Vector3 positionInitialize = new Vector3(0, -6, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = positionInitialize;
    }

    // Update is called once per frame
    void Update()
    {
        // 初期位置に戻す
        if (transform.position.x <= -21)
        {
            transform.position = positionInitialize;
        }

        // 左へ移動
        transform.position += new Vector3(-Time.deltaTime * 5, 0, 0);
    }
}
