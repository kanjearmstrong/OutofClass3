using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutofClassAssignment3
{
    public partial class Form1 : Form
    {
        private StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Convert to lowercase
            //first word alphabetically
            //last word alphabetically
            //longest word
            //most vowels

            //strings
            string longestWord = " ";
            string firstAlpha = " ";
            string lastAlpha = " ";
            string mostVowel = " ";
            //change2
            int vowelCt = 0;
            sw = System.IO.File.CreateText("Sample.out");
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                string allText = sr.ReadToEnd();
                this.richTextBox1.Text = allText;

                string[] words = allText.Split();
                for (int i = 0; i < words.Length; i++)
                {
                    this.richTextBox1.Text += words[i] + "\n";
                    words[i] = words[i].ToLower();
                    sw.Write(words[i] + " ");
                    //is this the first word?
                    if (i == 0)
                    {
                        longestWord = words[i];
                        firstAlpha = words[i];
                        lastAlpha = words[i];

                    }
                    else if (longestWord.Length < words[i].Length)
                        longestWord = words[i];
                    //first alphabetically
                    if (firstAlpha.CompareTo(words[i]) > 0)
                        firstAlpha = words[i];
                    //last alphabetically
                    if (lastAlpha.CompareTo(words[i]) < 0)
                        lastAlpha = words[i];

                    int vCtMax = 0;
                    for (int j = 0; j < words[i].Length; j++)
                        if (words[i][j] == 'a' ||
                          (words[i][j] == 'e' ||
                          (words[i][j] == 'i' ||
                          (words[i][j] == 'o' ||
                          (words[i][j] == 'u')))))
                            vowelCt++;

                    if (vowelCt > vCtMax)
                    {
                        vCtMax = vowelCt;
                        mostVowel = words[i];

                    }

                }


                richTextBox1.Text = "Longest Word: " + longestWord + " First Word: " + firstAlpha + " Most Vowels: " + mostVowel + " Last Alpha: " + lastAlpha;
            }
            sw.Close();
        }

    }
}

       

