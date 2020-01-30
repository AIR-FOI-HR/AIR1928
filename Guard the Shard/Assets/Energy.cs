using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public ScaleEnergy EnergyBarScript = null;
    public GameObject crystal;
    public float currentEnergy = 0;
    public float countdown = 5f;
    private void Start()
    {
        EnergyBarScript = GameObject.Find("EnergyBar").GetComponent<ScaleEnergy>();
    }
    private GameObject RaycastElemnt(string name, RaycastHit2D[] hits)
    {
        foreach (var item in hits)
        {
            if (item.collider.name == name)
            {
                return item.collider.gameObject;
            }
        }
        return null;
    }
    void Update()
    {
        if (countdown <= 0)
        {
            //stvori kristal
            Instantiate(crystal,Random.insideUnitCircle*4, Quaternion.identity);
            //reset timera
            countdown = 5f;
        }
        //odbrojavanje
        countdown -= Time.deltaTime;
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("tap");
            //raycasting
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);
            //Debug.Log(hits.Length);
            GameObject crystal = RaycastElemnt("Crystal(Clone)",hits);
            if (crystal != null)
            {
                Destroy(crystal);
                AddEnergy(10);
            }
        }
    }
    public void AddEnergy(float amount)
    {
        if((currentEnergy + amount) > 100)
        {
            currentEnergy = 100;
        }
        else
        {
            currentEnergy = currentEnergy + amount;
        }
        EnergyBarScript.Scale(currentEnergy);
    }
    public void Deduct(int cost)
    {
        if ((currentEnergy - cost) < 0)
        {
            currentEnergy = 0;
        }
        else
        {
            currentEnergy = currentEnergy - cost;
        }
        EnergyBarScript.Scale((float)currentEnergy);
    }
}
