using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    private Vector3 pickPosition = Vector3.zero;
    private Vector3 labelMouseOffset = new Vector3(0f, 0.5f, 0f);
    private Vector3 labelObjectOffset = new Vector3(0, -1, 0);
    private Pick pick = new Pick();
    private MeshDraw meshDraw = new MeshDraw();
    private Transform[] transforms = null;

    void EditUpdate()
    {
        // Prepare to pick
        pick.Set(height, e, view.camera);

        switch (mode)
        {
            case Mode.Create:
                EditModeCreate();
                break;
            case Mode.Delete:
                EditModeDelete();
                break;
            case Mode.Move:
                EditModeMove();
                break;
            case Mode.Rotate:
                EditModeRotate();
                break;
            case Mode.Scale:
                EditModeScale();
                break;
        }

        // Label
        SceneLabel(pickPosition + labelMouseOffset, "{0} : {1}", mode, paint);
        // Repain
        view.Repaint();
    }

    //
    // Edit Create
    //

    void EditModeCreate()
    {
        Tools.current = Tool.None;
        // Don't allow selection
        PassiveControls();
        // Pick update
        pick.Update();
        // Get position
        pickPosition = pick.Position;

        switch(paint)
        {
            case Paint.Brush:
                EditModeCreateBrush();
                break;
            case Paint.Single:
                EditModeCreateSingle();
                break;
        }
    }

    void EditModeCreateSingle()
    {
        // Snap if we didn't hit other objects
        pickPosition = pick.Hit ? Snap(pick.Point, move) : Snap(pickPosition, move);
        // Prepare mesh draw
        meshDraw.Set(GetFirst());
        // Draw mesh
        meshDraw.Draw(GetPoints());
        // Wire cube
        DrawBrush(pickPosition, Color.green);
        // Left click event
        LeftClick(Create);
    }

    void EditModeCreateBrush()
    {
        // Snap when we are brush painting
        pickPosition = Snap(pickPosition, move);
        // Prepare mesh draw
        meshDraw.Set(GetFirst());
        // Draw mesh
        meshDraw.Draw(GetPoints());
        // Wire cube
        DrawBrush(pickPosition, Color.green);
        // Exit
        if (pick.Overlap(pickPosition, size, layer)) { return; }
        // Left click event
        LeftClick(Create);
    }

    //
    // Delete
    //

    void EditModeDelete()
    {
        Tools.current = Tool.None;
        // Don't allow selection
        PassiveControls();
        // Raycast
        pick.Update();
        // Get position
        pickPosition = Snap(pick.Position, move);

        switch (paint)
        {
            case Paint.Brush:
                EditModeDeleteBrush();
                break;
            case Paint.Single:
                EditModeDeleteSingle();
                break;
        }
    }

    void EditModeDeleteSingle()
    {
        if (e.type == EventType.Used)
        {
            // Get GameObject
            pick.GetGameObject(layer);
        }

        if (pick.Target)
        {
            // hit target
            pickPosition = pick.TargetPosition;
        }

        // Wire cube
        DrawBrush(pickPosition, Color.red);

        LeftClick(Delete);
    }

    void EditModeDeleteBrush()
    {
        // Wire cube
        DrawBrush(pickPosition, Color.red);

        LeftClick(Delete);
    }

    //
    // Position
    //

    void EditModeMove()
    {
        Tools.current = Tool.Move;

        //transforms = Selection.transforms;

        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].hasChanged)
            {
                Undo.RecordObject(transforms[i], "sle.move");

                transforms[i].localPosition = Snap(transforms[i].localPosition, move);

                transforms[i].hasChanged = false;
            }

            SceneLabel(transforms[i].position + labelObjectOffset, transforms[i].localPosition.ToString());
        }

        pick.UpdateRay();
        // Update position
        pick.UpdatePosition();
        // Get position
        pickPosition = pick.Position;
    }

    //
    // Rotation
    //

    void EditModeRotate()
    {
        Tools.current = Tool.Rotate;
        
        //transforms = Selection.transforms;

        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].hasChanged)
            {
                Undo.RecordObject(transforms[i], "sle.rotate");

                transforms[i].localEulerAngles = Snap(transforms[i].localEulerAngles, rotate);

                transforms[i].hasChanged = false;
            }

            SceneLabel(transforms[i].position + labelObjectOffset, transforms[i].eulerAngles.ToString());
        }

        pick.UpdateRay();
        // Update position
        pick.UpdatePosition();
        // Get position
        pickPosition = pick.Position;
    }

    //
    // Scale
    //

    void EditModeScale()
    {
        Tools.current = Tool.Scale;

        //transforms = Selection.transforms;

        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].hasChanged)
            {
                Undo.RecordObject(transforms[i], "sle.scale");

                transforms[i].localScale = Snap(transforms[i].localScale, scale);

                transforms[i].hasChanged = false;
            }

            SceneLabel(transforms[i].position + labelObjectOffset, transforms[i].localScale.ToString());
        }

        pick.UpdateRay();
        // Update position
        pick.UpdatePosition();
        // Get position
        pickPosition = pick.Position;
    }
}
