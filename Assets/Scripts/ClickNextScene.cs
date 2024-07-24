using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickNextScene : MonoBehaviour
{
    /// <summary>
    /// ƒNƒŠƒbƒNˆ—
    /// </summary>
    public void OnClick()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex + 1);
    }
}
