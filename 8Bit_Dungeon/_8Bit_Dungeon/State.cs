using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    public enum _8Bit_Dungeon
    {
        Menu,
        InGame,
        InGameMenu,
        Quit,
        Win,
        Lose,
        Settings,
        Credits
    }
    class State
    {
        public _8Bit_Dungeon CurrentGameState;

        public State()
        {
            CurrentGameState = _8Bit_Dungeon.Menu;
        }
    }
}
