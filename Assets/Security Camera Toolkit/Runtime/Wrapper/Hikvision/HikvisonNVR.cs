using Hikvision;
using System.Threading.Tasks;
using UnityEngine;
namespace zFramework.Media
{
    public class HikvisonNVR : NVR
    {
        /// <summary>
        /// ����SDK�ĳ�ʼ��ֻ��Ҫ��һ�Σ��ʶ�ʹ�þ�̬����
        /// <br>ͬʱ��Ҳ��Ϊ��̬�����Բ���������������</br>
        /// </summary>
        public static bool IsSDKInit { get; private set; } = false;
        /// <summary>
        /// ���� NVR �Ƿ��¼
        /// </summary>
        public override bool IsLogin => null != loginHandle && (int)loginHandle > -1;

        public HikvisonNVR(NVRInformation data) : base(data)
        {

        }

        /// <summary>
        /// �˷�����Ҫ�����߳�ʹ�ã�Ϊɶ����Ϊһ��������API�ǳ����˳�ʱ�����������ܱ�������˳��쳣
        /// </summary>
        public override void CleanUp()
        {
            // todo �� ��������д��Ҫ�� init �� clean �ֱ�д���״� login �� logout ������� �첽�����⿨��
            Logout();
            if (IsSDKInit)
            {
                IsSDKInit = !CHCNetSDK.NET_DVR_Cleanup();
                if (IsSDKInit)
                {
                    Debug.Log($"{nameof(HikvisonNVR)}: ���� SDK �����쳣");
                }
            }
        }

        public override void InitSDK()
        {
            if (!IsSDKInit)
            {
                CHCNetSDK.NET_DVR_SetConnectTime(2000, 3);
                CHCNetSDK.NET_DVR_SetReconnect(1000, 1);
                IsSDKInit = CHCNetSDK.NET_DVR_Init();
                if (!IsSDKInit)
                {
                    Debug.LogError($"{nameof(HikvisonNVR)}: SDK ��ʼ��ʧ��");
                }
            }
        }

        public override void Login()
        {
            if (!IsLogin)
            {
                _ = Task.Run(() =>
                {
                    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                    loginHandle = CHCNetSDK.NET_DVR_Login_V30(data.Ip, (int)data.Port, data.userName, data.password, ref DeviceInfo);
                    if ((int)loginHandle != -1)
                    {
                        base.Login(); // ����صļ�ط��� ��¼״̬ , ע�⣬�˶����ڷ�Unity���߳��н���
                        Debug.Log($"{data.type} - {data.ActiveHost} NVR ��¼�ɹ���{loginHandle}");
                    }
                    else
                    {
                        Debug.Log($"{data.type} - {data.ActiveHost} NVR ��¼ʧ��,ErrorCode = {CHCNetSDK.NET_DVR_GetLastError()}");
                    }
                });
            }
            else
            {
                Debug.Log($"{data.type} - {data.ActiveHost} SDK �Ѿ���¼");
            }
        }

        public override void Logout()
        {
            base.Logout();
            if (IsLogin)
            {
                _ = Task.Run(() =>
                    {
                        var temp = CHCNetSDK.NET_DVR_Logout_V30((int)loginHandle);
                        if (temp)
                        {
                            Debug.Log($"{nameof(SDKManager)}: {data.ActiveHost} - {loginHandle} �ǳ��ɹ�");
                        }
                        else
                        {
                            Debug.LogWarning($"{nameof(SDKManager)}: {data.ActiveHost} - {loginHandle} �ǳ�ʧ��");
                        }
                    });
            }
        }
    }
}