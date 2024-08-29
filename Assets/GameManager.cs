using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���̏��
    /// </summary>
    enum SCENE_STATE
    {
        TITLE = 0,
        PLAY = 1,
        RESULT,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �N���b�N�Ŏ��̃V�[����
    /// </summary>
    public void OnClickNextScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if(buildIndex == (int)SCENE_STATE.RESULT)
            SceneManager.LoadSceneAsync((int)SCENE_STATE.TITLE);
        else
            SceneManager.LoadSceneAsync(buildIndex);
    }
}
