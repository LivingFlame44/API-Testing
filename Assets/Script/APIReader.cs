using Models;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIReader : MonoBehaviour
{
    private readonly string basePath = "https://retoolapi.dev/OJ3ve2/SuiBudokanAPI";
    public UserData[] users;

    public UserData userData;

    public void Start()
    {
        Get();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Post();
        }
        

    }

    public void Get()
    { 
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);   

                if(users!= null) {
                    Debug.Log("Number of users : " + users.Length);
                }
                
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "User array is null");
            }

        }).Catch(error => { 
            Debug.Log(error.Message);
        }

        );
    }

    public void Post()
    {
        RestClient.Post(basePath, userData).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Successful");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

        );
    }

    public void DeleteUser(int userId)
    {
        RestClient.Delete(basePath + "/"+ userId).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Deleted Successfully");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

           );
    }

    public void PatchUser()
    {
        RestClient.Patch(basePath + "/" + userData.id,userData).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Patched Successfully");
                }
                else
                {
                    Debug.Log("No Response");
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error Patching UserData");
            }

        }).Catch(error => {
            Debug.Log(error.Message);
        }

   );
    }

}
