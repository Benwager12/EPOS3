<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.la = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dataUsers = New System.Windows.Forms.DataGridView()
        Me.columnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnUsertype = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.columnPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSignIn = New System.Windows.Forms.Button()
        CType(Me.dataUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'la
        '
        Me.la.AutoSize = True
        Me.la.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.la.Location = New System.Drawing.Point(195, 41)
        Me.la.Name = "la"
        Me.la.Size = New System.Drawing.Size(169, 29)
        Me.la.TabIndex = 1
        Me.la.Text = "Manage Users"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 355)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "display users"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 343)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "add user"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(379, 325)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "remove user"
        '
        'dataUsers
        '
        Me.dataUsers.AllowUserToAddRows = False
        Me.dataUsers.AllowUserToDeleteRows = False
        Me.dataUsers.AllowUserToResizeColumns = False
        Me.dataUsers.AllowUserToResizeRows = False
        Me.dataUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dataUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnID, Me.columnUsername, Me.columnUsertype, Me.columnPoints})
        Me.dataUsers.Location = New System.Drawing.Point(26, 82)
        Me.dataUsers.Name = "dataUsers"
        Me.dataUsers.ReadOnly = True
        Me.dataUsers.RowHeadersVisible = False
        Me.dataUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dataUsers.Size = New System.Drawing.Size(507, 225)
        Me.dataUsers.TabIndex = 16
        '
        'columnID
        '
        Me.columnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.columnID.Frozen = True
        Me.columnID.HeaderText = "ID"
        Me.columnID.MinimumWidth = 75
        Me.columnID.Name = "columnID"
        Me.columnID.ReadOnly = True
        Me.columnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnID.Width = 75
        '
        'columnUsername
        '
        Me.columnUsername.Frozen = True
        Me.columnUsername.HeaderText = "Username"
        Me.columnUsername.MinimumWidth = 230
        Me.columnUsername.Name = "columnUsername"
        Me.columnUsername.ReadOnly = True
        Me.columnUsername.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnUsername.Width = 230
        '
        'columnUsertype
        '
        Me.columnUsertype.Frozen = True
        Me.columnUsertype.HeaderText = "User Type"
        Me.columnUsertype.Items.AddRange(New Object() {"1", "2", "3"})
        Me.columnUsertype.Name = "columnUsertype"
        Me.columnUsertype.ReadOnly = True
        Me.columnUsertype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'columnPoints
        '
        Me.columnPoints.Frozen = True
        Me.columnPoints.HeaderText = "Points"
        Me.columnPoints.MinimumWidth = 110
        Me.columnPoints.Name = "columnPoints"
        Me.columnPoints.ReadOnly = True
        Me.columnPoints.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnPoints.Width = 110
        '
        'btnSignIn
        '
        Me.btnSignIn.Location = New System.Drawing.Point(26, 12)
        Me.btnSignIn.Name = "btnSignIn"
        Me.btnSignIn.Size = New System.Drawing.Size(103, 41)
        Me.btnSignIn.TabIndex = 17
        Me.btnSignIn.Text = "Back to Sign In"
        Me.btnSignIn.UseVisualStyleBackColor = True
        '
        'ManageUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 418)
        Me.Controls.Add(Me.btnSignIn)
        Me.Controls.Add(Me.dataUsers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.la)
        Me.Name = "ManageUsers"
        Me.Text = "ManageUsers"
        CType(Me.dataUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents la As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dataUsers As System.Windows.Forms.DataGridView
    Friend WithEvents columnID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnUsertype As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents columnPoints As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSignIn As System.Windows.Forms.Button
End Class
