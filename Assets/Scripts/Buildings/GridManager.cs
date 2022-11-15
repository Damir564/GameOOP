using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int X = 10, Y = 10;
    public struct CELL
    {
        public GameObject CellObj;
        public GameObject Building;
        public bool Exists;
        public int X, Y;

        public CELL(int x, int y)
        {
            Building = null;
            CellObj = null;
            X = x;
            Y = y;
            Exists = true;
        }
    }
    CELL[,] Cells;
    void Start()
    {
        Cells = new CELL[X, Y];
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                Cells[i, j] = new CELL(i, j);
                var gos = GameObject.CreatePrimitive(PrimitiveType.Quad);
                //Destroy(gos.GetComponent<MeshCollider>());
                gos.name = "S" + i + "_" + j;
                gos.transform.localScale = Vector3.one * 6;
                gos.transform.SetPositionAndRotation(transform.position + new Vector3(i * 7, 0.1f, j * 7), Quaternion.Euler(90, 0, 0));
                gos.transform.SetParent(transform);
                
                var mf = gos.GetComponent<MeshFilter>();
                var m = mf.mesh;
                var vs = m.vertices;
                for (int k = 0; k < 4; k++)
                {
                    if (Physics.Raycast(gos.transform.TransformPoint(vs[k]) + Vector3.up * 9, Vector3.down, out var info, 20, ~7))
                        vs[k] = gos.transform.InverseTransformPoint(info.point);
                    else
                    {
                        //gos.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                        Cells[i, j].Exists = false;
                        Destroy(gos);
                        break;
                    }
                }
                if (!gos) continue;

                gos.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                gos.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green * 0.0f);
                gos.layer = LayerMask.NameToLayer("IgnoreByCam");
                gos.AddComponent<GridCellData>().Pos = new Vector2(i, j);


                //Debug.DrawLine(gos.transform.TransformPoint(vs[0]), gos.transform.TransformPoint(vs[0]) + Vector3.up);//vs[1] + gos.transform.position, vs[1] + gos.transform.position + Vector3.up);

                m.vertices = vs;
                m.RecalculateBounds();
                m.RecalculateNormals();
                m.RecalculateTangents();
                mf.mesh = m;
                gos.GetComponent<MeshCollider>().convex = true;
                gos.GetComponent<MeshCollider>().sharedMesh = m;
                gos.GetComponent<GridCellData>().WorldPos = gos.transform.TransformPoint(m.bounds.center);
                if (m.bounds.size.y > 1.1f)
                {
                    Debug.Log(m.bounds.size.y);
                    //gos.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                    Cells[i, j].Exists = false;
                    Destroy(gos);
                }
                if (gos) Cells[i, j].CellObj = gos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
