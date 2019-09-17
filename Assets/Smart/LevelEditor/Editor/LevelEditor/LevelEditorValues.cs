using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    //
    // Properties
    //

    // Is window focused
    private bool isFocused = false;

    // Is this level editor active
    private bool active = false;

    // The height of an invisible plane where objects are placed
    private float height = 0;

    // Mode
    private Mode mode;

    // Paint
    private Paint paint;

    // Current unity editor tool
    private Tool tool;

    // Objects Scroll View
    private Vector2 objsViewPos;

    // The size of the brush
    private Vector3Int size = Vector3Int.one;

    // Snap move value
    private Vector3 move = Vector3.one;

    // Snap rotate value
    private Vector3 rotate = new Vector3(15, 15, 15);

    // Snap scale value
    private Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);

    // Current event
    private Event e;

    // Layer mask
    private LayerMask layer;

    // Selected objects
    private List<GameObject> selected = new List<GameObject>();

    // Prefabs categories (by path)
    private Keylist<string, GameObject> prefabs = new Keylist<string, GameObject>();

    // Prefabs categories expanded
    private List<bool> isExpanded = new List<bool>();

    // Scene label style name
    private string sceneLabelStyle = "profilerbadge";

    // Search filter
    private string filter = "";

    //
    // Default properties
    //

    private readonly Vector3Int defaultSize = Vector3Int.one;
    private readonly Vector3 defaultMove = Vector3.one;
    private readonly Vector3 defaultRotate = new Vector3(15, 15, 15);
    private readonly Vector3 defaultScale = new Vector3(0.5f, 0.5f, 0.5f);
    private readonly int defaultLayer = 0;
    private readonly float defaultHeight = 0;

    //
    // Methods
    //

    void Load()
    {
        size = GetPrefsVector("sle.size", defaultSize);
        move = GetPrefsVector("sle.move", defaultMove);
        rotate = GetPrefsVector("sle.rotate", defaultRotate);
        scale = GetPrefsVector("sle.scale", defaultScale);
        layer = EditorPrefs.GetInt("sle.layer", defaultLayer);
        height = EditorPrefs.GetFloat("sle.height", defaultHeight);
    }

    void Save()
    {
        SetPrefsVector("sle.size", size);
        SetPrefsVector("sle.move", move);
        SetPrefsVector("sle.rotate", rotate);
        SetPrefsVector("sle.scale", scale);
        EditorPrefs.SetInt("sle.layer", layer);
        EditorPrefs.SetFloat("sle.height", height);
    }

    Vector3 GetPrefsVector(string key, Vector3 defaultValue)
    {
        Vector3 result = defaultValue;

        result.x = EditorPrefs.GetFloat(string.Format("{0}.x", key), defaultValue.x);
        result.y = EditorPrefs.GetFloat(string.Format("{0}.y", key), defaultValue.y);
        result.z = EditorPrefs.GetFloat(string.Format("{0}.z", key), defaultValue.z);

        return result;
    }

    Vector3Int GetPrefsVector(string key, Vector3Int defaultValue)
    {
        Vector3Int  result = defaultValue;

        result.x = EditorPrefs.GetInt(string.Format("{0}.x", key), defaultValue.x);
        result.y = EditorPrefs.GetInt(string.Format("{0}.y", key), defaultValue.y);
        result.z = EditorPrefs.GetInt(string.Format("{0}.z", key), defaultValue.z);

        return result;
    }

    void SetPrefsVector(string key, Vector3 value)
    {
        EditorPrefs.SetFloat(string.Format("{0}.x", key), value.x);
        EditorPrefs.SetFloat(string.Format("{0}.y", key), value.y);
        EditorPrefs.SetFloat(string.Format("{0}.z", key), value.z);
    }

    void SetPrefsVector(string key, Vector3Int value)
    {
        EditorPrefs.SetInt(string.Format("{0}.x", key), value.x);
        EditorPrefs.SetInt(string.Format("{0}.y", key), value.y);
        EditorPrefs.SetInt(string.Format("{0}.z", key), value.z);
    }
}
