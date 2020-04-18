using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    GameController gameController;
    Vector2Int dimensions;
    public GameObject tilePrefab;
    Camera cam;
    GameObject boardColliderObj;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponentInParent<GameController>();
        dimensions = gameController.boardDimensions;
        for(int x = 0; x < dimensions.x; x++){
            for (int y = 0; y < dimensions.y; y++){
                Vector3 pos = new Vector3(
                    x * gameController.cellSize,
                    y * gameController.cellSize ,
                    -.1f
                );
                // pos += - gameController.origin;
                // pos.x += - dimensions.x / 2 * gameController.cellSize;
                // pos.y += - dimensions.y / 2 * gameController.cellSize;
                Vector3 firstCellCenter = new Vector3(
                    gameController.firstCellCenter.x,
                    gameController.firstCellCenter.y,
                    0
                );
                pos += firstCellCenter;
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                // tile.transform.localScale = gameController.cellSize * Vector3.one;
                tile.transform.parent = transform;
            }
        }

        List<Vector3> centers = new List<Vector3> {
            new Vector3(dimensions.x, -gameController.yTopSpacing / 2, 0),
            new Vector3(-dimensions.x, -gameController.yTopSpacing / 2, 0),
            new Vector3(0, dimensions.y - gameController.yTopSpacing / 2, 0),
            new Vector3(0, -dimensions.y - gameController.yTopSpacing / 2, 0),
        };
        boardColliderObj = GameObject.Find("Board Collider");
        foreach (Vector3 center in centers){
            BoxCollider boardCollider;
            GameObject wallColliderObj = new GameObject();
            wallColliderObj.transform.parent = gameObject.transform;
            wallColliderObj.transform.position = center;
            boardCollider = wallColliderObj.AddComponent<BoxCollider>();
            boardCollider.size = new Vector3 (dimensions.x, dimensions.y, 10);
            boardCollider.isTrigger = true;
            wallColliderObj.AddComponent<BoardCollider>();
        }

        float width = (dimensions.x 
                    + gameController.xLeftSpacing
                    + gameController.xRightSpacing);
        float height = (dimensions.y 
                    + gameController.yTopSpacing
                    + gameController.yBottomSpacing);
        cam = Camera.main;
        cam.orthographicSize = Mathf.Max(width / cam.aspect, height) / 2;
    }
}
