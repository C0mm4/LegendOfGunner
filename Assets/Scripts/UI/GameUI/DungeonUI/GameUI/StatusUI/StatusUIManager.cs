using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text HP;
    public TMP_Text Exp;
    public TMP_Text Level;

    ResourceController resourceController;

    private void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();

        
    }

    private void Update()
    {
        HP.text = $"HP : {Mathf.Round(resourceController.CurrentHealth)}  /  {Mathf.Round(resourceController.MaxHealth)}";
        Exp.text = $"Exp : {resourceController.Exp}  /  {resourceController.RequireExp}";
        Level.text = $"Level : {resourceController.Level}";
    }
}
