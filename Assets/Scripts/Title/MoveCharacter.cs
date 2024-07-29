using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveCharacter : MonoBehaviour
{
    // 設定する位置
    private struct Position
    {
        public Vector2 initialize,
            midpoint,
            goal;
    }
    Position position;

    private float time_tmp,
        time_wait,
        SPEED_MOVE;

    private enum JOB
    {
        BOY = 1,
        GIRL = 2,
        MOM = 3,
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
        TextAsset csvFile = Resources.Load("TitleData") as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換
        List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        int jobIndex = (int)job;
        float initialize_x = float.Parse(csvData[jobIndex][1]);
        float initialize_y = float.Parse(csvData[jobIndex][2]);
        float midpoint_x = float.Parse(csvData[jobIndex][3]);
        float midpoint_y = float.Parse(csvData[jobIndex][4]);
        float goal_x = float.Parse(csvData[jobIndex][5]);
        float goal_y = float.Parse(csvData[jobIndex][6]);
        SPEED_MOVE = float.Parse(csvData[jobIndex][7]);
        time_wait = float.Parse(csvData[jobIndex][8]);

        position.initialize = new Vector2(initialize_x, initialize_y);
        position.midpoint = new Vector2(midpoint_x, midpoint_y);
        position.goal = new Vector2(goal_x, goal_y);
        // 位置の初期化
        transform.localPosition = position.initialize;
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
                    float tmp = (Time.time - time_tmp) * SPEED_MOVE / Vector2.Distance(position.initialize, position.midpoint);
                    transform.localPosition = Vector2.Lerp(position.initialize, position.midpoint, tmp);

                    if (transform.localPosition.x == position.midpoint.x)
                    {
                        arrived_position = ARRIVED_POSITION.MIDPOINT;
                        time_tmp = Time.time;
                    }
                    break;
                case ARRIVED_POSITION.MIDPOINT:
                    tmp = (Time.time - time_tmp) * SPEED_MOVE / Vector2.Distance(position.midpoint, position.goal);
                    transform.localPosition = Vector2.Lerp(position.midpoint, position.goal, tmp);

                    if (transform.localPosition.x == position.goal.x)
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
