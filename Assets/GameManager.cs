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
        EXPLAIN = 1,
        PLAY = 2,
        RESULT = 3,
    }
    private SCENE_STATE scene_state = SCENE_STATE.TITLE;

    public static bool isCleared = false;

    [SerializeField] AudioClip buttonDown;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        scene_state = (SCENE_STATE)buildIndex;
        switch (scene_state)
        {
            case SCENE_STATE.TITLE:
                // ������ʂ�
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GetComponent<AudioSource>().PlayOneShot(buttonDown);
                    SceneManager.LoadSceneAsync(buildIndex + 1);
                }
                break;
            case SCENE_STATE.EXPLAIN:
                // �v���C��ʂ�
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isCleared = false;
                    GetComponent<AudioSource>().PlayOneShot(buttonDown);
                    SceneManager.LoadSceneAsync(buildIndex + 1);
                }
                break;
            case SCENE_STATE.PLAY:
                break;
            case SCENE_STATE.RESULT:
                // �^�C�g����ʂ�
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GetComponent<AudioSource>().PlayOneShot(buttonDown);
                    SceneManager.LoadSceneAsync((int)SCENE_STATE.TITLE);
                }
                break;
        }
    }
}
