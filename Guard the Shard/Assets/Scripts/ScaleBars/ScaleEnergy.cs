using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleEnergy : MonoBehaviour
{
    private Image healthBar;

    void Awake()
    {
        healthBar = GameObject.Find("EnergyBar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Scale(float energyAmount)
    {
        healthBar.fillAmount = energyAmount / 100f;
    }

}
