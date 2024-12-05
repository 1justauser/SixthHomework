using SixthHomework.Classes;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

namespace SixthHomework
{
    abstract class Casino
    { 
        #region Fields
        private string casinoName = "Default Casino";
        private User user;
        private int gamesAmount = 1;
        private bool IsUserMinor = true;
        private int restrictionAge = 0;
        #endregion
        #region Constructor Methods

        #endregion
        #region Call Methods
        public void Output()
        {
            Console.WriteLine($"Здравствуйте {user.Name}");
            IsUserMinor = user.IsUserMinor(restrictionAge);
            if (IsUserMinor)
            {
                Console.WriteLine("Вы несовершеннолетни");
            }
            else
            {
                Console.WriteLine("Предлагаем вам сыграть в одну из наших игр");
                Help();
                Console.WriteLine($"Укажите номер игры от 1 до {gamesAmount}, либо что-то другое если не хотите играть");
                bool flag = true;
                while(flag && int.TryParse(Console.ReadLine(),out int gameNumber))
                {
                    if(gameNumber == 1)
                    {

                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
        }
        private void Help()
        {
            Console.WriteLine("1) Игра 50% удвой деньги");
        }
        private void DoubleMoney()
        {
            if (user.Balance <= 0)
            {
                Console.WriteLine("Недостаточно средств");
            }
            Console.WriteLine($"У вас {user.Balance}");
            Console.WriteLine("");
        }
        #endregion
    }
}
