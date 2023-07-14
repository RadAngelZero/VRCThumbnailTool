using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace RadAngelZero.ThumbnailTool.Editor
{
    [CustomEditor(typeof(ThumbnailTool))]
    public class ThumbnailToolEditor : UnityEditor.Editor
    {

        private ThumbnailTool Tool => target as ThumbnailTool;

        private VisualElement _root;

        private const string StringPath = "Packages/vrchat.radangelzero.thumbnailtool/ThumbnailTool.prefab";
        [MenuItem("Tools/Rad/Add Thumbnail Tool")]
        private static void AddThumbnailTool()
        {
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(StringPath);
            if (!asset) asset = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.FindAssets("t:prefab ThumbnailTool").Select(AssetDatabase.GUIDToAssetPath).FirstOrDefault());
            AddThumbnailTool(asset);
        }
        private static void AddThumbnailTool(Object gObject)
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


        public override VisualElement CreateInspectorGUI()
        {
            _root = new VisualElement();
            _root.Add(new IMGUIContainer(ToolGui));
            ThumbnailTool toolInstance = (ThumbnailTool)target;
            SerializedObject toolSerial = new UnityEditor.SerializedObject(toolInstance);
            SerializedProperty toolThuimbnailSerial = serializedObject.FindProperty("thumbnail");
            SerializedProperty toolPosXSerial = serializedObject.FindProperty("posX");
            SerializedProperty toolPosYSerial = serializedObject.FindProperty("posY");
            SerializedProperty toolScaleSerial = serializedObject.FindProperty("scale");
            SerializedProperty toolForceThumbnailUpdateSerial = serializedObject.FindProperty("forceThumbnailUpdate");

            
            _root.Add(new PropertyField(toolThuimbnailSerial, "Thumbnail"));
            _root.Add(new PropertyField(toolPosXSerial, "Position X"));
            _root.Add(new PropertyField(toolPosYSerial, "Position Y"));
            _root.Add(new PropertyField(toolScaleSerial, "Scale"));
            _root.Add(new PropertyField(toolForceThumbnailUpdateSerial, "Force Thumbnail Update"));


            return _root;
        }

        private void ToolGui()
        {
            if (!Tool) return;
            GUILayout.Label("Thumbnail Tool 0.0.1", ThumbnailToolStyles.TitleStyle);
            
        }
    }
    [CustomPropertyDrawer(typeof(ThumbnailTool))]
    public class ThumbnailTool_PropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var field = new UnityEngine.UIElements.Box();
            field.Add(new PropertyField(property.FindPropertyRelative("Thumbnail"), "Thumbnail"));

            container.Add(field);

            return container;
        }
    }
}

