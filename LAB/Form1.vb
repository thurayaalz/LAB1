Imports System.Data.OleDb

Public Class Lab
    '------------------------------------LAB1------------------------------------------
    Public Sub even()
        Dim sr As String = ""
        For i = 0 To 20 Step 2
            sr &= i & vbCrLf
        Next
        MsgBox(sr)
    End Sub
    Public i As Integer = InputBox("write the Num: ")
    Public d As Integer
    Function maxno(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer) As Integer
        d = a
        If d < b And b > c Then
            d = b
        ElseIf d < c Then
            d = c
        End If
        Return d
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a = Val(TextBox1.Text)
        Dim b = Val(TextBox2.Text)
        Dim c = Val(TextBox3.Text)
        d = maxno(a, b, c)
        Label3.Text = d
    End Sub

    '------------------------------------LAB2------------------------------------------
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
    End Sub
    Function maj(ByVal x As Integer) As String

        ListBox1.Items.Add(x)
        If x >= 87 Then
            Return ListBox2.Items.Add("science")
        ElseIf x >= 77.2 Then
            Return ListBox2.Items.Add("literature")
        ElseIf x >= 61.4 Then
            Return ListBox2.Items.Add("commerce")
        ElseIf x >= 50 Then
            Return ListBox2.Items.Add("military")
        Else
            Return ListBox2.Items.Add("F")

        End If
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Integer
        For i = 0 To 3
            x = InputBox("grade :")
            maj(x)
        Next
    End Sub
    '------------------------------------LAB3------------------------------------------
    Public Class box
        Public l, h, b As Integer
        Function vol(ByVal l As Integer, ByVal b As Integer, ByVal h As Integer) As Integer
            l = InputBox("what l ")
            h = InputBox("what h ")
            b = InputBox("what b ")
            Return l * b * h
        End Function
        Protected Overrides Sub finalize()
            MessageBox.Show("The Object was created Now Die")
        End Sub

    End Class
    Function mult(ByVal i As Integer) As Integer
        Dim re As Integer
        For j = 0 To i
            re += i * j
        Next
        Return re
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim box1 As New box
        Label1.Text = box1.vol(box1.l, box1.b, box1.b)
        db.Reset()
        sql = "SELECT * FROM drivers"
        dbcon.Open()
        Dim ada As New OleDb.OleDbDataAdapter(sql, dbcon)
        ada.Fill(db, "drivers")
        dbcon.Close()

        id.DataBindings.Add("text", db, "drivers.DriverID")
        nam.DataBindings.Add("text", db, "drivers.DName")
        nu.DataBindings.Add("text", db, "drivers.DNumber")
        ma.DataBindings.Add("text", db, "drivers.CarMaker")
        mo.DataBindings.Add("text", db, "drivers.CarModel")
        ra.DataBindings.Add("text", db, "drivers.RatingID")

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fe As Integer = mult(i)
        MsgBox(fe)
    End Sub
    '------------------------------------LAB4------------------------------------------
    Public Class cal
        Public x, z As Integer


        Function sum(ByVal x As Integer, ByVal z As Integer) As Integer
            Return z + x
        End Function
        Function tak(ByVal x As Integer, ByVal z As Integer) As Integer
            Return z - x
        End Function
        Function div(ByVal x As Integer, ByVal z As Integer) As Integer
            Return z \ x
        End Function

        Function muli(ByVal x As Integer, ByVal z As Integer) As Integer
            Return z * x
        End Function

    End Class

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim no As New cal
        Label2.Text = no.sum(ca2.Text, ca1.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim no As New cal
        Label2.Text = no.muli(ca2.Text, ca1.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim no As New cal
        Label2.Text = no.tak(ca2.Text, ca1.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim no As New cal
        Label2.Text = no.div(ca2.Text, ca1.Text)
    End Sub


    '------------------------------------LAB5------------------------------------------

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Dim con As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source=" & Application.StartupPath & "\database11.accdb"
        ' Dim dbcon As New OleDb.OleDbConnection(con)
        Dim sql As String = "SELECT * FROM drivers"
        Dim ada As New OleDb.OleDbDataAdapter(sql, dbcon)

        ada.Fill(db)
        DataGridView1.DataSource = db.Tables(0)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim sev As New OleDbCommand
        sev.Connection = dbcon
        sev.CommandType = CommandType.Text
        Dim sql As String = "INSERT INTO drivers (DriverID, DName, DNumber, CarMaker, CarModel, RatingID) VALUES ('" & InputBox("id") & "','" & InputBox("name") & "','" & InputBox("Number") & "','" & InputBox("CarMaker") & "', '" & InputBox("CarModel") & "', '" & InputBox("Rating") & "')"
        sev.CommandText = sql

        dbcon.Open()
        sev.ExecuteNonQuery()
        dbcon.Close()
        MsgBox("done")
        pos()

    End Sub
    '------------------------------------LAB6------------------------------------------
    Public Sub pos()
        Label4.Text = Me.BindingContext(db, "drivers").Position + 1 & " of " & Me.BindingContext(db, "drivers").Count
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.BindingContext(db, "drivers").Position = 0
        pos()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.BindingContext(db, "drivers").Position += 1
        pos()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.BindingContext(db, "drivers").Position -= 1
        pos()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.BindingContext(db, "drivers").Position = Me.BindingContext(db, "drivers").Count - 1
        pos()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        End
    End Sub
End Class
