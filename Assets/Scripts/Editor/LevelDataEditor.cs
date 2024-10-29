using UnityEditor;

[CustomEditor(typeof(PlaceLoader))]
public class LevelDataEditor : Editor
{
    private Editor editorInstance;
    void OnEnable()
    {
        editorInstance = null;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlaceLoader script = (PlaceLoader)target;
        if (script.data)
        {
            if (editorInstance == null)
                editorInstance = CreateEditor(script.data);
            editorInstance.DrawDefaultInspector();
        }
    }
}