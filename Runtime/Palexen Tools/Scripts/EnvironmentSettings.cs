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
using UnityEngine;

namespace Palexen.Tools
{
    [CreateAssetMenu(fileName = "Palexen Environment Settings", menuName = "Palexen/Environment Settings")]
    public class CustomEnvironment : ScriptableObject
    {
        #region VARIABLES

        [Header("Color Presets")]
        [SerializeField] private Color _preset1 = Color.white;
        [SerializeField] private Color _preset2 = Color.white;
        [SerializeField] private Color _preset3 = Color.white;
        [SerializeField] private Color _preset4 = Color.white;
        [SerializeField] private Color _preset5 = Color.white;
        [SerializeField] private Color _contextSeparatorColor = Color.white;

        #endregion

        #region PROPERTIES

        public Color Preset1 { get { return _preset1; } }
        public Color Preset2 { get { return _preset2; } }
        public Color Preset3 { get { return _preset3; } }
        public Color Preset4 { get { return _preset4; } }
        public Color Preset5 { get { return _preset5; } }
        public Color ContextSeparatorColor { get { return _contextSeparatorColor; } }

        #endregion

        #region UNITY METHODS



        #endregion

        #region MECHANICS



        #endregion

        #region API



        #endregion
    }
}
