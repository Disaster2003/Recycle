using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバー
        if(timer <= 0)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        timer -= Time.deltaTime;

        GetComponent<Text>().text = timer.ToString("f1") + "s";
    }
}
