using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] Sprite imgDestroyTrash;
    [SerializeField] KeyCode keyCode;

    [SerializeField] AudioClip trashbox;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // �[�Ŏ��g��j��
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
        // ���ɐi��
        else
        {
            transform.position += new Vector3(-Time.deltaTime * 5, 0, 0);
        }
    }

    private void OnMouseOver()
    {
        // null�`�F�b�N
        if(imgDestroyTrash == null)
        {
            Debug.Log("�S�~���̉摜�����݂��܂���");
            return;
        }
        if(trashbox == null)
        {
            Debug.Log("�S�~���̂Ă鉹�����݂��܂���");
            return;
        }

        // Recycle���āA���g��j��
        if (Input.GetKeyDown(keyCode))
        {
            GetComponent<AudioSource>().PlayOneShot(trashbox);
            GetComponent<SpriteRenderer>().sprite = imgDestroyTrash;
            Invoke(nameof(DestroyMyself), 0.5f);
        }
    }

    private void DestroyMyself()
    {
        TaskCount.countTask++;
        Destroy(gameObject);
    }
}
