Public Class frmToolbox
    Dim output As clsOutput

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTools.SelectedIndexChanged
        If lvwTools.SelectedItems.Count > 0 Then Me.Text = My.Application.Info.Title & " (" & lvwTools.SelectedItems(0).Text & ")"
    End Sub

    Private Sub frmToolbox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        backWorker.RunWorkerAsync()
    End Sub

    'Private Sub backWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backWorker.DoWork
    '    output = New clsOutput()
    '    'output.Main()
    '    output = Nothing
    'End Sub

    'Private Sub backWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backWorker.RunWorkerCompleted
    '    output = Nothing
    'End Sub

    Private Sub mnuItemQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemQuit.Click
        Dim MapEditorIsRunning As Boolean = False
        Me.Close()
    End Sub
End Class