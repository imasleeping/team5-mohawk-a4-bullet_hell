using System;
using System.Numerics;


namespace MohawkGame2D
{
    public class PlayerInput
    {
        void GetPlayerInput()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.Up) || Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                Input.Y -= 1;
            }

        }
    }
}
