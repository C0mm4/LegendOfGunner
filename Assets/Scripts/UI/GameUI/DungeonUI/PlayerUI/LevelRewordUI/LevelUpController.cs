using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    private LevelUpModel model;
    private LevelUpView view;

    List<Attribute> showAttributes = new();

    private void Awake()
    {
        model = transform.GetComponent<LevelUpModel>();
        view = GetComponent<LevelUpView>();
    }
    private void OnEnable()
    {
        model.SetRandomQueue();
        var randomRewards = model.SetRandomReword();
        showAttributes.Clear();
        showAttributes.Add(AttributeManager.Instance._HandGunAttributes[0]);
        showAttributes.Add(randomRewards[0][0]);
        showAttributes.Add(randomRewards[1][0]);

        view.SetRewordUI(showAttributes);
        GameManager.Instance.PauseGame();
    }

    private void OnDisable()
    {
        GameManager.Instance.ResumeGame();
    }

    public void SelectReword(int num)
    {
        model.SelectReword(num, showAttributes[num]);
    }
}
