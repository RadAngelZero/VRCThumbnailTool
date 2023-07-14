using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadAngelZero.ThumbnailTool.Editor
{
    public class ThumbnailToolStyles
    {
        private const string RadName = "RadAngelZero";

        private static GUIStyle _titleStyle;

        internal static GUIStyle TitleStyle => _titleStyle ?? (_titleStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 15,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
            padding = new RectOffset(10, 10, 10, 10)
        });
    }
}
