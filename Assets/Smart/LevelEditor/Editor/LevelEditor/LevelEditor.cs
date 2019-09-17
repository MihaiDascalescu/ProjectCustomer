using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    //
    // Unity
    //

    [MenuItem("Tools/Smart/Level Editor")]
    static void Init()
    {
        GetWindow<LevelEditor>("Level Editor");
    }

    private void OnEnable()
    {
        Load();

        GetObjects();

        tool = Tools.current;

        SceneView.onSceneGUIDelegate += OnSceneGUI;

        Selection.selectionChanged += SelectionChanged;
    }

    private void OnDisable()
    {
        Save();

        SceneView.onSceneGUIDelegate -= OnSceneGUI;

        Selection.selectionChanged -= SelectionChanged;
    }

    private void OnFocus()
    {
        tool = Tools.current;

        isFocused = true;

        GetObjects();
    }

    private void OnLostFocus()
    {
        isFocused = false;
    }

    private void OnHierarchyChange()
    {
        if (isFocused)
        {
            Repaint();
        }
    }

    private void OnGUI()
    {
        OnDrawGUI();
    }

    //
    // Methods
    //

    SceneView view;
    
    void OnSceneGUI(SceneView view)
    {
        e = Event.current;

        this.view = view;

        ControlActive();

        if (!IsActive()) { return; }

        ControlMode();
        ControlTools();
        ControlPaint();
        ControlHeight();
        EditUpdate();

        if(isFocused)
        {
            Repaint();
        }
    }

    void SelectionChanged()
    {
        transforms = Selection.transforms;

        if(null != transforms && transforms.Length > 0)
        {
            for(int i = 0; i < transforms.Length; i++)
            {
                transforms[i].hasChanged = false;
            }
        }
    }
}
