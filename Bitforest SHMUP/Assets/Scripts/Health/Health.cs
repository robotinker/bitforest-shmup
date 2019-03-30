using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHP;
    public int HP;

    public bool KillOnZeroHP;
    public Action OnDeath;
    public Action OnDamage;
    public Action<float> OnChange;

    [SerializeField]
    float _ImmuneTime = 1.5f;
    public float ImmuneTime { get { return _ImmuneTime; } }
    float ImmuneTimer = 0f;

    bool IsImmune { get { return ImmuneTimer > 0f; } }

    void Start()
    {
        HP = MaxHP;
    }

    void Update()
    {
        if (ImmuneTimer > 0)
        {
            ImmuneTimer -= Time.deltaTime;
        }
    }

    public void Heal()
    {
        HP = MaxHP;
    }

    public void Damage(int damage)
    {
        ChangeHealth(-1 * damage);
    }

    public void Heal(int amount)
    {
        ChangeHealth(amount);
    }

    void ChangeHealth(int change)
    {
        if (change < 0)
        {
            if (IsImmune)
            {
                return;
            }
            else
            {
                ImmuneTimer = ImmuneTime;
            }
        }

        HP = Mathf.Clamp(HP + change, 0, MaxHP);

        if (change != 0)
        {
            if (change < 0)
            {
                OnDamage?.Invoke();
            }
            OnChange?.Invoke(HP / (1f * MaxHP));
        }

        if (HP == 0)
        {
            OnDeath?.Invoke();
            if (KillOnZeroHP)
            {
                Destroy(gameObject);
            }
        }
    }
}
