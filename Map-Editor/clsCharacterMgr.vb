Option Explicit On
Imports SpriteCraft
Imports SpriteCraft.tagHotspot
Imports SpriteCraft.tagQueAny

Public Class clsCharacterMgr
    Implements SpriteCraft.ICommand

    Private WALKING_SPEED_TD As Integer = 120
    Private WALKING_SPEED_LR As Integer = 200
    Private WALKING_FPS As Integer = 0

    Private sprites As SpriteCraft.ISpritesList

    Public Sub New()
        sprites = engine.NewSpritesList
        engine.executor.Schedule(Me)
    End Sub

    Public Function Execute(ByVal que As SpriteCraft.IQue) As Integer Implements SpriteCraft.ICommand.Execute
        Dim delta As Single
        Dim character As SpriteCraft.ISprite
        delta = CType(que.delta / 1000.0#, Long)
        engine.layerY(2) = engine.layerY(2) + (delta * WALKING_SPEED_TD)
        sprites.Reset()
        Do While sprites.Next
            character = sprites.Get
            If character.alive Then
                'Here we check the absolute screen y-coordinate 
                'of the asteroid, but not the relative "y"
                If character.scrY > engine.scrHeight + character.height Then
                    sprites.Remove()
                    character.Dispose()
                Else
                    character.frno = _
                      CType(((engine.frameTick / 1000.0#) * WALKING_FPS + (character.random * character.frcount)) Mod character.frcount, Integer)
                End If
            Else
                sprites.Remove()
            End If
        Loop
        Return CommandStateRepeat
    End Function
End Class
