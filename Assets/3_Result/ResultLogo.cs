using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.isCleared)
        {
            GetComponent<Text>().text = "GameClear";
            GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            GetComponent<Text>().text = "GameOver";
            GetComponent<Text>().color = Color.blue;
        }
    }
}
