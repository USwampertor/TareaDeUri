using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kruskal : MonoBehaviour
{

  #region PROPERTIES
  public List<Connection> connections;

  public List<City> cities;

  public LineRenderer lineRendererPrefab;

  #endregion

  #region INTERNAL_PROPERTIES

  private List<LineRenderer> m_lineRenderer = new List<LineRenderer>();

  #endregion



  #region MONOBEHAVIOR_METHODS
  // Start is called before the first frame update
  void Start() {
      
  }

  // Update is called once per frame
  void Update() {
    
  }


  #endregion


  #region METHODS

  private int 
  FindSubset(List<Subset> subsets, int i) {
    if (subsets[i].parent != i) { subsets[i].parent = FindSubset(subsets, subsets[i].parent); }
    return subsets[i].parent;
  }

  private void
  UnionSubset(List<Subset> subsets, int origin, int destiny ) {
    int originSubset = FindSubset(subsets, origin);
    int destinySubset = FindSubset(subsets, destiny);

    if      (subsets[originSubset].rank < subsets[destinySubset].rank) { 
      subsets[originSubset].parent = destinySubset; 
    }
    else if (subsets[originSubset].rank > subsets[destinySubset].rank) { 
      subsets[destinySubset].parent = originSubset; 
    }
    else {
      subsets[destinySubset].parent = originSubset;
      ++subsets[originSubset].rank;
    }
  }

  public void
  StartKruskal() {

    int i = 0;
    List<Connection> orderedConnections = new List<Connection>();

    List<Connection> kruskalTree = new List<Connection>();

    List<Subset> subsets = new List<Subset>();

    foreach(Connection connection in connections) { orderedConnections.Add(connection); }

    int numCities = cities.Count;

    orderedConnections.Sort();

    //Creates a series of subsets based on amount of vertices
    for(i = 0; i < cities.Count; ++i) {
      Subset subset = new Subset();
      subset.parent = i;
      subset.rank = 0;
      subsets.Add(subset);
    }


    //Start connecting nodes until the amount of edges is number of vertices - 1
    i = 0;
    while (kruskalTree.Count < numCities - 1 && i < orderedConnections.Count) {

      //Get Next node in the list
      Connection currentConnection = orderedConnections[i];
      ++i;

      int originSubset = FindSubset(subsets, currentConnection.origin.nodeName - 1);
      int destinySubset = FindSubset(subsets, currentConnection.destiny.nodeName - 1);

      //Check if there is no cycle between chosen edges
      if (originSubset != destinySubset) {
        kruskalTree.Add(currentConnection);
        UnionSubset(subsets, originSubset, destinySubset);
      }
    }

    for (i = 0; i < m_lineRenderer.Count; ++i) {
      var lineRenderer = m_lineRenderer[i];
      m_lineRenderer[i] = null;
      Destroy(lineRenderer); 
    }

    Debug.Log("Kruskal Size: " + kruskalTree.Count);

    foreach(Connection connection in kruskalTree) {
      var lineRenderer = Instantiate(lineRendererPrefab);
      lineRenderer.positionCount = 2;

      GameObject origin   = cities.Find(x => x == connection.origin).gameObject;
      GameObject destiny  = cities.Find(x => x == connection.destiny).gameObject;

      Vector3 originPosition  = origin.transform.position;
      Vector3 destinyPosition = destiny.transform.position;

      lineRenderer.SetPosition(0, originPosition);
      lineRenderer.SetPosition(1, destinyPosition);
      m_lineRenderer.Add(lineRenderer);
      Debug.Log("Connection " + connection.origin.nodeName + " and " + connection.destiny.nodeName);
    }


  }

  #endregion
}
