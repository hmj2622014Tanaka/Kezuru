using UnityEngine;

public class enemySpown : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Vector3 spawnRange = new Vector3(15f, 0f, 15f); // 横幅, 高さ, 奥行き

    [Header("スポーン間隔の設定")]
    [SerializeField] float initialInterval = 2.0f; // スタート時のスポーン間隔（秒）
    [SerializeField] float minInterval = 0.5f;     // 最も早くなったときのスポーン間隔（秒）
    [SerializeField] float difficultySpeed = 0.05f; // 1秒ごとにどれくらい間隔を短くするか

    float spawnInterval;
    float timer;
    float elapsedTime;

    void Start()
    {
        spawnInterval = initialInterval;
    }

    void Update()
    {
        Debug.Log("スポナー動作中");

        elapsedTime += Time.deltaTime;
        spawnInterval = Mathf.Max(
            minInterval,
            initialInterval - (elapsedTime * difficultySpeed)
        );

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Debug.Log("スポーン処理を呼び出す");
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        float randomX = Random.Range(-spawnRange.x / 2f, spawnRange.x / 2f);
        float randomY = Random.Range(-spawnRange.y / 2f, spawnRange.y / 2f);
        float randomZ = Random.Range(-spawnRange.z / 2f, spawnRange.z / 2f);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, randomZ);

        // 敵を生成
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Debug.Log($"敵を生成！ 時間：{elapsedTime:F1}秒 / 位置：{spawnPosition}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }
}