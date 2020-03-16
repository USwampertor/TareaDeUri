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

      //Reviso si mi lista es nula, y si lo es, para revisar si los nodos ya 
      //fueron checados o no
      //if (v1 == null) { v1 = new int[v.Length]; }

      bool[] checkedNodes = new bool[v.Length];

      //Se limpian los valores para poner que ningun nodo ha sido revisado
      for (int i = 0; i < v1.Length; ++i) { v1[i] = 0; }
      //Limpio la lista de hijos en orden de anchura
      hijos.Clear();

      raiz = comboBox1.SelectedIndex;

      string actualNode = "";
      //Genero la lista de nodos temporales a revisar
      List<string> temporalNodes = new List<string>();
      //Añado a la lista el nodo que el usuario seleccionó
      temporalNodes.Add(v[raiz]);

      //Mientras quede algún nodo por checar, revisa los hijos del nodo a revisar
      while (temporalNodes.Count > 0) {

        //MODO ANCHURA revisa el primer nodo de la lista
        actualNode = temporalNodes[0];
        //Remuevo de la lista el nodo que estamos checando
        temporalNodes.RemoveAt(0);
        //Seteo que este nodo ya está revisado
        checkedNodes[nodes.IndexOf(actualNode)] = true;
        //Añado a la lista final el nodo
        hijos.AddLast(nodes.IndexOf(actualNode));

        int position = nodes.IndexOf(actualNode);

        //Reviso todas las conexiones posibles  (hijos/vecinos) restantes 
        //(no han sido metidos a la lista anteriormente)
        for (int i = 0; i < v.Length; ++i) {
          //Checamos la columna del nodo actual y las posibles conexiones
          if (matriz[position, i] != 0 && 
              !checkedNodes[i] && 
              !temporalNodes.Contains(v[i])) { temporalNodes.Add(v[i]); }
          //Checamos la fila del nodo actual y las posibles conexiones
          if (matriz[i, position] != 0 && 
              !checkedNodes[i] && 
              !temporalNodes.Contains(v[i])) { temporalNodes.Add(v[i]); }
        }
      }

      //Imprimo la lista final
      string s = "";
      s = String.Join(",", hijos);
      MessageBox.Show(s, "El arbol es;");
    }
  }
}
