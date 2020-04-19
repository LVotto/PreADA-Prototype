using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour {
    Camera gameCamera;
    Vector3 firstCellCenter;
    Vector2 padding = new Vector2(2, 2);

    public GameObject BoardColliderPrefab;
    public GameObject TilePrefab;
    public Vector2 corrections;
    public Vector2Int dimensions;

    public float CellSize { get; } = 1;

    void Start() {
        GenerateBoard();
        PositionCamera();
        SetupCollider();
    }

    void GenerateBoard() {
        firstCellCenter = new Vector3(-dimensions.x / 2, -dimensions.y / 2, 0);

        for (int x = 0; x < dimensions.x; x++) {
            for (int y = 0; y < dimensions.y; y++) {
                Vector3 pos = new Vector3(x * CellSize, y * CellSize, 0);
                GameObject tile = Instantiate(TilePrefab, pos + firstCellCenter, Quaternion.identity);
                tile.transform.localScale = CellSize * Vector3.one;
                tile.transform.parent = transform;
                tile.name = "Tile " + (x + 1) + "x" + (y + 1);
            }
        }
    }

    void PositionCamera() {
        float width = (dimensions.x + padding.x);
        float height = (dimensions.y + padding.y);
        gameCamera = Camera.main;
        gameCamera.orthographicSize = Mathf.Max(width / gameCamera.aspect, height) / 2;
        gameCamera.transform.Translate(-CellSize / 2, -CellSize / 2, 0);
    }

    void SetupCollider() {
        List<Vector3> centers = new List<Vector3> {
            new Vector3(dimensions.x, -padding.y / 2, 0),
            new Vector3(-dimensions.x - CellSize, -padding.y / 2, 0),
            new Vector3(0, dimensions.y + CellSize - padding.y / 2, 0),
            new Vector3(0, -dimensions.y - padding.y / 2, 0),
        };

        foreach (Vector3 center in centers) {
            GameObject boardCollider = Instantiate(BoardColliderPrefab);
            boardCollider.transform.parent = transform;
            boardCollider.transform.position = center;
            BoxCollider boxCollider = boardCollider.GetComponent<BoxCollider>();
            boxCollider.size = new Vector3(dimensions.x, dimensions.y, 10);
        }
    }
}
