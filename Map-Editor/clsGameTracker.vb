Option Explicit On
Imports SpriteCraft

Class clsGameTracker
    Implements ICommand

    'The game tracker will refer to both background tilemaps, 
    'thus we must declare corresponding variables:
    Private bg0 As ITileMap
    Private bg1 As ITileMap

    Public Function Execute(ByVal que As SpriteCraft.IQue) As Integer Implements SpriteCraft.ICommand.Execute


        'Repeat the command in the next game frame
        Return SpriteCraft.tagQueAny.CommandStateRepeat
    End Function
End Class
