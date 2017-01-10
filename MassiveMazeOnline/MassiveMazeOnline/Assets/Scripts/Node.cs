using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Node{
    private Dictionary<Node, int> nodes = new Dictionary<Node, int>();

    private Node previousNode;
    private int currentWeight = int.MaxValue;

    public IntVector2D location;

    public Node(IntVector2D location)
    {
        this.location = location;
    }

    /*
     * returns true if the node was succesfully added
     */
    public bool addNode(Node node, int weight)
    {
        if (nodes.ContainsKey(node)) return false;
        nodes.Add(node, weight);
        return true;
    }

    public Node getPreviousNode()
    {
        return previousNode;
    }

    public Dictionary<Node, int> getEdges()
    {
        return nodes;
    }

    public int getCurrentWeight()
    {
        return currentWeight;
    }
}
