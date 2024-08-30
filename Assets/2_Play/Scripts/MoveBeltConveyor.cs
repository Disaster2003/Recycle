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
        // èâä˙à íuÇ…ñﬂÇ∑
        if (transform.position.x <= -21)
            transform.position = positionInitialize;

        transform.position += new Vector3(-Time.deltaTime * 5, 0, 0);
    }
}
