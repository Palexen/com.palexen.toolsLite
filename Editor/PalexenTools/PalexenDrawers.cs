/*
* -----------------------------------------------------------------------------
* Palexen Tools
* © Palexen | Xeen Render & Devward. All rights reserved.
* https://www.palexen.com/

* -----------------------------------------------------------------------------

* Developed by: Palexen & Xeen Render

* Written by: Devward

* This software is provided "as is," without warranties of any kind.

* Use of this script is subject to the terms of the Palexen Tools and other derivative products license.

* Commercial redistribution or redistribution to third parties without authorization is prohibited.

* -----------------------------------------------------------------------------
*/
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Palexen.Tools.Editor
{
    #region BACKGROUND

    [CustomPropertyDrawer(typeof(BackgroundAttribute))]
    public class BackgroundDrawer : PropertyDrawer
    {
        Color color;

        private static CustomEnvironment _cachedSettings;
        private static CustomEnvironment Settings
        {
            get
            {
                if (_cachedSettings == null)
                    _cachedSettings = Resources.Load<CustomEnvironment>("Environment Settings/Palexen Environment Settings");
                return _cachedSettings;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            BackgroundAttribute bg = (BackgroundAttribute)attribute;

            _cachedSettings = Settings;

            if (_cachedSettings != null)
            {
                Rect r = new(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(property, label));

                switch (bg.BackgroundColor)
                {
                    case FieldPropertyColor.preset1:
                        color = _cachedSettings.Preset1;
                        break;

                    case FieldPropertyColor.preset2:
                        color = _cachedSettings.Preset2;
                        break;

                    case FieldPropertyColor.preset3:
                        color = _cachedSettings.Preset3;
                        break;

                    case FieldPropertyColor.preset4:
                        color = _cachedSettings.Preset4;
                        break;

                    case FieldPropertyColor.preset5:
                        color = _cachedSettings.Preset5;
                        break;
                }

                GUI.backgroundColor = color;
                EditorGUI.PropertyField(r, property, label, true);
                GUI.backgroundColor = Color.white;
            }
            else
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float h = EditorGUI.GetPropertyHeight(property, label, true);

            return h;
        }
    }

    #endregion

    #region TAGFIELD

    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagSelectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                EditorGUI.BeginProperty(position, label, property);

                List<string> tagList = new()
                {
                    "Untagged"
                };
                tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);

                int index = tagList.IndexOf(property.stringValue);
                if (index < 0) index = 0;

                EditorGUI.BeginChangeCheck();
                index = EditorGUI.Popup(position, label.text, index, tagList.ToArray());

                if (EditorGUI.EndChangeCheck())
                {
                    if (index == 0)
                        property.stringValue = "";
                    else
                        property.stringValue = tagList[index];
                }

                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }

    #endregion

    #region SEPARATOR

    [CustomPropertyDrawer(typeof(SeparatorAttribute))]
    public class SeparatorDrawer : PropertyDrawer
    {
        private const float HelpBoxHeight = 18f;
        private const float HelpBoxMessageHeight = 30f;
        private const float SpaceHeight = 2;

        private static CustomEnvironment _cachedSettings;
        private static CustomEnvironment Settings
        {
            get
            {
                if (_cachedSettings == null)
                    _cachedSettings = Resources.Load<CustomEnvironment>("Environment Settings/Palexen Environment Settings");
                return _cachedSettings;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SeparatorAttribute box = (SeparatorAttribute)attribute;

            float h = GetBoxHeight(box.Type);

            _cachedSettings = Settings;

            MessageType t = new();

            switch (box.Type)
            {
                case ShowObjectMessage.errorMessage: t = MessageType.Error; break;
                case ShowObjectMessage.warningMessage: t = MessageType.Warning; break;
                case ShowObjectMessage.message: t = MessageType.Info; break;
                case ShowObjectMessage.no: t = MessageType.None; break;
            }

            Rect boxRect = new(position.x, position.y, position.width, h);

            if (t == MessageType.None)
            {
                Color originalColor = GUI.color;
                if (_cachedSettings != null) GUI.color = _cachedSettings.ContextSeparatorColor;

                EditorGUI.HelpBox(boxRect, box.Message, t);

                GUI.color = originalColor;
            }
            else
            {
                EditorGUI.HelpBox(boxRect, box.Message, t);
            }

            float propertyY = position.y + h + SpaceHeight;
            float propertyHeight = EditorGUI.GetPropertyHeight(property, label, true);
            Rect propertyRect = new(position.x, propertyY, position.width, propertyHeight);
            EditorGUI.PropertyField(propertyRect, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SeparatorAttribute box = (SeparatorAttribute)attribute;
            float h = GetBoxHeight(box.Type);
            float baseHeight = EditorGUI.GetPropertyHeight(property, label, true);

            return baseHeight + h + SpaceHeight;
        }

        private float GetBoxHeight(ShowObjectMessage type)
        {
            return type == ShowObjectMessage.no ? HelpBoxHeight : HelpBoxMessageHeight;
        }

    }

    #endregion

    #region NOTES

    [CustomPropertyDrawer(typeof(NotepadAttribute))]
    public class NoteDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            NotepadAttribute note = (NotepadAttribute)attribute;

            GUIStyle style = new(GUI.skin.box)
            {
                richText = true,
                alignment = note.Alignment,
                fontStyle = note.FontStyles
            };

            GUIContent boxContent = new GUIContent(note.Message);
            float boxHeight = style.CalcHeight(boxContent, position.width);

            Rect boxRect = new(position.x, position.y, position.width, boxHeight);
            GUI.Box(boxRect, boxContent, style);

            float propertyY = position.y + boxHeight + 2;
            float propertyHeight = EditorGUI.GetPropertyHeight(property, label, true);
            Rect propertyRect = new(position.x, propertyY, position.width, propertyHeight);

            EditorGUI.PropertyField(propertyRect, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            NotepadAttribute note = (NotepadAttribute)attribute;

            GUIStyle style = new GUIStyle(GUI.skin.box)
            {
                richText = true,
                alignment = note.Alignment,
                fontStyle = note.FontStyles
            };

            GUIContent boxContent = new GUIContent(note.Message);

            float currentWidth = EditorGUIUtility.currentViewWidth;
            float boxHeight = style.CalcHeight(boxContent, currentWidth);

            float baseHeight = EditorGUI.GetPropertyHeight(property, label, true);
            return boxHeight + 2 + baseHeight;
        }
    }

    #endregion
}