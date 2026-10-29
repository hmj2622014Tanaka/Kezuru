using UnityEngine;

public class enemy2 : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";   // UŒ‚‘ÎÛ
    [SerializeField] int maxHp = 1;
    int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    // ƒ_ƒ[ƒW‚ğó‚¯‚½
    public void TakeDamage2(int damage)
    {
        currentHp -= damage;
        Debug.Log($"“G‚ª{damage}‚Ìƒ_ƒ[ƒW‚ğó‚¯‚½Bc‚è‚ÌHP:{currentHp}");

        // ‘Ì—Í‚ª‚O‚É‚È‚Á‚½
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("“G‚ª“|‚ê‚½!!");
        Destroy(gameObject);    // “G‚Ìíœ
    }
}