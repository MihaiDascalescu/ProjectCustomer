﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public partial class LevelEditor : EditorWindow
{
    public class Pick
    {
        //
        // Variables
        //

        private float distance;
        private float height;
        private Vector3 mouse;
        private Plane plane;
        private Bounds bounds;
        private Transform[] transforms;
        private List<GameObject> gameObjects;

        private Ray ray;
        private RaycastHit rayInfo;

        public Event e;
        public Camera camera;
        
        //
        // Properties
        //

        public bool Hit
        { get; protected set; }

        public GameObject Target
        { get; protected set; }

        public Vector3 Position
        { get; protected set; }

        public Vector3 Point
        { get; protected set; }

        public Vector3 TargetPosition
        {
            get { return Target.transform.position; }
        }

        //
        // Methods
        //

        public void Set(float height, Event e, Camera camera)
        {
            this.height = height;
            this.e = e;
            this.camera = camera;
        }

        
        public void UpdateRay()
        {
            mouse = e.mousePosition;

            mouse.y = camera.pixelHeight - mouse.y;

            ray = camera.ScreenPointToRay(mouse);
        }

        public void UpdatePosition()
        {
            plane = new Plane(Vector3.up, new Vector3(0, height, 0));

            plane.Raycast(ray, out distance);

            Position = ray.GetPoint(distance);
        }

        public void UpdateCast()
        {
            Hit = Physics.Raycast(ray, out rayInfo);
            
            Point = rayInfo.point;

            Target = rayInfo.collider ? rayInfo.collider.gameObject : null;
        }

        public void Update()
        {
            UpdateRay();
            UpdatePosition();
            UpdateCast();
        }

        public void GetGameObject(LayerMask layer)
        {
            Target = HandleUtility.PickGameObject(e.mousePosition, true);

            if(!WorkingLayers(Target, layer))
            {
                Target = null;
            }
        }

        public bool Overlap(Vector3 center, Vector3 size, LayerMask layer)
        {
            transforms = FindObjectsOfType<Transform>();

            bounds = new Bounds(center, size);

            for (int i = 0; i < transforms.Length; i++)
            {
                if (!WorkingLayers(transforms[i].gameObject, layer))
                {
                    continue;
                }

                if (bounds.Contains(transforms[i].position)) { return true; }
            }

            return false;
        }

        public GameObject[] GetGameObjects(Vector3 center, Vector3 size, LayerMask layer)
        {
            gameObjects = new List<GameObject>();

            transforms = FindObjectsOfType<Transform>();

            bounds = new Bounds(center, size);
            
            for (int i = 0; i < transforms.Length; i++)
            {
                if (!WorkingLayers(transforms[i].gameObject, layer))
                {
                    continue;
                }

                if(bounds.Contains(transforms[i].position))
                {
                    gameObjects.Add(transforms[i].gameObject);
                }
            }

            return gameObjects.ToArray();
        }

        bool WorkingLayers(GameObject gameObject, LayerMask layer)
        {
            return layer == (layer | (1 << gameObject.layer));
        }
    }
}
