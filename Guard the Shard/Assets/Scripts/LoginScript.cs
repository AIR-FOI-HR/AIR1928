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

    public void IdiNaRegistraciju()
    {
        SceneManager.LoadScene(1);
    }

    public void Login()
    {
        UserLogin userLogin = new UserLogin();
        if(userLogin.SignInUser(Email.text.ToString(), Password.text.ToString()))
        {
            SceneManager.LoadScene(3);
        }
    }
}
