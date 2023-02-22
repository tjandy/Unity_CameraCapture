using UnityEditor;
using UnityEngine;

/// <summary>
/// 相机截图 编辑器
/// </summary>
[CanEditMultipleObjects]
[CustomEditor(typeof(CameraCapture))]
public class CameraCaptureEditor : Editor {

    public override void OnInspectorGUI() {
        // 属性
        CameraCapture script = (CameraCapture)target;
        // 重绘GUI
        EditorGUI.BeginChangeCheck();
        drawProperty("targetCamera", "目标像机");
        drawProperty("offsetx", "x轴偏移");
        drawProperty("savePath", "保存路径");
        // 保存截图按钮
        bool isPress = GUILayout.Button("保存截图", GUILayout.ExpandWidth(true));
        if (isPress) script.saveAll();
        bool iss = GUILayout.Button("排列player", GUILayout.ExpandWidth(true));
        if (iss) script.sortPlayer();
        if (EditorGUI.EndChangeCheck()) serializedObject.ApplyModifiedProperties();
    }

    private void drawProperty(string property, string label) {
        EditorGUILayout.PropertyField(serializedObject.FindProperty(property), new GUIContent(label), true);
    }

}