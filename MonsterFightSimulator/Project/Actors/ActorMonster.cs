using MonsterFightSimulator.Engine;

namespace MonsterFightSimulator.Project.Actors
{
    public class ActorMonster : Actor
    {

        public ActorMonster()
        {
            //_monster = new Monster( _names[Game.Random.Next(0, _names.Length-1)], 
            //    Race.GetRandomFromExisting(Game.Random),
            //    Stats.GetRandom(Game.Random));
        }
        private Monster _monster;


        private string[] _names = new[]
        {
            "Lashonda Freshour",
            "Ned Willaert",
            "Gilma Dorton",
            "Louisa Mcrae",
            "Wm Shinn",
            "Doyle Sly",
            "Lin Mckittrick",
            "Aimee Gathings",
            "Rosendo Conforti",
            "Claud Serfass",
            "Arlinda Mooney",
            "Cherry Litwin",
            "Melonie Appleby",
            "Salvador Aguon",
            "Colette Pylant",
            "Eleni Coppedge",
            "Mitchell Debus",
            "Heath Tang",
            "Ambrose Dungan",
            "Wai Kowal",
            "Hayden Midgette",
            "Annabell Holstein",
            "Narcisa Marconi",
            "Cherie Clow",
            "Josephina Hoar",
            "Carlee Stafford",
            "Viva Tinkler",
            "Veronika Keitt",
            "Annalisa Bottorff",
            "Carmela Bouie"
        };


        public override void Render()
        {
            RenderStringAt(Transform.Position, StringToTexture(_monster.Name));
        }
    }
}