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
using System.Collections.Generic;
using UnityEngine;
using Palexen.Tools;

public class DemoScript : MonoBehaviour
{
    #region VARIABLES

#if PALEXEN_TOOLS
    [Separator("Color Fields")]
    [Background(FieldPropertyColor.preset1)] public GameObject _object;
    [Background(FieldPropertyColor.preset2)] public List<GameObject> _list;
    [Background(FieldPropertyColor.preset3)] public GameObject[] _array;

    [Separator("Background Color Fields")]
    [TagField] public string _tagField;
    [Background(FieldPropertyColor.preset4)] [TagField] public string _tagfieldColor;
    [Background(FieldPropertyColor.preset5)] public LayerMask anyBackgroundColor;

    [Space(10)]
    [Separator("Your Message Here", ShowObjectMessage.message)]
    public GameObject _necessaryField1;

    [Space(10)]
    [Separator("Your Warning Message Here", ShowObjectMessage.warningMessage)]
    public GameObject _necessaryField2;

    [Space(10)]
    [Separator("Your Error Message Here", ShowObjectMessage.errorMessage)]
    public GameObject _necessaryField3;

    [Separator("Notepad")]
    [Notepad("Your <color=cyan>Notepad</color> Message Here, you can write multiple lines of text here.\n" +
        "Also you can use this to write instrucctions for your team members or for you in the future!\n" +
        "You can <color=yellow>also</color> use font styles", FontStyle.BoldAndItalic, TextAnchor.MiddleLeft)]
    public GameObject _necessaryField4;
#else
    [Header("Color Fields")]
    public GameObject _object;
    public List<GameObject> _list;
    public GameObject[] _array;

    [Header("Background Color Fields")]
    public string _tagField;
    public string _tagfieldColor;
    public LayerMask anyBackgroundColor;

    [Space(10)]
    [Header("Your Message Here", ShowObjectMessage.message)]
    public GameObject _necessaryField1;

    [Space(10)]
    [Header("Your Warning Message Here", ShowObjectMessage.warningMessage)]
    public GameObject _necessaryField2;

    [Space(10)]
    [Header("Your Error Message Here", ShowObjectMessage.errorMessage)]
    public GameObject _necessaryField3;

    [Header("Notepad")]
    [Tooltip("Your <color=cyan>Notepad</color> Message Here, you can write multiple lines of text here.\n" +
        "Also you can use this to write instrucctions for your team members or for you in the future!\n" +
        "You can <color=yellow>also</color> use font styles", FontStyle.BoldAndItalic, TextAnchor.MiddleLeft)]
    public GameObject _necessaryField4;
#endif

    #endregion
}
