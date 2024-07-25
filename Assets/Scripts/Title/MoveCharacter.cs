using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveCharacter : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト

    // 設定する位置
    [SerializeField] Vector2 position_initialize, position_midpoint, position_goal;

    [SerializeField] int SPEED_MOVE; // 移動速度

    private float time_tmp;

    [SerializeField] float time_wait;

    private enum JOB
    {
        BOY,
        GIRL,
        MOM,
    }
    [SerializeField] JOB job;

    private enum ARRIVED_POSITION
    {
        INITIALIZE,
        MIDPOINT,
        GOAL,
    }
    private ARRIVED_POSITION arrived_position = ARRIVED_POSITION.INITIALIZE;

    bool isEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        //csvFile = Resources.Load("TitleData") as TextAsset; // ResourcesにあるCSVファイルを格納
        //StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換
        //while (reader.Peek() != -1)
        //{
        //    string line = reader.ReadLine(); // 1行ずつ読み込む
        //    csvData.Add(line.Split(',')); // csvDataリストに追加する
        //}
        // 位置の初期化
        transform.localPosition = position_initialize;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_wait <= 0)
        {
            if (!isEntered)
            {
                isEntered = true;
                time_tmp = Time.time;
            }

            switch (arrived_position)
            {
                case ARRIVED_POSITION.INITIALIZE:
                    float tmp = (Time.time - time_tmp) * SPEED_MOVE / Vector2.Distance(position_initialize, position_midpoint);
                    transform.localPosition = Vector2.Lerp(position_initialize, position_midpoint, tmp);

                    if (transform.localPosition.x == position_midpoint.x)
                    {
                        arrived_position = ARRIVED_POSITION.MIDPOINT;
                        time_tmp = Time.time;
                    }
                    break;
                case ARRIVED_POSITION.MIDPOINT:
                    tmp = (Time.time - time_tmp) * SPEED_MOVE / Vector2.Distance(position_midpoint, position_goal);
                    transform.localPosition = Vector2.Lerp(position_midpoint, position_goal, tmp);

                    if (transform.localPosition.x == position_goal.x)
                        arrived_position = ARRIVED_POSITION.GOAL;
                    break;
                case ARRIVED_POSITION.GOAL:
                    tmp = Mathf.PingPong(Time.time * SPEED_MOVE * 0.25f, 40 - -40) + -40;
                    transform.localRotation =
                        Quaternion.Euler(0, GetComponent<RectTransform>().eulerAngles.y, tmp);
                    break;
            }
        }
        else
            time_wait -= Time.deltaTime;
    }
}
