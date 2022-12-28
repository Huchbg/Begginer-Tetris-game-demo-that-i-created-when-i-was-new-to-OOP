using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace experimenti_s_labeli
{
    internal class Figure
    {
        static Random random = new Random();
        public string shape;
        private bool[,] cords = new bool[10, 20];
        private string color;
        private int state;
        public int[] Axis { 
            get
            {
                bool stop = true;
                int y = 0;
                int x = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (stop == false)
                    {
                        break;
                    }
                    
                    for (int j = 0; j < 10; j++)
                    {
                        if (cords[j, i])
                        {
                            y = i;
                            x = j;
                            stop = false;
                            break;
                        }
                        
                    }
                }
                int[] axis = new int[2];
                axis[0] = x;
                axis[1] = y;
                return axis;
            } 
        }
        public string Color { get { return color; } set { color = value; } }
        public bool[,] Cords
        {
           get =>cords;
            set =>cords = value;
        }
        public int State { get=>state; }
        public void Move()
        {
            bool[,] subCords = new bool[10, 20];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j+1!=10&&i+1!=20)
                    {
                        if (cords[j, i] == true) subCords[j, i + 1] = true;
                    }
                }
            }

            cords = subCords;
        }
        public void MoveR()
        {
            bool[,] subCords = new bool[10, 20];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //cords[j, i] = false;
                    if (j + 1 != 10&&j!=0 && i + 1 != 20&&i!=0)
                    {
                        if (cords[j, i] == true) subCords[j + 1, i] = true;
                    }
                }
            }
            
            cords=subCords;
            
        }
        public void MoveL()
        {
            bool[,] subCords = new bool[10, 20];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j + 1 != 10 && j != 0 && i + 1 != 20 && i != 0)
                    {
                        if (cords[j, i] == true) subCords[j - 1, i] = true;
                    }
                }
            }

            cords = subCords;
        }
        private void Shape()
        {
            int nRabdim = Roll();
            if (nRabdim == 1)
            {
                shape = "S-shape";
                color = "Red";
            }
            else if(nRabdim == 2)
            {
                shape = "Z-shape";
                color = "Green";
            }
            else if (nRabdim == 3)
            {
                shape = "T-shape";
                color = "Blue";
            }
            else if (nRabdim == 4)
            {
                shape = "L-shape";
                color = "Purple";
            }
            else if (nRabdim == 5)
            {
                shape = "Line-shape";
                color = "Yellow";
            }
            else if (nRabdim == 6)
            {
                shape = "MirroredL-shape";
                color = "White";
            }
            else if (nRabdim == 7)
            {
                shape = "Square-shape";
                color = "Orange";
            }
        }
        public void Generate()
        {
            state = 0;
            Shape();
            if (shape == "S-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j==0&&i==5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==1&&i==4|| j == 1 && i == 5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==2&& i == 4)
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape== "Z-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 0 && i == 4)
                        {
                            cords[i, j] = true;
                        }
                        else if (j == 1 && i == 4 || j == 1 && i == 5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j == 2 && i == 5)
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape == "T-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j==0&&i==5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==1&&i==5||j==1&&i==4||j==1&&i==6)
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape == "L-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j==0&&i==4||j==0&&i==5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==1&&i==4)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==2&&i==4)
                        {
                            cords[i, j] = true;

                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape == "Line-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j==0&&(i==3||i==4||i==5||i==6))
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape == "MirroredL-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 0 && i == 4 || j == 0 && i == 5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==1&&i==5)
                        {
                            cords[i, j] = true;
                        }
                        else if (j==2&&i==5)
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
            else if (shape == "Square-shape")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j==0&&(i==4||i==5))
                        {
                            cords[i, j] = true;
                        }
                        else if (j==1&&(i==4||i==5))
                        {
                            cords[i, j] = true;
                        }
                        else
                        {
                            cords[i, j] = false;
                        }
                    }
                }
            }
        }
        public Figure()
        {
            Generate();
        }
        private static int Roll()
        {
            return random.Next(1, 8);
        }

        public void Rotate(int k,int n)
        {
            
            if (shape == "S-shape")
            {
                if (state==0)
                {
                    state++;
                    int y, x;
                    y = Axis[1];
                    x = Axis[0];

                    cords[x, y] = false;
                    cords[x, y+1] = false;
                    cords[x - 1, y + 1] = false;
                    cords[x - 1, y + 2] = false;

                    //if (k == 0) x++;
                    if (k == 1) x--;

                    cords[x, y] = true;
                    cords[x - 1, y] = true;
                    cords[x, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                }
                else if (state == 1)
                {
                    state = 0;
                    int y, x;
                    y = Axis[1];
                    x = Axis[0];

                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 1, y + 1] = false;
                    cords[x + 2, y + 1] = false;

                    x++;
                    if (k==0)
                    {
                        y--; 
                    }
                    
                    cords[x, y] = true;
                    cords[x, y + 1] = true;
                    cords[x - 1, y + 1] = true;
                    cords[x - 1, y + 2] = true;

                }
            }
            else if (shape == "Z-shape")
            {
                if (state==0)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x + 1, y + 1] = false;
                    cords[x + 1, y + 2] = false;

                    if (k==0) x++;


                    cords[x, y] = true;
                    cords[x + 1, y] = true;
                    cords[x, y + 1] = true;
                    cords[x - 1, y + 1] = true;
                }
                else
                {
                    state = 0;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x, y + 1 ] = false;
                    cords[x - 1, y + 1] = false;

                    if (k == 0) y--;

                    cords[x, y] = true;
                    cords[x, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 1, y + 2] = true;
                }
            }
            else if (shape == "T-shape")
            {
                if (state==0)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x,y]=false;
                    cords[x,y + 1] = false;
                    cords[x - 1, y + 1] = false;
                    cords[x + 1, y + 1] = false;

                    if (k==0) y--;
                    if (n == 0) x++;

                    cords[x,y]=true;
                    cords[x,y+1] = true;
                    cords[x,y+2] = true;
                    cords[x + 1, y+1] = true;
                }
                else if (state==1)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x, y + 2] = false;
                    cords[x+1,y+1] = false;

                    if (k == 0) x++;
                    if (n == 0) x--;

                    cords[x, y+1] = true;
                    cords[x - 1, y+1] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x , y + 2] = true;

                }
                else if (state==2)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 2, y] = false;
                    cords[x+1,y+1] = false;

                    if(k==0) y++;
                    if (n == 0) x++; 
                    if(k == 1) x--;

                    cords[x, y] = true;
                    cords[x + 1, y] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 1, y - 1] = true;
                }
                else if (state==3)
                {
                    state = 0;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x-1,y+1] = false;
                    cords[x, y + 2] = false;

                    if (k == 0) x--;

                    cords[x, y] = true;
                    cords[x, y + 1] = true;
                    cords[x - 1, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                }
            }
            else if (shape == "Line-shape")
            {
                if (state == 0)
                {
                    
                    state++;
                    int y, x;
                    y = Axis[1];
                    x = Axis[0]+1;

                    cords[x - 1, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 2, y] = false;
                    cords[x, y] = false;

                    if (k == 0) y -= 3;
                    else if (k == 1) y -= 2;
                    else if (k == 2) y -= 1;

                    if (n == 0) y -= 3;
                    if (n == 1) y -= 2;
                    if (n == 2) y -= 1;


                    if (y == 0) y += 2;
                    else  y += 2;

                    cords[x, y] = true;
                    cords[x, y + 1] = true;
                    cords[x, y - 1] = true;
                    cords[x, y - 2] = true;
                }
                else if (state==1)
                {
                    int y, x;
                    y = Axis[1];
                    x = Axis[0];
                    state = 0;
                   

                    cords[x, y + 1] = false;
                    cords[x, y + 2] = false;
                    cords[x, y + 3] = false;
                    cords[x, y] = false;

                    if (k==0) x += 1;
                    else if(k==2) x -= 2;
                    else if(k==1) x -= 1;
                   

                    cords[x, y] = true;
                    cords[x - 1, y] = true;
                    cords[x + 1, y] = true;
                    cords[x + 2, y] = true;
                    
                }
            }
            else if (shape == "L-shape")
            {
                if (state == 0)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x, y + 1] = false;
                    cords[x, y + 2] = false;

                    if (k == 0) x++;
                    if (k == 1) x--;
                   

                    cords[x, y + 1] = true;
                    cords[x - 1, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 1, y + 2] = true;

                }
                else if (state == 1)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 2, y] = false;
                    cords[x + 2, y + 1] = false;

                    cords[x + 2, y] = true;
                    cords[x + 2, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 2, y - 1] = true;

                }
                else if (state == 2)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x, y + 2] = false;
                    cords[x - 1, y + 2] = false;

                    if (k == 0) x++;

                    cords[x, y + 1] = true;
                    cords[x - 1, y + 1] = true;
                    cords[x - 2, y + 1] = true;
                    cords[x - 2, y] = true;

                }
                else if (state == 3)
                {
                    state = 0;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x + 1, y + 1] = false;
                    cords[x + 2, y + 1] = false;

                    if (k == 0) y--;

                    cords[x + 2, y] = true;
                    cords[x + 1, y] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 1, y + 2] = true;
                }
            }
            else if (shape == "MirroredL-shape")
            {
                if (state==0)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];

                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 1, y + 1] = false;
                    cords[x+1,y+2] = false;

                    if (k == 0) x--;
                    if (k==1) x++;

                    cords[x, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                    cords[x + 2, y + 1] = true;
                    cords[x + 2, y ] = true;
                }
                else if (state==1)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x - 1, y + 1] = false;
                    cords[x - 2, y + 1] = false;

                    if (k == 0) y--;
                    if (n == 0) x++;

                    cords[x - 2, y + 2] = true;
                    cords[x-1,y+2] = true;
                    cords[x - 2, y+1] = true;
                    cords[x - 2, y ] = true;
                }
                else if (state==2)
                {
                    state++;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x, y + 1] = false;
                    cords[x,y+2] = false;
                    cords[x + 1, y + 2] = false;

                    if(k == 0) x++;
                    if(n == 0) y--;

                    cords[x-1,y+1] = true;
                    cords[x-1,y+2]=true;
                    cords[x, y + 1] = true;
                    cords[x + 1, y + 1] = true;
                }
                else if (state==3)
                {
                    state=0;
                    int y, x;
                    x = Axis[0];
                    y = Axis[1];
                    cords[x, y] = false;
                    cords[x + 1, y] = false;
                    cords[x + 2, y] = false;
                    cords[x, y + 1] = false;

                    if(k==0) y--;
                    if (n == 0) x--;

                    cords[x + 1, y - 1] = true;
                    cords[x + 2, y - 1] = true;
                    cords[x + 2, y] = true;
                    cords[x + 2, y + 1] = true;
                }
                
            }
            
        }
    }
}
