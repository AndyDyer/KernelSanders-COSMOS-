using Cosmos.HAL;
using Sys = Cosmos.System;

namespace Display
{
    public class DisplayDriver
    {

        protected VGAScreen screen;
        private int width, height, mouseX, mouseY;
        public static Mouse m;



        public DisplayDriver()
        {
            screen = new VGAScreen();
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            m = new Mouse();
            m.X = 0;
            m.Y = 0;
            m.Initialize(320,200);
    

            width = screen.PixelWidth;
            height = screen.PixelHeight;
            screen.Clear(0);

            DrawFilledRectangle(0, 0, width, height, 7);
            mouseX = m.X;
            mouseY = m.Y;
            screen.SetPixel((uint)m.X, (uint)m.Y, 40);
            screen.SetPixel((uint)m.X + 1, (uint)m.Y, 40);
            screen.SetPixel((uint)m.X + 2, (uint)m.Y, 40);
            screen.SetPixel((uint)m.X, (uint)m.Y + 1, 40);
            screen.SetPixel((uint)m.X, (uint)m.Y + 2, 40);
            screen.SetPixel((uint)m.X + 1, (uint)m.Y + 1, 40);
            screen.SetPixel((uint)m.X + 2, (uint)m.Y + 2, 40);
            screen.SetPixel((uint)m.X + 3, (uint)m.Y + 3, 40);

        }

        public void init()
        {
            int counter = 0;
            if (m.Buttons == Mouse.MouseState.None)
            {
                if (mouseX != m.X || mouseY != m.Y)
                {
                    screen.SetPixel((uint)mouseX, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX + 1, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX + 2, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX, (uint)mouseY + 1, 7);
                    screen.SetPixel((uint)mouseX, (uint)mouseY + 2, 7);
                    screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 1, 7);
                    screen.SetPixel((uint)mouseX + 2, (uint)mouseY + 2, 7);
                    screen.SetPixel((uint)mouseX + 3, (uint)mouseY + 3, 7);

                    mouseX = m.X;
                    mouseY = m.Y;
                }
                screen.SetPixel((uint)mouseX, (uint)mouseY, 40);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY, 40);
                screen.SetPixel((uint)mouseX + 2, (uint)mouseY, 40);
                screen.SetPixel((uint)mouseX, (uint)mouseY + 1, 40);
                screen.SetPixel((uint)mouseX, (uint)mouseY + 2, 40);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 1, 40);
                screen.SetPixel((uint)mouseX + 2, (uint)mouseY + 2, 40);
                screen.SetPixel((uint)mouseX + 3, (uint)mouseY + 3, 40);
                counter = 0;
            }
            if (m.Buttons == Mouse.MouseState.Left)
            {
                mouseX = m.X;
                mouseY = m.Y;
                if (counter == 0)
                {
                    screen.SetPixel((uint)mouseX, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX + 1, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX + 2, (uint)mouseY, 7);
                    screen.SetPixel((uint)mouseX, (uint)mouseY + 1, 7);
                    screen.SetPixel((uint)mouseX, (uint)mouseY + 2, 7);
                    screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 1, 7);
                    screen.SetPixel((uint)mouseX + 2, (uint)mouseY + 2, 7);
                    screen.SetPixel((uint)mouseX + 3, (uint)mouseY + 3, 7);
                    counter++;
                }
               

          
           
                screen.SetPixel((uint)mouseX + 2, (uint)mouseY + 2, 25);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 1, 25);
                screen.SetPixel((uint)mouseX , (uint)mouseY, 25);
                screen.SetPixel((uint)mouseX + 2, (uint)mouseY + 1, 25);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY, 25);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 2, 25);
                screen.SetPixel((uint)mouseX, (uint)mouseY + 2, 25);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY + 2, 25);
                screen.SetPixel((uint)mouseX + 1, (uint)mouseY, 25);
                screen.SetPixel((uint)mouseX, (uint)mouseY + 1, 25);
            }
            if (m.Buttons == Mouse.MouseState.Right)
            {
                DrawFilledRectangle(0, 0, width, height, 7);
            }


        }
        public virtual void setPixel(int x, int y, int c)
        {
            if (screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c)
                setPixelRaw(x, y, c);
        }

        public virtual byte getPixel(int x, int y)
        {
            return (byte)screen.GetPixel320x200x8((uint)x, (uint)y);
        }

        public virtual void clear()
        {
            clear(0);
        }

        public virtual void clear(int c)
        {
            screen.Clear(c);
        }

        public virtual void step() { }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setPixelRaw(int x, int y, int c)
        {
            screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);
        }

        public void DrawFilledRectangle(uint x0, uint y0, int Width, int Height, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint h = 0; h < Height; h++)
                {
                    setPixel((int)(x0 + i), (int)(y0 + h), color);
                }
            }
        }
    }
}