using UnityEngine;

/// <summary>
/// 一定間隔で壁を生成するコンポーネント
/// 適当なオブジェクトにアタッチして使う。
/// 一定間隔で、設定した Wall Prefabs からランダムにプレハブを選び、生成する
/// </summary>
public class WallGenerator : MonoBehaviour
{
    /// <summary>壁として生成するプレハブ</summary>
    [SerializeField] GameObject[] m_wallPrefabs = null;
    /// <summary>壁を生成する間隔（秒）</summary>
    [SerializeField] float m_wallGenerateInterval = 2f;
    /// <summary>壁生成間隔を計るためのタイマー（秒）</summary>
    float m_timer = 0;
    //壁をスポーンさせた数を数える。
    int m_spawnCount = 0;
    GameObject b_object;




    void Start()
    {
        // 実行したら最初の壁がすぐ生成されるようにタイマーに値を入れておく
        m_timer = m_wallGenerateInterval;
        m_spawnCount = 0;
        //指定したオブジェクトを探す。
        b_object = GameObject.Find("Bird");
    }

    void Update()
    {
        {
            m_timer += Time.deltaTime;

            // タイマーの値が生成間隔を超えたら
            if (m_timer > m_wallGenerateInterval)
            {
                if (m_spawnCount < 10)
                {
                    m_timer = 0f;   // タイマーをリセットする
                    int index = Random.Range(0, m_wallPrefabs.Length);  // 配列からオブジェクトを選ぶためのインデックス（添字）をランダムに選ぶ
                    GameObject go = Instantiate(m_wallPrefabs[index]);  // プレハブからオブジェクトを生成して、変数 go に入れる
                    go.transform.position = new Vector2(10f, 0f);   // 生成したオブジェクトの位置を定める
                    m_spawnCount++;

                }
                else if (m_spawnCount < 30)
                {
                    m_wallGenerateInterval = 1.5f;
                    m_timer = 0f;   // タイマーをリセットする
                    int index = Random.Range(0, m_wallPrefabs.Length);  // 配列からオブジェクトを選ぶためのインデックス（添字）をランダムに選ぶ
                    GameObject go = Instantiate(m_wallPrefabs[index]);  // プレハブからオブジェクトを生成して、変数 go に入れる
                    go.transform.position = new Vector2(10f, 0f);   // 生成したオブジェクトの位置を定める
                    m_spawnCount++;


                }
                else
                {
                    m_wallGenerateInterval = 1f;
                    m_timer = 0f;   // タイマーをリセットする
                    int index = Random.Range(0, m_wallPrefabs.Length);  // 配列からオブジェクトを選ぶためのインデックス（添字）をランダムに選ぶ
                    GameObject go = Instantiate(m_wallPrefabs[index]);  // プレハブからオブジェクトを生成して、変数 go に入れる
                    go.transform.position = new Vector2(10f, 0f);   // 生成したオブジェクトの位置を定める
                    m_spawnCount++;


                }
                if (m_spawnCount == 10)
                {
                    Rigidbody2D rb = b_object.GetComponent<Rigidbody2D>();
                    //鳥の速度を変える。
                    rb.velocity = new Vector3(0, 8, 0);
                    //背景の一部を削除する。
                    Destroy(GameObject.Find("BackgroundCloud(3)"));
                    Destroy(GameObject.Find("BackgroundCloud (2)"));
                }
                if (m_spawnCount == 30)
                {
                    Rigidbody2D rb = b_object.GetComponent<Rigidbody2D>();
                    //鳥の速度を変える。
                    rb.velocity = new Vector3(0, 10, 0);
                    //背景の一部を削除する。
                    Destroy(GameObject.Find("BackgroundCloud"));
                    Destroy(GameObject.Find("BackgroundCloud (1)"));
                }
                
            }
        }
    }
}
