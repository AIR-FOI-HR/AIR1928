using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorijalManager : MonoBehaviour
{
    public int stage = 0;
    private Vector3 initial;
    private GameObject turret;
    private Energy energyscript;
    private float energy = 0;
    private string type = "ground";
    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        turret = GameObject.Find("Turret");
        initial = turret.transform.position;
        energyscript = GameObject.Find("EnergyContainer").GetComponent<Energy>();
    }
    void Update()
    {
        switch (stage)
        {
            case 0:
                if (turret.transform.position != initial)
                {
                    Debug.Log("turret pomaknut :)");
                    stage++;
                    type = turret.GetComponent<TurretAttacking>().type;
                }
                break;
            case 1:
                if (type != turret.GetComponent<TurretAttacking>().type)
                {
                    Debug.Log("tip turreta promijenjen");
                    stage++;
                    energy = energyscript.currentEnergy;
                }
                break;
            case 2:
                if(energy != energyscript.currentEnergy)
                {
                    Debug.Log("energija pokupljena/potrošena");
                    energyscript.countdown = Mathf.Infinity;
                    GameObject crystal = GameObject.Find("Crystal");
                    while (crystal != null)
                    {
                        GameObject.Destroy(crystal);
                        crystal = GameObject.Find("Crystal");
                    }
                    GameObject.Find("EnemyParent").transform.Find("AirDummy").gameObject.SetActive(true);
                    GameObject.Find("EnemyParent").transform.Find("EarthDummy").gameObject.SetActive(true);
                    stage++;
                }
                break;
            case 3:
                //da ne ubiju neprijatelje vještinama
                if (energyscript.currentEnergy != 0)
                {
                    energyscript.Deduct((int)energyscript.currentEnergy);
                }
                if (GameObject.Find("AirDummy") == null && GameObject.Find("EarthDummy") == null)
                {
                    Debug.Log("neprijatelji ubijeni");
                    turret.SetActive(false);
                    GameObject.Find("EnemyParent").transform.Find("AbilityDummy").gameObject.SetActive(true);
                    energyscript.AddEnergy(100);
                    stage++;
                }
                break;
            case 4:
                if(energyscript.currentEnergy < 100)
                {
                    energyscript.AddEnergy(100 - energyscript.currentEnergy);
                }
                if (GameObject.Find("AbilityDummy") == null)
                {
                    Debug.Log("vještina iskorištena ispravno, tutorijal gotov");
                    stage++;
                }
                break;
        }
    }

}
