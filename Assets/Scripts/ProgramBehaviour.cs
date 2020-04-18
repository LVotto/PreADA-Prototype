using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramBehaviour : MonoBehaviour
{
    GameController gameController;
    Vector2Int dimensions;
    Camera cam;
    [Range(0, 1)]
    public float spacing = .25f;
    [Range(0, .5f)]
    public float margin = .125f;
    public GameObject programPrefab;
    public int nTiles = 0;
    public float tileSize;
    public bool debugMode = false;
    public GameObject debugCubePrefab;
    GameObject debugCube;
    public List<Vector3> directions;
    List<KeyCode> arrowKeyCodes = new List<KeyCode> {
        KeyCode.RightArrow,
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow
    };
    GameObject programTilesObj;

    Vector3 GetFirstPosition(){
        float x = -transform.localScale.x / 2;
        x += margin;
        x += tileSize / 2;
        Vector3 position = new Vector3(
            x, transform.position.y, transform.position.z
        );
        return position;
    }

    Vector3 GetNextPosition(){
        Vector3 position = GetFirstPosition();
        position += new Vector3 (
            nTiles * (tileSize + spacing), 0, 0
        );
        return position;
    }
    Vector3 GetDirectionFromKey(KeyCode key){
        Vector3 to = Vector3.up;
        if (key == KeyCode.RightArrow){
            to = Vector3.right;
        }
        if (key == KeyCode.DownArrow){
            to = Vector3.down;
        }
        if (key == KeyCode.LeftArrow){
            to = Vector3.left;
        }
        return to;
    }
    Quaternion GetRotationFromKey(KeyCode key){
        Vector3 from = Vector3.up;
        Vector3 to = GetDirectionFromKey(key);
        return Quaternion.FromToRotation(from, to);
    }
    

    void Awake()
    {
        GameObject gameManagement = GameObject.Find("GameManagement");
        gameController = gameManagement.GetComponent<GameController>();
        dimensions = gameController.boardDimensions;
        cam = Camera.main;

        transform.position = cam.ViewportToWorldPoint(
            new Vector3 (0.5f, 1, 0)
        );
        transform.position += 8 * Vector3.forward;
        // Assumes SR tiles are squares
        tileSize = programPrefab.transform.localScale.x;
        if (debugMode){
            debugCube = Instantiate(
                debugCubePrefab, transform.position, transform.rotation
            );
        }
        programTilesObj = GameObject.Find("ProgramTiles");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ViewportToWorldPoint(
            new Vector3 (0.5f, 1, 0)
        );
        transform.position += 8 * Vector3.forward;
        transform.position += 1 * Vector3.down;
        double width = cam.orthographicSize 
                     * 2.0 * Screen.width 
                     / Screen.height;
        transform.localScale = new Vector3 (
            (float) width - 1f, 1, 1
        );
        if (debugMode){
            debugCube.transform.position = GetNextPosition();
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            nTiles++;
        }
        foreach (KeyCode key in arrowKeyCodes){
            if (Input.GetKeyDown(key)){
                Vector3 direction = GetDirectionFromKey(key);
                directions.Add(direction);
                GameObject program = Instantiate(
                    programPrefab, GetNextPosition(),
                    GetRotationFromKey(key)
                );
                program.transform.parent = programTilesObj.transform;
                program.transform.position += Vector3.back * .2f;
                nTiles++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            directions = new List<Vector3>();
            Destroy(programTilesObj);
            programTilesObj = new GameObject("ProgramTiles");
            programTilesObj.transform.parent = transform;
            nTiles = 0;
        }
    }
}
