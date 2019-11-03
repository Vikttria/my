using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySquare : MonoBehaviour
{
    public static int width = 10;
    public static int height = 18;

    public static bool delete = false;

    public static Transform[,] grid = new Transform[width, height];

    public static void deleteFullRows()
    {

        for (int y = 0; y < height; y++)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRow(y+1);
                --y;
                delete = true;
                PointUpdate.point += 10;
            }
        }
    }

    public static Vector2 roundVector(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool insideField(Vector2 pos)
    {
        return (0 <= (int)pos.x && (int)pos.x < width && 0 <= (int)pos.y);
    }

    public static void deleteRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
            TheGame.deleteRow++;
        }
    }

    public static void downRows(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRow(int y)
    {
        for (int i = y; i < height; i++)
        {
            downRows(i);
        }
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
}
