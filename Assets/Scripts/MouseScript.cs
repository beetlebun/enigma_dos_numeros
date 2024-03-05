using UnityEngine;
using UnityEngine.EventSystems;

public class MouseScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Texture2D cursor_normal;
    public Texture2D cursor_pointer;

    void Start()
    {
        Cursor.SetCursor(cursor_normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursor_pointer, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(cursor_normal, Vector2.zero, CursorMode.ForceSoftware);
    }
}
