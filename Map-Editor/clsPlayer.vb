Option Explicit On
Imports SpriteCraft
Imports SpriteCraft.tagHotspot
Imports SpriteCraft.tagKeyVal

Public Class clsPlayer


    'Declare IOnUpdate interface:
    Implements IOnUpdate

    'Here are some constants for the ship speed:
    Private Const WARBOT_SPEED As Integer = 120
    Private Const WARBOT_SPEED1 As Integer = 200

    'Ship movement directions: left or right, up or down.
    Private leftright As Long
    Private updown As Long

    'The "safe area" coordinates, used to prevent 
    'the ship from going outside the screen.
    Private min_x As Long
    Private max_x As Long
    Private min_y As Long
    Private max_y As Long

    'Sprites for the ship frame and its trails.
    Private warbot As SpriteCraft.ISprite
    Private leftTrak As SpriteCraft.ISprite
    Private rightTrak As SpriteCraft.ISprite

    Public Sub New()

        'A sprite for the ship frame is initially located 
        'at the center-bottom area of the screen.
        warbot = engine.NewSprite_("player_warbot", 0)
        warbot.frno = 1
        warbot.hotspot = HotspotCenter
        warbot.subimpl = Me
        warbot.x = CType(engine.scrWidth / 2, Single)
        warbot.y = engine.scrHeight - warbot.Height

        min_x = CType(warbot.width / 2, Long)
        max_x = engine.scrWidth - min_x
        min_y = CType(warbot.height / 2, Long)
        max_y = engine.scrHeight - min_y
        updown = 0
        leftright = 0

        'These trail sprites are signed as child sprites of the ship sprite. 
        'Their coordinates are relative to the ship sprite.
        leftTrak = engine.NewSprite_("player_warbot_trak", 0)
        leftTrak.Parent = warbot
        leftTrak.x = 28 - (warbot.Width / 2)
        leftTrak.y = 59 - (warbot.Height / 2)

        rightTrak = engine.NewSprite_("player_warbot_trak", 0)
        rightTrak.Parent = warbot
        rightTrak.x = 38 - (warbot.Width / 2)
        rightTrak.y = 59 - (warbot.Height / 2)
    End Sub
    Private Sub IOnUpdate_OnUpdate(ByVal self As SpriteCraft.ISprite, ByVal tickdelta As Integer) Implements IOnUpdate.OnUpdate

        'Defining new space ship coordinates.
        warbot.x = CType(warbot.x + (WARBOT_SPEED * leftright * tickdelta) / 1000.0#, Single)
        If updown > 0 Then
            warbot.y = CType(warbot.y + (WARBOT_SPEED * updown * tickdelta) / 1000.0#, Single)
        Else
            warbot.y = CType(warbot.y + (WARBOT_SPEED * updown * tickdelta) / 1000.0#, Single)
        End If

        'Defining current speed directions.
        leftright = 0
        updown = 0

        'We're using default key mapping rules (see the key definitions above).
        If engine.IsKeyPressed(Key_StLeft) Then leftright = -1
        If engine.IsKeyPressed(Key_StRight) Then leftright = leftright + 1
        If engine.IsKeyPressed(Key_StUp) Then updown = -1
        If engine.IsKeyPressed(Key_StDown) Then updown = updown + 1

        'Check that the ship doesn't leave the "safe" screen area:  
        If warbot.x < min_x Then
            warbot.x = min_x
        ElseIf warbot.x > max_x Then
            warbot.x = max_x
        End If

        If warbot.y < min_y Then
            warbot.y = min_y
        ElseIf warbot.y > max_y Then
            warbot.y = max_y
        End If

        'Depending of the ship's horizontal direction, we can change 
        'its appearance, by changing sprite's frame number.
        If leftright < 0 Then
            warbot.frno = 0
        ElseIf leftright > 0 Then
            warbot.frno = 2
        Else
            warbot.frno = 1
        End If

        'Depending of the ship's vertical direction, we can show acceleration 
        'or deceleration, by scaling its trails vertically.
        If updown < 0 Then
            leftTrak.yScale = 150
            rightTrak.yScale = 150
        ElseIf updown > 0 Then
            leftTrak.yScale = 50
            rightTrak.yScale = 50
        Else
            leftTrak.yScale = 100
            rightTrak.yScale = 100
        End If

    End Sub
End Class
