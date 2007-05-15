Imports SpriteCraft
'Imports SpriteCraft.tagCollideGroup
'Imports SpriteCraft.tagEventType
'Imports SpriteCraft.tagHotspot
'Imports SpriteCraft.tagKeyState
Imports SpriteCraft.tagKeyVal
Imports SpriteCraft.tagPosition
'Imports SpriteCraft.tagQueAny
'Imports SpriteCraft.tagQueState
Imports SpriteCraft.tagScDevice
'Imports SpriteCraft.tagVideoMode

Public Class clsOutput
    Private ENGINE_CYCLES As Integer = 0

    Private player As clsPlayer
    Private character As clsCharacter
    Private mouse As clsMouse
    Private tracker As clsGameTracker

    Sub New()
        'First of all, we need to create an Engine instance 
        'to control our graphic window and to create all 
        'other graphic objects.
        engine = New SpriteCraft.Engine
        engine.logging = True

        'Then we have to initialize the engine. "To initialize" means 
        'to create devices for video and sound output and user input. 
        'Here we've chosen auto-detection of graphic device without 
        'usage of DirectInput.
        engine.Init(DevAuto)

        'Now we can set some window properties: background color, 
        'window location, and enable FPS displaying. 
        'This window will use default 640x480 video mode.
        engine.background.color = &H202020
        engine.SST = "../../common.sst"
        engine.PlaceWindowAt(PositionCenter)
        engine.showFps = True

        player = New clsPlayer

        mouse = New clsMouse

        character = New clsCharacter

        tracker = New clsGameTracker
        engine.executor.Schedule(tracker)
    End Sub
    Sub Main()
        Do
            engine.NextEvent()

            'Pressing "Esc" key or clicking the "close window" button 
            'will result in finishing the game. However, when you write 
            'your own game, you'd typically need to re-ask the player: 
            '"do you really wanna quit?"
            If engine.EvtIsESC Or engine.EvtIsQuit Then Exit Do

            'F4 key is used to toggle fullscreen and windowed modes. 
            'See how it's easy!
            If engine.EvtIsKeyDown And engine.EvtKey = Key_F4 Then engine.fullscreen = Not engine.fullscreen

            If engine.mouseLDown = True Then
                character.WalkToX = engine.mouseX
                character.WalkToY = engine.mouseY
            End If
            engine.title = My.Application.Info.Title & " - (" & ENGINE_CYCLES & ")"
            'Now we redraw all graphics and set frame duration 
            'for 30 milliseconds, which results in the maximum of 33 FPS.
            engine.DisplayEx(ENGINE_CYCLES)
        Loop
        'After finishing the main loop (when "exit" 
        'event occurred), we must destroy all SpriteCraft objects.
        engine.Purge()

        engine = Nothing
    End Sub
End Class
