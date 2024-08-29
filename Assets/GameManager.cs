using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���̏��
    /// </summary>
    private enum SCENE_STATE
    {
        TITLE = 0,
        PLAY = 1,
        RESULT,
    }
    private SCENE_STATE scene_state = SCENE_STATE.TITLE;

    // Update is called once per frame
    void Update()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        switch (scene_state)
        {
            case SCENE_STATE.TITLE:
                // �v���C��ʂ�
                if(Input.GetKeyDown(KeyCode.Return))
                    SceneManager.LoadSceneAsync(buildIndex + 1);
                break;
            case SCENE_STATE.PLAY:
                break;
            case SCENE_STATE.RESULT:
                // �^�C�g����ʂ�
                if (Input.GetKeyDown(KeyCode.Return))
                    SceneManager.LoadSceneAsync((int)SCENE_STATE.TITLE);
                break;
        }
    }
}
