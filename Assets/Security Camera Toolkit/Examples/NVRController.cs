// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace zFramework.Media.Demo
{
    //For Demo
    public class NVRController : MonoBehaviour
    {
        public Button login_bt;
        public Button logout_bt;
        Text login, logout;

        private void Start()
        {
            login = login_bt.GetComponentInChildren<Text>();
            logout = logout_bt.GetComponentInChildren<Text>();

            login_bt.onClick.AddListener(Login);
            logout_bt.onClick.AddListener(Logout);
        }
        void Login() => _ = LoginAsync();
        void Logout() => _ = LogoutAsync();

        async Task LoginAsync()
        {
            login.text = "登录中";
            login_bt.interactable = false;
            await NVRManager.LoginAllAsync();
            login.text = "已登录";
            logout.text = "登出";
            login_bt.interactable = true;
        }

        async Task LogoutAsync()
        {
            logout.text = "登出中";
            logout_bt.interactable = false;
            await NVRManager.LogoutAllAsync();
            logout.text = "已登出";
            login.text = "登录";
            logout_bt.interactable = true;
        }
    }
}
