using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabControler : MonoBehaviour
{
    //
    [SerializeField] GameObject scenarioPanel;
    [SerializeField] GameObject itemPanel;
    public void ShowItem()
    {
        scenarioPanel.SetActive(false);
        itemPanel.SetActive(true);
    }
    public void ShowScenario()
    {
        scenarioPanel.SetActive(true);
        itemPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowItem();
        }
    }
}
