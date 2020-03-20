using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Neighbor
{
  [SerializeField]
  public City neighbor;

  [SerializeField]
  public int weigth;
}

[System.Serializable]
public class Connection : System.IComparable<Connection>
{

  public 
  Connection(City newOrigin) {
    origin = newOrigin;
    destiny = null;
    weight = int.MaxValue;
  }

  public int
  CompareTo(Connection other) {
    return weight - other.weight;
  }

  [SerializeField]
  public City origin;

  [SerializeField]
  public City destiny;

  [SerializeField]
  public int weight;
}

public class Subset
{
  public int parent;
  public int rank;
}

public class City : MonoBehaviour
{

  public int nodeName;


  // Start is called before the first frame update
  void Start() {
        
  }

  // Update is called once per frame
  void Update() {
      
  }
}
