using System;
using NETSDKHelper;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GeneralDef
{
    public class PlayPanel
    {
        public int m_panelIndex = -1;
        public int m_deviceIndex = -1;
        public int m_channelID = -1;
        public bool m_playStatus = false;/*播放状态，默认未播放*/
        public bool m_recordStatus = false;/*luxiang*/
        public IntPtr m_playhandle = IntPtr.Zero;/*播放句柄*/

        /*playBack use*/
        public int m_curVideoSliderValue = 0;
        public int m_maxVideoSliderValue = 0;
        public long m_startTime = 0;
        public long m_endTime = 0;
        public int m_playSpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD;
        public bool m_pauseStatus = true;/*暂停状态，默认暂停*/

        public bool m_trackStatus = false;/*巡航状态*/

        /*3D Position and Digital Zoom*/
        public int rectStartX = 0;
        public int rectStartY = 0;
        public int rectEndX = 0;
        public int rectEndY = 0;

        /*Two-way Audio*/
        public IntPtr m_talkHandle = IntPtr.Zero;

        public bool m_bShortDelayFlag = true;
        public bool m_bFluentFlag = false;
        public bool m_bDigitalZoomFlag = false;
        public bool m_bFirstZoomFlag = true;
        public bool m_3DPositionFlag = false;
        public bool m_twoWayAudioFlag = false;

        public int m_volume = 0;
        public bool m_soundStatus = false;
        public int m_micVolume = 0;
        public bool m_micStatus = false;

        public void initPlayPanel()
        {
            m_channelID = -1;
            m_deviceIndex = -1;
            m_playStatus = false;
            m_playhandle = IntPtr.Zero;
            m_recordStatus = false;

            m_curVideoSliderValue = 0;
            m_maxVideoSliderValue = 0;
            m_playSpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD; ;
            m_startTime = 0;
            m_endTime = 0;
            m_pauseStatus = true;

            //this.BackColor = Color.Black;
            //this.setBorderColor(Color.Red, 2);

            rectStartX = 0;
            rectStartY = 0;
            rectEndX = 0;
            rectEndY = 0;

            m_talkHandle = IntPtr.Zero;

            m_bShortDelayFlag = true;
            m_bFluentFlag = false;
            m_bDigitalZoomFlag = false;
            m_3DPositionFlag = false;
            m_twoWayAudioFlag = false;

            m_volume = 0;
            m_soundStatus = false;
            m_micVolume = 0;
            m_micStatus = false;

            //this.Invalidate();
        }
    }

    public class NETDEMO
    {
        public const int REAL_PANEL_MAX_SIZE = 16;//16
        public const int PLAYBACK_PANEL_MAX_SIZE = 4;

        public const int NETDEV_IPV4_LEN_MAX = 16;
        public const int NETDEV_USERNAME_LEN_260 = 260;
        public const int NETDEV_SERIAL_NUMBER_LEN_64 = 64;
        public const int NETDEV_MODEL_LEN_64 = 64;

        public const int NETDEMO_SMALL_IMAGE_SIZE = 1024 * 1024;
        public const int NETDEMO_FIND_FACE_LIB_MEM_COUNT = 6;
        public const int NETDEMO_FIND_VEHICLE_LIB_MEM_COUNT = 16;
        public const int NETDEMO_FIND_SMART_ALARM_RECORD_COUNT = 16;

        /*   Common length */
        public const int NETDEV_LEN_4 = 4;
        public const int NETDEV_LEN_8 = 8;
        public const int NETDEV_LEN_16 = 16;
        public const int NETDEV_LEN_32 = 32;
        public const int NETDEV_LEN_64 = 64;
        public const int NETDEV_LEN_128 = 128;
        public const int NETDEV_LEN_132 = 132;
        public const int NETDEV_LEN_260 = 260;

        public const int NETDEV_MAX_PRESET_NUM = 255; /*预置位总数*/

        /*TreeView图标索引*/
        public const int NETDEV_TREEVIEW_IMAGE_ROOT = 0;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON = 1;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF = 2;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON = 3;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF = 4;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON = 5;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF = 6;
        public const int NETDEV_TREEVIEW_IMAGE_ORG = 7;

        public const int NETDEMO_DOWNLOAD_TIME_COUNT = 5;/*如果下载一个视频超过5次时间进度都没有变化，说明下载出问题，用于下载回放时*/

        public static bool NETDEMO_DOWNLOAD_TIMER_MUX_FLAG = false;/*控制定时器多线程同步,默认为没有线程执行*/
        public static bool NETDEMO_DOWNLOAD_TIMER_STOP_ALL = false;/*停止下载*/

        //public static bool NETDEMO_SELECTED_CHANGED_FlAG = true;/*是否允许presetIDCobBox_SelectedIndexChanged事件触发*/

        public enum NETDEMO_FIND_TREE_NODE_TYPE_E
        {
            NETDEMO_FIND_TREE_NODE_CHN_ID = 0,         /* channel ID */
            NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID = 1,   /* sub device ID */
            NETDEMO_FIND_TREE_NODE_DEVICE_INDEX = 2,
            NETDEMO_FIND_TREE_NODE_ORG_ID = 3
        }

        public enum NETDEV_LOGIN_TYPE_E
        {
            NETDEV_NEW_LOGIN = 0,         /* new Login */
            NETDEV_AGAIN_LOGIN = 1          /* again Login */
        }

        public enum NETDEMO_MONITOR_TYPE_E
        {
            NETDEMO_MONITOR_SINGLE_SCREEN = 0,
            NETDEMO_MONITOR_ALL_SCREEN = 1
        }

        public enum NETDEMO_DEVICE_TYPE_E
        {
            NETDEMO_DEVICE_IPC_OR_NVR = 0,
            NETDEMO_DEVICE_VMS = 1,
            NETDEMO_DEVICE_INVALID = 0xff
        }

        public class NETDEMO_UPDATE_TIME_INFO
        {
            public IntPtr  lpHandle;
            public Int64 tBeginTime;
            public Int64 tEndTime;
            public Int64 tCurTime;
            public Int32 dwCount;
            public String strFileName;
            public String strFilePath;
            public bool downLoad_status;
        }

        /*用于视频流配置质量Quality*/
        public static NETDEV_VIDEO_QUALITY_E[] gastVideoQualityMap = 
        {
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L0,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L1, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L2, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L3, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L4, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L5, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L6, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L7, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L8, 
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L9
        };

        public enum NETDEV_EXCEPTION_TYPE_E
        {
            /* 回放业务异常上报  Playback exceptions report 300~399 */
            NETDEV_EXCEPTION_REPORT_VOD_END             = 300,          /* 回放结束  Playback ended*/
            NETDEV_EXCEPTION_REPORT_VOD_ABEND           = 301,          /* 回放异常  Playback exception occured */
            NETDEV_EXCEPTION_REPORT_BACKUP_END          = 302,          /* 备份结束  Backup ended */
            NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT     = 303,          /* 磁盘被拔出  Disk removed */
            NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL    = 304,          /* 磁盘已满  Disk full */
            NETDEV_EXCEPTION_REPORT_BACKUP_ABEND        = 305,          /* 其他原因导致备份失败   Backup failure caused by other reasons */

            NETDEV_EXCEPTION_EXCHANGE                   = 0x8000,       /* 用户交互时异常（用户保活超时）  Exception occurred during user interaction (keep-alive timeout) */

            NETDEV_EXCEPTION_REPORT_INVALID             = 0xFFFF        /* 无效值  Invalid value */
        }

        public enum NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E
        {
            NETDEMO_FIND_FACE_ALARM_RECORD_MATCH = 0,         /* Match Alarm Record */
            NETDEMO_FIND_FACE_ALARM_RECORD_PASS_THRU = 1,   /* Pass-Thru Record */
        }

        public enum NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E
        {
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_MATCH = 0,         /* Match Alarm Record */
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_PASS_THRU = 1,   /* Pass-Thru Record */
        }

        public struct NETDEMO_ALARM_INFO
        {
            public Int32 alarmType;
            public string reportAlarm;

            public NETDEMO_ALARM_INFO(int alarmTypeArg, string reportAlarmArg)
            {
                alarmType = alarmTypeArg;
                reportAlarm = reportAlarmArg;
            }
        }

        public static NETDEMO_ALARM_INFO[] gastNETDemoAlarmInfo = 
        {
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALRAM_CONFLAG_DETECT,"conflag detect alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT,"Motion detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT_RECOVER,"Motion detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST,"Video loss alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_TAMPER_DETECT,"Tampering detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_TAMPER_RECOVER,"Tampering detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_INPUT_SWITCH,"Boolean input alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_HIGH,"High temperature alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_LOW,"Low temperature alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_AUDIO_DETECT,"Audio detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_INPUT_SWITCH_RECOVER,"Boolean input alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST_RECOVER,"Video loss alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_REBOOT,"Device restart"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT,"Service restart"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_ONLINE,"Device online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_OFFLINE,"Device offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_CHL_ONLINE,"Channel online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_CHL_OFFLINE,"Channel offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_DELETE_CHL,"Delete channel"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_FAILED,"Network timeout"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SHAKE_FAILED,"Interaction error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_TIMEOUT,"Network error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_OFFLINE,"Disk offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ONLINE,"Disk online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MEDIA_CONFIG_CHANGE,"Media configuration changed"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REMAIN_ARTICLE,"Remain article"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_PEOPLE_GATHER,"People gather alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ENTER_AREA,"Enter area"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LEAVE_AREA,"Leave area"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ARTICLE_MOVE,"Article move"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ABNORMAL,"Disk abnormal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ABNORMAL_RECOVER,"Disk abnormal recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_WILL_FULL,"Disk storage will full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER,"Disk storage will full recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_IS_FULL,"Disk storage is full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER,"Disk storage is full recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DISABLED,"RAID disabled"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER,"RAID disabled recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DEGRADED,"RAID degraded"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER,"RAID degraded recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_RECOVERED,"RAID recovered"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STREAMNUM_FULL,"Stream full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STREAM_THIRDSTOP,"Third party stream stopped"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_FILE_END,"File ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RTMP_CONNECT_FAIL,"RTMP connection fail"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RTMP_INIT_FAIL,"RTMP initialization fail"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_ERR,"Storage error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_DISOBEY_PLAN,"Not stored as planned"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ERROR,"Disk error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ILLEGAL_ACCESS,"Illegal access"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ALLTIME_FLAG_END,"End marker of alarm without arming schedule"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST_RECOVER,"Video loss alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_RECOVER,"Temperature alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_AUDIO_DETECT_RECOVER,"Audio detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_ERR_RECOVER,"Storage error recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER,"Not stored as planned recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IMAGE_BLURRY_RECOVER,"Image blurry recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TRACK_RECOVER,"Smart track recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_VOD_END,"Playback ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_VOD_ABEND,"Playback exception occured"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_END,"Backup ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT,"Disk removed"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL,"Disk full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_ABEND,"Backup failure caused by other reasons"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_EXCHANGE,"Exception occurred during user interaction new NETDEMO_ALARM_INFO((int)keep-alive timeout)"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWIDTH_CHANGE,"Bandwidth change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LINE_CROSS,"Line cross"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_OBJECTS_INSIDE,"Objects inside"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_FACE_RECOGNIZE,"Face recognize"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IMAGE_BLURRY,"Image blurry"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SCENE_CHANGE,"Scene change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TRACK,"Smart track"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LOITERING_DETECTOR,"Loitering detector"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IP_CONFLICT,"IP conflict exception alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IP_CONFLICT_CLEARED,"IP conflict exception alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_READ_ERROR_RATE,"Error reding the underlying data"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWIDTH_CHANGE,"Bandwidth change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_OFF,"Network disconnection faults"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_RESUME_ON,"Network disconnection alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MATCH_LIST,"Face recognition matchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MATCH_LIST_RECOVER,"Face recognition matchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MISMATCH_LIST,"Face recognition mismatchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MISMATCH_LIST_RECOVER,"Face recognition mismatchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST,"Vehicle recognition matchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST_RECOVER,"Vehicle recognition matchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST,"Vehicle recognition mismatchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST_RECOVER,"Vehicle recognition mismatchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SERVER_FAULT,"Server fault"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SERVER_NORMAL,"Server recovered"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_ERROR,"SysDisk abnormal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_ONLINE,"SysDisk online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_OFFLINE,"SysDisk offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_STORAGE_IS_FULL,"System storage is full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_RAID_DEGRADED,"SysRAID disabled"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_RAID_DISABLED,"SysRAID degraded"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_GO_FULL,"Equipment storage go full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_STOR_GO_FULL,"System storage go full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ARRAY_NORMAL,"Device array normal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_ARRAY_NORMAL,"Array system normal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_STOR_ERR,"System storage error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWITH_CHANGE,"Device export bandwidth changes"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEOENCODER_CHANGE,"Device videoencoder configuration changes"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_ILLEGAL_ACCESS,"System illegal access"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SPIN_UP_TIME,"Rotation time of spindle"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_START_STOP_COUNT,"Start and stop counting"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_REALLOCATED_SECTOR_COUNT,"Remap sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SEEK_ERROR_RATE,"Trace error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWER_ON_HOURS,"Current time accumulated"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SPIN_RETRY_COUNT,"The spindle rotating retries"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_CALIBRATION_RETRY_COUNT,"Head alignment retry count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWER_CYCLE_COUNT,"Current cycle count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWEROFF_RETRACT_COUNT,"Power back to count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_LOAD_CYCLE_COUNT,"Head load count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TEMPERATURE_CELSIUS,"Temperature celsius"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_REALLOCATED_EVENT_COUNT,"Mapping the counting"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_CURRENT_PENDING_SECTOR,"The current mapping sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_OFFLINE_UNCORRECTABLE,"Offline can't correction sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_UDMA_CRC_ERROR_COUNT,"Parity error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_MULTI_ZONE_ERROR_RATE,"Many regional error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RESOLUTION_CHANGE,"The resolution of the change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MANUAL,"Manual alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ALARMHOST_COMMON,"Emergency alarm events"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DOORHOST_COMMON,"Access the event")
        };

        public struct NETDEMO_PLATE_TYPE
        {
            public Int32 dwPlateType;
            public string strPlateType;

            public NETDEMO_PLATE_TYPE(int dwPlateTypeArg, string strPlateTypeArg)
            {
                dwPlateType = dwPlateTypeArg;
                strPlateType = strPlateTypeArg;
            }
        } 

        public static NETDEMO_PLATE_TYPE[] gastNETDemoPlateType = 
        {
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_BIG_CAR_E,"Large Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_MINI_CAR_E,"Small Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_EMBASSY_CAR_E,"Embassy Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_CONSULATE_CAR_E,"Consulate Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OVERSEAS_CAR_E,"Overseas Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_FOREIGN_CAR_E,"Foreign Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COMMON_MOTORBIKE_E,"Common Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_HANDINESS_MOTORBIKE_E,"Light Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_EMBASSY_MOTORBIKE_E,"Embassy Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_CONSULATE_MOTORBIKE_E,"Consulate Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OVERSEAS_MOTORBIKE_E,"Overseas Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_FOREIGN_MOTORBIKE_E,"Foreign Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_LOW_SPEED_CAR_E,"Low Speed Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TRACTOR_E,"Tractor Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TRAILER_E,"Trailer Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COACH_CAR_E,"Coach Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COACH_MOTORBIKE_E,"Coach Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_CAR_E,"Temporary Entry Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_MOTORBIKE_E,"Temporary Entry Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_DRIVING_E,"Temporary Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_POLICE_CAR_E,"Police Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_POLICE_MOTORBIKE_E,"Police Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_HONGKONG_ENTRY_EXIT_E,"Border Crossing Vehicle (Hong Kong) Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_MACAO_ENTRY_EXIT_E,"Border Crossing Vehicle (Macau) Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_ARMED_POLICE_E,"Armed Police Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_ARMY_E,"Military Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OTHER_E,"Other")
        };

        public struct NETDEMO_PLATE_COLOR
        {
            public Int32 dwPlateColor;
            public string strPlateColor;

            public NETDEMO_PLATE_COLOR(int dwPlateColorArg, string strPlateColorArg)
            {
                dwPlateColor = dwPlateColorArg;
                strPlateColor = strPlateColorArg;
            }
        }

        public static NETDEMO_PLATE_COLOR[] gastNETDemoPlateColor = 
        {
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BLACK_E,"Black"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_WHITE_E,"White"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GRAY_E,"Gray"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_RED_E,"Red"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BLUE_E,"Blue"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_YELLOW_E,"Yellow"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_ORANGE_E,"Orange"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BROWN_E,"Brown"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GREEN_E,"Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_PURPLE_E,"Purple"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_CYAN_E,"Cyan"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_PINK_E,"Pink"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_TRANSPARENT_E,"Transparent"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_SILVERYWHITE_E,"Silvery White"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_DARK_E,"Dark"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_LIGHT_E,"Light"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_COLOURLESS,"No Color"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_YELLOWGREEN,"Yellow&Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GRADUALGREEN,"Gradated Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_OTHER_E,"Other")
        };

        public static NETDEV_DEVICE_MAIN_TYPE_E[] gaENETDemoVMSMainDevType = 
        {
            NETDEV_DEVICE_MAIN_TYPE_E.NETDEV_DTYPE_MAIN_ENCODE,
            NETDEV_DEVICE_MAIN_TYPE_E.NETDEV_DTYPE_MAIN_BAYONET
        };
    }

    /*循环监视信息*/
    public class CycleMonitorInfo
    {
        /*单个监视对象信息*/
        public struct CYCLE_MONITOR_CHANNEL_INFO_S
        {
            public int deviceIndex;
            public IntPtr devhandle;
            public int channelID;/*1 ~ &*/
        }

        public NETDEMO.NETDEMO_MONITOR_TYPE_E monitorType = NETDEMO.NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN;
        public int panelNo = 0; /*0 ~ 15*/
        public int monitorCount = 0;
        public int intervalTime = 20;/*秒*/
        public List<CYCLE_MONITOR_CHANNEL_INFO_S> channelInfoList = new List<CYCLE_MONITOR_CHANNEL_INFO_S>();
    }

    public class PlayBackInfo
    {
        public IntPtr m_devHandle = IntPtr.Zero;
        public List<NETDEV_FINDDATA_S> m_findPlayBackDataList = new List<NETDEV_FINDDATA_S>();
        public int m_curSelectedChannelID = -1;
        public int m_curSelectedDeviceIndex = -1;
        public int m_nextPlayBackPanelIndex = 0;

        public System.Timers.Timer m_timer = new System.Timers.Timer(500);//初始化为100毫秒
    }

     public struct NETDEMO_BASIC_INFO_S
    {
         public bool existFlag;
        public NETDEV_TIME_CFG_S stSystemTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public String szDeviceName;
        public NETDEV_DISK_INFO_LIST_S stDiskInfoList;
    }

     public struct NETDEMO_NETWORK_INFO_S
     {
         public bool existFlag;
         public NETDEV_NETWORKCFG_S stNetWorkIP;
         public NETDEV_UPNP_NAT_STATE_S stNetWorkPort;
         public NETDEV_SYSTEM_NTP_INFO_S stNetWorkNTP;
     }

    public struct NETDEMO_INPUT_INFO_S
    {
        public bool existFlag;
        public NETDEV_ALARM_INPUT_LIST_S stInPutInfo;
        public NETDEV_ALARM_OUTPUT_LIST_S stOutPutInfo;
    }

    public struct NETDEMO_VIDEO_STREAM_INFO_S
    {
        public bool existFlag;
        public NETDEV_VIDEO_STREAM_INFO_S[] videoStreamInfoList;
    }

    public struct NETDEMO_IMAGE_INFO_S
    {
        public bool existFlag;
        public NETDEV_IMAGE_SETTING_S imageInfo;
    }

    public struct NETDEMO_VIDEO_OSD_S
    {
        public bool existFlag;
        public NETDEV_VIDEO_OSD_CFG_S OSDInfo;
    }

    public struct NETDEMO_PRIVACY_MASK_INFO_S
    {
        public bool existFlag;
        public NETDEV_PRIVACY_MASK_CFG_S privacyMaskInfo;
    }

    public struct NETDEMO_MOTION_ALARM_INFO_S
    {
        public bool existFlag;
        public NETDEV_MOTION_ALARM_INFO_S MotionAlarmInfo;
    }

    public struct NETDEMO_TAMPER_ALARM_INFO_S
    {
        public bool existFlag;
        public NETDEV_TAMPER_ALARM_INFO_S tamperAlarmInfo;
    }

    public class ChannelInfo
    {
        public NETDEV_VIDEO_CHL_DETAIL_INFO_S m_devVideoChlInfo = new NETDEV_VIDEO_CHL_DETAIL_INFO_S();
        public NETDEV_CRUISE_LIST_S m_CruiseInfoList;
        public NETDEMO_BASIC_INFO_S m_basicInfo;
        public NETDEMO_NETWORK_INFO_S m_networkInfo;
        public NETDEMO_VIDEO_STREAM_INFO_S m_videoStreamInfo;
        public NETDEMO_IMAGE_INFO_S m_imageInfo;
        public NETDEMO_VIDEO_OSD_S m_OSDInfo;
        public NETDEMO_INPUT_INFO_S m_IOInfo;
        public NETDEMO_PRIVACY_MASK_INFO_S m_privacyMaskInfo;
        public NETDEMO_MOTION_ALARM_INFO_S m_MotionAlarmInfo;
        public NETDEMO_TAMPER_ALARM_INFO_S m_tamperAlarmInfo;

        public ChannelInfo()
        {
            /**/
            m_CruiseInfoList = new NETDEV_CRUISE_LIST_S();
            m_CruiseInfoList.astCruiseInfo = new NETDEV_CRUISE_INFO_S[NETDEVSDK.NETDEV_MAX_CRUISEROUTE_NUM];
            for (int i = 0; i < m_CruiseInfoList.astCruiseInfo.Length; i++)
            {
                m_CruiseInfoList.astCruiseInfo[i].astCruisePoint = new NETDEV_CRUISE_POINT_S[NETDEVSDK.NETDEV_MAX_CRUISEPOINT_NUM];
            }

            m_basicInfo = new NETDEMO_BASIC_INFO_S();
            m_basicInfo.existFlag = false;

            m_networkInfo = new NETDEMO_NETWORK_INFO_S();
            m_networkInfo.existFlag = false;
            m_networkInfo.stNetWorkPort.astUpnpPort = new NETDEV_UPNP_PORT_STATE_S[NETDEVSDK.NETDEV_LEN_16];

            m_videoStreamInfo = new NETDEMO_VIDEO_STREAM_INFO_S();
            m_videoStreamInfo.videoStreamInfoList = new NETDEV_VIDEO_STREAM_INFO_S[3];
            m_videoStreamInfo.existFlag = false;

            m_imageInfo = new NETDEMO_IMAGE_INFO_S();
            m_imageInfo.existFlag = false;

            m_OSDInfo = new NETDEMO_VIDEO_OSD_S();
            m_OSDInfo.existFlag = false;
            m_OSDInfo.OSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[NETDEVSDK.NETDEV_OSD_TEXTOVERLAY_NUM];

            m_IOInfo = new NETDEMO_INPUT_INFO_S();
            m_IOInfo.existFlag = false;
            m_IOInfo.stInPutInfo.astAlarmInputInfo = new NETDEV_ALARM_INPUT_INFO_S[NETDEVSDK.NETDEV_MAX_ALARM_IN_NUM];

            m_privacyMaskInfo = new NETDEMO_PRIVACY_MASK_INFO_S();
            m_privacyMaskInfo.existFlag = false;
            m_privacyMaskInfo.privacyMaskInfo.astArea = new NETDEV_PRIVACY_MASK_AREA_INFO_S[NETDEVSDK.NETDEV_MAX_PRIVACY_MASK_AREA_NUM];

            m_MotionAlarmInfo = new NETDEMO_MOTION_ALARM_INFO_S();
            m_MotionAlarmInfo.existFlag = false;
            m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo = new Int16Array[NETDEVSDK.NETDEV_SCREEN_INFO_ROW];
            for (int i = 0; i < NETDEVSDK.NETDEV_SCREEN_INFO_ROW; i++)
            {
                m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo[i].data = new short[NETDEVSDK.NETDEV_SCREEN_INFO_COLUMN];
            }

            m_tamperAlarmInfo = new NETDEMO_TAMPER_ALARM_INFO_S();
            m_tamperAlarmInfo.existFlag = false;
        }
    }

    public class RealPlayInfo
    {
        public Int32 m_channel = -1;
        public Int32 m_panelIndex = -1;
    }

    public class TreeNodeInfo
    {
        public int dwOrgID = -1;
        public int dwDeviceIndex = -1;
        public int dwSubDeviceID = -1;
        public int dwChannelID = -1;
    }

    public class NETDEMO_VMS_DEV_CHANNEL_INFO_S
    {
        public NETDEV_DEV_CHN_ENCODE_INFO_S stChnInfo;
        public NETDEV_CRUISE_LIST_S stCruiseList; /* 通道的预置位巡航路径信息 */
        public NETDEMO_IMAGE_INFO_S m_imageInfo;

        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
    }

    public class NETDEMO_VMS_DEV_BASIC_INFO_S
    {
        public NETDEV_DEV_BASIC_INFO_S stDevBasicInfo;
        public List<NETDEMO_VMS_DEV_CHANNEL_INFO_S> stChnInfoList = new List<NETDEMO_VMS_DEV_CHANNEL_INFO_S>();
    }

    public class NETDEMO_VMS_ORG_INFO_S
    {
        public NETDEV_ORG_INFO_S stOrgInfo;
        public List<NETDEMO_VMS_DEV_BASIC_INFO_S> stVmsDevBasicInfoList = new List<NETDEMO_VMS_DEV_BASIC_INFO_S>();
    }

    public class NETDEMO_VMS_DEVICE_INFO_S
    {
        public NETDEV_TIME_CFG_S stSystemTime;
        public List<NETDEMO_VMS_ORG_INFO_S> stOrgInfoList = new List<NETDEMO_VMS_ORG_INFO_S>();
    }

    public class DeviceInfo
    {
        public NETDEMO.NETDEMO_DEVICE_TYPE_E m_eDeviceType = NETDEMO.NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR;
        
        //本地设备信息
        public String m_ip = null;
        public Int32 m_port = 0;
        public String m_userName = null;
        public String m_password = null;

        /* VMS */
        public NETDEMO_VMS_DEVICE_INFO_S stVmsDevInfo;

        /*共用信息*/
        public IntPtr m_lpDevHandle = IntPtr.Zero;
        public Int32 m_channelNumber = 0;
        public NETDEV_DEVICE_INFO_S m_stDevInfo;//设备信息，用于登录出参

        /* IPC/NVR */
        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
        public Int32 m_dwSubFaceRecogAlarmID = -1;
        public Int32 m_dwSubVehicleRecogAlarmID = -1;

        public List<ChannelInfo> m_channelInfoList = new List<ChannelInfo>();

        //public List<NETDEV_VIDEO_CHL_DETAIL_INFO_S> m_devVideoChlInfoList = new List<NETDEV_VIDEO_CHL_DETAIL_INFO_S>();
        //public List<>  = new List<NETDEV_CRUISE_LIST_S>();

        static readonly object m_RealPlayInfolocker = new object();
        public List<RealPlayInfo> m_RealPlayInfoList = new List<RealPlayInfo>();

        public void addRealPlayInfo(RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        return;
                    }
                }
                m_RealPlayInfoList.Add(objRealPlayInfo);
            }
        }

        public void removeRealPlayInfo(RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        m_RealPlayInfoList.RemoveAt(i);
                    }
                }
            }
        }

        public void initDeviceInfo()
        {
            /*共用信息*/
            m_lpDevHandle = IntPtr.Zero;
            m_channelNumber = 0;
            stVmsDevInfo = null;
            m_channelInfoList.Clear();
            
            m_dwSubFaceStructAlarmID = -1;
            m_dwSubVehicleStructAlarmID = -1;

            m_dwSubFaceRecogAlarmID = -1;
            m_dwSubVehicleRecogAlarmID = -1;
        }
    }
}