using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnScript : MonoBehaviour
{
    public LevelDataControler scriptWithData;
    public GameObject turret;
    // Start is called before the first frame update
    void Awake()
    {
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        turret = Resources.Load($"Turret1") as GameObject;
        Instantiate(turret, transform.position, transform.rotation);
    }

}
