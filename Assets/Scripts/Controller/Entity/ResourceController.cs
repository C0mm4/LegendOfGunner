using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;

    private BaseController baseController;
    private AnimationHandler animationHandler;
    private StatHandler statHandler;

    private float timeSinceLastChange = float.MaxValue;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler.MaxHealth;

    public float Exp { get; private set; }
    public int Level => statHandler.Level;

    public float RequireExp { get; private set; }
    

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        statHandler = baseController.statHandler;
        CurrentHealth = statHandler.Health;
        RequireExp = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                animationHandler?.InvicibillityEnd();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if(change == 0 || timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;
        statHandler.Health = CurrentHealth;

        if(change < 0)
        {
            if(animationHandler != null)
                animationHandler.Damage();
        }

        if(CurrentHealth <= 0)
        {
            if(animationHandler != null)
                animationHandler.Die();
            Death();
        }

        return true;
    }

    public void AddExp(int GetExp)
    {
        if (Level == 20) return;
        else
        {
            Exp += GetExp;
            while (Exp >= RequireExp)
            {
                if (Level == 20) break;
                else LevelUP();

            }
        }
    }

    public void LevelUP()
    {
        UIManager.Instance.ActiveLevelUPUI();
        Exp -= RequireExp;
        statHandler.Level++;
        //Pin Level
        if (statHandler.Level >= 2 && statHandler.Level <= 4)
        {
            RequireExp = 10 + 5 * (statHandler.Level - 1);
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
            ChangeHealth(2);

        }
        else if (statHandler.Level == 5)
        {
            RequireExp = 40;
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
            ChangeHealth(2);
        }
        else if (statHandler.Level >= 6 && statHandler.Level <= 8)
        {
            RequireExp = 40 + 10 * (statHandler.Level - 5);
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
            ChangeHealth(2);
        }
        else if (statHandler.Level == 9)
        {
            RequireExp = 100;
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
            ChangeHealth(2);
        }
        else if (statHandler.Level >= 10 && statHandler.Level <= 14)
        {
            RequireExp = 100 + 20 * (statHandler.Level - 9);
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
            ChangeHealth(2);
        }
        else if (statHandler.Level >= 15 && statHandler.Level <= 19)
        {
            RequireExp = 200 + 40 * (statHandler.Level - 14);
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
            ChangeHealth(2);
        }
        else if (Level == 20)
        {
            Exp = 0;
            RequireExp = 1;
            statHandler.MaxHealth = (float)(statHandler.MaxHealth + statHandler.MaxHealth * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
            ChangeHealth(2);
        }

    }

    

    private void Death()
    {
        baseController.Death();
    }
}
