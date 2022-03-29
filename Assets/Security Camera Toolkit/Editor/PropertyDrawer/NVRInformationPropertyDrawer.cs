// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using zFramework.Localization;
using zFramework.Media;

[CustomPropertyDrawer(typeof(NVRInformation))]
public class NVRInformationPropertyDrawer : PropertyDrawer
{
    bool hostmatched = false;
    bool mapingmatched = false;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //设置属性名宽度
        EditorGUIUtility.labelWidth = 60;
        position.height = EditorGUIUtility.singleLineHeight;

        // 初始化需要用到的字段
        var host = property.FindPropertyRelative("host");
        var type = property.FindPropertyRelative("type");
        var enable = property.FindPropertyRelative("enable");
        var mapping = property.FindPropertyRelative("mapping");
        var enableMapping = property.FindPropertyRelative("enableMapping");
        var userName = property.FindPropertyRelative("userName");
        var password = property.FindPropertyRelative("password");
        var desc = property.FindPropertyRelative("description");

        var foldout_Pos = new Rect(position);
        foldout_Pos.height = EditorGUI.GetPropertyHeight(SerializedPropertyType.String, new GUIContent(host.stringValue));
        var title = string.IsNullOrEmpty(host.stringValue) ? "default_title_host".Allocate() : host.stringValue;
        property.isExpanded = EditorGUI.Foldout(foldout_Pos, property.isExpanded, title);

        if (!property.isExpanded)
        {
            var tip = !enable.boolValue ? "" : enableMapping.boolValue ? "mapping_enable_tip".Allocate() : "host_enable_tip".Allocate();
            if (!string.IsNullOrEmpty(tip))
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.green;
                style.fontSize = 10;
                style.alignment = TextAnchor.MiddleRight;

                var tip_pos = new Rect(position);
                tip_pos.x = tip_pos.width - 20;
                tip_pos.width = 80;
                EditorGUI.LabelField(tip_pos, tip, style);
            }
        }
        else
        {
            position.y += 8; //想上下留点余量
            hostmatched = IsHostMatched(host.stringValue);
            mapingmatched = IsHostMatched(mapping.stringValue);
            isHelpboxShouldBeShowed = !hostmatched || (!mapingmatched && enableMapping.boolValue);
            if (isHelpboxShouldBeShowed)
            {
                position.y += position.height + 2; //开始绘制 主机格式异常 信息
                EditorGUI.HelpBox(position, "helpbox_host_error".Allocate(), MessageType.Error);
            }
            #region 绘制默认主机
            position.y += position.height + 2;
            var host_pos = new Rect(position);
            EditorGUI.PrefixLabel(host_pos, new GUIContentEx("host", "tooltip_host_error"));
            var hostv_pos = new Rect(position)
            {
                width = position.width - 60 - 58 - 15,//间隔 10Pixel
            };
            hostv_pos.x += 60;
            if (hostmatched)
            {
                EditorGUI.DelayedTextField(hostv_pos, host, GUIContent.none);
            }
            else
            {
                using (new BackgroundColorScope(Color.red))
                {
                    host.stringValue = EditorGUI.TextField(hostv_pos, host.stringValue);
                }
            }

            var sdk_pos = new Rect(position)
            {
                width = 48,
                x = position.width - 4
            };

            type.enumValueIndex = (int)(SDKTYPE)EditorGUI.EnumPopup(sdk_pos, (SDKTYPE)type.enumValueIndex);
            sdk_pos.x = position.width + 48;
            enable.boolValue = EditorGUI.Toggle(sdk_pos, enable.boolValue);
            #endregion

            #region 映射主机
            position.y += position.height + 2;
            var map_pos = new Rect(position);
            EditorGUI.PrefixLabel(map_pos, new GUIContentEx("mapping", "tooltip_host_error"));
            map_pos.x += 60;
            map_pos.width = position.width - 60 - 21;
            if (mapingmatched || !enableMapping.boolValue)
            {
                EditorGUI.DelayedTextField(map_pos, mapping, GUIContent.none);
            }
            else
            {
                using (new BackgroundColorScope(Color.red))
                {
                    mapping.stringValue = EditorGUI.TextField(map_pos, mapping.stringValue);
                }
            }
            map_pos.x += map_pos.width + 4;
            enableMapping.boolValue = EditorGUI.Toggle(map_pos, enableMapping.boolValue);
            #endregion

            #region 绘制账号 
            position.y += position.height + 2;
            var user_pos = new Rect(position);
            EditorGUI.PrefixLabel(user_pos, new GUIContentEx("user", "label_tooltip_user"));
            user_pos.x += 60;
            user_pos.width = position.width - 60 - 2;
            EditorGUI.DelayedTextField(user_pos, userName, GUIContent.none);

            #endregion
            #region 密码
            position.y += position.height + 2;
            var psw_pos = new Rect(position);
            EditorGUI.PrefixLabel(psw_pos, new GUIContentEx("password", "label_tooltip_psw"));
            psw_pos.x += 60;
            psw_pos.width = position.width - 60 - 21;

            var pswt_pos = new Rect(position);
            pswt_pos.width = 20;
            pswt_pos.x = position.width + 48;
            password.isExpanded = EditorGUI.Toggle(pswt_pos, password.isExpanded);
            if (password.isExpanded)
            {
                password.stringValue = EditorGUI.TextField(psw_pos, password.stringValue);
            }
            else
            {
                password.stringValue = EditorGUI.PasswordField(psw_pos, password.stringValue);
            }
            #endregion

            #region 绘制 Description
            position.y += position.height + 2;
            var desc_pos = new Rect(position);
            EditorGUI.PrefixLabel(desc_pos, new GUIContentEx("desc", "label_tooltip_desc"));
            desc_pos.x += 60;
            desc_pos.width = position.width - 60;
            desc_pos.height = position.height * (isHelpboxShouldBeShowed?2:3);//没动图出现的 control 暂时没找到获取高度的方法
            desc.stringValue = EditorGUI.TextArea(desc_pos, desc.stringValue);
            #endregion
        }
        EditorGUI.EndProperty();
    }
 

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = base.GetPropertyHeight(property, label);
        if (property.isExpanded)
        {
            var control_height = EditorGUIUtility.singleLineHeight * 8 + 2 * 6+16;// 8 个 control的高度 外加 6 个 2 pixel 的间隔，16 为上下的余量
            var helpbox_height = 2 + EditorGUIUtility.singleLineHeight;  //这个暂时先这么写着，没啥用
            height = control_height + (isHelpboxShouldBeShowed ? helpbox_height : 0);
        }
        return height;
    }


    #region Assistance Function

    /// <summary>
    /// 用于校验 IP:Port 的正则
    /// </summary>

    string pattern_ip = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";
    string pattern_port = @"^((6553[0-5])|(655[0-2][0-9])|(65[0-4][0-9]{2})|(6[0-4][0-9]{3})|([1-5][0-9]{4})|([0-5]{0,5})|([0-9]{1,4}))$";
    private bool isHelpboxShouldBeShowed;

    private bool IsHostMatched(string host)
    {
        var arr = host.Trim().Split(':');
        var ip = arr[0];
        var port = arr.Length == 1 ? "80" : arr[1];
        var ipMatch = Regex.IsMatch(ip, pattern_ip);
        var portMatch = Regex.IsMatch(port, pattern_port);
        return ipMatch && portMatch;
    }

    #endregion

}
