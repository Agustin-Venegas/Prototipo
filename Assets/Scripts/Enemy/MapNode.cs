using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cada nodo en el mapa
public class MapNode : MonoBehaviour
{

    public List<MapNode> connects;
    public List<float> costs;

    // Start is called before the first frame update
    void Start()
    {
        costs = new List<float>();

        foreach (MapNode n in connects)
        {
            costs.Add(Vector3.Distance(transform.position, n.transform.position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
