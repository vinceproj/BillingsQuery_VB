<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CustomersTableAdapter1 = New frmMicroland.Microland_DatabaseDataSetTableAdapters.CustomersTableAdapter()
        Me.Microland_DatabaseDataSet1 = New frmMicroland.Microland_DatabaseDataSet()
        Me.InventoryTableAdapter1 = New frmMicroland.Microland_DatabaseDataSetTableAdapters.InventoryTableAdapter()
        Me.OrdersTableAdapter1 = New frmMicroland.Microland_DatabaseDataSetTableAdapters.OrdersTableAdapter()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnStock = New System.Windows.Forms.Button()
        Me.btnBills = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        CType(Me.Microland_DatabaseDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomersTableAdapter1
        '
        Me.CustomersTableAdapter1.ClearBeforeFill = True
        '
        'Microland_DatabaseDataSet1
        '
        Me.Microland_DatabaseDataSet1.DataSetName = "Microland_DatabaseDataSet"
        Me.Microland_DatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InventoryTableAdapter1
        '
        Me.InventoryTableAdapter1.ClearBeforeFill = True
        '
        'OrdersTableAdapter1
        '
        Me.OrdersTableAdapter1.ClearBeforeFill = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Customers"
        Me.BindingSource1.DataSource = Me.Microland_DatabaseDataSet1
        '
        'BindingSource2
        '
        Me.BindingSource2.DataMember = "Inventory"
        Me.BindingSource2.DataSource = Me.Microland_DatabaseDataSet1
        '
        'BindingSource3
        '
        Me.BindingSource3.DataMember = "Orders"
        Me.BindingSource3.DataSource = Me.Microland_DatabaseDataSet1
        '
        'btnStock
        '
        Me.btnStock.Location = New System.Drawing.Point(11, 12)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(119, 46)
        Me.btnStock.TabIndex = 0
        Me.btnStock.Text = "Out of Stock Items"
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'btnBills
        '
        Me.btnBills.Location = New System.Drawing.Point(138, 12)
        Me.btnBills.Name = "btnBills"
        Me.btnBills.Size = New System.Drawing.Size(119, 46)
        Me.btnBills.TabIndex = 1
        Me.btnBills.Text = "Bills for Today's Orders"
        Me.btnBills.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(12, 64)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(245, 225)
        Me.lstOutput.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 304)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.btnBills)
        Me.Controls.Add(Me.btnStock)
        Me.Name = "Form1"
        Me.Text = "Microland"
        CType(Me.Microland_DatabaseDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CustomersTableAdapter1 As Microland_DatabaseDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents Microland_DatabaseDataSet1 As Microland_DatabaseDataSet
    Friend WithEvents InventoryTableAdapter1 As Microland_DatabaseDataSetTableAdapters.InventoryTableAdapter
    Friend WithEvents OrdersTableAdapter1 As Microland_DatabaseDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents BindingSource3 As BindingSource
    Friend WithEvents btnStock As Button
    Friend WithEvents btnBills As Button
    Friend WithEvents lstOutput As ListBox
End Class
