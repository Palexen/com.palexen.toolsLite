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
using System;
using UnityEngine;

namespace Palexen.Tools
{
    #region ENUMS

    public enum FieldPropertyColor { preset1, preset2, preset3, preset4, preset5 }
    public enum ShowObjectMessage { no, message, warningMessage, errorMessage }

    #endregion

    #region BACKGROUND

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class BackgroundAttribute : PropertyAttribute
    {
        private FieldPropertyColor m_color;

        public FieldPropertyColor BackgroundColor { get { return m_color; } }

        public BackgroundAttribute(FieldPropertyColor color)
        {
            m_color = color;
        }
    }

    #endregion

    #region TAGFIELD

    /// <summary>
    /// This attribute allows you to select a tag from a dropdown menu in the inspector, 
    /// ensuring that only valid tags can be assigned to the string field.
    /// </summary>
    public class TagFieldAttribute : PropertyAttribute
    {
        //Nothing needed here.
    }

    #endregion

    #region SEPARATOR

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SeparatorAttribute : PropertyAttribute
    {
        private string _message;
        private ShowObjectMessage _type;

        public SeparatorAttribute(string message = "", ShowObjectMessage type = ShowObjectMessage.no)
        {
            this._message = message;
            this._type = type;
        }

        public string Message { get { return _message; } }
        public ShowObjectMessage Type { get { return _type; } }
    }

    #endregion

    #region NOTES

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class NotepadAttribute : PropertyAttribute
    {
        private string note;
        private TextAnchor alignment;
        private FontStyle fs;

        public string Message { get { return note; } }
        public TextAnchor Alignment { get { return alignment; } }
        public FontStyle FontStyles { get { return fs; } }

        public NotepadAttribute(string bloc = "", FontStyle fontStyle = FontStyle.Normal, TextAnchor alignment = TextAnchor.MiddleLeft)
        {
            this.note = bloc;
            this.fs = fontStyle;
            this.alignment = alignment;
        }
    }

    #endregion
}