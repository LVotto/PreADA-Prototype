using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour {
    public GameObject TilePrefab;
    public Vector2 corrections;
    public Vector2Int dimensions;
    public Camera gameCamera;

    //GameController gameController;
    GameObject boardColliderObj;
    Vector3 firstCellCenter;
    Vector2 padding;

    public float CellSize { get; } = 1;

    void Start() {
        //gameController = GetComponentInParent<GameController>();
        //dimensions = dimensions;
        //firstCellCenter = new Vector2(-dimensions.x * cellSize / 2, -dimensions.y * cellSize / 2);
        //corrections.x = (1 - dimensions.x % 2) * .5f;
        //corrections.y = (1 - dimensions.y % 2) * .5f;
        padding = new Vector2(2, 2);
        firstCellCenter = new Vector3(
            -dimensions.x / 2,
            -dimensions.y / 2,
            0
        );

        for (int x = 0; x < dimensions.x; x++) {
            for (int y = 0; y < dimensions.y; y++) {
                Vector3 pos = new Vector3(x * CellSize, y * CellSize, 0);
                //pos += firstCellCenter;
                GameObject tile = Instantiate(TilePrefab, pos + firstCellCenter, Quaternion.identity);
                tile.transform.localScale = CellSize * Vector3.one;
                tile.transform.parent = transform;
                tile.name = "Tile " + (x+1) + "x" + (y+1);
            }
        }

        //List<Vector3> centers = new List<Vector3> {
        //    new Vector3(dimensions.x, -yTopSpacing / 2, 0),
        //    new Vector3(-dimensions.x, -yTopSpacing / 2, 0),
        //    new Vector3(0, dimensions.y - yTopSpacing / 2, 0),
        //    new Vector3(0, -dimensions.y - yTopSpacing / 2, 0),
        //};
        //boardColliderObj = GameObject.Find("Board Collider");
        //foreach (Vector3 center in centers) {
        //    BoxCollider boardCollider;
        //    GameObject wallColliderObj = new GameObject();
        //    wallColliderObj.transform.parent = gameObject.transform;
        //    wallColliderObj.transform.position = center;
        //    boardCollider = wallColliderObj.AddComponent<BoxCollider>();
        //    boardCollider.size = new Vector3(dimensions.x, dimensions.y, 10);
        //    boardCollider.isTrigger = true;
        //    wallColliderObj.AddComponent<BoardCollider>();
        //}

        float width = (dimensions.x + padding.x);
        float height = (dimensions.y + padding.y);
        gameCamera = Camera.main;
        gameCamera.orthographicSize = Mathf.Max(width / gameCamera.aspect, height) / 2;
        gameCamera.transform.Translate(-CellSize/2, -CellSize / 2, 0);
    }
}
