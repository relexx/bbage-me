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


Module modMapEditor

    Public APP_EXIT As Boolean = False
    'We'll declare the Engine object as global, 
    'to allow all classes call Engine methods.
    Public engine As SpriteCraft.Engine
    Private ENGINE_CYCLES As Integer = 0
    Private thEditor As Threading.Thread
    Dim MapEditorIsRunning As Boolean = True

    Sub ShowMapEditor()
        frmToolbox.Show()
        Do
            Threading.Thread.Sleep(50)
            Application.DoEvents()
        Loop While MapEditorIsRunning
        frmToolbox.Close()
    End Sub

    Sub Main()

        thEditor = New Threading.Thread(AddressOf ShowMapEditor)
        thEditor.Start()

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

        Dim player As clsPlayer
        player = New clsPlayer

        Dim mouse As clsMouse
        mouse = New clsMouse

        Dim character As clsCharacter
        character = New clsCharacter

        Dim tracker As clsGameTracker
        tracker = New clsGameTracker
        engine.executor.Schedule(tracker)

        Do
            engine.NextEvent()

            'Pressing "Esc" key or clicking the "close window" button 
            'will result in finishing the game. However, when you write 
            'your own game, you'd typically need to re-ask the player: 
            '"do you really wanna quit?"
            If engine.EvtIsESC Or engine.EvtIsQuit Or MapEditorIsRunning = False Then Exit Do

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

        MapEditorIsRunning = False
        thEditor.Join()
    End Sub
End Module
