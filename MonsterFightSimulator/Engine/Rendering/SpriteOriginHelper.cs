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

            origin.X = axisX switch
            {
                AxisX.Right  => size.X - 1,
                AxisX.Middle => size.X / 2,
                _            => origin.X
            };
            
            origin.Y = axisY switch
            {
                AxisY.Bottom => size.Y - 1,
                AxisY.Center => size.Y / 2,
                _            => origin.Y
            };

            return origin;
        }
    }
}