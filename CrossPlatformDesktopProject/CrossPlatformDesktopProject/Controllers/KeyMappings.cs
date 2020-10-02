using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class KeyMappings
    {
        private KeyMappings(CrossPlatformDesktopProject.Game1 game, Player player1)
        {
        }

        private static Dictionary<Keys, ButtonKind> defaultKeyMap = new Dictionary<Keys, ButtonKind>()
        {
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
