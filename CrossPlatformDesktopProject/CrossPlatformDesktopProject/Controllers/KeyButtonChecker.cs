using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class KeyButtonChecker : IButtonChecker
    {
        private static KeyButtonChecker instance = null;

        public static IButtonChecker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyButtonChecker();
                }
                return instance;
            }
        }

        private KeyButtonChecker()
        {
        }

        private static Dictionary<Keys, ButtonKind> keyMapping = new Dictionary<Keys, ButtonKind>(){
           [Keys.W] = ButtonKind.UP,
           [Keys.A] = ButtonKind.LEFT,
           [Keys.S] = ButtonKind.DOWN,
           [Keys.D] = ButtonKind.RIGHT,

           [Keys.Up] = ButtonKind.UP,
           [Keys.Down] = ButtonKind.DOWN,
           [Keys.Right] = ButtonKind.RIGHT,
           [Keys.Left] = ButtonKind.LEFT,

           [Keys.Space] = ButtonKind.PRIMARY,
           [Keys.E] = ButtonKind.SECONDARY,

           [Keys.RightShift] = ButtonKind.SELECT,
           [Keys.Enter] = ButtonKind.START,
        };

        ISet<ButtonKind> IButtonChecker.GetPressedButtons()
        {
            ISet<ButtonKind> buttons = new HashSet<ButtonKind>();
            KeyboardState state = Keyboard.GetState();
            foreach (KeyValuePair<Keys, ButtonKind> pair in keyMapping)
            {
                if (state.IsKeyDown(pair.Key))
                {
                    buttons.Add(pair.Value);
                }
            }
            return buttons;
        }
    }
}
