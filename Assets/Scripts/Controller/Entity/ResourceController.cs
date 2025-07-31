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
    public float MaxHealth => statHandler.Health;

    public float Exp { get; private set; }
    public int Exp { get; private set; }
    public int Level => statHandler.Level;

    private int RequireExp = 10;

    private void Awake()
    {
        statHandler = GetComponent<StatHandler>();
        baseController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = statHandler.Health;
        
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
        
        if(change < 0)
        {
            if(animationHandler != null)
                animationHandler.Damage();
        }

        if(CurrentHealth <= 0)
        {
            if(animationHandler != null)
                animationHandler?.Die();
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
        
        Exp -= RequireExp;
        statHandler.Level++;

        if (statHandler.Level >= 2 && statHandler.Level <= 4)
        {
            RequireExp = 10 + 5 * (statHandler.Level - 1);
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
        }
        else if (statHandler.Level == 5)
        {
            RequireExp = 40;
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
        }
        else if (statHandler.Level >= 6 && statHandler.Level <= 8)
        {
            RequireExp = 40 + 10 * (statHandler.Level - 5);
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.1);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.1);
        }
        else if (statHandler.Level == 9)
        {
            RequireExp = 100;
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
        }
        else if (statHandler.Level >= 10 && statHandler.Level <= 14)
        {
            RequireExp = 100 + 20 * (statHandler.Level - 9);
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
        }
        else if (statHandler.Level >= 15 && statHandler.Level <= 19)
        {
            RequireExp = 200 + 40 * (statHandler.Level - 14);
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
        }
        else if (Level == 20)
        {
            Exp = 0;
            RequireExp = 1;
            statHandler.Health = (float)(statHandler.Health + statHandler.Health * 0.05);
            statHandler.Speed = (float)(statHandler.Speed + statHandler.Speed * 0.05);
        }

    }

    

    private void Death()
    {
        baseController.Death();
    }
}
