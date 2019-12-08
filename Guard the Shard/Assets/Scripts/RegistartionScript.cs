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
        SceneManager.LoadScene(2);
    }

    //Potvrda registracije ukoliko su sva polja ispravno popunjena
    //Prelazak na scenu glavnog izbornika
    public void Registration()
    {
        UserLogin userLogin = new UserLogin();
        if (Email.text.ToString() != "" && Username.text.ToString() != "" && Password.text.ToString() != "")
        {
            if (Password.text.ToString() == ConfirmPassword.text.ToString())
            {
                if (userLogin.SignUpUser(Email.text.ToString(), Password.text.ToString(), Username.text.ToString()))
                {
                    SceneManager.LoadScene(3);
                }
                SceneManager.LoadScene(3);
            }
        }
    }
}
