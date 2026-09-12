Imports System.Drawing
Imports System.Windows.Forms

Namespace CarDealershipPOS
    Friend NotInheritable Class UiTheme
        Private Sub New()
        End Sub
        Public Shared ReadOnly Navy As Color = Color.FromArgb(15, 39, 59)
        Public Shared ReadOnly Blue As Color = Color.FromArgb(39, 137, 216)
        Public Shared ReadOnly Light As Color = Color.FromArgb(244, 247, 250)
        Public Shared ReadOnly Green As Color = Color.FromArgb(40, 137, 75)
        Public Shared ReadOnly Red As Color = Color.FromArgb(198, 48, 48)
        Public Shared ReadOnly Muted As Color = Color.FromArgb(100, 112, 125)
        Public Shared Sub StyleGrid(grid As DataGridView)
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            grid.BackgroundColor = Color.White
            grid.BorderStyle = BorderStyle.FixedSingle
            grid.ReadOnly = True
            grid.MultiSelect = False
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grid.AllowUserToAddRows = False
            grid.AllowUserToDeleteRows = False
            grid.RowHeadersVisible = False
            grid.EnableHeadersVisualStyles = False
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 245)
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(20, 35, 50)
            grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            grid.ColumnHeadersHeight = 36
            grid.RowTemplate.Height = 32
            grid.DefaultCellStyle.Padding = New Padding(4, 2, 4, 2)
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 237, 250)
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 35, 50)
        End Sub
    End Class
End Namespace
