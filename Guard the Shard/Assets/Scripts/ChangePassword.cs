using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangePassword : MonoBehaviour
{
    public InputField inpOldPassword;
    public InputField inpNewPassword;
    public InputField inpNewPasswordAgain;

    private UserControl userControl = new UserControl();

    public void ConfirmNewPasword()
    {
        if (inpNewPassword.text.ToString() == inpNewPasswordAgain.text.ToString())
        {
            if (userControl.ChangePassword(PlayerPrefs.GetInt("userid"), inpOldPassword.text, inpNewPassword.text))
            {
                SceneManager.LoadScene(7);
            }
            else
            {

            }
        }
        else
        {

        }
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(7);
    }
}
