Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Public Class frmSAV
    Function md5_hash(ByVal file_name As String)
        Return hash_generator("md5", file_name)
    End Function
    Function hash_generator(ByRef hash_type As String, ByRef file_name As String)
        Dim hash
        hash = MD5.Create
        Dim hashValue() As Byte
        Dim filestream As FileStream = File.OpenRead(file_name)
        filestream.Position = 0
        hashValue = hash.ComputeHash(filestream)
        Dim hash_hex = PrintByteArray(hashValue)
        filestream.Close()
        Return hash_hex
    End Function
    Public Function PrintByteArray(ByRef array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("x2")
        Next i
        Return hex_value.ToLower
    End Function
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim path As String = OpenFileDialog1.FileName
            txtFilePath.Text = path
            Dim sample As String
            sample = md5_hash(path)
            txtHash.Text = md5_hash(path)
        End If
    End Sub
End Class
