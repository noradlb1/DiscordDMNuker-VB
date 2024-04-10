Imports System
Imports System.Windows.Forms
Imports System.Runtime.CompilerServices

Namespace DiscordDMNuker.Extensions
    Public Module Extensions
        <Extension()>
        Friend Sub SafeChangeText(ByVal item As ToolStripItem, ByVal value As String)
            If item.Owner IsNot Nothing AndAlso item.Owner.InvokeRequired Then
                item.Owner.Invoke(Sub() item.SafeChangeText(value))
                Return
            End If

            item.Text = "Status: " & value
        End Sub

        <Extension()>
        Friend Sub SafeChangeText(ByVal item As Label, ByVal value As String)
            If item IsNot Nothing AndAlso item.InvokeRequired Then
                item.Invoke(Sub() item.SafeChangeText(value))
                Return
            End If

            item.Text = "Status: " & value
        End Sub

        <Extension()>
        Friend Sub SafeAddItem(ByVal item As ListBox, ByVal value As String)
            If item IsNot Nothing AndAlso item.InvokeRequired Then
                item.Invoke(Sub() item.SafeAddItem(value))
                Return
            End If
            item.Items.Add(String.Format("[{0}]  -{1}", String.Format("{0:dd/MM/yyyy HH:mm:ss}", Date.Now), value))
        End Sub

        <Extension()>
        Friend Sub UpdateCell(ByVal row As DataGridViewRow, ByVal i As Integer, ByVal value As Object)
            If i > row.Cells.Count - 1 Then
                Return
            End If

            If row.DataGridView IsNot Nothing AndAlso row.DataGridView.InvokeRequired Then
                row.DataGridView.Invoke(Sub() row.UpdateCell(i, value))
                Return
            End If

            row.Cells(i).Value = value
        End Sub

        <Extension()>
        Friend Sub Invoke(ByVal control As Control, ByVal action As Action)
            control.Invoke(action)
        End Sub
    End Module
End Namespace
