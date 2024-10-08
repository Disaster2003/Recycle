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
        // 端で自身を破壊
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
        // 左に進む
        else
        {
            transform.position += new Vector3(-Time.deltaTime * 5, 0, 0);
        }
    }

    private void OnMouseOver()
    {
        // nullチェック
        if(imgDestroyTrash == null)
        {
            Debug.Log("ゴミ箱の画像が未設定です");
            return;
        }
        if(keyCode == KeyCode.None)
        {
            Debug.Log("キーの振り分けが未完了です");
            return;
        }
        if(trashbox == null)
        {
            Debug.Log("ゴミを捨てる音が未設定です");
            return;
        }

        // Recycleして、自身を破壊
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
