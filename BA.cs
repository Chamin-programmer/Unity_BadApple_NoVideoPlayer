using UnityEngine;

public class BA : MonoBehaviour
{
    [SerializeField, Header("Speed"), Range(1, 100)]
    public float speed = 50f;
    void Update()
    {
        int i;
        for (i = 1; i <= 2628;)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Textures");
            var index = (int)Mathf.Repeat(Time.frameCount * speed / 100, sprites.Length);
            var renderer = GetComponent<MeshRenderer>();
            var material = renderer.material;

            var sprite = sprites[index];
            var texSize = new Vector2(sprite.texture.width, sprite.texture.height);
            var rect = sprite.textureRect;
            material.mainTexture = sprite.texture;
            material.mainTextureOffset = new Vector2(rect.x / texSize.x, rect.y / texSize.y);
            material.mainTextureScale = new Vector2(rect.width / texSize.x, rect.height / texSize.y);
            material.SetTexture("BAMat", sprite.texture);
            material.SetTextureOffset("BAMat", new Vector2(rect.x, rect.y));
            material.SetTextureScale("BAMat", new Vector2(1 / rect.width, 1 / rect.height));

            renderer.material = material;
            return;
        }
    }
}
