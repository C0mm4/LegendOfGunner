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
        statHandler.Health = CurrentHealth;
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

    private void Death()
    {
        baseController.Death();
    }
}
