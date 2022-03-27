// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    public interface INVRStateHandler
    {
        string Host{ get;  }
        void OnLogin(object loginHandle);
        void OnLogout();
    }
}
