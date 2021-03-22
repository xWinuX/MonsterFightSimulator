namespace MonsterFightSimulator.Engine
{
    public interface ILayerItem
    {
        void Update(float deltaTime);
        void Render();
    }
}
