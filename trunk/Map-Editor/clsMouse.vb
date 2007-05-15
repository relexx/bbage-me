Option Explicit On
Imports SpriteCraft
Imports SpriteCraft.tagHotspot

Public Class clsMouse
    'Declare IOnUpdate interface:
    Implements IOnUpdate

    'Here are some constants for the ship speed:
    Private Const WARBOT_SPEED As Integer = 120
    Private Const WARBOT_SPEED1 As Integer = 200

    ''Sprites for the ship frame and its trails.
    Private cursor As SpriteCraft.ISprite

    Public Sub New()
        'A sprite for the ship frame is initially located 
        'at the center-bottom area of the screen.
        cursor = engine.NewSprite_("mouse_cursor", 0)
        cursor.frno = 1
        cursor.hotspot = HotspotLeftTop
        cursor.subimpl = Me
        cursor.x = CType(engine.scrWidth / 2 + 200, Single)
        cursor.y = engine.scrHeight - cursor.height
    End Sub
    Private Sub IOnUpdate_OnUpdate(ByVal self As SpriteCraft.ISprite, ByVal tickdelta As Integer) Implements IOnUpdate.OnUpdate
        If engine.mouseIn = True Then
            cursor.visible = True
            cursor.x = engine.mouseX
            cursor.y = engine.mouseY
        Else
            cursor.visible = False
        End If
    End Sub
End Class
