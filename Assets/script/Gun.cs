using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;

    [SerializeField] int damage = 1;
    [SerializeField] float range = 100f;

    void Start()
    {
        if (fpsCamera == null)
        {
            fpsCamera = FindObjectOfType<Camera>();
        }
    }

    void Update()
    {
        // マウス左クリックで発射
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (fpsCamera == null)
        {
            Debug.LogWarning("FPSカメラが設定されていません");
            return;
        }

        // 画面中央からRayを飛ばす
        Ray ray = new Ray(
        fpsCamera.transform.position,
        fpsCamera.transform.forward
        );

        RaycastHit hit;

        // 指定した距離以内に何か当たったか調べる
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("命中！：" + hit.collider.name);

            // 当たったオブジェクト、または親からenemy1を取得
            enemy1 enemy = hit.collider.GetComponentInParent<enemy1>();

            // 敵に当たった場合
            if (enemy != null)
            {
                enemy.TakeDamage1(damage);
            }
        }
    }
}
