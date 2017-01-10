using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeSpawner : MonoBehaviour {
    public IntVector2D dimentions;

    [SerializeField]
    private List<Node> nodes = new List<Node>();


    public Node[,] grid = new Node[5, 5];
    // Use this for initialization
    void Start () {
        //Node[,] grid = new Node[dimentions.y, dimentions.x];
        List<Node> unfinishedNodes = new List<Node>();

        IntVector2D start = getRandomCoord();
        grid[start.y, start.x] = new Node(start);
        unfinishedNodes.Add(grid[start.y, start.x]);

        while(unfinishedNodes.Count > 0)
        {
            Node currentNode = unfinishedNodes[unfinishedNodes.Count - 1];

            IntVector2D neighbor;
            int count = 4;
            do
            {

                neighbor = getRandomNeighbor(currentNode);
                if (neighbor.x == 0 ||
                    neighbor.x >= dimentions.x ||
                    neighbor.y == 0 ||
                    neighbor.y >= dimentions.y) neighbor = currentNode.location;
            } while (grid[neighbor.y, neighbor.x] != null && count >= 0);

            if(count < 0)
            {
                unfinishedNodes.Remove(currentNode);
                continue;
            }

            unfinishedNodes.Add(new Node(neighbor));
            grid[neighbor.y, neighbor.x] = unfinishedNodes[unfinishedNodes.Count - 1];
        }

	}

    private IntVector2D getRandomCoord()
    {
        System.Random r = new System.Random();
        return new IntVector2D(
            r.Next(0, dimentions.x),
            r.Next(0, dimentions.y));
    }

    private IntVector2D getRandomNeighbor(Node node)
    {
        int dir = (new System.Random()).Next(0, 4);
        switch (dir)
        {
            case 0:
                return node.location + new IntVector2D(0, -1);
            case 1:
                return node.location + new IntVector2D(0, 1);
            case 2:
                return node.location + new IntVector2D(1, 0);
            case 3:
                return node.location + new IntVector2D(-1, 0);
            default:
                return node.location;
        }
    }
}
