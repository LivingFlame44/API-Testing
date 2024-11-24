using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpManager : MonoBehaviour
{
    public APIReader apiReader;

    public TMP_InputField usernameTxt, passwordTxt, confirmPWTxt, classTxt;
    public TMP_Dropdown classDropdown;

    public bool usernameOK, passwordOK;
    public GameObject errorUsername, errorPassword;

    public Button signUpButton;
    public GameObject signUpPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UsernameChecker();
        PasswordChecker();
        ClassDropDown();
        LogInChecker();
    }

    public void ClassDropDown()
    {
        switch(classDropdown.value)
        {
            case 0: apiReader.userData.Class = "Mage";
                break;
            case 1:
                apiReader.userData.Class = "Swordsman";
                break;
            case 2:
                apiReader.userData.Class = "Healer";
                break;
            case 3:
                apiReader.userData.Class = "Archer";
                break;
        }
    }

    public void SignUp()
    {
        apiReader.userData.id = apiReader.users.Length + 1;
        apiReader.userData.Username = usernameTxt.text;
        apiReader.userData.Password = passwordTxt.text;

        apiReader.Post();
        apiReader.Get();

        CleanUp();
    }

    public void CleanUp()
    {
        usernameTxt.text = null; 
        passwordTxt.text = null; 
        confirmPWTxt.text = null;

        usernameOK = false;
        passwordOK = false;

        signUpPanel.SetActive(false);
    }

    public void UsernameChecker()
    {
        errorUsername.SetActive(false);

        if (usernameTxt.text != "")
        {
            foreach (UserData user in apiReader.users)
            {
                if (user.Username == usernameTxt.text)
                {
                    usernameOK = false;
                    errorUsername.SetActive(true);
                    return;
                }
            }

            usernameOK = true;
        }


        else
        {
            usernameOK = false;
        }

        
    }

    public void PasswordChecker()
    {
        if(passwordTxt.text == confirmPWTxt.text && passwordTxt.text != "")
        {
            errorPassword.SetActive(false);
            passwordOK = true;
        }
        else if (passwordTxt.text != confirmPWTxt.text && passwordTxt.text != "")
        {
            errorPassword.SetActive(true);
            passwordOK = false;
        }

        else
        {
            errorPassword.SetActive(false);
            passwordOK = false;
        }
    }

    public void LogInChecker()
    {
        if(usernameOK && passwordOK)
        {
            signUpButton.interactable = true; 
        }
        else
        {
            signUpButton.interactable = false;
        }
    }
}
