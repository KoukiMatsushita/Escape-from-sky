using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

/// <summary>
/// キャラクターを制御するコンポーネント
/// キャラクターにアタッチして使う。Rigidbody2D を必要とする。
/// ボタンでジャンプする。
/// 何かにぶつかったらゲームオーバーにする。
/// </summary>
public class BirdFlapController : MonoBehaviour
{
   
    /// <summary>スペースキーを押した時に上昇する力</summary>
    [SerializeField] float m_speedPower = 5f;
    /// <summary>鳥のオブジェクト</summary>
    Rigidbody2D m_rb = default;
  



    void Start()
    {

        m_rb = GetComponent<Rigidbody2D>();
       
        //Birdの行動処理
        m_rb.velocity = new Vector3(0, m_speedPower, 0);
        //時間を動かす。
        Time.timeScale = 1;

    }

    void Update()
    {
        // ジャンプボタンが力の方向を反対にする。
        if (Input.GetButtonDown("Jump"))
        {
            m_rb.velocity = -m_rb.velocity;
        }

      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
    　//ものにぶつかったら自爆する
       Destroy(this.gameObject);
        //時を止めて、エンディング処理
        Time.timeScale = 0;
        SceneManager.LoadScene("end");

    }

}
