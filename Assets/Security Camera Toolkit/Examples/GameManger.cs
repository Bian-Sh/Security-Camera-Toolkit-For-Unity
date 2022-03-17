using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zFramework.Media;

[DefaultExecutionOrder(-900)]
public class GameManger : MonoBehaviour
{
    public void Login() 
    {
        NVRManager.Login();
    }

    public void Logout() 
    {
        NVRManager.Logout();
    }
}
