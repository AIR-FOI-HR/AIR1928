using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    //Gumbovi koji se nalaze na Login screenu
    public InputField Email;
    public InputField Password;

    //Prelazak na scenu registracije
    public void IdiNaRegistraciju()
    {
        SceneManager.LoadScene(1);
    }

    //Prelazak na scenu glavnog izbornika ukoliko se dohvaćeni podaci podudaraju
    public void Login()
    {
        UserControl userControl = new UserControl();
        User user = userControl.Login(Email.text.ToString(), Password.text.ToString());

        if (user != null)
        {
            PlayerPrefs.SetInt("userid", user.ID);
            PlayerPrefs.Save();
            SceneManager.LoadScene(3);
        }
    }
}
