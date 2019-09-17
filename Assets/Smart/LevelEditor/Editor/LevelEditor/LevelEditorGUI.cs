using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    string areaStyle = "DD HeaderStyle";
    string titleSyle = "boldLabel";
    float imgWidth = 80;
    float imgHeight = 80;

    void OnDrawGUI()
    {
        DrawMenuGUI();
        DrawSelectedGUI();
        DrawObjectsGUI();
    }

    void DrawMenuGUI()
    {
        SUI.Label("Menu", titleSyle);

        SUI.Vertical(areaStyle, DrawMenuGUIFields);
    }

    void DrawMenuGUIFields()
    {
        // Label
        GUILayout.Label("Main", "boldlabel");
        // Active
        SUI.Field("Edit (ESC)", () => active = SUI.Toggle(active));
        // Mode
        SUI.Field("Mode (C)", () => mode = (Mode)SUI.EnumField(mode, "label"));
        // Paint
        SUI.Field("Paint (B)", () => paint = (Paint)SUI.EnumField(paint, "label"));
        // Layer
        SUI.Field("Layer", () => layer = SUI.LayerField(layer, "label"));
        // Height
        SUI.Field("Height (+/-)", () => height = EditorGUILayout.FloatField(height));
        // Size
        SUI.Field("Size", () => size = Vector3Int.RoundToInt(SUI.VectorCustom(size)));

        // Label
        GUILayout.Label("Snap", "boldlabel");
        // Move
        SUI.Field("Move", () => move = SUI.VectorCustom(move));
        // Rotate
        SUI.Field("Rotate", () => rotate = SUI.VectorCustom(rotate));
        // Scale
        SUI.Field("Scale", () => scale = SUI.VectorCustom(scale));
    }

    void DrawSelectedGUI()
    {
        SUI.Label("Selected", titleSyle);

        SUI.Horizontal(areaStyle, DrawSelectedGUIContents, SUI.ExpandWidth);
    }

    void DrawSelectedGUIContents()
    {
        if (selected.Count == 0)
        {
            GUILayout.Box(GUIContent.none, SUI.Width(imgWidth), SUI.Height(imgHeight));
        }
        else
        {
            DrawSelectedPreview();
        }
    }

    void DrawSearchBar()
    {
        SUI.Horizontal(DrawSearchBarField);
    }

    void DrawSearchBarField()
    {
        filter = GUILayout.TextField(filter, "SearchTextField");
        SUI.Button("", "SearchCancelButton", () => filter = "");
    }

    void DrawObjectsGUI()
    {
        SUI.Label("Objects", titleSyle);

        SUI.Vertical(areaStyle, () =>
        {
            DrawSearchBar();

            SUI.Space(SUI.VerticalSpace);

            objsViewPos = SUI.ScrollView(objsViewPos, DrawKeylistAndValues, SUI.DontExpandHeight);
        });
    }

    void DrawKeylistAndValues()
    {
        string text = "";
        string name = "";
        Texture2D texture = null;

        for (int k = 0; k < prefabs.KeyCount; k++)
        {
            SUI.Horizontal(() =>
            {
                SUI.Toggle(isExpanded[k], GUIContent.none, "ol toggle", SUI.DontExpandWidth);
                isExpanded[k] = SUI.Toggle(isExpanded[k], prefabs.Keys[k], "exposablepopupmenu");
            });

            if (false == isExpanded[k]) { continue; }

            DrawKeys(k, text, name, texture);
        }
    }

    void DrawKeys(int k, string text, string name, Texture texture)
    {
        for (int v = 0; v < prefabs.Values[k].Count; v++)
        {
            // Name to lower
            name = prefabs[k, v].name.ToLower();
            // FILTER
            if (!name.Contains(filter.ToLower())) { continue; }

            DrawValues(k, v, text, name, texture);
        }
    }

    void DrawValues(int k, int v, string text, string name, Texture texture)
    {
        // Space
        SUI.Space(SUI.VerticalSpace);

        bool isSelected = selected.Contains(prefabs[k, v]);

        // Horizontal
        SUI.Horizontal(() =>
        {
            texture = GetThumbnail(prefabs[k, v]);

            GUILayout.Box(texture, "Label", SUI.Width(SUI.LineHeight), SUI.Height(SUI.LineHeight));

            text = string.Format("{0} - {1}", v, prefabs[k, v].name);

            if (isSelected)
            {
                RemoveButton(text, prefabs[k, v]);
            }
            else
            {
                AddButton(text, prefabs[k, v]);
            }
        });
    }

    GUIStyle FindStyle(string style)
    {
        return GUI.skin.FindStyle(style);
    }

    void RemoveButton(string text, GameObject gameObject)
    {
        SUI.Button(text, "assetlabel", () =>
        {
            selected.Remove(gameObject);

            view.Repaint();

            Repaint();

        }, SUI.ExpandWidth);
    }

    void AddButton(string text, GameObject gameObject)
    {
        SUI.Button(text, "Label", () =>
        {
            selected.Add(gameObject);

            view.Repaint();

            Repaint();
        });
    }
}
