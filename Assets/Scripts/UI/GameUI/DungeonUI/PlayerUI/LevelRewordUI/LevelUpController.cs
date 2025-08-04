using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    private LevelUpModel model;
    private LevelUpView view;

    private void Awake()
    {
        model = transform.GetComponent<LevelUpModel>();
        view = GetComponent<LevelUpView>();
    }
    private void OnEnable()
    {
        view.SetRewordUI(model.handgunQueue, model.SetRandomReword());
        GameManager.Instance.PauseGame();
    }

    private void OnDisable()
    {
        GameManager.Instance.PauseGame();
    }

    public void SelectReword(int num)
    {
        model.SelectReword(num);
    }
}
