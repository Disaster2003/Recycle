using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] trash;
    //private float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        // null�`�F�b�N
        if (trash == null)
        {
            Debug.Log("�S�~�̃I�u�W�F�N�g�����ݒ�ł�");
            return;
        }

        // ����I(��O�����̒ls)�Ɋ֐������s
        // �~�߂�ꍇ�́ACancelInvoke()
        InvokeRepeating(nameof(SpawnTrash), 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //// ���������t������Ȃ�A���̂���
        //// �X�|�[��������
        //if (timer <= 0)
        //{
        //    timer = 3;
        //    SpawnTrash();
        //}
        //// ���Ԍv��
        //timer -= Time.deltaTime;
    }

    /// <summary>
    /// �X�|�[������
    /// </summary>
    private void SpawnTrash()
    {
        // �S�~�̐���
        Instantiate(trash[Random.Range(0, trash.Length)]);
    }
}
