using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private GameObject _cursor = null;
    private SpriteRenderer _cursorSpriteRenderer = null;

    public Texture2D cursorTexture = null;

    void Start()
    {
        Cursor.visible = false;

        _cursorSpriteRenderer = _cursor.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        _cursor.transform.position = Helper.MousePosToWorldVec();
    }
}
