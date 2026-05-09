using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Tilemap groundtilemap;
    [SerializeField]
    private Tilemap collisiontilemap;
    private ChartacterInput controls;

    private void Awake()
    {
        controls = new ChartacterInput();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable(); ;
    }
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 dir)
    {
        if (CanMove(dir))
        {
            transform.position += (Vector3)dir;
        }
    }

    private bool CanMove(Vector2 dir)
    {
        Vector3Int gridPos = groundtilemap.WorldToCell(transform.position + (Vector3)dir);

        if (!groundtilemap.HasTile(gridPos) || collisiontilemap.HasTile(gridPos))
        { 
            return false;
        }
        else
            return true;
    }


}