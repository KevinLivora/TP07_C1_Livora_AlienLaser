using UnityEngine;

[DefaultExecutionOrder(100)]
public class ParallaxLayer : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float followFactor = 0.5f;

    private Transform cameraTransform;
    private Transform[] tiles;
    private float tileWidth;
    private float startCameraX;
    private float startX;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;

        tiles = new Transform[transform.childCount];
        for (int i = 0; i < tiles.Length; i++)
            tiles[i] = transform.GetChild(i);

        tileWidth = tiles[0].GetComponent<SpriteRenderer>().bounds.size.x;

        for (int i = 0; i < tiles.Length; i++)
        {
            Vector3 localPosition = tiles[i].localPosition;
            localPosition.x = tileWidth * (i - (tiles.Length - 1) / 2f);
            tiles[i].localPosition = localPosition;
        }
    }

    private void Start()
    {
        startCameraX = cameraTransform.position.x;
        startX = transform.position.x;
    }

    private void LateUpdate()
    {
        float cameraX = cameraTransform.position.x;

        Vector3 position = transform.position;
        position.x = startX + (cameraX - startCameraX) * followFactor;
        transform.position = position;

        float totalWidth = tileWidth * tiles.Length;

        foreach (Transform tile in tiles)
        {
            float offset = tile.position.x - cameraX;

            if (offset < -totalWidth / 2f)
                tile.position += Vector3.right * totalWidth;
            else if (offset > totalWidth / 2f)
                tile.position -= Vector3.right * totalWidth;
        }
    }
}
