using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegistartionScript : MonoBehaviour
{
    //Polja za umetanje vrijednosti potrebnih stavki
    public InputField Email;
    public InputField Username;
    public InputField Password;
    public InputField ConfirmPassword;

    //Prelazak na scenu prijave
    public void IdiNaPrijavu()
    {
        SkillControl tc = new SkillControl();
        List<Skill> p = tc.GetSkills();
        Debug.Log(p[0].Damage);
        //SceneManager.LoadScene(2);
    }

    //Potvrda registracije ukoliko su sva polja ispravno popunjena
    //Prelazak na scenu glavnog izbornika
    public void Registration()
    {
        UserControl userControl = new UserControl();
        if (Username.text.ToString() != "" && Password.text.ToString() != "")
        {
            if (Password.text.ToString() == ConfirmPassword.text.ToString())
            {
                if (userControl.Register(Username.text.ToString(), Password.text.ToString())=="Everything ok")
                {
                    SceneManager.LoadScene(3);
                }
                else
                {
                    Debug.Log("Username is used");
                }
            }
        }
    }
}
