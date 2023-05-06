using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    public static bool isBuildingActive = false;
    public Transform POVCamara;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;

    public int prefabIndex = -1; //Index out of scope så den ikke kan placeres // lidt et hack

    public GameObject minTurret;
    public GameObject midTurret;
    public GameObject maxTurret;

    private PlaceableObject objectToPlace;
    
    #region Unity methods

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuildingActive = true;
        }
        
        if (isBuildingActive)
        {
            //Something with the cam
            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (prefabIndex >= 0)
                {
                    switch (prefabIndex)
                    {
                    case 0:
                        InitilizeWithObject(minTurret);
                        prefabIndex = -1;
                        break;
                    case 1:
                        InitilizeWithObject(midTurret);
                        prefabIndex = -1;
                        break;
                    case 2:
                        InitilizeWithObject(maxTurret);
                        prefabIndex = -1;
                        break;
                    default:
                        //Gør intet hvis ingen er selected
                        break;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                //Camera.main.enabled = false;
                isBuildingActive = false;
            }

            if (!objectToPlace)
            {
                return;
            }
            
            if(Input.GetKeyDown(KeyCode.Space)){
            {
                if (CanBePlaced(objectToPlace))
                {
                    objectToPlace.Place();
                    Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                    TakeArea(start, objectToPlace.Size);
                }
                else
                {
                    Destroy(objectToPlace.gameObject);
                }
            }} else if (Input.GetKeyDown(KeyCode.P))
            {
                Destroy(objectToPlace.gameObject);
            }
        }
    }
    
    #endregion
    
    #region Utils

    public void SetPrefabIndex(int index)
    {
        prefabIndex = index;
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }
    
    
    #endregion
    
    #region Building Placement

    public void InitilizeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(GetMouseWorldPosition());
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

        foreach (var b in baseArray)
        {
            if (b == whiteTile)
            {
                return false;
            }
        }

        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.z + size.x, start.y + start.y);
    }
    
    #endregion
    
    

}
