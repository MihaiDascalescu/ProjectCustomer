using System;
using UnityEditor;
using UnityEngine;
using Rand = UnityEngine.Random;

public partial class LevelEditor : EditorWindow
{
    //
    // V a r i a b l e s
    //
    
    //GameObject target;
    GameObject[] targets;
    
    //
    // U n i t y
    //

    //
    // U s e r
    //

    GameObject GetFirst()
    {
        if(selected.Count <= 0) { return null; }

        return selected[0];
    }

    GameObject GetObject()
    {
        if(selected.Count == 0) { return null; }

        if(selected.Count == 1) { return selected[0]; }

        int index = Rand.Range(0, selected.Count);

        return selected[index];
    }

    void Create()
    {
        Vector3[] points = GetPoints();

        for(int i = 0; i < points.Length; i++)
        {
            GameObject gameObject = GetObject();

            if(null == gameObject) { return; }

            GameObject go = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;

            go.transform.SetParent(GetRoot());
            go.transform.localPosition = points[i];
            Undo.RegisterCreatedObjectUndo(go, "LeveEditor.CreateObject");
        }
    }

    Transform root;

    Transform GetRoot()
    {
        root = Selection.activeTransform;
        // E x i t
        if (root) { return root; }
        // Create new section
        GameObject newSection = new GameObject("[NewSection]");
        // Get Transform
        root = newSection.transform;
        // Register undo
        Undo.RegisterCreatedObjectUndo(newSection, "Smart.Root.GO.Created");
        // Select transform
        Selection.activeTransform = root;

        return root;
    }
    
    void Delete()
    {
        targets = pick.GetGameObjects(pickPosition, size, layer);

        if(null == targets) { return; }
        
        for(int i = 0; i < targets.Length; i++)
        {
            //if (!IsPrefabAndSelected(targets[i])) { continue; }
            if(null == targets[i]) { continue; }
            Undo.DestroyObjectImmediate(targets[i]);
            //DestroyImmediate(targets[i]);
        }
    }

    //GameObject GetPrefab(GameObject from)
    //{
    //    if(null == from) { return null; }
    //
    //    return PrefabUtility.GetCorrespondingObjectFromOriginalSource(from);
    //}

    //bool IsPrefabAndSelected(GameObject gameObject)
    //{
    //    GameObject prefab = null;
    //
    //    for (int i = 0; i < selected.Count; i++)
    //    {
    //        prefab = GetPrefab(gameObject);
    //        // Continue
    //        if (null == prefab) { continue; }
    //        // Exit TRUE
    //        if (prefab == selected[i]) { return true; }
    //    }
    //    // Exit FALSE
    //    return false;
    //}
}
