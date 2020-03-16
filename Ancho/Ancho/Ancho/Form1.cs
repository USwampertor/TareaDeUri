using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ancho
{
  public partial class Form1 : Form
  {
    int[,] matriz;
    string[] v = {"a", "b", "c", "d", "e", "f", "g", "h"};
    List<string> nodes = new List<string>();
    string[,] a;
    int[] v1 = {};
    string[,] a1;
    int raiz = 0;
    int[] dif = { };
    LinkedList<int> hijos = new LinkedList<int>();

    //variables de iteracion
    int z = 0;
    int x = 0;
    int c = 0;





    public Form1() {
        
      InitializeComponent();
      comboBox1.SelectedIndex = 0;
      matriz = new int[,] 
        {{0,1,1,0,0,0,1,0},
         {1,0,0,1,0,0,0,0},
         {1,0,0,0,1,0,0,0},
         {0,1,0,0,0,1,0,0},
         {0,0,1,0,0,0,0,0},
         {0,0,0,1,0,0,0,1},
         {1,0,0,0,0,0,0,0},
         {0,0,0,0,0,1,0,0}};

      a = new string[,]
        {{"","e1","e12","","","","e9",""},
         {"e1","","","e3","","","",""},
         {"e12","","","","e8","","",""},
         {"","e3","","","","e4","",""},
         {"","","e8","","","","",""},
         {"","","","e","","","","e5"},
         {"e9","","","","","","",""},
         {"","","","","","e5","",""}};

      v1 = new int[v.Length];

      nodes.Add("a");
      nodes.Add("b");
      nodes.Add("c");
      nodes.Add("d");
      nodes.Add("e");
      nodes.Add("f");
      nodes.Add("g");
      nodes.Add("h");
    }

    /**
     * Click 
     * 
     */
    private void button1_Click(object sender, EventArgs e) {

      if (v1 == null) { v1 = new int[v.Length]; }
      hijos.Clear();

      raiz = comboBox1.SelectedIndex;

      string actualNode = "";

      List<string> temporalNodes = new List<string>();
      temporalNodes.Add(v[raiz]);

      while (temporalNodes.Count > 0) {
        
        actualNode = temporalNodes[0];
        temporalNodes.RemoveAt(0);
        v1[nodes.IndexOf(actualNode)] = 1;

        hijos.AddLast(nodes.IndexOf(actualNode));

        int position = nodes.IndexOf(actualNode);

        for (int i = 0; i < v.Length; ++i) {
          if (matriz[position, i] != 0 && v1[i] == 0) { temporalNodes.Add(v[i]); }
        }
      }

      string s = "";
      s = String.Join(",", hijos);
      MessageBox.Show(s, "El arbol es;");

      /*
            
      do {
        for(x=0;x<v1.Length;++x) {
          v1[x] = raiz;


          IEnumerable<int> df = dif.Except(v1);

          foreach (var str in dif) {
              if (!hijos.Contains(str)) { hijos.AddLast(str); }
          }
        }
        ++z;
      } while (z < v1.Length);

  */
    }
  }
}
