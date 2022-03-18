namespace zFramework.Media
{
    public interface INVRStateHandler
    {
        string Host{ get;  }
        void OnLogin(object loginHandle);
        void OnLogout();
    }
}
