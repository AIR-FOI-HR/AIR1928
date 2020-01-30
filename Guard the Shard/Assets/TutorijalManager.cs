using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Pomaknite turret dodirom prsta prvo na turret, a zatim na mjesto gdje ga želite prebaciti";
                if (turret.transform.position != initial)
                {
                    Debug.Log("turret pomaknut :)");
                    GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Uspješno ste pomaknuli turret, čestitamo";
                    stage++;
                    type = turret.GetComponent<TurretAttacking>().type;
                }
                break;
            case 1:
                GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Promijenite tip turreta pritiskom na tipku u donjem desnom kutu";
                if (type != turret.GetComponent<TurretAttacking>().type)
                {
                    Debug.Log("tip turreta promijenjen");
                    stage++;
                    energy = energyscript.currentEnergy;
                }
                break;
            case 2:
                GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Skupite energiju dodirom na ekran gdje se nalaze kristali";
                if (energy != energyscript.currentEnergy)
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
                GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Ubijte neprijatelje prethodno stečenim znanjima";
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
                GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Iskoristite vještinu tako da pritisnite jednu" +
                    " od vještina u donjem dijelu ekrana te zatim pritisnete na označene područje kako bi je aktivirali";
                if (energyscript.currentEnergy < 100)
                {
                    energyscript.AddEnergy(100 - energyscript.currentEnergy);
                }
                if (GameObject.Find("AbilityDummy") == null)
                {
                    GameObject.Find("UputeText").GetComponentInChildren<Text>().text = "Tutorial uspješno završen, spremni ste za igru!";
                    Debug.Log("vještina iskorištena ispravno, tutorijal gotov");
                    stage++;
                }
                break;
        }
    }

}
