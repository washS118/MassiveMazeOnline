using System.Collections;

[System.Serializable]
public class IntVector2D{
    public int x;
    public int y;

    public IntVector2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static IntVector2D operator + (IntVector2D a, IntVector2D b)
    {
        return new IntVector2D(a.x + b.x, a.y + b.y);
    }
}
