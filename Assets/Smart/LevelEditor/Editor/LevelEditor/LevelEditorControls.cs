using UnityEditor;
using UnityEngine;
using System;

public partial class LevelEditor : EditorWindow
{
    void ControlActive()
    {
        if (KeyUp(KeyCode.Escape))
        {
            active = !active;

            Repaint();
        }
    }

    void ControlMode()
    {
        if (KeyDown(KeyCode.C))
        {
            Tools.current = Tool.None;

            Array vals = Enum.GetValues(typeof(Mode));

            int current = (int)mode;

            bool greater = (current + 1) > (vals.Length - 1);

            current = greater ? 0 : current + 1;

            mode = (Mode)current;

            Repaint();
        }
    }

    void ControlPaint()
    {
        if (KeyDown(KeyCode.B))
        {
            switch (paint)
            {
                case Paint.Brush:
                    paint = Paint.Single;
                    break;
                case Paint.Single:
                    paint = Paint.Brush;
                    break;
            }

            Repaint();
        }
    }

    void ControlHeight()
    {
        if(KeyDown(KeyCode.Plus) || KeyDown(KeyCode.Equals))
        {
            height += size.y;

            Repaint();
        }

        if(KeyDown(KeyCode.Minus))
        {
            height -= size.y;

            Repaint();
        }
    }

    void ControlTools()
    {
        // Exit
        if(tool == Tools.current)
        {
            return;
        }

        switch(Tools.current)
        {
            case Tool.Move:
                if(mode == Mode.Move) { return; }
                mode = Mode.Move;
                break;
            case Tool.Rotate:
                if (mode == Mode.Rotate) { return; }
                mode = Mode.Rotate;
                break;
            case Tool.Scale:
                if (mode == Mode.Scale) { return; }
                mode = Mode.Scale;
                break;
        }

        tool = Tools.current;
    }
}
