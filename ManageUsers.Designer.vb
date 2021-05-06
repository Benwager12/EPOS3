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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.la = New System.Windows.Forms.Label()
        Me.dataUsers = New System.Windows.Forms.DataGridView()
        Me.columnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnUsertype = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.columnPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSignIn = New System.Windows.Forms.Button()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
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
        'dataUsers
        '
        Me.dataUsers.AllowUserToAddRows = False
        Me.dataUsers.AllowUserToDeleteRows = False
        Me.dataUsers.AllowUserToResizeColumns = False
        Me.dataUsers.AllowUserToResizeRows = False
        Me.dataUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnID, Me.columnUsername, Me.columnUsertype, Me.columnPoints})
        Me.dataUsers.Location = New System.Drawing.Point(26, 82)
        Me.dataUsers.Name = "dataUsers"
        Me.dataUsers.ReadOnly = True
        Me.dataUsers.RowHeadersVisible = False
        Me.dataUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
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
        Me.columnUsertype.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.columnUsertype.Frozen = True
        Me.columnUsertype.HeaderText = "User Type"
        Me.columnUsertype.Items.AddRange(New Object() {"Superuser", "Admin", "User"})
        Me.columnUsertype.Name = "columnUsertype"
        Me.columnUsertype.ReadOnly = True
        Me.columnUsertype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'columnPoints
        '
        Me.columnPoints.Frozen = True
        Me.columnPoints.HeaderText = "Password"
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
        'btnAddUser
        '
        Me.btnAddUser.Location = New System.Drawing.Point(26, 313)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(163, 32)
        Me.btnAddUser.TabIndex = 18
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(195, 313)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(169, 32)
        Me.btnUpdate.TabIndex = 19
        Me.btnUpdate.Text = "Update Users"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(370, 313)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(163, 32)
        Me.btnRemove.TabIndex = 20
        Me.btnRemove.Text = "Remove Selected"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'ManageUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 369)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddUser)
        Me.Controls.Add(Me.btnSignIn)
        Me.Controls.Add(Me.dataUsers)
        Me.Controls.Add(Me.la)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ManageUsers"
        Me.Text = "ManageUsers"
        CType(Me.dataUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents la As System.Windows.Forms.Label
    Friend WithEvents dataUsers As System.Windows.Forms.DataGridView
    Friend WithEvents btnSignIn As System.Windows.Forms.Button
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents columnID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnUsertype As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents columnPoints As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
End Class
