using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTD
{
    class Village
    {
        private Shop shop;
        private enum Options {Rest , Shop , Leave , Error};
        public Village() 
        {
            shop = new Shop();
        }
        public Player RestPlayer(Player player) 
        {
            player.HealPlayer();
            player.RestoreMana();
            return player;
        }
        public Player Stay(Player player) 
        {
            bool StayInVillage = true;
            Console.WriteLine("Welcome to Shulman");
            Options option;
            do
            {
                Console.WriteLine("Que decides?");
                Console.WriteLine("Rest = 0 - Shop = 1 , Leave = 2");
                int imput = Convert.ToInt32(Console.ReadLine());
                if (imput >= 0 && imput < (int)Options.Error)
                {
                    option = (Options)imput;
                }
                else
                {
                    option = Options.Error;
                }
                switch (option)
                {
                    case Options.Rest:
                        player = RestPlayer(player);
                        break;
                    case Options.Shop:
                        break;
                    case Options.Leave:
                        StayInVillage = false;
                        break;
                    default:
                        break;
                }
            } while (StayInVillage);
            return player;
        }
    }
}
