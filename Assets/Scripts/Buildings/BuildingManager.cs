using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool MenuShown = false;
    public GameObject[] MenuObjs;
    public GameObject OpenButton;
    public void ShowMenu()
    {
        Input.ResetInputAxes();
        if (MenuShown) return;
        for (int i = 0; i < MenuObjs.Length; i++) MenuObjs[i].SetActive(true);
        MenuShown = true;
    }
    public void HideMenu()
    {
        Input.ResetInputAxes();
        if (!MenuShown) return;
        for (int i = 0; i < MenuObjs.Length; i++) MenuObjs[i].SetActive(false);
        MenuShown = false;
    }

    int Type = 0;
    bool IsPlacing = false;
    GameObject go;
    public void Choose(int t)
    {
        Input.ResetInputAxes();
        Type = t;
        OpenButton.SetActive(false);
        HideMenu();
        if (t > 0)
        {
            string s = "Building";
            switch (t)
            {
                case 1: { s = "Glavnoe_zdanie_1"; break; }
                case 2: { s = "domik1"; break; }
                case 3: { s = "domik2"; break; }
            }
            Debug.Log(s);
            go = Instantiate(Resources.Load<GameObject>("Buildings/" + s));
            go.AddComponent<BuildingClass>().Type = t;
            go.AddComponent<BoxCollider>().size = Vector3.one * 4;
        }
        IsPlacing = true;
    }
    void Cancel2()
    {
        IsPlacing = false;
        ShowMenu();
        OpenButton.SetActive(true);
    }

    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (!IsPlacing) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel2();
            if (go) Destroy(go);
            return;
        }
        if (Type > 0)
        {
            var RAY = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(RAY, out rh, 100.0f, LayerMask.GetMask("IgnoreByCam")))
            {
                var vv = rh.transform.GetComponent<GridCellData>();
                if (!vv.Occupied)
                {
                    go.transform.position = vv.WorldPos;
                    go.GetComponent<BuildingClass>().cell = vv;
                    if (Input.GetMouseButtonDown(0))
                    {
                        go.GetComponent<BuildingClass>().Type = Type;
                        go.layer = 8;
                        go = null;
                        vv.Occupied = true;
                        Cancel2();
                    }
                }
            }
        }
        else
        {
            //Debug.Log("Удаляется...");
            var RAY = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(RAY, out rh, 100.0f))
            {
                Debug.Log("смотрит на " + rh.transform.gameObject.name);
                if (rh.transform.GetComponent<BuildingClass>())
                {
                    rh.transform.GetComponent<BuildingClass>().cell.Occupied = false;
                    Destroy(rh.transform.gameObject);
                    Cancel2();
                }
            }
        }
    }

}
