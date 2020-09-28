using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathVizualizer : MonoBehaviour
{
    [SerializeField] private GameObject[] path;
    [SerializeField] private bool enabled = false;
    [SerializeField] private Color color1 = Color.black;
    [SerializeField] private Color color2 = Color.white;
    private GameObject[] lines = new GameObject[100];
    private LineRenderer[] newLine = new LineRenderer[100];
    private Vector3 offset = new Vector3(0, 1.0f, 0);
    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            for (int i = 0; i < path.Length; i++)
            {
                lines[i] = new GameObject();
                newLine[i] = lines[i].AddComponent<LineRenderer>();
                newLine[i].startWidth = 2.0f;
                newLine[i].endWidth = 0.5f;
                newLine[i].material = new Material(Shader.Find("Sprites/Default"));
                newLine[i].SetColors(color1, color2);
                if (i == 0)
                {
                    newLine[i].SetPosition(0, this.transform.position - offset);
                    newLine[i].SetPosition(1, path[i].transform.position - offset);
                }
                else
                {
                    newLine[i].SetPosition(0, path[i - 1].transform.position - offset);
                    newLine[i].SetPosition(1, path[i].transform.position - offset);
                }
            }
        }
    }
}
