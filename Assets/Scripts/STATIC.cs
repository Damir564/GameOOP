using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STATIC
{
    public enum ResourceType
    {
        Iron = 0,
        Coal = 1,
        Wood = 2,
        Oil = 3
    }
    public struct Resource
    {
        public GameObject Obj;
        public Vector3 Coord;
        public Vector3[] PointsForRobot;
        public int ResourcesCount;
        public ResourceType Type;
    }
    public static Resource[] Resources = new Resource[64];

    public static bool IsMusicOn = true;
    public static int CurrentMusic = -1;
}
