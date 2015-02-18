using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monopacman
{
    /// <summary>
    /// This is the input class which handles all the input.
    /// </summary>
    public static class Input
    {
        /**
         * Turns the input into correct movement.
         */
        public static Vector2 GetKeyboardInputDirection(PlayerIndex playerIndex)
        {
            Vector2 direction = Vector2.Zero;
            KeyboardState keyboardState = Keyboard.GetState(playerIndex);

            if (playerIndex == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.Left))  direction = new Vector2(-1, 0);
                if (keyboardState.IsKeyDown(Keys.Right)) direction = new Vector2(1, 0);
                if (keyboardState.IsKeyDown(Keys.Up))    direction = new Vector2(0, -1);
                if (keyboardState.IsKeyDown(Keys.Down))  direction = new Vector2(0, 1);
            }

            return direction;
        }
    }
}
