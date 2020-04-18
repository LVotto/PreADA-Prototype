using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InstructionType {
    public const int Void = -1;

    public static Dictionary<int, string> InstructionTypeMaterialMap = new Dictionary<int, string>() {
        { Movement.Straight.Up, "Materials/ArrowUp" },
        { Movement.Straight.Right, "Materials/ArrowRight" },
        { Movement.Straight.Down, "Materials/ArrowDown" },
        { Movement.Straight.Left, "Materials/ArrowLeft" },
    };
    public static class Movement {
        public static class Straight {
            public static int Up = 0;
            public static int Right = 1;
            public static int Down = 2;
            public static int Left = 3;
        }
    }
};

