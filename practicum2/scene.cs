﻿using System;
using System.Collections.Generic;
using OpenTK;
namespace Template
{
    struct Intersect{
        public float Distance;
        public float Col;
        public Ray originalRay;

    }
    class Scene
    {
        private List<Primitive> entities;
        private List<Light> lightSources;

        public Scene()
        {
            entities = new List<Primitive>();
            entities.Add(new Sphere(new Vector3(0,5,0), 1.5f));
            entities.Add(new Sphere(new Vector3(-2, 3, 0), 1.5f));
            entities.Add(new Sphere(new Vector3(2, 6, 0), 1.5f));
            entities.Add(new Plane(new Vector3(0, 0, -10), 10.0f));
        }

        public float IntersectWithScene(Ray ray)
        {
            float distance = 0;

            foreach (var primitive in entities)
            {
                float dis = primitive.Intersect(ray);
                if (dis > 0)
                {
                    ray.distance = dis;
                    distance = dis;
                }
            }

            return distance;
        }

        public List<Primitive> GetObjects()
        {
            return entities;
        }
    }
}