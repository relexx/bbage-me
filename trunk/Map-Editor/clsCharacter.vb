Option Explicit On
Imports SpriteCraft
Imports SpriteCraft.tagHotspot
Imports SpriteCraft.tagKeyVal

Public Class clsCharacter
    'Declare IOnUpdate interface:
    Implements IOnUpdate

    'Here are some constants for the ship speed:
    Private WALKING_SPEED As Single = 250
    'Private WALKING_SPEED_TD As Single = 120
    'Private WALKING_SPEED_LR As Single = 200
    Private WALKING_WALKTO_X As Single
    Private WALKING_WALKTO_Y As Single
    Private WALKING_TOLERANCE As Single = 8
    Private FRAME_SKIPPING As Integer = 0


    'Ship movement directions: left or right, up or down.
    Private leftright As Integer
    Private updown As Integer

    'Sprites for the ship frame and its trails.
    Private character As SpriteCraft.ISprite

    Public Sub New()
        leftright = 0
        updown = 0
        'A sprite for the ship frame is initially located 
        'at the center-bottom area of the screen.
        character = engine.NewSprite_("character", 0)
        character.frno = 38
        'warbot.hotspot = HotspotLeftTop
        character.subimpl = Me
        character.x = CType(engine.scrWidth / 2 + 200, Single)
        character.y = engine.scrHeight - character.height
        WALKING_WALKTO_X = character.x
        WALKING_WALKTO_Y = character.y
    End Sub

    Private Sub IOnUpdate_OnUpdate(ByVal self As SpriteCraft.ISprite, ByVal tickdelta As Integer) Implements IOnUpdate.OnUpdate
        'If engine.IsKeyPressed(tagKeyVal.Key_LEFT) = True Then
        '    character.visible = True

        '    character.x = CType(engine.scrWidth / 2 + 200, Single)
        '    character.y = engine.scrHeight - character.height
        'ElseIf engine.IsKeyPressed(tagKeyVal.Key_RIGHT) = True Then
        '    character.visible = True

        '    character.x = CType(engine.scrWidth / 2 + 200, Single)
        '    character.y = engine.scrHeight - character.height
        'Else
        character.visible = True
        ' Differenzen berechnen
        Dim xDiff As Double = Math.Abs(WALKING_WALKTO_X - character.x)
        Dim yDiff As Double = Math.Abs(WALKING_WALKTO_Y - character.y)

        ' Restliche Strecke berechnen (Pythagoras)
        Dim dblRemain As Double = Math.Sqrt(xDiff ^ 2 + yDiff ^ 2)
        Dim dblStep As Double = 0
        ' Falls noch Weg zurückgelegt werden muss
        If dblRemain > (WALKING_TOLERANCE) Then
            dblStep = ((WALKING_SPEED * tickdelta) / 1000.0#)
            character.x = CType(character.x + ((dblStep * xDiff) / dblRemain) * leftright, Single)
            character.y = CType(character.y + ((dblStep * yDiff) / dblRemain) * updown, Single)
        End If

        'character.y = CType(character.y + (WALKING_SPEED_TD * updown * tickdelta) / 1000.0#, Single)
        'End If

        'Defining current speed directions.
        leftright = 0
        updown = 0

        'We're using default key mapping rules (see the key definitions above).
        If WALKING_WALKTO_X < character.x Then leftright = -1
        If WALKING_WALKTO_X > character.x Then leftright = 1
        If WALKING_WALKTO_Y < character.y Then updown = -1
        If WALKING_WALKTO_Y > character.y Then updown = 1
        If Math.Abs(WALKING_WALKTO_X - character.x) < (tickdelta / 10) Then leftright = 0
        If Math.Abs(WALKING_WALKTO_Y - character.y) < (tickdelta / 10) Then updown = 0
    End Sub

    Public Property FrameSkipping() As Integer
        Get
            Return FRAME_SKIPPING
        End Get
        Set(ByVal value As Integer)
            FRAME_SKIPPING = value
        End Set
    End Property

    'Public Property WalkingSpeedLR() As Single
    '    Get
    '        Return WALKING_SPEED_LR
    '    End Get
    '    Set(ByVal value As Single)
    '        WALKING_SPEED_LR = value
    '    End Set
    'End Property

    'Public Property WalkingSpeedTD() As Single
    '    Get
    '        Return WALKING_SPEED_TD
    '    End Get
    '    Set(ByVal value As Single)
    '        WALKING_SPEED_TD = value
    '    End Set
    'End Property

    Public Property WalkToX() As Single
        Get
            Return WALKING_WALKTO_X
        End Get
        Set(ByVal value As Single)
            WALKING_WALKTO_X = value
        End Set
    End Property

    Public Property WalkToY() As Single
        Get
            Return WALKING_WALKTO_Y
        End Get
        Set(ByVal value As Single)
            WALKING_WALKTO_Y = value
        End Set
    End Property
End Class
