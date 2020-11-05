using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public  int[,] m = new int[4,4];
        public int[] dirLine = { 1, 0, -1, 0 };
        public  int[] dirColumn = { 0, 1, 0, -1 };
        public Random rand = new Random(0);
        
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i,j] = 0;
            addPiece();
            copyMatrix();
        }
        public class pair
        {
            
           public int first, second;
             public  pair(int i,int j)
            {
                first = i;
                second = j;
            }
        }
        private pair generateUnoccupiedPosition()
        {
            int occupied = 1, line=1, column=1;
            while(occupied==1)
            {
                line = rand.Next(0,10) % 4;
                column = rand.Next(0, 10) % 4;
                if (m[line,column] == 0)
                    occupied = 0;
            }
            return new pair(line, column);
        }
        private void addPiece()
        {
            pair pos = generateUnoccupiedPosition();
            m[pos.first,pos.second] = 2;
        }

        private void copyMatrix()
        {
            if (m[0, 0] != 0)
            {
                textBox2.Text = m[0, 0].ToString();
                if (int.Parse(textBox2.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox2.Text = "";
            if (m[0, 1] != 0)
            {
                textBox10.Text = m[0, 1].ToString();
                if (int.Parse(textBox10.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox10.Text = "";
            if (m[0, 2] != 0)
            {
                textBox9.Text = m[0, 2].ToString();
                if (int.Parse(textBox9.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox9.Text = "";
            if (m[0, 3] != 0){
                textBox14.Text = m[0, 3].ToString();
                if (int.Parse(textBox14.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !"); }
            else textBox14.Text = "";
            if (m[1, 0] != 0)
            {
                textBox8.Text = m[1, 0].ToString();
                if (int.Parse(textBox8.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox8.Text = "";
            if (m[1, 1] != 0)
            {
                textBox11.Text = m[1, 1].ToString();
                if (int.Parse(textBox11.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox11.Text = "";
            if (m[1, 2] != 0)
            {
                textBox12.Text = m[1, 2].ToString();
                if (int.Parse(textBox12.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox12.Text = "";
            if (m[1, 3] != 0)
            {
                textBox15.Text = m[1, 3].ToString();
                if (int.Parse(textBox15.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox15.Text = "";
            if (m[2, 0] != 0)
            {
                textBox7.Text = m[2, 0].ToString();
                if (int.Parse(textBox7.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox7.Text = "";
            if (m[2, 1] != 0)
            {
                textBox6.Text = m[2, 1].ToString();
                if (int.Parse(textBox6.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox6.Text = "";
            if (m[2, 2] != 0)
            {
                textBox5.Text = m[2, 2].ToString();
                if (int.Parse(textBox5.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox5.Text = "";
            if (m[2, 3] != 0)
            {
                textBox16.Text = m[2, 3].ToString();
                if (int.Parse(textBox16.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox16.Text = "";
            if (m[3, 0] != 0)
            {
                textBox13.Text = m[3, 0].ToString();
                if (int.Parse(textBox13.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox13.Text = "";
            if (m[3, 1] != 0)
            {
                textBox19.Text = m[3, 1].ToString();
                if (int.Parse(textBox19.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox19.Text = "";
            if (m[3, 2] != 0)
            {
                textBox18.Text = m[3, 2].ToString();
                if (int.Parse(textBox18.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox18.Text = "";
            if (m[3, 3] != 0)
            {
                textBox17.Text = m[3, 3].ToString();
                if (int.Parse(textBox17.Text) >= 2048) MessageBox.Show("Bravo ! Ai castigat !");
            }
            else textBox17.Text = "";

        }
        private bool canDoMove(int line, int column, int nextLine, int nextColumn)
        {
            if (nextLine < 0 || nextColumn < 0 || nextLine > 3 || nextColumn > 3 || 
                (m[line,column] != m[nextLine,nextColumn] && m[nextLine,nextColumn] !=0 ))
                return false;
            return true;
        }
        private void applyMove(int direction)
        {
            int startLine = 0, startColumn = 0, lineStep = 1, columnStep = 1;
            if (direction == 0)
            {
                startLine = 3;
                lineStep = -1;
            }
            if (direction == 1)
            {
                startColumn = 3;
                columnStep = -1;
            }
            int movePossible, canAddPiece = 0;
            do
            {
                movePossible = 0;
                for (int i = startLine; i >= 0 && i < 4; i += lineStep)
                    for (int j = startColumn; j >= 0 && j < 4; j += columnStep)
                    {
                        int nextI = i + dirLine[direction], nextJ = j + dirColumn[direction];
                        if (m[i,j]!=0 && canDoMove(i, j, nextI, nextJ))
                        {
                            { m[nextI, nextJ] += m[i, j]; textBox1.Text= (int.Parse(textBox1.Text)+ m[nextI,nextJ]).ToString();
                             if(int.Parse(textBox3.Text)<int.Parse(textBox1.Text))
                                    textBox3.Text = textBox1.Text; }
                            m[i,j] = 0;
                            movePossible = canAddPiece = 1;
                        }
                    }
            } while (movePossible==1);
            if (canAddPiece == 1)
                addPiece();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Keypress(object sender,KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case (char)83: applyMove(0); copyMatrix(); e.Handled = true; break;
                case (char)68: applyMove(1); copyMatrix(); e.Handled = true; break;
                case (char)87: applyMove(2); copyMatrix(); e.Handled = true; break;
                case (char)65: applyMove(3); copyMatrix(); e.Handled = true; break;
                default: break;
            }
        }

        private void clickLeft(object sender, EventArgs e)
        {
            applyMove(3);
            copyMatrix();
        }
        private void clickUp(object sender, EventArgs e)
        {
            applyMove(2);
            copyMatrix();
        }
        private void clickDown(object sender, EventArgs e)
        {
            applyMove(0);
            copyMatrix();
        }
        private void clickRight(object sender, EventArgs e)
        {
            applyMove(1);
            copyMatrix();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i, j] = 0;
            addPiece();
            textBox1.Text = 0.ToString();
            copyMatrix();
        }
    }
}
