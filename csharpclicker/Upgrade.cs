namespace Csharpclicker
{
    class Upgrade
    {
        readonly int Cost;
        readonly BuildingType Type;
        readonly string Description;

        Upgrade(int cost, BuildingType type, string description)
        {
            Cost = cost;
            Type = type;
            Description = description;
        }


    }
}
