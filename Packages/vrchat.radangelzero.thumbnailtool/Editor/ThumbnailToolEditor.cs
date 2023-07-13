using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace RadAngelZero.ThumbnailTool.Editor
{
    [CustomEditor(typeof(ThumbnailTool))]
    public class ThumbnailToolEditor : UnityEditor.Editor
    {
        private const string StringPath = "Packages/vrchat.radangelzero.thumbnailtool/ThumbnailTool.prefab";
        [MenuItem("Tools/Rad/Add Thumbnail Tool")]
        private static void AddThumbnailTool()
        {
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(StringPath);
            if (!asset) asset = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.FindAssets("t:prefab GestureManager").Select(AssetDatabase.GUIDToAssetPath).FirstOrDefault());
            AddThumbnailTool(asset);
        }
        private static void AddThumbnailTool(UnityEngine.Object gObject)
        {
            var prefab = PrefabUtility.InstantiatePrefab(gObject) as GameObject;
            CreateAndPing(prefab ? prefab.GetComponent<ThumbnailTool>() : null);
        }
        public static void CreateAndPing(ThumbnailTool manager = null)
        {
            if (!manager) manager = new GameObject("GestureManager").AddComponent<ThumbnailTool>();
            Selection.activeObject = manager;
            EditorGUIUtility.PingObject(manager);
        }
    }
}

