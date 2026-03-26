// Include the namespaces (code libraries) you need below.
using MohawkGame2D;
using System;
using System.Drawing;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Player
    {
        // Place your variables here:

        Vector2 position;
        Vector2 size;
        Vector2 point;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // compute side of player
            float playerLeftEdge = position.X;            // left edge
            float playerRightEdge = position.X + size.X;  // right edge
            float playerTopEdge = position.Y;             // top edge
            float playerBottomEdge = position.Y + size.Y; // bottom edge

            bool isLeftOfWindow = playerLeftEdge <= 0;             // left check
            bool isRightOfWindow = playerRightEdge >= Window.Width;  // right check
            bool isAboveWindow = playerTopEdge <= 0;             // top check
            bool isBelowWindow = playerBottomEdge >= Window.Height; // bottom check

            bool isWithinX = point.X > playerLeftEdge && point.X < playerRightEdge;
            bool isWithinY = point.Y > playerTopEdge && point.Y < playerBottomEdge;

            bool isWithinRectangle = isWithinX && isWithinY;

            if (isWithinRectangle == true)
            {

            }

        }
        public void GetPlayerInput()
        {

            Vector2 input = Vector2.Zero;

            // UP
            if (Input.IsKeyboardKeyDown(KeyboardInput.Up) || Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                input.Y -= 1;
            }

            // DOWN
            if (Input.IsKeyboardKeyDown(KeyboardInput.Down) || Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                input.Y += 1;
            }

            // LEFT
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left) || Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                input.X -= 1;
            }

            // RIGHT
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) || Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                input.X += 1;
            }

        }
    }

}
