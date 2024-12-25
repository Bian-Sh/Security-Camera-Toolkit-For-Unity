using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using GeneralDef;

namespace NETSDKHelper
{

    /* define enum start */
    public enum NETDEV_CHANNEL_STATUS_E
    {
        NETDEV_CHL_STATUS_OFFLINE   = 0,       /* Channel offline */
        NETDEV_CHL_STATUS_ONLINE    = 1,       /* Channel online */
        NETDEV_CHL_STATUS_UNBIND    = 2,       /* Channel unbind */

        NETDEV_CHL_STATUS_INVALID
    }

    public enum NETDEV_DEVICETYPE_E
    {
        NETDEV_DTYPE_UNKNOWN = 0,                   /* Unknown type */
        NETDEV_DTYPE_IPC = 1,                       /* IPC range */
        NETDEV_DTYPE_IPC_FISHEYE = 2,               /* Fisheye IPC*/
        NETDEV_DTYPE_IPC_ECONOMIC_FISHEYE = 3,      /* Economic fisheye IPC */
        NETDEV_DTYPE_NVR = 101,                     /* NVR range */
        NETDEV_DTYPE_NVR_BACKUP = 102,              /* NVR back up */
        NETDEV_DTYPE_HNVR = 103,                    /* Mixture NVR */
        NETDEV_DTYPE_DC = 201,                      /* DC range */
        NETDEV_DTYPE_DC_ADU = 202,                  /* ADU range */
        NETDEV_DTYPE_EC = 301,                      /* EC range */
        NETDEV_DTYPE_VMS = 501,                     /* VMS range */

        NETDEV_DTYPE_INVALID = 0xFFFF               /* Invalid value */
    }

    public enum NETDEV_LIVE_STREAM_INDEX_E
    {
        NETDEV_LIVE_STREAM_INDEX_MAIN  = 0,   /* Main stream */
        NETDEV_LIVE_STREAM_INDEX_AUX   = 1,   /* Sub stream */
        NETDEV_LIVE_STREAM_INDEX_THIRD = 2,   /* Third stream */

        NETDEV_LIVE_STREAM_INDEX_INVALID
    }

    public enum NETDEV_PROTOCAL_E
    {
        NETDEV_TRANSPROTOCAL_RTPUDP = 0,         /* UDP */
        NETDEV_TRANSPROTOCAL_RTPTCP = 1          /* TCP */
    }

    public enum NETDEV_PICTURE_FLUENCY_E
    {
        NETDEV_PICTURE_REAL                 = 0,                /* Real-time first */
        NETDEV_PICTURE_FLUENCY              = 1,                /* Fluency first */
        NETDEV_PICTURE_BALANCE_NEW          = 3,                /* Balance */
        NETDEV_PICTURE_RTMP_FLUENCY         = 4,                /* RTMP fluency first */

        NETDEV_PICTURE_FLUENCY_INVALID      = 0xff              /* Invalid value */
    }

    public enum NETDEV_PTZ_E
    {
        NETDEV_PTZ_FOCUSNEAR_STOP       =0x0201,       /* Focus near stop */
        NETDEV_PTZ_FOCUSNEAR            =0x0202,       /* Focus near */
        NETDEV_PTZ_FOCUSFAR_STOP        =0x0203,       /* Focus far stop */
        NETDEV_PTZ_FOCUSFAR             =0x0204,       /* Focus far */

        NETDEV_PTZ_ZOOMTELE_STOP        = 0x0301,       /* Zoom in stop */
        NETDEV_PTZ_ZOOMTELE             = 0x0302,       /* Zoom in */
        NETDEV_PTZ_ZOOMWIDE_STOP        = 0x0303,       /* Zoom out stop */
        NETDEV_PTZ_ZOOMWIDE             = 0x0304,       /* Zoom out */
        NETDEV_PTZ_TILTUP               = 0x0402,       /* Tilt up */
        NETDEV_PTZ_TILTDOWN             = 0x0404,       /* Tilt down */
        NETDEV_PTZ_PANRIGHT             = 0x0502,       /* Pan right */
        NETDEV_PTZ_PANLEFT              = 0x0504,       /* Pan left */
        NETDEV_PTZ_LEFTUP               = 0x0702,       /* Move up left */
        NETDEV_PTZ_LEFTDOWN             = 0x0704,       /* Move down left */
        NETDEV_PTZ_RIGHTUP              = 0x0802,       /* Move up right */
        NETDEV_PTZ_RIGHTDOWN            = 0x0804,       /* Move down right */

        NETDEV_PTZ_ALLSTOP              = 0x0901,       /* All-stop command word */
        NETDEV_PTZ_FOCUS_AND_IRIS_STOP  = 0x0907,       /* Focus & Iris-stop command word */
        NETDEV_PTZ_MOVE_STOP            = 0x0908,       /* move stop command word */
        NETDEV_PTZ_ZOOM_STOP            = 0x0909,       /* zoom stop command word */

        NETDEV_PTZ_TRACKCRUISE          = 0x1001,       /* Start route patrol*/
        NETDEV_PTZ_TRACKCRUISESTOP      = 0x1002,       /* Stop route patrol*/
        NETDEV_PTZ_TRACKCRUISEREC       = 0x1003,       /* Start recording route */
        NETDEV_PTZ_TRACKCRUISERECSTOP   = 0x1004,       /* Stop recording route */
        NETDEV_PTZ_TRACKCRUISEADD       = 0x1005,       /* Add patrol route */
        NETDEV_PTZ_TRACKCRUISEDEL       = 0x1006,       /* Delete patrol route */

        NETDEV_PTZ_AREAZOOMIN           = 0x1101,       /* Zoom in area */
        NETDEV_PTZ_AREAZOOMOUT          = 0x1102,       /* Zoom out area */
        NETDEV_PTZ_AREAZOOM3D           = 0x1103,       /* 3D positioning */

        NETDEV_PTZ_BRUSHON              = 0x0A01,       /* Wiper on */
        NETDEV_PTZ_BRUSHOFF             = 0x0A02,       /* Wiper off */

        NETDEV_PTZ_LIGHTON              = 0x0B01,       /* Lamp on */
        NETDEV_PTZ_LIGHTOFF             = 0x0B02,       /* Lamp off */

        NETDEV_PTZ_HEATON               = 0x0C01,       /* Heater on */
        NETDEV_PTZ_HEATOFF              = 0x0C02,       /* Heater off */

        NETDEV_PTZ_SNOWREMOINGON        = 0x01301,       /* Snowremoval on */
        NETDEV_PTZ_SNOWREMOINGOFF       = 0x01302,       /* Snowremoval off  */

        NETDEV_PTZ_INVALID

    }

    public enum NETDEV_PICTURE_FORMAT_E
    {
        NETDEV_PICTURE_BMP = 0,                  /* bmp */
        NETDEV_PICTURE_JPG = 1,                  /* jpg */

        NETDEV_PICTURE_INVALID
    }

    public enum NETDEV_MEDIA_FILE_FORMAT_E
    {
        NETDEV_MEDIA_FILE_MP4                    = 0,    /* MP4(+)  mp4 media file (Audio + Video) */
        NETDEV_MEDIA_FILE_TS                     = 1,    /* TS(+)   TS media file (Audio + Video) */
        NETDEV_MEDIA_FILE_MP4_ADD_TIME           = 2,    /* MP4(+) ,  MP4 media file with time in file name (Audio + Video) */
        NETDEV_MEDIA_FILE_TS_ADD_TIME            = 3,    /* TS(+) ,  TS media file with time in file name (Audio + Video) */
        NETDEV_MEDIA_FILE_AUDIO_TS               = 4,    /* TS()   TS audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_MP4              = 5,    /* MP4()   MP4 audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_TS_ADD_TIME      = 6,    /* TS(),  TS audio file with time in file name (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_MP4_ADD_TIME     = 7,    /* MP4(),  MP4 audio file with time in file name (Only audio) */
        NETDEV_MEDIA_FILE_MP4_ADD_RCD_TIME       = 8,    /* MP4 media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_TS_ADD_RCD_TIME        = 9,    /* TS media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_MP4_ADD_RCD_TIME = 10,   /* MP4 audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_AUDIO_TS_ADD_RCD_TIME  = 11,   /* TS audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_VIDEO_MP4_ADD_RCD_TIME = 12,   /* mp4 media file (Only video) */
        NETDEV_MEDIA_FILE_VIDEO_TS_ADD_RCD_TIME  = 13,   /* ts media file (Only video) */

        NETDEV_MEDIA_FILE_AVI                    = 14,   /* AVI media file (Audio + Video) */
        NETDEV_MEDIA_FILE_AVI_ADD_TIME           = 15,   /* AVI media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_AVI              = 16,   /* AVI audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_AVI_ADD_TIME     = 17,   /* AVI audio file with time in file name (Only audio)*/
        NETDEV_MEDIA_FILE_AVI_ADD_RCD_TIME       = 18,   /* AVI audio file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_AVI_ADD_RCD_TIME = 19,   /* AVI audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_VIDEO_AVI_ADD_RCD_TIME = 20,   /* AVI media file (Only video) */

        NETDEV_MEDIA_FILE_INVALID
    }

    public enum NETDEV_PLAN_STORE_TYPE_E
    {
        NETDEV_TYPE_STORE_TYPE_ALL                  = 0,            /* All */

        NETDEV_EVENT_STORE_TYPE_MOTIONDETECTION     = 4,            /* Motion detection */
        NETDEV_EVENT_STORE_TYPE_DIGITALINPUT        = 5,            /* Digital input */
        NETDEV_EVENT_STORE_TYPE_VIDEOLOSS           = 7,            /* Video loss */

        NETDEV_TYPE_STORE_TYPE_INVALID              = 0xFF          /* Invalid value */
    }

    public enum NETDEV_RECORD_LOCATION_E
    {
        NETDEV_RECORD_LOCATION_ALL = 0,                /* 存储位置：所有 */
        NETDEV_RECORD_LOCATION_VMS = 1,                /* 存储位置：VMS */
        NETDEV_RECORD_LOCATION_NVR = 2,                /* 存储位置：NVR */
        NETDEV_RECORD_LOCATION_BACKUP = 3,                /* 存储位置：备份 */

        NETDEV_RECORD_LOCATION_INVALID = 0xFF              /* 无效值 */
    }

    public enum NETDEV_HDD_SMART_ASSESSMENT_STATUS_E
    {
        NETDEV_HDD_SMART_ASSESSMENT_STATUS_NORMAL = 0,          /* 良好 */
        NETDEV_HDD_SMART_ASSESSMENT_STATUS_WARNING = 1,         /* 警告 */
        NETDEV_HDD_SMART_ASSESSMENT_STATUS_FAULT = 2,           /* 故障 */

        NETDEV_HDD_SMART_ASSESSMENT_STATUS_INVALID = 0xFF       /* Invalid value */
    }

    public enum NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_E
    {
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_NORMAL = 0,         /* 健康状态良好 */
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_PART_DAMAGE = 1,    /* 存在坏扇区 */
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_FAULT = 2,          /* 故障 */

        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_INVALID = 0xFF      /* Invalid value */
    }

    public enum NETDEV_HDD_TYPE_E
    {
        NETDEV_HDD_TYPE_LOCAL_HDD = 0,          /* LocalHDD */
        NETDEV_HDD_TYPE_NO1_EXTEND_HDD = 1,     /* No1ExtendCabinetHDD */
        NETDEV_HDD_TYPE_NO2_EXTEND_HDD = 2,     /* No2ExtendCabinetHDD */

        NETDEV_HDD_TYPE_INVALID = 0xFF          /* Invalid value */
    }

    public enum NETDEV_HDD_STATUS_E
    {
        NETDEV_HDD_STATUS_NO = 0,               /* 无硬盘 */
        NETDEV_HDD_STATUS_NORMAL = 1,           /* 正常 */
        NETDEV_HDD_STATUS_ABNORMAL = 2,         /* 异常 */

        NETDEV_HDD_STATUS_INVALID = 0xFF        /* Invalid value */
    }
    public enum NETDEV_ADDR_TYPE_E
    {
        NETDEV_ADDR_TYPE_IPV4 = 0,              /* IPV4 */
        NETDEV_ADDR_TYPE_IPV6 = 1,              /* IPV6 */
        NETDEV_ADDR_TYPE_DOMAIN = 2,            /* 域名 */
        NETDEV_ADDR_TYPE_IPV4_IPV6 = 3,         /* IPV4和IPV6都需要 */
        NETDEV_ADDR_TYPE_INVALID = 0XFFFF       /* 无效值 */
    }
    public enum NETDEV_STORAGE_CONTAINER_USAGE_TYPE_E
    {
        NETDEV_STORAGE_CONTAINER_USAGE_TYPE_RECORD_CAPTURE = 0,         /* 录像/抓图 */
        NETDEV_STORAGE_CONTAINER_USAGE_TYPE_BACKUP = 1,                 /* 备份 */

        NETDEV_STORAGE_CONTAINER_USAGE_TYPE_INVALID = 0xFF              /* Invalid value */
    }
    public enum NETDEV_STORAGE_CONTAINER_STATUS_E
    {
        NETDEV_STORAGE_CONTAINER_STATUS_NO = 0,                 /* 无硬盘/空闲 */
        NETDEV_STORAGE_CONTAINER_STATUS_UNFORMATTED = 1,        /* 未格式化 */
        NETDEV_STORAGE_CONTAINER_STATUS_FORMATTING = 2,         /* 正在格式化 */
        NETDEV_STORAGE_CONTAINER_STATUS_NORMAL = 3,             /* 硬盘状态良好 */
        NETDEV_STORAGE_CONTAINER_STATUS_SLEEP = 4,              /* 休眠 */
        NETDEV_STORAGE_CONTAINER_STATUS_ABNORMAL = 5,           /* 异常 */
        NETDEV_STORAGE_CONTAINER_STATUS_SWITCH = 6,             /* 切换中 */
        NETDEV_STORAGE_CONTAINER_STATUS_UNINSTALLED = 7,        /* 已卸载 */

        NETDEV_STORAGE_CONTAINER_STATUS_INVALID = 0xFF          /* Invalid value */

    }
    public enum NETDEV_STORAGE_CONTAINER_PROPERTY_E
    {
        NETDEV_STORAGE_CONTAINER_PROPERTY_RW = 0,               /* 读写 */
        NETDEV_STORAGE_CONTAINER_PROPERTY_R = 1,                /* 只读 */
        NETDEV_STORAGE_CONTAINER_PROPERTY_REDUNDANT = 2,        /* 冗余 */

        NETDEV_STORAGE_CONTAINER_PROPERTY_INVALID = 0xFF        /* Invalid value */
    }
    public enum NETDEV_HDD_WORK_MODE_E
    {
        NETDEV_HDD_WORK_MODE_COMMON = 0,            /* 普通盘 */
        NETDEV_HDD_WORK_MODE_RAID = 1,              /* 阵列盘 */
        NETDEV_HDD_WORK_MODE_HOT_BACKUP = 2,        /* 热备盘 */

        NETDEV_HDD_WORK_MODE_INVALID = 0xFF         /* Invalid value */
    }
    public enum NETDEV_HDD_SMART_CHECK_STATUS_E
    {
        NETDEV_HDD_SMART_CHECK_STATUS_NOT = 0,              /* 未检测 */
        NETDEV_HDD_SMART_CHECK_STATUS_IN_PORGRESS = 1,      /* 正在自检 */
        NETDEV_HDD_SMART_CHECK_STATUS_SUCCESS = 2,          /* 自检成功 */
        NETDEV_HDD_SMART_CHECK_STATUS_RECOGNITION_FAIL = 3, /* 硬盘识别失败 */
        NETDEV_HDD_SMART_CHECK_STATUS_FAIL = 4,             /* SMART自检失败 */
        NETDEV_HDD_SMART_CHECK_STATUS_NOT_SUPPORT = 5,      /* 硬盘不支持检测 */

        NETDEV_HDD_SMART_CHECK_STATUS_INVALID = 0xFF        /* Invalid value */
    }

    public enum NETDEV_HDD_SMART_CHECK_TYPE_E
    {
        NETDEV_HDD_SMART_CHECK_TYPE_BRIEF = 0,          /* 简短型 */
        NETDEV_HDD_SMART_CHECK_TYPE_EXTEND = 1,         /* 扩展型 */
        NETDEV_HDD_SMART_CHECK_TYPE_TRANSMISSION = 2,   /* 传输型 */

        NETDEV_HDD_SMART_CHECK_TYPE_INVALID = 0xFF      /* Invalid value */
    }

    public enum NETDEV_E_DOWNLOAD_SPEED_E
    {
        NETDEV_DOWNLOAD_SPEED_ONE           = 0,                /* 1x */
        NETDEV_DOWNLOAD_SPEED_TWO           = 1,                /* 2x */
        NETDEV_DOWNLOAD_SPEED_FOUR          = 2,                /* 4x */
        NETDEV_DOWNLOAD_SPEED_EIGHT         = 3,                /* 8x */
        NETDEV_DOWNLOAD_SPEED_TWO_IFRAME    = 4,                /* I  I2x */
        NETDEV_DOWNLOAD_SPEED_FOUR_IFRAME   = 5,                /* I  I4x */
        NETDEV_DOWNLOAD_SPEED_EIGHT_IFRAME  = 6,                /* I  I8x */
        NETDEV_DOWNLOAD_SPEED_HALF          = 7                 /* 1/2  1/2x */
    }

    public enum NETDEV_VOD_PLAY_STATUS_E
    {
        /**   Play status */
        NETDEV_PLAY_STATUS_16_BACKWARD          = 0,            /* 16  Backward at 16x speed */
        NETDEV_PLAY_STATUS_8_BACKWARD           = 1,            /* 8  Backward at 8x speed */
        NETDEV_PLAY_STATUS_4_BACKWARD           = 2,            /* 4  Backward at 4x speed */
        NETDEV_PLAY_STATUS_2_BACKWARD           = 3,            /* 2  Backward at 2x speed */
        NETDEV_PLAY_STATUS_1_BACKWARD           = 4,            /* Backward at normal speed */
        NETDEV_PLAY_STATUS_HALF_BACKWARD        = 5,            /* 1/2  Backward at 1/2 speed */
        NETDEV_PLAY_STATUS_QUARTER_BACKWARD     = 6,            /* 1/4  Backward at 1/4 speed */
        NETDEV_PLAY_STATUS_QUARTER_FORWARD      = 7,            /* 1/4  Play at 1/4 speed */
        NETDEV_PLAY_STATUS_HALF_FORWARD         = 8,            /* 1/2  Play at 1/2 speed */
        NETDEV_PLAY_STATUS_1_FORWARD            = 9,            /* Forward at normal speed */
        NETDEV_PLAY_STATUS_2_FORWARD            = 10,           /* 2  Forward at 2x speed */
        NETDEV_PLAY_STATUS_4_FORWARD            = 11,           /* 4  Forward at 4x speed */
        NETDEV_PLAY_STATUS_8_FORWARD            = 12,           /* 8  Forward at 8x speed */
        NETDEV_PLAY_STATUS_16_FORWARD           = 13,           /* 16  Forward at 16x speed */
        NETDEV_PLAY_STATUS_2_FORWARD_IFRAME     = 14,           /* 2(I) Forward at 2x speed(I frame) */
        NETDEV_PLAY_STATUS_4_FORWARD_IFRAME     = 15,           /* 4(I) Forward at 4x speed(I frame) */
        NETDEV_PLAY_STATUS_8_FORWARD_IFRAME     = 16,           /* 8(I) Forward at 8x speed(I frame) */
        NETDEV_PLAY_STATUS_16_FORWARD_IFRAME    = 17,           /* 16(I) Forward at 16x speed(I frame) */
        NETDEV_PLAY_STATUS_2_BACKWARD_IFRAME    = 18,           /* 2(I) Backward at 2x speed(I frame) */
        NETDEV_PLAY_STATUS_4_BACKWARD_IFRAME    = 19,           /* 4(I) Backward at 4x speed(I frame) */
        NETDEV_PLAY_STATUS_8_BACKWARD_IFRAME    = 20,           /* 8(I) Backward at 8x speed(I frame) */
        NETDEV_PLAY_STATUS_16_BACKWARD_IFRAME   = 21,           /* 16(I) Backward at 16x speed(I frame) */
        NETDEV_PLAY_STATUS_INTELLIGENT_FORWARD  = 22,           /* Intelligent forward */
        NETDEV_PLAY_STATUS_1_FRAME_FORWD        = 23,           /* Forward at 1 frame speed */
        NETDEV_PLAY_STATUS_1_FRAME_BACK         = 24,           /* Backward at 1 frame speed */
        NETDEV_PLAY_STATUS_40_FORWARD           = 25,           /* Forward at 40x speed*/

        NETDEV_PLAY_STATUS_32_FORWARD_IFRAME    = 26,           /* Forward at 32x speed(I frame)*/
        NETDEV_PLAY_STATUS_32_BACKWARD_IFRAME   = 27,           /* Backward at 32x speed(I frame)*/
        NETDEV_PLAY_STATUS_64_FORWARD_IFRAME    = 28,           /* Forward at 64x speed(I frame)*/
        NETDEV_PLAY_STATUS_64_BACKWARD_IFRAME   = 29,           /* Backward at 64x speed(I frame)*/
        NETDEV_PLAY_STATUS_128_FORWARD_IFRAME   = 30,           /* Forward at 128x speed(I frame)*/
        NETDEV_PLAY_STATUS_128_BACKWARD_IFRAME  = 31,           /* Backward at 128x speed(I frame)*/
        NETDEV_PLAY_STATUS_256_FORWARD_IFRAME   = 32,           /* Forward at 256x speed(I frame)*/
        NETDEV_PLAY_STATUS_256_BACKWARD_IFRAME  = 33,           /* Backward at 256x speed(I frame)*/

        NETDEV_PLAY_STATUS_32_FORWARD           = 34,           /* Forward at 32x speed */
        NETDEV_PLAY_STATUS_32_BACKWARD          = 35,           /* Backward at 32x speed */

        NETDEV_PLAY_STATUS_INVALID
    }

    public enum NETDEV_VOD_PLAY_CTRL_E
    {
        NETDEV_PLAY_CTRL_PLAY            = 0,           /* Play */
        NETDEV_PLAY_CTRL_PAUSE           = 1,           /* Pause */
        NETDEV_PLAY_CTRL_RESUME          = 2,           /* Resume */
        NETDEV_PLAY_CTRL_GETPLAYTIME     = 3,           /* Obtain playing time */
        NETDEV_PLAY_CTRL_SETPLAYTIME     = 4,           /* Configure playing time */
        NETDEV_PLAY_CTRL_GETPLAYSPEED    = 5,           /* Obtain playing speed */
        NETDEV_PLAY_CTRL_SETPLAYSPEED    = 6,           /* Configure playing speed */
        NETDEV_PLAY_CTRL_SINGLE_FRAME    = 7            /* Configure single frame playing speed */
    }

    public enum NETDEV_CONFIG_COMMAND_E
    {
        NETDEV_GET_DEVICECFG                = 100,              /* #NETDEV_DEVICE_BASICINFO_S  Get device information, see #NETDEV_DEVICE_BASICINFO_S */
        NETDEV_SET_DEVICECFG                = 101,              /* Reserved */

        NETDEV_GET_NTPCFG                   = 110,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */
        NETDEV_SET_NTPCFG                   = 111,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */

        NETDEV_GET_NTPCFG_EX                = 112,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_LIST_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_LIST_S */
        NETDEV_SET_NTPCFG_EX                = 113,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_LIST_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_LIST_S */

        NETDEV_GET_STREAMCFG                = 120,              /* #NETDEV_VIDEO_STREAM_INFO_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */
        NETDEV_SET_STREAMCFG                = 121,              /* #NETDEV_VIDEO_STREAM_INFO_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */

        NETDEV_GET_STREAMCFG_EX             = 122,              /* #NETDEV_VIDEO_STREAM_INFO_LIST_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_LIST_S */
        NETDEV_SET_STREAMCFG_EX             = 123,              /* #NETDEV_VIDEO_STREAM_INFO_LIST_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_LIST_S */

        NETDEV_GET_VIDEOMODECFG             = 124,              /* #NETDEV_VIDEO_MODE_INFO_S */
        NETDEV_SET_VIDEOMODECFG             = 125,              /* #NETDEV_VIDEO_MODE_INFO_S */

        NETDEV_GET_PTZPRESETS               = 130,              /* #NETDEV_PTZ_ALLPRESETS_S  Get PTZ preset, see #NETDEV_PTZ_ALLPRESETS_S */

        NETDEV_GET_OSDCFG                   = 140,              /* OSD,#NETDEV_VIDEO_OSD_CFG_S  Get OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */
        NETDEV_SET_OSDCFG                   = 141,              /* OSD,#NETDEV_VIDEO_OSD_CFG_S  Set OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */

        NETDEV_GET_OSD_CONTENT_CFG          = 144,              /* #NETDEV_OSD_CONTENT_S  Get OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_SET_OSD_CONTENT_CFG          = 145,              /* #NETDEV_OSD_CONTENT_S  Set OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_GET_OSD_CONTENT_STYLE_CFG    = 146,              /* #NETDEV_OSD_CONTENT_STYLE_S  Get OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */
        NETDEV_SET_OSD_CONTENT_STYLE_CFG    = 147,              /* #NETDEV_OSD_CONTENT_STYLE_S  Set OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */

        NETDEV_GET_ALARM_OUTPUTCFG          = 150,              /* #NETDEV_ALARM_OUTPUT_LIST_S  Get boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_SET_ALARM_OUTPUTCFG          = 151,              /* #NETDEV_ALARM_OUTPUT_LIST_S  Set boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_TRIGGER_ALARM_OUTPUT         = 152,              /* #NETDEV_TRIGGER_ALARM_OUTPUT_S        Trigger boolean, see #NETDEV_TRIGGER_ALARM_OUTPUT_S */
        NETDEV_GET_ALARM_INPUTCFG           = 153,              /* #NETDEV_ALARM_INPUT_LIST_S   Get the number of boolean inputs, see #NETDEV_ALARM_INPUT_LIST_S */
        NETDEV_GET_MANUAL_ALARM_CFG         = 154,              /* #NETDEV_OUTPUT_SWITCH_ALARM_STATUS_LIST_S  Get manual alarm boolean configuration information, see #NETDEV_OUTPUT_SWITCH_ALARM_STATUS_LIST_S*/
        NETDEV_SET_MANUAL_ALARM_CFG         = 155,              /* #NETDEV_OUTPUT_SWITCH_MANUAL_ALARM_INFO_S  Set manual alarm boolean configuration information, see #NETDEV_OUTPUT_SWITCH_MANUAL_ALARM_INFO_S */

        NETDEV_GET_IMAGECFG                 = 160,              /* #NETDEV_IMAGE_SETTING_S  Get image configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_IMAGECFG                 = 161,              /* #NETDEV_IMAGE_SETTING_S  Set image configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_NETWORKCFG               = 170,              /* #NETDEV_NETWORKCFG_S  Get network configuration information, see #NETDEV_NETWORKCFG_S */
        NETDEV_SET_NETWORKCFG               = 171,              /* #NETDEV_NETWORKCFG_S  Set network configuration information, see #NETDEV_NETWORKCFG_S */

        NETDEV_GET_PRIVACYMASKCFG           = 180,              /* #NETDEV_PRIVACY_MASK_CFG_S  Get privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_SET_PRIVACYMASKCFG           = 181,              /* #NETDEV_PRIVACY_MASK_CFG_S  Set privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_DELETE_PRIVACYMASKCFG        = 182,              /* Delete privacy mask configuration information */

        NETDEV_GET_TAMPERALARM              = 190,              /* #NETDEV_TAMPER_ALARM_INFO_S  Get tamper alarm configuration information, see #NETDEV_TAMPER_ALARM_INFO_S */
        NETDEV_SET_TAMPERALARM              = 191,              /* #NETDEV_TAMPER_ALARM_INFO_S  Set tamper alarm configuration information, see #NETDEV_TAMPER_ALARM_INFO_S */

        NETDEV_GET_MOTIONALARM              = 200,              /* #NETDEV_MOTION_ALARM_INFO_S  Get motion alarm configuration information, see #NETDEV_MOTION_ALARM_INFO_S */
        NETDEV_SET_MOTIONALARM              = 201,              /* #NETDEV_MOTION_ALARM_INFO_S  Set motion alarm configuration information, see #NETDEV_MOTION_ALARM_INFO_S */

        NETDEV_GET_CROSSLINEALARM           = 202,              /* #NETDEV_CROSS_LINE_ALARM_INFO_S Get Cross Line alarm configuration information, see #NETDEV_CROSS_LINE_ALARM_INFO_S*/
        NETDEV_SET_CROSSLINEALARM           = 203,              /* #NETDEV_CROSS_LINE_ALARM_INFO_S Set Cross Line alarm configuration information, see #NETDEV_CROSS_LINE_ALARM_INFO_S*/

        NETDEV_GET_INTRUSIONALARM           = 204,              /* #NETDEV_INTRUSION_ALARM_INFO_S Get intrusion alarm configuration information, see #NETDEV_INTRUSION_ALARM_INFO_S*/
        NETDEV_SET_INTRUSIONALARM           = 205,              /* #NETDEV_INTRUSION_ALARM_INFO_S Set intrusion alarm configuration information, see #NETDEV_INTRUSION_ALARM_INFO_S*/

        NETDEV_GET_DISKSINFO                = 210,              /* #NETDEV_GET_DISKS_INFO_S  Get disks information, see #NETDEV_GET_DISKS_INFO_S */

        NETDEV_GET_FOCUSINFO                = 230,              /* #NETDEV_FOCUS_INFO_S Get focus info, see #NETDEV_FOCUS_INFO_S */
        NETDEV_SET_FOCUSINFO                = 231,              /* #NETDEV_FOCUS_INFO_S Set focus info, see #NETDEV_FOCUS_INFO_S */

        NETDEV_GET_IRCUTFILTERINFO          = 240,              /* #NETDEV_IRCUT_FILTER_INFO_S Get IRcut filter info, see #NETDEV_IRCUT_FILTER_INFO_S */
        NETDEV_SET_IRCUTFILTERINFO          = 241,              /* #NETDEV_IRCUT_FILTER_INFO_S Set IRcut filter info, see #NETDEV_IRCUT_FILTER_INFO_S */

        NETDEV_GET_DEFOGGINGINFO            = 250,              /* #NETDEV_DEFOGGING_INFO_S Get defogging info, see #NETDEV_DEFOGGING_INFO_S */
        NETDEV_SET_DEFOGGINGINFO            = 251,              /* #NETDEV_DEFOGGING_INFO_S Set defogging info, see #NETDEV_DEFOGGING_INFO_S */

        NETDEV_GET_RECORDPLANINFO           = 252,              /* #NETDEV_RECORD_PLAN_CFG_INFO_S */
        NETDEV_SET_RECORDPLANINFO           = 253,              /* #NETDEV_RECORD_PLAN_CFG_INFO_S */

        NETDEV_GET_DST_CFG                  = 260,              /* #NETDEV_DST_CFG_S Get defogging info, see #NETDEV_DST_CFG_S */
        NETDEV_SET_DST_CFG                  = 261,              /* #NETDEV_DST_CFG_S Set defogging info, see #NETDEV_DST_CFG_S */

        NETDEV_GET_AUDIOIN_CFG              = 262,              /* #NETDEV_AUDIO_INPUT_CFG_INFO_S get audio input config info see #NETDEV_AUDIO_INPUT_CFG_INFO_S */
        NETDEV_SET_AUDIOIN_CFG              = 263,              /* #NETDEV_AUDIO_INPUT_CFG_INFO_S set audio input config info see #NETDEV_AUDIO_INPUT_CFG_INFO_S */

        NETDEV_SET_DNS_CFG                  = 270,              /* #NETDEV_DNS_INFO_S Set DNS info see #NETDEV_DNS_INFO_S*/
        NETDEV_GET_DNS_CFG                  = 271,              /* #NETDEV_DNS_INFO_S Get DNS info see #NETDEV_DNS_INFO_S*/

        NETDEV_SET_NETWORK_CARDS            = 272,              /* #NETDEV_NETWORK_CARD_INFO_S set device networkcards infos see #NETDEV_NETWORK_CARD_INFO_S*/
        NETDEV_GET_NETWORK_CARDS            = 273,              /* #NETDEV_NETWORK_CARD_INFO_S get device networkcards infos see #NETDEV_NETWORK_CARD_INFO_S*/

        NETDEV_GET_RECORD_STATUS            = 320,              /* 获取录像状态信息 参见#NETDEV_RECORD_STATUS_LIST_S  Get video status information*/

        NETDEV_GET_RAID_STATUS              = 470,              /* 获取阵列状态 参见#NETDEV_RAID_STATUS_S */
        NETDEV_GET_RAID_STORAGE_CONTAINER_INFO_LIST = 471,      /* 先使用NETDEV_GET_RAID_STATUS命令获取阵列状态，阵列状态使能时，获取存储容器信息列表 参见#NETDEV_HDD_INFO_LIST_S */
        NETDEV_GET_STORAGE_CONTAINER_INFO_LIST = 472,           /* 先使用NETDEV_GET_RAID_STATUS命令获取阵列状态，阵列状态不使能时，获取存储容器信息列表 参见#NETDEV_STORAGE_CONTAINER_INFO_LIST_S */
        NETDEV_GET_HDD_SMART_INFO              = 473,           /* 获取指定硬盘的Smart检测信息 参见#NETDEV_HDD_SMART_INFO_S */


        NETDEV_CFG_INVALID                  = 0xFFFF            /* Invalid value */

    }

    
    public enum NETDEV_PTZ_PRESETCMD_E
    {
        NETDEV_PTZ_SET_PRESET   = 0,            /* Set preset */
        NETDEV_PTZ_CLE_PRESET   = 1,            /* Clear preset */
        NETDEV_PTZ_GOTO_PRESET  = 2             /* Go to preset */
    }


    public enum NETDEV_PTZ_CRUISECMD_E
    {
        NETDEV_PTZ_ADD_CRUISE    = 0,         /* Add patrol route */
        NETDEV_PTZ_MODIFY_CRUISE = 1,         /* Edit patrol route */
        NETDEV_PTZ_DEL_CRUISE    = 2,         /* Delete patrol route */
        NETDEV_PTZ_RUN_CRUISE    = 3,         /* Start patrol */
        NETDEV_PTZ_STOP_CRUISE   = 4          /* Stop patrol */
    }

    
    public enum NETDEV_DISK_WORK_STATUS_E
    {
        NETDEV_DISK_WORK_STATUS_EMPTY       = 0,            /* Empty */
        NETDEV_DISK_WORK_STATUS_UNFORMAT    = 1,            /* Unformat */
        NETDEV_DISK_WORK_STATUS_FORMATING   = 2,            /* Formating */
        NETDEV_DISK_WORK_STATUS_RUNNING     = 3,            /* Running */
        NETDEV_DISK_WORK_STATUS_HIBERNATE   = 4,            /* Hibernate */
        NETDEV_DISK_WORK_STATUS_ABNORMAL    = 5,            /* Abnormal */
        NETDEV_DISK_WORK_STATUS_UNKNOWN     = 6,            /* Unknown */

        NETDEV_DISK_WORK_STATUS_INVALID                     /* Invalid value */
    }


    public enum NETDEV_PROTOCOL_TYPE_E
    {
        NETDEV_PROTOCOL_TYPE_HTTP  = 0,
        NETDEV_PROTOCOL_TYPE_HTTPS = 1,
        NETDEV_PROTOCOL_TYPE_RTSP  = 2
    }


    public enum NETDEV_VIDEO_QUALITY_E
    {
        NETDEV_VQ_L0 = 0,                    /* Highest */
        NETDEV_VQ_L1 = 1,
        NETDEV_VQ_L2 = 4,                    /* Higher */
        NETDEV_VQ_L3 = 8,
        NETDEV_VQ_L4 = 12,                   /* Medium */
        NETDEV_VQ_L5 = 16,
        NETDEV_VQ_L6 = 20,                   /* Low */
        NETDEV_VQ_L7 = 24,
        NETDEV_VQ_L8 = 28,                   /* Lower */
        NETDEV_VQ_L9 = 31,                   /* Lowest */

        NETDEV_VQ_LEVEL_INVALID = -1         /* Valid */
    }

    public enum NETDEV_BOOLEAN_MODE_E
    {
        NETDEV_BOOLEAN_MODE_OPEN   = 1,                         /* Always open */
        NETDEV_BOOLEAN_MODE_CLOSE  = 2,                         /* Always closed */
        NETDEV_BOOLEAN_MODE_INVALID
    }

    public enum NETDEV_LOG_SUB_TYPE_E
    {
        NETDEV_LOG_ALL_SUB_TYPES                     = 0x0101,          /* All information logs */

        /* Information logs */
        NETDEV_LOG_MSG_HDD_INFO                     = 300,              /* HDD information */
        NETDEV_LOG_MSG_SMART_INFO                   = 301,              /* S.M.A.R.T  S.M.A.R.T information */
        NETDEV_LOG_MSG_REC_OVERDUE                  = 302,              /* Expired recording deletion */
        NETDEV_LOG_MSG_PIC_REC_OVERDUE              = 303,              /* Expired image deletion */

        /*notification logs */
        NETDEV_LOG_NOTICE_IPC_ONLINE                = 310,              /* Device online */
        NETDEV_LOG_NOTICE_IPC_OFFLINE               = 311,              /* Device offline */
        NETDEV_LOG_NOTICE_ARRAY_RECOVER             = 312,              /* arrayRecover */
        NETDEV_LOG_NOTICE_INIT_ARRARY               = 313,              /* initializeArray */
        NETDEV_LOG_NOTICE_REBUILD_ARRARY            = 314,              /*  rebuildArray */
        NETDEV_LOG_NOTICE_POE_PORT_STATUS           = 315,              /*  poePortStatus */
        NETDEV_LOG_NOTICE_NETWORK_PORT_STATUS       = 316,              /*  networkPortStatus */
        NETDEV_LOG_NOTICE_DISK_ONLINE               = 317,              /* Disk online */


        /* ID  Sub type log ID of alarm logs */
        NETDEV_LOG_ALARM_MOTION_DETECT              = 350,              /* Motion detection alarm */
        NETDEV_LOG_ALARM_MOTION_DETECT_RESUME       = 351,              /* Motion detection alarm recover */
        NETDEV_LOG_ALARM_VIDEO_LOST                 = 352,              /* Video loss alarm */
        NETDEV_LOG_ALARM_VIDEO_LOST_RESUME          = 353,              /* Video loss alarm recover */
        NETDEV_LOG_ALARM_VIDEO_TAMPER_DETECT        = 354,              /* Tampering detection alarm */
        NETDEV_LOG_ALARM_VIDEO_TAMPER_RESUME        = 355,              /* Tampering detection alarm recover */
        NETDEV_LOG_ALARM_INPUT_SW                   = 356,              /* Boolean input alarm */
        NETDEV_LOG_ALARM_INPUT_SW_RESUME            = 357,              /* Boolean input alarm recover */
        NETDEV_LOG_ALARM_IPC_ONLINE                 = 358,              /* Device online */
        NETDEV_LOG_ALARM_IPC_OFFLINE                = 359,              /* Device offline */

        /* ID  Sub type log ID of exception logs */
        NETDEV_LOG_EXCEP_DISK_ONLINE                = 400,              /* Disk online */
        NETDEV_LOG_EXCEP_DISK_OFFLINE               = 401,              /* Disk offline */
        NETDEV_LOG_EXCEP_DISK_ERR                   = 402,              /* Disk exception */
        NETDEV_LOG_EXCEP_STOR_ERR                   = 403,              /* Storage error */
        NETDEV_LOG_EXCEP_STOR_ERR_RECOVER           = 404,              /* Storage error recover */
        NETDEV_LOG_EXCEP_STOR_DISOBEY_PLAN          = 405,              /* Not stored as planned */
        NETDEV_LOG_EXCEP_STOR_DISOBEY_PLAN_RECOVER  = 406,              /* Not stored as planned recover */
        NETDEV_LOG_EXCEP_ILLEGAL_ACCESS             = 407,              /* Illegal access */
        NETDEV_LOG_EXCEP_IP_CONFLICT                = 408,              /* IP  IP address conflict */
        NETDEV_LOG_EXCEP_NET_BROKEN                 = 409,              /* Network disconnection */
        NETDEV_LOG_EXCEP_PIC_REC_ERR                = 410,              /* ,  Failed to get captured image */
        NETDEV_LOG_EXCEP_VIDEO_EXCEPTION            = 411,              /* ()  Video input exception (for analog channel only) */
        NETDEV_LOG_EXCEP_VIDEO_MISMATCH             = 412,              /* Video standards do not match */
        NETDEV_LOG_EXCEP_RESO_MISMATCH              = 413,              /* Encoding resolution and front-end resolution do not match */
        NETDEV_LOG_EXCEP_TEMP_EXCE                  = 414,              /* Temperature exception */
        NETDEV_LOG_EXCEP_RUNOUT_RECORD_SPACE        = 415,              /* runOutOfRecordSpace */
        NETDEV_LOG_EXCEP_RUNOUT_IMAGE_SPACE         = 416,              /* runOutOfImageSpace */
        NETDEV_LOG_EXCEP_OUT_RECORD_SPACE           = 417,              /* recordSpaceUsedUp */
        NETDEV_LOG_EXCEP_OUT_IMAGE_SPACE            = 418,              /* imageSpaceUsedUp */
        NETDEV_LOG_EXCEP_ANRIDISASSEMBLY            = 419,              /* antiDisassembly Alarm */
        NETDEV_LOG_EXCEP_ANRIDISASSEMBLY_RECOVER    = 420,              /* antiDisassembly AlarmClear*/
        NETDEV_LOG_EXCEP_ARRAY_DAMAGE               = 421,              /* arrayDamage */
        NETDEV_LOG_EXCEP_ARRAY_DEGRADE              = 422,              /* arrayDegrade */
        NETDEV_LOG_EXCEP_RECORD_SNAPSHOT_ABNOR      = 423,              /* recordSnapshotAbnormal */
        NETDEV_LOG_EXCEP_NET_BROKEN_RECOVER         = 424,              /* networkDisconnectClear */
        NETDEV_LOG_EXCEP_IP_CONFLICT_RECOVER        = 425,              /* ipConflictClear */

        /* ID  Sub type log ID of operation logs */
        /* Services */
        NETDEV_LOG_OPSET_LOGIN                      = 450,              /* User login */
        NETDEV_LOG_OPSET_LOGOUT                     = 451,              /* Log out */
        NETDEV_LOG_OPSET_USER_ADD                   = 452,              /* Add user */
        NETDEV_LOG_OPSET_USER_DEL                   = 453,              /* Delete user */
        NETDEV_LOG_OPSET_USER_MODIFY                = 454,              /* Modify user */
        NETDEV_LOG_OPSET_START_REC                  = 455,              /* Start recording */
        NETDEV_LOG_OPSET_STOP_REC                   = 456,              /* Stop recording */
        NETDEV_LOG_OPSETR_PLAY_DOWNLOAD             = 457,              /* /  Playback and download */
        NETDEV_LOG_OPSET_DOWNLOAD                   = 458,              /* Download */
        NETDEV_LOG_OPSET_PTZCTRL                    = 459,              /* PTZ control */
        NETDEV_LOG_OPSET_PREVIEW                    = 460,              /* Live preview */
        NETDEV_LOG_OPSET_REC_TRACK_START            = 461,              /* Start recording route */
        NETDEV_LOG_OPSET_REC_TRACK_STOP             = 462,              /* Stop recording route */
        NETDEV_LOG_OPSET_START_TALKBACK             = 463,              /* Start two-way audio */
        NETDEV_LOG_OPSET_STOP_TALKBACK              = 464,              /* Stop two-way audio */
        NETDEV_LOG_OPSET_IPC_ADD                    = 465,              /* IPC  Add IP camera */
        NETDEV_LOG_OPSET_IPC_DEL                    = 466,              /* IPC  Delete IP camera */
        NETDEV_LOG_OPSET_IPC_SET                    = 467,              /* IPC  Modify IP camera */
        NETDEV_LOG_OPSET_IPC_QUICK_ADD              = 468,              /* quickAddIpc*/
        NETDEV_LOG_OPSET_IPC_ADD_BY_NETWORK         = 469,              /* addIpcByNetwork */
        NETDEV_LOG_OPSET_IPC_MOD_IP                 = 470,              /* modifyIpcAddr */

        /* Configurations */
        NETDEV_LOG_OPSET_DEV_BAS_CFG                = 500,              /* Basic device information */
        NETDEV_LOG_OPSET_TIME_CFG                   = 501,              /* Device time */
        NETDEV_LOG_OPSET_SERIAL_CFG                 = 502,              /* Device serial port */
        NETDEV_LOG_OPSET_CHL_BAS_CFG                = 503,              /* Basic channel configuration */
        NETDEV_LOG_OPSET_CHL_NAME_CFG               = 504,              /* Channel name configuration */
        NETDEV_LOG_OPSET_CHL_ENC_VIDEO              = 505,              /* Video encoding configuration */
        NETDEV_LOG_OPSET_CHL_DIS_VIDEO              = 506,              /* Video display configuration */
        NETDEV_LOG_OPSET_PTZ_CFG                    = 507,              /* PTZ configuration */
        NETDEV_LOG_OPSET_CRUISE_CFG                 = 508,              /* Patrol route configuration */
        NETDEV_LOG_OPSET_PRESET_CFG                 = 509,              /* Preset configuration */
        NETDEV_LOG_OPSET_VIDPLAN_CFG                = 510,              /* Recording schedule configuration */
        NETDEV_LOG_OPSET_MOTION_CFG                 = 511,              /* Motion detection configuration */
        NETDEV_LOG_OPSET_VIDLOSS_CFG                = 512,              /* Video loss configuration */
        NETDEV_LOG_OPSET_COVER_CFG                  = 513,              /* Tampering detection configuration */
        NETDEV_LOG_OPSET_MASK_CFG                   = 514,              /* Privacy mask configuration */
        NETDEV_LOG_OPSET_SCREEN_OSD_CFG             = 515,              /* OSD  OSD overlay configuration */
        NETDEV_LOG_OPSET_ALARMIN_CFG                = 516,              /* Alarm input configuration */
        NETDEV_LOG_OPSET_ALARMOUT_CFG               = 517,              /* Alarm output configuration */
        NETDEV_LOG_OPSET_ALARMOUT_OPEN_MAN          = 518,              /* ,  Manually enable alarm output, GUI */
        NETDEV_LOG_OPSET_ALARMOUT_CLOSE_MAN         = 519,              /* ,  Manually disable alarm input, GUI */
        NETDEV_LOG_OPSET_ABNORMAL_CFG               = 520,              /* Exception configuration */
        NETDEV_LOG_OPSET_HDD_CFG                    = 521,              /* HDD configuration */
        NETDEV_LOG_OPSET_NET_IP_CFG                 = 522 ,             /* TCP/IP  TCP/IP configuration */
        NETDEV_LOG_OPSET_NET_PPPOE_CFG              = 523,              /* PPPOE  PPPOE configuration */
        NETDEV_LOG_OPSET_NET_PORT_CFG               = 524,              /* Port configuration */
        NETDEV_LOG_OPSET_NET_DDNS_CFG               = 525,              /* DDNS  DDNS configuration */
        NETDEV_LOG_OPSET_AUDIO_DETECT               = 527,              /* searchExtendDisk */
        NETDEV_LOG_OPSET_SEARCH_EX_DISK             = 528,              /* searchExtendDisk */
        NETDEV_LOG_OPSET_ADD_EX_DISK                = 529,              /* addExtendDisk */
        NETDEV_LOG_OPSET_DEL_EX_DISK                = 530,              /*  deleteExtendDisk */
        NETDEV_LOG_OPSET_SET_EX_DISK                = 531,              /* setExtendDisk */
        NETDEV_LOG_OPSET_LIVE_BY_MULTICAST          = 532,              /*  liveViewByMulticast */
        NETDEV_LOG_OPSET_BISC_DEV_INFO              = 533,              /*  setBasicDeviceInfo */
        NETDEV_LOG_OPSET_PREVIEW_CFG                = 534,              /* SetPreviewOnNvr */
        NETDEV_LOG_OPSET_SET_EMAIL                  = 535,              /* setEmail */
        NETDEV_LOG_OPSET_TEST_EMAIL                 = 536,              /* testEmail */
        NETDEV_LOG_OPSET_SET_IPCONTROL              = 537,              /*  setIPControl */
        NETDEV_LOG_OPSET_PORT_MAP                   = 538,              /* setPortMap */
        NETDEV_LOG_OPSET_ADD_TAG                    = 539,              /*  addTag */
        NETDEV_LOG_OPSET_DEL_TAG                    = 540,              /* 删除录像标签  deleteTag */
        NETDEV_LOG_OPSET_MOD_TAG                    = 541,              /* 修改录像标签  modifyTag */
        NETDEV_LOG_OPSET_LOCK_RECORD                = 542,              /* 录像锁定  lockRecord */
        NETDEV_LOG_OPSET_UNLOCK_RECORD              = 543,              /* 录像解锁定  unlockRecord */
        NETDEV_LOG_OPSET_DDNS_UPDATE_SUCCESS        = 545,              /* DDNS更新成功  DDNSUpdateSuccess */
        NETDEV_LOG_OPSET_DDNS_INCORRECT_ID          = 546,              /* DDNS更新失败，错误的用户名密码  DDNSUpdateFailedIncorrectUsernamePassword */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_NAME_NOT_EXIST = 547,              /* DDNS更新失败，域名不存在  DDNSUpdateFailedDomainNameNotExist */
        NETDEV_LOG_OPSET_DDNS_UPDATE_FAIL           = 548,              /* DDNS更新失败  DDNSUpdateFailed */
        NETDEV_LOG_OPSET_HTTP_CFG                   = 549,              /* HTTPS配置  setHttps */
        NETDEV_LOG_OPSET_IP_OFFLINE_ALARM_CFG       = 550,              /* IPC离线报警配置  testDDNSDomain */
        NETDEV_LOG_OPSET_TELNET_CFG                 = 551,              /* Telnet配置  setTelnet */
        NETDEV_LOG_OPSET_TEST_DDNS_DOMAIN           = 552,              /* DDNS域名检测  testDDNSDomain */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_CONFLICT       = 553,              /* DDNS域名冲突  DDNSDomainInvalid */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_INVALID        = 554,              /* DDNS域名不合法  setDDNS */
        NETDEV_LOG_OPSET_DEL_PRESET                 = 555,              /* 删除预置位  deletePreset */
        NETDEV_LOG_OPSET_PTZ_3D_POSITION            = 556,              /* 云台3D定位  ptz3DPosition */
        NETDEV_LOG_OPSET_SNAPSHOT_SCHEDULE_CFG      = 557,              /* 抓图计划配置  setSnapshotSchedule */
        NETDEV_LOG_OPSET_IMAGE_UPLOAD_SCHEDULE_CFG  = 558,              /* 图片上传计划配置  setImageUploadSchedule */
        NETDEV_LOG_OPSET_FTP_CFG                    = 559,              /* FTP服务器配置  setFtpServer */
        NETDEV_LOG_OPSET_TEST_FTP_SERVER            = 560,              /* FTP服务器连接测试  testFtpServer */
        NETDEV_LOG_OPSET_START_MANUAL_SNAPSHOT      = 561,              /* 手动抓图开启  startManualSnapshot */
        NETDEV_LOG_OPSET_CLOSE_MANUAL_SNAPSHOT      = 562,              /* 手动抓图关闭  endManualSnapshot */
        NETDEV_LOG_OPSET_SNAPSHOT_CFG               = 563,              /* 抓图参数配置  setSnapshot */
        NETDEV_LOG_OPSET_ADD_HOLIDAY                = 564,             /* 添加假日  addHoliday */
        NETDEV_LOG_OPSET_DEL_HOLIDAY                = 565,              /* 删除假日  deleteHoliday */
        NETDEV_LOG_OPSET_MOD_HOLIDAY                = 566,              /* 修改假日  modifyHoliday */
        NETDEV_LOG_OPSET_ONOFF_HOLIDAY              = 567,              /* 开启/关闭假日  enableDisableHoliday */
        NETDEV_LOG_OPSET_ALLOCATE_SPACE             = 568,              /* 容量配置  allocateSpace */
        NETDEV_LOG_OPSET_HDD_FULL_POLICY_CFG        = 569,              /* 满策略配置  setHddFullPolicy */
        NETDEV_LOG_OPSET_AUDIO_STREAM_CFG           = 570,              /* 音频流配置  setAudioStream */
        NETDEV_LOG_OPSET_ARRAY_PROPERTY_CFG         = 571,              /* 阵列属性配置  setArrayProperty */
        NETDEV_LOG_OPSET_HOT_SPACE_DISK_CFG         = 572,              /* 热备盘配置  setHotSpaceDisk */
        NETDEV_LOG_OPSET_CREAT_ARRAY                = 573,              /* 手动创建阵列  createArray */
        NETDEV_LOG_OPSET_ONE_CLICK_CREAT_ARRAY      = 574,              /* 一键创建阵列  oneClickCreateArray */
        NETDEV_LOG_OPSET_REBUILD_ARRAY              = 575,              /* 重建阵列  rebuildArray */
        NETDEV_LOG_OPSET_DEL_ARRAY                  = 576,              /* 删除阵列  deleteArray */
        NETDEV_LOG_OPSET_ENABLE_RAID                = 577,              /* 开启RAID模式  enableRaid */
        NETDEV_LOG_OPSET_DISABLE_RAID               = 578,              /* 关闭RAID模式  disableRaid */
        NETDEV_LOG_OPSET_TEST_SMART                 = 579,              /* S.M.A.R.T检测  testSmart */
        NETDEV_LOG_OPSET_SMART_CFG                  = 580,              /* S.M.A.R.T配置  setSmart */
        NETDEV_LOG_OPSET_BAD_SECTOR_DETECT          = 581,              /* 坏道检测  badSectorDetect */
        NETDEV_LOG_OPSET_AUDIO_ALARM_DURATION       = 582,              /* 配置声音报警时长  setAudioAlarmDuration */
        NETDEV_LOG_OPSET_CLR_AUDIO_ALARM            = 583,             /* 清除声音报警  clearAudioAlarm */
        NETDEV_LOG_OPSET_IPC_TIME_SYNC_CFG          = 584,              /* 配置同步摄像机时间  setIpcTimeSync */
        NETDEV_LOG_OPSET_ENABLE_DISK_GROUP          = 585,              /* 开启盘组  enableDiskGroup */
        NETDEV_LOG_OPSET_DISABLE_DISK_GRRUOP        = 586,              /* 关闭盘组  disableDiskGroup */
        NETDEV_LOG_OPSET_ONVIF_AUTH_CFG             = 587,              /* ONVIF认证配置  setOnvifAuth */
        NETDEV_LOG_OPSET_8021X_CFG                  = 588,              /* 配置802.1X  set8021x */
        NETDEV_LOG_OPSET_ARP_PROTECTION_CFG         = 589,              /* 配置ARP防攻击  setArpProtection */
        NETDEV_LOG_OPSET_SMART_BASIC_INFO_CFG       = 590,             /* 智能报警基本信息配置  setSmartBasicInfo */
        NETDEV_LOG_OPSET_CROSS_LINE_DETECT_CFG      = 591,              /* 越界检测配置  setCrossLineDetection */
        NETDEV_LOG_OPSET_INSTRUSION_DETECT_CFG      = 592,              /* 区域入侵配置  setIntrusionDetection */
        NETDEV_LOG_OPSET_PEOPLE_COUNT_CFG           = 593,              /* 客流量配置  setPeopleCount */
        NETDEV_LOG_OPSET_FACE_DETECT_CFG            = 594,              /* 人脸检测配置  setFaceDetection */
        NETDEV_LOG_OPSET_FISHEYE_CFG                = 595,              /* 鱼眼配置  setFisheye */
        NETDEV_LOG_OPSET_CUSTOM_PROTOCOL_CFG        = 596,              /* 自定义协议配置  setCustomProtocol */
        NETDEV_LOG_OPSET_BEHAVIOR_SEARCH            = 597,              /* 行为检索  behaviorSearch */
        NETDEV_LOG_OPSET_FACE_SEARCH                = 598,              /* 人脸检索  faceSearch */
        NETDEV_LOG_OPSET_PEOPLE_COUNT               = 599,              /* 客流量统计  peopleCount */

        /* Maintenance */
        NETDEV_LOG_OPSET_START_DVR                  = 600,              /* Start up*/
        NETDEV_LOG_OPSET_STOP_DVR                   = 601,              /* Shut down */
        NETDEV_LOG_OPSET_REBOOT_DVR                 = 602,              /* Restart device */
        NETDEV_LOG_OPSET_UPGRADE                    = 603,              /* Version upgrade */
        NETDEV_LOG_OPSET_LOGFILE_EXPORT             = 604,              /* Export log files */
        NETDEV_LOG_OPSET_CFGFILE_EXPORT             = 605,              /* Export configuration files */
        NETDEV_LOG_OPSET_CFGFILE_IMPORT             = 606,              /* Import configuration files */
        NETDEV_LOG_OPSET_CONF_SIMPLE_INIT           = 607,              /* Export configuration files */
        NETDEV_LOG_OPSET_CONF_ALL_INIT              = 608,               /* Restore to factory settings */
        NETDEV_LOG_OPSET_VCA_BACKUP = 700,              /* 智能备份  vcaBackup */
        NETDEV_LOG_OPSET_3G4G_CFG = 701,              /* 3G/4G配置  set3g4g */
        NETDEV_LOG_OPSET_MOUNT_EXTENDED_DISK = 702,              /* 加载扩展硬盘 Mount extended disk*/
        NETDEV_LOG_OPSET_UNMOUNT_EXTENDED_DISK = 703,              /* 卸载扩展硬盘 Unmount extended disk*/
        NETDEV_LOG_OPSET_FORCE_USER_OFFLINE = 704,              /* 强制用户下线 Force user off line*/

        NETDEV_LOG_OPSET_AUTO_FUNCTION = 709,              /* 自动维护  autoFunction */
        NETDEV_LOG_OPSET_IPC_UPRAGDE = 710,              /* 摄像机升级  ipcUpgrade */
        NETDEV_LOG_OPSET_RESTORE_IPC_DEFAULTS = 711,              /* 摄像机恢复默认配置  restoreIpcDefaults */
        NETDEV_LOG_OPSET_ADD_TRANSACTION = 712,              /* 添加交易配置  addTransaction */
        NETDEV_LOG_OPSET_MOD_TRANSACTION = 713,              /* 修改交易配置  modifyTransaction */
        NETDEV_LOG_OPSET_DEL_TRANSACTION = 714,              /* 删除交易配置  deleteTransaction */
        NETDEV_LOG_OPSET_POS_OSD = 715,              /* POS显示配置设置  setPosOsd */
        NETDEV_LOG_OPSET_ADD_HOT_SPACE_DEV = 716,              /* 添加备机  addHotSpaceDevice */
        NETDEV_LOG_OPSET_DEL_HOT_SPACE_DEV = 717,              /* 删除备机  deleteHotSpaceDevice */
        NETDEV_LOG_OPSET_MOD_HOT_SPACE_DEV = 718,              /* 修改备机  modifyHotSpaceDevice */
        NETDEV_LOG_OPSET_DEL_WORK_DEV = 719,              /* 删除工作机  deleteWorkDevice */
        NETDEV_LOG_OPSET_WORKMODE_TO_NORMAL_CFG = 720,              /* 设置工作机模式  SetWorkModeToNormal */
        NETDEV_LOG_OPSET_WORKMODE_TO_HOTSPACE_CFG = 721,              /* 设置备机模式  SetWorkModeToHotSpace */
        NETDEV_LOG_OPSET_AUTO_GUARD_CFG = 723,              /* 守望配置  setAutoGuard */
        NETDEV_LOG_OPSET_MULTICAST_CFG = 724,              /* 组播配置  SetMulticast */
        NETDEV_LOG_OPSET_DEFOCUS_DETECT_CFG = 725,              /* 虚焦检测配置 Set defocus detection*/
        NETDEV_LOG_OPSET_SCENECHANGE_CFG = 726,              /* 场景变更配置 Set scene change detection*/
        NETDEV_LOG_OPSET_AUTO_TRCAK_CFG = 727,              /* 智能跟踪配置 Set auto tracking*/
        NETDEV_LOG_OPSET_SORT_CAMERA_CFG = 728,              /* 通道排序 Sort camera*/
        NETDEV_LOG_OPSET_WATER_MARK_CFG = 729              /* 视频水印配置 Set watermark*/     

    }

    public enum NETDEV_EXCEPTION_TYPE_E
    {
        /* Playback exceptions report 300~399 */
        NETDEV_EXCEPTION_REPORT_VOD_END             = 300,          /* Playback ended*/
        NETDEV_EXCEPTION_REPORT_VOD_ABEND           = 301,          /* Playback exception occured */
        NETDEV_EXCEPTION_REPORT_BACKUP_END          = 302,          /* Backup ended */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT     = 303,          /* Disk removed */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL    = 304,          /* Disk full */
        NETDEV_EXCEPTION_REPORT_BACKUP_ABEND        = 305,          /* Backup failure caused by other reasons */

        NETDEV_EXCEPTION_EXCHANGE                   = 0x8000,       /* Exception occurred during user interaction (keep-alive timeout) */
        NETDEV_EXCEPTION_REPORT_ALARM_INTERRUPT     = 0x8001,       /* Alarm report abnormal end ,keep live failure or long connection disconnection*/

        NETDEV_EXCEPTION_REPORT_INVALID             = 0xFFFF        /* Invalid value */
    }

    public enum NETDEV_FORM_TYPE_E
    {
        NETDEV_FORM_TYPE_DAY    = 0,            /* Form type : Day */
        NETDEV_FORM_TYPE_WEEK   = 1,            /* Form type : Week */
        NETDEV_FORM_TYPE_MONTH  = 2,            /* Form type : Month */
        NETDEV_FORM_TYPE_YEAR   = 3,            /* Form type : Year */
        NETDEV_FORM_TYPE_BUTT
    }

 
    public enum NETDEV_LOGIN_PROTO_E
    {
        NETDEV_LOGIN_PROTO_ONVIF             = 0,           /* ONVIF */
        NETDEV_LOGIN_PROTO_PRIVATE           = 1            /* private */
    }

    public enum NETDEV_DEVICE_MAIN_TYPE_E
    {
        NETDEV_DTYPE_MAIN_ENCODE            = 0,                /* 编码设备 */
        NETDEV_DTYPE_MAIN_DECODE            = 1,                /* 解码设备 */
        NETDEV_DTYPE_MAIN_VMS               = 2,                /* 一体机设备 */
        NETDEV_DTYPE_MAIN_DA                = 3,                /* 代理设备 */
        NETDEV_DTYPE_MAIN_CLOUD             = 4,                /* 云端编码设备  */
        NETDEV_DTYPE_MAIN_BAYONET           = 5,                /* 卡口设备 */
        NETDEV_DTYPE_MAIN_ACS               = 6,                /* 门禁主机设备 */
        NETDEV_DTYPE_MAIN_ALARMHOST         = 7,                /* 报警主机设备 */

        NETDEV_DTYPE_MAIN_UNKNOWN           = 0XFF              /* 未知设备 */
    }

    public enum NETDEV_ORG_TYPE_E
    {
        NETDEV_ORG_TYPE_GENERAL            = 0,            /* 普通组织 */
        NETDEV_ORG_TYPE_CLOUD              = 1,            /* 云端组织 */
        NETDEV_ORG_TYPE_VIRTUAL            = 2,            /* 逻辑组织 */
        NETDEV_ORG_TYPE_FAVORITES          = 3,            /* 收藏夹 */
        NETDEV_ORG_TYPE_DOMAIN             = 4,            /* 域名组织 */
        NETDEV_ORG_TYPE_DOORGROUP          = 5,            /* 门组 */
        NETDEV_ORG_TYPE_DEPT               = 6,            /* 部门组织 */

        NETDEV_ORG_TYPE_INVALID            = 0XFF          /* 无效值 */
    }

    public enum NETDEV_ORG_FIND_MODE_E
    {
        NETDEV_ORG_FIND_MODE_ID          = 0,            /* 组织ID */
        NETDEV_ORG_FIND_MODE_TYPE        = 1,            /* 组织类型 */

        NETDEV_ORG_FIND_MODE_INVALID            = 0XFF       /* 无效值 */
    }

    public enum NETDEV_DEVICE_STATUS_E
    {
        NETDEV_DEV_STATUS_OFFLINE                   = 0,                /* 离线 */
        NETDEV_DEV_STATUS_ONLINE                    = 1,                /* 在线 */
        NETDEV_DEV_STATUS_CONNECTING                = 2,                /* 连接中 */

        NETDEV_DEV_STATUS_INVALID                   = 0XFF              /* 无效值 */
    }

    public enum NETDEV_CHN_STATUS_E
    {
        NETDEV_CHN_STATUS_OFFLINE          = 0,                /* 离线 offline */
        NETDEV_CHN_STATUS_ONLINE           = 1,                /* 在线 online */
        NETDEV_CHN_STATUS_VIDEO_LOSE       = 2,                /* 视频丢失 video lose */

        NETDEV_CHN_STATUS_INVALID       = 0xFF
    }

    public enum NETDEV_REPORT_TYPE_E
    {
        NETDEV_REPORT_TYPE_ALARM            = 0,                /* 上报类型：告警 */
        NETDEV_REPORT_TYPE_EVENT            = 1,                /* 上报类型：事件 */

        NETDEV_REPORT_TYPE_INVALID          = 0xFF              /* 无效值 */
    }

    public enum NETDEV_EVENT_ACTION_TYPE_E
    {
        NETDEV_EVENT_ACTION_TYPE_ADD            = 0,                /* 事件动作类型：增加 */
        NETDEV_EVENT_ACTION_TYPE_DELETE         = 1,                /* 事件动作类型：删除 */
        NETDEV_EVENT_ACTION_TYPE_MODIFY         = 2,                /* 事件动作类型：修改 */
        NETDEV_EVENT_ACTION_TYPE_ONLINE         = 3,                /* 事件动作类型：上线 */
        NETDEV_EVENT_ACTION_TYPE_OFFLINE        = 4,                /* 事件动作类型：离线 */
        NETDEV_EVENT_ACTION_TYPE_EMAP_ALARM     = 5,                /* 事件动作类型：电子地图告警 */

        NETDEV_EVENT_ACTION_TYPE_INVALID        = 0xFF              /* 无效值 */
    }

    public enum NETDEV_EVENT_RES_TYPE_E
    {
        NETDEV_EVENT_RES_TYPE_USER              = 0,                /* 用户资源，用户上下线对应登录句柄，其余对应用户编号 */
        NETDEV_EVENT_RES_TYPE_DEVICE            = 1,                /* 设备资源，对应设备编号 */
        NETDEV_EVENT_RES_TYPE_CHANNEL           = 2,                /* 通道资源，对应通道编号 */
        NETDEV_EVENT_RES_TYPE_LOGOUT            = 3,                /* 强制用户退出，对应登录句柄 */
        NETDEV_EVENT_RES_TYPE_SEQUENCE          = 4,                /* 轮巡资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_HOTPOT       = 5,                /* 电子地图热点资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_HOTAREA      = 6,                /* 电子地图热区资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_ALARM        = 7,                /* 电子地图告警资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_TIMETEMPLATE      = 8,                /* 告警预案模板，对应模板ID */
        NETDEV_EVENT_RES_TYPE_SYSRIGHT          = 9,                /* 系统权限资源，对应用户登录句柄 */
        NETDEV_EVENT_RES_TYPE_DEVRIGHT          = 10,               /* 设备权限资源，对应通道编号 */
        NETDEV_EVENT_RES_TYPE_ORG               = 11,               /* 组织资源，对应组织编号 */
        NETDEV_EVENT_RES_TYPE_ALARM_TASK        = 12,               /* 报警任务资源，对应报警任务编号 */
        NETDEV_EVENT_RES_TYPE_SLAVE             = 13,               /* 主从资源(与服务端保持一致) */
        NETDEV_EVENT_RES_TYPE_TVWALL            = 14,               /* 电视墙资源，对应电视墙ID */
        NETDEV_EVENT_RES_TYPE_TVWALL_SCENE      = 15,               /* 电视墙场景资源，对应电视墙ID */
        NETDEV_EVENT_RES_TYPE_WND               = 16,               /* 电视墙窗口资源，对应窗口ID */
        NETDEV_EVENT_RES_TYPE_VIRTUAL_LED       = 17,               /* 电视墙虚拟LED资源，对应虚拟LED ID */
        NETDEV_EVENT_RES_TYPE_BROADCAST_CHANGE  = 18,               /* 广播组信息变更(值与服务端保持一致) */
        NETDEV_EVENT_RES_TYPE_LOGIC_ORG         = 19,               /* 虚拟组织资源，对应组织编号，删除虚拟组织下通道时使用 */
        NETDEV_EVENT_RES_TYPE_USER_ROLE         = 20,               /* 用户角色资源，对应用户登录句柄*/
        NETDEV_EVENT_RES_TYPE_ROLE_ORG          = 21,               /* 角色组织展示树资源，对应用户登录句柄 */
        NETDEV_EVENT_RES_TYPE_EMAP_PIC          = 22,               /* 图片资源，对应热区编号 */
        NETDEV_EVENT_RES_TYPE_PATROL            = 23,               /* 巡航资源 */
        NETDEV_EVENT_RES_TYPE_RECORD            = 24,               /* 录制轨迹资源 */
        NETDEV_EVENT_RES_TYPE_ACS_PERSON        = 25,               /* 门禁人员资源，对应门禁人员ID */
        NETDEV_EVENT_RES_TYPE_ACS_PERSON_CARD   = 26,               /* 门禁卡资源，对应门禁人员ID */
        NETDEV_EVENT_RES_TYPE_TVWALL_LIST       = 27,               /* 电视墙列表，权限到电视墙 */
        NETDEV_EVENT_RES_TYPE_TVWALL_SCENE_SWITCH = 28,             /* 电视墙场景切换 */

        NETDEV_EVENT_RES_TYPE_FACE_LIB          = 29,               /* 人脸库资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_FACE_CUSTOM       = 30,               /* 人脸库自定义属性，对应属性ID */
        NETDEV_EVENT_RES_TYPE_FACE_MEMBER       = 31,               /* 人脸成员资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_FACE_GUARD        = 32,               /* 人脸布控资源，对应人脸布控ID */
        NETDEV_EVENT_RES_TYPE_SMART_DETECT      = 33,               /* 智能检测资源，对应智能检测类型，人脸识别:0 */
        NETDEV_EVENT_RES_TYPE_MANUAL_STATUS     = 34,               /* 手动录像状态 */
        NETDEV_EVENT_RES_TYPE_VEHICLE_GUARD     = 38,               /* 车牌布控资源，对应车牌布控ID */
        NETDEV_EVENT_RES_TYPE_CDN_CHANNEL       = 39,               /* CDN通道资源变更，不上报对应变更信息，客户端收到事件后主动来查询通道列表 */
        NETDEV_EVENT_RES_TYPE_FACE_MEMBER_SORT  = 40,               /* 人脸成员划归资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_LIB       = 41,               /* 车辆库资源，对应车辆库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_MEMBER_SORT = 42,             /* 车辆成员划归资源，对应车辆库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_MEMBER      = 43,             /* 车辆成员资源，对应车辆成员ID */
        NETDEV_EVENT_RES_TYPE_VIEWPLAN_RES      = 44,               /* 视图计划，对应计划ID */
        NETDEV_EVENT_RES_TYPE_SCENESPLAN_RES    = 45,               /* 场景间计划，对应计划ID */
        NETDEV_EVENT_RES_TYPE_ACS_PERMISSION    = 46,               /* 权限资源,  用于授权信息变更*/
        NETDEV_EVENT_RES_TYPE_ACS_GROUP         = 47,               /* 门禁权限组资源，用于门禁权限组（组织）的变更 */
        NETDEV_EVENT_RES_TYPE_TVWALL_AUDIO      = 48,               /* 音频事件 */

        NETDEV_EVENT_RES_TYPE_INVALID           = 0xFF              /* 无效值 */
    }

    public enum NETDEV_CHN_TYPE_E
    {
        NETDEV_CHN_TYPE_ENCODE              = 0,                /* 编码通道, 通道状态参见NETDEV_CHN_STATUS_E */
        NETDEV_CHN_TYPE_ALARMIN             = 1,                /* 告警输入通道, 通道状态参见NETDEV_ALARM_RUNMODE_E */
        NETDEV_CHN_TYPE_ALARMOUT            = 2,                /* 告警输出通道, 通道状态参见NETDEV_ALARMOUT_CHN_STATUS_E */
        NETDEV_CHN_TYPE_DECODE              = 3,                /* 解码通道 */
        NETDEV_CHN_TYPE_AUDIO               = 4,                /* 音频通道 */
        NETDEV_CHN_TYPE_NIC                 = 5,                /* 网卡通道 */
        NETDEV_CHN_TYPE_ALARMPOINT          = 6,                /* 报警点 */
        NETDEV_CHN_TYPE_DOOR                = 7,                /* 门 */
        NETDEV_CHN_TYPE_ADU_ENCODE          = 8,                /* ADU本地编码通道, 通道状态参见NETDEV_CHN_STATUS_E */
        NETDEV_CHN_TYPE_EMERGENCY           = 9,                /* 紧急铃通道 */

        NETDEV_CHN_TYPE_INVALID             = 0xFF              /* 无效值 */
    }


    public enum NETDEV_ARMING_TYPE_E
    {
        NETDEV_ARMING_TYPE_TIMING                   = 0,        /* 定时 */
        NETDEV_ARMING_TYPE_MOTIONDETEC              = 1,        /* 动检 */
        NETDEV_ARMING_TYPE_ALARM                    = 2,        /* 报警 */
        NETDEV_ARMING_TYPE_MOTIONDETEC_AND_ALARM    = 3,        /* 动检和报警 */
        NETDEV_ARMING_TYPE_MOTIONDETEC_OR_ALARM     = 4,        /* 动检或报警 */
        NETDEV_ARMING_TYPE_NO_PLAN                  = 5,        /* 无计划 */
        NETDEV_ARMING_TYPE_EVENT                    = 10        /* 事件 */
    }

    /**
    * @enum tagNETDEVPeopleLibType
    * @brief 人员库类型
    * @attention 无 None
    */
    public enum NETDEV_PEOPLE_LIB_TYPE_E
    {
        NETDEV_PEOPLE_LIB_TYPE_DEFAULT = 0,        /* 默认无效值 */
        NETDEV_PEOPLE_LIB_TYPE_BLACKLIST = 1,        /* 黑名单 */
        NETDEV_PEOPLE_LIB_TYPE_STRANGER = 2,        /* 灰名单/陌生人 */
        NETDEV_PEOPLE_LIB_TYPE_STAFF = 3,        /* 员工 */
        NETDEV_PEOPLE_LIB_TYPE_VISITOR = 4,        /* 访客 */
        NETDEV_PEOPLE_LIB_TYPE_INVALID = 0xFF      /* 无效值 */
    }

    /**
    * @enum tagNETDEVCertificateType
    * @brief 证件类型
    * @attention 无 None
    */
    public enum NETDEV_ID_TYPE_E
    {
        NETDEV_CERTIFICATE_TYPE_ID = 0,        /*0:身份证 */
        NETDEV_CERTIFICATE_TYPE_IC = 1,        /* 1:IC卡 */
        NETDEV_CERTIFICATE_TYPE_PASSPORT = 2,        /* 2:护照 */
        NETDEV_CERTIFICATE_TYPE_DRIVING_LICENSE = 3,        /* 3:行驶证 */
        NETDEV_CERTIFICATE_TYPE_OTHER = 99,       /* 99:其他 */
        NETDEV_CERTIFICATE_TYPE_INVALID = 0xFF      /* 无效值 */
    }

    /**
    * @enum tagNETDEVFileType
    * @brief 文件信息
    * @attention 无 None
    */
    public enum NETDEV_FILE_TYPE_E
    {
        NETDEV_TYPE_FOLDER = 0,    /* 文件夹 */
        NETDEV_TYPE_FILE = 1,    /* 文件 */
        NETDEV_TYPE_INVALID = 0xff  /* 文件夹 */
    }

    /**
     * @enum tagNETDEVGenderType
     * @brief 成员性别
     * @attention 无 None
     */
    public enum NETDEV_GENDER_TYPE_E
    {
        NETDEV_GENDER_TYPE_UNKNOW = 0,        /* 0-未知的性别 */
        NETDEV_GENDER_TYPE_MAN = 1,        /* 1-男 */
        NETDEV_GENDER_TYPE_WOMAN = 2,        /* 2-女 */
        NETDEV_GENDER_TYPE_UNEXPLAINED = 9,        /* 9-未说明的性别 */
        NETDEV_GENDER_TYPE_INVALID = 0xFF      /* 无效值 */
    }

    /**
    * @enum tagNETDEVPersonResultCode
    * @brief 人脸处理结果状态码
    * @attention 无 None
    */
    public enum NETDEV_PERSON_RESULT_CODE_E
    {
        NETDEV_PERSON_CODE_SUCCEED = 0,               /* 成功 */
        NETDEV_PERSON_CODE_COMMON_FAIL = 1,               /* 通用执行失败 */
        NETDEV_PERSON_CODE_SENDING = 2,               /* 下发中 */
        NETDEV_PERSON_CODE_DEV_NOT_SUPPORT = 4,               /* 设备不支持 */
        NETDEV_PERSON_CODE_ARGORITHM_INIT_FAIL = 1000,            /* 算法初始化失败 */
        NETDEV_PERSON_CODE_FACE_DETECT_FAIL = 1001,            /* 人脸检测失败 */
        NETDEV_PERSON_CODE_PICTURE_NO_FACE = 1002,            /* 图片未检测到人脸 */
        NETDEV_PERSON_CODE_JPEG_DECODE_FAIL = 1003,            /* jpeg照片解码失败 */
        NETDEV_PERSON_CODE_PICTURE_QUALITY_LOW = 1004,            /* 图片质量分数不满足 */
        NETDEV_PERSON_CODE_PICTURE_ZOOM_FAIL = 1005,            /* 图片缩放失败 */
        NETDEV_PERSON_CODE_INTELLECT_DISABLE = 1006,            /* 未启用智能 */
        NETDEV_PERSON_CODE_PICTURE_TOO_SMALL = 1007,            /* 导入图片过小 */
        NETDEV_PERSON_CODE_PICTURE_TOO_LARGE = 1008,            /* 导入图片过大 */
        NETDEV_PERSON_CODE_RESOLUTION_TOO_LARGE = 1009,            /* 导入图片分辨率超过1920*1080 */
        NETDEV_PERSON_CODE_PICTURE_NON_EXISTENT = 1010,            /* 导入图片不存在 */
        NETDEV_PERSON_CODE_FACE_ELEMENTS_LIMIT = 1011,            /* 人脸元素个数已达到上限 */
        NETDEV_PERSON_CODE_INTELLECT_MODULE_MISMATCH = 1012,            /* 智能棒算法模型不匹配 */
        NETDEV_PERSON_CODE_DOCUMENT_ID_INVLID = 1013,            /* 人脸导入库成员证件号非法 */
        NETDEV_PERSON_CODE_PICTURE_FORMAT_ERROR = 1014,            /* 人脸导入库成员图片格式错误 */
        NETDEV_PERSON_CODE_MONITOR_DEVICE_LIMIT = 1015,            /* 通道布控已达设备能力上限 */
        NETDEV_PERSON_CODE_FACE_LIBRARY_LOCKED = 1016,            /* 其它客户端正在进行操作人脸库 */
        NETDEV_PERSON_CODE_FACE_LIBRARY_UPDATING = 1017,            /* 人脸库文件正在更新中 */
        NETDEV_PERSON_CODE_JSON_DESERIALIZE_FAIL = 1018,            /* Json反序列化失败 */
        NETDEV_PERSON_CODE_BASE64_DECODE_FAIL = 1019,            /* Base64解码失败 */
        NETDEV_PERSON_CODE_PICTURE_SIZE_MISMATCH = 1020,            /* 人脸照片，编码后的大小和实际接收到的长度不一致 */
        NETDEV_PERSON_CODE_DEV_PROTOCOL_DIFFER = 1021,            /* 布控任务只能选择相同图片接入协议的设备 */
        NETDEV_PERSON_CODE_INVALID = 0xff             /* 无效值 */
    }

    /**
     * @enum tagNETDEVPersonMonitorOptResCode
     * @brief 人脸布控操作结果错误码
     * @attention 仅VMS支持
     */
    public enum NETDEV_PERSON_MONITOR_OPT_RES_CODE_E
    {
        NETDEV_PERSON_MONITOR_CODE_INIT_DETECT_FAIL = 11702,           /* 初始化检测失败 */
        NETDEV_PERSON_MONITOR_CODE_FACE_DETECT_FAIL = 11703,           /* 人脸检测失败 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_NOT_FIND_FACE = 11704,           /* 图片未检测到人脸 */
        NETDEV_PERSON_MONITOR_CODE_JPEG_PARSE_FAIL = 11705,           /* jpeg照片解码失败 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_MASS_NOT_ENOUGH = 11706,           /* 人脸图片质量分数不满足 */
        NETDEV_PERSON_MONITOR_CODE_IMAGE_ZOOM_FAIL = 11707,           /* 图片缩放失败 */
        NETDEV_PERSON_MONITOR_CODE_NOT_START_SMART = 11708,           /* 未启用智能 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_TOO_SMALL = 11709,           /* 导入图片过小 */
        NETDEV_PERSON_MONITOR_CODE_CREATE_FACE_LIB_FAIL = 11710,           /* 创建人脸库失败 */
        NETDEV_PERSON_MONITOR_CODE_CREATE_MONITOR_FAIL = 11711,           /* 创建布控任务失败 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_TOO_LARGE = 11714,           /* 导入图片过大 */
        NETDEV_PERSON_MONITOR_CODE_RESOLUTION_TOO_LARGE = 11715,           /* 导入图片分辨率超过1920*1080 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_NON_EXISTENT = 11716,           /* 导入图片不存在 */
        NETDEV_PERSON_MONITOR_CODE_FACE_ELEMENTS_LIMIT = 11717,           /* 人脸元素个数已达到上限 */
        NETDEV_PERSON_MONITOR_CODE_INTELLECT_MODULE_MISMATCH = 11718,           /* 智能棒算法模型不匹配 */
        NETDEV_PERSON_MONITOR_CODE_DOCUMENT_ID_INVLID = 11719,           /* 人脸导入库成员证件号非法 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_FORMAT_ERROR = 11720,           /* 人脸导入库成员图片格式错误 */
        NETDEV_PERSON_MONITOR_CODE_MONITOR_DEVICE_LIMIT = 11721,           /* 通道布控已达设备能力上限 */
        NETDEV_PERSON_MONITOR_CODE_FACE_LIBRARY_LOCKED = 11722,           /* 其它客户端正在进行操作人脸库 */
        NETDEV_PERSON_MONITOR_CODE_FACE_LIBRARY_UPDATING = 11723,           /* 人脸库文件正在更新中 */
        NETDEV_PERSON_MONITOR_CODE_JSON_DESERIALIZE_FAIL = 11724,           /* Json反序列化失败 */
        NETDEV_PERSON_MONITOR_CODE_BASE64_DECODE_FAIL = 11725,           /* Base64解码失败 */
        NETDEV_PERSON_MONITOR_CODE_PICTURE_SIZE_MISMATCH = 11726            /* 人脸照片，编码后的大小和实际接收到的长度不一致 */
    }

    /**
     * @enum tagNETDEVQueryCondType
     * @brief 查询条件类型
     * @attention 无 None
     */
    public enum NETDEV_QUERYCOND_TYPE_E
    {
        NETDEV_QUERYCOND_USERNAME = 0,                /* 查询条件：用户名称 */
        NETDEV_QUERYCOND_ORGNAME = 1,                /* 查询条件：组织名称 */
        NETDEV_QUERYCOND_DEVNAME = 2,                /* 查询条件：设备名称 */
        NETDEV_QUERYCOND_CHNNAME = 3,                /* 查询条件：通道名称 */
        NETDEV_QUERYCOND_TIME = 4,                /* 查询条件：时间 */
        NETDEV_QUERYCOND_BUSINESSTYPE = 5,                /* 查询条件：业务类型 */
        NETDEV_QUERYCOND_OPERATETYPE = 6,                /* 查询条件：操作类型 */
        NETDEV_QUERYCOND_OPEROBJECT = 7,                /* 查询条件：操作对象 */
        NETDEV_QUERYCOND_ALARMTYPE = 8,                /* 查询条件：告警类型 参见枚举NETDEV_ALARM_TYPE_E*/
        NETDEV_QUERYCOND_ALARMSRCNAME = 9,                /* 查询条件：告警源名称 */
        NETDEV_QUERYCOND_ALARMLEVEL = 10,               /* 查询条件：告警级别 */
        NETDEV_QUERYCOND_ALARMCHECKED = 11,               /* 查询条件：告警是否确认 */
        NETDEV_QUERYCOND_ALARMCHECKUSER = 12,               /* 查询条件：告警确认用户 */
        NETDEV_QUERYCOND_ALARMCHECKTIME = 13,               /* 查询条件：告警确认时间 */
        NETDEV_QUERYCOND_ALARM_DEVID = 14,               /* 查询条件：告警设备ID */
        NETDEV_QUERYCOND_ALARM_CHNID = 15,               /* 查询条件：告警通道ID */
        NETDEV_QUERYCOND_ALARM_SUBTYPE = 16,               /* 查询条件：告警子类型 */
        NETDEV_QUERYCOND_ALARM_SERVER = 17,               /* 查询条件：归属服务器 */
        NETDEV_QUERYCOND_DOOR_NUM = 18,               /* 查询条件：门编号 */
        NETDEV_QUERYCOND_CARD_NUM = 19,               /* 查询条件：卡号 */
        NETDEV_QUERYCOND_ALARM_GENDER = 20,               /* 查询条件：性别 */
        NETDEV_QUERYCOND_ALARM_BIRTHDAY = 21,               /* 查询条件：出生年月 */
        NETDEV_QUERYCOND_MONITOY_REASON = 22,               /* 查询条件：布控原因 */
        NETDEV_QUERYCOND_PLATE_NUM = 23,               /* 查询条件：车牌号码 */
        NETDEV_QUERYCOND_VEHICLE_TYPE = 24,               /* 查询条件：车辆类型 */
        NETDEV_QUERYCOND_PLATE_COLOR = 25,               /* 查询条件：车牌颜色 */
        NETDEV_QUERYCOND_VEHICLE_COLOR = 26,               /* 查询条件：车身颜色 */
        NETDEV_QUERYCOND_PERSON_NUMBER = 27,               /* 查询条件：员工编号*/
        NETDEV_QUERYCOND_PERSON_TYPE = 28,               /* 查询条件：人员类型*/
        NETDEV_QUERYCOND_DIRECT = 29,               /* 查询条件：方向*/
        NETDEV_QUERYCOND_ORGID = 30,               /* 组织ID */
        NETDEV_QUERYCOND_ORGPID = 31,               /* 组织PID */
        NETDEV_QUERYCOND_DEVICEID = 32,               /* 设备ID */
        NETDEV_QUERYCOND_DEVICE_TYPE = 33,               /* 设备类型 */
        NETDEV_QUERYCOND_DEVICE_SUBTYPE = 34,               /* 设备子类型 */
        NETDEV_QUERYCOND_CHANNELID = 35,               /* 通道ID */
        NETDEV_QUERYCOND_CHANNEL_TYPE = 36,               /* 通道类型 */
        NETDEV_QUERYCOND_ONLINE_STATE = 37,               /* 在线状态 */
        NETDEV_DATABASE_ID = 38,               /* 查询条件：库ID */
        NETDEV_QUERY_TYPE_PLATECLASS = 39,               /* 查询条件：车牌类型 */
        NETDEV_QUERYCOND_RANGE = 40,               /* 查询条件：告警查询范围 0是设备，1是服务器*/
        NETDEV_QUERYCOND_BEGIN_TIME = 41,             /* 查询条件：访客预约开始时间*/
        NETDEV_QUERYCOND_END_TIME = 42,             /* 查询条件：访客预约结束时间*/
        NETDEV_QUERYCOND_INTERVIEWEE_NAME = 43,             /* 查询条件：受访人姓名*/
        NETDEV_QUERYCOND_INTERVIEWEE_STATUS = 44,             /* 查询条件：受访人状态*/
        NETDEV_QUERYCOND_PARK_NAME = 45,               /* 查询条件：停车场名称 */
        NETDEV_QUERYCOND_CONFIDENCE_LEVEL = 46,               /* 查询条件：置信度 */
        NETDEV_QUERYCOND_PARK_TIME = 47,               /* 查询条件：停车时长 */
        NETDEV_QUERYCOND_CONTRACT_RULE = 48,               /* 查询条件：包期规则 */
        NETDEV_QUERYCOND_PAYMENT_METHOD = 49,               /* 查询条件：付款方式 */
        NETDEV_QUERYCOND_PASSING_DIRECTION = 50,               /* 查询条件：过车方向 */
        NETDEV_QUERYCOND_VEHICLE_ATTR = 51,               /* 查询条件：车辆属性 */
        NETDEV_QUERYCOND_STATISTICS_UNITS = 52,               /* 查询条件：统计单位 */
        NETDEV_QUERYCOND_EXITENTRANCE_NAME = 53,               /* 查询条件：出入口名称 */
        NETDEV_QUERYCOND_PICTURE_DATA = 54,               /* 查询条件：图片数据 */
        NETDEV_QUERYCOND_PERSON_NAME = 55,               /* 查询条件：人员姓名 */
        NETDEV_QUERYCOND_SIMILARITY = 56,               /* 查询条件：相似度 */
        NETDEV_QUERYCOND_SEARCH_TYPE = 57,               /* 查询条件：检索类型，参见枚举值NETDEV_SEARCH_TYPE_E */
        NETDEV_QUERYCOND_ID_NUMBER = 58,               /* 查询条件：证件号 */
        NETDEV_QUERYCOND_AGERANGE = 59,               /* 查询条件：年龄段 */
        NETDEV_QUERYCOND_GLASSES_STYLE = 61,               /* 查询条件：眼镜款式 */
        NETDEV_QUERYCOND_SLEEVES_LENGTH = 62,               /* 查询条件：上衣长短款式 */
        NETDEV_QUERYCOND_COAT_COLOR = 63,               /* 查询条件：上衣颜色 */
        NETDEV_QUERYCOND_TROUSERS_STYLE = 64,               /* 查询条件：下衣长短款式 */
        NETDEV_QUERYCOND_TROUSERS_COLOR = 65,               /* 查询条件：下衣颜色 */
        NETDEV_QUERYCOND_SNAP_TOWARD = 66,               /* 查询条件：抓拍朝向 */
        NETDEV_QUERYCOND_SHOES_TUBE_LENGTH = 67,               /* 查询条件：鞋子长短款式 */
        NETDEV_QUERYCOND_HAIR_LENGTH = 68,               /* 查询条件：发型长短 */
        NETDEV_QUERYCOND_BAG_FLAG = 69,               /* 查询条件：是否携包 */
        NETDEV_QUERYCOND_SPEED_TYPE = 70,               /* 查询条件：速度类型 */
        NETDEV_QUERYCOND_NON_VEH_TYPE = 71,               /* 查询条件：非机动车类型 */
        NETDEV_QUERYCOND_VEH_BRAND = 72,               /* 查询条件：车辆品牌 */
        NETDEV_QUERYCOND_VEH_DATA_TYPE = 73,               /* 查询条件：车辆数据类型（0：普通抓拍数据，1：结构化抓拍数据） */
        NETDEV_QUERYCOND_PROTOCOL_TYPE = 74,       /* 查询条件：设备接入协议 */
        NETDEV_QUERYCOND_RELEVANT_ROOM = 75,       /* 查询条件：关联房间 */
        NETDEV_QUERYCOND_LOCK_SIGNAL = 76,       /* 查询条件：智能锁信号 */
        NETDEV_QUERYCOND_BIND_RELATION_DOORLOCK = 77,       /* 查询条件：门锁绑定关系 */
        NETDEV_QUERYCOND_BIND_RELATION_PERSON_CARD = 78,       /* 查询条件：人卡绑定关系 */
        NETDEV_QUERYCOND_PERSONID = 79,       /* 查询条件：人员ID */
        NETDEV_QUERYCOND_PARKINGLOTID = 80,       /* 查询条件：停车场ID */
        NETDEV_QUERYCOND_ENTREXITID = 81,       /* 查询条件：出入口ID */
        NETDEV_QUERYCOND_RECORDID = 82,       /* 查询条件：记录ID */
        NETDEV_QUERYCOND_VEH_GROUPINGID = 83,       /* 查询条件：车辆分组ID */

        NETDEV_QUERYCOND_INVALID = 0xFF              /* 无效 */
    }

    /**
     * @enum tagNETDEVQueryCondLogic
     * @brief 查询条件逻辑类型
     * @attention 无 None
     */
    public enum NETDEV_QUERYCOND_LOGICTYPE_E
    {
        NETDEV_QUERYCOND_LOGIC_EQUAL = 0,                /* 查询条件逻辑类型：等于 */
        NETDEV_QUERYCOND_LOGIC_GREATER = 1,                /* 查询条件逻辑类型：大于 */
        NETDEV_QUERYCOND_LOGIC_LESS = 2,                /* 查询条件逻辑类型：小于 */
        NETDEV_QUERYCOND_LOGIC_NO_LESS = 3,                /* 查询条件逻辑类型：不小于 */
        NETDEV_QUERYCOND_LOGIC_NO_GREATER = 4,                /* 查询条件逻辑类型：不大于 */
        NETDEV_QUERYCOND_LOGIC_NO_EQUAL = 5,                /* 查询条件逻辑类型：不等于 */
        NETDEV_QUERYCOND_LOGIC_DIM_QUERY = 6,                /* 查询条件逻辑类型：模糊查询 */
        NETDEV_QUERYCOND_LOGIC_CONTAIN = 7,                /* 查询条件逻辑类型：包括 */
        NETDEV_QUERYCOND_LOGIC_ASC_ORDER = 8,                /* 查询条件逻辑类型：升序 */
        NETDEV_QUERYCOND_LOGIC_DESC_ORDER = 9                 /* 查询条件逻辑类型：降序 */
    }

    /**
     * @enum tagNETDEVFaceMemberIDType
     * @brief 人脸成员证件类型
     * @attention 无 None
     */
    public enum NETDEV_FACE_MEMBER_ID_TYPE_E
    {
        NETDEV_FACE_MEMBER_ID_TYPE_ID_CARD = 0,               /* 身份证 */
        NETDEV_FACE_MEMBER_ID_TYPE_IC_CARD = 1,               /* IC卡 */
        NETDEV_FACE_MEMBER_ID_TYPE_PASSPORT = 2,               /* 护照 */
        NETDEV_FACE_MEMBER_ID_TYPE_DRIVING = 3,               /* 驾照 */
        NETDEV_FACE_MEMBER_ID_TYPE_OTHER = 99,              /* 其他 */

        NETDEV_FACE_MEMBER_ID_TYPE_INVALID = 0xFF             /* 无效值 */
    }

    /**
    * @struct tagNETDEVFacePassRecordType
    * @brief 人脸通行记录类型
    * @attention 无 None
    */
    public enum NETDEV_FACE_PASS_RECORD_TYPE_E
    {
        NETDEV_TYPE_FACE_PASS_COM_SUCCESS = 1,                /* 比对成功告警 */
        NETDEV_TYPE_FACE_PASS_COM_FAIL = 2,                /* 比对失败告警 */
        NETDEV_TYPE_FACE_PASS_INVALID = 0xff              /* 无效值 */
    }

    /**
     * @enum tagNETDEVAlarmActID
     * @brief 使能联动参数
     * @attention
     */
    public enum NETDEV_ALARM_ACT_ID_E
    {
        ALARM_ACTION_TYPE_NVR_PREVIEW = 0,                    /* 联动NVR预览，ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_BUZZER = 1,                    /* 联动蜂鸣器，IPC暂不支持,NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_E_MAIL = 2,                    /* 联动E-Mail，IPC暂不支持，NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_RECORD = 3,                    /* 联动存储，IPC暂不支持，NVR ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_PRESET = 4,                    /* 联动云台预置位，ActParam见NETDEV_PRESET_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_OUTPUT_SWITCH = 5,                    /* 联动开关量输出，ActParam见NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_SNAP = 6,                    /* 联动抓拍，IPC无需填写ActParam ，NVR ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S*/
        ALARM_ACTION_TYPE_BOX = 7,                    /* 告警弹框，IPC暂不支持，NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_CENTER_RECORD = 8,                    /* 联动中心存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_START_LOCAL_RECORD = 9,                    /* 联动启动本地存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_STOP_LOCAL_RECORD = 10,                   /* 联动停止本地存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_FTP = 11,                   /* 联动抓拍上传FTP，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_EMAIL = 12,                   /* 联动抓拍上传EMail，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_FTP_AND_EMAIL = 13,                   /* 联动抓拍上传FTP和EMail，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SMART_SNAP_UP = 14,                   /* 智能联动抓拍上传，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_FACE_PIC_SNAP_UP = 15,                   /* 联动人脸小图抓拍上传，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_ALARM_REPORT = 16,                   /* 联动告警上报，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_PTZ_ZOOM = 17,                   /* 联动云台变倍， */
        ALARM_ACTION_TYPE_INVALID = 0xff                  /* 无效参数 */
    }

    /**
     * @enum tagLinkageStrategy
     * @brief 告警联动配置信息 结构体定义
     * @attention 无 None
     */
    public enum NETDEV_PERSON_COMPARE_RESULT_TYPE_E
    {
        NETDEV_TYPE_COMPARE_SUCCESS = 1,
        NETDEV_TYPE_COMPARE_FAILED = 2,
        NETDEV_TYPE_COMPARE_INVALID = 0xff
    }

    /**
    * @enum tagNETDEVPlateColor
    * @brief 车牌颜色 枚举定义 plate color Enumeration definition
    * @attention 无 None
    */
    public enum NETDEV_PLATE_COLOR_E
    {
        NETDEV_PLATE_COLOR_BLACK_E = 0,           /* 黑色 */
        NETDEV_PLATE_COLOR_WHITE_E = 1,           /* 白色 */
        NETDEV_PLATE_COLOR_GRAY_E = 2,           /* 灰色 */
        NETDEV_PLATE_COLOR_RED_E = 3,           /* 红色 */
        NETDEV_PLATE_COLOR_BLUE_E = 4,           /* 蓝色 */
        NETDEV_PLATE_COLOR_YELLOW_E = 5,           /* 黄色 */
        NETDEV_PLATE_COLOR_ORANGE_E = 6,           /* 橙色 */
        NETDEV_PLATE_COLOR_BROWN_E = 7,           /* 棕色 */
        NETDEV_PLATE_COLOR_GREEN_E = 8,           /* 绿色 */
        NETDEV_PLATE_COLOR_PURPLE_E = 9,           /* 紫色 */
        NETDEV_PLATE_COLOR_CYAN_E = 10,          /* 青色 */
        NETDEV_PLATE_COLOR_PINK_E = 11,          /* 粉色 */
        NETDEV_PLATE_COLOR_TRANSPARENT_E = 12,          /* 透明 */
        NETDEV_PLATE_COLOR_SILVERYWHITE_E = 13,          /* 银白 */
        NETDEV_PLATE_COLOR_DARK_E = 14,          /* 深色 */
        NETDEV_PLATE_COLOR_LIGHT_E = 15,          /* 浅色 */
        NETDEV_PLATE_COLOR_COLOURLESS = 16,          /* 无色 */
        NETDEV_PLATE_COLOR_YELLOWGREEN = 17,          /* 黄绿双色 */
        NETDEV_PLATE_COLOR_GRADUALGREEN = 18,          /* 渐变绿色 */
        NETDEV_PLATE_COLOR_OTHER_E = 99,          /* 其他 */
        NETDEV_PLATE_COLOR_UNKNOW_E = 100,         /* 未知 */
        NETDEV_PLATE_COLOR_INVALID = 0xFF         /* 无效值  Invalid value */
    }

    /**
    * @enum tagNETDEVPlateType
    * @brief 车牌类型 枚举定义 plate type Enumeration definition
    * @attention 无 None
    */
    public enum NETDEV_PLATE_TYPE_E
    {
        NETDEV_PLATE_TYPE_BIG_CAR_E = 0,                     /* 大型汽车号牌 */
        NETDEV_PLATE_TYPE_MINI_CAR_E = 1,                    /* 小型汽车号牌 */
        NETDEV_PLATE_TYPE_EMBASSY_CAR_E = 2,                 /* 使馆汽车号牌 */
        NETDEV_PLATE_TYPE_CONSULATE_CAR_E = 3,               /* 领馆汽车号牌 */
        NETDEV_PLATE_TYPE_OVERSEAS_CAR_E = 4,                /* 境外汽车号牌 */
        NETDEV_PLATE_TYPE_FOREIGN_CAR_E = 5,                 /* 外籍汽车号牌 */
        NETDEV_PLATE_TYPE_COMMON_MOTORBIKE_E = 6,            /* 普通摩托车号牌 */
        NETDEV_PLATE_TYPE_HANDINESS_MOTORBIKE_E = 7,         /* 轻便摩托车号牌 */
        NETDEV_PLATE_TYPE_EMBASSY_MOTORBIKE_E = 8,           /* 使馆摩托车号牌 */
        NETDEV_PLATE_TYPE_CONSULATE_MOTORBIKE_E = 9,         /* 领馆摩托车号牌 */
        NETDEV_PLATE_TYPE_OVERSEAS_MOTORBIKE_E = 10,         /* 境外摩托车号牌 */
        NETDEV_PLATE_TYPE_FOREIGN_MOTORBIKE_E = 11,          /* 外籍摩托车号牌 */
        NETDEV_PLATE_TYPE_LOW_SPEED_CAR_E = 12,              /* 低速车号牌 */
        NETDEV_PLATE_TYPE_TRACTOR_E = 13,                    /* 拖拉机号牌 */
        NETDEV_PLATE_TYPE_TRAILER_E = 14,                    /* 挂车号牌 */
        NETDEV_PLATE_TYPE_COACH_CAR_E = 15,                  /* 教练汽车号牌 */
        NETDEV_PLATE_TYPE_COACH_MOTORBIKE_E = 16,            /* 教练摩托车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_CAR_E = 17,        /* 临时入境汽车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_MOTORBIKE_E = 18,  /* 临时入境摩托车号牌 */
        NETDEV_PLATE_TYPE_TEMPORARY_DRIVING_E = 19,          /* 临时行驶车号牌 */
        NETDEV_PLATE_TYPE_POLICE_CAR_E = 20,                 /* 警用汽车号牌 */
        NETDEV_PLATE_TYPE_POLICE_MOTORBIKE_E = 21,           /* 警用摩托车号牌 */
        NETDEV_PLATE_TYPE_AGRICULTURAL_E = 22,               /* 原农机号牌 */
        NETDEV_PLATE_TYPE_HONGKONG_ENTRY_EXIT_E = 23,        /* 香港入出境号牌 */
        NETDEV_PLATE_TYPE_MACAO_ENTRY_EXIT_E = 24,           /* 澳门入出境号牌 */
        NETDEV_PLATE_TYPE_ARMED_POLICE_E = 25,               /* 武警号牌 */
        NETDEV_PLATE_TYPE_ARMY_E = 26,                       /* 军队号牌 */

        NETDEV_PLATE_TYPE_OTHER_E = 99,                      /* 其他号牌 */


        NETDEV_PLATE_TYPE_INVALID = 0xFF                     /* 无效值  Invalid value */
    }

    /**
    * @enum tagNETDEVVehicleType
    * @brief 车辆类型 枚举定义 plate type Enumeration definition
    * @attention 无 None
    */
    public enum NETDEV_VEHICLE_TYPE_E
    {
        NETDEV_VEHICLE_TYPE_TRICYCLE_E = 0,                /* 三轮车 */
        NETDEV_VEHICLE_TYPE_MOTOR_BUS_E = 1,                /* 大客车 */
        NETDEV_VEHICLE_TYPE_MIDDLE_E = 2,                /* 中型车 */
        NETDEV_VEHICLE_TYPE_SMALL_E = 3,                /* 小型车 */
        NETDEV_VEHICLE_TYPE_BIG_E = 4,                /* 大型车 */
        NETDEV_VEHICLE_TYPE_TWOWHEELVEH = 5,                /* 二轮车 */
        NETDEV_VEHICLE_TYPE_MOTORCYCLE_E = 6,                /* 摩托车 */
        NETDEV_VEHICLE_TYPE_TRACTOR_E = 7,                /* 拖拉机 */
        NETDEV_VEHICLE_TYPE_AGRICULTURAL_E = 8,                /* 农用货车 */
        NETDEV_VEHICLE_TYPE_SEADAN = 9,                /* 轿车 */
        NETDEV_VEHICLE_TYPE_SUV_E = 10,               /* SUV */
        NETDEV_VEHICLE_TYPE_VAN_E = 11,               /* 面包车 */
        NETDEV_VEHICLE_TYPE_SMALLTRUCK_E = 12,               /* 小货车 */
        NETDEV_VEHICLE_TYPE_MEDIUMCAR_E = 13,               /* 中巴车/中型客车 */
        NETDEV_VEHICLE_TYPE_LARGEBUS_E = 14,               /* 大客车/大型客车 */
        NETDEV_VEHICLE_TYPE_LARGETRUCK_E = 15,               /* 大货车/大型货车 */
        NETDEV_VEHICLE_TYPE_PICKUPTRUCK_E = 16,               /* 皮卡车 */
        NETDEV_VEHICLE_TYPE_BUSINESSVEH_E = 17,               /* MPV 商务车 */
        NETDEV_VEHICLE_TYPE_SPORTSCAR_E = 18,               /* 跑车 */
        NETDEV_VEHICLE_TYPE_MINICAR_E = 19,               /* 微型轿车 */
        NETDEV_VEHICLE_TYPE_HATCHBACKCAR_E = 20,               /* 两厢轿车 */
        NETDEV_VEHICLE_TYPE_THREEBOX_E = 21,               /* 三厢轿车 */
        NETDEV_VEHICLE_TYPE_LIGHTBUS_E = 22,               /* 轻型客车 */
        NETDEV_VEHICLE_TYPE_MEDIUNTRUCK_E = 23,               /* 中型货车 */
        NETDEV_VEHICLE_TYPE_TRAILER_E = 24,               /* 挂车 */
        NETDEV_VEHICLE_TYPE_TANK_E = 25,               /* 槽罐车 */
        NETDEV_VEHICLE_TYPE_WATERCAR_E = 26,               /* 洒水车 */
        NETDEV_VEHICLE_TYPE_OTHER_E = 998,              /* 其他 */
        NETDEV_VEHICLE_TYPE_UNKNOW_E = 999,              /* 未知 */
        NETDEV_VEHICLE_TYPE_INDISTINGUISH_E = 1000,             /* 不区分车辆类型 */
        NETDEV_VEHICLE_TYPE_INVALID = 0xFFFF            /* 无效值  Invalid value */
    }

    /**
     * @enum tagNETDEVSpeedType
     * @brief 结构化场景中非机动车速度类型
     * @attention 
     */
    public enum NETDEV_SPEED_TYPE_E
    {
        NETDEV_SPEED_TYPE_UNKNOW = 0,                   /* 未知 */
        NETDEV_SPEED_TYPE_STATIC = 1,                   /* 静止 */
        NETDEV_SPEED_TYPE_SLOW = 2,                   /* 慢速 */
        NETDEV_SPEED_TYPE_MEDIUM = 3,                   /* 中速 */
        NETDEV_SPEED_TYPE_FAST = 4,                   /* 快速 */
        NETDEV_SPEED_TYPE_INVALID = 0xFF                 /* 无效值 */
    }

    /**
     * @enum tagNETDEVImageDirection
     * @brief 结构化场景中非机动车相对画面运动方向
     * @attention 
     */
    public enum NETDEV_IMAGE_DIRECTION_E
    {
        NETDEV_IMAGE_DIRECTION_UNKNOW = 0,                   /* 未知 */
        NETDEV_IMAGE_DIRECTION_STATIC = 1,                   /* 静止 */
        NETDEV_IMAGE_DIRECTION_UP = 2,                   /* 向上 */
        NETDEV_IMAGE_DIRECTION_DOWN = 3,                   /* 向下 */
        NETDEV_IMAGE_DIRECTION_LEFT = 4,                   /* 向左 */
        NETDEV_IMAGE_DIRECTION_RIGHT = 5,                   /* 向右 */
        NETDEV_IMAGE_DIRECTION_LEFTUP = 6,                   /* 左上 */
        NETDEV_IMAGE_DIRECTION_LEFTDOWN = 7,                   /* 左下 */
        NETDEV_IMAGE_DIRECTION_RIGHTUP = 8,                   /* 右上 */
        NETDEV_IMAGE_DIRECTION_RIGHTDOWN = 9,                   /* 右下 */
        NETDEV_IMAGE_DIRECTION_INVALID = 0xFF                 /* 无效值 */
    }

    /**
    * @enum tagNETDEVSmartAlarmType
    * @brief 智能告警类型
    * @attention 无
    */
    public enum NETDEV_SMART_ALARM_TYPE_E
    {
        NETDEV_SMART_ALARM_TYPE_FACE_SNAP = 0,             /* 人脸识别抓图 */
        NETDEV_SMART_ALARM_TYPE_VEHICLE_SNAP = 1,             /* 车牌识别抓图 */
        NETDEV_SMART_ALARM_TYPE_VIDEO_STRUCT_SNAP = 3,             /* 视频结构化抓图 */
        NETDEV_SMART_ALARM_TYPE_INVALID = 0xFF           /* 无效值 */
    }

    /**
    * @enum tagNETDEVNotificationType
    * @brief 通知类型
    * @attention 无 None
    */
    public enum NETDEV_NOTIFICATION_TYPE_E
    {
        NETDEV_NOTIFICATION_TYPE_REALTIME = 0,           /* 实时通知 */
        NETDEV_NOTIFICATION_TYPE_HISTORY = 1,           /* 历史通知 */
        NETDEV_NOTIFICATION_TYPE_EARLYWARN = 2            /* 预警通知 */
    }

    /**
     * @enum tagNETDEVAgeRange
     * @brief 年龄段
     * @attention 
     */
    public enum NETDEV_AGE_RANGE_E
    {
        NETDEV_AGE_RANGE_UNKNOW = 0,                /* 未知 */
        NETDEV_AGE_RANGE_CHILD = 1,                /* 儿童 */
        NETDEV_AGE_RANGE_JUVENILE = 2,                /* 少年 */
        NETDEV_AGE_RANGE_Youth = 3,                /* 青年 */
        NETDEV_AGE_RANGE_MIDDLEAGE = 4,                /* 中年 */
        NETDEV_AGE_RANGE_OLDAGE = 5,                /* 老年 */
        NETDEV_AGE_RANGE_INVALID = 0xFF              /* 无效年龄段 */
    }

    /**
     * @enum tagNETDEVGlassFlag
     * @brief 是否戴眼镜标志
     * @attention 
     */
    public enum NETDEV_GLASS_FLAG_E
    {
        NETDEV_GLASS_FLAG_UNKNOW = 0,                 /* 未知 */
        NETDEV_GLASS_FLAG_NO = 1,                 /* 不戴 */
        NETDEV_GLASS_FLAG_YES = 2,                 /* 戴 */
        NETDEV_GLASS_FLAG_INVALID = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVGlassesStyle
     * @brief 眼镜款式
     * @attention 
     */
    public enum NETDEV_GLASSES_STYLE_E
    {
        NETDEV_GLASSES_STYLE_UNKNOW = 0,                 /* 未知 */
        NETDEV_GLASSES_STYLE_GENERAL = 1,                 /* 普通眼镜 */
        NETDEV_GLASSES_STYLE_SUNLIGHT = 2,                 /* 太阳眼镜 */
        NETDEV_GLASSES_STYLE_OTHER = 99,                /* 其它 */
        NETDEV_GLASSES_STYLE_INVALID = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVSleevesLength
     * @brief 上衣长短款式
     * @attention 
     */
    public enum NETDEV_SLEEVES_LENGTH_E
    {
        NETDEV_SLEEVES_LENGTH_UNKNOW = 0,                 /* 未知 */
        NETDEV_SLEEVES_LENGTH_SHORT = 1,                 /* 短袖 */
        NETDEV_SLEEVES_LENGTH_LONG = 2,                 /* 长袖 */
        NETDEV_SLEEVES_LENGTH_INVALID = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVTrousersLength
     * @brief 下衣长短款式
     * @attention 
     */
    public enum NETDEV_TROUSERS_LENGTH_E
    {
        NETDEV_TROUSERS_LENGTH_UNKNOW = 0,                 /* 未知 */
        NETDEV_TROUSERS_LENGTH_SHORT = 1,                 /* 短裤 */
        NETDEV_TROUSERS_LENGTH_LONG = 2,                 /* 长裤 */
        NETDEV_TROUSERS_LENGTH_INVALID = 0xFF               /* 无效值 */
    }

    /**
    * @enum tagNETDEVClothesColor
    * @brief 衣服颜色 
    * @attention 无 None
    */
    public enum NETDEV_CLOTHES_COLOR_E
    {
        NETDEV_CLOTHES_COLOR_BLACK_E = 0,            /* 黑色 */
        NETDEV_CLOTHES_COLOR_WHITE_E = 1,           /* 白色 */
        NETDEV_CLOTHES_COLOR_GRAY_E = 2,           /* 灰色 */
        NETDEV_CLOTHES_COLOR_RED_E = 3,           /* 红色 */
        NETDEV_CLOTHES_COLOR_BLUE_E = 4,           /* 蓝色 */
        NETDEV_CLOTHES_COLOR_YELLOW_E = 5,           /* 黄色 */
        NETDEV_CLOTHES_COLOR_ORANGE_E = 6,           /* 橙色 */
        NETDEV_CLOTHES_COLOR_BROWN_E = 7,           /* 棕色 */
        NETDEV_CLOTHES_COLOR_GREEN_E = 8,           /* 绿色 */
        NETDEV_CLOTHES_COLOR_PURPLE_E = 9,           /* 紫色 */
        NETDEV_CLOTHES_COLOR_CYAN_E = 10,          /* 青色 */
        NETDEV_CLOTHES_COLOR_PINK_E = 11,          /* 粉色 */
        NETDEV_CLOTHES_COLOR_TRANSPARENT_E = 12,          /* 透明 */
        NETDEV_CLOTHES_COLOR_SILVERYWHITE_E = 13,          /* 银白 */
        NETDEV_CLOTHES_COLOR_DARK_E = 14,          /* 深色 */
        NETDEV_CLOTHES_COLOR_LIGHT_E = 15,          /* 浅色 */
        NETDEV_CLOTHES_COLOR_COLOURLESS = 16,          /* 无色 */
        NETDEV_CLOTHES_COLOR_YELLOWGREEN = 17,          /* 黄绿双色 */
        NETDEV_CLOTHES_COLOR_GRADUALGREEN = 18,          /* 渐变绿色 */
        NETDEV_CLOTHES_COLOR_OTHER_E = 99,          /* 其他 */
        NETDEV_CLOTHES_COLOR_UNKNOW_E = 100,         /* 未知 */
        NETDEV_CLOTHES_COLOR_INVALID = 0xFF         /* 无效值  Invalid value */
    }

    /**
     * @enum tagNETDEVBodyToward
     * @brief 身体抓拍朝向
     * @attention 
     */
    public enum NETDEV_BODY_TOWARD_E
    {
        NETDEV_BODY_TOWARD_UNKNOW = 0,                 /* 未知 */
        NETDEV_BODY_TOWARD_POSITIVE = 1,                 /* 正面 */
        NETDEV_BODY_TOWARD_SIDE = 2,                 /* 侧面 */
        NETDEV_BODY_TOWARD_BACK = 3,                 /* 背面 */
        NETDEV_BODY_TOWARD_INVALID = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVShoesTubeLength
     * @brief 鞋子长短款式
     * @attention 
     */
    public enum NETDEV_SHOES_TUBE_LENGTH_E
    {
        NETDEV_SHOES_TUBE_LENGTH_UNKNOW = 0,                  /* 未知 */
        NETDEV_SHOES_TUBE_LENGTH_LONG = 1,                  /* 长筒靴 */
        NETDEV_SHOES_TUBE_LENGTH_SHORT = 2,                  /* 短筒靴/普通鞋 */
        NETDEV_SHOES_TUBE_LENGTH_INVALID = 0xFF                /* 无效值 */
    }

    /**
     * @enum tagNETDEVHairLength
     * @brief 发型长短
     * @attention 
     */
    public enum NETDEV_HAIR_LENGTH_E
    {
        NETDEV_HAIR_LENGTH_UNKNOW = 0,                   /* 未知 */
        NETDEV_HAIR_LENGTH_LONG = 1,                   /* 长发 */
        NETDEV_HAIR_LENGTH_SHORT = 2,                   /* 短发 */
        NETDEV_HAIR_LENGTH_INVALID = 0xFF                 /* 无效值 */
    }

    /**
     * @enum tagNETDEVBagFlag
     * @brief 是否携包标志
     * @attention 
     */
    public enum NETDEV_BAG_FLAG_E
    {
        NETDEV_BAG_FLAG_NO = 0,                   /* 未带包 */
        NETDEV_BAG_FLAG_CARRY = 1,                   /* 拎包 */
        NETDEV_BAG_FLAG_BACK = 2,                   /* 背包 */
        NETDEV_BAG_FLAG_INVALID = 0xFF                 /* 无效值 */
    }

    /**
     * @enum tagNETDEVMaskFlag
     * @brief 是否戴口罩
     * @attention 
     */
    public enum NETDEV_MASK_FLAG_E
    {
        NETDEV_MASK_FLAG_UNKNOW                        = 0,                 /* 未知 */
        NETDEV_MASK_FLAG_NOT_WEAR                      = 1,                 /* 不戴 */
        NETDEV_MASK_FLAG_WEAR                          = 2,                 /* 戴 */
        NETDEV_MASK_FLAG_INVALID                       = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVEmotionFlag
     * @brief 情绪情况
     * @attention 
     */
    public enum NETDEV_EMOTION_FLAG_E
    {
        NETDEV_EMOTION_FLAG_UNKNOW                        = 0,                 /* 未知 */
        NETDEV_EMOTION_FLAG_ANGER                         = 1,                 /* 生气的 */
        NETDEV_EMOTION_FLAG_CALM                          = 2,                 /* 平静的 */
        NETDEV_EMOTION_FLAG_CONFUSED                      = 3,                 /* 迷茫的 */
        NETDEV_EMOTION_FLAG_ABHORRENT                     = 4,                 /* 厌恶的 */
        NETDEV_EMOTION_FLAG_HAPPY                         = 5,                 /* 高兴的 */
        NETDEV_EMOTION_FLAG_SAD                           = 6,                 /* 悲伤的 */
        NETDEV_EMOTION_FLAG_AFRAID                        = 7,                 /* 害怕的 */
        NETDEV_EMOTION_FLAG_AMAZED                        = 8,                 /* 吃惊的 */
        NETDEV_EMOTION_FLAG_SQUINT                        = 9,                 /* 眯眼的 */
        NETDEV_EMOTION_FLAG_SCREAM                        = 10,                /* 尖叫的 */
        NETDEV_EMOTION_FLAG_OTHER                         = 11,                /* 其他 */
        NETDEV_EMOTION_FLAG_INVALID                       = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVSmileFlag
     * @brief 微笑标志
     * @attention 
     */
    public enum NETDEV_SMILE_FLAG_E
    {
        NETDEV_SMILE_FLAG_UNKNOW                        = 0,                 /* 未知 */
        NETDEV_SMILE_FLAG_NO                            = 1,                 /* 不微笑 */
        NETDEV_SMILE_FLAG_YES                           = 2,                 /* 微笑 */
        NETDEV_SMILE_FLAG_INVALID                       = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVSkinColorType
     * @brief 肤色
     * @attention 
     */
    public enum NETDEV_SKINCOLOR_TYPE_E
    {
        NETDEV_SKINCOLOR_TYPE_UNKNOW                           = 0,                    /* 未知 */
        NETDEV_SKINCOLOR_TYPE_WHITE                            = 2011,                 /* 白皮肤 */
        NETDEV_SKINCOLOR_TYPE_BLACK                            = 2012,                 /* 黑皮肤 */
        NETDEV_SKINCOLOR_TYPE_YELLOW                           = 2013,                 /* 黄皮肤 */
        NETDEV_SKINCOLOR_TYPE_BROWN                            = 2014,                 /* 棕皮肤 */
        NETDEV_SKINCOLOR_TYPE_INVALID                          = 0xFF                  /* 无效值 */
    }

    /**
     * @enum tagNETDEVBeardFlag
     * @brief 胡子标志
     * @attention 
     */
    public enum NETDEV_BEARD_FLAG_E
    {
        NETDEV_BEARD_FLAG_UNKNOW                        = 0,                 /* 未知 */
        NETDEV_BEARD_FLAG_UNEXIST                       = 1,                 /* 没胡子 */
        NETDEV_BEARD_FLAG_EXIST                         = 2,                 /* 有胡子 */
        NETDEV_BEARD_FLAG_INVALID                       = 0xFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVPersonMaskFlag
     * @brief 是否戴口罩
     * @attention 
     */
    public enum NETDEV_PERSON_MASK_FLAG_E
    {
        NETDEV_PERSON_MASK_FLAG_NOT_WEAR                      = 1,                 /* 不戴 */
        NETDEV_PERSON_MASK_FLAG_WEAR                          = 2,                 /* 戴 */
        NETDEV_PERSON_MASK_FLAG_UNKNOW                        = 255,               /* 未知 */
        NETDEV_PERSON_MASK_FLAG_INVALID                       = 0xFFFF             /* 无效值 */
    }

    /**
     * @enum tagNETDEVCoatTexture
     * @brief 上衣纹理
     * @attention 无 None
     */
    public enum NETDEV_CLOTHES_TEXTURE_E
    {
        NETDEV_CLOTHES_TEXTURE_NO_PATTERNS                  = 1,         /* 无花纹 */
        NETDEV_CLOTHES_TEXTURE_EXIST_PATTERNS               = 2,         /* 有花纹 */
        NETDEV_CLOTHES_TEXTURE_UNKNOW                       = 255,       /* 未知 */
        NETDEV_CLOTHES_TEXTURE_INVALIDP                     = 0xFFFF     /* 无效值 */
    }

    /**
     * @enum tagNETDEVMoveDirection
     * @brief 人员运动方向
     * @attention 
     */
    public enum NETDEV_MOVE_DIRECTION_E
    {
        NETDEV_MOVE_DIRECTION_STATIC                        = 1,                   /* 静止 */
        NETDEV_MOVE_DIRECTION_UP                            = 2,                   /* 向上 */
        NETDEV_MOVE_DIRECTION_DOWN                          = 3,                   /* 向下 */
        NETDEV_MOVE_DIRECTION_LEFT                          = 4,                   /* 向左 */
        NETDEV_MOVE_DIRECTION_RIGHT                         = 5,                   /* 向右 */
        NETDEV_MOVE_DIRECTION_LEFTUP                        = 6,                   /* 左上 */
        NETDEV_MOVE_DIRECTION_LEFTDOWN                      = 7,                   /* 左下 */
        NETDEV_MOVE_DIRECTION_RIGHTUP                       = 8,                   /* 右上 */
        NETDEV_MOVE_DIRECTION_RIGHTDOWN                     = 9,                   /* 右下 */
        NETDEV_MOVE_DIRECTION_UNKNOW                        = 255,                 /* 未知 */
        NETDEV_MOVE_DIRECTION_INVALID                       = 0xFFFF               /* 无效值 */
    }

    /**
     * @enum tagNETDEVNonVehType
     * @brief 非机动车类型
     * @attention 
     */
    public enum NETDEV_NON_VEH_TYPE_E
    {
        NETDEV_NON_VEH_TYPE_UNKNOW = 0,                   /* 未知 */
        NETDEV_NON_VEH_TYPE_BICYCLE = 1,                   /* 人力自行车 */
        NETDEV_NON_VEH_TYPE_TRIYCLE = 2,                   /* 三轮车 */
        NETDEV_NON_VEH_TYPE_MOTORCYCLE = 3,                   /* 摩托车 */
        NETDEV_NON_VEH_TYPE_ELECTRIC_BICYCLE = 4,                   /* 电动自行车 */
        NETDEV_NON_VEH_TYPE_TWOWHEEL_VEHICLE = 5,                   /* 二轮车（摩托车/人力自行车/电动自行车) */
        NETDEV_NON_VEH_TYPE_INVALID = 0xFF                 /* 无效值 */
    }

    /**
     * @enum tagNETDEVImageFormat
     * @brief 图像格式
     * @attention 
     */
    public enum NETDEV_IMAGE_FORMAT_E
    {
        NETDEV_IMAGE_FORMAT_JPG = 0,                   /* JPG */
        NETDEV_IMAGE_FORMAT_BMP = 1,                   /* BMP */
        NETDEV_IMAGE_FORMAT_PNG = 2,                   /* PNG */
        NETDEV_IMAGE_FORMAT_GIF = 3,                   /* GIF */
        NETDEV_IMAGE_FORMAT_TIFF = 4,                   /* TIFF */
        NETDEV_IMAGE_FORMAT_INVALID = 0xFF                 /* 无效值 */
    }

    /**
     * @enum tagNETDEVMonitorType
     * @brief 布控任务类型
     * @attention 无 None
     */
    public enum NETDEV_MONITOR_TYPE_E
    {
        NETDEV_MONITOR_TYPE_FACE = 0,                /* 人脸 */
        NETDEV_MONITOR_TYPE_VEHICLE = 1,                /* 车牌 */
        NETDEV_MONITOR_TYPE_INVALID = 0xFF              /* 无效值*/
    }

    /* 响应状态类型枚举 */
    public enum NETDEV_ORG_RESPONSE_STAUTE_E
    {
        NETDEV_ORG_RESPONSE_SUCCESS = 0,            /* 响应成功 */
        NETDEV_ORG_RESPONSE_FAIL = 1             /* 响应失败 */
    }

    /**
    * @enum tagNETDEVCapSrc
    * @brief 采集来源
    * @attention 无 None
    */
    public enum NETDEV_CAP_SRC_E
    {
        NETDEV_CAP_SRC_FACE = 1,          /* 人脸识别终端采集的人脸信息 */
        NETDEV_CAP_SRC_ENTRANCE_GUARDCARD = 2,          /* 读卡器采集的门禁卡信息 */
        NETDEV_CAP_SRC_ID = 3,          /* 读卡器采集的身份证信息 */
        NETDEV_CAP_SRC_GATE = 4,          /* 闸机采集的闸机信息 */
        NETDEV_CAP_SRC_INVALID = 0xff        /* 无效值 Invalid value */
    }

    /**
    * @enum tagNETDEVMatchStatus
    * @brief 匹配状态
    * @attention 无 None
    */
    public enum NETDEV_MATCH_STATUS_E
    {
        NETDEV_MATCH_STATUS_SUCCESS = 1,          /* 核验成功 */
        NETDEV_MATCH_STATUS_FAIL = 2,          /* 核验失败（比对失败) */
        NETDEV_MATCH_STATUS_NO_MONITOR_TIME = 3,          /* 核验失败（对比成功，不在布控时间）*/
        NETDEV_MATCH_STATUS_BASE_MAP_COLLECT_SUCC = 4,          /* 底图采集成功 */
        NETDEV_MATCH_STATUS_BASE_MAP_COLLECT_FAIL = 5,          /* 底图采集失败 */
        NETDEV_MATCH_STATUS_INVALID = 0xff        /* 无效值 Invalid value */
    }

    /**
     * @enum tagNETDEVACSVisitStaus
     * @brief 访客状态
     * @attention 无 None
     */
    public enum NETDEV_ACS_VISIT_STATUS_E
    {
        NETDEV_ACS_VISIT_STATUS_SCHEDULE = 0,               /* 预约 */
        NETDEV_ACS_VISIT_STATUS_VISITING = 1,               /* 在访 */
        NETDEV_ACS_VISIT_STATUS_LEAVE = 2,               /* 离访 */
        NETDEV_ACS_VISIT_STATUS_SCHEDULE_CANCEL = 3,               /* 预约取消 */
        NETDEV_ACS_VISIT_STATUS_TIMEOUT = 4,               /* 超时 */

        NETDEV_ACS_VISIT_STATUS_INVALID = 0xFF             /* 无效值 */
    }

    /**
     * @enum tagNETDEVACSPersonType
     * @brief 人员类型
     * @attention 无 None
     */
    public enum NETDEV_ACS_PERSON_TYPE_E
    {
        NETDEV_ACS_PERSON_TYPE_STAFF = 0,               /* 员工 */
        NETDEV_ACS_PERSON_TYPE_VISITOR = 1,               /* 访客 */
        NETDEV_ACS_PERSON_TYPE_STRANGER = 2,               /* 陌生人 */

        NETDEV_ACS_PERSON_TYPE_INVALID = 0xFF             /* 无效值 */
    }

    /**
     * @enum tagNETDEVTimeTemplatePlanType
     * @brief 时间模板计划类型
     */
    public enum NETDEV_TIME_TEMPLATE_PLAN_TYPE_E
    {
        NETDEV_TIME_TEMPLATE_PLAN_COMMON = 0,                /* 常规存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION = 1,                /* 运动检测存储 */
        NETDEV_TIME_TEMPLATE_PLAN_ALARM = 2,                /* 告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION_AND_ALARM = 3,                /* 运动检测和告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION_OR_ALARM = 4,                /* 运动检测或告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MANUL = 5,                /* 手动存储 */
        NETDEV_TIME_TEMPLATE_PLAN_DISCONNECT = 6,                /* 断网报警 */
        NETDEV_TIME_TEMPLATE_PLAN_THIRD_STREAM = 7,                /* 第三流存储 */
        NETDEV_TIME_TEMPLATE_PLAN_VIDEO_LOSS = 8,                /* 视频丢失告警 */
        NETDEV_TIME_TEMPLATE_PLAN_AUDIODETECT = 9,                /* 音频检测 */
        NETDEV_TIME_TEMPLATE_PLAN_EVENT_ALL_ALARM = 10,               /* 事件类型，包涵所有告警类型 */
        NETDEV_TIME_TEMPLATE_PLAN_ALL_RECORD_TYPE = 11,               /* 所有录像类型 */

        NETDEV_TIME_TEMPLATE_PLAN_INVALID = 0xFF              /* 无效值 */
    }

    /**
     * @enum tagNETDEVAlarmPointActionType
     * @brief 报警点通道控制命令
     * @attention
     */
    public enum NETDEV_DOORCTRL_ACTION_TYPE_E
    {
        NETDEV_DOORCTRL_ACTION_TYPE_OPEN = 0,                /* 开门 */
        NETDEV_DOORCTRL_ACTION_TYPE_CLOSE = 1,                /* 关门 */

        NETDEV_DOORCTRL_ACTION_TYPE_INVALID = 0xFF              /* 无效值 */
    }

    /**
     * @enum tagNETDEVTimeTemplateType
     * @brief 时间模板类型
     * @attention 无 None
     */
    public enum NETDEV_TIME_TEMPLATE_TYPE_E
    {
        NETDEV_TIMETEMPLATE_TYPE_RECORD = 0,                /* 录像计划 */
        NETDEV_TIMETEMPLATE_TYPE_ALARM = 1,                /* 告警计划 */
        /* 2和3CS暂不使用，web端使用 2是用户时间模板， 3是微信小程序使用 */
        NETDEV_TIMETEMPLATE_TYPE_SEQUENCE = 4,                /* 轮巡 */
        NETDEV_TIMETEMPLATE_TYPE_ACS = 5,                /* 门禁管理 */
        NETDEV_TIMETEMPLATE_TYPE_INVALID = 0xFF              /* 无效 */
    }

    /**
     * @enum tagNETDEVACSPersonCommondType
     * @brief 门禁人员管理命令(添加和删除使用批量接口)
     * @attention
     */
    public enum NETDEV_ACS_PERSON_COMMOND_TYPE_E
    {
        NETDEV_ACS_PERSON_COMMOND_TYPE_GET = 0,                /* 获取 */
        NETDEV_ACS_PERSON_COMMOND_TYPE_MOD = 1,                /* 修改 */

        NETDEV_ACS_PERSON_COMMOND_TYPE_INVALID = 0xFF              /* 无效值 */
    }

    /**
    * @enum tagNETDEVPlayerRunInfoType
    * @brief 解码层上报运行信息的类型的枚举定义
    * @attention 无
    */
    public enum NETDEV_PLAYER_RUN_INFO_TYPE_E
    {
        NETDEV_PLAYER_RUN_INFO_RECORD_VIDEO        = 1,        /**< 本地录像过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PROCESS       = 2,        /**< 视频媒体处理过程中的上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_SERIES_SNATCH       = 3,        /**< 连续抓拍过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_VOICE         = 4,        /**< 语音业务过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_NOT_IDENTIFY  = 5,        /**< 码流无法识别 */
        NETDEV_PLAYER_RUN_INFO_RECV_PACKET_NUM     = 6,        /**< 周期内接收到的包数 */
        NETDEV_PLAYER_RUN_INFO_RECV_BYTE_NUM       = 7,        /**< 周期内接收到的字节数 */
        NETDEV_PLAYER_RUN_INFO_VIDEO_FRAME_NUM     = 8,        /**< 周期内解析的视频帧数 */
        NETDEV_PLAYER_RUN_INFO_AUDIO_FRAME_NUM     = 9,        /**< 周期内解析的音频帧数 */
        NETDEV_PLAYER_RUN_INFO_LOST_PACKET_RATIO   = 10,       /**< 周期内丢包率统计信息（单位为0.01%） */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PLAY_PROGRESS = 11,       /**< 媒体中携带的进度信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PLAY_END      = 12,       /**< 媒体中携带的播放结束 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_ABNORMAL      = 13,       /**< 媒体处理异常 */
        NETDEV_PLAYER_RUN_INFO_CODEC               = 14,       /**< 编解码器 */
        NETDEV_PLAYER_RUN_INFO_STREAM              = 15,       /**< 网络流或输入流播放 */
        NETDEV_PLAYER_RUN_INFO_PLAYBACK_FINISH     = 16,       /**< 回放结束 */
        NETDEV_PLAYER_RUN_INFO_SNATCH              = 17,       /**< 截图过程中的上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_INVALID             = 0xff
    }

    /**
    * @enum tagNetDEVFishEyePtzMode
    * @brief 鱼眼设备矫正模式枚举变量
    * @attention 无
    */
    public enum NETDEV_FISHEYE_PTZ_MODE_E
    {
        NETDEV_FISHEYE_MODE_ORIGINAL = 0,                /* 原始图像 */
        NETDEV_FISHEYE_MODE_180 = 1,                /* 2*180度模式 */
        NETDEV_FISHEYE_MODE_360_1PTZ = 2,                /* 360度+1PTZ模式 */
        NETDEV_FISHEYE_MODE_360_6PTZ = 3,                /* 360度+6PTZ模式 */
        NETDEV_FISHEYE_MODE_3PTZ = 4,                /* 鱼眼+3PTZ模式 */
        NETDEV_FISHEYE_MODE_MID_ON_4PTZ = 5,                /* 鱼眼图像在中间且显示+4PTZ模式 */
        NETDEV_FISHEYE_MODE_MID_OFF_4PTZ = 6,                /* 鱼眼图像在中间但不显示+4PTZ模式 */
        NETDEV_FISHEYE_MODE_LEFT_4PTZ = 7,                /* 鱼眼左边+4PTZ模式 */
        NETDEV_FISHEYE_MODE_8PTZ = 8,                /* 鱼眼+8PTZ模式 */
        NETDEV_FISHEYE_MODE_PANORAMA = 9,                /* 全景模式 */
        NETDEV_FISHEYE_MODE_PR_3PTZ = 10,               /* 全景+3PTZ模式 */
        NETDEV_FISHEYE_MODE_PR_4PTZ = 11,               /* 全景+4PTZ模式 */
        NETDEV_FISHEYE_MODE_PR_8PTZ = 12,               /* 全景+8PTZ模式 */
        NETDEV_FISHEYE_MODE_INVALID = 0xFF              /* 非法值 */
    };

    /**
    * @enum tagNETDEVfMouseMoveMode
    * @brief 鼠标移动模式
    * @attention 无
    */
    public enum NETDEV_MOUSE_MOVE_MODE_E
    {
        NETDEV_MOUSE_MOVE = 0,            /* 鼠标位移 */
        NETDEV_MOUSE_LEFT_BTN_DOWN = 1,            /* 左键按下 */
        NETDEV_MOUSE_LEFT_BTN_UP = 2,            /* 左键弹起 */
        NETDEV_MOUSE_WHEEL = 3,            /* 滚轮操作 */
        NETDEV_MOUSE_INVALID = 0xFF          /* 非法值 */
    };

    public enum NETDEV_ALARM_TYPE_V30_E
    {
        NETDEV_ALARM_RYPE_DEV_STATUS                = (0x1 << 0),         /* 设备状态类型告警 */
        NETDEV_ALARM_RYPE_COMM_ALARM                = (0x1 << 1),         /* 监控业务类告警 */
        NETDEV_ALARM_RYPE_INTEL_ALARM               = (0x1 << 2),         /* 泛智能告警 */
        NETDEV_ALARM_RYPE_SMART_ALARM               = (0x1 << 3),         /* 智能类告警 */
        NETDEV_ALARM_RYPE_FACE_RECOGNITION          = (0x1 << 4),         /* 人脸识别 NETDEV_SetPersonAlarmCallBack */
        NETDEV_ALARM_RYPE_STRUCTURED_DATA           = (0x1 << 5),         /* 结构化数 NETDEV_SetStructAlarmCallBack */
        NETDEV_ALARM_RYPE_VEHICLE_RECOGNITION       = (0x1 << 6),         /* 车牌识别 NETDEV_SetVehicleAlarmCallBack */
        NETDEV_ALARM_RYPE_TRAFFIC_DATA              = (0x1 << 7),         /* 交通数据 (暂未支持) */
        NETDEV_ALARM_RYPE_HYPERSENSITIVE_DATA       = (0x1 << 8),         /* 超感数据 (暂未支持) */
        NETDEV_ALARM_RYPE_RESOURCE_CHANGE           = (0x1 << 9),         /* 资源变更 NETDEV_SetResChangeEventCallBack */
        NETDEV_ALARM_RYPE_PERSON_VERIFICATION       = (0x1 << 10),        /* 人员核验 NETDEV_SetAlarmFGCallBack */
        NETDEV_ALARM_RYPE_PARKING_IDENTIFICATION    = (0x1 << 11),        /* 车场抓拍 NETDEV_SetParkEventCallBack */
        NETDEV_ALARM_RYPE_FIREALARM_DATA            = (0x1 << 12),        /* 火点告警 NETDEV_SetConflagrationAlarmCallBack */
        NETDEV_ALARM_RYPE_ALARM_PICTURE_DATA        = (0x1 << 13),        /* 告警图片数据 NETDEV_SetPicAlarmCallBack */
        NETDEV_ALARM_RYPE_PEOPLE_COUNT              = (0x1 << 14),        /* 人数统计 NETDEV_SetPeopleCountAlarmCallBack */
        NETDEV_ALARM_RYPE_HEATMAP_DATA              = (0x1 << 16),        /* 热度图数据 (暂未支持) */
        NETDEV_ALARM_RYPE_PLAYBOX_STATUS            = (0x1 << 17),        /* 播放盒状态 (暂未支持) */
        NETDEV_ALARM_RYPE_PLAYBOX_MANAGEMENT        = (0x1 << 18),        /* 播放盒管理设备在线状态(暂未支持)... */
        NETDEV_ALARM_RYPE_INVALID                   = 0xFF
    };

    public enum NETDEV_CROWD_DENSITY_STATISTIC_TYPE_E
    {
        NETDEV_CROWD_DENSITY_STATISTIC_TYPE_DENSITY = 1,                  /* 人员密度统计 */
        NETDEV_CROWD_DENSITY_STATISTIC_TYPE_STRANDED = 2,                 /* 滞留人数统计 */
        NETDEV_CROWD_DENSITY_STATISTIC_TYPE_INVALID = 0xff                /* 无效值 */
    };

    public enum NETDEV_OBJECT_RECORD_TYPE_E
    {
        NETDEV_OBJECT_RECORD_TYPE_CROSSLINE_DETECTION = 0,       /* 越界检测 */
        NETDEV_OBJECT_RECORD_TYPE_INTRUSION_DETECTION = 1,       /* 区域入侵 */
        NETDEV_OBJECT_RECORD_TYPE_ENTER_ZONE = 2,                /* 进入区域 */
        NETDEV_OBJECT_RECORD_TYPE_LEAVE_ZONE = 3,                /* 离开区域 */
        NETDEV_OBJECT_RECORD_TYPE_SMD = 4,                       /* SMD(智能运动检测) */
        NETDEV_OBJECT_RECORD_TYPE_INVALID = 0xff                 /* 无效值 */
    };

    public enum NETDEV_OBJECT_TYPE_E
    {
        NETDEV_OBJECT_TYPE_FACE = 1,                             /* 人脸 */
        NETDEV_OBJECT_TYPE_PERSON = 2,                           /* 人员 */
        NETDEV_OBJECT_TYPE_NON_MOTOR = 3,                        /* 非机动车 */
        NETDEV_OBJECT_TYPE_MOTOR = 4,                            /* 机动车 */
        NETDEV_OBJECT_TYPE_UNKNOWN = 255,                        /* 未知/未识别的目标类型 */
        NETDEV_OBJECT_TYPE_INVALID = 0xffff                      /* 无效值 */
    };

    /**
     * @enum tagNETDEVReportPicDataType
     * @brief 上报图片数据类型 
     * @attention 无 None
     */
    public enum NETDEV_REPORT_PIC_DATA_TYPE_E
    {
        NETDEV_REPORT_PIC_DATA_TYPE_BASE64 = 0,       /* base64编码的图片数据 */
        NETDEV_REPORT_PIC_DATA_TYPE_URL = 1,       /* 图片URL */
        NETDEV_REPORT_PIC_DATA_TYPE_CLOUDSTORAGE = 2,       /* 云存储图片 */
        NETDEV_REPORT_PIC_DATA_TYPE_INVALID = 0xff     /* 无效值 */
    };

    /**
     * @enum NETDEV_TEMPERATURE_TYPE_E
     * @brief 温度告警值类型 
     * @attention 无 None
     */
    public enum NETDEV_TEMPERATURE_TYPE_E
    {
        NETDEV_TEMPERATURE_TYPE_MAX = 1,       /* 最高温 */
        NETDEV_TEMPERATURE_TYPE_MIN = 2,       /* 最低温 */
        NETDEV_TEMPERATURE_TYPE_AVERAGE = 3,       /* 平均温 */
        NETDEV_TEMPERATURE_TYPE_DIFFERENCE = 4,       /* 温度差值 */
        NETDEV_TEMPERATURE_TYPE_CHANGE_RATE = 5,       /* 温度变化率 */
        NETDEV_TEMPERATURE_TYPE_INVALID = 0xff     /* 无效值 */
    };

    /**
     * @enum tagNETDEVPeopleCountAlarmType
     * @brief 人数统计告警类型
     * @attention 
     */
    public enum NETDEV_PEOPLE_COUNT_ALARM_TYPE_E
    {
        NETDEV_PEOPLE_COUNT_ALARM_TYPE_AREA_RULE        = 0,               /* 区域规则 */
        NETDEV_PEOPLE_COUNT_ALARM_TYPE_LINE_RULE        = 1,               /* 绊线规则 */
        NETDEV_PEOPLE_COUNT_ALARM_TYPE_CROWD_DENSITY    = 2,               /* 人员密度 */
        NETDEV_PEOPLE_COUNT_ALARM_TYPE_INVALID          = 0xFFFF           /* 无效值 */
};


    /* define enum end */

    /* define struct start */

    //
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_INFO_S
    {
        public Int32 dwDevType;
        public Int16 wAlarmInputNum;                   /* Number of alarm inputs */
        public Int16 wAlarmOutputNum;                  /* Number of alarm outputs */
        public Int32 dwChannelNum;                      /* Number of Channels */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_FIREWARE_INFO_S
    {    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szDevModel;       /* 设备型号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szFireVersion;    /* 软件版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szSerialNum;      /* 设备序列号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string    byRes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_INFO_V30_S
    {
        public NETDEV_DEV_BASIC_INFO_S stDevBasicInfo;             /* 设备基本信息 */
        public NETDEV_DEV_FIREWARE_INFO_S stDevFirewareInfo;       /* 设备固件信息 */
    }

    /**/
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_S
    {
        public Int32   dwAlarmType;                    /* ,#NETDEV_ALARM_TYPE_E  Alarm type, see enumeration #NETDEV_ALARM_TYPE_E */
        public Int64   tAlarmTime;                     /* Alarm time */
        public Int32   dwChannelID;                    /* ,NVR  Channel ID for NVR */
        public UInt16  wIndex;                         /* ,  Index number,  disk slot index number */
        public string  pszName;                       /* , Alarm source name, alarm input/output name */
        public Int32   dwTotalBandWidth;               /* ,MBps */
        public Int32   dwUnusedBandwidth;              /* ,MBps */
        public Int32   dwTotalStreamNum;               /* */
        public Int32   dwFreeStreamNum;                /* */
        public Int32   dwReserved;                     /* 异常上报保留参数，用于上报解码层保留参数 */
        public Int32   dwEventCode;                    /* 事件类型，用于上报解码层事件类型，参见枚举#NETDEV_PLAYER_RUN_INFO_TYPE_E */
        public Int32   dwMediaMode;                    /* ,#NETDEV_MEDIA_MODE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string  byRes;                          /* Reserved */
    }

    /**/
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISCOVERY_DEVINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevAddr;                            /* Device address */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevModule;                          /* Device model */  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevSerailNum;                       /* Device serial number */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevMac;                             /* MAC  Device MAC address */ 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevName;                            /* Device name */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szDevVersion;                         /* Device version */
        public NETDEV_DEVICETYPE_E  enDevType;                              /* Device type */
        public Int32   dwDevPort;                                           /* Device port number */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szManuFacturer;                       /* Device manufacture */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szActiveCode;                         /* activeCode */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string    szCloudUserName; 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 68)]
        public string    byRes;                                          /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_CHL_DETAIL_INFO_S
    {
        public Int32 dwChannelID;
        public Int32 bPtzSupported;          /* Whether ptz is supported */
        public Int32 enStatus;        /* Channel status */    
        public Int32 dwStreamNum;     /* Number of streams */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public string szChnName;                       /* Device serial number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_LIST_S
    {
        public Int32 udwNum;                /* Channel Num */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public Int32[] audwChannelList;     /* channel list*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                          /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_TIME_S
    {
        public Int32 udwChlID;                   /* ID */
        public Int64 tEarliestTime;              /* Earliest Time */
        public Int64 tLatestTime;                /* Latest Time */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                          /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_TIME_LIST_S
    {
        public Int32 udwNum;                /* Channel Num */
        public IntPtr pstRecordTimes;       /* Record time list, #NETDEV_RECORD_TIME_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                          /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PREVIEWINFO_S
    {
        public Int32 dwChannelID;                    /* ID  Channel ID */
        public Int32 dwStreamType;                   /* #NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwLinkMode;                     /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                      /* Play window handle */
        public Int32 dwFluency;                      /* #NETDEV_PICTURE_FLUENCY_E  image play fluency*/
        public Int32 dwStreamMode;                   /* #NETDEV_STREAM_MODE_E  start stream mode see #NETDEV_STREAM_MODE_E*/
        public Int32 dwLiveMode;                     /* #NETDEV_PULL_STREAM_MODE_E  Rev. Flow pattern */
        public Int32 dwDisTributeCloud;              /* #NETDEV_DISTRIBUTE_CLOUD_SRV_E distribution  */
        public Int32 dwallowDistribution;                    /* allow or no distribution*/
        public Int32 dwTransType;                    /* 传输类型，参见枚举# NETDEV_TRANS_TYPE_E */
        public Int32 dwStreamProtocol;               /* 起流协议，参见枚举# NETDEV_START_STREAM_PROT_E */
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 236)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IRIS_INFO_S
    {
        public Int32 udwIris;       /* 光圈,在光圈优先、手动曝光模式下可选。光圈支持的取值:160， 200， 240， 280， 340， 400， 480， 560， 680， 800， 960， 1100，1400,  1600,  2200*/
        public Int32 udwMinIris;    /* 最小光圈值 自定义曝光模式下可用，枚举同 Iris能力集所描述，不得大于光圈最大值。图像能力集支持该功能，此字段必选。*/
        public Int32 udwMaxIris;    /* 最大光圈值 自定义曝光模式下可用，枚举同 Iris能力集所描述，不得小于光圈最小值。图像能力集支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SHUTTER_INFO_S
    {
        public Int32 udwShutterTime;       /* 快门时间 枚举见#NETDEV_SHUTTER_TIME_RANGE_E,快门时间单位  0：微秒 1：秒*/
        public Int32 udwMinShutterTime;    /* 快门时间最小值 MinShutter 枚举见#NETDEV_SHUTTER_TIME_RANGE_E*/
        public Int32 udwMaxShutterTime;    /* 快门时间最大值 MaxShutter 枚举见#NETDEV_SHUTTER_TIME_RANGE_E*/
        public Int32 udwIsEnableSlowShutter;  /* 慢快门使能。非光圈优先模式下可用：0：不使能  1：使能*/
        public Int32 udwSlowestShutter; /* 最慢慢快门,慢快门使能后可用。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GAIN_INFO_S
    {
        public Int32 udwGain;         /* 增益值（单位:db）手动曝光模式下可用。范围[1,100]*/
        public Int32 udwMinGain;      /* 增益最小值 ,自定义曝光模式下可用，不得大于增益最大值。最小值为1*/
        public Int32 udwMaxGain;      /* 增益最大值 , 自定义曝光模式下可用，不得小于增益最小值。最大值为100*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_TOP_LEFT_S
    {
        public Int32 dwTopLeftX;     /* 左上角横坐标(比例)：区域测光模式范围: [0, 100]。Upper left corner X [0, 100]  */
        public Int32 dwTopLeftY;     /* 左上角纵坐标(比例)：区域测光模式范围: [0, 100]。Upper left corner Y [0, 100]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_BOT_RIGHT_S
    {
        public Int32 dwBottomRightX;     /* 左上角横坐标(比例)：区域测光模式范围: [0, 100]  Lower right corner x [0, 100] */
        public Int32 dwBottomRightY;     /* 左上角纵坐标(比例)：区域测光模式范围: [0, 100]  Lower right corner y [0, 100] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_METERING_AREA_S
    {
        public NETDEV_AREA_TOP_LEFT_S stAreaTopLeft;           /* 左上角区域  结构体见#NETDEV_AREA_TOP_LEFT_S*/
        public NETDEV_AREA_BOT_RIGHT_S stAreaBotRight;          /* 右下角区域  结构体见#NETDEV_AREA_BOT_RIGHT_S*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_METERING_INFO_S
    {
        public Int32 udwMeteringMode;                 /* 测光控制模式,此字段在非手动曝光模式下可用。枚举详见#NETDEV_DAY_NIGHT_MODE_E*/
        public Int32 udwRefBrightness;                /* 人脸亮度。人脸测光模式下可用。范围：[0, 100]。*/
        public Int32 udwHoldTime;                     /* 最短持续时间。人脸测光模式下可用。单位：分钟。范围：[0, 60]。*/
        public NETDEV_METERING_AREA_S stMeteringArea;  /* 测光区域 ,在测光模式为区域测光及点测光时，此字段可用*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DAY_NIGHT_INFO_S
    {
        public Int32 udwDayNightMode;                 /* 昼夜模式类型 DayNightMode 枚举参见#NETDEV_DAY_NIGHT_MODE_E*/
        public Int32 udwDayNightSensitivity;          /* 昼夜模式灵敏度 DayNightSensitivity 在昼夜模式为自动模式下可用，范围[0, 9]。若图像能力支持该功能，此字段必选。*/
        public Int32 udwDayNightTime;                 /* 昼夜模式切换时间，在昼夜模式为自动模式下可用。范围[3, 120]。单位秒。若图像能力支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_WIDE_DYNAMIC_INFO_S
    {
        public Int32 udwWideDynamicMode;              /* 宽动态模式 WideDynamicMode 枚举详见#NETDEV_WIDE_DYNAMIC_MODE_E*/
        public Int32 udwWideDynamicLevel;             /* 宽动态级别配置，宽动态开启且在曝光模式为自动模式、自定义、快门优先、室内50HZ、室内60HZ、低拖影下可用。范围[1, 9]。*/
        public Int32 udwOpenSensitivity;              /* 宽动态开启的灵敏度。宽动态模式为自动下可用。范围[1, 9]。*/
        public Int32 udwCloseSensitivity;             /* 宽动态关闭的灵敏度。宽动态模式为自动下可用。范围[1, 9]。*/
        public Int32 udwAntiFlicker;                    /* 宽动态条纹抑制：0：关闭 1：开启该功能开启后，可消除图像中的条纹效应。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_EXPOSURE_S
    {
        public Int32 udwMode;                /* 曝光模式  Exposure Mode 枚举详见#NETDEV_EXPOSURE_MODE_E*/
        public Int32 dwCompensationLevel;    /* 曝光补偿级别,曝光模式为非手动曝光模式时可用。范围[-100,100].图像能力集支持该功能，此字段必选 */
        public Int32 udwHLCSensitivity;      /* 强光抑制灵敏度，当前场景为道路强光抑制及园区强光抑制时可用,范围[1,9]。 图像能力集支持该功能，此字段必选 */
        public NETDEV_IRIS_INFO_S stIrisInfo;             /* 光圈信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_SHUTTER_INFO_S stShutterInfo;          /* 快门信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_GAIN_INFO_S stGainInfo;             /* 增益信息。*/
        public NETDEV_WIDE_DYNAMIC_INFO_S stWideDynamicInfo;      /* 宽动态信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_METERING_INFO_S stMeteringInfo;         /* 测光信息。当前场景不是道路强光抑制及园区强光抑制时可用。图像能力集支持该功能，此字段必选。*/
        public NETDEV_DAY_NIGHT_INFO_S stDayNightInfo;         /* 昼夜模式信息。图像能力集支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szReserve;                    /* Reserved */
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILECOND_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public String szFileName;                    /* Recording file name */
        public Int32 dwChannelID;                    /* Channel ID */
        public Int32 dwStreamType;                   /* #NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwFileType;                     /* Recording storage type, see enumeration # NETDEV_PLAN_STORE_TYPE_E */
        public Int64 tBeginTime;                     /* Start time */
        public Int64 tEndTime;                       /* End time */
        public Int32 dwRecordLocation;               /* Record Position, see enumeration# NETDEV_RECORD_LOCATION_E */
        public Int32 udwServerID;                    /* 录像所属服务器ID Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] szReserve;                    /* Reserved */
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FINDDATA_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String    szFileName;               /* Recording file name */
        public Int64 tBeginTime;                                    /* Start time */
        public Int64 tEndTime;                                      /* End time */
        public byte byFileType;                                     /* Recording storage type */
        public UInt32   udwServerID;                                /* 录像所属服务器ID */
        public UInt32   udwFileSize;                                /* Recording file size */
        public Int32    dwFileType;                                 /* 文件类型，参考# NETDEV_RECORD_SEARCH_TYPE_E ，暂内部使用 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 159)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_260)]
        public String    szName;         /* Playback control block name*/
        public Int64   tBeginTime;                     /* Playback start time */
        public Int64   tEndTime;                       /* Playback end time */
        public Int32   dwLinkMode;                     /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr  hPlayWnd;                       /* Play window handle */
        public Int32   dwFileType;                     /* #NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32   dwDownloadSpeed;                /* #NETDEV_E_DOWNLOAD_SPEED_E  Download speed, see enumeration #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32   dwStreamMode;                 /* stream mode see #NETDEV_STREAM_MODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] szReserve;                    /* Reserved */
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(IntPtr lpUserID, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKCOND_S
    {
        public Int32 dwChannelID;                /* Playback channel */
        public Int64 tBeginTime;                 /* Playback start time */
        public Int64 tEndTime;                   /* Playback end time */
        public Int32 dwLinkMode;                 /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                   /* Play window handle */
        public Int32 dwFileType;                 /*#NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;            /* #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32 dwStreamMode;                 /* stream mode see #NETDEV_STREAM_MODE_E */
        public Int32 dwStreamIndex;              /* 存储码流类型, 参见枚举#NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwRecordLocation;           /* 录像存储位置 Record Position, 参见枚举#NETDEV_RECORD_LOCATION_E */
        public Int32 dwTransType;                /* 传输类型，参见枚举#NETDEV_TRANS_TYPE_E */
        public Int32 bCloudStorage;              /* 是否开启云存储回放模式 */
        public Int32 bOneFrameEnable;            /* 是否开启单帧解码模式，开启后对解码效率有影响 */
        public Int32 dwPlaySpeed;                /* Playback speed, see enumeration #NETDEV_VOD_PLAY_STATUS_E*/
        NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCALLBACK;       /*  Decode data callback function */
        public Int64 tPlayTime;                  /* Playback time */
        public UInt32 udwServerID;                /* Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
        public byte[] szReserve;                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_SMART_DETAILS_INFO_S
    {
        public Int32 udwAttributeID;                                /* 属性ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szAttributeName;                              /* 属性名称 */
        public Int32 udwStatus;                                     /* 状态 参见枚举#NETDEV_HDD_SMART_ASSESSMENT_STATUS_E */
        public Int32 udwHex;                                        /* 显示为十六进制 */
        public Int32 udwThresh;                                     /* 阈值 */
        public Int32 udwCurrentValue;                               /* 当前值 */
        public Int32 udwWorstValue;                                 /* 最差值 */
        public Int32 udwActualValue;                                /* 实际值 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_INFO_S
    {
        public Int32 udwID;                                 /* 磁盘编号 */
        public Int32 udwType;                               /* 磁盘类型 参见枚举#NETDEV_HDD_TYPE_E */
        public Int32 udwWorkMode;                           /* 磁盘工作模式 参见枚举#NETDEV_HDD_WORK_MODE_E */
        public Int32 udwTotalCapacity;                      /* 硬盘总容量(MB) Total Capacity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szRAIDName;                          /* 阵列名称 */
        public Int32 udwStatus;                            /* 磁盘状态 参见枚举#NETDEV_HDD_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szManufacturer;                      /* 厂商名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STORAGE_CONTAINER_INFO_S
    {
        public Int32 udwID;                                 /* 磁盘编号 */
        public Int32 udwRemainCapacity;                     /* 存储容器剩余容量(MB) */
        public Int32 udwTotalCapacity;                      /* 存储容器总容量(MB) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szManufacturer;                       /* 厂商名称 */
        public Int32 udwStatus;                             /* 存储容器状态 参见枚举#NETDEV_STORAGE_CONTAINER_STATUS_E */
        public Int32 udwProperty;                           /* 存储盘属性,当udwStatus为0时无效 参见枚举#NETDEV_STORAGE_CONTAINER_PROPERTY_E */
        public Int32 udwFormatProgress;                     /* 格式化进度，百分比 */
        public Int32 udwGroupID;                            /* 盘组序号 */
        public Int32 udwTemperature;                        /* 硬盘温度(摄氏度) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S
    {
        public Int32 udwID;                                 /* 磁盘编号 */
        public Int32 udwRemainCapacity;                     /* 存储容器剩余容量(MB) */
        public Int32 udwTotalCapacity;                      /* 存储容器总容量(MB) */
        public Int32 udwAddressType;                        /* IP地址类型,参见枚举#NETDEV_ADDR_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szIPAddress;                          /* 服务器IP地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szPath;                               /* NAS服务器存储路径 */
        public Int32 udwUsageType;                          /* 用途,参见枚举#NETDEV_STORAGE_CONTAINER_USAGE_TYPE_E */
        public Int32 udwStatus;                             /* 存储容器状态 参见枚举#NETDEV_STORAGE_CONTAINER_STATUS_E */
        public Int32 udwProperty;                           /* 存储盘属性,当udwStatus为0时无效 参见枚举#NETDEV_STORAGE_CONTAINER_PROPERTY_E */
        public Int32 udwFormatProgress;                     /* 格式化进度，百分比 */
        public Int32 udwGroupID;                            /* 盘组序号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STORAGE_CONTAINER_INFO_LIST_S
    {
        public Int32 udwLocalHDDNum;                                        /* 本地硬盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LOCAL_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astLocalHDDList;           /* 本地存储盘信息列表 */
        public Int32 udwSDNum;                                              /* SD卡数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SD_CARD_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astSDList;                 /* SD卡信息列表 */
        public Int32 udwArrayNum;                                           /* 阵列数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_ARRAY_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astArrayList;              /* 阵列信息列表 */
        public Int32 udwExtendCabinet1HDDNum;                               /* 拓展柜-1存储盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_EXTEND_CABINET_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astExtendCabinet1HDDList;  /* 拓展柜-1 信息列表 */
        public Int32 udwExtendCabinet2HDDNum;                               /* 拓展柜-2存储盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_EXTEND_CABINET_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astExtendCabinet2HDDList;  /* 拓展柜-2 信息列表 */
        public Int32 udwNASNum;                                             /* NAS数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAS_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] astNASList;         /* NAS信息列表 */
        public Int32 udweSATANum;                                           /* eSATA硬盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_ESATA_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] asteSATAList;      /* eSATA信息列表 */
        public Int32 udwIPSANNum;                                           /* IPSAN数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_ESATA_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] astIPSANList;      /* IPSAN信息列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_INFO_LIST_S
    {
        public Int32 dwSize;                             /* 硬盘个数 Disk number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public NETDEV_HDD_INFO_S[] astHDDInfo;          /* 硬盘信息 Disk info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                        /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RAID_STATUS_S
    {
        public Int32 bEnabled;                  /* 阵列状态使能 0:不使能 1:使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_SMART_INFO_S
    {
        public Int32 udwID;                                         /* IN 存储容器编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szManufacturer;                               /* 厂商名称 */
        public Int32 udwTemperature;                                /* 温度(℃) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szDeviceModel;                                /* 硬盘型号 */
        public Int32 udwUsedDays;                                   /* 使用天数 */
        public Int32 udwHealthAssessment;                           /* 整体评估结果 参见枚举#NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFirmware;                                   /* 硬盘固件版本 */
        public Int32 udwSmartNum;                                  /* Smart详情项数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DISK_SMART_MAX_NUM)]
        public NETDEV_HDD_SMART_DETAILS_INFO_S[] SmartDetailsInfoList;          /* Smart详情项列表 */
        public Int32 bCheckResult;                                 /* 自我评估结果, 1 通过，0 未通过 */
        public Int32 udwCheckPrograss;                             /* 检测进度 [0,100] */
        public Int32 udwCheckStatus;                               /* 检测状态 参见枚举#NETDEV_HDD_SMART_CHECK_STATUS_E */
        public Int32 udwCheckType;                                 /* 检测类型 参见枚举#NETDEV_HDD_SMART_CHECK_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PRESET_S
    {
        public Int32 dwPresetID;                                 /* ID  Preset ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szPresetName;    /** Preset name */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ALLPRESETS_S
    {
        public Int32               dwSize;                             /* Total number of presets */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEMO.NETDEV_MAX_PRESET_NUM)]
        public NETDEV_PTZ_PRESET_S[] astPreset;   /* Structure of preset information */
    }

    public struct NETDEV_PTZ_TRACK_INFO_S
    {
        public Int32 dwTrackNum;                                               /* Number of existing patrol routes */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public String  TrackName;  /* Route name */
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_INFO_S
    {
        public Int32 dwCuriseID;                                     /* ID  Route ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szCuriseName;                    /* Route name */
        public Int32 dwSize;                                         /* Number of presets included in the route */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_CRUISEPOINT_NUM)]
        public NETDEV_CRUISE_POINT_S[] astCruisePoint;     /* Information of presets included in the route */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NETWORKCFG_S
    {
        public Int32 dwMTU;                                         /* MTU value */
        public Int32 dwIPv4DHCP;                                    /* DHCP of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string Ipv4AddressStr;                                /* IP address of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szIPv4GateWay;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szIPv4SubnetMask;                          /* Gateway of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 480)]
        public byte[] byRes;                                        /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_NAT_STATE_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_UPNP_PORT_STATE_S[] astUpnpPort;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_PORT_STATE_S
    {
        public NETDEV_PROTOCOL_TYPE_E eType;
        public Int32 bEnbale;
        public Int32 dwPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_IPADDR_S
    {
        public Int32 eIPType;                            /* #NETDEV_HOSTTYPE_E  Protocol type, see enumeration #NETDEV_HOSTTYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_132)]
        public string szIPAddr;           /* IP  IP address */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_S
    {
        public NETDEV_LIVE_STREAM_INDEX_E enStreamType;       /* Stream index */
        public Int32 bEnableFlag;        /* Enable or not */
        public Int32 dwHeight;           /* -Height  Video encoding resolution - Height */
        public Int32 dwWidth;            /* -Width  Video encoding resolution - Width */
        public Int32 dwFrameRate;        /* Video encoding configuration frame rate */
        public Int32 dwBitRate;          /* Bit rate */
        public NETDEV_VIDEO_CODE_TYPE_E enCodeType;         /* Video encoding format */
        public NETDEV_VIDEO_QUALITY_E enQuality;          /* Image quality */
        public Int32 dwGop;              /* I  I-frame interval */
        public Int32 bConstantBitRate;   /* Constant Bit Rate or Variable bit rate;0:Variable 1:Constant*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] byRes;                            /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_LIST_S
    {
        public UInt32 udwNum;                                /* Number of video stream */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_VIDEO_STREAM_INFO_EX_S astVideoStreamInfoList;/* Video stream list*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_EX_S
    {
        public string  bEnabled;                                                                  /* 视频流是否启用编码 Enable encoding for video stream or not*/
        public UInt32 udwStreamID;                                                             /* 码流索引，参见枚举NETDEV_LIVE_STREAM_INDEX_E。 Stream index. For enumeration, seeNETDEV_LIVE_STREAM_INDEX_E*/
        public UInt32 udwMainStreamType;                                                       /* 主码流类型，参见NETDEV_MAIN_STREAM_TYPE_E。 Main stream. See NETDEV_MAIN_STREAM_TYPE_E for reference */
        public NETDEV_VIDEO_ENCODE_INFO_S stVideoEncodeInfo;                                   /* 视频编码参数信息 Video encoding parameter*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_ENCODE_INFO_S
    {
        public string bEnableSVCMode;                        /* SVC配置,0：关闭,1：开启 SVC configuration. 0-Off, 1-On*/
        public UInt32 udwEncodeFormat;                     /* 视频编码格式信息，参见枚举NETDEV_VIDEO_CODE_TYPE_E。  Video Compression. For enumeration, seeNETDEV_VIDEO_CODE_TYPE_E*/
        public UInt32 udwWidth;                            /* 图像宽度 Image width*/
        public UInt32 udwHeight;                           /* 图像高度 Image height*/
        public UInt32 udwBitrate;                          /* 码率 Bit rate*/
        public UInt32 udwBitrateType;                      /* 码率类型，参见NETDEV_BIT_RATE_TYPE_E。 Bitrate type. See NETDEV_BIT_RATE_TYPE_E for reference */
        public UInt32 udwFrameRate;                        /* 帧率 Frame rate*/
        public UInt32 udwGopType;                          /* Gop模式,参见NETDEV_GOP_TYPE_E。 GOP mode. See NETDEV_GOP_TYPE_E for reference */
        public UInt32 udwIFrameInterval;                   /* I帧间隔，范围根据能力来定 I Frame Interval. The range depends on capability*/
        public UInt32 udwImageQuality;                     /* 图像质量，范围[1, 9]，9代表图像质量最高 Image quality, ranges from 1 to 9. 9 means the highest quality*/
        public UInt32 udwSmoothLevel;                      /* 码流平滑等级，范围[1,9]，1代表平滑级别最低 Smoothing level, ranges from 1 to 9. 1 means the lowest level*/
        public UInt32 udwSmartEncodeMode;                  /* 智能编码模式，参见NETDEV_SMART_ENCODE_MODE_E。 Smart encoding mode. See NETDEV_SMART_ENCODE_MODE_E for reference*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_MODE_INFO_S
    {
        public Int32 udwWidth;                                      /* 图像宽度 Image width*/
        public Int32 udwHeight;                                     /* 图像高度 Image height*/
        public Int32 udwFrameRate;                                  /* 图像帧率 Image frame rate*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IRCUT_FILTER_INFO_S
    {
        public Int32 udwIrCutFilterMode;                            /* 昼夜模式：0白天，1，夜晚，2自动 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;                                        /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_CONTENT_STYLE_S
    {
        public UInt32 udwFontStyle;                         /* 字体形式，参见枚举NETDEV_OSD_FONT_STYLE_E。  Font style. For enumeration, seeNETDEV_OSD_FONT_STYLE_E*/
        public UInt32 udwFontSize;                          /* 字体大小，参见枚举NETDEV_OSD_FONT_SIZE_E。  Font Size. For enumeration, seeNETDEV_OSD_FONT_SIZE_E*/
        public UInt32 udwColor;                             /* 颜色 Color*/
        public UInt32 udwDateFormat;                        /* 日期格式，参见枚举NETDEV_OSD_DATE_FORMAT_E。  Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
        public UInt32 udwTimeFormat;                        /* 时间格式，参见枚举NETDEV_OSD_TIME_FORMAT_E。  Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_8)]
        public UInt32 audwFontAlignList;                   /* 区域内字体对齐，固定8个区域，IPC支持,参见枚举NETDEV_OSD_ALIGN_E。  Font align in area, 8 areasfixed, IPcamera supported. For enumeration, seeNETDEV_OSD_ALIGN_E */
        public UInt32 udwMargin;                            /* 边缘空的字符数，IPC支持，参见枚举NETDEV_OSD_MIN_MARGIN_E。  Number of character with margin, IP camera supported. For enumeration, seeNETDEV_OSD_MIN_MARGIN_E */

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEFOGGING_INFO_S
    {
        public Int32 dwDefoggingMode;              /* 除雾模式 Defogging mode (0:On 1:Off) */
        public float fDefoggingLevel;              /* 除雾等级 Defogging level (0.0, 1.0) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                            /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_SETTING_S
    {
        public Int32 dwContrast;                   /* Contrast */
        public Int32 dwBrightness;                 /* Brightness */
        public Int32 dwSaturation;                 /* Saturation */
        public Int32 dwSharpness;                  /* Sharpness */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                            /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TEXT_OVERLAY_S
    {
        public Int32 bEnableFlag;                /** OSD, BOOL_TRUE,BOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public NETDEV_AREA_SCOPE_S     stAreaScope;                /** OSD * OSD text overlay area coordinates */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TEXT_MAX_LEN)]
        public byte[]                    OSDText;    /** OSD * OSD text overlay name strings */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] byRes;                            /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_OSD_CFG_S
    {
        public NETDEV_OSD_TIME_S         stTimeOSD;        /* OSD  Information of channel time OSD */
        public NETDEV_OSD_TEXT_OVERLAY_S stNameOSD;        /* OSD  Information of channel name OSD */
        public Int16                     wTextNum;         /* OSD  Text OSD number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TEXTOVERLAY_NUM)]
        public NETDEV_OSD_TEXT_OVERLAY_S[] astTextOverlay;   /* OSD  Information of channel OSD text overlay */
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_LIST_S
    {
        public Int32 dwSize;                                           /* Number of input alarms */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_ALARM_IN_NUM)]
        public NETDEV_ALARM_INPUT_INFO_S[] astAlarmInputInfo;       /* Configuration information of input alarms */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szName;                                           /* Boolean name */
        public Int32 dwChancelId;                                       /* Channel number */
        public Int32 enDefaultStatus;                                   /* Default status of boolean output, see enumeration #NETDEV_BOOLEAN_MODE_E */
        public Int32 dwDurationSec;                                     /* Alarm duration (s) */
        public Int32 dwOutputNum;                                       /* Alarm output serial number */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szName;                                                  /* Name of input alarm */
    }

    /**
 * @struct tagPrivacyMaskPara
 * @brief  Privacy mask configuration information
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_CFG_S
    {
        public Int32 dwSize;                                     /* Mask area number */ 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_PRIVACY_MASK_AREA_NUM)]
        public NETDEV_PRIVACY_MASK_AREA_INFO_S[] astArea;  /* Mask area parameters */
    }

    /**
 * @struct tagAreaInfo
 * @brief  Definition of area configuration structure 
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
    {
        public Int32 bIsEanbled;           /* Enable or not. */
        public Int32 dwTopLeftX;           /* X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* Y [0, 10000]  Lower right corner y [0, 10000] */
        public Int32 dwIndex;              /* Index. */
    }

    public struct Int16Array 
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_COLUMN)]
        public Int16[] data; 
    }

    /**
 * @struct tagNETDEVMotionAlarmInfo
 * @brief 
 * @attention  None
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MOTION_ALARM_INFO_S
    {
        public Int32   dwSensitivity;                                                     /* Sensitivity */
        public Int32   dwObjectSize;                                                      /* Objection Size */
        public Int32   dwHistory;                                                         /* History */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_ROW)]
        public Int16Array[] awScreenInfo;    /* Screen Info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                            /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TAMPER_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                               /* Sensitivity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* Reserved */
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_BASICINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szDevModel;                     /* Device model */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szSerialNum;                    /* Hardware serial number */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szFirmwareVersion;              /* Software version */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szMacAddress;                   /* IPv4Mac  MAC address of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szDeviceName;                   /* Device name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szManufacturer;                 /* Manufacturer */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 384)]
        public byte[] byRes;                                    /* Reserved */
    }

    public struct NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S
    {
        public Int32 dwChannelID;                  /* Channel ID */
        public Int64 tReportTime;                  /* unix Report time */
        public Int32 tInterval;                    /* Interval time */
        public Int32 dwEnterNum;                   /* Enter num */
        public Int32 dwExitNum;                    /* Exit num */
        public Int32 dwTotalEnterNum;              /* Total enter num */
        public Int32 dwTotalExitNum;               /* Total exit num */
    }

    public struct NETDEV_TRAFFIC_STATISTICS_COND_S
    {
        public Int32 dwChannelID;            /* Channel ID */
        public Int32 dwStatisticsType;       /* # NETDEV_TRAFFIC_STATISTICS_TYPE_E Statistics type */
        public Int32 dwFormType;             /* # NETDEV_FORM_TYPE_E Form type */
        public Int64 tBeginTime;             /* Begin time */
        public Int64 tEndTime;               /* End time */
    }

    public struct NETDEV_TRAFFIC_STATISTICS_DATA_S
    {
        public Int32  dwSize;                                          /* */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[]  adwEnterCount;        /* */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[]  adwExitCount;         /* */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECT_S
    {
        public Int32 dwLeft;                               /* X axis left point value [0,10000] */
        public Int32 dwTop;                                /* Y axis top point value [0,10000] */
        public Int32 dwRight;                              /* X axis right point value [0,10000] */
        public Int32 dwBottom;                             /* Y axis bottom point value [0,10000] */
    }

    /*multi traffic statistics*/
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_INFO_S
    {
        public Int32 dwID;                 /* ID */
        public Int32 dwReturnCode;         /* Return Code */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;               /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_LIST_S
    {
        public Int32 dwSize;                  /*Size */
        public IntPtr pstOperateInfo;         /*Need to be dynamically allocated memory (see # NETDEV_OPERATE_INFO_S) */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S
    {
        public NETDEV_OPERATE_LIST_S stChannelIDs; /* Channel ID List*/
        public UInt32 udwStatisticsType;           /* # NETDEV_TRAFFIC_STATISTICS_TYPE_E Statistics type */
        public UInt32 udwFormType;                 /* # NETDEV_TRAFFIC_STATIC_FORM_TYPE_E Form type */
        public Int64 tBeginTime;                   /* Begin time */
        public Int64 tEndTime;                     /* End time */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                       /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TRAFFIC_STATISTICS_INFO_S
    {
        public Int32 bIsSuccess;                   /* The success of the query*/
        public Int32 dwChannelID;                  /* Channel ID  */
        public Int32 dwSize;                       /* Number of periods */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwEnterCount;              /* Enter the number of statistics */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwExitCount;               /* Leave the number of statistics */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] byRes;                       /* Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_RULE_COUNT_DATA_S
    {
        public UInt32 udwAreaID;                                              /* 检测区域ID号，从0开始 */
        public UInt32 udwObjectNum;                                           /* 区域规则当前人数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PEOPLE_COUNT_AREA_RULE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public string szReference;                                            /* 描述信息 */
        public Int64 tTimeStamp;                                              /* 告警时间 从1970年1月1日0点开始的秒数 */
        public UInt32 udwSeq;                                                 /* 告警序号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szDeviceID;                                             /* 相机编码或域编码，回传事件订阅下发的设备编码，当事件订阅接口中携带设备编码时必填 */
        public UInt32 udwChannelID;                                           /* 通道号，从0开始 */
        public UInt32 udwAreaNum;                                             /* 区域规则数量，从0开始，0代表无区域规则上报 */
        public IntPtr pstAreaRuleCountDataList;                               /* 区域规则统计数据, 需动态申请内存 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINE_RULE_COUNT_DATA_S
    {
        public UInt32 udwLineID;                                              /* 伴线ID号，从0开始 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szBeginPassTime;                                        /* 检测开始时间：YYYYMMDDHHMMSS，时间按24小时制。字符串长度[0,18] */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szEndPassTime;                                          /* 检测结束时间：YYYYMMDDHHMMSS，时间按24小时制。字符串长度[0,18] */
        public UInt32 udwObjectIn;                                            /* 配置时间内进入人数 */
        public UInt32 udwObjectOut;                                           /* 配置时间内离开人数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PEOPLE_COUNT_LINE_RULE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public string szReference;                                            /* 描述信息 */
        public Int64 tTimeStamp;                                              /* 告警时间 从1970年1月1日0点开始的秒数 */
        public UInt32 udwSeq;                                                 /* 告警序号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szDeviceID;                                             /* 相机编码或域编码，回传事件订阅下发的设备编码，当事件订阅接口中携带设备编码时必填 */
        public UInt32 udwChannelID;                                           /* 通道号，从0开始 */
        public UInt32 udwLineNum;                                             /* 伴线规则数量，从0开始，0代表无区域规则上报 */
        public IntPtr pstLineRuleCountDataList;                               /* 伴线规则统计数据信息 需动态申请内存 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CROWD_DENSITY_SUMMARY_INFO_S
    {
        public UInt32 udwTotalIn;                                             /* 总进入人数 */
        public UInt32 udwTotalOut;                                            /* 总离开人数 */
        public UInt32 udwAlarmThermal;                                        /* 报警阈值人数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CROWD_DENSITY_DATA_S
    {
        public UInt32 udwGroupID;                                             /* 统计组ID */
        public Int64 tBeginTime;                                              /* 统计开始时间，UTC时间 */
        public Int64 tEndTime;                                                /* 统计结束时间，UTC时间 */
        public UInt32 udwObjectIn;                                            /* 进入人数 */
        public UInt32 udwObjectOut;                                           /* 离开人数 */
        public IntPtr pstLineRuleCountDataList;                               /* 伴线规则统计数据信息 需动态申请内存 */
        public NETDEV_CROWD_DENSITY_SUMMARY_INFO_S stCrowdDensitySummaryInfo; /* 统计汇总信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CROWD_DENSITY_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public string szReference;                                            /* 订阅者描述信息 */
        public Int64 tTimeStamp;                                              /* 告警时间 从1970年1月1日0点开始的秒数 */
        public UInt32 udwSeq;                                                 /* 推送数据序号 */
        public UInt32 udwSrcID;                                               /* 源ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szSrcName;                                              /* 源名称,长度[1,63] */
        public UInt32 udwRelatedID;                                           /* 告警事件关联ID */
        public NETDEV_CROWD_DENSITY_DATA_S stCrowdDensityData;                /* 人员密度统计数据 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PEOPLE_COUNT_ALARM_INFO_S
    {
        public UInt32 udwType;                                                /* 人数统计告警类型，参见枚举# NETDEV_PEOPLE_COUNT_ALARM_TYPE_E */
        public NETDEV_PEOPLE_COUNT_AREA_RULE_INFO_S stAreaRuleInfo;           /* 人数统计区域规则统计数据信息 */
        public NETDEV_PEOPLE_COUNT_LINE_RULE_INFO_S stLineRuleInfo;           /* 人数统计绊线规则统计数据信息 */
        public NETDEV_CROWD_DENSITY_INFO_S stCrowdDensityInfo;                /* 人员密度统计信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_RULE_INFO_S
    {
        public UInt32 bEnabled;                                               /* 通道ID */
        public UInt32 udwAlarmThermal;                                        /* 报警人数阈值 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CROWD_DENSITY_RULE_INFO_S
    {
        public NETDEV_ALARM_RULE_INFO_S stMinorAlarmRuleInfo;                 /* 轻度报警规则 */
        public NETDEV_ALARM_RULE_INFO_S stMajorAlarmRuleInfo;                 /* 中度报警规则 */
        public NETDEV_ALARM_RULE_INFO_S stCriticalAlarmRuleInfo;              /* 严重报警规则 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_RULE_INFO_S
    {
        public UInt32 udwChannelID;                                           /* 通道ID */
        public UInt32 udwRuleNum;                                             /* 规则个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public UInt32[] audwRuleIDList;                                       /* 规则ID列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CROWD_DENSITY_GROUP_INFO_S
    {
        public UInt32 udwGroupID;                                             /* 统计组ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szGroupName;                                            /* 统计组名称，长度范围[0,63] */
        public UInt32 udwStatisticalType;                                     /* 统计类型 参见# NETDEV_CROWD_DENSITY_STATISTIC_TYPE_E */
        public UInt32 udwChannelRuleNum;                                      /* 通道规则个数 */
        public IntPtr pstChannelRuleInfoList;                                 /* 通道规则信息列表，通道规则个数为0时可选，需用户分配内存 */
        public NETDEV_CROWD_DENSITY_RULE_INFO_S stCrowdDensityRuleInfo;       /* 滞留规则 */
        public UInt32 udwReportInterval;                                      /* 上报间隔时间 单位:(秒) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_QUERY_CHN_CONDITION_S
    {
        public Int32 dwLimit;                                                 /* 每次查询的数量 */
        public Int32 dwOffset;                                                /* 从当前序号开始查询 */
        public Int32 dwQryInfoNum;                                            /* 查询条件数量 */
        public IntPtr pstQueryInfo;                                           /* 查询条件 */
        public Int32 dwRecursion;                                             /* 递归查询类型  0：不递归 1：向上递归 2：向下递归 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SINGLE_OBJECT_INFO_S
    {
        public UInt32 udwObjectType;                                          /* 目标类型 # 参见 NETDEV_OBJECT_TYPE_E */
        public NETDEV_FACE_STRUCT_INFO_S stFaceInfo;                          /* 人脸信息 */
        public NETDEV_PERSON_STRUCT_INFO_S stPersonInfo;                      /* 人员信息 */
        public NETDEV_NON_MOTOR_VEH_INFO_S stNonMotorVehInfo;                 /* 非机动车信息 */
        public NETDEV_VEH_INFO_S stVehInfo;                                   /* 车辆信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_INFO_LIST_S
    {
        public UInt32 udwObjectID;                                            /* 目标ID */
        public NETDEV_FILE_INFO_S stSmallImageInfo;                           /* 目标对应小图信息 */
        public NETDEV_SINGLE_OBJECT_INFO_S stObjectInfo;                      /* 目标信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_RESULT_INFO_S
    {
        public UInt32 udwRecordID;                                            /* 记录ID */
        public UInt32 udwType;                                                /* 记录类型 详见 NETDEV_OBJECT_RECORD_TYPE_E */
        public UInt32 udwTime;                                                /* 记录事件，UTC格式，单位秒 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public string szChannelName;                                          /* 抓拍通道名称，范围[1,63] */
        public UInt32 udwChannelID;                                           /* 抓拍通道ID */
        public NETDEV_FILE_INFO_S stBigImageInfo;                             /* 大图信息 */
        public UInt32 udwObjectInfoNum;                                       /* 目标信息列表数量 */
        public IntPtr pstObjectInfoList;                                      /* 目标信息列表 需动态申请 详见 NETDEV_OBJECT_INFO_LIST_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    /**
    * @struct NETDEV_TEMPERATURE_CHANNEL_INFO_S
    * @brief 温度告警通道信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TEMPERATURE_CHANNEL_INFO_S
    {
        public UInt32 udwChannelID;                     /* 通道ID */
        public UInt32 udwImageNum;                      /* 图像个数 */
        public IntPtr pstImageInfo;                     /* 图像相关信息 需动态申请内存， 详见 NETDEV_STRUCT_IMAGE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    /**
    * @struct NETDEV_TEMPERATURE_INFO_S
    * @brief 温度信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TEMPERATURE_INFO_S
    {
        public UInt32 udwRuleType;                                                /* 规则类型，用于检测规则内的温度告警  1 : 温度告警全屏规则 2 : 温度告警单规则（即点、线、多边形规则）3 : 温度告警规则,包含单规则与对比规则 */
        public UInt32 udwRuleId;                                                  /* 规则ID, RuleType为2、3时必选 */
        public UInt32 udwReferenceRuleId;                                         /* 对比规则ID，RuleType为3时必选 */
        public UInt32 udwAlarmCondition;                                          /* 温度告警触发条件 1：低于 2：高于 3：匹配 */
        public UInt32 udwValueType;                                               /* 告警值类型 详见 NETDEV_TEMPERATURE_TYPE_E */
        public float  fAlarmValue;                                                /* 当前报警类型产生的告警值 ValueType为5时表示温度变化率，其他表示温度值，精度小数点后两位 */
        public float  fThreshold;                                                 /* ValueType为5时表示温度变化率阈值，其他表示温度阈值，精度小数点后两位 */
        public UInt32 udwChannelNum;                                              /* 通道个数 */
        public IntPtr pstTemperatureChannelInfo;                                  /* 温度告警通道信息 动态申请内存，详见 NETDEV_TEMPERATURE_CHANNEL_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                          /* 保留字段 */
    };

    /**
    * @struct NETDEV_SMOKE_DETC_CHANNEL_S
    * @brief 吸烟检测通道信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMOKE_DETC_CHANNEL_S
    {
        public UInt32 udwChannelID;                     /* 通道ID */
        public UInt32 udwNum;                           /* 火点数量 */
        public IntPtr pstFirePointList;                 /* 不同火点的位置信息列表 */
        public UInt32 udwImageNum;                      /* 图像个数 */
        public IntPtr pstImageList;                     /* 图像相关信息 需动态申请内存, 详见 NETDEV_STRUCT_IMAGE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                  /* 保留字段 */
    };


    /**
    * @struct NETDEV_SMOKING_INFO_S
    * @brief 吸烟信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMOKING_INFO_S
    {
        public UInt32 udwChannelNum;                     /* 通道数量 */
        public IntPtr pstSmokeDetcChannel;               /* 吸烟通道信息 需动态申请内存，详见 NETDEV_SMOKE_DETC_CHANNEL_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                          /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FIRE_POINT_S
    {
        public UInt32 udwId;                     /* 通道ID */
        public UInt32 udwNum;                    /* 图像个数 */
        public IntPtr pstPoint;                  /* 火点中心位置在通道中的坐标信息 需动态申请内存, 详见 NETDEV_POINT_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FIRE_POINT_LIST_S
    {
        public UInt32 udwNum;                    /* 通道ID */
        public IntPtr pstFirePointsInfo;          /* 点的位置信息列表 需动态申请内存， 详见 NETDEV_FIRE_POINT_S */
        public UInt32 udwImageNum;               /* 图像个数 */
        public IntPtr pstImageInfo;              /* 图像相关信息 需动态申请内存， 详见 NETDEV_STRUCT_IMAGE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CONFLAGRATION_CHANNEL_INFO_S
    {
        public UInt32 udwChannelID;                    /* 通道ID */
        public float fLensView;                        /* 发现火点位置时的镜头视场角角度，精确到小数点后两位 */
        public NETDEV_FIRE_POINT_LIST_S stFirePointList; /* 不同火点的位置信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    };

    /**
    * @struct NETDEV_CONFLAGRATION_INFO_S
    * @brief 火点信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CONFLAGRATION_INFO_S
    {
        public NETDEV_GEOLACATION_INFO_S stPTPositionInfo;            /* 定位信息 */
        public UInt32 udwNum;                      /* 火点通道个数 */
        public IntPtr pstChannelInfo;               /* 火点通道信息 需动态分配内存 详见 NETDEV_CONFLAGRATION_CHANNEL_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                                                 /* 保留字段 */
    };

    /**
    * @struct tagNETDEVCyberAttackData
    * @brief 安全攻击数据 Cyber Attack Data
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CYBER_ATTACK_DATA_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szAttackSrcIP;                      /* 攻击者IPv4地址, 长度范围为[1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szAttackDstIP;                      /* 被攻击IPv4地址, 长度范围为[1,64] */
        public UInt32 udwAttackProtocol;                  /* 攻击协议, 参见枚举 NETDEV_ATTACK_PROTOCOL_E */
        public UInt32 udwAttackType;                      /* 攻击类型, 参见枚举 NETDEV_ATTACK_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szAttackName;                       /* 攻击名称, 长度范围为[1,128] */
        public UInt32 udwAttackTime;                      /* 攻击发生时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] bRes;                               /* 保留字段 Reserved */
    };

    /**
     * @struct NETDEV_ALARM_RELATED_DATA_S
     * @brief 告警关联数据 Alarm Related Data
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_RELATED_DATA_S
    {
        public NETDEV_STRUCT_DATA_INFO_S     stStructDataInfo;        /* 告警关联结构化数据信息 */
        public NETDEV_CYBER_ATTACK_DATA_S    stCyberAttackData;       /* 告警关联网络攻击数据信息 */
        public NETDEV_CONFLAGRATION_INFO_S   stConflagrationInfo;     /* 火点信息 */
        public NETDEV_SMOKING_INFO_S         stSmokingInfo;           /* 吸烟信息 */
        public NETDEV_TEMPERATURE_INFO_S     stTemperatureInfo;       /* 温度信息 */
        public IntPtr                        pstFaceComparison;       /* 人脸识别比对信息，内存需调用者动态申请 详见 NETDEV_FACE_PASS_RECORD_INFO_S */
        public IntPtr                        pstVehicleComparison;    /* 车辆识别比对信息，内存需调用者动态申请 详见 NETDEV_VEHICLE_RECORD_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
        public byte[] byRes;                                   /* 保留字段 */
    };

    /* define struct end */
    



    public enum NETDEV_CAMERA_TYPE_E
    {
        NETDEV_CAMERA_TYPE_FIX = 0,           
        NETDEV_CAMERA_TYPE_PTZ = 1,           

        NETDEV_CAMERA_TYPE_INVALID = 0xFF        
    }

    public enum NETDEV_RENDER_SCALE_E
    {
        NETDEV_RENDER_SCALE_FULL = 0,                
        NETDEV_RENDER_SCALE_PROPORTION = 1,          

        NETDEV_RENDER_SCALE_BUTT = 0xFF
    }

    public enum NETDEV_VIDEO_CODE_TYPE_E
    {
        NETDEV_VIDEO_CODE_MJPEG = 0,          /* MJPEG */
        NETDEV_VIDEO_CODE_H264 = 1,          /* H.264 */
        NETDEV_VIDEO_CODE_H265 = 2,          /* H.265 */
        NETDEV_VIDEO_CODE_INVALID
    };


    public enum NETDEV_HOSTTYPE_E
{
        NETDEV_NETWORK_HOSTTYPE_IPV4 = 0,               /* IPv4 */
        NETDEV_NETWORK_HOSTTYPE_IPV6 = 1,               /* IPv6 */
        NETDEV_NETWORK_HOSTTYPE_DNS  = 2                /* DNS */
};
    public enum NETDEV_RELAYOUTPUT_STATE_E
{
        NETDEV_BOOLEAN_STATUS_ACTIVE    = 0,            /* Triggered */
        NETDEV_BOOLEAN_STATUS_INACTIVE  = 1             /* Not triggered */
};

    public enum NETDEV_OSD_TIME_FORMAT_CAP_E
{
        NETDEV_OSD_TIME_FORMAT_CAP_HHMMSS = 0,          /* HH:mm:ss */
        NETDEV_OSD_TIME_FORMAT_CAP_HH_MM_SS_PM          /* hh:mm:ss tt */

};


  public enum NETDEV_TIME_ZONE_E
{
    NETDEV_TIME_ZONE_W1200 = 0,              /* W12 */
    NETDEV_TIME_ZONE_W1100 = 1,              /* W11 */
    NETDEV_TIME_ZONE_W1000 = 2,              /* W10 */
    NETDEV_TIME_ZONE_W0900 = 3,              /* W9 */
    NETDEV_TIME_ZONE_W0800 = 4,              /* W8 */
    NETDEV_TIME_ZONE_W0700 = 5,              /* W7 */
    NETDEV_TIME_ZONE_W0600 = 6,              /* W6 */
    NETDEV_TIME_ZONE_W0500 = 7,              /* W5 */
    NETDEV_TIME_ZONE_W0430 = 8,              /* W4:30 */
    NETDEV_TIME_ZONE_W0400 = 9,              /* W4 */
    NETDEV_TIME_ZONE_W0330 = 10,             /* W3:30 */
    NETDEV_TIME_ZONE_W0300 = 11,             /* W3 */
    NETDEV_TIME_ZONE_W0200 = 12,             /* W2 */
    NETDEV_TIME_ZONE_W0100 = 13,             /* W1 */
    NETDEV_TIME_ZONE_0000  = 14,             /* W0 */
    NETDEV_TIME_ZONE_E0100 = 15,             /* E1 */
    NETDEV_TIME_ZONE_E0200 = 16,             /* E2 */
    NETDEV_TIME_ZONE_E0300 = 17,             /* E3 */
    NETDEV_TIME_ZONE_E0330 = 18,             /* E3:30 */
    NETDEV_TIME_ZONE_E0400 = 19,             /* E4 */
    NETDEV_TIME_ZONE_E0430 = 20,             /* E4:30 */
    NETDEV_TIME_ZONE_E0500 = 21,             /* E5 */
    NETDEV_TIME_ZONE_E0530 = 22,             /* E5:30 */
    NETDEV_TIME_ZONE_E0545 = 23,             /* E5:45 */
    NETDEV_TIME_ZONE_E0600 = 24,             /* E6 */
    NETDEV_TIME_ZONE_E0630 = 25,             /* E6:30 */
    NETDEV_TIME_ZONE_E0700 = 26,             /* E7 */
    NETDEV_TIME_ZONE_E0800 = 27,             /* E8 */
    NETDEV_TIME_ZONE_E0900 = 28,             /* E9 */
    NETDEV_TIME_ZONE_E0930 = 29,             /* E9:30 */
    NETDEV_TIME_ZONE_E1000 = 30,             /* E10 */
    NETDEV_TIME_ZONE_E1100 = 31,             /* E11 */
    NETDEV_TIME_ZONE_E1200 = 32,             /* E12 */
    NETDEV_TIME_ZONE_E1300 = 33,             /* E13 */
    NETDEV_TIME_ZONE_W0930 = 34,              /* W9:30 */
    NETDEV_TIME_ZONE_E0830 = 35,             /* E8:30 */
    NETDEV_TIME_ZONE_E0845 = 36,             /* E8:45 */
    NETDEV_TIME_ZONE_E1030 = 37,             /* E10:30 */
    NETDEV_TIME_ZONE_E1245 = 38,             /* E12:45 */
    NETDEV_TIME_ZONE_E1400 = 39,             /* E14 */
    NETDEV_TIME_ZONE_INVALID = 0xFF          /* Invalid value */
};

  public enum NETDEV_ALARM_TYPE_E
  {
      NETDEV_ALARM_MOVE_DETECT                                      = 1,        /* 运动检测告警  Motion detection alarm */
      NETDEV_ALARM_MOVE_DETECT_RECOVER                              = 2,        /* 运动检测告警恢复  Motion detection alarm recover */
      NETDEV_ALARM_VIDEO_LOST                                       = 3,        /* 视频丢失告警  Video loss alarm */
      NETDEV_ALARM_VIDEO_LOST_RECOVER                               = 4,        /* 视频丢失告警恢复  Video loss alarm recover */
      NETDEV_ALARM_VIDEO_TAMPER_DETECT                              = 5,        /* 遮挡侦测告警  Tampering detection alarm */
      NETDEV_ALARM_VIDEO_TAMPER_RECOVER                             = 6,        /* 遮挡侦测告警恢复  Tampering detection alarm recover */
      NETDEV_ALARM_INPUT_SWITCH                                     = 7,        /* 输入开关量告警  boolean input alarm */
      NETDEV_ALARM_INPUT_SWITCH_RECOVER                             = 8,        /* 输入开关量告警恢复  Boolean input alarm recover */
      NETDEV_ALARM_TEMPERATURE_HIGH                                 = 9,        /* 高温告警  High temperature alarm */
      NETDEV_ALARM_TEMPERATURE_LOW                                  = 10,       /* 低温告警  Low temperature alarm */
      NETDEV_ALARM_TEMPERATURE_RECOVER                              = 11,       /* 温度告警恢复  Temperature alarm recover */
      NETDEV_ALARM_AUDIO_DETECT                                     = 12,       /* 音频异常检测告警  Audio detection alarm */
      NETDEV_ALARM_AUDIO_DETECT_RECOVER                             = 13,       /* 音频异常检测告警恢复  Audio detection alarm recover */
      NETDEV_ALARM_SERVER_FAULT                                     = 18,       /* 服务器故障 */
      NETDEV_ALARM_SERVER_NORMAL                                    = 19,       /* 服务器故障恢复 */


      NETDEV_ALARM_REPORT_DEV_ONLINE                                = 201,       /* 设备上线告警 */
      NETDEV_ALARM_REPORT_DEV_OFFLINE                               = 202,       /* 设备下线告警 */
      NETDEV_ALARM_REPORT_DEV_REBOOT                                = 203,       /* 设备重启  Device restart */
      NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT                        = 204,       /* 服务重启  Service restart */
      NETDEV_ALARM_REPORT_DEV_CHL_ONLINE                            = 205,       /* 视频通道: 上线 */
      NETDEV_ALARM_REPORT_DEV_CHL_OFFLINE                           = 206,       /* 视频通道: 下线 */
      NETDEV_ALARM_REPORT_DEV_DELETE_CHL                            = 207,       /* 视频通道: 删除 */

      NETDEV_ALARM_DEVICE_HIGHTEMP                                  = 246,       /* 异常类：设备高温 */
      NETDEV_ALARM_DEVICE_LOWTEMP                                   = 247,       /* 异常类：设备低温 */
      NETDEV_ALARM_FAN_FAULT                                        = 248,       /* 异常类：风扇故障 */
      NETDEV_ALARM_LEDBOX_HIGHTEMP                                  = 249,       /* 异常类：电箱高温 */
      NETDEV_ALARM_LEDBOX_SMOKE                                     = 250,       /* 异常类：电箱烟雾告警 */
      NETDEV_ALARM_DEVICE_HIGHTEMP_RECOVER                          = 251,       /* 异常类:设备温度恢复 */
      NETDEV_ALARM_DEVICE_LOWTEMP_RECOVER                           = 252,       /* 异常类:设备温度恢复 */
      NETDEV_ALARM_FAN_FAULT_RECOVER                                = 253,       /* 异常类:风扇故障恢复 */
      NETDEV_ALARM_LEDBOX_HIGHTEMP_RECOVER                          = 254,       /* 异常类:电箱高温恢复 */
      NETDEV_ALARM_LEDBOX_SMOKE_RECOVER                             = 255,       /* 异常类:电箱烟雾告警恢复 */

      NETDEV_ALARM_NET_FAILED                                       = 401,      /* 会话网络错误 Network error */
      NETDEV_ALARM_NET_TIMEOUT                                      = 402,      /* 会话网络超时 Network timeout */
      NETDEV_ALARM_SHAKE_FAILED                                     = 403,      /* 会话交互错误 Interaction error */
      NETDEV_ALARM_STREAMNUM_FULL                                   = 404,      /* 流数已经满 Stream full */
      NETDEV_ALARM_STREAM_THIRDSTOP                                 = 405,      /* 第三方停止流 Third party stream stopped */
      NETDEV_ALARM_FILE_END                                         = 406,      /* 文件结束 File ended */
      NETDEV_ALARM_RTMP_CONNECT_FAIL                                = 407,      /* RTMP连接失败 */
      NETDEV_ALARM_RTMP_INIT_FAIL                                   = 408,      /* RTMP初始化失败*/

      NETDEV_ALARM_STREAM_DOWNLOAD_OVER                             = 409,      /* 一体机国标流下载完成 */
      NETDEV_ALARM_PLAYBACK_FINISH                                  = 410,      /* 回放结束 */
      NETDEV_ALARM_VIDEO_RECORD_PART                                = 411,      /* 录像分段 */
      NETDEV_ALARM_FISHEYE_STREAM_EXIST                             = 412,      /* 鱼眼流存在,仅用于上报 */
      NETDEV_ALARM_FISHEYE_STREAM_NOT_EXIST                         = 413,      /* 鱼眼流不存在,仅用于上报 */
      NETDEV_ALARM_PTZ_RESOUCE_FAIL                                 = 414,      /* 四目全景ptz资源错误 */
      NETDEV_ALARM_PTZ_STREAM_EXIST                                 = 415,      /* 四目全景ptz流存在，仅用于上报 */
      NETDEV_ALARM_STREAM_NOT_EXIST                                 = 416,      /* 四目全景ptz流不存在，仅用于上报 */
      NETDEV_ALARM_INNER_TIMEOUT                                    = 417,      /* 内部处理超时 */
      NETDEV_ALARM_STREAM_NOT_READY                                 = 418,      /* 流未就绪 */
      NETDEV_ALARM_KEEP_ALIVE_FAILED                                = 419,      /* 保活失败 */
      NETDEV_ALARM_OVER_ABILITY                                     = 420,      /* 回放能力不足 */
      NETDEV_ALARM_UNAUTHORIZED                                     = 421,      /* 未通过认证 */
      NETDEV_ALARM_FORIBIDDEN                                       = 422,      /* 禁止 */
      NETDEV_ALARM_METHOD_NOT_ALLOWED                               = 423,      /* 不允许该方法 */
      NETDEV_ALARM_PRECONDITION_FAILED                              = 424,      /* 预处理失败 */
      NETDEV_ALARM_SESSION_NOT_FOUND                                = 425,      /* 找不到会话 */
      NETDEV_ALARM_NOT_ENOUGH_BANDWIDTH2                            = 426,      /* 带宽不足(RTSP) */
      NETDEV_ALARM_REALPLAY_ESTABLISHED                             = 427,      /* 实况业务已经建立 */
      NETDEV_ALARM_REALPLAY_RES_BUSY                                = 428,      /* 实况业务显示资源忙 */
      NETDEV_ALARM_MULTICAST_DISABLED                               = 429,      /* 组播使能关闭 */
      NETDEV_ALARM_MULTICAST_PORT_OCCUPIED                          = 430,      /* 组播端口已被占用 */
      NETDEV_ALARM_MULTICAST_PORT_EXHAUSTED                         = 431,      /* 组播端口已耗尽 */
      NETDEV_ALARM_MULTICAST_USER_NOT_EXIST                         = 432,      /* 组播用户不存在 */
      NETDEV_ALARM_CHANNEL_NOT_ONLINE                               = 433,      /* 通道不在线 */
      NETDEV_ALARM_TALKBACK_ENCODED_INVALID                         = 434,      /* 语音对讲资源编码无效 */
      NETDEV_ALARM_VOICE_RES_USED_BY_TALKBACK                       = 435,      /* 语音资源已被对讲使用 */
      NETDEV_ALARM_TALKBACK_EXISTS                                  = 436,      /* 语音对讲已存在 */
      NETDEV_ALARM_VOICE_WORK_NOT_EXIST                             = 437,      /* 语音业务不存在 */
      NETDEV_ALARM_TALKBACK_TIMEOUT                                 = 438,      /* 建立语音对讲业务超时 */
      NETDEV_ALARM_TALKBACK_ERROR                                   = 439,      /* 语音对讲失败 */

      NETDEV_ALARM_DISK_ERROR                                       = 601,      /* 设备磁盘错误  Disk error */
      NETDEV_ALARM_SYS_DISK_ERROR                                   = 602,      /* 系统磁盘错误  Disk error */
      NETDEV_ALARM_DISK_ONLINE                                      = 603,      /* 设备磁盘上线 Disk online */
      NETDEV_ALARM_SYS_DISK_ONLINE                                  = 604,      /* 系统磁盘上线 Disk online */
      NETDEV_ALARM_DISK_OFFLINE                                     = 605,      /* 设备磁盘离线 */
      NETDEV_ALARM_SYS_DISK_OFFLINE                                 = 606,      /* 系统磁盘离线 */
      NETDEV_ALARM_DISK_ABNORMAL                                    = 607,      /* 磁盘异常 Disk abnormal */
      NETDEV_ALARM_DISK_ABNORMAL_RECOVER                            = 608,      /* 磁盘异常恢复 Disk abnormal recover */
      NETDEV_ALARM_DISK_STORAGE_WILL_FULL                           = 609,      /* 磁盘存储空间即将满 Disk StorageGoingfull */
      NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER                   = 610,      /* 磁盘存储空间即将满恢复 Disk StorageGoingfull recover */
      NETDEV_ALARM_DISK_STORAGE_IS_FULL                             = 611,      /* 设备存储空间满 StorageIsfull */
      NETDEV_ALARM_SYS_DISK_STORAGE_IS_FULL                         = 612,      /* 系统存储空间满 StorageIsfull */
      NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER                     = 613,      /* 存储空间满恢复 StorageIsfull recover */
      NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER                       = 614,      /* 阵列损坏恢复 RAIDDisabled recover */
      NETDEV_ALARM_DISK_RAID_DEGRADED                               = 615,      /* 设备阵列衰退 RAIDDegraded */
      NETDEV_ALARM_SYS_DISK_RAID_DEGRADED                           = 616,      /* 系统阵列衰退 RAIDDegraded */
      NETDEV_ALARM_DISK_RAID_DISABLED                               = 617,      /* 设备阵列损坏 RAIDDisabled */
      NETDEV_ALARM_SYS_DISK_RAID_DISABLED                           = 618,      /* 系统阵列损坏 RAIDDisabled */
      NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER                       = 619,      /* 阵列衰退恢复 RAIDDegraded recover */
      NETDEV_ALARM_STOR_GO_FULL                                     = 620,      /* 设备存储即将满告警 */
      NETDEV_ALARM_SYS_STOR_GO_FULL                                 = 621,      /* 系统存储即将满告警 */
      NETDEV_ALARM_ARRAY_NORMAL                                     = 622,      /* 设备阵列正常 */
      NETDEV_ALARM_SYS_ARRAY_NORMAL                                 = 623,      /* 系统阵列正常 */
      NETDEV_ALARM_DISK_RAID_RECOVERED                              = 624,      /* 阵列恢复正常 RAIDDegraded */
      NETDEV_ALARM_STOR_ERR                                         = 625,      /* 设备存储错误  Storage error */
      NETDEV_ALARM_SYS_STOR_ERR                                     = 626,      /* 系统存储错误  Storage error */
      NETDEV_ALARM_STOR_ERR_RECOVER                                 = 627,      /* 存储错误恢复  Storage error recover */
      NETDEV_ALARM_STOR_DISOBEY_PLAN                                = 628,      /* 未按计划存储  Not stored as planned */
      NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER                        = 629,      /* 未按计划存储恢复  Not stored as planned recover */

      NETDEV_ALARM_BANDWITH_CHANGE                                  = 801,      /* 设备出口带宽变更 */
      NETDEV_ALARM_VIDEOENCODER_CHANGE                              = 802,      /* 设备码流配置变更告警 */
      NETDEV_ALARM_IP_CONFLICT                                      = 803,      /* IP冲突异常告警 IP conflict exception alarm*/
      NETDEV_ALARM_IP_CONFLICT_CLEARED                              = 804,      /* IP冲突异常告警恢复IP conflict exception alarm recovery */
      NETDEV_ALARM_NET_OFF                                          = 805,      /* 网络断开异常告警 */
      NETDEV_ALARM_NET_RESUME_ON                                    = 806,      /* 网络断开恢复告警 */

      NETDEV_ALRAM_CONFLAG_DETECT                                   = 920,      /* 火点告警 Conflagration detection alarm */

      NETDEV_ALARM_NO_MASK                                          = 921,      /* 未戴口罩 NoMaskmAlarm */
      NETDEV_ALARM_BODY_TEMPERATURE                                 = 922,      /* 人体温度 BodyTemperatureAlarm */
      NETDEV_ALARM_AREA_PEOPLE_COUNT                                = 923,      /* 区域人数统计告警 Area people count alarm */
      NETDEV_ALARM_AREA_PEOPLE_COUNT_RECOVER                        = 924,      /* 区域人数统计告警恢复 Area people count alarm recover */


      NETDEV_ALARM_ILLEGAL_ACCESS                                   = 1001,          /* 设备非法访问  Illegal access */
      NETDEV_ALARM_SYS_ILLEGAL_ACCESS                               = 1002,          /* 系统非法访问  Illegal access */
      NETDEV_ALARM_LINE_CROSS                                       = 1003,          /* 越界告警  Line cross */
      NETDEV_ALARM_OBJECTS_INSIDE                                   = 1004,          /* 区域入侵  Objects inside */
      NETDEV_ALARM_FACE_RECOGNIZE                                   = 1005,          /* 人脸识别  Face recognize */
      NETDEV_ALARM_IMAGE_BLURRY                                     = 1006,          /* 图像虚焦  Image blurry */
      NETDEV_ALARM_SCENE_CHANGE                                     = 1007,          /* 场景变更  Scene change */
      NETDEV_ALARM_SMART_TRACK                                      = 1008,          /* 智能跟踪  Smart track */
      NETDEV_ALARM_LOITERING_DETECTOR                               = 1009,          /* 徘徊检测  Loitering Detector */
      NETDEV_ALARM_BANDWIDTH_CHANGE                                 = 1010,          /* 带宽变更  Bandwidth change */
      NETDEV_ALARM_ALLTIME_FLAG_END                                 = 1011,          /* 无布防告警结束标记  End marker of alarm without arming schedule */
      NETDEV_ALARM_MEDIA_CONFIG_CHANGE                              = 1012,          /* 编码参数变更 media configurationchanged */
      NETDEV_ALARM_REMAIN_ARTICLE                                   = 1013,          /*物品遗留告警  Remain article*/
      NETDEV_ALARM_PEOPLE_GATHER                                    = 1014,          /* 人员聚集告警 People gather alarm*/
      NETDEV_ALARM_ENTER_AREA                                       = 1015,          /* 进入区域 Enter area*/
      NETDEV_ALARM_LEAVE_AREA                                       = 1016,          /* 离开区域 Leave area*/
      NETDEV_ALARM_ARTICLE_MOVE                                     = 1017,          /* 物品搬移 Article move*/
      NETDEV_ALARM_SMART_FACE_MATCH_LIST                            = 1018,       /* 人脸识别黑名单报警 */
      NETDEV_ALARM_SMART_FACE_MATCH_LIST_RECOVER                    = 1019,       /* 人脸识别黑名单报警恢复 */
      NETDEV_ALARM_SMART_FACE_MISMATCH_LIST                         = 1020,       /* 人脸识别不匹配报警 */
      NETDEV_ALARM_SMART_FACE_MISMATCH_LIST_RECOVER                 = 1021,       /* 人脸识别不匹配报警恢复 */
      NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST                         = 1022,       /* 车辆识别匹配报警 */
      NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST_RECOVER                 = 1023,       /* 车辆识别匹配报警恢复 */
      NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST                      = 1024,       /* 车辆识别不匹配报警 */
      NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST_RECOVER              = 1025,       /* 车辆识别不匹配报警回复 */
      NETDEV_ALARM_IMAGE_BLURRY_RECOVER                             = 1026,         /* 图像虚焦告警恢复  Image blurry recover */
      NETDEV_ALARM_SMART_TRACK_RECOVER                              = 1027,         /* 智能跟踪告警恢复  Smart track recover */
      NETDEV_ALARM_SMART_READ_ERROR_RATE                            = 1028,         /* 底层数据读取错误率Error reding the underlying data */
      NETDEV_ALARM_SMART_SPIN_UP_TIME                               = 1029,         /* 主轴起旋时间  Rotation time of spindle */
      NETDEV_ALARM_SMART_START_STOP_COUNT                           = 1030,         /* 启停计数 Rev. Stop counting*/
      NETDEV_ALARM_SMART_REALLOCATED_SECTOR_COUNT                   = 1031,         /* 重映射扇区计数  Remap sector count*/
      NETDEV_ALARM_SMART_SEEK_ERROR_RATE                            = 1032,         /* 寻道错误率 Trace error rate*/
      NETDEV_ALARM_SMART_POWER_ON_HOURS                             = 1033,         /* 通电时间累计，出厂后通电的总时间，一般磁盘寿命三万小时 */
      NETDEV_ALARM_SMART_SPIN_RETRY_COUNT                           = 1034,         /* 主轴起旋重试次数 */
      NETDEV_ALARM_SMART_CALIBRATION_RETRY_COUNT                    = 1035,         /* 磁头校准重试计数 */
      NETDEV_ALARM_SMART_POWER_CYCLE_COUNT                          = 1036,         /* 通电周期计数 */
      NETDEV_ALARM_SMART_POWEROFF_RETRACT_COUNT                     = 1037,         /* 断电返回计数 */
      NETDEV_ALARM_SMART_LOAD_CYCLE_COUNT                           = 1038,         /* 磁头加载计数 */
      NETDEV_ALARM_SMART_TEMPERATURE_CELSIUS                        = 1039,         /* 温度 */
      NETDEV_ALARM_SMART_REALLOCATED_EVENT_COUNT                    = 1040,         /* 重映射事件计数 */
      NETDEV_ALARM_SMART_CURRENT_PENDING_SECTOR                     = 1041,         /* 当前待映射扇区计数 */
      NETDEV_ALARM_SMART_OFFLINE_UNCORRECTABLE                      = 1042,         /* 脱机无法校正的扇区计数 */
      NETDEV_ALARM_SMART_UDMA_CRC_ERROR_COUNT                       = 1043,         /* 奇偶校验错误率  */
      NETDEV_ALARM_SMART_MULTI_ZONE_ERROR_RATE                      = 1044,         /* 多区域错误率 */
      NETDEV_ALARM_RESOLUTION_CHANGE                                = 1045,         /* 分辨率变更 */
      NETDEV_ALARM_MANUAL                                           = 1401,         /* 手动告警 */
      NETDEV_ALARM_ALARMHOST_COMMON                                 = 1402,         /* 报警点事件 */
      NETDEV_ALARM_DOORHOST_COMMON                                  = 1403,         /* 门禁事件 */
      NETDEV_ALARM_FACE_NOT_MATCH                                   = 1411,         /* 人脸对比失败 */
      NETDEV_ALARM_FACE_MATCH_SUCCEED                               = 1412,         /* 人脸对比成功 */

      NETDEV_ALARM_VEHICLE_BLACK_LIST                               = 1420,         /* 车辆识别黑名单报警 */
      NETDEV_ALARM_HUMAN_SHAPE_DETECTION                            = 1421,         /* 人形检测 */
      NETDEV_ALARM_HUMAN_SHAPE_DETECTION_RECOVER                    = 1422,         /* 人形检测告警恢复 */
      NETDEV_ALARM_NOT_WORN_SAFETYHELMET                            = 1423,         /* 未佩戴安全帽报警  */
      NETDEV_ALARM_NOT_WORN_WORKCLOTHES                             = 1424,         /* 未穿戴工作服报警 */
      NETDEV_ALARM_FAST_MOVING                                      = 1425,         /* 快速移动报警 */
      NETDEV_ALARM_NOT_WORN_CHEFHAT                                 = 1426,         /* 未带厨师帽报警 */
      NETDEV_ALARM_TELEPHONING                                      = 1427,         /* 打电话告警 */
      NETDEV_ALARM_SMOKING                                          = 1428,         /* 吸烟告警 */
      NETDEV_ALARM_CROWD_DENSITY_MINOR                              = 1429,         /* 人员密度普通告警 */
      NETDEV_ALARM_CROWD_DENSITY_MINOR_CLEARED                      = 1430,         /* 人员密度普通告警恢复 */
      NETDEV_ALARM_CROWD_DENSITY_MAJOR                              = 1431,         /* 人员密度中度告警 */
      NETDEV_ALARM_CROWD_DENSITY_MAJOR_CLEARED                      = 1432,         /* 人员密度中度告警恢复 */
      NETDEV_ALARM_CROWD_DENSITY_CRITICAL                           = 1433,         /* 人员密度严重告警 */
      NETDEV_ALARM_CROWD_DENSITY_CRITICAL_CLEARED                   = 1434,         /* 人员密度严重告警恢复 */
      NETDEV_ALARM_ACCESS_ELEVATOR                                  = 1435,         /* 入梯报警 */
      NETDEV_ALARM_ACCESS_ELEVATOR_CLEARED                          = 1436,         /* 入梯报警恢复 */
      NETDEV_ALARM_SMART_MOTION_DETECT_ON                           = 1437,         /* 智能运动检测开始告警 */
      NETDEV_ALARM_SMART_MOTION_DETECT_OFF                          = 1438,         /* 智能运动检测结束告警 */
      NETDEV_ALARM_FALL_OBJ_DETECTION                               = 1439,         /* 高空抛物告警 */
      NETDEV_ALARM_CYBER_ATTACK                                     = 1440,         /* 安全攻击 */
      NETDEV_ALARM_FUME                                             = 1441,         /* 烟雾告警 */
      NETDEV_ALARM_TEMPERATURE                                      = 1442,         /* 温度告警 */
      NETDEV_ALARM_LOITERING                                        = 1443,          /* 区域徘徊 */
      NETDEV_ALARM_FALL_OVER_DETECTION                              = 1444,          /* 跌倒检测 */
      NETDEV_ALARM_FIGHT_DETECTION                                  = 1445,          /* 打架检测 */
      NETDEV_ALARM_OFF_DUTY_DETECTION                               = 1446,          /* 离岗检测 */
      NETDEV_ALARM_SLEEPING_DETECTION                               = 1447,          /* 睡岗检测 */
      NETDEV_ALARM_CLIMBING_DETECTION                               = 1448,          /* 攀高检测 */
      NETDEV_ALARM_INVALID                                          = 0xFFFF        /* 无效值  Invalid value */
  };

  public enum NETDEV_AUDIO_SAMPLE_FORMAT_E
  {
      NETDEV_AUDIO_SAMPLE_FMT_NONE = -1,
      NETDEV_AUDIO_SAMPLE_FMT_U8 = 0,            /* 无符号8位整型 */
      NETDEV_AUDIO_SAMPLE_FMT_S16 = 1,            /* 有符号16位整型 */
      NETDEV_AUDIO_SAMPLE_FMT_S32 = 2,            /* 有符号32位整型 */
      NETDEV_AUDIO_SAMPLE_FMT_FLT = 3,            /* 浮点型 */
      NETDEV_AUDIO_SAMPLE_FMT_DBL = 4             /* double型 */
  };

  public enum NETDEV_TMS_PERSION_IMAGE_TYPE_E
  {
      NETDEV_TMS_PERSION_IMAGE_TYPE_FULL_VIEW = 1,         /* 全景图 */
      NETDEV_TMS_PERSION_IMAGE_TYPE_FACE = 2,              /* 人脸图 */
      NETDEV_TMS_PERSION_IMAGE_TYPE_INVALID
  };

  public enum NETDEV_TMS_PERSION_IMAGE_FORMAT_E
  {
      NETDEV_TMS_PERSION_IMAGE_FORMAT_JPG = 1,            /* JPEG */
      NETDEV_TMS_PERSION_IMAGE_FORMAT_BMP = 2,            /* BMP */
      NETDEV_TMS_PERSION_IMAGE_FORMAT_PNG = 3,            /* PNG */
      NETDEV_TMS_PERSION_IMAGE_FORMAT_GIF = 4,            /* GIF */
      NETDEV_TMS_PERSION_IMAGE_FORMAT_TIFF = 5,           /* TIFF */
      NETDEV_TMS_PERSION_IMAGE_FORMAT_INVALID
  };

  public enum NETDEV_TMS_CAR_PLATE_COLOR_E
  {
      NETDEV_TMS_CAR_PLATE_COLOR_WHITE = 0,             /* 白色 */
      NETDEV_TMS_CAR_PLATE_COLOR_YELLOW = 1,            /* 黄色 */
      NETDEV_TMS_CAR_PLATE_COLOR_BLUE = 2,              /* 蓝色 */
      NETDEV_TMS_CAR_PLATE_COLOR_BLACK = 3,             /* 黑色 */
      NETDEV_TMS_CAR_PLATE_COLOR_OTHER = 4,             /* 其它颜色 */
      NETDEV_TMS_CAR_PLATE_COLOR_GREEN = 5,             /* 绿色，农用车 */
      NETDEV_TMS_CAR_PLATE_COLOR_RED = 6,               /* 红色 */
      NETDEV_TMS_CAR_PLATE_COLOR_YELLOW_AND_GREEN = 7,  /* 黄绿双色 */
      NETDEV_TMS_CAR_PLATE_COLOR_GRADIENT_GREEN = 8,    /* 渐变绿色 */
  };

  public enum NETDEV_MODEL_STATUS_E
  {
      NETDEV_MODEL_STATUS_TYPE_UNMODELED                      = 0,        /*0:未建模 */
      NETDEV_MODEL_STATUS_TYPE_SUCCEED                        = 1,        /* 1:已建模 */
      NETDEV_MODEL_STATUS_TYPE_FAILED                         = 2,        /* 2:建模失败 */
      NETDEV_MODEL_STATUS_TYPE_INVALID                        = 0xFF      /* 无效值 */
  };

    /**
    * @enum tagNETDEVRecordSearchType
    * @brief 按位查询录像类型枚举
    * @attention 无 None
    */
    public enum NETDEV_RECORD_SEARCH_TYPE_E
    {
        NETDEV_RECORD_SEARCH_TYPE_ALL                       = 0x00000000,               /* 查找时使用，全部录像类型 */
        NETDEV_RECORD_SEARCH_TYPE_MANUL                     = 0x00000001,               /* 手动录像 */
        NETDEV_RECORD_SEARCH_TYPE_EVENT                     = 0x00000002,               /* 通用类告警（NVR暂不支持） */
        NETDEV_RECORD_SEARCH_TYPE_MOTION                    = 0x00000004,               /* 运动检测 */
        NETDEV_RECORD_SEARCH_TYPE_ALARMIN                   = 0x00000008,               /* 输入开关量 */
        NETDEV_RECORD_SEARCH_TYPE_VIDEO_LOSS                = 0x00000010,               /* 视频丢失 */
        NETDEV_RECORD_SEARCH_TYPE_AUDIO_DETECT              = 0x00000020,               /* 音频检测 */

        NETDEV_RECORD_SEARCH_TYPE_COMMON                    = 0x00000080,               /* 计划录像(常规录像) */
        NETDEV_RECORD_SEARCH_TYPE_FACE_DETECT               = 0x00000100,               /* 人脸检测 */
        NETDEV_RECORD_SEARCH_TYPE_LINE_DETECT               = 0x00000200,               /* 越界检测 */
        NETDEV_RECORD_SEARCH_TYPE_FIELD_DETECT              = 0x00000400,               /* 区域入侵 */
        NETDEV_RECORD_SEARCH_TYPE_FOCUS_DETECT              = 0x00000800,               /* 虚焦检测 */
        NETDEV_RECORD_SEARCH_TYPE_SCENE_CHANGE              = 0x00001000,               /* 场景变更 */
        NETDEV_RECORD_SEARCH_TYPE_SMART_TRACK               = 0x00002000,               /* 智能运动跟踪事件 */

        NETDEV_RECORD_SEARCH_TYPE_URGENT_BELL               = 0x00004000,               /* 紧急铃 */
        NETDEV_RECORD_SEARCH_TYPE_REMAIN_ARTICLE            = 0x00020000,               /* 物品遗留 */
        NETDEV_RECORD_SEARCH_TYPE_MOVE_ARTICLE              = 0x00040000,               /* 物品搬移 */

        NETDEV_RECORD_SEARCH_TYPE_HUMAN_DETECT              = 0x00200000,               /* 人形检测 */
        NETDEV_RECORD_SEARCH_TYPE_ELEVATOR_ENTRANCE_DETECT  = 0x20000000,               /* 入梯检测 */
        NETDEV_RECORD_SEARCH_TYPE_FALL_OBJ_DETECT           = 0x40000000,               /* 高空抛物检测 */
        NETDEV_RECORD_SEARCH_TYPE_SMART_RECORD              = 0x60263F20,               /* 所有智能类告警  0010 0000 0010 0110 0011 1111 0010 0000*/

        NETDEV_RECORD_SEARCH_TYPE_INVALID                   = 0x7FFFFFFF                /* 无效值 */
    };

    /**
     * @enum NETDEV_STORE_TYPE_E
     * @brief 录像存储类型 枚举定义 Recording storage type Enumeration definition
     * @attention 无 None
     */
    public enum NETDEV_STORE_TYPE_E
    {
        NETDEV_STORE_TYPE_COMMON                        = 0,                /* 常规存储 */  
        NETDEV_STORE_TYPE_DIGITIALINPUT                 = 1,                /* 开关量输入告警存储 */
        NETDEV_STORE_TYPE_MANUL                         = 2,                /* 手动存储 */
        NETDEV_STORE_TYPE_AUDIODETECT                   = 3,                /* 音频检测告警存储 */
        NETDEV_STORE_TYPE_MOTION                        = 4,                /* 运动检测告警存储 */
        NETDEV_STORE_TYPE_DIGITALINPUT                  = 5,                /* 数字输入事件存储  Digital input */
        NETDEV_STORE_TYPE_FACEDETECT                    = 6,                /* 人脸检测告警存储 */
        NETDEV_STORE_TYPE_VIDEO_LOSS                    = 7,                /* 视频丢失存储 */
        NETDEV_STORE_TYPE_LINEDETECT                    = 8,                /* 越界检测告警存储 */
        NETDEV_STORE_TYPE_FIELDDETECT                   = 9,                /* 区域入侵检测告警存储 */
        NETDEV_STORE_TYPE_FOCUSDETECT                   = 10,               /* 图像虚焦告警存储 */
        NETDEV_STORE_TYPE_SCENECHANGE                   = 11,               /* 场景变更告警存储 */
        NETDEV_STORE_TYPE_ALARM                         = 12,               /* 告警 */
        NETDEV_STORE_TYPE_ALARM_AND_MOTION              = 13,               /* 运动检测 和 告警 */
        NETDEV_STORE_TYPE_ALARM_OR_MOTION               = 14,               /* 运动检测 或 告警 */
        NETDEV_STORE_TYPE_CAMERA_DISCONNECT             = 15,               /* 监控点断线 */
        NETDEV_STORE_TYPE_THIRD_STREAM                  = 16,               /* 第三流存储 */
        NETDEV_STORE_TYPE_EVENT_ALL_ALARM               = 17,               /* 事件类型录像，包涵所有告警类型 */
        NETDEV_STORE_TYPE_EVENT_ALL_TYPE                = 18,               /* 事件类型录像，包涵所有录像类型 */
        NETDEV_PLAN_STORE_TYPE_EVENT_WITHOUT_RESUME     = 19,               /* 没有恢复的事件类型存储 */
        NETDEV_STORE_TYPE_SMART_TRACK                   = 20,               /* 智能跟踪 */
        NETDEV_STORE_TYPE_URGENT_BELL                   = 21,               /* 紧急铃 */
        NETDEV_STORE_TYPE_REMAIN_ARTICLE                = 22,               /* 物品遗留 */
        NETDEV_STORE_TYPE_MOVE_ARTICLE                  = 23,               /* 物品搬移 */
        NETDEV_STORE_TYPE_SMART_RECORD                  = 24,               /* 所有智能类告警 */
        NETDEV_PLAN_STORE_TYPE_MAX                      = 25,               /* 存储类型最大值 */
        NETDEV_STORE_TYPE_HUMAN_DETECT                  = 26,               /* 人形检测 */
        NETDEV_STORE_TYPE_ELEVATOR_ENTRANCE_DETECT      = 27,               /* 入梯检测 */
        NETDEV_STORE_TYPE_FALL_OBJ_DETEC                = 28,               /* 高空抛物检测 */
        NETDEV_STORE_TYPE_INVALID                       = 0xFF              /* 无效值 */
    };

    /**
     * @enum tagNETDEVRuleType
     * @brief 规则类型 枚举定义
     * @attention 无 None
     */
    public enum NETDEV_RULE_TYPE_E
    {
        NETDEV_RULE_TYPE_INTRUSION_DETECTION                    = 0,       /* 区域入侵 */
        NETDEV_RULE_TYPE_CROSSLINE_DETECTION                    = 1,       /* 越界检测 */
        NETDEV_RULE_TYPE_LEAVE_ZONE                             = 2,       /* 离开区域 */
        NETDEV_RULE_TYPE_ENTER_ZONE                             = 3,       /* 进入区域 */
        NETDEV_RULE_TYPE_ELEVATOR_ENTRANCE_DETECTION            = 4,       /* 入梯检测报警 */
        NETDEV_RULE_TYPE_SMD                                    = 5,       /* SMD(智能运动检测) */
        NETDEV_RULE_TYPE_INVALID                                = 0xff     /* 无效值 */
    };

    /**
 * @enum tagNETDEVCFGCmd
 * @brief   Parameter configuration command words Enumeration definition
 * @attention  None
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARSE_VIDEO_DATA_S
    {
        public byte pucData;             /* Pointer to video data */
        public Int32 dwDataLen;            /* Video data length */
        public Int32 dwVideoFrameType;     /* NETDEV_VIDEO_FRAME_TYPE_E  Frame type, see enumeration #NETDEV_VIDEO_FRAME_TYPE_E */
        public Int32 dwVideoCodeFormat;    /* #NETDEV_VIDEO_CODE_TYPE_E  Video encoding format, see enumeration #NETDEV_VIDEO_CODE_TYPE_E */
        public Int32 dwHeight;             /* Video image height */
        public Int32 dwWidth;              /* Video image width */
        public Int64 tTimeStamp;           /* Time stamp (ms) */
        public Int64 tAbTime;              /* 绝对时间(unix时间戳)，当前仅回放流存在 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ORIENTATION_INFO_S
    {
        public Int32 dwDirection;/* Direction Info see enumeration #NETDEV_PTZ_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;              /* Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_STATUS_S
    {
        public float fPanTiltX;                         /* 绝对水平坐标  Absolute horizontal coordinates*/
        public float fPanTiltY;                         /* 绝对竖直坐标  Absolute vertical coordinates*/
        public float fZoomX;                            /* 绝对聚焦倍数  Absolute multiples*/
        public Int32 enPanTiltStatus;/* 云台状态  PTZ Status*/
        public Int32 enZoomStatus;   /* 聚焦状态  Focus Status*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ABSOLUTE_MOVE_S
    {
        public float fPanTiltX;                         /* 绝对水平坐标  Absolute horizontal coordinates*/
        public float fPanTiltY;                         /* 绝对竖直坐标  Absolute vertical coordinates*/
        public float fZoomX;                            /* 绝对聚焦倍数  Absolute multiples*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PT_POSITION_INFO_S
    {
        public float fLongitude;                        /* 云台经度（云台水平移动角度）范围：[0.00, 360.00] */
        public float fLatitude;                         /* 云台纬度（云台上下翻转角度） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                            /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_POSITION_INFO_S
    {
        public Int32 dwTopLeftX;           /* 左上角X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* 左上角Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* 右下角X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* 右下角Y [0, 10000]  Lower right corner y [0, 10000] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_TIME_SECTION_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szBeginTime;                                                   /* 开始时间*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szEndTime;                                                   /* 结束时间 */
        public UInt32 udArmingType;                /* 布防类型 参考NETDEV_ARMING_TYPE_E*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_DAY_PLAN_S
    {
        public Int32 udwIndex;                                                  /* 星期索引  day index */
        public Int32 udwSectionNum;                                             /* 每天时间段个数  Section Num NVR最大为8段,IPC最大为4段 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_TIME_SECTION_NUM)]
        public NETDEV_VIDEO_TIME_SECTION_S[] astTimeSection;                     /* 布防时间段配置 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_WEEK_PLAN_S
    {
        public Int32 bEnabled;           /* 布防计划是否使能,仅IPC支持该字段 */
        public Int32 udwDayNum;           /* 计划天数,NVR最大为8(一周七天和假日);IPC最大为7(一周七天) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_DAY_NUM)]
        public NETDEV_VIDEO_DAY_PLAN_S[] astDayPlan;                     /* 一周内每天的布防计划列表*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_RULE_S
    {
        public Int32 udwPreRecordTime;           /* 警前预录时间，单位秒,取值：0,5,10,20,30,60 */
        public Int32 udwPostRecordTime;           /* 警后录像时间，单位秒,取值：5，10,30,60，120,300,600 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_PLAN_CFG_INFO_S
    {
        public Int32                    bPlanEnable;            /* 计划使能 */
        public Int32                    bRedundantStorage;      /* 冗余录像使能 */
        public NETDEV_RECORD_RULE_S     stRecordRule;           /* 录像计划规则 */
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;             /* 计划配置 */
        public UInt32                   udwChlID;               /* 视频输入通道号 批量获取/添加时使用 */
        public UInt32                   udwReqSeq;              /* 请求数据序号 [1, 50] 仅VMS支持 添加录像计划Post必选 */
        public UInt32                   udwTamplateID;          /* 时间模板ID 仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
        public byte[]                   szTamplateName;         /* 时间模板名称 仅VMS支持 Get接口返回 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[]                   byRes;                  /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S
    {
        public Int32 udwFaceId;                                         /* 人脸ID */
        public IntPtr pcPicBuff;                                        /* 图片缓存，Base64编码(使用完后需在SDK内部free) */
        public Int32 udwPicBuffLen;                                     /* 图片缓存长度 */
        public Int32 enImgType;                                         /* 图像类型，参考枚举NETDEV_TMS_PERSION_IMAGE_TYPE_E */
        public Int32 enImgFormat;                                       /* 图像格式，参考枚举NETDEV_TMS_PERSION_IMAGE_FORMAT_E */
        NETDEV_FACE_POSITION_INFO_S stFacePos;                          /* 人脸坐标---画面坐标归一化：0-10000 ;  矩形左上和右下点："138,315,282,684" */
        public Int32 udwImageWidth;                                     /* 图像宽度 */
        public Int32 udwImageHeight;                                    /* 图像高度 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAMER_ID_LEN)]
        public char[] szCamerID;                                        /* 相机编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_FACE_RECORD_ID_LEN)]
        public char[] szRecordID;                                       /* 记录ID号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_FACE_TOLLGATE_ID_LEN)]
        public char[] szTollgateID;                                     /* 卡口编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_PASSTIME_LEN)]
        public char[] szPassTime;                                       /* 经过时刻,YYYYMMDDHHMMSSMMM，时间按24小时制。第一组MM表示月，第二组MM表示分，第三组MMM表示毫秒 */
        public UInt32   udwFaceNum;                                     /* 人脸个数 全景图时有效*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_IPV4_LEN_MAX)]
        public byte[]   szIPAddr;                                       /* 设备IP地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 76)]
        public byte[] byRes;                                            /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_PIC_INFO_S
    {
        public Int32 udwPicSize;       /* 图片大小 */
        public IntPtr pcPicData;       /* 图片数据 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_XML_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_CAMID_LEN)]
        public byte[] szCamID;                                          /* 卡口相机编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_RECORDID_LEN)]
        public byte[] szRecordID;                                       /* 记录ID号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_TOLLGATE_LEN)]
        public byte[] szTollgateID;                                     /* 卡口编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_PASSTIME_LEN)]
        public byte[] szPassTime;                                       /* 经过时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_LANEID_LEN)]
        public byte[] szLaneID;                                         /* 经过时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAR_PLATE_CARPLATE_LEN)]
        public byte[] szCarPlate;                                       /* 车牌号码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_IPV4_LEN_MAX)]
        public byte[] szIPAddr;                                         /* 设备IP */
        public Int32 dwCarPlateColor;                                   /* 号牌颜色，参见枚举NETDEV_TMS_CAR_PLATE_COLOR_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
        public byte[] byRes;                                            /*   Reserved field*/
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_INFO_S
    {
        public Int32 udwPicNum;                                           /* 图片个数 Picture Number */
        public NETDEV_TMS_CAR_PLATE_XML_INFO_S stTmsXmlInfo;                                /* XML信息 XML Information */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_PIC_COMMON_NUM)]
        public NETDEV_TMS_CAR_PLATE_PIC_INFO_S[] stTmsPicInfo;      /* 图片信息 Picture Message */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PIC_QUERY_COND_S
    {
        public UInt32 udwSearchID;                                            /* 业务号 */
        public UInt32 udwLimit;                                               /* 每次查询的数量 */
        public UInt32 udwOffset;                                              /* 从当前序号开始查询，序号从0开始 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PIC_QUERY_RESULT_S
    {
        public UInt32 udwTotal;                                               /* 查询结果总个数 */
        public UInt32 udwNum;                                                 /* 当前返回数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] byRes;                                                  /* 保留字段 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PICTURE_DATA_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] pucData;                /* pucData[0]: Y plane pointer, pucData[1]: U plane pointer, pucData[2]: V plane pointer */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Int32[] dwLineSize;              /* ulLineSize[0]: Y line spacing, ulLineSize[1]: U line spacing, ulLineSize[2]: V line spacing */
        public Int32 dwPicHeight;                /* Picture height */
        public Int32 dwPicWidth;                 /* Picture width */
        public Int32 dwRenderTimeType;           /* Time data type for rendering */
        public Int64 tRenderTime;                /* Time data for rendering */
    };

    //[StructLayout(LayoutKind.Sequential)]
    //public struct NETDEV_VIDEO_STREAM_INFO_S
    //{
    //    public Int32 enStreamType;       /* NETDEV_LIVE_STREAM_INDEX_E*/
    //    public Int32 bEnableFlag;        
    //    public Int32 dwHeight;           /* -Height */
    //    public Int32 dwWidth;            /* -Width */
    //    public Int32 dwFrameRate;        
    //    public Int32 dwBitRate;          
    //    public Int32 enCodeType;         /* NETDEV_VIDEO_CODE_TYPE_E*/
    //    public Int32 enQuality;          /* UW_VIDEO_QUALITY_E*/
    //    public Int32 dwGop;              /* I */
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //    public byte[] szReserve;
    //}

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_OPERATEAREA_S
    {
        public Int32 dwBeginPointX;                           /* X[0,10000]  Area start point X value [0,10000] */
        public Int32 dwBeginPointY;                           /* Y[0,10000]  Area start point Y value [0,10000] */
        public Int32 dwEndPointX;                             /* X[0,10000]  Area end point X value [0,10000] */
        public Int32 dwEndPointY;                             /* Y [0,10000]  Area end point Y value [0,10000] */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_POINT_S
{
        public Int32 dwPresetID;                     /* ID  Preset ID */
        public Int32 dwStayTime;                     /* Stay time */
        public Int32 dwSpeed;                        /* Speed */
        public Int32 dwID;                           /* 巡航动作ID */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_LIST_S
    {
        public Int32 dwSize;                                         /* Number of patrol routes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_CRUISEROUTE_NUM)]
        public NETDEV_CRUISE_INFO_S[] astCruiseInfo;      /* Information of patrol routes */
    };

//    [StructLayout(LayoutKind.Sequential)]
//    public struct NETDEV_IMAGE_SETTING_S
//{
//        public Int32 dwContrast;                   /* Contrast */
//        public Int32 dwBrightness;                 /* Brightness */
//        public Int32 dwSaturation;                 /* Saturation */
//        public Int32 dwSharpness;                  /* Sharpness */
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
//        public byte[]  byRes;                     /* Reserved */
//};


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_NTP_INFO_S
{
        public Int32 bSupportDHCP;                      /* DHCP  Support DHCP or not */
        public NETDEV_SYSTEM_IPADDR_S stAddr;          /* NTP   NTP information */
};
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_NTP_INFO_LIST_S
    {
        public Int64 ulNum;                      /*  NTP Server Number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public NETDEV_SYSTEM_IPADDR_INFO_S[] astNTPServerInfoList;          /* NTP   NTP information */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                    byRes;                               /* Reserved */
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_IPADDR_INFO_S
    {
        public string bEnabled;                      /*NTP Server enable 0:unable  1:enable */
        public Int64  ulAddressType;                 /*Address type  0:IPv4  1:IPv6(Temporary does not support)  2:domain name(NVR and AIO support)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szIPAddress;                   /* The IP address of the NTP server ,character length range [0,64]. When address type is 0,the node must be selected. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szDomainName;                  /*The domain name of the NTP server ,character length range [0,64]. When address type is 2,the node must be selected.*/

        public Int64 ulPort;                         /*NTP Port ,the range of [1-65535]. IPC does not support this configuration. */
        public Int64 ulSynchronizeInterval;          /*Synchronize Interval: The support range of NVR and VMS is 5/10/15/30 minutes ,1/2/3/6/12 hours ,1 day ,and 1 week.The support range of IPC is 30-3600 seconds.
                                                     All of the above time periods need to be converted to a time value in seconds.*/
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]  byRes;                               /* Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_LIST_S
{   
        public Int32 dwSize;                                                 /* Number of booleans  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_ALARM_OUT_NUM)]
        public NETDEV_ALARM_OUTPUT_INFO_S[]  astAlarmOutputInfo;           /* Boolean configuration information */
};

    [StructLayout(LayoutKind.Sequential)]
    public  struct NETDEV_TRIGGER_ALARM_OUTPUT_S
{
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szName;          /* Boolean name */
        public NETDEV_RELAYOUTPUT_STATE_E  enOutputState;                  /* ,#NETDEV_RELAYOUTPUT_STATE_E  Trigger status, see enumeration #NETDEV_RELAYOUTPUT_STATE_E */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_SCOPE_S
{
        public Int32  dwLocateX;             /** x[0,10000] * Coordinates of top point x [0,10000] */
        public Int32  dwLocateY;             /** y[0,10000] * Coordinates of top point y [0,10000] */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TIME_S
{
        public Int32                    bEnableFlag;        /** OSD BOOL_TRUEBOOL_FALSE * Enable time OSD, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public Int32                    bWeekEnableFlag;    /** () * Display week or not (reserved) */
        public NETDEV_AREA_SCOPE_S     stAreaScope;        /**  * Area coordinates */
        public UInt32                  udwTimeFormat;      /** OSDNETDEV_OSD_TIME_FORMAT_E * Time OSD format, see NETDEV_OSD_TIME_FORMAT_E */
        public UInt32                  udwDateFormat;      /** OSDNETDEV_OSD_DATE_FMT_E * Date OSD format, see NETDEV_OSD_TIME_FORMAT_E */

};

//    [StructLayout(LayoutKind.Sequential)]
//    public struct NETDEV_OSD_TEXT_OVERLAY_S
//{
//        public bool                    bEnableFlag;                /** OSD BOOL_TRUEBOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
//        public NETDEV_AREA_SCOPE_S     stAreaScope;                /** OSD * OSD text overlay area coordinates */
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TEXT_MAX_LEN)]
//        public char[]                    szOSDText;    /** OSD * OSD text overlay name strings */
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        public byte[]                    byRes;                               /* Reserved */
//};


//    [StructLayout(LayoutKind.Sequential)]
//    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
//{
//        public Int32   bIsEanbled;           /* Enable or not. */
//        public Int32   dwTopLeftX;           /* X [0, 10000]  Upper left corner X [0, 10000]  */
//        public Int32   dwTopLeftY;           /* Y [0, 10000]  Upper left corner Y [0, 10000]  */
//        public Int32   dwBottomRightX;       /* X [0, 10000]  Lower right corner x [0, 10000] */
//        public Int32   dwBottomRightY;       /* Y [0, 10000]  Lower right corner y [0, 10000] */
//        public Int32   dwIndex;              /* Index */
//};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_EFFECT_S
{
    public Int32 dwContrast;                   /* Contrast */
    public Int32 dwBrightness;                 /* Brightness */
    public Int32 dwSaturation;                 /* Saturation */
    public Int32 dwHue;                        /* Hue */
    public Int32 dwGamma;                      /* Gamma */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] byRes;                    /* Reserved */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct array
{
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_COLUMN)]
    public Int16[] wTemp;
}

//    [StructLayout(LayoutKind.Sequential)]
//    public struct NETDEV_MOTION_ALARM_INFO_S
//{
//    public Int32  dwSensitivity;                                                     /* Sensitivity */
//    public Int32  dwObjectSize;                                                      /* Objection Size */
//    public Int32  dwHistory;                                                         /* History */
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_ROW)]
//    public array[] awScreenInfo;                                                       /* Screen Info */
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
//    public byte[] byRes;                                                             /* Reserved */
//};


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_S
    {
        public Int32 dwYear;                       /* Year */
        public Int32 dwMonth;                      /* Month */
        public Int32 dwDay;                        /* Day */
        public Int32 dwHour;                       /* Hour */
        public Int32 dwMinute;                     /* Minute */
        public Int32 dwSecond;                     /* Second */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GEOLACATION_INFO_S
    {
        public float fLongitude;       /* 经度 Longitude */
        public float fLatitude;        /* 纬度 Latitude */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_CFG_S
{
    public NETDEV_TIME_ZONE_E       dwTimeZone;             /* see NETDEV_TIME_ZONE_E */
    public NETDEV_TIME_S            stTime;                 /* Time */
    public Int32                    bEnableDST;             /* 夏令时使能 DST enable */
    public NETDEV_TIME_DST_CFG_S    stTimeDSTCfg;           /* 夏令时配置 DST time config*/
    public UInt32                   udwDateFormat;          /* 日期格式 0：YYYY-MM-DD 年月日 1：MM-DD-YYYY 月日年 2：DD-MM-YYYY 日月年*/
    public UInt32                   udwHourFormat;          /* 时间格式 0 ：12小时制  1:24 小时制*/
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
    public byte[]                   byRes;                  /* Reserved */
};
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DST_CFG_S
{
    public NETDEV_TIME_DST_S stBeginTime;        /* 夏令时开始时间 参见枚举#NETDEV_TIME_DST_S  DST begin time see enumeration NETDEV_TIME_DST_S */
    public NETDEV_TIME_DST_S stEndTime;          /* 夏令时结束时间 参见枚举#NETDEV_TIME_DST_S  DST end time see enumeration NETDEV_TIME_DST_S */
    public Int32 dwOffsetTime;       /* 夏令时节约时间 参见枚举# NETDEV_DST_OFFSET_TIME  DST saving time see enumeration NETDEV_DST_OFFSET_TIME */
};
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DST_S
{
    public Int32 dwMonth;              /* Month(1~12)*/
    public Int32 dwWeekInMonth;        /* 1 for the first week and 5 for the last week in the month */
    public Int32 dwDayInWeek;          /* 0 for Sunday and 6 for Saturday see enumeration NETDEV_DAY_IN_WEEK_E */
    public Int32 dwHour;               /* Hour */
};
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REV_TIMEOUT_S
{
    public Int32         dwRevTimeOut;                /* Set receive time out */
    public Int32         dwFileReportTimeOut;         /* Set file report time out*/
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] byRes;                              /* Reserved */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_LOGIN_INFO_S
{    
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
    public string    szIPAddr;       /* IP地址/域名 */
    public Int32   dwPort;                         /* 端口号 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_132)]
    public string    szUserName;     /* 用户名 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
    public string    szPassword;     /* 密码 */
    public Int32   dwLoginProto;                   /* 登录协议, 参见NETDEV_LOGIN_PROTO_E */
    public Int32   dwDeviceType;                   /* 设备类型, 参见NETDEV_DEVICE_TYPE_E */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public byte[] byRes;                              /* Reserved */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SELOG_INFO_S
    {
        public Int32 dwSELogCount;
        public Int32 dwSELogTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IPADDR_INFO_S
{
    public Int32 dwType;                            /* 地址类型，参见枚举NETDEV_IP_ADDRESS_TYPE_E */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    public string szIPAddr;      /* IP地址/域名 */
    public Int32 dwPort;                            /* 端口号 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_USER_SIMPLE_INFO_S
{    
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
    public string szUserName;       /* 用户名 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string szPassword;       /* 密码 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ONVIF_INFO_S
{   
    public Int32   udwTransportMode;                          /* 传输模式，参见枚举NETDEV_TRANS_PROTOCOL_E */

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GBINFO_S
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public string szUniCode;      /* 国标资源编码，范围[1, 32]*/
    public Int32   udwTransport;                  /* 传输模式 0: TCP 1: UDP*/
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] byRes;                      /* 保留字节 */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_LOCK_INFO_S
    {
        public UInt32   udwType;                        /* 锁类型 0: WIFI锁 1: NBIoT锁 */
        public UInt32   udwSignal;                      /* 锁信号 详见 NETDEV_LOCK_SIGNAL_E */
        public UInt32   udwStatus;                      /* 锁状态 0：在线  1：离线*/
        public UInt32   udwBatteryPercent;              /* 电量，取值范围[0,100] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]   szSN;                           /* 锁设备序列号，字符串范围[0,20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]   szIMEI;                         /* 国际移动设备识别码 Type为1时携带,字符串长度范围[1,16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]   szVersion;                      /* 锁版本信息 字符串长度范围[1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_480)]
        public byte[]   szRoomName;                     /* 绑定房间名称 字符串长度范围[1, 128]*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]   byRes;                          /* 保留字节 */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_BASIC_INFO_S
{
    public NETDEV_IPADDR_INFO_S stDevAddr;                         /* 设备IP地址信息 */
    public NETDEV_USER_SIMPLE_INFO_S stDevUserInfo;                /* 设备用户名、密码 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public byte[] szDevName;                    /* 设备名称 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 516)]
    public string szDevDesc;                /* 设备描述 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string szDevModel;               /* 设备型号 */
    public Int32 dwDevID;                                          /* 设备ID */
    public Int32 dwDevStatus;                                      /* 设备状态, 参考# NETDEV_DEVICE_STATUS_E */
    public Int32 dwDevType;                                        /* 设备类型，参考# NETDEV_DEVICE_MAIN_TYPE_E */
    public Int32 dwDevSubType;                                     /* 设备子类型，参考# NETDEV_DEVICE_SUB_TYPE_E */
    public Int32 dwOrgID;                                          /* 组织编号 */
    public Int32 dwAccessProtocol;                                 /* 接入协议 */
    public Int32 dwAccessMode;                                     /* 接入方式 参考# NETDEV_DEVICE_ACCESS_MODE_E*/
    public Int32 dwServerID;                                       /* 所属服务器ID */
    public Int32 dwAudioResID;                                     /* 音频通道ID */
    public Int32 dwIsPTZNeeded;                                           /* 是否需要云台 0:  不需要 1:  需要 255: 自适应 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
    public string  szVIIDCode;                 /* 视图库编码,仅卡口设备时有效 */
    public Int32 dwVIIDStatus;                                     /* 视图库状态，用来标识当前设备是否已通过视图库协议连接，0：离线 1：在线 */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
    public string szSerialNum;                        /* 设备序列号*/
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
    public string szSoftVersion;                     /* 软件版本号*/
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public string szMacAddr;                          /* MAC地址*/
    public Int32 dwStoreStatus;                                    /* 设备存储状态。0: 空闲 1: 未格式化 2: 格式化中3: 运行中*/
    public NETDEV_ONVIF_INFO_S stOnvifInfo;                        /* onvif信息 */
    public NETDEV_GBINFO_S stGBInfo;                               /* 国标信息 当AccessProtocol值为3时该节点必选，其他可选*/
    public IntPtr   pstSmartLockInfo;                               /* 锁设备信息 需调用者分配内存,参见NETDEV_SMART_LOCK_INFO_S */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
    public byte[]   szManufacture;                              /* 厂商名称 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public byte[]   szDeviceCode;                               /* 设备编码 [1,32] 添加播放盒时必选  */
    public IntPtr   pstPlayerInfo;                              /* 播放盒信息 当Type为11时必选 需要malloc分配内存,NETDEV_IPM_PLAYER_BASIC_INFO_S */
    public UInt32   udwCustomProtocolID;                        /* 自定义协议ID，当AccessProtocol值为4时该节点必选 */
    public UInt32   udwChlMaxNum;                               /* 设备通道号最大数量，当AccessProtocol值为4时该节点必选 */
    public UInt32   udwChlIndexNum;                             /* 设备通道号数量，当AccessProtocol值为4时该节点必选，上限256 */
    public IntPtr   pudwChlIndexList;                           /* 通道号列表，需动态分配内存，建议分配256个 UINT32 */
    public Int32    dwImageProtocol;                            /* 图片协议，设备类型Type为5智能设备时必带 1:私有 2:视图库 */
};

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_FIND_COND_S
{
    public UInt32 udwOrgType;              /* 组织类型 参见NETDEV_ORG_TYPE_E */
    public UInt32 udwRootOrgID;            /* 根节点组织ID */
    public UInt32 udwFindType;             /* 查找模式，参见NETDEV_ORG_FIND_MODE_E */
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] byRes;
};

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_INFO_S
{
    public Int32 dwOrgID;                              /* 组织ID */
    public Int32 dwParentID;                           /* 组织父节点ID */
    public Int32 dwType;                               /*  see NETDEV_ORG_TYPE_E */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
    public byte[] szNodeName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_DESCRIBE_MAX_LEN)]
    public string szDesc;
    public Int32  udwTime;                               /* 创建时间，UTC时间 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
    public byte[] szUserName;                           /* 创建人 [1,64] */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
    public byte[] byRes;
};
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEL_ORG_INFO_S
    {
        public Int32 dwOrgNum;     /* 组织数量 */
        public IntPtr pdwOrgIDs;   /* 需要删除的组织ID，根据dwOrgNum 动态申请(INT32*) */
        public Int32 dwOrgType;    /* 组织类型 见 NETDEV_ORG_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;    /* 保留字段  Reserved field*/
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_BATCH_DEL_INFO_S
    {
        public Int32 dwStatus;                             /* 响应状态，类型 参见 NETDEV_ORG_RESPONSE_STAUTE_E */
        public Int32 dwNum;                                /* 响应数量 */
        public IntPtr pstResultInfo;      /*批量删除返回信息，根据删除数量动态申请(NETDEV_OPERATE_INFO_S[])*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        public byte[] byRes;                            /* 保留字段  Reserved field*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_RES_S
{
    public Int32   dwResType;                          /* 资源类型，参见枚举#NETDEV_EVENT_RES_TYPE_E */
    public Int32   dwResID;                            /* 资源ID */
    public Int32   dwFirstSubResID;                    /* 第一子资源ID */
    public Int32   dwSecondSubResID;                   /* 第二子资源ID 不同资源类型对应意义不同。如：电视墙分屏资源的资源ID是电视墙ID，第一子资源ID是窗口ID，第二子资源ID就是分屏ID*/

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] byRes;
};

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_INFO_S
{
    public Int32                   dwSize;                                     /* 资源数量 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
    public NETDEV_EVENT_RES_S[]      astEventRes;     /* 事件资源信息 */
    public Int32                   dwEventActionType;                          /* 事件类型，参见枚举#NETDEV_EVENT_ACTION_TYPE_E */
    public IntPtr    pstEventRes;                                /* 超过NETDEV_MAX_EVENT_RES_SIZE的事件资源信息 需要动态申请*/
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
    public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_LIST_S
    {
        public UInt32                       udwObjectType;                  /* 目标类型 参见枚举 NETDEV_OBJECT_TYPE_E */
        public UInt32                       udwObjectID;                    /* 目标ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                       byRes;                          /* 保留字段 */
    };

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_V30_S
{
    public Int32 dwAlarmType;                                  /* 告警类型，参见枚举#NETDEV_ALARM_TYPE_E  Alarm type, see enumeration #NETDEV_ALARM_TYPE_E */
    public Int32 dwAlarmSubType;                               /* 告警子类型，参见NETDEV_ALARM_SUBTYPE_E */
    public Int32 dwAlarmLevel;                                 /* 告警等级，1到5级，1级最严重 */
    public Int64 tAlarmTimeStamp;                              /* 告警发生时间  Alarm occurrence time */
	public Int32 dwChannelID;                                  /* 通道ID,非一体机设备使用  Channel ID */
	public Int32 dwAlarmID;                                    /* 告警ID，一体机设备使用 */
    public Int32 dwAlarmSrcID;                                 /* 告警源ID 参见枚举#NETDEV_ALARM_SRC_TYPE_E
                                                        note:
                                                        1. dwAlarmSrcType为NETDEV_ALARM_SRC_LOCAL_HARD_DISK到NETDEV_ALARM_SRC_SD_STORAGE_DISK之间，dwAlarmID代表存储盘索引；
                                                        2. dwAlarmSrcType为8，dwAlarmID代表视频通道号；
                                                        3. dwAlarmSrcType为9，dwAlarmID代表报警输入通道号，报警源见dwInputSwitchID字段。
                                                        4. dwAlarmSrcType为10,dwAlarmID默认为0,代表系统本身
                                                        */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 68)]
    public string   szAlarmSrc;      /* 告警源信息（名称） */
    public Int32    IsAlarmSnapExisted;                            /* 告警是否有抓图 0没有抓图 1有抓图  vms使用*/
    public UInt16   wIndex;                                     /* 索引号  Index number, index number */
    public Int32    dwTotalBandWidth;                           /* 当前带宽总量,单位为MBps  Current total bandwidth (in MBps) */
    public Int32    dwUnusedBandwidth;                          /* 未使用的带宽,单位为MBps  Bandwidth left (in MBps)*/
    public Int32    dwTotalStreamNum;                           /* 总路数 Total cameras*/
    public Int32    dwFreeStreamNum;                            /* 未使用路数 Cameras left */
    public Int32    dwMediaMode;                                /* 流类型,参见枚举#NETDEV_MEDIA_MODE_E Stream type. For enumerations, see#NETDEV_MEDIA_MODE_E*/
    public Int32    dwEventCode;                                  /* 事件类型，用于上报解码层事件类型，参见枚举# NETDEV_PLAYER_RUN_INFO_TYPE_E */
    public Int32    dwReserved;                                   /* 异常上报保留参数，用于上报解码层保留参数 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
    public byte[]   szFileName;                                     /* ND上报字符串参数信息 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
    public byte[]   szDeviceID;                                     /* 告警设备ID，国标协议接入时填写国标注册码。长度[1,32]。IPC、VM平台支持 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public byte[]   szRelatedID;                                    /* 告警事件与告警数据的关联ID,同一个相机内全局唯一。长度为15个字符.当告警存在与之关联数据时，需携带此字段 */
    public Int32    dwObjectNum;                                    /* 目标个数  Object Num */
    public IntPtr   pstObjectList;                                  /* 目标列表 Object List 需根据dwObjectNum动态申请内存,NETDEV_OBJECT_LIST_S */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 144)]
    public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REPORT_INFO_S
{
    public Int32                       dwReportType;       /* 上报类型，参见枚举#NETDEV_REPORT_TYPE_E */
    public NETDEV_ALARM_INFO_V30_S     stAlarmInfo;        /* 告警信息，当dwReportType为NETDEV_REPORT_TYPE_ALARM时有效 */
    public NETDEV_EVENT_INFO_S         stEventInfo;        /* 事件信息，当dwReportType为NETDEV_REPORT_TYPE_EVENT时有效 */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_BASE_INFO_S
{    
    public Int32 dwChannelID;                                      /* 通道ID */
    public Int32 dwDevID;                                          /* 设备ID */
    public Int32 dwOrgID;                                          /* 组织ID */
    public Int32 dwChnType;                                        /* 通道类型，参见 NETDEV_CHN_TYPE_E */
    public Int32 dwChnStatus;                                      /* 通道状态, 参见 NETDEV_CHN_STATUS_E */
    public Int32 dwChnIndex;                                       /* 通道索引 */

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public byte[] szChnName;                    /* 通道名称 */
    public UInt32 udwRight;                                        /* 通道权限 */
    public UInt32 udwAbnormalReason;                               /* 视频通道异常的原因 参见 NETDEV_CHN_OFFLINE_REASON_E */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
    public byte[] byRes;
};

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STREAM_FORMAT_INFO_S
{
    public UInt32                           udwStreamIndex;             /* 视频流索引 参考 NETDEV_LIVE_STREAM_INDEX_E */
    public UInt32                           udwEncodeFormat;            /* 编码格式 参考 NETDEV_VIDEO_CODE_TYPE_E */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] byRes;
};

[StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_ENCODE_INFO_S
{
    public NETDEV_DEV_CHN_BASE_INFO_S stChnBaseInfo;  /* 通道基本信息 */
    public Int32                       dwMaxStream;    /* 支持的最大流个数 */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public NETDEV_STREAM_FORMAT_INFO_S[] astStreamFormatList;             /* Disk info*/
    public Int32                        bSupportPTZ;    /* 是否支持云台 */
    public Int32                        bScrambleEnable;    /* 码流是否加扰使能 */
    public Int32                       dwAudioResID;   /* 音频资源ID */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public byte[] szGBResID;    /** 国标资源ID */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
    public byte[] byRes;
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISK_INFO_S
{
    public Int32 dwDiskCabinetIndex;
    public Int32 dwSlotIndex;                                                      /* Slot Index */
    public Int32 dwTotalCapacity;                                                  /* Total Capacity*/
    public Int32 dwUsedCapacity;                                                   /* Used Capacity */
    public NETDEV_DISK_WORK_STATUS_E enStatus;                                                         /* Status */
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
    public String szManufacturer;                                                 /* Manufacturer */
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISK_INFO_LIST_S
{
    public Int32 dwSize;                                  /*Disk number */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DISK_MAX_NUM)]
    public NETDEV_DISK_INFO_S[] astDisksInfo;             /* Disk info*/
};

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS
    {
        public Int32 dwChannelID;                    /* 通道号  Channel ID */
        public Int32 dwRecordType;                   /* 录像类型 0:手动录像1:事件录像2:交易录像3:定时录像4:其他*/
        public Int32 dwRecordStatus;                 /* 录像状态 0:正在录像1:未启动存储2:没有硬盘或硬盘坏3:通道不在线*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                       /* 保留字节 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS_LIST_S
    {
        public UInt32 udwSize;                                 /* 录像状态数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public NETDEV_RECORD_STATUS[] astRecordStatus;      /* 录像状态信息 */
    }

    /**
    * @struct tagNETDEVAudioSampleParamType
    * @brief 音频参数
    * @attention 无
    */
    public struct NETDEV_AUDIO_SAMPLE_PARAM_S
{
    public Int32 dwChannels;                               /* 声道数,单声道为1,立体声为2 */
    public Int32 dwSampleRate;                             /* 采样率 */
    public NETDEV_AUDIO_SAMPLE_FORMAT_E enSampleFormat;    /* 位宽 */
};

    /**
     * @struct tagNETDEVPersonLibCapInfo
     * @brief 人脸库容量信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_CAP_INFO_S
    {
        public UInt32 udwLibID;            /* 库ID */
        public UInt32 udwCapacity;         /* 库容量信息，单位：人 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;          /* 保留字段 */
    }

    /**
     * @struct tagNETDEVPersonLibCapList
     * @brief 所有人员库的容量信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_CAP_LIST_S
    {
        public UInt32 udwMaxPerpleMun;                         /* 总库容量，单位：K人 */
        public UInt32 udwFreePerpleNum;                        /* 剩余容量，单位：人 */
        public UInt32 udwMaxLibNum;                            /* 最大可建库容量 */
        public UInt32 udwFreeLibNum;                           /* 剩余可建库容量 */
        public UInt32 udwNum;                                  /* 已建库个数 库个数范围:[0, 16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_PERSON_LIB_CAP_INFO_S[] stLibCapInfoList;         /* 单库容量信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* 保留字段 */
    }

    /**
    * @struct tagNETDEVLibInfo
    * @brief 库信息
    * @attention 人员库和车辆库
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LIB_INFO_S
    {
        public UInt32 udwID;                           /* 库ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;          /* 库名称 范围[1,63] */
        public UInt32 udwType;                         /* 人员库类型 详情参见枚举NETDEV_PEOPLE_LIB_TYPE_E*/
        public UInt32 udwPersonNum;                    /* 库中人员信息的总数 */
        public UInt32 udwFaceNum;                      /* 库中人脸照片总数 */
        public UInt32 udwMemberNum;                    /* 库中成员的总数 */
        public UInt32 udwLastChange;                   /* 库的信息的最后修改时间 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public string szBelongIndex;   /* 库的唯一归属索引 */
        public Int32 bIsMonitored;                    /* 是否已布控，获取库信息时必带 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                      /* 保留字节 */
    }

    /**
    * @struct tagNETDEVPersonLibList
    * @brief 人员库信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_LIST_S
    {
        public UInt32 udwNum;                     /* 设备中已创建的库数量 */
        public IntPtr pstLibInfo;                 /* 库列表信息,需动态分配内存（参见NETDEV_LIB_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                 /* 保留字节 */
    }

    /**
     * @struct tagNETDEVDeleteDBFlagInfo
     * @brief 删除库信息标志位
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DELETE_DB_FLAG_INFO_S
    {
        public Int32 bIsDeleteMember;       /* 是否删除库下里面的成员信息：0:不删除 1:删除 */
        public UInt32 udwDevID;             /* 设备ID(仅VMS删除人脸库支持) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;            /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVPersonQueryInfo
     * @brief 人员信息查询条件
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_QUERY_INFO_S
    {
        public UInt32 udwNum;             /* 查询条件数量 */
        public IntPtr pstQueryInfos;      /* 查询条件列表，Num为0时，不带此字段（参见NETDEV_QUERY_INFO_S）*/
        public UInt32 udwLimit;           /* 每次查询的数量，最大20 */
        public UInt32 udwOffset;          /* 从当前序号开始查询，序号从0开始 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @struct tagNETDEVBatchOperateBasicInfo
     * @brief 批量查询返回的基本信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_BASIC_S
    {
        public UInt32 udwTotal;       /* 数量 */
        public UInt32 udwOffset;      /* 查询起始序号 */
        public UInt32 udwNum;         /*查询结果总数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVRegionInfo
    * @brief 成员地区信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REGION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szNation;          /* 国籍，范围[1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szProvince;        /* 省份，范围[1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szCity;            /* 城市，范围[1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

    /**
    * @enum tagNETDEVPersonTimeTemplateInfo
    * @brief 时间模板相关信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_TIME_TEMPLATE_INFO_S
    {
        public UInt32 udwBeginTime;    /* 时间模板生效起始时间 若未配置，填写0 */
        public UInt32 udwEndTime;      /* 时间模板生效结束时间 若未配置，填写4294967295(0xFFFFFFFF)*/
        public UInt32 udwIndex;        /* 时间模板索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;      /* 保留字节 */
    }

    /**
    * @struct tagNETDEVIdentificationInfo
    * @brief 成员证件信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IDENTIFICATION_INFO_S
    {
        public UInt32 udwType;                     /* 证件类型 详情参见枚举 NETDEV_ID_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public string szNumber;     /* 证件号，范围:[1, 20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                  /* 保留字节 */
    }

    /**
    * @struct tagNETDEVFileInfo
    * @brief 文件信息
    * @attention 若udwSize不为0且pcData为空,则通过szUrl获取图片
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szName;   /* 文件名称 范围[1, 16]*/
        public UInt32 udwSize;                 /* 文件大小[data或通过szurl获取到的图片大小(Base64编码后)] */
        public UInt32 dwFileType;              /* 文件类型，详见枚举值：NETDEV_FILE_TYPE_E */
        public UInt32 udwLastChange;           /* 最后修改时间，UTC时间，单位为s */
        public IntPtr pcData;                 /* 文件数据 Base64 需根据udwSize 动态申请内存(CHAR*)*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public string szUrl;   /* 图片URL，长度范围[0,256] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字节 */
    }

    /**
    * @struct tagNETDEVImageInfo
    * @brief 人脸图片信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_INFO_S
    {
        public UInt32 udwFaceID;                   /* 人脸照片ID */
        public NETDEV_FILE_INFO_S stFileInfo;      /* 照片信息 */
        public UInt32 udwModelStatus;              /* 建模状态,详见枚举值: NETDEV_MODEL_STATUS_E  ModelStatus,See NETDEV_MODEL_STATUS_E for details*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                  /* 保留字节 */
    }

    /**
     * @struct tagNETDEVCustomValue
     * @brief 自定义属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CUSTOM_VALUE_S
    {
        public UInt32 udwID;                                         /* 自定义属性名称序号 从0开始*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_CUSTOM_LEN)]
        public string szValue;        /* 自定义属性值 范围[1,63]*/
        public UInt32 udwModelStatus;                                /* 建模状态，即将人脸图片转为半结构化数据的状态。0：未建模 1：已建模 2：建模失败 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVStaffInfo
     * @brief 员工信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STAFF_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szNumber;                       /* 人员编号 字符串长度范围[1, 16] */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szBirthday;                     /* 出生日期 字符串长度范围[1,31] */
        public UInt32 udwDeptID;                                     /* 部门ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szDeptName;                    /* 部门名称 添加时可不携带 字符串长度范围[1, 64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVVisitorInfo
     * @brief 访客信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VISITOR_INFO_S
    {
        public UInt32 udwVisitorCount;                               /* 访客人数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szCompany;                     /* 访客单位 字符串长度范围[1, 64] */
        public UInt32 udwIntervieweeID;                              /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVPersonInfo
    * @brief 人员信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_INFO_S
    {
        public UInt32 udwPersonID;                         /* 人员ID */
        public UInt32 udwLastChange;                       /* 人员信息最后修改时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szPersonName;        /* 人员名字 范围:[1, 63] */
        public UInt32 udwGender;                           /* 成员性别 详情参见枚举NETDEV_GENDER_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szBirthday;           /* 成员出生日期，格式YYYYMMDD，范围[1,31] */
        public NETDEV_REGION_INFO_S stRegionInfo;                        /* 成员地区信息 */
        public UInt32 udwTimeTemplateNum;                  /* 时间模板数量 */
        public IntPtr pstTimeTemplateList;                 /* 时间模板相关信息 需动态分配(参见NETDEV_PERSON_TIME_TEMPLATE_INFO_S) */
        public UInt32 udwIdentificationNum;                /* 证件信息个数 范围:[0, 6]*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_8)]
        public NETDEV_IDENTIFICATION_INFO_S[] stIdentificationInfo;  /* 成员证件信息 */
        public UInt32 udwImageNum;                         /* 人脸图片个数 范围:[0, 6] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_8)]
        public NETDEV_IMAGE_INFO_S[] stImageInfo;           /* 人脸图片信息列表 */
        public UInt32 udwReqSeq;                           /* 请求数据序列号，此字段会在返回结果中待会，仅在批量添加中携带该字段 */
        public Int32 bIsMonitored;                        /* 是否已布控，获取时必带，仅VMS支持 */
        public UInt32 udwBelongLibNum;                     /* 所属人员库数量，仅VMS支持 */
        public IntPtr pudwBelongLibList;                   /* 所属人员库ID列表，需动态分配内存，仅VMS支持(UINT32*) */
        public UInt32 udwCustomNum;                        /* 自定义属性值数量，最多5个，仅VMS支持 */
        public IntPtr pstCustomValueList;                  /* 自定义属性值列表，需动态分配内存，当Num为0时可以不填（参见NETDEV_CUSTOM_VALUE_S） */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szTelephone;          /* 联系电话 字符串长度[1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szAddress;           /* 地址 字符串长度范围[1, 64] */
        public UInt32 udwCardNum;                          /* 门禁卡个数 取值范围[0,6],Get时携带 */
        public UInt32 udwFingerprintNum;                   /* 指纹个数，取值范围[0,10] */
        public UInt32 udwType;                             /* 人员类型 0：员工 1：访客 2：陌生人 */
        public NETDEV_STAFF_INFO_S stStaff;                             /* 员工信息 Type为员工时必填 */
        public NETDEV_VISITOR_INFO_S stVisitor;                           /* 访客信息 Type为访客时必填 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_480)]
        public byte[] szDesc;              /* 备注信息 字符串长度范围[1, 128] */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public string szPersonCode;         /* 人员编码，可填写学号或工号，范围:[1, 15] PTS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szRemarks;            /* 备注信息 范围:[1-63] PTS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 176)]
        public byte[] byRes;                          /* 保留字节 */
    }

    /**
    * @struct tagNETDEVPersonInfoList
    * @brief 人员信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_INFO_LIST_S
    {
        public UInt32 udwNum;                                          /* 人员库人员个数 */
        public IntPtr pstPersonInfo;      /* 人员信息列表,需动态分配内存（参见NETDEV_PERSON_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                     /* 保留字节 */
    }

    /**
    * @struct tagNETDEVFaceInfo
    * @brief 人脸信息结果
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_INFO_S
    {
        public UInt32 udwFaceID;           /* 人员ID */
        public UInt32 udwResultCode;       /* 处理结果状态码，详见#NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;          /* 保留字节 */
    }

    /**
    * @struct tagNETDEVPersonList
    * @brief 人员信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIST_S
    {
        public UInt32 udwPersonID;                                 /* 人员ID */
        public UInt32 udwFaceNum;                                  /* 人脸个数 批量单次最多6个 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_8)]
        public  NETDEV_FACE_INFO_S[] stFaceInfo;        /* 人脸信息结果列表 */
        public UInt32 udwReqseq;                                   /* 请求数据序号,仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                  /* 保留字节 */
    }

    /**
    * @struct tagNETDEVPersonResultList
    * @brief 人员信息结果列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_RESULT_LIST_S
    {
        public UInt32 udwNum;                                          /* 人员个数 */
        public IntPtr pstPersonList;                   /* 人员信息执行结果列表,需动态分配内存 malloc by caller（参见NETDEV_PERSON_LIST_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                      /* 保留字节 */
    }

    /**
     * @struct tagNETDEVBatchOperateMemberList
     * @brief 批量操作成员列表 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_MEMBER_LIST_S
    {
        public UInt32 udwTaskNo;             /* 操作任务号，仅NVR支持 */
        public UInt32 udwMemberNum;          /* 成员数量 */
        public IntPtr pstMemberIDList;       /* 成员列表 根据udwNum进行动态申请(UINT32*) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */

    }

    /**
     * @struct tagNETDEVBatchOperatorInfo
     * @brief 批量操作信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATOR_INFO_S
    {
        public UInt32 udwReqSeq;                          /* 请求数据序号 */
        public UInt32 udwResultCode;                      /* 返回错误码,人脸布控操作结果详见# NETDEV_PERSON_MONITOR_OPT_RES_CODE_E */
        public UInt32 udwID;                              /* 编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;             /* 成员名称，长度范围[1,63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVBatchOperateList
     * @brief 批量操作列表 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATOR_LIST_S
    {
        public UInt32 udwNum;         /* 批量操作数量 */
        public UInt32 udwStatus;      /* 结果状态 */
        public IntPtr pstBatchList;   /* 批量操作信息 最大是2000个,需动态申请（参见 NETDEV_BATCH_OPERATOR_INFO_S ） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POINT_S
    {
        public Int32 dwPointX;     /* 横坐标,万分比 */
        public Int32 dwPointY;     /* 纵坐标,万分比 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POSTION_INFO_S
    {
        public Int32 udwChannelId;                          /* 通道ID */
        public NETDEV_POINT_S stPoint;                      /* 火点中心位置在通道中的坐标信息,图像中火点位置坐标万分比表示,范围[0,9999) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                /* 保留字段 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FIRE_POINT_INFO
    {
        public Int32 udwChannelNum;                            /* 通道个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_POSTION_INFO_S[] stPositionList;  /* 火点在不同通道下的位置列表。当ChannelNum不为0时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                            /* 保留字段 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CONFLAGRATION_ALARM_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szReference;                          /* 订阅者描述信息 */
        public Int32 udwTimeStamp;                          /* 告警时间 UTC时间 单位秒 */
        public Int32 udwAlarmSeq;                           /* 告警序号 */
        public NETDEV_GEOLACATION_INFO_S stPTPosition;      /* 发现火点位置时的云台位置 */
        public float fLensView;                             /* 发现火点位置时的镜头视场角角度，精确到小数点后两位 */
        public Int32 udwNum;                                /* 火点数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_FIRE_POINT_INFO[] stFirePointInfoList;/* 不同火点的位置信息列表，当Num不为0时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                /* 保留字段 */
    };

    /**
     * @struct tagstNETDEVAlarmLogInfo
     * @brief 告警日志信息
     * @attention
     */
    public struct NETDEV_ALARM_LOG_INFO_S
    {
        public Int32 dwAlarmID;                                      /* 告警ID */
        public Int32 dwAlarmType;                                    /* 告警类型 参见# NETDEV_ALARM_TYPE_E*/
        public Int32 dwAlarmSubType;                                 /* 告警子类型,参见# NETDEV_ALARM_SUBTYPE_E */
        public Int32 dwAlarmLevel;                                   /* 告警等级 0：紧急 1：重要 2：次要 3：警告 4：提示 */
        public Int32 dwServerID;                                     /* 所属服务器 */
        public Int32 dwDevID;                                        /* 设备ID */
        public Int32 dwChannelID;                                    /* 通道ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
        public byte[]  szAlarmSrc;                                   /* 告警源信息 */
        public Int64 tAlarmTime;                                     /* 告警发生时间 UTC时间格式，单位为秒 */
        public Int32 bAlarmChecked;                                  /* 告警是否被确认，0：未确认 1：确认 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] szAlarmCheckUser;                              /* 告警确认用户 */
        public Int64 tAlarmCheckTime;                                /* 告警确认时间 UTC时间格式，单位为秒 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 516)]
        public byte[] szAlarmCheckDesc;                              /* 告警确认描述 */
        public Int32 dwAlarmLinkType;                                /* 告警联动类型 */
        public Int32 IsAlarmSnapExisted;                             /* 告警是否有抓图 0没有抓图 1有抓图*/
        public Int32 dwAlarmSrcBelong;                               /* 告警所属，参见#NETDEV_ALARM_SRC_BELONG_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 516)]
        public byte[] szAlarmDetail;                                  /* 告警详情，补充业务层需要展示的信息 */
        public Int32 dwHasRelatedData;                                      /* 告警是否存在关联数据 0：不存在 1：存在 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 244)]
        public byte[] byRes;                                            /* 保留字段 */
    }

    /**
     * @struct tagstNETDEVAlarmLogCond
     * @brief 告警日志查询条件
     * @attention  查询“告警类型”时，携带的告警主类型或子类型数量均不能超过16个。
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_QUERY_INFO_S
    {
        public Int32 dwQueryType;                                /* 查询条件类型，参见# NETDEV_QUERYCOND_TYPE_E */
        public Int32 dwLogicFlag;                                /* 查询条件逻辑类型，参见#NETDEV_QUERYCOND_LOGICTYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CODE_STR_MAX_LEN)]
        public byte[] szConditionData;   /* 查询条件右值 */
    }

    /**
     * @struct tagstNETDEVAlarmLogCondList
     * @brief 告警日志所有查询条件
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_LOG_COND_LIST_S
    {
        public Int32 dwPageRow;                                                      /* 每页最大条数 */
        public Int32 dwFirstRow;                                                     /* 分页查询中第一条数据的序号 */
        public Int32 dwCondSize;                                                     /* 查询条件数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LOG_QUERY_COND_NUM)]
        public  NETDEV_QUERY_INFO_S[] astCondition;            /* 查询条件右值 */
    }

    /**
     * @struct tagstNETDEVFaceAlarmLogResultInfo
     * @brief 告警记录返回信息（人脸识别和车牌识别）
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_ALARM_LOG_RESULT_INFO_S
    {
        public UInt32 udwTotal;                     /* 告警记录总数 */
        public UInt32 udwOffset;                    /* 记录偏移量 */
        public UInt32 udwNum;                       /* 此次返回告警记录个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                   /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVFaceMemberRegionInfo
     * @brief 人脸库成员地区信息 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_REGION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szNation;                       /* 国籍 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szProvince;                     /* 省份 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szCity;                         /* 城市 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                    /* 保留字段  Reserved */

    }

    /**
     * @struct tagNETDEVFaceMemberIDInfo
     * @brief 成员证件信息 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_ID_INFO_S
    {
        public UInt32 udwType;                                       /*证件类型 参见枚举 NETDEV_FACE_MEMBER_ID_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_FACE_IDNUMBER_LEN)]
        public string szNumber;            /* 证件号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                     /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVFaceMemberInfo
     * @brief 人脸库成员信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_INFO_S
    {
        public UInt32 udwReqSeq;                                                   /* 请求数据序号 */
        public UInt32 udwMemberID;                                                 /*人脸库成员ID   只读 post消息时不带*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_NAME_LEN)]
        public byte[] szMemberName;                   /* 成员名称 */
        public UInt32 udwMemberGender;                                             /* 成员性别 参见枚举 NETDEV_GENDER_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_BIRTHDAY_LEN)]
        public string szMemberBirthday;           /* 成员出生日期 */
        public NETDEV_FACE_MEMBER_REGION_INFO_S stMemberRegionInfo;                /* 成员地区信息 */
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                    /* 成员证件信息 */
        public NETDEV_FILE_INFO_S stMemberImageInfo;                 /* 人脸图片信息 */
        public NETDEV_FILE_INFO_S stMemberSemiInfo;                  /* 人脸半结构化信息 */
        public UInt32 udwCustomNum;                                                /* 自定义属性值数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_CUSTOM_NUM)]
        public NETDEV_CUSTOM_VALUE_S[] stCustomValue;        /* 自定义属性值列表 */
        public Int32 bIsMonitored;                                               /* 是否已布控  0未布控，1已布控 */
        public UInt32 udwDBNum;                                                   /* 所属人脸库数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;                                /* 人脸库ID列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                                 /* 保留字段  Reserved */

    }

    /**
     * @struct tagstNETDEVFaceAlarmImageArea
     * @brief 区域坐标
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_IMAGE_AREA_S
    {
        public UInt32 udwLeft;          /* 左坐标 */
        public UInt32 udwTop;           /* 上坐标 */
        public UInt32 udwRight;         /* 右坐标 */
        public UInt32 udwButtom;        /* 下坐标 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                 /* 保留字段  Reserved */
    }

    /**
     * @struct tagstNETDEVFaceAlarmLogSnapImage
     * @brief 抓拍图片信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_SNAP_IMAGE_S
    {
        public NETDEV_FILE_INFO_S stBigImage;                /* 大图 */
        public NETDEV_FILE_INFO_S stSmallImage;              /* 小图 */
        public NETDEV_FACE_ALARM_IMAGE_AREA_S stArea;        /* 区域坐标 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                            /* 保留字段  Reserved */
    }

    /**
     * @struct tagstNETDEVFaceAlarmCmpInfo
     * @brief 人脸抓拍告警记录比对信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_CMP_INFO_S
    {
        public UInt32 udwSimilarity;                            /* 相似度 */
        public NETDEV_FACE_MEMBER_INFO_S stMemberInfo;          /* 人脸库成员信息 */
        public NETDEV_FACE_ALARM_SNAP_IMAGE_S stSnapshotImage;  /* 抓拍图片 */
        public IntPtr pstPersonInfo;                            /* 人脸库成员信息(NVR支持) 查询匹配成功/失败记录携带 需malloc申请内存，参见NETDEV_PERSON_INFO_S */
        public IntPtr pstFaceAttr;                              /* 人脸属性信息，参见NETDEV_FACE_ATTR_S */
        public IntPtr pstPersonAttr;                            /* 关联人员属性信息，参见NETDEV_PERSON_ATTR_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }


    /**
     * @struct tagstNETDEVFaceRecordSnapshotInfo
     * @brief 人脸识别记录
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_RECORD_SNAPSHOT_INFO_S
    {
        public UInt32 udwRecordID;                                       /* 人脸识别记录ID */
        public UInt32 udwRecordType;                                     /* 人脸识别记录类型 参见# NETDEV_FACE_PASS_RECORD_TYPE_E */
        public UInt32 udwPassTime;                                       /* 过人时间 UTC格式 */
        public UInt32 udwEventType;                                      /* 事件类型 按BIT位进行类型描述，相应BIT为1，表示属于该类型，为0表示不属于该类型。BIT0:人脸抓拍BIT1:人脸匹配告警BIT2:人脸不匹配告警*/
        public UInt32 udwChannelID;                                      /* 通道ID */
        public UInt32 udwMonitorRuleID;                                  /* 告警对应的布控ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szChannelName;                     /* 抓拍通道名称 */
        public NETDEV_FACE_ALARM_CMP_INFO_S stCompareInfo;                /* 比对信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                        /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVMonitorQueryInfo
     * @brief 布控信息查询条件
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_QUERY_INFO_S
    {
        public UInt32 udwLimit;           /* 每次查询的数量，最大20 */
        public UInt32 udwOffset;          /* 从当前序号开始查询，序号从0开始 */
        public Int32 bIsQueryAll;        /* 是否查询所有，是:TRUE,否:FALSE */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @struct tagNETDEVEnabledActParamInfo
     * @brief 使能联动参数
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ENABLED_ACT_PARAM_INFO_S
    {
        public Int32 bEnabled;       /* 使能标记 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @brief  输出开关量的逻辑报警状态(手动告警)
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S
    {
        public Int32 dwBooleanId;                            /* 开关量编号  Boolean ID */
        public Int32 dwChannelId;                            /* 通道ID,设备本身为0 */
        public Int32 enAlarmStatus;                          /* 输出开关量报警状态 参见#NETDEV_RELAYOUTPUT_STATE_E */
    }

    /**
     * @struct tagNETDEVOutputSwitchActParamInfo
     * @brief 联动开关量输出
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                                                                 /* 联动的开关量输出个数*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_ALARM_OUT_NUM)]
        public NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S[] astOutputAlarmStatusInfo;        /* 联动的开关量输出列表*/
    }

    /**
     * @struct tagNETDEVChannelActParamInfo
     * @brief 通道联动
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                 /* 通道个数*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public Int32[] adwChannelID;        /* 通道ID列表*/
    }

    /**
     * @struct tagNETDEVChannelPreset
     * @brief 联动云台预置位
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_PRESET_S
    {
        public Int32 dwChannelID;                              /* 通道号*/
        public Int32 dwPresetID;                               /* 预置位编号*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @struct tagNETDEVPresetActParamInfo
     * @brief 联动云台预置位
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRESET_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                                      /* 联动动作数量*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public NETDEV_CHANNEL_PRESET_S[] stChannelPreset;        /* 联动到预置位信息列表*/
    }

    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 联动动作列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_INFO_S
    {
        public UInt32 udwActID;                                                   /* 联动动作ID，参见枚举值NETDEV_ALARM_ACT_ID_E */
        public NETDEV_ENABLED_ACT_PARAM_INFO_S stEnabledInfo;                     /* 联动参数使能标记，适用于联动蜂鸣器、联动EMail、联动告警弹窗、 */
        public NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S stOutputSwitchActParamInfo;   /* 联动开关量输出*/
        public NETDEV_CHANNEL_ACT_PARAM_INFO_S stChannelActParamInfo;              /* 联动NVR预览、联动存储、联动抓拍 */
        public NETDEV_PRESET_ACT_PARAM_INFO_S stPresetActParamInfo;               /* 联动云台预置位 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 布控任务联动动作列表 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_LIST_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_LINK_ACTION_NUM)]
        public NETDEV_LINKAGE_ACTION_INFO_S[] stActionInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;         /* 保留字段 */
    }

    /**
     * @struct tagLinkageStrategy
     * @brief 告警联动配置信息 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_STRATEGY_S
    {
        public UInt32 udwType;                /* 告警类型,NETDEV_PERSON_COMPARE_RESULT_TYPE_E */
        public NETDEV_LINKAGE_ACTION_LIST_S stLintageActions;       /* 人脸布控任务联动动作 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;             /* 保留字段 */
    }

    /**
     * @struct tagNETDEVMonitorDefenceInfo
     * @brief 布防信息 结构体定义
     * @attention 仅PTS VMS使用
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_DEFENCE_INFO_S
    {
        public Int64 tBegin;                  /* 时间模板生效起始时间(unix时间戳) */
        public Int64 tEnd;                    /* 时间模板生效结束时间(unix时间戳) */
        public UInt32 udwTimeTemplateID;       /* 时间模板索引，若未配置，则填写0 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段 */
    }

    /**
     * @struct tagNETDEVMemberInfo
     * @brief 人脸/车辆成员信息列表 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MEMBER_INFO_S
    {
        public UInt32 udwMemberID;                              /* 人脸/车辆成员ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szMemberName;                             /* 人脸/车辆成员名称，范围[1,63] */
        public UInt32 udwStatus;                                /* 成员同步状态 人脸参考: NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVMonitorRuleInfo
     * @brief 布控任务配置信息 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_RULE_INFO_S
    {
        public Int32 bEnabled;                                              /* 布控任务使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MONITOR_RULE_NAME_LEN)]
        public byte[] szName;             /* 布控任务的布控名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MONITOR_RULE_REASON_LEN)]
        public byte[] szReason;         /* 布控的布控原因 */
        public UInt32 udwLibNum;                                             /* 任务对应的库数量,最大16个 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public UInt32[] audwLibList;                            /* 库ID列表 */
        public UInt32 udwMonitorType;                                        /* 布控告警类型，0：匹配告警,1：不匹配告警 */
        public UInt32 udwMultipleValue;                                      /* 人脸1：N比较置信度阀值 */
        public UInt32 udwMonitorReason;                                      /*  车辆布控原因：0：被抢车 1：被盗车 2：嫌疑车 3：交通违法车 4：紧急查控车*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[] szMatchSucceedMsg;                     /* 比对成功提示语 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[] szMatchFailedMsg;                      /* 比对失败提示语 */
        public UInt32 udwMemberNum;                                          /* 成员数量 [0-32] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public NETDEV_MEMBER_INFO_S[] stMemberInfo;                           /* 成员信息列表 */
        public UInt32 udwChannelNum;                                         /* 人脸布控任务的布控通道个数 获取单个布控任务详情时必带 */
        public IntPtr pudwMonitorChlIDList;                                 /* 人脸布控任务的布控通道列表 根据udwChannelNum动态确定 上层申请内存(UINT32*) */
        public UInt32 udwDevNum;                                             /* 布控任务的布控设备个数 最多四个,仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public UInt32[] audwMonitorDevIDList;                   /* 布控任务的布控设备列表 根据DevNum动态确定,仅VMS支持*/
        public UInt32 udwMonitorRuleType;                       /* 布控任务智能类型，0：本地智能布控,1：前端智能布控 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
        public byte[] byRes;                                            /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVFaceMonitorInfo
     * @brief 布控任务信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_INFO_S
    {
        public UInt32 udwID;                        /* 人脸布控任务序号 添加布控不再返回该字段 */
        public NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo;            /* 人脸布控任务配置信息 */
        public UInt32 udwLinkStrategyNum;           /* 告警联动策略数量 */
        public IntPtr pstLinkStrategyList;          /* 告警联动策略配置信息，需动态分配内存（参见NETDEV_LINKAGE_STRATEGY_S）*/
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;                   /* 人脸布控任务布防计划,仅NVR IPC使用 */
        public NETDEV_MONITOR_DEFENCE_INFO_S stMonitorDefenceInfo;         /* 布防信息，仅PTS VMS使用 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                   /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVMonitorChlInfo
     * @brief 添加布控返回的布控信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_CHL_INFO_S
    {
        public UInt32 udwChannelID;                       /* 布控对应通道ID IPC、VMS该字段不返回 */
        public UInt32 udwResultCode;                      /* 人脸处理结果码 NETDEV_PERSON_RESULT_CODE_E */
        public UInt32 udwMonitorID;                       /* 相应通道对应的布控ID */
    }

    /**
     * @struct tagNETDEVMonitorResultInfo
     * @brief 添加布控返回的布控信息 Device information Structure definition
     * @attention  None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_RESULT_INFO_S
    {
        public UInt32 udwChannelNum;                  /* 布控添加成功的实际通道数 需赋值标明内存申请大小*/
        public IntPtr pstMonitorChlInfos;             /* 布控返回信息列表 内存由上层申请 不应小于下发的通道数量 malloc by caller （参见NETDEV_MONITION_CHL_INFO_S）*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                     /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVDevMonitorInfo
    * @brief 成员布控设备信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_MONITOR_INFO_S
    {
        public UInt32 udwDevID;               /* 设备ID */
        public UInt32 udwMonitorStatus;       /* 设备布控状态 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字节 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_STATUS_INFO_S
    {
        public UInt32  udwDevID;               /* 设备ID */
        public UInt32  udwChlID;               /* 通道ID 仅布控任务到通道时携带 */
        public UInt32  udwMonitorStatus;       /* 布控状态 见 NETDEV_MONITOR_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]    byRes;              /* 保留字节 */
    };

    /**
    * @struct tagNETDEVMonitorMemberInfo
    * @brief 成员布控状态信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_MEMBER_INFO_S
    {
        public UInt32 udwMemberID;                        /* 成员ID */
        public UInt32 udwMonitorNum;                          /* 布控数量 */
        public UInt32 udwMonitorResult;                   /* 布控总结果 0:布控失败 1:布控成功 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;             /* 成员名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_MONITOR_STATUS_INFO_S[] stMonitorStatusInfo;    /* 布控状态信息列表 目前设备数量最大为5*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                          /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVMonitorCapacityInfo
    * @brief 容量布控信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_INFO_S
    {
        public UInt32 udwMonitorType;         /* 布控类型 0：人脸布控   1：车辆布控 */
        public UInt32 udwNum;                 /* 设备数量 */
        public IntPtr pudwDevIDList;         /* 设备ID列表 根据udwNum动态申请(UINT32*)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVDevCapacityInfo
    * @brief 设备容量信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CAPACITY_INFO_S
    {
        public UInt32 udwDevID;               /* 设备ID */
        public UInt32 udwCapacity;            /* 设备布控人脸总数量 */
        public UInt32 udwMonitoredNum;        /* 已布控人脸数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVMonitorCapacityList
    * @brief 容量布控操作列表结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_LIST_S
    {
        public UInt32 udwDevNum;              /* 设备数量 */
        public IntPtr pstDevCapacityList;     /* 容量列表 根据DevNum动态申请（参见NETDEV_DEV_CAPACITY_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
    * @struct tagstNETDEVPlateAttrInfo
    * @brief 车牌信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szPlateNo;                        /* 车牌号 */
        public UInt32 udwColor;                                        /* 车牌颜色 参见NETDEV_PLATE_COLOR_E */
        public UInt32 udwType;                                         /* 车牌类型，参见NETDEV_PLATE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVVehicleMemberAttr
     * @brief 车辆信息(不能增加预留，会导致NETDEV_VEHICLE_DETAIL_INFO_S预留不够)
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_MEMBER_ATTR_S
    {
        public UInt32 udwColor;                                      /* 车身颜色 详见枚举NETDEV_PLATE_COLOR_E*/
        public NETDEV_FILE_INFO_S stVehicleImage;                    /* 车辆图片 图片加密后大小不超过4M */
    }

    /**
    * @struct tagstNETDEVVehicleOwnerInfo
    * @brief 车主信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_OWNER_INFO_S
    {
        public UInt32                         udwPersonID;                       /* 人员ID，临时车不携带 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                         szPersonName;      /* 人员姓名，长度范围[0,63] */
        NETDEV_IDENTIFICATION_INFO_S stIDInfo;                          /* 证件信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]                         szPhone;            /* 联系方式，长度范围[0,31] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                         szAddress;         /* 地址，长度范围[0,63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                         byRes;                        /* 保留字段  Reserved */
    }

    /**
    * @struct tagstNETDEVVehicleDetailInfo
    * @brief 车辆成员信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_DETAIL_INFO_S
    {
        public UInt32 udwReqSeq;                         /* 请求数据序列号 */
        public UInt32 udwMemberID;                       /* 人脸成员ID */
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;                       /* 车牌信息 */
        public NETDEV_VEHICLE_MEMBER_ATTR_S stVehicleAttr;                     /* 车辆信息 */
        public Int32 bIsMonitored;                      /* 是否已布控 0未布控 1已布控 */
        public UInt32 udwDBNum;                          /* 所属车辆库数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;       /* 所属车辆库ID数组 */
        public IntPtr pstVehicleOwnerInfo;   /* 车主信息，需申请内存,详见 NETDEV_VEHICLE_OWNER_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVVehicleInfoList
     * @brief 车辆信息列表 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_INFO_LIST_S
    {
        public UInt32 udwVehicleNum;          /* 车辆成员数量 */
        public IntPtr pstMemberInfoList;      /* 车辆成员列表 根据udwNum进行动态申请(参见NETDEV_VEHICLE_DETAIL_INFO_S) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVVehAttr
     * @brief 车辆属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_ATTR_S
    {
        public UInt32 udwType;                                       /* 车辆类型 详见 NETDEV_VEHICLE_TYPE_E */
        public UInt32 udwColor;                                      /* 车身颜色 详见 NETDEV_PLATE_COLOR_E */
        public UInt32 udwSpeedUnit;                                  /* 车辆速度单位 0：公里/每小时 1：英里/每小时 */
        public Single fSpeedValue;                                   /* 车辆速度 */
        public UInt32 udwSpeedType;                                  /* 结构化场景中的机动车车辆速度类型 详见 NETDEV_SPEED_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szVehicleBrand;                 /* 车辆车标编码（自行编码) */
        public UInt32 udwImageDirection;                             /* 结构化场景中的机动车在画面坐标系中的行驶方向 详见 NETDEV_IMAGE_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
    * @struct tagstNETDEVMonitorAlarmInfo
    * @brief 车牌告警布控信息(无法增加预留，会导致NETDEV_VEHICLE_RECORD_INFO_S预留不够)
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_ALARM_INFO_S
    {
        public UInt32 udwMonitorReason;                          /* 布控原因类型 */
        public UInt32 udwMonitorAlarmType;                       /* 布控告警类型 0：匹配告警 1：不匹配告警 */
        public UInt32 udwMemberID;                               /* 车辆成员ID */
    }

    /**
    * @struct tagstNETDEVVehicleRcordInfo
    * @brief 车辆识别记录信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_RECORD_INFO_S
    {
        public UInt32 udwRecordID;                                       /* 车辆识别记录ID */
        public UInt32 udwChannelID;                                      /* 通道ID，抓拍推送时有效 */
        public UInt32 udwPassingTime;                                    /* 过车时间，UTC格式，单位秒*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szChannelName;                     /* 卡口相机名称 */
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;                    /* 车牌抓拍信息 */
        public NETDEV_VEH_ATTR_S stVehAttr;                      /* 车辆抓拍信息 */
        public NETDEV_FILE_INFO_S stPlateImage;                   /* 车牌抓拍图片 图片加密后大小不超过1M*/
        public NETDEV_FILE_INFO_S stVehicleImage;                 /* 车辆抓拍图片 结构化查询时携带 图片加密后大小不超过1M*/
        public NETDEV_FILE_INFO_S stPanoImage;                    /* 全景图 结构化查询时携带 仅携带图片URL和size，图片数据需要通过/LAPI/V1.0/System/Picture接口获取*/
        public NETDEV_MONITOR_ALARM_INFO_S stMonitorAlarmInfo;             /* 车牌告警布控信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
     * @struct tagstNETDEVSubscribeSmartInfo
     * @brief 订阅智能事件信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SUBSCRIBE_SMART_INFO_S
    {
        public UInt32 udwNum;                /* 订阅智能告警数 */
        public IntPtr pudwSmartType;        /* 订阅的智能告警类型 参见枚举 NETDEV_SMART_ALARM_TYPE_E ，根据udwNum动态申请(UINT32*) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
     * @struct tagstNETDEVSmartInfo
     * @brief 智能事件信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_INFO_S
    {
        public Int32 dwChannelID;         /* 通道ID */
        public UInt32 udwSubscribeID;      /* 订阅ID */
        public UInt32 udwSubscribeType;      /* 订阅类型 */
        public UInt32 udwCurrrntTime;      /* 当前时间，UTC格式，单位秒 */
        public UInt32 udwEndTime;          /* 结束时间，UTC格式，单位秒 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
    * @enum tagNETDEVLapiSubInfo
    * @brief Lapi告警订阅信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LAPI_SUB_INFO_S
    {
        public UInt32 udwType;                          /* 订阅类型 按位表示参见 NETDEV_ALARM_TYPE_V30_E */
        public UInt32 udwLibIDNum;                      /* 订阅的库ID数目 LibIDNum为0xffff时 表示订阅所有库 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public UInt32[] audwLibIDList;     /* 订阅的库ID列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
    * @enum tagNETDEVSubscribeSuccInfo
    * @brief 订阅信息成功返回信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SUBSCRIBE_SUCC_INFO_S
    {
        public UInt32 udwID;                      /* 订阅ID */
        public UInt32 udwCurrrntTime;             /* 当前时间，UTC格式，从1970年1月1日0点开始的秒数 */
        public UInt32 udwTerminationTime;         /* 结束时间，UTC格式，从1970年1月1日0点开始的秒数 */
        public UInt32 udwSupportAlarmType;        /* 请求消息携带订阅告警类型时返回值需携带此参数，返回0说明响应未携带该数据 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szReference;/* 订阅者描述信息 以URL格式体现 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

    /**
    * @struct tagNETDEVFeatureInfo
    * @brief 半结构化特征信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FEATURE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szFeatureVersion;        /* 人脸半结构化特征提取算法版本号 [0, 20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_FEATURE_SIZE)]
        public byte[] szFeature;    /* 基于人脸提取出来的特征信息 目前加密前512B */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                             /* 保留字节 */
    }

    /**
    * @struct tagNETDEVPersonCompareInfo
    * @brief 人脸 比对信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_COMPARE_INFO_S
    {
        public UInt32 udwSimilarity;                                  /* 相似度 */
        public NETDEV_PERSON_INFO_S stPersonInfo;                                   /* 人脸库成员信息 */
        public NETDEV_FILE_INFO_S stPanoImage;                                    /* 人脸大图  */
        public NETDEV_FILE_INFO_S stFaceImage;                                    /* 人脸小图 */
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;                                     /* 人脸区域坐标 */
        public UInt32 udwCapSrc;                                      /* 采集来源 */
        public UInt32 udwFeatureNum;                                  /* 半结构化特征数目 如果没有半结构化特征，可不带相关字段 PTS必带 */
        public IntPtr pstFeatureInfo;                                 /* 半结构化特征列表 如果没有半结构化特征，可不带相关字段  PTS必带(NETDEV_FEATURE_INFO_S[]) */
        public NETDEV_FACE_ATTR_S stFaceAttr;                         /* 人脸属性信息 */
        public NETDEV_PERSON_ATTR_S stPersonAttr;                     /* 关联人员属性信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 248)]
        public byte[] byRes;                                     /* 保留字段 */
    }

    /**
    * @struct tagNETDEVFacePassRecordInfo
    * @brief 人脸 通过记录信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_PASS_RECORD_INFO_S
    {
        public UInt32 udwRecordID;                        /* 人脸通行记录ID */
        public UInt32 udwType;                            /* 人脸通行类型，参见枚举NETDEV_FACE_PASS_RECORD_TYPE_E */
        public Int64 tPassingTime;                       /* 过人时间，UTC格式，单位秒 */
        public UInt32 udwChannelID;                       /* 通道ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szChlName;          /* 抓拍通道名称，范围[1,63] */
        public NETDEV_PERSON_COMPARE_INFO_S stCompareInfo;                      /* 比对信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

    /**
    * @struct tagNETDEVPersonEventInfo
    * @brief 人员报警信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_EVENT_INFO_S
    {
        public UInt32 udwID;                                   /* 通知记录ID */
        public UInt32 udwTimestamp;                            /* 通知上报时间 UTC格式，单位秒*/
        public UInt32 udwNotificationType;                     /* 通知类型 0：实时通知1：历史通知 */
        public UInt32 udwFaceInfoNum;                          /* 人脸信息数目 范围：[0, 1] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_2)]
        public NETDEV_FACE_PASS_RECORD_INFO_S[] stCtrlFaceInfo;            /* 人脸信息列表，当采集信息没有人脸时，可不带FaceInfo相关字段 */
        public UInt32 udwFinishFaceNum;                        /* 人脸结束数量 范围：[0, 40] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_40)]
        public UInt32[] audwFinishFaceList;       /* 人脸结束列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 92)]
        public byte[] byRes;                               /* 保留字段 */
    }

    /**
    * @struct tagstVehicleEventInfo
    * @brief 车辆比对报警信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_EVENT_INFO_S
    {
        public UInt32 udwID;                                              /* 通知记录ID */
        public UInt32 udwTimestamp;                                       /* 通知上报时间，UTC格式，单位秒 */
        public UInt32 udwNotificationType;                                /* 通知类型 详见 NETDEV_NOTIFICATION_TYPE_E*/
        public UInt32 udwVehicleInfoNum;                                  /* 车辆信息数目 [0, 1] */
        public IntPtr pstVehicleRecordInfo;       /* 车辆信息列表(NETDEV_VEHICLE_RECORD_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* 保留字段  Reserved */
    }

    /**
    * @struct tagstNETDEVVehRecognitionEvent
    * @brief 车辆识别事件
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_RECOGNITION_EVENT_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_480)]
        public byte[] szReference;                        /* 订阅者描述信息 */
        public UInt32 udwSrcID;                                           /* 告警源ID */
        public NETDEV_VEHICLE_EVENT_INFO_S stVehicleEventInfo;            /* 车辆比对报警信息 需动态申请内存 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVStructAlarmInfo
     * @brief 结构化告警上报信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_ALARM_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szReference;                   /* 描述信息 */
        public UInt32 udwTimeStamp;                                  /* 告警时间 从1970年1月1日0点开始的秒数 */
        public UInt32 udwSeq;                                        /* 告警序号 */
        public UInt32 udwSrcID;                                      /* 告警源ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szSrcName;                     /* 告警源名称 */
        public UInt32 udwNotificationType;                           /* 通知类型 0：实时通知 1：历史通知 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[]   szDeviceID;                     /* 告警设备ID，国标协议接入时填写国标注册码。长度[1,32] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]   szRelatedID;                    /* 关联ID，告警和数据关联；或多通道目标数据的关联，同一个相机内全局唯一。长度为15个字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVFaceAttr
     * @brief 人脸属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ATTR_S
    {
        public UInt32 udwGender;                                     /* 性别 详见 NETDEV_GENDER_TYPE_E */
        public UInt32 udwAgeRange;                                   /* 年龄段 详见 NETDEV_AGE_RANGE_E */
        public UInt32 udwGlassFlag;                                  /* 是否戴眼镜标志 详见 NETDEV_GLASS_FLAG_E */
        public UInt32 udwGlassesStyle;                               /* 眼镜款式 详见 NETDEV_GLASSES_STYLE_E */
        public UInt32 udwMask;                                       /* 口罩 详见 NETDEV_MASK_FLAG_E */
        public float fTemperature;                                   /* 体温 单位：摄氏度 精度：小数点后2位 */
        public UInt32 udwEmotion;                                    /* 情绪情况，未检测时可选 参见 NETDEV_EMOTION_FLAG_E */
        public UInt32 udwSmile;                                      /* 是否微笑，未检测时可选 详见 NETDEV_SMILE_FLAG_E */
        public UInt32 udwAttractive;                                 /* 颜值，未检测时可选 数值范围[0~100] */
        public UInt32 udwSkinColor;                                  /* 肤色，未检测时可选 详见 NETDEV_SKINCOLOR_TYPE_E */
        public UInt32 udwBeard;                                      /* 胡子，未检测时可选 详见 NETDEV_BEARD_FLAG_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVPointInfo
     * @brief 检测区域图形顶点坐标信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POINT_INFO_S
    {
        public UInt32 udwX;                                  /* X轴坐标，范围[0,10000] */
        public UInt32 udwY;                                  /* Y轴坐标，范围[0,10000] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[]   byRes;                             /* 保留字段 */
    };

    /**
     * @struct tagNETDEVRuleInfo
     * @brief 规则信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RULE_INFO_S
    {
        public UInt32   udwRuleType;        /* 规则类型 参见 NETDEV_RULE_TYPE_E */
        public UInt32   udwTrigerType;      /* 规则触发类型 参见 NETDEV_RULE_TRIGGER_TYPE_E */
        public UInt32   udwPointNum;        /* 规则坐标点数量 */
        public IntPtr   pstPointInfo;       /* 检测区域图形各顶点坐标,在顶点个数为0时，这个节点可以没有,NETDEV_POINT_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]   byRes;              /* 保留字段 */
    };

    /**
     * @struct tagNETDEVFaceStructInfo
     * @brief 人脸信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_STRUCT_INFO_S
    {
        public UInt32 udwFaceID;                                     /* 人脸ID */
        public UInt32 udwFaceDoforPersonID;                          /* 人脸所属人员ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 人脸位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 人脸对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 人脸对应的大图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFeaturVersion;                /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 基于人脸提取出来的特征信息 采用base64编码 前加密前512 Bytes */
        public NETDEV_FACE_ATTR_S stFaceAttr;                        /* 人脸属性信息 */
        public IntPtr pstRuleInfo;                                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S */
        public UInt32 udwFaceDoforNonMotorID;                        /* 人脸所属非机动车ID */
        public UInt32 udwFaceDoforVehicleID;                         /* 人脸所属机动车ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVPersonAttr
     * @brief 人员属性
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_ATTR_S
    {
        public UInt32 udwGender;                                     /* 性别 详见 NETDEV_GENDER_TYPE_E */
        public UInt32 udwAgeRange;                                   /* 年龄段 详见 NETDEV_AGE_RANGE_E */
        public UInt32 udwSleevesLength;                              /* 上衣长短款式 详见 NETDEV_SLEEVES_LENGTH_E */
        public UInt32 udwCoatColor;                                  /* 上衣颜色 详见 NETDEV_CLOTHES_COLOR_E */
        public UInt32 udwTrousersLength;                             /* 下衣长短款式 详见 NETDEV_TROUSERS_STYLE_E */
        public UInt32 udwTrousersColor;                              /* 下衣颜色 详见 NETDEV_CLOTHES_COLOR_E */
        public UInt32 udwBodyToward;                                 /* 身体抓怕朝向 详见 NETDEV_BODY_TOWARD_E */
        public UInt32 udwShoesTubeLength;                            /* 鞋子长短款式 详见 NETDEV_SHOES_TUBE_LENGTH_E */
        public UInt32 udwHairLength;                                 /* 发型长短 详见 NETDEV_HAIR_LENGTH_E */
        public UInt32 udwBagFlag;                                    /* 是否携包标志 详见 NETDEV_BAG_FLAG_E */
        public float  fTemperature;                                  /* 体温 单位：摄氏度 精度：小数点后2位 */
        public UInt32 udwMask;                                       /* 口罩 详见 NETDEV_PERSON_MASK_FLAG_E */
        public UInt32 udwCoatTexture;                                /* 上衣纹理 详见 NETDEV_CLOTHES_TEXTURE_E */
        public UInt32 udwMovingDirection;                            /* 人员运动方向 详见 NETDEV_MOVE_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段 详见 */
    }

    /**
     * @struct tagNETDEVPersonStructInfo
     * @brief 人员信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_STRUCT_INFO_S
    {
        public UInt32 udwPersonID;                                   /* 人员ID */
        public UInt32 udwPersonDoforFaceID;                          /* 人员所属人脸ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 人员位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 人员对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 人员对应的大图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFeaturVersion;                /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 半结构化特征厂商类型版本号 采用base64编码 加密前512 Bytes */
        public NETDEV_PERSON_ATTR_S stPersonAttr;                    /* 人员信息 */
        public IntPtr pstRuleInfo;                                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVNonMotorVehicleAttr
     * @brief 非机动车属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NO_MOTOR_VEH_ATTR_S
    {
        public UInt32 udwSpeedType;                                  /* 结构化场景中非机动车速度类型 详见 NETDEV_SPEED_TYPE_E */
        public UInt32 udwImageDirection;                             /* 结构化场景中非机动车相对画面运动方向 详见 NETDEV_IMAGE_DIRECTION_E */
        public UInt32 udwNonVehicleType;                            /* 非机动车类型 详见 NETDEV_NON_VEH_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVNonMotorVehInfo
     * @brief 非机动车信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NON_MOTOR_VEH_INFO_S
    {
        public UInt32 udwID;                                         /* 非机动车ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 非机动车位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 非机动车对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 非机动对应的大图在图像列表中的索引 */
        public NETDEV_NO_MOTOR_VEH_ATTR_S stNoMotorVehAttr;          /* 非机动车属性信息 */
        public UInt32 udwPersonOnNoVehiNum;                          /* 驾乘人员数目 */
        public IntPtr pstPersonAttr;                 /* 人员属性 需动态申请内存(NETDEV_PERSON_ATTR_S[]) */
        public IntPtr pstRuleInfo;                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S[] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVPlateAttr
     * @brief 车牌属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPlateNo;                      /* 车牌号码 */
        public UInt32 udwColor;                                      /* 车牌颜色 详见 NETDEV_PLATE_COLOR_E */
        public UInt32 udwType;                                       /* 车牌类型 详见 NETDEV_PLATE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVVehicleInfo
     * @brief 车辆信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_INFO_S
    {
        public UInt32 udwID;                                         /* 车辆ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 车辆位置信息 */
        public UInt32 udwSmallPicAttachIndex;                       /* 车辆对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 车辆对应的大图在图像列表中的索引 */
        public UInt32 udwPlatePicAttachIndex;                        /* 车牌对应的小图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFeatureVersion;               /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 基于人脸提取出来的特征信息 采用base64编码 加密前512 Bytes */
        public NETDEV_VEH_ATTR_S stVehAttr;                          /* 车辆属性信息 */
        public NETDEV_PLATE_ATTR_S stPlateAttr;                      /* 车牌属性信息 */
        public IntPtr pstRuleInfo;                                  /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S[] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVObjectInfo
     * @brief 目标信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_INFO_S
    {
        public UInt32 udwFaceNum;                                    /* 人脸数量 */
        public IntPtr pstFaceInfo;              /* 人脸信息 需动态申请内存(NETDEV_FACE_STRUCT_INFO_S[]) */
        public UInt32 udwPersonNum;                                  /* 人员数量 */
        public IntPtr pstPersonInfo;          /* 人员信息 需动态申请内存(NETDEV_PERSON_STRUCT_INFO_S[]) */
        public UInt32 udwNonMotorVehNum;                             /* 非机动车数量 */
        public IntPtr pstNonMotorVehInfo;     /* 非机动车信息 需动态申请内存(NETDEV_NON_MOTOR_VEH_INFO_S[]) */
        public UInt32 udwVehicleNum;                                 /* 车辆数量 */
        public IntPtr pstVehInfo;                       /* 车辆信息 需动态申请内存(NETDEV_VEH_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVStructImageInfo
     * @brief 图像相关信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_IMAGE_INFO_S
    {
        public UInt32 udwIndex;                                      /* 图像索引 */
        public UInt32 udwType;                                       /* 图像类型 */
        public UInt32 udwFormat;                                     /* 图像格式 详见 NETDEV_IMAGE_FORMAT_E*/
        public UInt32 udwWidth;                                      /* 图像的宽度 */
        public UInt32 udwHeight;                                     /* 图像的高度 */
        public UInt32 udwCaptureTime;                                /* 图片采集时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szUrl;                         /* 图片URL */
        public UInt32 udwSize;                                       /* 图像经过base64编码之后的长度 最大3M */
        public IntPtr pszData;                                       /* 图像的base64编码数据(CHAR*) */
        public UInt32 udwDataType;                                   /* 上报图片数据类型 详见 NETDEV_REPORT_PIC_DATA_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
     * @struct tagNETDEVStructDataInfo
     * @brief 结构化数据信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_DATA_INFO_S
    {
        public NETDEV_OBJECT_INFO_S stObjectInfo;                    /* 目标信息 */
        public UInt32 udwImageNum;                                   /* 图像个数 */
        public IntPtr pstImageInfo;            /* 图像相关信息 需动态申请内存( NETDEV_STRUCT_IMAGE_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

    /**
    * @struct tagNETDEVCtrlFaceInfo
    * @brief 人脸信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_FACE_INFO_S
    {
        public UInt32 udwID;                                           /* 记录ID */
        public UInt32 udwTimestamp;                                    /* 采集时间 UTC格式，单位秒 */
        public UInt32 udwCapSrc;                                       /* 采集来源 详见 NETDEV_CAP_SRC_E FaceInfo选择1 */
        public UInt32 udwFeatureNum;                                   /* 半结构化特征数目 范围：[0, 2] */
        public IntPtr pstFeatureInfo;                 /* 半结构化特征列表 需动态分配内存(NETDEV_FEATURE_INFO_S[]) */
        public NETDEV_FILE_INFO_S stPanoImage;                         /* 人脸全景图 */
        public NETDEV_FILE_INFO_S stFaceImage;                         /* 人脸小图 */
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;                 /* 人脸全景图人脸区域坐标 */
        public float  fTemperature;                                    /* 人员体温 单位：摄氏度，注：小数点后1位 */
        public UInt32 udwMaskFlag;                                     /* 是否戴口罩，0：未知或未启用检测；1：未戴口罩；2：戴口罩 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] byRes;                                      /* 保留字节 */
    }

    /**
     * @struct tagNETDEVTVwallCode
     * @brief 电视墙编码 结构体定义 
     * @attention 无 None
     */
    public struct NETDEV_TVWALL_CODE_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]   szTVwallCode;   /* 电视墙编码，字符串长度范围[1, 64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]   byRes;          /* 保留字段 */
    };

    /**
    * @struct NETDEVPermissionInfo
     * @brief 权限信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_PERMISSION_INFO_S
    {
        public UInt32   udwMajorPermission;          /* 一级权限 #NETDEV_MAJOR_RIGHT_E */
        public UInt32   udwMinorPermission;          /* 二级权限 #NETDEV_MINOR_RIGHT_XXXX_E */
        public UInt32   udwOrgNum;                   /* 组织数量 */
        public IntPtr   pudwOrgList;                 /* 组织ID列表 需要Malloc申请内存 (UINT32 *)*/
        public UInt32   udwChlNum;                   /* 通道数量 */
        public IntPtr   pudwChlList;                 /* 通道列表 需要Malloc申请内存 (UINT32 *)*/
        public UInt32   udwTvwallNum;                /* 电视墙数量 */
        public IntPtr   pudwTvwallIDList;            /* 电视墙信息列表 需要Malloc申请内存 (UINT32 *) */
        public IntPtr   pstTVwallCodeList;           /* 电视墙编码信息列表 需要Malloc申请内存，NETDEV_TVWALL_CODE_S */
        public UInt32   udwEntranceNum;              /* 出入口数量 */
        public IntPtr   pudwEntranceIDList;          /* 出入口信息列表 需要Malloc申请内存 (UINT32 *) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
        public byte[]   byRes;                      /* 保留字节 */
    }

    /**
    * @struct NETDEVRoleInfo
    * @brief 角色信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_ROLE_INFO_S
    {
        public UInt32                          udwRoleID;                  /* 角色ID 添加角色可选*/
        public UInt32                          udwLevel;                   /* 角色等级 [0,99] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szRoleName;                 /* 角色名称 [1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[]                          szDesc;                      /* 描述长度 [0,256] */
        public UInt32                          udwOrgID;                   /* 组织ID */
        public UInt32                          udwPermissionsNum;          /* 权限数量 */
        public IntPtr                          pstPermissionList;          /* 权限列表 获取角色列表不返回 需要Malloc申请内存 详见NETDEVPermissionInfo*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                        /* 保留字节 */
    }

    /**
    * @struct tagNETDEVTimeTemplateBaseInfo
    * @brief 时间模板 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_TIME_TEMPLATE_BASE_INFO_S
    {
        public UInt32                   udwTemplateID;                  /* 模板ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                   szTemplateName;                 /* 模板名称  */
        public UInt32                   udwLastChange;                  /* 最后的修改时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                   byRes;                          /* 保留字段  */
    }

    /**
    * @brief 时间段配置 结构体定义 Time Sections Structure definition
    * @attention 无 None
    */
    public struct NETDEV_TIME_SECTION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[]                   szBeginTime;                 /* 开始时间  Begin time  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[]                   szEndTime;                   /* 结束时间  End time  */
        public UInt32                   udwArmingType;               /* 布防类型0: 定时 1: 动检 2: 报警 3: 动检和报警 4: 动检或报警5: 无计划10: 事件  Distribution Type 0: Timing 1: Motive Inspection 2: Alarm 3: Motive Inspection and Alarm 4: Motive Inspection or Alarm 5: Unplanned 10: Event*/
    }

    /**
    * @brief 计划（天）配置 结构体定义 Play (Day) Structure definition
    * @attention 无 None
    */
    public struct NETDEV_DAY_PLAN_INFO_S
    {
        public UInt32                        udwID;                                           /*星期索引1：周一;2：周二；3：周三；4：周四；5：周五；6：周六；7：周日；8：假日；  Weekly Index 1: Monday; 2: Tuesday; 3: Wednesday; 4: Thursday; 5: Friday; 6: Saturday; 7: Sunday; 8: Holidays;*/
        public UInt32                        udwNum;                                          /*每天时间段个数 NVR最大为8段；IPC最大为4段  The maximum number of NVRs per day is 8; IPC maximum 4 paragraphs*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_TIME_SECTION_NUM)]
        public NETDEV_TIME_SECTION_INFO_S[]  astTimeSection;                                  /* 时间段配置  Time Sections */
    }

    /**
    * @brief 计划（周）配置 结构体定义 Play (Week) Structure definition
    * @attention 无 None
    */
    public struct NETDEV_WEEK_PLAN_INFO_S
    {
        public Int32                        bEnabled;                       /*使能,仅IPC支持  Enabling,IPC only*/
        public UInt32                       udwNum;                         /* 计划天数，NVR最大为8(一周七天和假日)IPC最大为7(一周七天)  Planned days, NVR up to 8(7 days a week and holidays) IPC up to 7(7 days a week)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_DAY_NUM)]
        public NETDEV_DAY_PLAN_INFO_S[]     astDayPlanInfo;                 /* 一周内每天的布防计划列表  List of deployment plans for each day of the week*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[]                   byRes;                              /* 保留字段  */
    }

    /**
    * @struct tagNETDEVExceptionDayInfo
    * @brief 每天的布防计划具体信息
    * @attention 无 None
    */
    public struct NETDEV_EXCEPTION_DAY_INFO_S
    {
        public UInt32                       udwID;                                      /* 例外日期索引 */
        public Int32                        bEnabled;                                   /* 例外日期是否使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[]                       szDate;                                     /* 例外日期 year-month-day  */
        public UInt32 udwNum;                                                           /* 例外时间段个数 NVR最大为8段 IPC/PTS最大为4段*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_TIME_SECTION_INFO_S[] astTimeSectionInfo;                         /* 布防配置具体信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                       byRes;                                      /* 保留字段  */
    }

    /**
    * @struct tagNETDEVExceptionInfo
    * @brief 布控任务例外计划
    * @attention 无 None
    */
    public struct NETDEV_EXCEPTION_INFO_S
    {  
        public Int32                         bEnabled;                      /* 例外日期是否使能 0:不使能 1：使能 */
        public UInt32                        udwNum;                        /* 例外日期个数 [0, 16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public NETDEV_EXCEPTION_DAY_INFO_S[] astExceptionDayInfo;           /* 每天的布防计划具体信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                        byRes;                         /* 保留字段  */
    }

    /**
    * @struct tagNETDEVSystemTimeTemplate
    @brief 时间模板配置(PTS VMS)
    * @attention 无 None
    */
    public struct NETDEV_SYSTEM_TIME_TEMPLATE_S
    {
        public UInt32                  udwTemplateID;                           /* 时间模板ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                  szTemplateName;                          /*  时间模板名称 [1, 63]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[]                  szTemplateDesc;                         /* 时间模板描述 [1, 128]  */
        public UInt32                  udwLastChange;                           /* 时间模板最后修改时间 */
        public NETDEV_WEEK_PLAN_INFO_S stWeekPlanInfo;                          /* 布控任务布防计划 */
        public NETDEV_EXCEPTION_INFO_S stExceptionInfo;                         /* 布控任务例外计划 */
        public Int32                   bIsBuiltin;                              /* 是否为内置时间模板 仅VMS支持 1:是 0:否 */
        public UInt32                  udwTemplateType;                         /* 时间模板类型 仅VMS支持 0:录像时间模板 1:报警时间模板 2:用户时间模板 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                   byRes;                          /* 保留字段  */
    }

    /**
    * @struct tagNETDEVUserExtendInfo
    * @brief 用户扩展信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_USER_EXTEND_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]                   szCertificateCode;                          /* 证件号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]                   szEmail;                                    /* 邮箱号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]                   szTelephone;                                /* 电话号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_512)]
        public byte[]                   szDesc;                                     /* 描述 [1,128]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[]                   szName;                                     /* 证件号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 192)]
        public byte[]                   byRes;                                      /* 保留字段  */
    }

    /**
    * @struct tagNETDEVUserDetailInfo
    * @brief 用户详细信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_USER_DETAIL_INFO_V30_S
    {
        public UInt32                          udwUserID;                              /* 用户ID Get必选 仅VMS支持 */
        public UInt32                          udwLevel;                               /* 用户等级 Post Put必选 仅NVR支持 见 #NETDEV_USER_LEVEL_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szUserName;                             /* 用户名称[1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szPassword;                             /* 用户密码 Post Put必选[0,256]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szOldPassword;                          /* 用户旧密码 仅NVR支持修改密码 Put必选[0,256]  */
        public NETDEV_TIME_TEMPLATE_S          stTimeTemplateInfo;                     /* 时间模板信息 Get返回ID、名称 Post Put必选ID 描述不返回 仅VMS支持 */
        public NETDEV_TIME_S                   stValidBeginTime;                       /* 用户有效期开始时间 精确到日 Get Post Put必选 仅VMS支持 */
        public NETDEV_TIME_S                   stValidEndTime;                         /* 用户有效期结束时间 精确到日 Get Post Put必选 仅VMS支持 */
        public NETDEV_USER_EXTEND_INFO_S       stUserExtendInfo;                       /* 用户扩展信息 Post Put必选 仅VMS支持  */
        public UInt32                          udwOrgID;                               /* 组织ID 仅IPM支持 不支持修改 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[]                          byRes;                             /* 保留字段  */
    }

    /**
    * @struct tagNETDEVRoleBaseInfo
    * @brief 角色信息 结构体定义 
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ROLE_BASE_INFO_S
    {
        public UInt32                          udwRoleID;                    /* 角色ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szRoleName;                   /* 角色名称  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                          byRes;                        /* 保留字段  */
    }

    /**
    * @struct tagNETDEVUserNameInfoList
    * @brief 用户名列表 结构体定义
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_USER_NAME_INFO_LIST_S
    {  
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[]                          szUserName;                   /* 用户名[1,64]   */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                          byRes;                        /* 保留字段  */
    }

    /**
    * @struct tagNETDEVIDList
    * @brief 通用ID列表 结构体定义 
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ID_LIST_S
    {
        public UInt32                          udwNum;                     /* 数量 */
        public IntPtr                          pudwIDs;                    /* ID列表 Malloc申请内存(UINT32 *) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                          byRes;                      /* 保留字段  */
    }

    /**
    * @enum tagNETDEVCtrlGateInfo
    * @brief 闸机信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_GATE_INFO_S
    {
        public UInt32 udwID;                /* 记录ID */
        public UInt32 udwTimestamp;         /* 采集时间 */
        public UInt32 udwCapSrc;            /* 采集来源 详见 NETDEV_CAP_SRC_E GateInfo选择4 */
        public UInt32 udwInPersonCnt;       /* 进入人员计数 */
        public UInt32 udwOutPersonCnt;      /* 离开人员计数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                /* 保留字节 */
    }

    /**
    * @struct tafNETDEVCtrlCardInfo
    * @brief 卡信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_CARD_INFO_S
    {
        public UInt32 udwID;                                       /* 记录ID */
        public UInt32 udwTimestamp;                                /* 采集时间 UTC格式，单位秒 */
        public UInt32 udwCapSrc;                                   /* 采集来源 详见 NETDEV_CAP_SRC_E CardInfo选择2或3*/
        public UInt32 udwCardType;                                 /* 0：身份证，1：门禁卡*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szCardID;                     /* 门禁卡字段：物理卡号 最长18位*/
        public UInt32 udwCardStatus;                               /* 门禁卡字段：卡状态 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szName;                      /* 身份证字段：姓名 范围[1,63] */
        public UInt32 udwGender;                                   /* 身份证字段：性别 详情参见枚举NETDEV_GENDER_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szBirthday;                   /* 身份证字段：出生日期 YYYYMMDD */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szResidentialAddress;        /* 身份证字段：住址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szIdentityNo;                 /* 身份证字段：身份证号码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szIssuingAuthority;          /* 身份证字段：发证机关 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szIssuingDate;                /* 身份证字段：发证日期 YYYYMMDD */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szValidDateStart;             /* 身份证字段：证件有效期开始时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szValidDateEnd;               /* 身份证字段：证件有效期结束时间 */
        public NETDEV_FILE_INFO_S stIDImage;                       /* 身份证照片 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;                                  /* 保留字节 */
    }

    /**
    * @struct tagNETDEVMatchPersonInfo
    * @brief 匹配人员信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MATCH_PERSON_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szPersonName;        /* 成员名字 范围[1,63] */
        public UInt32 udwGender;                           /* 成员性别 详情参见枚举NETDEV_GENDER_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szCardID;             /* 门禁卡号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szIdentityNo;         /* 身份证卡号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPersonCode;         /* 人员编码 可填写学号或工号 范围:[1, 15] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                           /* 保留字节 */
    }

    /**
    * @struct tagNETDEVCtrlLibMatchInfo
    * @brief 库比对信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_LIB_MATCH_INFO_S
    {
        public UInt32 udwID;                                   /* 记录ID */
        public UInt32 udwLibID;                                /* 库ID */
        public UInt32 udwLibType;                              /* 库类型 */
        public UInt32 udwMatchStatus;                          /* 匹配状态 详见NETDEV_MATCH_STATUS_E */
        public UInt32 udwMatchPersonID;                        /* 匹配人员ID */
        public UInt32 udwMatchFaceID;                          /* 匹配人脸ID */
        public NETDEV_MATCH_PERSON_INFO_S stMatchPersonInfo;   /* 匹配人员信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                              /* 保留字节 */
    }

    /**
    * @struct tagNETDEVCtrlTemperatureInfo
    * @brief 温度信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_TEMPERATURE_INFO
    {
        public UInt32       udwRelativeFaceID;          /* 关联人脸ID，若无关联人脸，填写0xffffffff */
        public float        fEnvTemperature;            /* 环境温度，单位：摄氏度  */
        public float        fTemperatureThreshold;      /* 温度阈值，单位：摄氏度 */
        public float        fBodyTemperature;           /* 测量体温温度，单位：摄氏度 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]       byRes;                      /* 保留字段 */
    }


    /**
    * @struct tagNETDEVPersonVerification
    * @brief 人员核验
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_VERIFICATION_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_128)]
        public byte[] szReference;                                      /* 用于客户端确认推送消息的url */
        public UInt32 udwSeq;                                                           /* 通知记录序号 */
        public UInt32 udwChannelID;                                                     /* 通道ID VMS支持*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szChannelName;                                    /* 通道名称，长度 [1,64]，VMS支持 */
        public UInt32 udwTimestamp;                                                     /* 通知上报时间 UTC格式，单位秒*/
        public UInt32 udwNotificationType;                                              /* 通知类型 0：实时通知1：历史通知 */
        public UInt32 udwFaceInfoNum;                                                   /* 人脸信息数目 范围：[0, 1] */
        public IntPtr pstCtrlFaceInfo;                               /* 人脸信息 需动态申请内存(NETDEV_CTRL_FACE_INFO_S[])*/
        public UInt32 udwCardInfoNum;                                                   /* 卡信息数目 范围：[0, 1] */
        public IntPtr pstCtrlCardInfo;                               /* 卡信息 需动态申请内存(NETDEV_CTRL_CARD_INFO_S[])*/
        public UInt32 udwGateInfoNum;                                                   /* 闸机信息数目 范围：[0, 1] */
        public IntPtr pstCtrlGateInfo;                               /* 闸机信息 需动态申请内存(NETDEV_CTRL_GATE_INFO_S[])*/
        public UInt32 udwLibMatInfoNum;                                                 /* 库比对信息数目 范围：[0, 16] */
        public IntPtr pstLibMatchInfo;                          /* 库比对信息 需动态申请内存(NETDEV_CTRL_LIB_MATCH_INFO_S[])*/
        public UInt32 udwTemperatureInfoNum;                    /* 温度信息数目 */
        public IntPtr pstTemperatureInfo;                       /* 温度信息列表，需动态申请内存，NETDEV_CTRL_TEMPERATURE_INFO */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] byRes;                                                       /* 保留字节 */
    }

    /**
     * @struct tagNETDEVACSStaffInfo
     * @brief 员工信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_STAFF_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szNumber;                               /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_BIRTHDAY_LEN)]
        public byte[] szBirthday;           /* 出生日期 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szDeptName;                            /* 部门名称*/
        public UInt32 udwDeptID;                                             /* 部门ID */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                            /* 保留字段 */
    }

    /**
     * @struct tagACSTimeSection
     * @brief 时间信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_TIME_SECTION_S
    {
        public Int64 tStartTime;                                      /* 起始时间 UTC时间 单位秒s */
        public Int64 tEndTime;                                        /* 结束时间 UTC时间 单位秒s */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                                       /* 保留字段 */
    }

    /**
    * @struct tagNETDEVACSVisitorInfo
    * @brief 访客信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISITOR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;       /* 访客公司 [1,64]字符 */
        public UInt32 udwVisitorCount;                        /* 访客人数 */
        public UInt32 udwIntervieweeID;                       /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;      /* 被访者姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;      /* 被访者部门 [1,64]字符 */
        public NETDEV_ACS_TIME_SECTION_S tScheduleTime;     /* 预约访问时间 */
        public NETDEV_ACS_TIME_SECTION_S tRealTime;         /* 实际到访时间 */
        public UInt32 udwStatus;                              /* 状态 参见枚举NETDEV_ACS_VISIT_STATUS_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                             /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSPersonBaseInfo
     * @brief 门禁人员基本信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BASE_INFO_S
    {
        public UInt32 udwPersonID;                    /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;         /* 姓名 */
        public UInt32 udwGender;                      /* 性别 参见枚举 NETDEV_GENDER_TYPE_E*/
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                 /* 证件信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szTelephone;     /* 联系电话 */
        public UInt32 udwCardID;                      /* 卡片编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szCardNo;        /* 卡片号码*/
        public UInt32 udwType;                        /* 人员类型  0员工  1访客*/
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;                    /* 员工信息 */
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;                      /* 访客信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                     /* 保留字段 */
    }

    /**
     * @struct tagACSPersonCard
     * @brief 人员所持门禁卡信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_CARD_INFO_S
    {
        public UInt32 udwCardID;                      /* 绑定ID */
        public UInt32 udwCardType;                    /* 卡片类型 */
        public UInt32 udwCardStatus;                  /* 卡片状态  0:空白 1:激活 2:冻结 3:注销  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szCardNo;        /* 卡号 */
        public UInt32 udwReqSeq;                      /* 序号 */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                    /* 有效时间 */


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                     /* 保留字段 */
    }

    /**
 * @struct tagNETDEVACSFaceImage
 * @brief 图片信息
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_FACE_IMAGE_S
    {
        public UInt32 udwNum;                            /* 照片数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_FILE_INFO_S[] stImageList;        /* 人脸照片列表 */
        public UInt32 udwMajorImageIndex;                /* 主照片索引 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                        /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSPersonInfo
     * @brief 门禁人员信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_INFO_S
    {
        public UInt32 udwReqSeq;                          /* 请求序号 */
        public UInt32 udwPersonID;                        /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;             /* 姓名 */
        public UInt32 udwGender;                          /* 性别 参见枚举 NETDEV_GENDER_TYPE_E*/
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                     /* 证件信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szTelephone;         /* 联系电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szAddress;          /* 地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_480)]
        public byte[] szDesc;             /* 备注 */

        public UInt32 udwCardNum;                         /* 门禁卡个数，取值范围[1,6] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_6)]
        public NETDEV_ACS_PERSON_CARD_INFO_S[] stACSPersonCardList;    /* 门禁卡信息 */
        public NETDEV_ACS_FACE_IMAGE_S stFaceImage;                        /* 人脸图片 */
        public UInt32 udwType;                            /* 人员类型  参见NETDEV_ACS_PERSON_TYPE_E*/
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;                        /* 员工信息 */
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;                          /* 访客信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSPersonList
     * @brief 人员列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_LIST_S
    {
        public UInt32 udwNum;                 /* 人员数量 */
        public IntPtr pstPersonInfoList;      /* 员工信息列表 根据udwNum动态申请(NETDEV_ACS_PERSON_INFO_S[])*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段 */
    }

    /**
    * @brief 批量开窗场景窗口返回信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_WND_S
    {
        public UInt32 udwReqSeq;      /* 请求数据序号 */
        public UInt32 udwResuleCode;  /* 返回错误码 */
        public UInt32 udwWinID;       /* 窗口ID */
    }

    /**
    * @brief 批量开窗场景窗口返回信息列表
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_XW_BATCH_RESULT_LIST_S
    {
        public UInt32 udwSize;            /* 窗口数量 */
        public UInt32 udwLastChange;      /* 摘要字 */
        public IntPtr pstResultInfo;      /* 窗口信息,根据窗口数量动态申请内存(NETDEV_XW_BATCH_RESULT_WND_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;          /* 保留字段 */
    }

    /**
     * @struct tagNETDEVFaceBatchInfo
     * @brief 人脸识别模块批量操作信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_INFO_S
    {
        public UInt32 udwReqSeq;         /* 请求数据序号 */
        public UInt32 udwResultCode;     /* 返回错误码 */
        public UInt32 udwID;             /* 编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段  Reserved */
    }

    /**
     * @struct tagNETDEVFaceBatchList
     * @brief 人脸识别模块批量操作列表 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_LIST_S
    {
        public UInt32 udwNum;         /* 批量操作数量 */
        public IntPtr pstBatchList;   /* 批量操作信息 根据udwNum进行动态申请(NETDEV_FACE_BATCH_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

    /**
     * @struct tagstNETDEVTimeTemplate
     * @brief 时间模板信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;        /* 模板名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;    /* 模板描述 */
        public Int32 dwTamplateID;                               /* 模板ID */
    }

    /**
     * @struct tagstNETDEVTimeTemplateList
     * @brief 时间模板列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_LIST_S
    {
        public Int32 dwSize;                                                         /* 模板大小 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TIME_TEMPLATE_NUM)]
        public NETDEV_TIME_TEMPLATE_S[] astTimeTemplate;       /* 时间模板信息 */
    }

    /**
     * @struct tagstNETDEVTimeDuration
     * @brief 每天的时间段信息
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_S
    {
        public Int64 tBeginTime;                              /* 起始时间 */
        public Int64 tEndTime;                                /* 结束时间 */
        public Int32 dwPlanType;                              /* 参见 NETDEV_TIME_TEMPLATE_PLAN_TYPE_E */
    }

    /**
     * @struct tagstNETDEVTimeDurationList
     * @brief 每天的时间段信息列表，一天最多24个时间段
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_LIST_S
    {
        public Int32 dwSize;                                                      /* 时间段个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TIME_DURATION_NUM)]
        public NETDEV_TIME_DURATION_S[] astTimeDurationList;               /* 时间段信息列表 */
    }

    /**
     * @struct tagstNETDEVTimeRange
     * @brief 时间范围信息，一个时间模板最多可包含8个时间范围，周一到周日和假日
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_RANGE_S
    {
        public Int32 dwSize;                                         /* 时间范围个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TIME_RANGE_NUM)]
        public NETDEV_TIME_DURATION_LIST_S[] astTimeRangeList;        /* 时间范围列表 */
    }

    /**
     * @struct tagstNETDEVTimeTemplateInfo
     * @brief 时间模板详细信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_INFO_V30_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;                            /* 模板名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;                        /* 模板描述 */
        public Int32 dwTemplateType;                                                 /* 时间模板类型 参见NETDEV_TIME_TEMPLATE_TYPE_E */
        public NETDEV_TIME_RANGE_S stTimeRange;                                     /* 共8个时间范围 */
    }

    /**
     * @struct tagNETDEVACSPermissionInfo
     * @brief 授权信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionID;                   /* 权限ID     */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPermissionName;  /* 权限名称 */
        public UInt32 udwPermissionType;                 /* 权限类型：0表示员工权限组，1表示访客权限组 */
        public NETDEV_OPERATE_LIST_S stPersonList;                      /* 人员ID列表，其中dwSize为人员个数*/
        public UInt32 udwTemplateID;                     /* 时间模板ID */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                       /* 有效时间 */
        public NETDEV_OPERATE_LIST_S stDoorList;                        /* 门通道列表, 其中dwSize为门通道个数*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段 */
    }

//     /**
//      * @struct tagstNETDEVOperateInfo
//      * @brief 单个操作信息
//      * @attention dwID为入参，dwReturnCode为出参
//      */
//     [StructLayout(LayoutKind.Sequential)]
//     public struct NETDEV_OPERATE_INFO_S
//     {
//         public Int32 dwID;                   /* ID */
//         public Int32 dwReturnCode;           /* 返回码*/
//         [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
//         public byte[] byRes;              /* 保留字段  Reserved field */
//     }

    /**
    * @struct tagNETDEVACSPermStatus
    * @brief 权限组门禁通道人员授权状态
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERM_STATUS_S
    {
        public UInt32 udwPersonID;                                    /* 人员ID,查询条件为通道时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szPersonName;                   /* 人员姓名,查询条件为通道时必选 字符串长度范围[1, 63] */
        public UInt32 udwDepartmentID;                                /* 部门ID,查询条件为通道时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szDepartmentName;               /* 部门名称,查询条件为通道时必选 字符串长度范围[1, 63] */
        public UInt32 udwDoorID;                                      /* 门禁通道ID,查询条件为人员时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szDoorName;                     /* 门禁通道名称,查询条件为人员时必选 字符串长度范围[1, 63] */
        public UInt32 udwDeviceID;                                    /* 门禁通道所属设备ID,查询条件为人员时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szDeviceName;                   /* 门禁通道所属设备名称,查询条件为人员时必选 字符串长度范围[1, 63] */
        public UInt32 udwStatus;                                      /* 人员下发到速通门状态 详见 NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                     /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSPermissionGroupInfo
     * @brief 权限组信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERMISSION_GROUP_INFO_S
    {
        public UInt32 udwPermissionGroupID;                  /* 权限组ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPermissionGroupName;  /* 权限组名称 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                             /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSDoorPermissionInfo
     * @brief 门授权信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_DOOR_PERMISSION_INFO_S
    {
        public UInt32 udwPermissionNum;                  /* 权限组个数 */
        public NETDEV_ACS_TIME_SECTION_S stValidTime;                       /* 有效时间 */
        public IntPtr pstPermissionGroupList;            /* 权限组信息列表.Num数为0时可选(NETDEV_ACS_PERMISSION_GROUP_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

    /**
     * @struct tagACSVisitLogInfo
     * @brief 访客记录信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISIT_LOG_INFO_S
    {
        public UInt32 udwLogID;                                /* 日子ID */
        public UInt32 udwVisitorID;                            /* 访客ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szVisitorName;           /* 访客姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;        /* 访客公司 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szVisitorPhone;           /* 访客电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szCardNo;                 /* 访客卡号 */
        public UInt32 udwIntervieweeID;                        /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;       /* 被访者姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;       /* 被访者部门 [1,64]字符 */
        public Int64 tScheduleStartTime;                      /* 预约来访时间 UTC时间 单位秒s */
        public Int64 tRealStartTime;                          /* 实际来访时间 UTC时间 单位秒s */
        public UInt32 udwStatus;                               /* 状态 参见枚举NETDEV_ACS_VISIT_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* 保留字段 */
    }

    /**
    * @struct tagNETDEVPagedQueryInfo
    * @brief 查询条件
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PAGED_QUERY_INFO_S
    {
        public UInt32 udwLimit;        /* 每次查询的数量 */
        public UInt32 udwOffset;       /* 从当前序号开始查询 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;      /* 保留字节 */
    }

    /**
     * @struct tagNETDEVACSPersonBlacklistInfo
     * @brief 黑名单信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BLACKLIST_INFO_S
    {
        public UInt32 udwBlackListID;                    /* 黑名单ID */
        public NETDEV_FACE_MEMBER_ID_INFO_S stIdentificationInfo;               /* 身份信息 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                        /* 保留字段 */
    }

    /**
     * @struct tagNETDEVCompareInfo
     * @brief 人脸对比信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_COMPARE_INFO_S
    {
        public NETDEV_FILE_INFO_S stPersonImage;                    /* 人员图片 */
        public  NETDEV_FILE_INFO_S stSnapshotImage;                  /* 抓拍图片 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                       /* 保留字段 */
    }

    /**
     * @struct tagNETDEVACSAttendanceLogInfo
     * @brief 出入记录信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_ATTENDANCE_LOG_INFO_S
    {
        public UInt32 udwAlarmType;                    /* 告警类型 */
        public Int64 tTimeStamp;                      /* 告警时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szDoorName;      /* 门名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szDoorNo;         /* 门编号 */
        public UInt32 udwDoorDirect;                   /* 进出方向 0:进,1:出 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szCardNo;         /* 刷卡卡号*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPersonName;    /* 刷卡人姓名 */
        public UInt32 udwPersonType;                   /* 人员类型  参见NETDEV_ACS_PERSON_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPersonPhone;    /* 刷卡人电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPersonDept;    /* 刷卡人部门 */
        public NETDEV_COMPARE_INFO_S stCompareInfo;    /* 脸对比信息，速通门会携带此信息 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CONFLAGRATION_ALARM_INFO_V30_S
    {
        public NETDEV_ALARM_PIC_BASE_INFO_S stConflagrationBaseInfo;        /* 火点基础信息 */
        public NETDEV_GEOLACATION_INFO_S stPTPositionInfo;                 /* 定位信息 */
        public UInt32 udwNum;                                            /* 火点数量 */
        public IntPtr pstChannelInfo;                                    /* 火点告警通道信息 需动态分配内存， 详见 NETDEV_CONFLAGRATION_CHANNEL_INFO_S */
        public float fZoom;                                             /* 变倍倍数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                                            /* 保留字段 */
    };

    /**
    * @struct tagNETDEVAlarmPicBaseInfo
    * @brief 图片告警基础信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_PIC_BASE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szReference;                      /* 订阅者描述信息 以URL格式体现 */
        public UInt32 udwAlarmType;                    /* 告警类型 */
        public Int64 tTimeStamp;                      /* 告警时间 */
        public UInt32 udwSeq;                                        /* 告警序号 */
        public UInt32 udwSourceID;                                      /* 告警源ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_256)]
        public byte[] szSourceName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szDeviceID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public byte[] szRelatedID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szDeviceCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
        public byte[] byRes;                                                 /* 保留字段 */
    };

    /**
     * @struct tagNETDEVAlarmPicData
     * @brief 告警图片数据
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_PIC_DATA_S
    {
        public NETDEV_ALARM_PIC_BASE_INFO_S stAlarmPicBaseInfo;         /* 图片告警基础信息 */
        public UInt32 udwImageNum;                /* 图像个数 */
        public IntPtr pstImageInfo;               /* 图像相关信息 需动态申请内存， 详见 NETDEV_STRUCT_IMAGE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                                            /* 保留字段 */
    };

    /**
    * @enum NETDEV_THERMAL_PARAM_INFO_S
    * @brief 热成像参数信息
    * @attention 无
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_THERMAL_PARAM_INFO_S
    {
        public Int32 bThermalDetect;             /* 火点检测使能 0 关闭 1 使能 */
        public Int32 bTempDetect;                /* 测温检测使能 0 关闭 1 使能 */
        public Int32 bExtremeTrace;              /* 冷热点追踪使能 0 关闭 1 使能 */
        public Int32 bShowTempeInfo;             /* 检测信息显示使能 0 关闭 1 使能 */
        public UInt32 udwTempInfoPlace;           /* 测温检测信息位置 0:规则周边 1:窗口左边 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                       /* 保留字段 */
    };

    /**
    * @struct NETDEV_SMOKE_DETC_S
    * @brief 吸烟检测信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMOKE_DETC_S
    {
        public NETDEV_ALARM_PIC_BASE_INFO_S stAlarmBaseInfo;                   /* 告警基础信息 */
        public UInt32 udwChannelNum;                     /* 通道数量 */
        public IntPtr pstSmokeDetcChannel;               /* 吸烟通道信息 需动态申请内存， 详见 NETDEV_SMOKE_DETC_CHANNEL_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                          /* 保留字段 */
    };

    /**
    * @struct NETDEV_TEMPERATURE_ALARM_INFO_S
    * @brief 温度告警信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TEMPERATURE_ALARM_INFO_S
    {
        public NETDEV_ALARM_PIC_BASE_INFO_S stAlarmBaseInfo;                      /* 告警基础信息 */
        public UInt32 udwRuleType;                                                /* 规则类型，用于检测规则内的温度告警  1 : 温度告警全屏规则 2 : 温度告警单规则（即点、线、多边形规则）3 : 温度告警规则,包含单规则与对比规则 0xFF:无效值*/
        public UInt32 udwRuleId;                                                  /* 规则ID, RuleType为2、3时必选 */
        public UInt32 udwReferenceRuleId;                                         /* 对比规则ID，RuleType为3时必选 */
        public UInt32 udwAlarmCondition;                                          /* 温度告警触发条件 1：低于 2：高于 3：匹配 */
        public UInt32 udwValueType;                                               /* 告警值类型 详见 NETDEV_TEMPERATURE_TYPE_E */
        public float fAlarmValue;                                                /* 当前报警类型产生的告警值 ValueType为5时表示温度变化率，其他表示温度值，精度小数点后两位 */
        public float fThreshold;                                                 /* ValueType为5时表示温度变化率阈值，其他表示温度阈值，精度小数点后两位 */
        public UInt32 udwChannelNum;                                              /* 通道个数 */
        public IntPtr pstTemperatureChannelInfo;                                  /* 温度告警通道信息 需动态申请内存，详见 NETDEV_TEMPERATURE_CHANNEL_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                      /* 保留字段 */
    };

    
    /**
    * @struct NETDEV_FACE_DETEC_CAP_S
    * @brief 人脸检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_FACE_DETEC_CAP_S 
    {
        public Int32 bIsSupport;                                                    /* 是否支持Smart人脸检测 */
        public Int32 bQualityAnalysisIsSupport;                                     /* 是否具有人脸质量优先（上报图片）能力 */
        public Int32 dwFaceQualityAnalysisType;                                     /* 人脸质量优先类型, 参考枚举 NETDEV_FACE_ANALYSIS_SKILL_E */
        public Int32 bAttributeAnalysisIsSupport;                                   /* 设备具备是否具有人脸属性分析（上报）能力 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] adwAttributeAnalysisSkills;                                  /* 设备的人脸分析能力，参考枚举 当为“0”时，该对象可以不存在 */
        public Int32 bFeatureIsSupport;                                             /* 设备是否具有人脸二进制特征提取（上报）能力 */
        public Int32 bRecognitionIsSupport;                                         /* 设备是否具有人脸识别能力 */
        public Int32 dwFaceRecognitionType;                                         /*人脸识别类型, 参考枚举NETDEV_FACE_RECOGNITION_TYPE_E */
        public Int32 bPersonSnapshotSupport;                                        /* 设备具备是否具有人体抓拍（上报）能力 0: 不支持该能力 1: 支持该能力 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                    /* 保留字节 */
    };

    /**
    * @struct NETDEV_INTRUSION_DETEC_CAP_S
    * @brief 区域入侵能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_INTRUSION_DETEC_CAP_S 
    {
        public Int32  bIsSupport;                        /* 是否支持区域入侵 */
        public Int32  dwPecentMin;                      /* 区域入侵中，图形占比(Percentages)最小值, 不支持区域入侵时，该字段可选 */
        public Int32  dwPecentMax;                      /* 区域入侵中，图形占比(Percentages)最大值, 不支持区域入侵时，该字段可选 */
        public Int32  dwTimeThresholdMin;               /* 区域入侵中，时间阈值(TimeThreshold)最小值, 不支持区域入侵时，该字段可选 */
        public Int32  dwTimeThresholdMax;               /* 区域入侵中，时间阈值(TimeThreshold)最大值, 不支持区域入侵时，该字段可选 */
        public UInt32 udwSmartMode;                     /* 智能模式 0：泛智能 1：深度智能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] byRes;                                                    /* 保留字节 */
    };

    /**
    * @struct NETDEV_CROSS_LINE_DETEC_CAP_S
    * @brief 越界检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_CROSS_LINE_DETEC_CAP_S
    {
        public Int32   bIsSupport;                /* 是否支持越界检测 */
        public UInt32 udwSmartMode;              /* 智能模式 0：泛智能 1：深度智能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[]   byRes;                  /* 保留字段 */
    };

    /**
    * @struct NETDEV_PASSENGER_FLOW_CAP_S
    * @brief 客流量检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_PASSENGER_FLOW_CAP_S
    {
        public Int32 bIsSupport;                /* 是否支持客流量检测 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                  /* 保留字段 */
    };

    /**
    * @struct NETDEV_AUDIO_DETEC_CAP_S
    * @brief 音频检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_AUDIO_DETEC_CAP_S
    {
        public Int32   bIsSupport;  /* 是否支持音频检测 */
        public Int32 dwDiffMin;    /* 音频检测中，差值/阈值的最小值, 不支持音频检测时，该字段可选 */
        public Int32 dwDiffMax;    /* 音频检测中，差值/阈值的最大值, 不支持音频检测时，该字段可选  */
    };

    /**
    * @struct NETDEV_OBJ_TRACK_CAP_S
    * @brief 智能跟踪能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_OBJ_TRACK_CAP_S
    {
        public Int32  bIsSupport;                               /* 是否支持智能跟踪 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] adwMode;       /* 跟踪模式,参考枚举 NETDEV_OBJ_TRACK_MODE_E ，支持智能跟踪时可选 */
        public Int32 dwTrackTimeMin;                           /* 最小跟踪时间（单位：s），跟踪模式包含 NETDEV_OBJ_TRACK_MODE_FULLVIEW 时可选 */
        public Int32 dwTrackTimeMax;                           /* 最大跟踪时间（单位：s），跟踪模式包含 NETDEV_OBJ_TRACK_MODE_FULLVIEW 时可选 */
    };

    /**
    * @struct NETDEV_MIX_DETECTION_INFO_S
    * @brief 混行检测能力
    * @attention 无 None
    */
    public struct NETDEV_MIX_DETECTION_INFO_S
    {
        public Int32 bIsSupported;                               /* 是否支持混行检测 0: 不支持 1: 支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] bRes;                                  /* 保留字段 */
    };

    /**
    * @struct NETDEV_MASTER_SLAVE_LINK_CAP_S
    * @brief 支持主从联动模式
    * @attention 无 None
    */
    public struct NETDEV_MASTER_SLAVE_LINK_CAP_S
    {
        public UInt32 udwSupportMode;                          /* 支持主从联动模式 详见 NETDEV_MASTER_SLAVE_LINKAGE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]   bRes;                                /* 保留字段 */
    };

    /**
    * @struct NETDEV_OBJ_ATTR_OVERLAY_CAP_S
    * @brief 属性信息叠加能力
    * @attention 无 None
    */
    public struct NETDEV_OBJ_ATTR_OVERLAY_CAP_S
    {
        public Int32 bSupportAttrOverlay;                       /* 是否支持属性信息叠加：FALSE:不支持，TRUE:支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] bRes;                                  /* 保留字段 */
    };


    /**
    * @struct NETDEV_ACCESS_ZONE_CAP_S
    * @brief 进入区域检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_ACCESS_ZONE_CAP_S
    {
        public Int32    bIsSupport;             /* 是否支持进入区域 0：不支持 1：支持 */
        public UInt32  udwSmartMode;           /* 智能模式 0：泛智能 1：深度智能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]    bRes;               /* 保留字段 */
    };

    /**
    * @struct NETDEV_LEAVE_ZONE_CAP_S
    * @brief 离开区域检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_LEAVE_ZONE_CAP_S
    {
        public Int32    bIsSupport;             /* 是否支持进入区域 0：不支持 1：支持 */
        public UInt32  udwSmartMode;           /* 智能模式 0：泛智能 1：深度智能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte    bRes;              /* 保留字段 */
    };

    /**
    * @struct NETDEV_AREA_PEOPLE_COUNT_CAP_S
    * @brief 区域人数统计能力
    * @attention 无 None
    */
    public struct NETDEV_AREA_PEOPLE_COUNT_CAP_S
    {
        public Int32   bSupportAreaPeopleCount;                 /* 是否支持区域人数统计：FALSE:不支持，TRUE:支持 */
        public UInt32 udwMaxAreaNum;                           /* 设备支持配置区域规则的最大数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]   bRes;                                /* 保留字段 */
    };

    /**
    * @struct NETDEV_LINE_PEOPLE_COUNT_CAP_S
    * @brief 绊线人数统计能力
    * @attention 无 None
    */
    public struct NETDEV_LINE_PEOPLE_COUNT_CAP_S
    {
        public Int32   bSupportLinePeopleCount;                 /* 是否支持绊线人数统计：FALSE:不支持，TRUE:支持 */
        public UInt32 udwMaxLineNum;                           /* 设备支持配置绊线规则的最大数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]   bRes;                                /* 保留字段 */
    };

    /**
    * @struct tagNETDEVCrowdDensityCap
    * @brief 人员密度检测能力
    * @attention 无 None
    */
    public struct NETDEV_CROWD_DENSITY_CAP_S
    {
        public Int32   bSupportCrowdDensity;            /* 是否支持人员密度检测：FALSE:不支持 TRUE:支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]   bRes;                        /* 保留字段 */
    };

    /**
    * @struct NETDEV_ACCESS_ELEVATOR_CAP_S
    * @brief 电瓶车入梯检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_ACCESS_ELEVATOR_CAP_S
    {
        public Int32    bIsSupport;             /* 是否支持电瓶车入梯检测 0：不支持 1：支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]    bRes;               /* 保留字段 */
    };

    /**
    * @struct tagNETDEVLinkagePlanCfg
    * @brief 联动项布防计划配置
    * @attention 无 None
    */
    public struct NETDEV_LINKAGE_PLAN_CFG_S
    {
        public Int32    bSupportAudioLinkagePlan;          /* 是否支持声音联动布防配置：FALSE:不支持 TRUE:支持 */
        public Int32    bSupportLightLinkagePlan;          /* 是否支持灯光联动布防配置：FALSE:不支持 TRUE:支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]    bRes;                          /* 保留字段 */
    };

    /**
    * @struct NETDEV_SMART_MOTION_DECTION_CAP_S
    * @brief 智能运动检测能力
    * @attention 无 None
    */
    public struct NETDEV_SMART_MOTION_DECTION_CAP_S
    {
        public Int32                        bSupportSmartMotion;                         /* 是否支持配置前端智能运动检测：FALSE:不支持 TRUE:支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public UInt32[]                      pudwSupportDetecObjectList;               /* 支持检测对象列表 参见枚举 NETDEV_SMART_MOTION_DETECTION_TYPE_E */
        NETDEV_LINKAGE_PLAN_CFG_S   stLinkagePlanCfg;                            /* 联动项布防计划*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]    bRes;                                                        /* 保留字段 */
    };

    /**
    * @struct NETDEV_FALL_OBJ_DETEC_CAP_S
    * @brief 高空抛物检测能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_FALL_OBJ_DETEC_CAP_S
    {
        public Int32  bIsSupport;              /* 是否支持高空抛物检测 FALSE：不支持， TRUE：支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte  bRes;                /* 保留字段 */
    };

    /**
    * @struct NETDEV_SMART_CAP_S
    * @brief smart智能能力 结构体定义
    * @attention 无 None
    */
    public struct NETDEV_SMART_CAP_S
    {
        NETDEV_FACE_DETEC_CAP_S            stFaceDetecCap;                 /* 人脸检测能力 */
        NETDEV_INTRUSION_DETEC_CAP_S       stIntrusionDetecCap;            /* 区域入侵能力 */
        NETDEV_CROSS_LINE_DETEC_CAP_S      stCrossLineDetecCap;            /* 越界检测能力 */
        NETDEV_PASSENGER_FLOW_CAP_S        stPassengerFlowCap;             /* 客流量检测能力 */
        NETDEV_AUDIO_DETEC_CAP_S           stAudioDetecCap;                /* 音频检测能力 */
        NETDEV_OBJ_TRACK_CAP_S             stObjTrackCap;                  /* 智能跟踪能力 */
        NETDEV_MIX_DETECTION_INFO_S        stMixDetectionCap;              /* 混行检测能力 */
        NETDEV_MASTER_SLAVE_LINK_CAP_S     stMasterSlaveCap;               /* 主从联动能力 */
        NETDEV_OBJ_ATTR_OVERLAY_CAP_S      stObjAttrOverlayCap;            /* 属性信息叠加能力 */
        NETDEV_ACCESS_ZONE_CAP_S           stAccessZoneCap;                /* 进入区域检测能力 */
        NETDEV_LEAVE_ZONE_CAP_S            stLeaveZoneCap;                 /* 离开区域检测能力 */
        NETDEV_LINE_PEOPLE_COUNT_CAP_S     stLinePeopleCountCap;           /* 绊线人数统计能力 */
        NETDEV_AREA_PEOPLE_COUNT_CAP_S     stAreaPeopleCountCap;           /* 区域人数统计能力 */
        NETDEV_CROWD_DENSITY_CAP_S         stCrowdDensityCap;              /* 人员密度检测能力 */
        NETDEV_ACCESS_ELEVATOR_CAP_S       stAccessElevatorCap;            /* 电瓶车入梯检测能力 */
        NETDEV_SMART_MOTION_DECTION_CAP_S  stSmartMotionDetectionCap;      /* 智能运动检测能力 */
        NETDEV_FALL_OBJ_DETEC_CAP_S        stFallObjDetecCap;              /* 高空抛物检测能力 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 184)]
        public byte[]  bRes;                /* 保留字段 */
    };

       public class NETDEVSDK
    {

        public const int NETDEV_TMS_FACE_ID_LEN = 16;       /* 人脸ID缓存长度 */
        public const int NETDEV_TMS_FACE_POSITION_LEN = 32;       /* 人脸位置字符串缓存长度 */
        public const int NETDEV_TMS_FACE_RECORD_ID_LEN = 32;       /* 记录ID缓存长度 */
        public const int NETDEV_TMS_CAMER_ID_LEN = 32;      /* 相机ID缓存长度 */
        public const int NETDEV_TMS_PASSTIME_LEN = 32;       /* 通过时间字符串缓存长度 */
        public const int NETDEV_TMS_FACE_TOLLGATE_ID_LEN = 32;       /* 卡口编号缓存长度 */

        /**********************************  Commonly used numerical macros *************** */

        public const int NETDEV_FACE_MEMBER_CUSTOM_LEN = 255;             /* 自定义属性值长度 */
        public const int NETDEV_LOG_QUERY_COND_NUM = 48;              /* 日志查询条件数量 */
        public const int NETDEV_FACE_MEMBER_REGION_LEN = 256;             /* 人脸库成员所在地区名称最大值 */
        public const int NETDEV_FACE_IDNUMBER_LEN = 128;             /*证件号最大范围*/
        public const int NETDEV_FACE_MEMBER_NAME_LEN = 256;            /* 人脸库成员名称长度最大值 */
        public const int NETDEV_FACE_MEMBER_BIRTHDAY_LEN = 31;              /* 成员出生日期字符串最大长度 */
        public const int NETDEV_FACE_MEMBER_CUSTOM_NUM = 5;               /* 自定义属性列表个数 */
        public const int NETDEV_MAX_LINK_ACTION_NUM = 9;               /* 最大联动动作数量 */
        public const int NETDEV_FACE_MONITOR_RULE_NAME_LEN = 508;             /*人脸布控任务的布控名称最大值 */
        public const int NETDEV_FACE_MONITOR_RULE_REASON_LEN = 508;             /*人脸布控的布控原因最大值 */
        public const int NETDEV_FACE_FEATURE_SIZE = 512;                 /* 人脸特征信息 512B */
        public const int NETDEV_TIME_TEMPLATE_NUM = 32;              /* 时间模板数量 */
        public const int NETDEV_TIME_RANGE_NUM = 8;               /* 时间模板时间范围个数(周一到周日再加假日) */
        public const int NETDEV_TIME_DURATION_NUM = 8;               /* 时间模板中一天最多8个片段 */

        /* Length of stream ID*/
        public const int NETDEV_STREAM_ID_LEN = 32;

        /* Length of filename */
        public const uint NETDEV_FILE_NAME_LEN = (256u);

        /* Maximum length of username */
        public const int NETDEV_USER_NAME_LEN = 32;

        /* Maximum length of password */
        public const int NETDEV_PASSWD_LEN = 64;

        /* Length of password and encrypted passcode for user login */
        public const int NETDEV_PASSWD_ENCRYPT_LEN = 64;

        /* Length of resource code string */
        public const int NETDEV_RES_CODE_LEN = 48;

        /* Maximum length of domain name */
        public const int NETDEV_DOMAIN_LEN = 64;

        /* Maximum length of device name */
        public const int NETDEV_DEVICE_NAME_LEN = 32;

        /* Maximum length of path */
        public const int NETDEV_PATH_LEN_WITHOUT_NAME = 64;

        /* Maximum length of path, including filename */
        public const int NETDEV_PATH_LEN = 128;

        /* Maximum length of email address */
        public const int NETDEV_EMAIL_NAME_ADDR = 32;

        /* Length of MAC address */
        public const int NETDEV_MAC_ADDR_LEN = 6;

        /* Length of endpoint called by gSOAP */
        public const int NETDEV_ENDPOINT_LEN = 96;

        /* Maximum length of session ID */
        public const int NETDEV_SESSION_ID_LEN = 16;

        /* Maximum length of URL */
        public const int NDE_MAX_URL_LEN = 512;

        /* Maximum number of alarm inputs */
        public const int  NETDEV_MAX_ALARM_IN_NUM = 64;

        /* Maximum number of alarm outputs */
        public const int NETDEV_MAX_ALARM_OUT_NUM = 64;

       /* Maximum number of people count */
       public  const int NETDEV_PEOPLE_CNT_MAX_NUM = 60;

        /* Common length */
        public const int NETDEV_LEN_2 = 2;
        public const int NETDEV_LEN_4 = 4;
        public const int NETDEV_LEN_6 = 6;
        public const int NETDEV_LEN_8 = 8;
        public const int NETDEV_LEN_16 = 16;
        public const int NETDEV_LEN_32 = 32;
        public const int NETDEV_LEN_40 = 40;
        public const int NETDEV_LEN_64 = 64;
        public const int NETDEV_LEN_128 = 128;
        public const int NETDEV_LEN_132 = 132;
        public const int NETDEV_LEN_256 = 256;
        public const int NETDEV_LEN_260 = 260;
        public const int NETDEV_LEN_480 = 480;
        public const int NETDEV_LEN_512 = 512;
        public const int NETDEV_LEN_1024 = 1024;
        public const int NETDEV_TMS_PIC_COMMON_NUM = 10;
        public const int NETDEV_TMS_CAR_PLATE_CAMID_LEN = 32;       /*车牌识别CamID字段长度*/
        public const int NETDEV_TMS_CAR_PLATE_RECORDID_LEN = 32;    /*车牌识别RecordID字段长度*/
        public const int NETDEV_TMS_CAR_PLATE_TOLLGATE_LEN = 32;    /*车牌识别TollgateID字段长度*/
        public const int NETDEV_TMS_CAR_PLATE_PASSTIME_LEN = 18;    /*车牌识别PassTime字段长度*/
        public const int NETDEV_TMS_CAR_PLATE_LANEID_LEN = 18;      /*车牌识别LaneID字段长度*/
        public const int NETDEV_TMS_CAR_PLATE_CARPLATE_LEN = 32;    /*车牌识别CarPlate字段长度*/
        public const int NETDEV_MANAGER_SERVER_MAX_NUM = 4;         /* 管理服务器数量上限 Maximum number of Manager Server */
        public const int NETDEV_DEV_NAME_LEN_MAX = 64;              /* 设备名称长度 */
        public const int NETDEV_DISK_SMART_MAX_NUM = 128;           /* 硬盘SMART信息最大数量 Maximum number of Disk Smart Info */
        public const int NETDEV_LOCAL_DISK_MAX_NUM = 32;            /* 本地磁盘最大数量 local Maximum number of Disk */
        public const int NETDEV_SD_CARD_DISK_MAX_NUM = 16;          /* SD卡最大数量 SD Maximum number of Disk */
        public const int NETDEV_ARRAY_MAX_NUM = 16;                 /* 阵列最大数量 array Maximum number of Disk */
        public const int NETDEV_EXTEND_CABINET_DISK_MAX_NUM = 32;   /* 扩展柜硬盘最大数量 extend cabinet Maximum number of Disk */
        public const int NETDEV_NAS_MAX_NUM = 16;                   /* NAS最大数量 NAS Maximum number of Disk */
        public const int NETDEV_ESATA_MAX_NUM = 4;                  /* ESATA最大数量 eSATA Maximum number of Disk */

        /* Length of IP address string */
        public const uint NETDEV_IPADDR_STR_MAX_LEN = (64u);

        /* Length of IPV4 address string */
        public const int NETDEV_IPV4_LEN_MAX = 16;

        /* Length of IPV6 address string */
        public const int NETDEV_IPV6_LEN_MAX = 128;

        /* Length of common name string */
        public const int NETDEV_NAME_MAX_LEN = 256;

        public const int NETDEV_DESCRIBE_MAX_LEN  = (512 + 4);

        /* Length of common code */
        public const int NETDEV_CODE_STR_MAX_LEN = 256;

        /* Maximum length of date string "2008-10-02 09:25:33.001 GMT" */
        public const uint NETDEV_MAX_DATE_STRING_LEN = (64u);

        /* Length of time string "hh:mm:ss" */
        public const uint NETDEV_SIMPLE_TIME_LEN = (12u);

        /* Length of date string "YYYY-MM-DD"*/
        public const uint NETDEV_SIMPLE_DATE_LEN = (12u);

        /* Number of scheduled time sections in a day */
        public const int NETDEV_PLAN_SECTION_NUM = 8;

        /* Total number of plans allowed in a week, including Monday to Sunday, and holidays */
        public const int NETDEV_PLAN_NUM_AWEEK = 8;

        /* Maximum number of motion detection areas allowed */
        public const int NETDEV_MAX_MOTION_DETECT_AREA_NUM = 4;

        /* Maximum number of privacy mask areas allowed */
        public const int NETDEV_MAX_PRIVACY_MASK_AREA_NUM = 8;

        /* Maximum number of tamper-proof areas allowed */
        public const int NETDEV_MAX_TAMPER_PROOF_AREA_NUM = 1;

        /* Maximum number of text overlays allowed for a channel */
        public const int NETDEV_MAX_TEXTOVERLAY_NUM = 6;

        /* Maximum number of video streams */
        public const int NETDEV_MAX_VIDEO_STREAM_NUM = 8;

        /* Month of the year */
        public const int NETDEV_MONTH_OF_YEAR = 12;

        /* Day of the month */
        public const int NETDEV_DAYS_OF_MONTH = 32;

        /* Length of device ID */
        public const int NETDEV_DEV_ID_LEN = 64;

        /* Length of device serial number */
        public const int NETDEV_SERIAL_NUMBER_LEN = 32;

        /* Maximum number of queries allowed at a time */
        public const int NETDEV_MAX_QUERY_NUM = 200;

        /* Total number of queries allowed */
        public const int NETDEV_MAX_QUERY_TOTAL_NUM = 2000;

        /* Maximum number of IP cameras */
        public const int NETDEV_MAX_IPC_NUM = 128;

        /* Maximum number of presets */
        public const int NETDEV_MAX_PRESET_NUM = 255;

        /* Maximum number of presets for preset patrol */
        public const int NETDEV_MAX_CRUISEPOINT_NUM = 32;

        /* Maximum number of routes for preset patrol */
        public const int NETDEV_MAX_CRUISEROUTE_NUM = 16;

        /* PTZ rotating speed */
        public const int NETDEV_MIN_PTZ_SPEED_LEVEL = 1;
        public const int NETDEV_MAX_PTZ_SPEED_LEVEL = 9;

        /* Maximum / Minimum values for image parameters (brightness, contrast, hue, saturation) */
        public const int NETDEV_MAX_VIDEO_EFFECT_VALUE = 255;
        public const int NETDEV_MIN_VIDEO_EFFECT_VALUE = 0;

        /* Minimum values for image parameters (Gama) */
        public const int NETDEV_MAX_VIDEO_EFFECT_GAMMA_VALUE = 10;

        /* Maximum connection timeout */
        public const int NETDEV_MAX_CONNECT_TIME_VALUE = 75000;

        /* Minimum connection timeout */
        public const int NETDEV_MIN_CONNECT_TIME_VALUE = 300;

        /* Maximum number of users */
        public const int NETDEV_MAX_USER_NUM = (256 + 32);

        /* Maximum number of channels allowed for live preview */
        public const int NETDEV_MAX_REALPLAY_NUM = 128;

        /* Maximum number of channels allowed for playback or download */
        public const int NETDEV_MAX_PALYBACK_NUM = 128;

        /* Maximum number of alarm channels */
        public const int NETDEV_MAX_ALARMCHAN_NUM = 128;

        /* Maximum number of channels allowed for formatting hard disk */
        public const int NETDEV_MAX_FORMAT_NUM = 128;

        /* Maximum number of channels allowed for file search */
        public const int NETDEV_MAX_FILE_SEARCH_NUM = 2000;

        /* Maximum number of channels allowed for log search */
        public const int NETDEV_MAX_LOG_SEARCH_NUM = 2000;

        /* Maximum number of channels allowed for creating transparent channels */
        public const int NETDEV_MAX_SERIAL_NUM = 2000;

        /* Maximum number of channels allowed for upgrade */
        public const int NETDEV_MAX_UPGRADE_NUM = 256;

        /* Maximum number of channels allowed for audio forwarding */
        public const int NETDEV_MAX_VOICE_COM_NUM = 256;

        /* Maximum number of channels allowed for audio broadcast */
        public const int NETDEV_MAX_VOICE_BROADCAST_NUM = 256;

        /* Maximum timeout, unit: ms */
        public const int NETDEV_MAX_CONNECT_TIME = 75000;

        /* Minimum timeout, unit: ms */
        public const int NETDEV_MIN_CONNECT_TIME = 300;

        /* Default timeout, unit: ms */
        public const int NETDEV_DEFAULT_CONNECT_TIME = 3000;

        /* Number of connection attempts */
        public const int NETDEV_CONNECT_TRY_TIMES = 1;

        /* User keep-alive interval */
        public const int NETDEV_KEEPLIVE_TRY_TIMES = 3;

        /* Number of OSD text overlays */
        public const int NETDEV_OSD_TEXTOVERLAY_NUM = 6;

        /* Length of OSD texts */
        public const int NETDEV_OSD_TEXT_MAX_LEN = (64 + 4);

        /* Maximum number of OSD type */
        public const int NETDEV_OSD_TYPE_MAX_NUM = 26;

        /* Maximum number of OSD time format type  */
        public const int NETDEV_OSD_TIME_FORMAT_MAX_NUM = 7;

        /* Maximum number of OSD date format type */
        public const int NETDEV_OSD_DATE_FORMAT_MAX_NUM = 15;

        /* Maximum number of alarms a user can get */
        public const int NETDEV_PULL_ALARM_MAX_NUM = 8;

        /* Maximum number of patrol routes allowed  */
        public const int NETDEV_TRACK_CRUISE_MAXNUM = 1;

        /* Minimum volume */
        public const int NETDEV_AUDIO_SOUND_MIN_VALUE = 0;

        /* Maximum volume */
        public const int NETDEV_AUDIO_SOUND_MAX_VALUE = 255;

        /* microphone Minimum volume */
        public const int NETDEV_MIC_SOUND_MIN_VALUE = 0;

        /* microphone Maximum volume */
        public const int NETDEV_MIC_SOUND_MAX_VALUE = 255;

        /* Screen Info Row */
        public const int NETDEV_SCREEN_INFO_ROW = 18;

        /* Screen Info Column */
        public const int NETDEV_SCREEN_INFO_COLUMN = 22;

        /* Length of IP */
        public const int NETDEV_IP_LEN = 64;


        /* Maximum length of URL */
        public const int NETDEV_BUFFER_MAX_LEN = 1024;

        /* Maximum number of channel */
        public const int NETDEV_CHANNEL_MAX = 512;

        /* Maximum number of days in a month */
        public const int NETDEV_MONTH_DAY_MAX = 31;

        /* Maximum number of resolution */
        public const int NETDEV_RESOLUTION_NUM_MAX = 32;

        /* Maximum number of encode type */
        public const int NETDEV_VIDEO_ENCODE_TYPE_MAX = 16;

        /* Length of wifi sniffer MAC  */
        public const int NETDEV_WIFISNIFFER_MAC_MAX_NUM = 64;

        /* Maximum number of wifi sniffer MAC array */
        public const int NETDEV_WIFISNIFFER_MAC_ARRY_MAX_NUM = 128;

        /* Maximum number of Disk */
        public const int NETDEV_DISK_MAX_NUM = 256;

        /* Maximum number of image quality level */
        public const int NETDEV_IMAGE_QUALITY_MAX_NUM = 9;

        /* Maximum number of bit rate mode */
        public const int NETDEV_BIT_RATE_TYPE_MAX_NUM = 2;

        /* Maximum number of video compression  */
        public const int NETDEV_ENCODE_FORMAT_MAX_NUM = 3;

        /*Maximum number of smart image encoding mode  */
        public const int NETDEV_SMART_ENCODE_MODEL_MAX_NUM = 3;

        /* Maximum number of GOP type */
        public const int NETDEV_GOP_TYPE_MAX_NUM = 4;

        public const int TRUE = 1;

        public const int FALSE = 0;
        public const int NETDEV_E_NONSUPPORT = 38;

        public static int m_bRouteRecording;
        public static int m_bTracking;

        public const int NETDEV_MAX_TIME_SECTION_NUM = 8;

        public const int NETDEV_MAX_DAY_NUM = 8;

        /* error code start */

        public const int NETDEV_E_NO_RESULT = 41;          /* No result */
        public const int NETDEV_E_VIDEO_RESOLUTION_CHANGE = 1269;        /* Resolution changed */

        /* error code end */

        /*interface function start */

        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_FaceSnapshotCallBack_PF(IntPtr lpHandle, ref NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S pstFaceSnapShotData, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_AlarmMessCallBack_PF(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_AlarmMessCallBack_PF_V30(IntPtr lpUserID, ref NETDEV_REPORT_INFO_S pstReportInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_ExceptionCallBack_PF(IntPtr lpUserID, Int32 dwType, IntPtr lpExpHandle, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_DISCOVERY_CALLBACK_PF(IntPtr pstDevInfo,IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_PassengerFlowStatisticCallBack_PF(IntPtr lpUserID, IntPtr pstPassengerFlowData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_PersonAlarmMessCallBack_PF(IntPtr lpUserID,ref NETDEV_PERSON_EVENT_INFO_S pstAlarmData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_VehicleAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_VEH_RECOGNITION_EVENT_S pstVehicleAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_StructAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_STRUCT_ALARM_INFO_S pstAlarmInfo, ref NETDEV_STRUCT_DATA_INFO_S pstAlarmData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_AlarmMessFGCallBack_PF(IntPtr lpUserID, ref NETDEV_PERSON_VERIFICATION_S pstAlarmData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);



        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);



        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle,Int32 dwFluency);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);   
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        /* interface function end */














        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_SOURCE_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref byte pucBuffer, IntPtr dwBufSize, Int32 dwMediaDataType, IntPtr lpUserParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_DISPLAY_CALLBACK_PF(IntPtr lpRealHandle, IntPtr hdc, IntPtr lpUserParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_S pstParseVideoData, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref  NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID,Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);


        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID,Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo,ref UInt32 pudwID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle,ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID,ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle,ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);
		
		[DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S  pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo );

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S  pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S  pstResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle,ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);
        
        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_ConflagrationAlarmMessCallBack_PF(IntPtr lpHandle, ref NETDEV_CONFLAGRATION_ALARM_INFO_S pstAlarmInfo, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_CarPlateCallBack_PF(IntPtr lpHandle, ref NETDEV_TMS_CAR_PLATE_INFO_S pstCarPlateData, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SyncPersonLibToDevice(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_ID_LIST_S pstDeviceIDList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPtzAndFixMode(IntPtr lpPlayHandle, ref Int32 pdwPtzMode, ref Int32 pdwInstallMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPtzAndFixMode(IntPtr lpPlayHandle, Int32 pdwPtzMode, Int32 pdwInstallMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_IsFishEyeStream(IntPtr lpPlayHandle, ref Int32 pbFishEyeStream);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetMouseMoveMode(IntPtr lpPlayHandle, Int32 dwOperateMode, UInt32 udwFlag, Int32 wDelta, ref NETDEV_POINT_S pstPoint);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_PeopleCountAlarmMessCallBack_PF(IntPtr lpHandle, ref NETDEV_PEOPLE_COUNT_ALARM_INFO_S pstAlarmInfo, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPeopleCountAlarmCallBack(IntPtr lpUserID, NETDEV_PeopleCountAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindCrowdDensityGroupList(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextCrowdDensityGroupInfo(IntPtr lpFindHandle, ref NETDEV_CROWD_DENSITY_GROUP_INFO_S pstCrowdDensityGroupInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseCrowdDensityGroupList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddCrowdDensityGroupInfo(IntPtr lpUserID, ref NETDEV_CROWD_DENSITY_GROUP_INFO_S pstCrowdDensityGroupInfo, ref UInt32 pUdwGroupID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyCrowdDensityGroupInfo(IntPtr lpUserID, ref NETDEV_CROWD_DENSITY_GROUP_INFO_S pstCrowdDensityGroupInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteCrowdDensityGroupInfo(IntPtr lpUserID, UInt32 udwCrowdDensityGroupID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCrowdDensityGroupInfo(IntPtr lpUserID, UInt32 udwCrowdDensityGroupID, ref NETDEV_CROWD_DENSITY_GROUP_INFO_S pstCrowdDensityGroupInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLinesPeopleCounting(IntPtr lpUserID, UInt32 udwChannelID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartObjectSearch(IntPtr lpUserID, ref NETDEV_QUERY_CHN_CONDITION_S pstStartInfo, ref UInt32 pudwSearchID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopObjectSearch(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetObjectSearchProg(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwPercent);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindObjectSearchList(IntPtr lpUserID, ref NETDEV_PIC_QUERY_COND_S pstQueryCond, ref NETDEV_PIC_QUERY_RESULT_S pstQueryResult);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextObjectSearchInfo(IntPtr lpFindHandle, ref NETDEV_OBJECT_RESULT_INFO_S pstObjectResultInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseObjectSearchList(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindFile_V30(IntPtr lpUserID, ref NETDEV_FILECOND_S pstFindCond);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindAlarmLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref Int32 pdwTotalRealRow);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextAlarmLog(IntPtr lpFindHandle, ref NETDEV_ALARM_LOG_INFO_S pstAlarmLogInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseAlarmLog(IntPtr lpFindHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindAlarmRelatedDataList(IntPtr lpUserID, Int32 dwAlarmID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextAlarmRelatedDataInfo(IntPtr lpFindHandle, ref NETDEV_ALARM_RELATED_DATA_S pstAlarmRelatedData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseAlarmRelatedDataList(IntPtr lpFindHandle);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_ConflagrationAlarmCallBack_PF_V30(IntPtr lpHandle, ref NETDEV_CONFLAGRATION_ALARM_INFO_V30_S pstAlarmInfo, IntPtr lpUserParam);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConflagrationAlarmCallBackV30(IntPtr lpUserID, NETDEV_ConflagrationAlarmCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_PicAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_ALARM_PIC_DATA_S pstAlarmPicData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPicAlarmCallBack(IntPtr lpUserID, NETDEV_PicAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetThermalParam(IntPtr lpPlayHandle, ref NETDEV_THERMAL_PARAM_INFO_S pstThermalParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_SmokeAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_SMOKE_DETC_S pstSmokeAlarmData, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSmokeAlarmCallBack(IntPtr lpUserID, NETDEV_SmokeAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_TemperatureDetcMessCallBack_PF(IntPtr lpUserID, ref NETDEV_TEMPERATURE_ALARM_INFO_S pstTemperatureDetcInfo, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetTemperatureDetcCallBack(IntPtr lpUserID, NETDEV_TemperatureDetcMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);
       }
}
