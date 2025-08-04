using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    private LevelUpModel model;
    private LevelUpView view;

    private void Start()
    {
        UIManager.Instance.levelUPRewordUI = this.gameObject;
        model = transform.GetComponent<LevelUpModel>();
        view = GetComponent<LevelUpView>();
        gameObject.SetActive(false);
        model.SetRandomReword();
    }
    private void OnEnable()
    {
        Debug.Log("qwcxztweq");

        var val = model.SetRandomReword();
        view.SetRewordUI(model.handguns, val);
    }
    public void AddRage()
    {
        Debug.Log("AddRage");
    }
    public void AddDamage()
    {
        Debug.Log("AddDamage");
    }
    public void AddAtkSpd()
    {
        Debug.Log("AddAtkSpd");
    }
    public void ReplaceLaser()
    {
        Debug.Log("ReplaceLaser");
    }
    public void TripleShot()
    {
        Debug.Log("TripleShot");
    }
    public void AddBullet()
    {
        Debug.Log("AddBullet");
    }
    public void Granade()
    {
        Debug.Log("Granade");
    }
    public void ReduceCooldown()
    {
        Debug.Log("ReduceCooldown");
    }

    public void PiercingBullet()
    {
        Debug.Log("PiercingBullet");
    }
    public void SelectReword(int num)
    {
        model.SelectReword(num);
    }
}
