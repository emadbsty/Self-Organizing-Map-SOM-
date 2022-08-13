using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANN_Lib;
namespace SOM01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SOM_Network som_network;
        SOM_Network.SOM_Nodes nodes;
        float[] inputs;
        float lr = 0.5f;
        Point dim; int radius = 7;
        static Random rand1 = new Random();
        static Random rand2 = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            int out_num = 20;
            dim = new Point(out_num, out_num);
            inputs = new float[2];
            int input_num = 500;
            float[,] ii = new float[input_num, 2];
            for (int i = 0; i < input_num; i += 3)
            {
                ii[i, 0] = (float)rand1.Next(100, 125) / 1000.0f;
                ii[i, 1] = (float)rand1.Next(15, 35) / 100.0f;
            }
            for (int i = 1; i < input_num; i += 3)
            {
                ii[i, 0] = (float)rand1.Next(135, 165) / 1000.0f;
                ii[i, 1] = (float)rand1.Next(45, 60) / 100.0f;
            }
            for (int i = 2; i < input_num; i += 3)
            {
                ii[i, 0] = (float)rand1.Next(175, 215) / 1000.0f;
                ii[i, 1] = (float)rand1.Next(75, 115) / 100.0f;
            }
            som_network = new SOM_Network(dim, inputs.Length);
            for (int k = 0; k < 5; k++)
            {
                for (int j = 0; j < input_num; j++)
                {
                    inputs[0] = ii[j, 0]; inputs[1] = ii[j, 1];
                    for (int i = 0; i <= radius; i++)
                    {
                        lr = 0.7f;
                        som_network.CalcDistance(inputs);
                        nodes = som_network.Get_BMU();
                        List<Point> pp = som_network.Get_neighboring(nodes, i);
                        lr = lr * (float)Math.Exp((float)-i / (float)radius);
                        som_network.Update(pp, inputs, lr);
                    }
                }
            }
            int[,] auxx = new int[out_num, out_num];
            for (int i = 0; i < out_num; i++)
            {
                for (int j = 0; j < out_num; j++)
                {
                    auxx[j, i] = som_network.Nodes[j, i].color.R;
                }
            }
            imageViewer1.inti(auxx, out_num, out_num, 18, 18);
        }
    }
}
