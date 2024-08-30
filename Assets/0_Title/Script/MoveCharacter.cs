using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveCharacter : MonoBehaviour
{
    // 設定する位置
    private struct POSITION
    {
        public Vector2 initialize,
            midpoint,
            goal_self,
            goal_mom;
    }
    POSITION position;

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

    [SerializeField] GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        // CSVの読み込み
        TextAsset csvFile = Resources.Load("TitleData") as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換
        List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        // データの代入
        int jobIndex = (int)job;
        int jobIndex_mom = (int)JOB.MOM;
        float initialize_x = float.Parse(csvData[jobIndex][1]);
        float initialize_y = float.Parse(csvData[jobIndex][2]);
        float midpoint_x = float.Parse(csvData[jobIndex][3]);
        float midpoint_y = float.Parse(csvData[jobIndex][4]);
        float goal_self_x = float.Parse(csvData[jobIndex][5]);
        float goal_self_y = float.Parse(csvData[jobIndex][6]);
        float goal_mom_x = float.Parse(csvData[jobIndex_mom][5]);
        float goal_mom_y = float.Parse(csvData[jobIndex_mom][6]);
        SPEED_MOVE = float.Parse(csvData[jobIndex][7]);
        time_wait = float.Parse(csvData[jobIndex][8]);

        position.initialize = new Vector2(initialize_x, initialize_y);
        position.midpoint = new Vector2(midpoint_x, midpoint_y);
        position.goal_self = new Vector2(goal_self_x, goal_self_y);
        position.goal_mom = new Vector2(goal_mom_x, goal_mom_y);

        // 位置の初期化
        transform.position = position.initialize;
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
                    transform.position = Vector2.Lerp(position.initialize, position.midpoint, tmp);

                    if (transform.position.x == position.midpoint.x)
                    {
                        arrived_position = ARRIVED_POSITION.MIDPOINT;
                        isEntered = false;
                    }
                    break;
                case ARRIVED_POSITION.MIDPOINT:
                    tmp = (Time.time - time_tmp) * SPEED_MOVE / Vector2.Distance(position.midpoint, position.goal_self);
                    transform.position = Vector2.Lerp(position.midpoint, position.goal_self, tmp);

                    if (transform.position.x == position.goal_self.x)
                        arrived_position = ARRIVED_POSITION.GOAL;
                    break;
                case ARRIVED_POSITION.GOAL:
                    if (mom.GetComponent<MoveCharacter>().transform.position.x == position.goal_mom.x)
                    {
                        tmp = Mathf.PingPong(Time.time * SPEED_MOVE * 20, 40 - -40) + -40;
                        transform.rotation =
                            Quaternion.Euler(0, GetComponent<Transform>().eulerAngles.y, tmp);
                    }
                    break;
            }
        }
        // 待ち時間計測
        else
            time_wait -= Time.deltaTime;
    }
}
