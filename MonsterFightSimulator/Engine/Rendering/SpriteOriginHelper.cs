using MonsterFightSimulator.Engine.Core;

namespace MonsterFightSimulator.Engine.Rendering
{
    public static class OriginHelper
    {
        public enum AxisX
        {
            Left,
            Middle,
            Right
        }

        public enum AxisY
        {
            Top,
            Center,
            Bottom
        }

        public enum Preset
        {
            TopLeft,
            MiddleCenter,
            TopRight
        }

        public static Vector2Int CalculateOrigin(Vector2Int size, Preset preset)
        {
            return preset switch
            {
                Preset.TopLeft => CalculateOrigin(size, AxisX.Left, AxisY.Top),
                Preset.MiddleCenter => CalculateOrigin(size, AxisX.Middle, AxisY.Center),
                Preset.TopRight => CalculateOrigin(size, AxisX.Right, AxisY.Top),
                _ => Vector2Int.Zero
            };
        }

        public static Vector2Int CalculateOrigin(Vector2Int size, AxisX axisX, AxisY axisY)
        {
            Vector2Int origin = Vector2Int.Zero;

            if (axisX == AxisX.Right)  { origin.X = size.X - 1; }
            if (axisX == AxisX.Middle) { origin.X = size.X / 2; }
            if (axisY == AxisY.Bottom) { origin.Y = size.Y - 1; }
            if (axisY == AxisY.Center) { origin.Y = size.Y / 2; }

            return origin;
        }
    }
}