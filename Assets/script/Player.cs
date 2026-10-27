using UnityEngine;

public class Player : MonoBehaviour
{

    float Playerspeed = 3.0f;
    float Jumpspeed = 100.0f;

     void Update()
    {
        // 前移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Playerspeed * transform.forward * Time.deltaTime;
        }
        // 後ろ移動
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Playerspeed * transform.forward * Time.deltaTime;
        }
        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Playerspeed * transform.right * Time.deltaTime;
        }
        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Playerspeed * transform.right * Time.deltaTime;
        }
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Jumpspeed * transform.up * Time.deltaTime;
        }

    }
}
