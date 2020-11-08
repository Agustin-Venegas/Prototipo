using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//esta clase se encarga de contener todos los puntos de ruta
//transitables por los enemigos en un nivel

public class MapManager : MonoBehaviour
{
    public List<MapNode> nodes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*aqui esta el algoritmo malo que uso
    public List<MapNode> getRoad(Vector2 pos, Vector2 goal)
    {
        MapNode start = getClosestNode(pos);
        MapNode End = getClosestNode(goal);

        List<MapNode> road = new List<MapNode>();
        road.Add(nodes[0]);

        List<int[]> trees = new List<int[]>();

    }*/

    public MapNode getClosestNode(Vector2 p)
    {
        float dist = Vector3.Distance(p, nodes[0].transform.position);
        MapNode n = nodes[1];

        for (int i = 1; i < nodes.Count; i++)
            if (dist > Vector3.Distance(p, nodes[i].transform.position))
            {
                dist = Vector3.Distance(p, nodes[i].transform.position);
                n = nodes[i];
            }

        return n;
    }
}
