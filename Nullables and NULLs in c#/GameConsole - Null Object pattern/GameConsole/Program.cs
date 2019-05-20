using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter bob = new PlayerCharacter(new DiamondSkinDefence())
            {
                Name = "Bob"
            };

            PlayerCharacter nextLevel = new PlayerCharacter(new IronBonesDefence())
            {
                Name = "nextLevel"
            };

            PlayerCharacter goldie = new PlayerCharacter(SpecialDefence.Null)
            {
                Name ="Goldie"
            };
            
            bob.Hit(10);
            nextLevel.Hit(10);
            goldie.Hit(10);

            Console.ReadLine();
        }
    }
}
