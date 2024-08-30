using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskCount : MonoBehaviour
{
    public static int countTask;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
        countTask = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTask >= 20)
        {
            GameManager.isCleared = true;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        GetComponent<Text>().text = countTask.ToString() + "/20";
    }
}
