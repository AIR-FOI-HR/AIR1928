using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScript : MonoBehaviour
{
    public Button bonusDamage;
    public Button bonusAttack;
    public Button bonusRange;
    System.Random rnd = new System.Random();
    void Awake()
    {
        bonusDamage = GameObject.Find("BonusDamage").GetComponent<Button>();
        bonusAttack = GameObject.Find("BonusAttackSpeed").GetComponent<Button>();
        bonusRange = GameObject.Find("BonusRange").GetComponent<Button>();
        bonusDamage.onClick.AddListener(delegate { ChooseBonus(1,RandomizeBonusDamage()); });
        bonusAttack.onClick.AddListener(delegate { ChooseBonus(2, RandomizeBonusFireRate()); });
        bonusRange.onClick.AddListener(delegate { ChooseBonus(3, RandomizeRange()); });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChooseBonus(int bonusPick, float value)
    {
        switch (bonusPick)
        {
            case 1:
                float dmg = FindObjectOfType<TurretAttacking>().damage;                
                FindObjectOfType<TurretAttacking>().damage = dmg + value;                
                break;
            case 2:
                float atk = FindObjectOfType<TurretAttacking>().fireRate;
                FindObjectOfType<TurretAttacking>().fireRate = atk * value;
                break;
            case 3:
                float rng = FindObjectOfType<TurretAttacking>().range;
                FindObjectOfType<TurretAttacking>().range = rng * value;
                break;

            default:
                break;
        }
        FindObjectOfType<UIElementManager>().PlayGame();
    }

    public int RandomizeBonusDamage()
    {       
        int damage = rnd.Next(1, 10);
        return damage;      
    }
    public int RandomizeBonusFireRate()
    {
        int fireRate = rnd.Next(1, 3);
        return fireRate;
    }
    public int RandomizeRange()
    {
        int range = rnd.Next(1, 5);
        return range;
    }
}
