using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasColliderSetter : MonoBehaviour
{
    public BoxCollider2D collider2D;

    private void Awake()
    {
        var rect = (RectTransform)transform;
        var rt = rect.rect;
        var collider2DSize = collider2D.size;
        collider2DSize.x = rt.width;
        collider2DSize.y = rt.height;
        collider2D.size = collider2DSize;

    }
}
