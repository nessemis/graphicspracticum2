﻿using System;
using System.Collections.Generic;
using OpenTK;
namespace Template
{
    class Intersect{
        public int Col;
        public Ray OriginalRay;

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

        public void IntersectWithScene(Intersect intersect)
        {
            foreach (var primitive in entities)
            {
                float dis = primitive.Intersect(intersect.OriginalRay);
                if (dis > 0)
                {
                    intersect.OriginalRay.distance = dis;
                }
            }
            float t = intersect.OriginalRay.distance;
            intersect.Col = ((int)((1 / (t * t) * 255)) << 16) + ((int)((1 / (t * t) * 255)) << 8);

        }

        public List<Primitive> GetObjects()
        {
            return entities;
        }
    }
}