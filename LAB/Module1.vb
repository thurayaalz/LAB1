Module Module1
    '
    Public con As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source=" & Application.StartupPath & "\database11.accdb"
    Public dbcon As New OleDb.OleDbConnection(con)
    Public sql As String
    Public ada As New OleDb.OleDbDataAdapter(sql, dbcon)
    Public db As New DataSet

End Module
