using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScaleHealth : MonoBehaviour
{
    private Image healthBar;

    void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scale(float lives)
    {
        healthBar.fillAmount = lives * 20 / 100f;
    }

    
}
