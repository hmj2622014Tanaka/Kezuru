using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float jumpPowor;
    [SerializeField] int maxJumpCount = 2;
    float Playerspeed = 3.0f;
    int junpCount = 0;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        if (Input.GetKeyDown(KeyCode.Space) && junpCount < maxJumpCount)
        {
            Vector3 vel = rb.linearVelocity;
            vel.y = 0f;
            rb.linearVelocity = vel;

            rb.AddForce(Vector3.up * jumpPowor, ForceMode.Impulse);
            junpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            junpCount = 0;
        }
    }
}
