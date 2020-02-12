'Description:   Create a form that reads data from a database and outputs wanted information

Public Class Form1 'Form name could not be altered without causing breaking errors; Multiple fix attempts unsuccessful
    'Structs to hold item, order, and customer information
    Private Structure Item
        Public itemName As String
        Public itemQuantity As Integer
        Public itemDescription As String
        Public itemPrice As Double
    End Structure

    Private Structure Order
        Public custID As String
        Public itemID As String
        Public orderQuantity As Integer
    End Structure

    Private Structure Customer
        Public custID As Integer
        Public custName As String
        Public custStreet As String
        Public custCity As String
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try-Catch to set adapters with information
        Try
            Me.InventoryTableAdapter1.Fill(Me.Microland_DatabaseDataSet1.Inventory)
            Me.CustomersTableAdapter1.Fill(Me.Microland_DatabaseDataSet1.Customers)
            Me.OrdersTableAdapter1.Fill(Me.Microland_DatabaseDataSet1.Orders)
        Catch
            MessageBox.Show("Failed to upload database")
            End
        End Try
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        lstOutput.Items.Clear()

        'Vars for total items, itemArray to hold item objects, itemArray counter
        Dim intItemsTotal As Integer = BindingSource2.Count
        Dim itemsArray(intItemsTotal - 1) As Item
        Dim itemsArrayCounter As Integer = 0

        'Query for all inventory
        Dim queryItemStart = From itemStart In Microland_DatabaseDataSet1.Inventory
                             Order By itemStart.itemID Descending
                             Select itemStart.itemID, itemStart.quantity, itemStart.description

        'Create item objects for each item
        For Each itemFound In queryItemStart
            itemsArray(itemsArrayCounter).itemName = itemFound.itemID
            itemsArray(itemsArrayCounter).itemQuantity = itemFound.quantity
            itemsArray(itemsArrayCounter).itemDescription = itemFound.description
            itemsArrayCounter += 1
        Next


        'Find quantity changes from all orders
        Dim queryItemOrders = From itemOrders In Microland_DatabaseDataSet1.Orders
                              Select itemOrders.itemID, itemOrders.quantity

        'For all quantity changes check with all item objects for a match and change the quantity
        For Each itemChange In queryItemOrders
            For Index = 0 To itemsArrayCounter - 1
                If itemChange.itemID = itemsArray(Index).itemName Then
                    itemsArray(Index).itemQuantity -= itemChange.quantity
                End If
            Next
        Next

        'Initial output
        lstOutput.Items.Add("Here are the items that are out of")
        lstOutput.Items.Add("inventory or must be reordered")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("The numbers shown give the")
        lstOutput.Items.Add("minimum reorder quantity required")
        lstOutput.Items.Add("")

        'For item objects if the new quantity <= 0 and it is a valid object then output
        For Each itemIndex In itemsArray
            If itemIndex.itemQuantity <= 0 Then
                lstOutput.Items.Add(itemIndex.itemName + " " + (itemIndex.itemQuantity * -1).ToString + " " + itemIndex.itemDescription)
            End If
        Next


    End Sub

    Private Sub btnBills_Click(sender As Object, e As EventArgs) Handles btnBills.Click
        lstOutput.Items.Clear()

        'Vars for total customers/orders, customerArray/ordersArray, customerCount/ordersCount
        Dim intCustTotal As Integer = BindingSource1.Count
        Dim intOrdersTotal As Integer = BindingSource3.Count
        Dim custArray(intCustTotal - 1) As Customer
        Dim ordersArray(intOrdersTotal - 1) As Order
        Dim intCustCounter As Integer = 0
        Dim intOrdersCounter As Integer = 0

        'Find all order information
        Dim queryOrders = From itemOrders In Microland_DatabaseDataSet1.Orders
                          Select itemOrders.custID, itemOrders.itemID, itemOrders.quantity

        'Create order objects
        For Each orderFound In queryOrders
            ordersArray(intOrdersCounter).custID = orderFound.custID
            ordersArray(intOrdersCounter).itemID = orderFound.itemID
            ordersArray(intOrdersCounter).orderQuantity = orderFound.quantity
            intOrdersCounter += 1
        Next

        'Find all customer information
        Dim queryCustomers = From custFound In Microland_DatabaseDataSet1.Customers
                             Select custFound.custID, custFound.name, custFound.street, custFound.city

        'Create customer objects
        For Each custFound In queryCustomers
            custArray(intCustCounter).custID = custFound.custID
            custArray(intCustCounter).custName = custFound.name
            custArray(intCustCounter).custStreet = custFound.street
            custArray(intCustCounter).custCity = custFound.city
            intCustCounter += 1
        Next

        'For each customer check for their orders
        For Each custFound In custArray
            'Flags for proper output and handling
            Dim bolNamePrint As Boolean = False
            Dim bolCostPrint As Boolean = False
            Dim dblTotalCost As Double = 0

            'For each order check if they match the current customer; Handle output
            For Each orderFound In ordersArray
                If custFound.custID = orderFound.custID Then
                    'For initial info print
                    If bolNamePrint = False Then
                        lstOutput.Items.Add(custFound.custName)
                        lstOutput.Items.Add(custFound.custStreet)
                        lstOutput.Items.Add(custFound.custCity)
                        lstOutput.Items.Add("")
                        bolNamePrint = True
                    End If

                    'Output items; Use functions to get proper information; Calculate running total
                    lstOutput.Items.Add(orderFound.orderQuantity.ToString + " " + getItemName(orderFound.itemID) + " " + FormatCurrency(orderFound.orderQuantity * CDbl(getItemPrice(orderFound.itemID))))
                    dblTotalCost += orderFound.orderQuantity * CDbl(getItemPrice(orderFound.itemID))
                    bolCostPrint = True

                End If

            Next

            'Output handling
            If bolCostPrint = True Then
                lstOutput.Items.Add("Total Cost: " + FormatCurrency(dblTotalCost.ToString))
            End If
            lstOutput.Items.Add("")
        Next


    End Sub

    'Take in an itemID and get a description name
    Public Function getItemName(itemName As String)
        'Query for result
        Dim queryName = From item In Microland_DatabaseDataSet1.Inventory
                        Where item.itemID = itemName
                        Select item.description

        'For to hold output
        Dim itemFound As String = ""

        'Clone query result into string for output
        For Each queryItem In queryName
            itemFound = queryItem.Clone
        Next

        Return itemFound
    End Function

    'Take in an itemID and get the item price
    Public Function getItemPrice(itemName As String)
        'Query for result
        Dim queryPrice = From item In Microland_DatabaseDataSet1.Inventory
                         Where item.itemID = itemName
                         Select item.price

        'For to hold output
        Dim itemFound As String = ""

        'Clone query result into string for output
        For Each queryItem In queryPrice
            itemFound = queryItem.ToString.Clone
        Next

        Return itemFound
    End Function
End Class
