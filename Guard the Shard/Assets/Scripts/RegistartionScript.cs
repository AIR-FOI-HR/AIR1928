using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegistartionScript : MonoBehaviour
{
    public InputField Email;
    public InputField Username;
    public InputField Password;
    public InputField ConfirmPassword;

    public void IdiNaPrijavu()
    {
        SceneManager.LoadScene(2);
    }

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
