Imports Pathfinder

Public Class PointsEditor

    Private m_grid_factor As Integer = 10
    private m_grid_points() as Point 
    Private m_polygon_mgr As PolygonManager
    Private m_draw_points() As Point

    Private Sub PointsEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub DoPaint(ByVal g As Graphics)
        ' Draw Grid
        For i As Integer = 0 To (Me.Width / m_grid_factor)

        Next
    End Sub
End Class
