using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace experimenti_s_labeli
{
    public partial class Tetris : Form
    {
        private bool[,] cordSystem = new bool[10, 20];
        private string[,] colorSystem = new string[10, 20];
        Figure figure;
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        readonly int y = 20;
        readonly int x = 10;
        readonly Label[,] labels = new Label[10, 20];
        private bool yes;
        private bool[] corR = new bool[20];
        private string lastMove;
        private bool no;
        private bool[] corL = new bool[20];
        private bool[] corU = new bool[10];
        private bool[] corD = new bool[10];
        int score = 0;
        int maxScore = 0;
        bool gameStop;
        bool start = true;
        bool up;
        bool down;
        bool stateChanger;
        bool firstStart=true;
        public Tetris()
        {
            InitializeComponent();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveDow();
        }

        /// <summary>
        /// This creates the board where the game is played
        /// </summary>
        private void BuildLabels()
        {

            int myLocationy = 30;
            int myLocationx = 30;
            for (int i = 0; i < y; i++)
            {

                for (int j = 0; j < x; j++)
                {
                    labels[j, i] = new Label
                    {
                        Location = new Point(myLocationx, myLocationy),
                        Size = new Size(30, 30),
                        BorderStyle = BorderStyle.None

                    };
                    myLocationx += 30;
                    this.Controls.Add(labels[j, i]);
                    labels[j, i].BackColor = Color.Black;
                }
                myLocationx = 30;
                myLocationy += 30;

            }
        }

        /// <summary>
        /// this refreshes the board wvery move
        /// </summary>
        private void ShowGame()
        {
            Scorelbl.Text = $"Score = {score}";

            if (lastMove == "Colapse")
            {
                for (int i = 0; i < 20; i++)
                {
                    if (corR[i]) corR[i] = false;
                    if (corL[i]) corL[i] = false;

                }
            }

            //These four are backup checkers for the top roll ,the last roll ,the left-most colomn and the right-most column respectively
            //I created these backup checkers because there was some bug that i have not figured out  so far .
            if (up)
            {
                bool con = true;
                if (stateChanger)
                {
                    con = false;
                }

                if (con)
                {
                    if (lastMove == "Left")
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i != 0)
                            {
                                if (corU[i]) figure.Cords[i - 1, 0] = true;
                            }
                            corU[i] = false;
                        }
                    }
                    else if (lastMove == "Right")
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i + 1 != 10)
                            {
                                if (corU[i]) figure.Cords[i + 1, 0] = true;
                            }
                            corU[i] = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++) corU[i] = false;
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++) corU[i] = false;
                }
                
            }
            if (down)
            {
                bool con =true;
                if (stateChanger)
                {
                    con = false;
                }

                if (con)
                {
                    if (lastMove == "Left")
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i != 0)
                            {
                                if (corD[i]) figure.Cords[i - 1, 19] = true;
                            }
                            corD[i] = false;
                        }
                    }
                    else if (lastMove == "Right")
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i + 1 != 10)
                            {
                                if (corD[i]) figure.Cords[i + 1, 19] = true;
                            }
                            corD[i] = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++) corD[i] = false;
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++) corD[i] = false;
                }
                
            }
            if (yes)
            {
                if (lastMove == "Left")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (corR[i])
                        {
                            figure.Cords[8, i] = true;
                            corR[i] = false;
                        }
                    }
                    yes = false;
                }
                else
                {
                    bool con = true;
                    if (stateChanger && figure.shape == "Line-shape" && figure.State == 1)
                    {
                        stateChanger = false;
                        con = false;
                    }
                    if (stateChanger&&figure.shape== "S-shape"&&figure.State==0)
                    {
                        stateChanger = false;
                        con = false;
                    }
                    if (stateChanger&&figure.shape== "MirroredL-shape"&&figure.State==2)
                    {
                        stateChanger = false;
                        con = false;
                    }
                    if (stateChanger&&figure.shape== "T-shape"&& figure.State ==1)
                    {
                        stateChanger = false;
                        con = false;
                    }
                    if (stateChanger && figure.shape == "T-shape"&& figure.State ==3)
                    {
                        stateChanger = false;
                        con = false;
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        if (figure.Cords[9, i]) con = false;
                    }
                    if (con)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if (i + 1 != 20)
                            {
                                if (corR[i])
                                {
                                    figure.Cords[9, i + 1] = true;
                                    corR[i] = false;
                                }
                            }

                        }

                    }
                    else
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if (i + 1 != 20) corR[i] = false;
                        }
                    }
                    yes = false;
                }
            }
            if (no)
            {
                if (lastMove == "Right")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        //Debug.WriteLine(corL[i]);
                        if (corL[i]) figure.Cords[1, i] = true;
                        corL[i] = false;
                    }

                    no = false;
                }
                else
                {
                    for (int i = 0; i < 20; i++) corL[i] = false;

                    no = false;
                }
            }

            
            if (stateChanger) stateChanger = false;

            //Show
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (figure.Cords[j, i]|| cordSystem[j, i])
                    {
                        if (figure.Cords[j, i])
                        {
                            if (figure.Color == "Blue")
                            {
                                labels[j, i].BackColor = Color.Blue;
                            }
                            else if (figure.Color == "Green")
                            {
                                labels[j, i].BackColor = Color.Green;
                            }
                            else if (figure.Color == "Red")
                            {
                                labels[j, i].BackColor = Color.Red;
                            }
                            else if (figure.Color == "Purple")
                            {
                                labels[j, i].BackColor = Color.Purple;
                            }
                            else if (figure.Color == "Yellow")
                            {
                                labels[j, i].BackColor = Color.Yellow;
                            }
                            else if (figure.Color == "White")
                            {
                                labels[j, i].BackColor = Color.White;
                            }
                            else if (figure.Color == "Orange")
                            {
                                labels[j, i].BackColor = Color.Orange;
                            }
                        }
                        if (cordSystem[j, i] == true)
                        {
                            switch (colorSystem[j, i])
                            {
                                case "Blue":
                                    labels[j, i].BackColor = Color.Blue;
                                    break;
                                case "Red":
                                    labels[j, i].BackColor = Color.Red;
                                    break;
                                case "Purple":
                                    labels[j, i].BackColor = Color.Purple;
                                    break;
                                case "Yellow":
                                    labels[j, i].BackColor = Color.Yellow;
                                    break;
                                case "White":
                                    labels[j, i].BackColor = Color.White;
                                    break;
                                case "Orange":
                                    labels[j, i].BackColor = Color.Orange;
                                    break;
                                case "Green":
                                    labels[j, i].BackColor = Color.Green;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        labels[j, i].BackColor = Color.Black;
                    }

                }
            }

            //Checks for MostLeft and MostRight
            for (int i = 0; i < 20; i++)
            {
                if (figure.Cords[9, i])
                {
                    yes = true;
                    corR[i] = true;
                }
                if (figure.Cords[0, i])
                {
                    no = true;
                    corL[i] = true;
                }
            }

            //Checks for Up and Down
            for (int i = 0; i < 10; i++)
            {
                if (figure.Cords[i, 0])
                {
                    corU[i] = true;
                    up = true;
                }
                if (figure.Cords[i, 19])
                {
                    corD[i] = true;
                    down = true;
                }
            }

            stateChanger = false;
        }
        private void Clear()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                    labels[j, i].BackColor = Color.Black;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BuildLabels();
            figure = new Figure();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;

            StreamReader sr = new StreamReader("MaxScore.text");
            maxScore = int.Parse(sr.ReadLine());
            Debug.WriteLine("Tova e maxScore" + maxScore);
            maxScorelbl.Text = $"MaxScore = {maxScore} ";
            Scorelbl.Text = $"Score = {score}";
        }
        private void MoveDown_Click(object sender, EventArgs e)
        {
            MoveDow();
        }
        private void MoveRight_Click(object sender, EventArgs e)
        {
            MoveRig();
        }
        private void MoveLeft_Click(object sender, EventArgs e)
        {
            MoveLef();
        }
        private void MoveDow()
        {

            bool toContinue = true;
            for (int i = 0; i < 10; i++)
            {
                if (figure.Cords[i, 19] == true) toContinue = false;
            }
            for (int i = 0; i < 20; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    if (i + 1 != 20)
                    {
                        if (cordSystem[j, i + 1] && figure.Cords[j, i])
                            toContinue = false;
                    }
                }
            }
            if (toContinue)
            {
                lastMove = "MoveDown";
                //Clear();
                figure.Move();
                ShowGame();
            }
            else
            {
                lastMove = "Colapse";

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {

                        if (j + 1 != 10 && i + 1 != 20)
                        {
                            if (figure.Cords[j, i] == true)
                            {
                                cordSystem[j, i] = true;
                                colorSystem[j, i] = figure.Color;
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (figure.Cords[i, 19] == true)
                    {
                        cordSystem[i, 19] = true;
                        colorSystem[i, 19] = figure.Color;
                    }
                }
                for (int i = 0; i < 20; i++)
                {
                    if (figure.Cords[9, i])
                    {
                        cordSystem[9, i] = true;
                        colorSystem[9, i] = figure.Color;
                    }
                }
                bool stop = true;
                for (int i = 0; i < 10; i++)
                {
                    if (cordSystem[i, 0])
                    {
                        stop = false;
                        break;
                    }
                }
                if (stop)
                {
                    int[] yCord = new int[0];
                    bool nStop = true;
                    for (int i = 0; i < 20; i++)
                    {

                        if
                            (
                            cordSystem[1, i] &&
                            cordSystem[2, i] &&
                            cordSystem[3, i] &&
                            cordSystem[4, i] &&
                            cordSystem[5, i] &&
                            cordSystem[6, i] &&
                            cordSystem[7, i] &&
                            cordSystem[8, i] &&
                            cordSystem[9, i] &&
                            cordSystem[0, i]
                            )
                        {
                            cordSystem[1, i] = false;
                            cordSystem[2, i] = false;
                            cordSystem[3, i] = false;
                            cordSystem[4, i] = false;
                            cordSystem[5, i] = false;
                            cordSystem[6, i] = false;
                            cordSystem[7, i] = false;
                            cordSystem[8, i] = false;
                            cordSystem[9, i] = false;
                            cordSystem[0, i] = false;
                            score += 10;

                            colorSystem[1, i] = null;
                            colorSystem[2, i] = null;
                            colorSystem[3, i] = null;
                            colorSystem[4, i] = null;
                            colorSystem[5, i] = null;
                            colorSystem[6, i] = null;
                            colorSystem[7, i] = null;
                            colorSystem[8, i] = null;
                            colorSystem[9, i] = null;
                            colorSystem[0, i] = null;
                            if (score>maxScore)
                            {
                                maxScore = score;
                                maxScorelbl.Text = $"MaxScore = {maxScore} ";
                            }

                            Array.Resize(ref yCord, yCord.Length + 1);
                            yCord[yCord.Length - 1] = i;
                            nStop = false;
                        }

                    }
                    if (nStop == false)
                    {
                        timer.Stop();
                    }

                    for (int i = 0; i < yCord.Length; i++)
                    {
                        bool[,] subCords = new bool[10, yCord[i] + 1];
                        string[,] subColorSystem = new string[10, yCord[i] + 1];
                        for (int k = 0; k < yCord[i]; k++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (cordSystem[j, k])
                                {
                                    subCords[j, k + 1] = true;
                                    subColorSystem[j, k + 1] = colorSystem[j, k];
                                    colorSystem[j, k] = null;
                                }
                            }
                        }

                        for (int k = 0; k < yCord[i] + 1; k++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                cordSystem[j, k] = subCords[j, k];
                                colorSystem[j, k] = subColorSystem[j, k];
                            }
                        }

                    }

                    figure.Generate();
                    Clear();
                    ShowGame();
                    if (timer.Enabled == false)
                        timer.Enabled = true;
                }
                else
                {
                    timer.Stop();
                    Clear();
                    for (int i = 0; i < 20; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            cordSystem[j, i] = false;
                            colorSystem[j, i] = null;
                        }
                    }
                    start = true;
                    if (score > maxScore)
                    {
                        maxScore = score;
                        maxScorelbl.Text = $"MaxScore = {maxScore} ";
                    }
                    StreamWriter sw = new StreamWriter("MaxScore.text");
                    sw.WriteLine(maxScore);
                    sw.Close();
                    score = 0;
                    gameStop = false;
                }


            }

        }
        private void MoveRig()
        {

            bool toContinue = true;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j + 1 != 10)
                    {
                        if (cordSystem[j + 1, i] && figure.Cords[j, i])
                            toContinue = false;
                    }
                    if (figure.Cords[9, i])
                        toContinue = false;

                }
            }

            if (toContinue)
            {
                lastMove = "Right";
                figure.MoveR();
                Clear();
                ShowGame();
            }

        }
        private void MoveLef()
        {

            bool toContinue = true;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 0)
                    {
                        if (cordSystem[j - 1, i] && figure.Cords[j, i])
                            toContinue = false;
                    }
                    if (figure.Cords[0, i])
                        toContinue = false;

                }
            }

            if (toContinue)
            {
                lastMove = "Left";
                figure.MoveL();
                Clear();
                ShowGame();

            }

        }

        private void FigureRotation()
        {
            if (figure.shape == "Line-shape")
            {
                if (figure.State == 0)
                {
                    int k = int.MinValue;
                    int n = int.MinValue;
                    int y, x;
                    y = figure.Axis[1];
                    x = figure.Axis[0] + 1;


                    if (y == 19)
                    {
                        //y -= 3;
                        k = 0;
                    }
                    else if (y == 18)
                    {
                        //y -= 2;
                        k = 1;
                    }
                    else if (y == 17) 
                    {
                        //y -= 1;
                        k = 2;
                    }
                   
                    if (k == 0) y -= 3;
                    else if(k==1) y -= 2;
                    else if(k==2) y -= 1;

                    if (y-1!=-1)
                    {
                        if (cordSystem[x, y + 3] && cordSystem[x, y + 2] == false && cordSystem[x, y + 1] == false)
                        {
                            if (cordSystem[x, y - 1] == false)
                            {

                                n = 2;
                            }

                        }
                    }

                    if (y-2>=0)
                    {
                        if (cordSystem[x, y + 2] && cordSystem[x, y + 1] == false)
                        {
                            if (cordSystem[x, y - 2] == false)
                            {
                                n = 1;
                            }
                        }
                    }
                    if (y-3>=0)
                    {
                        if (cordSystem[x, y + 1])
                        {
                            if (cordSystem[x, y - 3] == false)
                            {

                                n = 0;
                            }
                        }
                    }
                   
                    if (n == 0) y -= 3;
                    if (n == 1) y -= 2;
                    if (n == 2) y -= 1;

                    if (y == 0) y += 3;
                    else y += 1;
                    if (cordSystem[x, y + 1] || cordSystem[x, y + 1] || cordSystem[x, y - 1] || cordSystem[x, y - 2] || cordSystem[x, y])
                    {
                        return;
                    }
                    else
                    {
                        figure.Rotate(k,n);
                        stateChanger = true;
                        Clear();
                        ShowGame();
                    }
                }
                else
                {
                    int y, x;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    int k = int.MinValue;


                    if (x == 0)
                    {
                        k = 0;
                    }
                    if (x == 9)
                    {
                        k = 2;
                    }
                    if (x == 8)
                    {
                        k = 1;
                    }

                    if (x != 9 && x != 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int j = y;
                            if (cordSystem[x - 1, j] && cordSystem[x + 1, j])
                            {
                                return;
                            }
                            j++;
                        }

                    }
                    if (x != 0 && (x != 8 && x != 9))
                    {
                        if (cordSystem[x - 1, y] && cordSystem[x - 1, y + 1] && cordSystem[x - 1, y + 2])
                        {
                            k = 0;
                        }
                        else if (cordSystem[x + 1, y] && cordSystem[x + 1, y + 1] && cordSystem[x + 1, y + 2])
                        {
                            k = 2;
                        }
                        else if (cordSystem[x + 2, y] && cordSystem[x + 2, y + 1] && cordSystem[x + 2, y + 2])
                        {
                            k = 1;
                        }
                    }


                    if (k == 0) x += 1;
                    else if (k == 2) x -= 2;
                    else if (k == 1) x -= 1;
                    if (cordSystem[x - 1, y] || cordSystem[x + 1, y] || cordSystem[x + 2, y] )
                    {
                        return;
                    }
                    if (cordSystem[x, y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();

                }
            }
            else if (figure.shape== "S-shape")
            {
                if (figure.State==0)
                {
                    int k = int.MinValue;
                    int n = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    if (x==1)
                    {
                        k = 0;
                        x++;
                    }
                    if (x==9)
                    {
                        k = 1;
                        x--;
                    }
                    if (n != 1)
                    {
                        if (cordSystem[x+1,y])
                        {
                            k = 1;
                            x--;
                        }
                    }

                    if (cordSystem[x - 1, y]||cordSystem[x, y + 1]||cordSystem[x + 1, y + 1])
                    {
                        return;
                    }
                    if (cordSystem[x, y])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    x++;

                    if (y==18)
                    {
                        k = 0;
                        y--;
                    }
                    if (k != 0)
                    {
                        if (cordSystem[x - 1, y + 2])
                        {
                            k = 0;
                            y--;
                        }
                    }
                    if (k!=0)
                    {
                        if (cordSystem[x-1,y+1])
                        {
                            k = 0;
                            y--;
                        }
                    }

                    if (cordSystem[x, y + 1]||cordSystem[x - 1, y + 1]||cordSystem[x - 1, y + 2])
                    {
                        return;
                    }
                    if (cordSystem[x, y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                
            }
            else if (figure.shape== "Z-shape")
            {
                if (figure.State == 0)
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (x==0)
                    {
                        k = 0;
                        x++;
                    }
                    if (k!=0&&x!=8)
                    {
                        if (cordSystem[x-1,y+1])
                        {
                            k = 0;
                            x++;
                        }
                    }

                    if (cordSystem[x + 1, y]||cordSystem[x, y + 1]||cordSystem[x - 1, y + 1])
                    {
                        return;
                    }
                    if (cordSystem[x,y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (y == 18)
                    {
                        k = 0;
                        y--;
                    }
                    if (k != 0)
                    {
                        if (cordSystem[x, y + 2])
                        {
                            k = 0;
                            y--;
                        }
                    }

                    if (cordSystem[x, y + 1]||cordSystem[x + 1, y + 1]||cordSystem[x + 1, y + 2])
                    {
                        return;
                    }
                    if (cordSystem[x, y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
            }
            else if (figure.shape == "L-shape")
            {
                if (figure.State==0)
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (x==0)
                    {
                        k = 0;
                        x++;
                    }
                    if (k!=0)
                    {
                        if (cordSystem[x-1,y+1])
                        {
                            k = 0;
                            x++;
                        }
                    }
                    if (k!=0)
                    {
                        if (cordSystem[x + 1, y + 1] || cordSystem[x + 1, y + 1])
                        {
                            k = 1;
                            x--;
                        }
                    }
                    
                   
                    

                    if (cordSystem[x, y + 1]||cordSystem[x - 1, y + 1]||cordSystem[x + 1, y + 1]||cordSystem[x + 1, y + 2])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State == 1)
                {
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    if (cordSystem[x + 2, y]||cordSystem[x + 2, y + 1]||cordSystem[x + 1, y + 1]||cordSystem[x + 2, y - 1])
                    {
                        return;
                    }
                    figure.Rotate(int.MinValue, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==2)
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (x==1)
                    {
                        k = 0;
                        x++;
                    }
                    if (k!=0&&x!=9)
                    {
                        if (cordSystem[x - 2, y + 1]&&cordSystem[x - 2, y])
                        {
                            k = 0;
                            x++;
                        }
                    }

                    if (cordSystem[x, y + 1]||cordSystem[x - 1, y + 1]||cordSystem[x - 2, y + 1]||cordSystem[x - 2, y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==3)
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    if (y==18)
                    {
                        k = 0;
                        y--;
                    }
                    if (k!=0)
                    {
                        if (cordSystem[x + 1, y + 2])
                        {
                            k = 0;
                            y--;
                        }
                    }

                    if (cordSystem[x + 2, y]||cordSystem[x + 1, y]||cordSystem[x + 1, y + 1]||cordSystem[x + 1, y + 2])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
            }
            else if (figure.shape == "MirroredL-shape")
            {
                if (figure.State==0)
                {
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (x==8)
                    {
                        k = 0;
                        x--;
                    }
                    if (k!=0&&x!=0)
                    {
                        if (cordSystem[x + 2, y + 1]||cordSystem[x + 2, y])
                        {
                            k = 0;
                            x--;
                        }
                    }
                    if (x!=7)
                    {
                        if (cordSystem[x,y+1])
                        {
                            k = 1;
                            x++;
                        }
                    }

                    Debug.WriteLine(x);
                    if (cordSystem[x, y + 1]||cordSystem[x + 1, y + 1]||cordSystem[x + 2, y + 1]||cordSystem[x + 2, y])
                    {
                        return;
                    }

                    figure.Rotate(k, int.MinValue);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==1)
                {
                    int n=int.MinValue;
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (y==18)
                    {
                        k = 0;
                        y--;
                    }
                    if (k!=0)
                    {
                        if (cordSystem[x - 2, y + 2]||cordSystem[x - 1, y + 2])
                        {
                            k = 0;
                            y--;
                        }
                    }
                    if (cordSystem[x - 2, y + 2]||cordSystem[x - 2, y + 1]||cordSystem[x - 2, y])
                    {
                        n = 0;
                        x++;
                    }
                    if (cordSystem[x - 2, y + 2]||cordSystem[x - 1, y + 2]||cordSystem[x - 2, y + 1]||cordSystem[x - 2, y])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==2)
                {
                    int n = int.MinValue;
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (x==0)
                    {
                        k = 0;
                        x++;
                    }
                    if (k != 0)
                    {
                        if (cordSystem[x - 1, y + 1]||cordSystem[x - 1, y + 2])
                        {
                            k = 0;
                            x++;
                        }
                    }
                    if (cordSystem[x - 1, y + 2])
                    {
                        n=0;
                        y--;
                    }
                    if (n!=0)
                    {
                        if (cordSystem[x + 1, y + 1]||cordSystem[x, y + 1])
                        {
                            n = 0;
                            y--;
                        }
                    }
                    if (cordSystem[x - 1, y + 1] || cordSystem[x - 1, y + 2] || cordSystem[x, y + 1] || cordSystem[x + 1, y + 1])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==3)
                {
                    int n = int.MinValue;
                    int k = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (y!=0)
                    {
                        if (cordSystem[x + 2, y + 1])
                        {
                            k = 0;
                            y--;
                        }
                    }
                    if (cordSystem[x + 2, y + 1]||cordSystem[x + 2, y]||cordSystem[x + 2, y - 1])
                    {
                        x--;
                        n = 0;
                    }
                    if (cordSystem[x + 1, y - 1]||cordSystem[x + 2, y - 1]||cordSystem[x + 2, y]||cordSystem[x + 2, y + 1])
                    {
                        return;
                    }
                   
                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
            }
            else if (figure.shape== "T-shape")
            {
                if (figure.State==0)
                {
                    int k = int.MinValue;
                    int n=int.MinValue; 
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (y==18)
                    {
                        k = 0;
                        y--;
                    }
                    if (k!=0&&y!=0)
                    {
                        if (cordSystem[x, y + 2])
                        {
                            k = 0;
                            y--;
                        }
                    }
                    if (x!=8)
                    {
                        if (cordSystem[x, y+1] || cordSystem[x, y + 2])
                        {
                            n = 0;
                            x++;
                        }
                    }
                    
                    if (cordSystem[x, y]||cordSystem[x, y + 1] || cordSystem[x, y + 2] || cordSystem[x + 1, y + 1])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State ==1)
                {
                    int k = int.MinValue;
                    int n = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    if (x==0)
                    {
                        k = 0;
                        x++;
                    }
                    if (k!=0&&x!=8)
                    {
                        if (cordSystem[x -1, y + 1])
                        {
                            k = 0;
                            x++;
                        }
                    }
                    if (x!=0)
                    {
                        if (cordSystem[x+1,y + 1])
                        {
                            n = 0;
                            x--;
                        }
                    }
                    if (cordSystem[x, y + 1]|| cordSystem[x - 1, y + 1]||cordSystem[x + 1, y + 1]||cordSystem[x, y + 2])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();

                }
                else if (figure.State ==2)
                {
                    int k = int.MinValue;
                    int n = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];

                    if (y!=18)
                    {
                        if ((cordSystem[x + 1, y - 1]&&cordSystem[x + 2, y - 1])||(cordSystem[x + 1, y - 1]&&cordSystem[x, y - 1]))
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else
                    {
                        if (x!=0)
                        {
                            if (cordSystem[x + 1, y - 1] && cordSystem[x + 2, y - 1])
                            {
                                k = 1;
                                x--;
                            }
                        }
                        if (x!=7)
                        {
                            if (cordSystem[x + 1, y - 1] && cordSystem[x, y - 1])
                            {
                                n = 0;
                                x++;
                            }
                        }
                        
                    }
                    if (cordSystem[x, y]||cordSystem[x + 1, y]||cordSystem[x + 1, y + 1]||cordSystem[x + 1, y - 1])
                    {
                        return;
                    }

                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();
                }
                else if (figure.State==3)
                {
                    int k = int.MinValue;
                    int n = int.MinValue;
                    int x, y;
                    y = figure.Axis[1];
                    x = figure.Axis[0];
                    if (x==9)
                    {
                        k = 0;
                        x--;
                    }
                    if (k!=0&&x!=1)
                    {
                        if (cordSystem[x + 1, y + 1])
                        {
                            k = 0;
                            x--;
                        }
                    }
                    if (cordSystem[x, y]||cordSystem[x, y + 1]||cordSystem[x - 1, y + 1]||cordSystem[x + 1, y + 1])
                    {
                        return;
                    }
                    figure.Rotate(k, n);
                    stateChanger = true;
                    Clear();
                    ShowGame();

                }
            }
        }
        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameStop)
            {
                if (e.KeyCode == Keys.S)
                {
                    MoveDow();
                }
                else if (e.KeyCode == Keys.D)
                {
                    MoveRig();
                }
                else if (e.KeyCode == Keys.W)
                {
                    FigureRotation();
                }
                else if (e.KeyCode == Keys.A)
                {
                    MoveLef();
                }
            }

        }
        private void Tetris_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.D)
            //{
            //    MoveRig();
            //}
            //else if (e.KeyCode == Keys.S)
            //{
            //    MoveDow();
            //}
            //else if (e.KeyCode == Keys.A)
            //{
            //    MoveLef();
            //}
            //if (gameStop)
            //{
            //    if (e.KeyCode == Keys.D)
            //    {
            //        MoveRig();
            //    }
            //    else if (e.KeyCode == Keys.W)
            //    {
            //        FigureRotation();
            //    }
            //    else if (e.KeyCode == Keys.A)
            //    {
            //        MoveLef();
            //    }
            //}

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            startGame();
            ShowGame();
            
        }
        private void startGame()
        {
            if (start)
            {
                if (firstStart)
                {
                    figure = new Figure();
                    firstStart = false;
                }
                else
                {
                    figure.Generate();
                }
                timer.Start();
                ShowGame();
                start = false;
                gameStop = true;
            }
        }
        private void Scorelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
