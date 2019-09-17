using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    //
    // Mode & Paint
    //

    public enum Paint
    {
        Single,
        Brush
    }

    public enum Mode
    {
        Create,
        Delete,
        Move,
        Rotate,
        Scale
    }

    //
    // Passive Controls
    //

    void PassiveControls()
    {
        int passive = GUIUtility.GetControlID(FocusType.Passive);
        HandleUtility.AddDefaultControl(passive);
    }

    //
    // Snap
    //

    public float Snap(float val, float snap)
    {
        if(snap > 0)
        {
            val = Mathf.Round(val / snap) * snap;
        }

        return val;
    }

    public Vector3 Snap(Vector3 v, float x, float y, float z)
    {
        v.x = Snap(v.x, x);
        v.y = Snap(v.y, y);
        v.z = Snap(v.z, z);

        return v;
    }

    public Vector3 Snap(Vector3 v, Vector3 snap)
    {
        v.x = Snap(v.x, snap.x);
        v.y = Snap(v.y, snap.y);
        v.z = Snap(v.z, snap.z);
        

        return v;
    }

    //
    // Labels
    //

    void SceneLabel(Vector3 point, string text)
    {
        Handles.Label(point, text, sceneLabelStyle);
    }

    void SceneLabel(Vector3 point, string format, object arg)
    {
        Handles.Label(point, string.Format(format, arg), sceneLabelStyle);
    }

    void SceneLabel(Vector3 point, string format, params object[] args)
    {
        Handles.Label(point, string.Format(format, args), sceneLabelStyle);
    }

    //
    // Draws
    // 

    void DrawBrush(Vector3 point, Color color)
    {
        Handles.color = color;

        Handles.DrawWireCube(point, size);
    }

    //void DrawDisc()
    //{
    //    Handles.color = new Color(0.2f, 0.7f, 1f, 0.4f);
    //    Handles.DrawSolidDisc(pickPosition, Vector3.up, snap.magnitude * 0.3f);
    //}

    //
    // Mesh Draw
    //

    public class MeshDraw
    {
        private Material material;
        private Renderer renderer;
        private Mesh mesh;
        private MeshFilter filter;
        private GameObject gameObject;
        private Transform transform;

        public void Set(GameObject gameObject)
        {
            // Gameobject
            this.gameObject = gameObject;
            // E x i t
            if (!this.gameObject) { return; }
            // Transform
            transform = this.gameObject.transform;
            // Renderer
            renderer = gameObject.GetComponentInChildren<Renderer>();
            // Material
            material = renderer ? renderer.sharedMaterial : null;
            // Filter
            filter = gameObject.GetComponentInChildren<MeshFilter>();
            // Mesh
            mesh = filter ? filter.sharedMesh : null;
        }

        public void Draw(Vector3[] points)
        {
            // E x i t
            if (!gameObject || !mesh) { return; }

            material.SetPass(0);

            for (int i = 0; i < points.Length; i++)
            {
                Graphics.DrawMeshNow(mesh, points[i], transform.rotation);
            }
        }
    }

    bool IsActive()
    {
        if (!active) { return false; }

        return true;
    }

    void GetObjects()
    {
        string[] guids = AssetDatabase.FindAssets("t:prefab");
        string path = "";
        GameObject go = null;
        prefabs = new Keylist<string, GameObject>();

        for (int i = 0; i < guids.Length; i++)
        {
            // Get the path of the current guid
            path = AssetDatabase.GUIDToAssetPath(guids[i]);
            // Load gameObject
            go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            // Continue
            if (null == go) { continue; }
            // Add to the key list
            prefabs.Add(path.Substring(0, path.LastIndexOf("/")), go);
        }

        isExpanded = new List<bool>();

        for (int k = 0; k < prefabs.KeyCount; k++)
        {
            isExpanded.Add(true);
        }
    }

    void DrawSelectedPreview()
    {
        for (int k = 0; k < prefabs.KeyCount; k++)
        {
            for (int v = 0; v < prefabs.Values[k].Count; v++)
            {
                if (selected.Contains(prefabs[k, v]))
                {
                    GUILayout.Box(GetPreview(prefabs[k, v]), "label", SUI.Width(imgWidth), SUI.Height(imgHeight));
                }
            }
        }
    }

    Texture2D GetPreview(UnityEngine.Object value)
    {
        return AssetPreview.GetAssetPreview(value);
    }

    Texture2D GetThumbnail(UnityEngine.Object value)
    {
        return AssetPreview.GetMiniThumbnail(value);
    }

    Vector3[] GetPoints()
    {
        Vector3[] result = new Vector3[size.x * size.y * size.z];

        // Offset
        Vector3 point = Vector3.zero;
        Vector3 fsize = (Vector3)size;

        int index = 0;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    point.x = x - (fsize.x / 2) + 0.5f;
                    point.y = y - (fsize.y / 2) + 0.5f;
                    point.z = z - (fsize.z / 2) + 0.5f;
                    
                    result[index] = pickPosition + point;

                    index++;
                }
            }
        }

        return result;
    }
}
