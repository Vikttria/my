using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheGame : MonoBehaviour
{
    public float lastFall = 0;
    public float speed = 0f;
    public int level;
    public static int deleteRow = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!isValidBlockPos())
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
            GameOverMenu.gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidBlockPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidBlockPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
            if (isValidBlockPos())
            {
                updateGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || 1 <= Time.time - lastFall)
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidBlockPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                PlaySquare.deleteFullRows();
                if (!PlaySquare.delete)
                {
                    updateGrid();
                }
                PointUpdate.point += FindObjectOfType<NewBlock>().blockNumber;
                FindObjectOfType<NewBlock>().blockNext();
                enabled = false;
            }

            lastFall = Time.time + speed;

            if (2 == deleteRow)
            {
                speed += 0.1f;
                deleteRow = 0;
            }
        }

    }


    bool isValidBlockPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 block = PlaySquare.roundVector(child.position);
            if (!PlaySquare.insideField(block))
            {
                return false;
            }
            if (PlaySquare.grid[(int)block.x, (int)block.y] != null 
                    && PlaySquare.grid[(int)block.x, (int)block.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < PlaySquare.height; y++)
        {
            for (int x = 0; x < PlaySquare.width; x++)
            {
                if (PlaySquare.grid[x, y] != null)
                {
                    if (PlaySquare.grid[x, y].parent == transform)
                    {
                        PlaySquare.grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform child in transform)
        {
            Vector2 block = PlaySquare.roundVector(child.position);
            PlaySquare.grid[(int)block.x, (int)block.y] = child;
        }
    }
}
