#Region " Imports "

Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

#End Region

'|------DO-NOT-REMOVE------|
'
' Creator: HazelDev
' Site   : HazelDev.com
' Created: 23.Jul.2014
' Changed: 29.Sep.2014
' Version: 1.3.0
'
'|------DO-NOT-REMOVE------|

Namespace iTalk

#Region " RoundRect "

    ' [CREDIT][DO NOT REMOVE]
    '
    ' This module was written by Aeonhack
    '
    ' [CREDIT][DO NOT REMOVE]

    Module RoundRectangle
        Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
            Dim GP As GraphicsPath = New GraphicsPath()
            Dim EndArcWidth As Integer = Curve * 2
            GP.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90)
            GP.AddArc(New Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90)
            GP.AddArc(New Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90)
            GP.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90)
            GP.AddLine(New Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
            Return GP
        End Function

        Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
            Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
            Dim GP As GraphicsPath = New GraphicsPath()
            Dim EndArcWidth As Integer = Curve * 2
            GP.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90)
            GP.AddArc(New Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90)
            GP.AddArc(New Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90)
            GP.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90)
            GP.AddLine(New Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
            Return GP
        End Function
    End Module

#End Region

#Region " Control Renderer "

#Region " Color Table "

    Public MustInherit Class xColorTable
        Public MustOverride ReadOnly Property TextColor As Color
        Public MustOverride ReadOnly Property Background As Color
        Public MustOverride ReadOnly Property SelectionBorder As Color
        Public MustOverride ReadOnly Property SelectionTopGradient As Color
        Public MustOverride ReadOnly Property SelectionMidGradient As Color
        Public MustOverride ReadOnly Property SelectionBottomGradient As Color
        Public MustOverride ReadOnly Property PressedBackground As Color
        Public MustOverride ReadOnly Property CheckedBackground As Color
        Public MustOverride ReadOnly Property CheckedSelectedBackground As Color
        Public MustOverride ReadOnly Property DropdownBorder As Color
        Public MustOverride ReadOnly Property Arrow As Color
        Public MustOverride ReadOnly Property OverflowBackground As Color
    End Class

    Public MustInherit Class ColorTable
        Public MustOverride ReadOnly Property CommonColorTable As xColorTable
        Public MustOverride ReadOnly Property BackgroundTopGradient As Color
        Public MustOverride ReadOnly Property BackgroundBottomGradient As Color
        Public MustOverride ReadOnly Property DroppedDownItemBackground As Color
        Public MustOverride ReadOnly Property DropdownTopGradient As Color
        Public MustOverride ReadOnly Property DropdownBottomGradient As Color
        Public MustOverride ReadOnly Property Separator As Color
        Public MustOverride ReadOnly Property ImageMargin As Color
    End Class

    Public Class MSColorTable
        Inherits ColorTable

        Private _CommonColorTable As xColorTable

        Public Sub New()
            _CommonColorTable = New DefaultCColorTable()
        End Sub

        Public Overrides ReadOnly Property CommonColorTable As xColorTable
            Get
                Return _CommonColorTable
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundTopGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(246, 246, 246)
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundBottomGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(226, 226, 226)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownTopGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(246, 246, 246)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownBottomGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(246, 246, 246)
            End Get
        End Property

        Public Overrides ReadOnly Property DroppedDownItemBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(240, 240, 240)
            End Get
        End Property

        Public Overrides ReadOnly Property Separator As System.Drawing.Color
            Get
                Return Color.FromArgb(190, 195, 203)
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMargin As System.Drawing.Color
            Get
                Return Color.FromArgb(240, 240, 240)
            End Get
        End Property
    End Class

    Public Class DefaultCColorTable
        Inherits xColorTable

        Public Overrides ReadOnly Property CheckedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(230, 230, 230)
            End Get
        End Property

        Public Overrides ReadOnly Property CheckedSelectedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(230, 230, 230)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectionBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(180, 180, 180)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectionTopGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(240, 240, 240)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectionMidGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(235, 235, 235)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectionBottomGradient As System.Drawing.Color
            Get
                Return Color.FromArgb(230, 230, 230)
            End Get
        End Property

        Public Overrides ReadOnly Property PressedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(232, 232, 232)
            End Get
        End Property

        Public Overrides ReadOnly Property TextColor As System.Drawing.Color
            Get
                Return Color.FromArgb(80, 80, 80)
            End Get
        End Property

        Public Overrides ReadOnly Property Background As System.Drawing.Color
            Get
                Return Color.FromArgb(188, 199, 216)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownBorder As System.Drawing.Color
            Get
                Return Color.LightGray
            End Get
        End Property

        Public Overrides ReadOnly Property Arrow As System.Drawing.Color
            Get
                Return Color.Black
            End Get
        End Property

        Public Overrides ReadOnly Property OverflowBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(213, 220, 232)
            End Get
        End Property
    End Class

#End Region
#Region " Renderer "

    Public Class ControlRenderer
        Inherits ToolStripProfessionalRenderer

        Public Sub New()
            Me.New(New MSColorTable())
        End Sub

        Public Sub New(ByVal ColorTable As ColorTable)
            Me.ColorTable = ColorTable
        End Sub

        Private _ColorTable As ColorTable
        Public Overloads Property ColorTable() As ColorTable
            Get
                If _ColorTable Is Nothing Then
                    _ColorTable = New MSColorTable()
                End If
                Return _ColorTable
            End Get
            Set(ByVal value As ColorTable)
                _ColorTable = value
            End Set
        End Property

        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            MyBase.OnRenderToolStripBackground(e)

            ' Menu strip bar gradient
            Using LGB As New LinearGradientBrush(e.AffectedBounds, Me.ColorTable.BackgroundTopGradient, Me.ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(LGB, e.AffectedBounds)
            End Using
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If e.ToolStrip.Parent Is Nothing Then
                ' Draw border around the menu drop-down
                Dim Rect As New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
                Using P1 As New Pen(Me.ColorTable.CommonColorTable.DropdownBorder)
                    e.Graphics.DrawRectangle(P1, Rect)
                End Using

                ' Fill the gap between menu drop-down and owner item
                Using B1 As New SolidBrush(Me.ColorTable.DroppedDownItemBackground)
                    e.Graphics.FillRectangle(B1, e.ConnectedArea)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            If e.Item.Enabled Then
                If e.Item.Selected Then
                    If Not e.Item.IsOnDropDown Then
                        Dim SelRect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
                        RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, SelRect)
                    Else
                        Dim SelRect As New Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1)
                        RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, SelRect)
                    End If
                End If

                If CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso Not e.Item.IsOnDropDown Then
                    Dim BorderRect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height)
                    ' Fill the background
                    Dim BackgroundRect As New Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2)
                    Using B1 As New SolidBrush(Me.ColorTable.DroppedDownItemBackground)
                        e.Graphics.FillRectangle(B1, BackgroundRect)
                    End Using

                    ' Draw border
                    Using P1 As New Pen(Me.ColorTable.CommonColorTable.DropdownBorder)
                        RectDrawing.DrawRoundedRectangle(e.Graphics, P1, BorderRect.X, BorderRect.Y, BorderRect.Width, BorderRect.Height, 2)
                    End Using
                End If
                e.Item.ForeColor = Me.ColorTable.CommonColorTable.TextColor
            End If
        End Sub

        Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)
            e.TextColor = Me.ColorTable.CommonColorTable.TextColor
            MyBase.OnRenderItemText(e)
        End Sub

        Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
            MyBase.OnRenderItemCheck(e)

            Dim rect As New Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3)
            Dim c As Color

            If e.Item.Selected Then
                c = Me.ColorTable.CommonColorTable.CheckedSelectedBackground
            Else
                c = Me.ColorTable.CommonColorTable.CheckedBackground
            End If

            Using b As New SolidBrush(c)
                e.Graphics.FillRectangle(b, rect)
            End Using

            Using p As New Pen(Me.ColorTable.CommonColorTable.SelectionBorder)
                e.Graphics.DrawRectangle(p, rect)
            End Using

            e.Graphics.DrawString("ü", New Font("Wingdings", 13, FontStyle.Regular), Brushes.Black, New Point(4, 2))
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
            MyBase.OnRenderSeparator(e)
            Dim PT1 As Integer = 28
            Dim PT2 As Integer = e.Item.Width
            Dim Y As Integer = 3
            Using P1 As New Pen(Me.ColorTable.Separator)
                e.Graphics.DrawLine(P1, PT1, Y, PT2, Y)
            End Using
        End Sub

        Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            MyBase.OnRenderImageMargin(e)

            Dim BackgroundRect As New Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1)
            Using LGB As New LinearGradientBrush(BackgroundRect,
                                               Me.ColorTable.DropdownTopGradient,
                                               Me.ColorTable.DropdownBottomGradient,
                                               LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(LGB, BackgroundRect)
            End Using

            Using B1 As New SolidBrush(Me.ColorTable.ImageMargin)
                e.Graphics.FillRectangle(B1, e.AffectedBounds)
            End Using
        End Sub

        Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim checked As Boolean = CType(e.Item, ToolStripButton).Checked
            Dim drawBorder As Boolean = False

            If checked Then
                drawBorder = True

                If e.Item.Selected AndAlso Not e.Item.Pressed Then
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.CheckedSelectedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                Else
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.CheckedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                End If

            Else

                If e.Item.Pressed Then
                    drawBorder = True
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                ElseIf e.Item.Selected Then
                    drawBorder = True
                    RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect)
                End If

            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectionBorder)
                    e.Graphics.DrawRectangle(p, rect)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim drawBorder As Boolean = False

            If e.Item.Pressed Then
                drawBorder = True
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            ElseIf e.Item.Selected Then
                drawBorder = True
                RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect)
            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectionBorder)
                    e.Graphics.DrawRectangle(p, rect)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            MyBase.OnRenderSplitButtonBackground(e)

            Dim drawBorder As Boolean = False
            Dim drawSeparator As Boolean = True

            Dim item = DirectCast(e.Item, ToolStripSplitButton)

            Dim btnRect As New Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1)
            Dim borderRect As New Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1)

            If item.DropDownButtonPressed Then
                drawBorder = True
                drawSeparator = False
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, borderRect)
                End Using
            ElseIf item.DropDownButtonSelected Then
                drawBorder = True
                RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, borderRect)
            End If

            If item.ButtonPressed Then
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, btnRect)
                End Using
            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectionBorder)
                    e.Graphics.DrawRectangle(p, borderRect)
                    If drawSeparator Then e.Graphics.DrawRectangle(p, btnRect)
                End Using

                Me.DrawCustomArrow(e.Graphics, item)
            End If
        End Sub

        Private Sub DrawCustomArrow(ByVal g As Graphics, ByVal item As ToolStripSplitButton)
            Dim dropWidth As Integer = item.DropDownButtonBounds.Width - 1
            Dim dropHeight As Integer = item.DropDownButtonBounds.Height - 1
            Dim triangleWidth As Single = dropWidth / 2.0F + 1
            Dim triangleLeft As Single = item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F
            Dim triangleHeight As Single = triangleWidth / 2.0F
            Dim triangleTop As Single = item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1
            Dim arrowRect As New RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight)

            Me.DrawCustomArrow(g, item, Rectangle.Round(arrowRect))
        End Sub

        Private Sub DrawCustomArrow(ByVal g As Graphics, ByVal item As ToolStripItem, ByVal rect As Rectangle)
            Dim arrowEventArgs As New ToolStripArrowRenderEventArgs(g,
                                                        item,
                                                        rect,
                                                        Me.ColorTable.CommonColorTable.Arrow,
                                                        ArrowDirection.Down)
            MyBase.OnRenderArrow(arrowEventArgs)
        End Sub

        Protected Overrides Sub OnRenderOverflowButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect, rectEnd As Rectangle
            rect = New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2)
            rectEnd = New Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height)

            If e.Item.Pressed Then
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            ElseIf e.Item.Selected Then
                RectDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect)
            Else
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.OverflowBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            End If

            Using P1 As New Pen(Me.ColorTable.CommonColorTable.Background)
                RectDrawing.DrawRoundedRectangle(e.Graphics, P1, rectEnd.X, rectEnd.Y, rectEnd.Width, rectEnd.Height, 3)
            End Using

            ' Icon
            Dim w As Integer = rect.Width - 1
            Dim h As Integer = rect.Height - 1
            Dim triangleWidth As Single = w / 2.0F + 1
            Dim triangleLeft As Single = rect.Left + (w - triangleWidth) / 2.0F + 3
            Dim triangleHeight As Single = triangleWidth / 2.0F
            Dim triangleTop As Single = rect.Top + (h - triangleHeight) / 2.0F + 7
            Dim arrowRect As New RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight)
            Me.DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect))

            Using p As New Pen(Me.ColorTable.CommonColorTable.Arrow)
                e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2, triangleTop - 2)
            End Using
        End Sub
    End Class

#End Region
#Region " Drawing "

    Public Class RectDrawing

        Public Shared Sub DrawSelection(ByVal G As Graphics,
                                        ByVal ColorTable As xColorTable,
                                        ByVal Rect As Rectangle)
            Dim TopRect As Rectangle
            Dim BottomRect As Rectangle
            Dim FillRect As New Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1)

            TopRect = FillRect
            TopRect.Height -= CInt(TopRect.Height / 2)
            BottomRect = New Rectangle(TopRect.X, TopRect.Bottom, TopRect.Width, FillRect.Height - TopRect.Height)

            ' Top gradient
            Using LGB As New LinearGradientBrush(TopRect, ColorTable.SelectionTopGradient, ColorTable.SelectionMidGradient, LinearGradientMode.Vertical)
                G.FillRectangle(LGB, TopRect)
            End Using

            ' Bottom
            Using B1 As New SolidBrush(ColorTable.SelectionBottomGradient)
                G.FillRectangle(B1, BottomRect)
            End Using

            ' Border
            Using P1 As New Pen(ColorTable.SelectionBorder)
                RectDrawing.DrawRoundedRectangle(G, P1, Rect.X, Rect.Y, Rect.Width, Rect.Height, 2)
            End Using
        End Sub

        Public Shared Sub DrawRoundedRectangle(ByVal G As Graphics,
                                        ByVal P As Pen,
                                        ByVal X As Single,
                                        ByVal Y As Single,
                                        ByVal W As Single,
                                        ByVal H As Single,
                                        ByVal Rad As Single)

            Using gp As New GraphicsPath()
                gp.AddLine(X + Rad, Y, X + W - (Rad * 2), Y)
                gp.AddArc(X + W - (Rad * 2), Y, Rad * 2, Rad * 2, 270, 90)
                gp.AddLine(X + W, Y + Rad, X + W, Y + H - (Rad * 2))
                gp.AddArc(X + W - (Rad * 2), Y + H - (Rad * 2), Rad * 2, Rad * 2, 0, 90)
                gp.AddLine(X + W - (Rad * 2), Y + H, X + Rad, Y + H)
                gp.AddArc(X, Y + H - (Rad * 2), Rad * 2, Rad * 2, 90, 90)
                gp.AddLine(X, Y + H - (Rad * 2), X, Y + Rad)
                gp.AddArc(X, Y, Rad * 2, Rad * 2, 180, 90)
                gp.CloseFigure()

                G.SmoothingMode = SmoothingMode.AntiAlias
                G.DrawPath(P, gp)
                G.SmoothingMode = SmoothingMode.Default
            End Using
        End Sub
    End Class

#End Region

#End Region
#Region " ThemeContainer "

    Public Class iTalk_ThemeContainer
        Inherits ContainerControl


#Region " Variables "

        Private MouseP As Point = New Point(0, 0)
        Private Cap As Boolean = False
        Private MoveHeight As Integer
        Private _TextBottom As String = Nothing
        Const BorderCurve As Integer = 7
        Protected State As MouseState
        Private HasShown As Boolean
        Private HeaderRect As Rectangle

#End Region
#Region " Enums "

        Enum MouseState As Byte
            None = 0
            Over = 1
            Down = 2
        End Enum

#End Region
#Region " Properties "

        Private _Sizable As Boolean = True
        Property Sizable() As Boolean
            Get
                Return _Sizable
            End Get
            Set(ByVal value As Boolean)
                _Sizable = value
            End Set
        End Property

        Private _SmartBounds As Boolean = False
        Property SmartBounds() As Boolean
            Get
                Return _SmartBounds
            End Get
            Set(ByVal value As Boolean)
                _SmartBounds = value
            End Set
        End Property

        Private _IsParentForm As Boolean
        Protected ReadOnly Property IsParentForm As Boolean
            Get
                Return _IsParentForm
            End Get
        End Property

        Protected ReadOnly Property IsParentMdi As Boolean
            Get
                If Parent Is Nothing Then Return False
                Return Parent.Parent IsNot Nothing
            End Get
        End Property

        Private _ControlMode As Boolean
        Protected Property ControlMode() As Boolean
            Get
                Return _ControlMode
            End Get
            Set(ByVal v As Boolean)
                _ControlMode = v
                Invalidate()
            End Set
        End Property

        Private _StartPosition As FormStartPosition
        Property StartPosition As FormStartPosition
            Get
                If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.StartPosition Else Return _StartPosition
            End Get
            Set(ByVal value As FormStartPosition)
                _StartPosition = value

                If _IsParentForm AndAlso Not _ControlMode Then
                    ParentForm.StartPosition = value
                End If
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
            MyBase.OnParentChanged(e)

            If Parent Is Nothing Then Return
            _IsParentForm = TypeOf Parent Is Form

            If Not _ControlMode Then
                InitializeMessages()

                If _IsParentForm Then
                    Me.ParentForm.FormBorderStyle = FormBorderStyle.None
                    Me.ParentForm.TransparencyKey = Color.Fuchsia

                    If Not DesignMode Then
                        AddHandler ParentForm.Shown, AddressOf FormShown
                    End If
                End If
                Parent.BackColor = BackColor
                Parent.MinimumSize = New Size(126, 39)
            End If
        End Sub

        Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)
            If Not _ControlMode Then HeaderRect = New Rectangle(0, 0, Width - 14, MoveHeight - 7)
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)
            If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized OrElse _ControlMode) Then
                If HeaderRect.Contains(e.Location) Then
                    Capture = False
                    WM_LMBUTTONDOWN = True
                    DefWndProc(Messages(0))
                ElseIf _Sizable AndAlso Not Previous = 0 Then
                    Capture = False
                    WM_LMBUTTONDOWN = True
                    DefWndProc(Messages(Previous))
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            Cap = False
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized) Then
                If _Sizable AndAlso Not _ControlMode Then InvalidateMouse()
            End If
            If Cap Then
                Parent.Location = MousePosition - MouseP
            End If
        End Sub

        Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
            MyBase.OnInvalidated(e)
            ParentForm.Text = Text
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)
            Invalidate()
        End Sub

        Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
            If _ControlMode OrElse HasShown Then Return

            If _StartPosition = FormStartPosition.CenterParent OrElse _StartPosition = FormStartPosition.CenterScreen Then
                Dim SB As Rectangle = Screen.PrimaryScreen.Bounds
                Dim CB As Rectangle = ParentForm.Bounds
                ParentForm.Location = New Point(SB.Width \ 2 - CB.Width \ 2, SB.Height \ 2 - CB.Width \ 2)
            End If
            HasShown = True
        End Sub

#End Region
#Region " Mouse & Size "

        Private Sub SetState(ByVal current As MouseState)
            State = current
            Invalidate()
        End Sub

        Private GetIndexPoint As Point
        Private B1x, B2x, B3, B4 As Boolean
        Private Function GetIndex() As Integer
            GetIndexPoint = PointToClient(MousePosition)
            B1x = GetIndexPoint.X < 7
            B2x = GetIndexPoint.X > Width - 7
            B3 = GetIndexPoint.Y < 7
            B4 = GetIndexPoint.Y > Height - 7

            If B1x AndAlso B3 Then Return 4
            If B1x AndAlso B4 Then Return 7
            If B2x AndAlso B3 Then Return 5
            If B2x AndAlso B4 Then Return 8
            If B1x Then Return 1
            If B2x Then Return 2
            If B3 Then Return 3
            If B4 Then Return 6
            Return 0
        End Function

        Private Current, Previous As Integer
        Private Sub InvalidateMouse()
            Current = GetIndex()
            If Current = Previous Then Return

            Previous = Current
            Select Case Previous
                Case 0
                    Cursor = Cursors.Default
                Case 6
                    Cursor = Cursors.SizeNS
                Case 8
                    Cursor = Cursors.SizeNWSE
                Case 7
                    Cursor = Cursors.SizeNESW
            End Select
        End Sub

        Private Messages(8) As Message
        Private Sub InitializeMessages()
            Messages(0) = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
            For I As Integer = 1 To 8
                Messages(I) = Message.Create(Parent.Handle, 161, New IntPtr(I + 9), IntPtr.Zero)
            Next
        End Sub

        Private Sub CorrectBounds(ByVal bounds As Rectangle)
            If Parent.Width > bounds.Width Then Parent.Width = bounds.Width
            If Parent.Height > bounds.Height Then Parent.Height = bounds.Height

            Dim X As Integer = Parent.Location.X
            Dim Y As Integer = Parent.Location.Y

            If X < bounds.X Then X = bounds.X
            If Y < bounds.Y Then Y = bounds.Y

            Dim Width As Integer = bounds.X + bounds.Width
            Dim Height As Integer = bounds.Y + bounds.Height

            If X + Parent.Width > Width Then X = Width - Parent.Width
            If Y + Parent.Height > Height Then Y = Height - Parent.Height

            Parent.Location = New Point(X, Y)
        End Sub

        Private WM_LMBUTTONDOWN As Boolean
        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)

            If WM_LMBUTTONDOWN AndAlso m.Msg = 513 Then
                WM_LMBUTTONDOWN = False

                SetState(MouseState.Over)
                If Not _SmartBounds Then Return

                If IsParentMdi Then
                    CorrectBounds(New Rectangle(Point.Empty, Parent.Parent.Size))
                Else
                    CorrectBounds(Screen.FromControl(Parent).WorkingArea)
                End If
            End If
        End Sub

#End Region

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            Me.ParentForm.FormBorderStyle = FormBorderStyle.None
            Me.ParentForm.TransparencyKey = Color.Fuchsia
        End Sub

        Protected Overrides Sub CreateHandle()
            MyBase.CreateHandle()
        End Sub

        Sub New()
            MyBase.New()
            SetStyle(DirectCast(139270, ControlStyles), True)
            Dock = DockStyle.Fill
            MoveHeight = 25
            Padding = New Padding(3, 28, 3, 28)
            Font = New Font("Segoe UI", 8, FontStyle.Regular)
            ForeColor = Color.FromArgb(142, 142, 142)
            BackColor = Color.FromArgb(246, 246, 246)
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)
            Dim ClientRectangle As New Rectangle(0, 0, Width - 1, Height - 1)
            Dim TransparencyKey As Color = Me.ParentForm.TransparencyKey

            G.SmoothingMode = SmoothingMode.Default
            G.Clear(TransparencyKey)

            ' Draw the container borders
            G.FillPath(New SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(ClientRectangle, BorderCurve))
            ' Draw a rectangle in which the controls should be added on
            G.FillPath(New SolidBrush(Color.FromArgb(246, 246, 246)), RoundRectangle.RoundRect(New Rectangle(2, 20, Width - 5, Height - 42), BorderCurve))

            ' Patch the header with a rectangle that has a curve so its border will remain within container bounds
            G.FillPath(New SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(New Rectangle(2, 2, Width / 2 + 2, 16), BorderCurve))
            G.FillPath(New SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(New Rectangle(Width / 2 - 3, 2, Width / 2, 16), BorderCurve))
            ' Fill the header rectangle below the patch
            G.FillRectangle(New SolidBrush(Color.FromArgb(52, 52, 52)), New Rectangle(2, 15, Width - 5, 10))

            ' Increase the thickness of the container borders
            G.DrawPath(New Pen(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(New Rectangle(2, 2, Width - 5, Height - 5), BorderCurve))
            G.DrawPath(New Pen(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(ClientRectangle, BorderCurve))

            ' Draw the string from the specified 'Text' property on the header rectangle
            G.DrawString(Text, New Font("Trebuchet MS", 10, FontStyle.Bold), New SolidBrush(Color.FromArgb(221, 221, 221)), New Rectangle(BorderCurve, BorderCurve - 4, Width - 1, 22), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})


            ' Draws a rectangle at the bottom of the container
            G.FillRectangle(New SolidBrush(Color.FromArgb(52, 52, 52)), 0, Height - 25, Width - 3, 22 - 2)
            G.DrawLine(New Pen(Color.FromArgb(52, 52, 52)), 5, Height - 5, Width - 6, Height - 5)
            G.DrawLine(New Pen(Color.FromArgb(52, 52, 52)), 7, Height - 4, Width - 7, Height - 4)

            G.DrawString(_TextBottom, New Font("Trebuchet MS", 10, FontStyle.Bold), New SolidBrush(Color.FromArgb(221, 221, 221)), 5, Height - 23)

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose()
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " ControlBox "

    Public Class iTalk_ControlBox
        Inherits Control

#Region " Enums "

        Enum MouseState As Byte
            None = 0
            Over = 1
            Down = 2
            Block = 3
        End Enum

#End Region
#Region " Variables "

        Dim State As MouseState = MouseState.None
        Dim i As Integer
        Dim CloseRect As New Rectangle(28, 0, 47, 18)
        Dim MinimizeRect As New Rectangle(0, 0, 28, 18)

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            MyBase.OnMouseClick(e)

            If i > 0 And i < 28 Then
                FindForm.WindowState = FormWindowState.Minimized
            ElseIf i > 30 And i < 75 Then
                FindForm.Close()
            End If

            State = MouseState.Down
        End Sub

        Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
            MyBase.OnMouseEnter(e)
            State = MouseState.Over
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            State = MouseState.None
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            State = MouseState.Over
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            i = e.Location.X
            Invalidate()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Width = 77
            Height = 19
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
            BackColor = Color.Transparent
            DoubleBuffered = True
            Anchor = AnchorStyles.Top Or AnchorStyles.Right
        End Sub
        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            Location = New Point(FindForm.Width - 81, -1) ' Auto-decide control location on the theme container
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)
            Dim GP_MinimizeRect As New GraphicsPath
            Dim GP_CloseRect As New GraphicsPath

            GP_MinimizeRect.AddRectangle(MinimizeRect)
            GP_CloseRect.AddRectangle(CloseRect)
            G.Clear(BackColor)

            Select Case State
                Case MouseState.None
NonePoint:          Dim MinimizeGradient As New LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)
                    G.FillPath(MinimizeGradient, GP_MinimizeRect)
                    G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect)
                    G.DrawString("0", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16)

                    Dim CloseGradient As New LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)
                    G.FillPath(CloseGradient, GP_CloseRect)
                    G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect)
                    G.DrawString("r", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16)
                Case MouseState.Over
                    If i > 0 And i < 28 Then
                        Dim MinimizeGradient As New LinearGradientBrush(MinimizeRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90S)
                        G.FillPath(MinimizeGradient, GP_MinimizeRect)
                        G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect)
                        G.DrawString("0", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16)

                        Dim CloseGradient As New LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)
                        G.FillPath(CloseGradient, GP_CloseRect)
                        G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect)
                        G.DrawString("r", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16)
                    ElseIf i > 30 And i < 75 Then
                        Dim CloseGradient As New LinearGradientBrush(CloseRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90S)
                        G.FillPath(CloseGradient, GP_CloseRect)
                        G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect)
                        G.DrawString("r", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16)

                        Dim MinimizeGradient As New LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90S)
                        G.FillPath(MinimizeGradient, RoundRectangle.RoundRect(MinimizeRect, 1))
                        G.DrawPath(New Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect)
                        G.DrawString("0", New Font("Marlett", 11, FontStyle.Regular), New SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16)
                    Else
                        GoTo NonePoint ' Return to [MouseState = None]
                    End If
            End Select

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose()
            GP_CloseRect.Dispose()
            GP_MinimizeRect.Dispose()
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " Button 1 "

    Class iTalk_Button_1
        Inherits Control

#Region " Variables "

        Private MouseState As Integer
        Private Shape As GraphicsPath
        Private InactiveGB, PressedGB, PressedContourGB As LinearGradientBrush
        Private R1 As Rectangle
        Private P1, P3 As Pen
        Private _Image As Image
        Private _ImageSize As Size
        Private _TextAlignment As StringAlignment = StringAlignment.Center
        Private _TextColor As Color = Color.FromArgb(150, 150, 150)
        Private _ImageAlign As ContentAlignment = ContentAlignment.MiddleLeft

#End Region
#Region " Image Designer "

        Private Shared Function ImageLocation(ByVal SF As StringFormat, ByVal Area As SizeF, ByVal ImageArea As SizeF) As PointF
            Dim MyPoint As PointF
            Select Case SF.Alignment
                Case StringAlignment.Center
                    MyPoint.X = CSng((Area.Width - ImageArea.Width) / 2)
                Case StringAlignment.Near
                    MyPoint.X = 2
                Case StringAlignment.Far
                    MyPoint.X = Area.Width - ImageArea.Width - 2

            End Select

            Select Case SF.LineAlignment
                Case StringAlignment.Center
                    MyPoint.Y = CSng((Area.Height - ImageArea.Height) / 2)
                Case StringAlignment.Near
                    MyPoint.Y = 2
                Case StringAlignment.Far
                    MyPoint.Y = Area.Height - ImageArea.Height - 2
            End Select
            Return MyPoint
        End Function

        Private Function GetStringFormat(ByVal _ContentAlignment As ContentAlignment) As StringFormat
            Dim SF As StringFormat = New StringFormat()
            Select Case _ContentAlignment
                Case ContentAlignment.MiddleCenter
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.MiddleLeft
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.MiddleRight
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Far
                Case ContentAlignment.TopCenter
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.TopLeft
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.TopRight
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Far
                Case ContentAlignment.BottomCenter
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.BottomLeft
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.BottomRight
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Far
            End Select
            Return SF
        End Function

#End Region
#Region " Properties "

        Property Image() As Image
            Get
                Return _Image
            End Get
            Set(ByVal value As Image)
                If value Is Nothing Then
                    _ImageSize = Size.Empty
                Else
                    _ImageSize = value.Size
                End If

                _Image = value
                Invalidate()
            End Set
        End Property

        Protected ReadOnly Property ImageSize() As Size
            Get
                Return _ImageSize
            End Get
        End Property

        Public Property ImageAlign() As ContentAlignment
            Get
                Return _ImageAlign
            End Get
            Set(ByVal Value As ContentAlignment)
                _ImageAlign = Value
                Invalidate()
            End Set
        End Property

        Public Property TextAlignment As StringAlignment
            Get
                Return Me._TextAlignment
            End Get
            Set(ByVal value As StringAlignment)
                Me._TextAlignment = value
                Me.Invalidate()
            End Set
        End Property

        Public Overrides Property ForeColor As Color
            Get
                Return Me._TextColor
            End Get
            Set(ByVal value As Color)
                Me._TextColor = value
                Me.Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MouseState = 0
            Invalidate()
            MyBase.OnMouseUp(e)
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MouseState = 1
            Invalidate()
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MouseState = 0
            Invalidate()
            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)

            BackColor = Color.Transparent
            DoubleBuffered = True
            Font = New Font("Segoe UI", 12)
            ForeColor = Color.FromArgb(150, 150, 150)
            Size = New Size(166, 40)
            _TextAlignment = StringAlignment.Center
            P1 = New Pen(Color.FromArgb(190, 190, 190)) ' P1 = Border color
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            If Width > 0 AndAlso Height > 0 Then

                Shape = New GraphicsPath
                R1 = New Rectangle(0, 0, Width, Height)

                InactiveGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(251, 251, 251), Color.FromArgb(225, 225, 225), 90.0F)
                PressedGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(235, 235, 235), Color.FromArgb(223, 223, 223), 90.0F)
                PressedContourGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90.0F)

                P3 = New Pen(PressedContourGB)
            End If

            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With

            Invalidate()
            MyBase.OnResize(e)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            With e.Graphics
                .SmoothingMode = SmoothingMode.HighQuality
                Dim ipt As PointF = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize)

                Select Case MouseState
                    Case 0 'Inactive
                        .FillPath(InactiveGB, Shape) ' Fill button body with InactiveGB color gradient
                        .DrawPath(P1, Shape) ' Draw button border [InactiveGB]
                        If IsNothing(Image) Then
                            ' If an image is not specified, only draw the string on the button
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        Else
                            ' If an image is specified, the image and draw the string on the button
                            .DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height)
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        End If
                    Case 1 'Pressed
                        .FillPath(PressedGB, Shape) ' Fill button body with PressedGB color gradient
                        .DrawPath(P3, Shape) ' Draw button border [PressedGB]

                        If IsNothing(Image) Then
                            ' If an image is not specified, only draw the string on the button
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        Else
                            ' If an image is specified, the image and draw the string on the button
                            .DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height)
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        End If
                End Select
            End With
            MyBase.OnPaint(e)
        End Sub
    End Class

#End Region
#Region " Button 2 "

    Class iTalk_Button_2
        Inherits Control

#Region " Variables "

        Private MouseState As Integer
        Private Shape As GraphicsPath
        Private InactiveGB, PressedGB, PressedContourGB As LinearGradientBrush
        Private R1 As Rectangle
        Private P1, P3 As Pen
        Private _Image As Image
        Private _ImageSize As Size
        Private _TextAlignment As StringAlignment = StringAlignment.Center
        Private _ImageAlign As ContentAlignment = ContentAlignment.MiddleLeft

#End Region
#Region " Image Designer "

        Private Shared Function ImageLocation(ByVal SF As StringFormat, ByVal Area As SizeF, ByVal ImageArea As SizeF) As PointF
            Dim MyPoint As PointF
            Select Case SF.Alignment
                Case StringAlignment.Center
                    MyPoint.X = CSng((Area.Width - ImageArea.Width) / 2)
                Case StringAlignment.Near
                    MyPoint.X = 2
                Case StringAlignment.Far
                    MyPoint.X = Area.Width - ImageArea.Width - 2
            End Select

            Select Case SF.LineAlignment
                Case StringAlignment.Center
                    MyPoint.Y = CSng((Area.Height - ImageArea.Height) / 2)
                Case StringAlignment.Near
                    MyPoint.Y = 2
                Case StringAlignment.Far
                    MyPoint.Y = Area.Height - ImageArea.Height - 2
            End Select
            Return MyPoint
        End Function

        Private Function GetStringFormat(ByVal _ContentAlignment As ContentAlignment) As StringFormat
            Dim SF As StringFormat = New StringFormat()
            Select Case _ContentAlignment
                Case ContentAlignment.MiddleCenter
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.MiddleLeft
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.MiddleRight
                    SF.LineAlignment = StringAlignment.Center
                    SF.Alignment = StringAlignment.Far
                Case ContentAlignment.TopCenter
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.TopLeft
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.TopRight
                    SF.LineAlignment = StringAlignment.Near
                    SF.Alignment = StringAlignment.Far
                Case ContentAlignment.BottomCenter
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Center
                Case ContentAlignment.BottomLeft
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Near
                Case ContentAlignment.BottomRight
                    SF.LineAlignment = StringAlignment.Far
                    SF.Alignment = StringAlignment.Far
            End Select
            Return SF
        End Function

#End Region
#Region " Properties "

        Property Image() As Image
            Get
                Return _Image
            End Get
            Set(ByVal value As Image)
                If value Is Nothing Then
                    _ImageSize = Size.Empty
                Else
                    _ImageSize = value.Size
                End If

                _Image = value
                Invalidate()
            End Set
        End Property

        Public Property TextAlignment As StringAlignment
            Get
                Return Me._TextAlignment
            End Get
            Set(ByVal value As StringAlignment)
                Me._TextAlignment = value
                Me.Invalidate()
            End Set
        End Property

        Protected ReadOnly Property ImageSize() As Size
            Get
                Return _ImageSize
            End Get
        End Property

        Public Property ImageAlign() As ContentAlignment
            Get
                Return _ImageAlign
            End Get
            Set(ByVal Value As ContentAlignment)
                _ImageAlign = Value
                Invalidate()
            End Set
        End Property

#End Region
#Region "  EventArgs "

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MouseState = 0
            Invalidate()
            MyBase.OnMouseUp(e)
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MouseState = 1
            Invalidate()
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MouseState = 0
            Invalidate()
            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)

            BackColor = Color.Transparent
            DoubleBuffered = True
            Font = New Font("Segoe UI", 14)
            ForeColor = Color.White
            Size = New Size(166, 40)
            _TextAlignment = StringAlignment.Center
            P1 = New Pen(Color.FromArgb(0, 118, 176)) ' P1 = Border color
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            If Width > 0 AndAlso Height > 0 Then

                Shape = New GraphicsPath
                R1 = New Rectangle(0, 0, Width, Height)

                InactiveGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(0, 176, 231), Color.FromArgb(0, 152, 224), 90.0F)
                PressedGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 149, 222), 90.0F)
                PressedContourGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 118, 176), 90.0F)

                P3 = New Pen(PressedContourGB)
            End If

            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With

            Invalidate()
            MyBase.OnResize(e)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            With e.Graphics
                .SmoothingMode = SmoothingMode.HighQuality

                Dim ipt As PointF = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize)

                Select Case MouseState
                    Case 0 'Inactive
                        .FillPath(InactiveGB, Shape) ' Fill button body with InactiveGB color gradient
                        .DrawPath(P1, Shape) ' Draw button border [InactiveGB]
                        If IsNothing(Image) Then
                            ' If an image is not specified, only draw the string on the button
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        Else
                            ' If an image is specified, the image and draw the string on the button
                            .DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height)
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        End If
                    Case 1 'Pressed
                        .FillPath(PressedGB, Shape) ' Fill button body with PressedGB color gradient
                        .DrawPath(P3, Shape) ' Draw button border [PressedGB]
                        If IsNothing(Image) Then
                            ' If an image is not specified, only draw the string on the button
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        Else
                            ' If an image is specified, the image and draw the string on the button
                            .DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height)
                            .DrawString(Text, Font, New SolidBrush(ForeColor), R1, New StringFormat() With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        End If
                End Select
            End With
            MyBase.OnPaint(e)
        End Sub
    End Class

#End Region
#Region " Toggle Button "

    <DefaultEvent("ToggledChanged")> Class iTalk_Toggle
        Inherits Control

#Region " Designer "

        '|------DO-NOT-REMOVE------|
        '|---------CREDITS---------|

        ' Pill class and functions were originally created by Tedd
        ' Last edited by Tedd on: 12/20/2013
        ' Modified by HazelDev on: 1/4/2014

        '|---------CREDITS---------|
        '|------DO-NOT-REMOVE------|

        Class PillStyle
            Public Left As Boolean
            Public Right As Boolean
        End Class

        Public Function Pill(ByVal Rectangle As Rectangle, ByVal PillStyle As PillStyle) As GraphicsPath
            Pill = New GraphicsPath()

            If PillStyle.Left Then
                Pill.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180)
            Else
                Pill.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y)
            End If

            If PillStyle.Right Then
                Pill.AddArc(New Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180)
            Else
                Pill.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height)
            End If
            Pill.CloseAllFigures()
            Return Pill
        End Function

        Public Function Pill(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal PillStyle As PillStyle)
            Return Pill(New Rectangle(X, Y, Width, Height), PillStyle)
        End Function

#End Region
#Region " Enums "

        Enum _Type
            YesNo
            OnOff
            IO
        End Enum

#End Region
#Region " Variables "

        Private WithEvents AnimationTimer As Timer = New Timer With {.Interval = 1}
        Private ToggleLocation As Integer = 0
        Event ToggledChanged()
        Private _Toggled As Boolean
        Private ToggleType As _Type
        Private Bar As Rectangle
        Private cHandle As Size = New Size(15, 20)

#End Region
#Region " Properties "

        Public Property Toggled() As Boolean
            Get
                Return _Toggled
            End Get
            Set(ByVal value As Boolean)
                _Toggled = value
                Invalidate()
                RaiseEvent ToggledChanged()
            End Set
        End Property

        Public Property Type As _Type
            Get
                Return ToggleType
            End Get
            Set(value As _Type)
                ToggleType = value
                Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Width = 41
            Height = 23
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            Toggled = Not Toggled
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                      ControlStyles.DoubleBuffer Or
                      ControlStyles.ResizeRedraw Or
                      ControlStyles.UserPaint, True)
        End Sub
        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)
            AnimationTimer.Start() ' activate the animation timer
        End Sub

        Private Sub Animation() Handles AnimationTimer.Tick
            ' Create a slide animation when toggled on/off
            If _Toggled = True Then
                If ToggleLocation < 100 Then
                    ToggleLocation += 10
                    Me.Invalidate(False)
                End If
            Else
                If ToggleLocation > 0 Then
                    ToggleLocation -= 10
                    Me.Invalidate(False)
                End If
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim G As Graphics = e.Graphics
            Dim Gradient As LinearGradientBrush = New LinearGradientBrush(New Point(0, CInt((Height / 2) - (cHandle.Height / 2))), New Point(0, CInt((Height / 2) + (cHandle.Height / 2))), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240))
            Bar = New Rectangle(8, 10, Width - 21, Height - 21)

            G.Clear(BackColor)
            G.SmoothingMode = SmoothingMode.AntiAlias

            ' Draw the control body and border
            G.FillPath(Gradient, Pill(0, CInt(Height / 2 - cHandle.Height / 2), Width - 1, cHandle.Height - 5, New PillStyle With {.Left = True, .Right = True}))
            G.DrawPath(New Pen(Color.FromArgb(177, 177, 176)), Pill(0, CInt(Height / 2 - cHandle.Height / 2), Width - 1, cHandle.Height - 5, New PillStyle With {.Left = True, .Right = True}))

            Gradient.Dispose() ' Dispose GradientBrush object 

            ' Draw a string based on the toggle boolean value
            Select Case ToggleType
                Case _Type.YesNo
                    If Toggled Then
                        G.DrawString("Yes", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    Else
                        G.DrawString("No", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                Case _Type.OnOff
                    If Toggled Then
                        G.DrawString("On", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    Else
                        G.DrawString("Off", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                Case _Type.IO
                    If Toggled Then
                        G.DrawString("I", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 7, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    Else
                        G.DrawString("O", New Font("Segoe UI", 7, FontStyle.Regular), Brushes.Gray, Bar.X + 18, Bar.Y, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
            End Select

            ' Draw the toggle handle
            G.FillEllipse(New SolidBrush(Color.FromArgb(249, 249, 249)), Bar.X + CInt(Bar.Width * (ToggleLocation / 80)) - CInt(cHandle.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(cHandle.Height / 2 - 1), cHandle.Width, cHandle.Height - 5)
            G.DrawEllipse(New Pen(Color.FromArgb(177, 177, 176)), Bar.X + CInt(Bar.Width * (ToggleLocation / 80) - CInt(cHandle.Width / 2)), Bar.Y + CInt((Bar.Height / 2)) - CInt(cHandle.Height / 2 - 1), cHandle.Width, cHandle.Height - 5)
        End Sub
    End Class

#End Region
#Region " Label "

    Class iTalk_Label
        Inherits Label

        Sub New()
            Font = New Font("Segoe UI", 8)
            ForeColor = Color.FromArgb(142, 142, 142)
            BackColor = Color.Transparent
        End Sub
    End Class

#End Region
#Region " Link Label "
    Class iTalk_LinkLabel
        Inherits LinkLabel

        Sub New()
            Font = New Font("Segoe UI", 8, FontStyle.Regular)
            BackColor = Color.Transparent
            LinkColor = Color.FromArgb(51, 153, 225)
            ActiveLinkColor = Color.FromArgb(0, 101, 202)
            VisitedLinkColor = Color.FromArgb(0, 101, 202)
            LinkBehavior = Windows.Forms.LinkBehavior.NeverUnderline
        End Sub
    End Class

#End Region
#Region " Header Label "

    Class iTalk_HeaderLabel
        Inherits Label

        Sub New()
            Font = New Font("Segoe UI", 25, FontStyle.Regular)
            ForeColor = Color.FromArgb(80, 80, 80)
            BackColor = Color.Transparent
        End Sub
    End Class

#End Region
#Region " Big TextBox "

    <DefaultEvent("TextChanged")> Class iTalk_TextBox_Big
        Inherits Control

#Region " Variables "

        Public WithEvents iTalkTB As New TextBox
        Private Shape As GraphicsPath
        Private _maxchars As Integer = 32767
        Private _ReadOnly As Boolean
        Private _Multiline As Boolean
        Private _Image As Image
        Private _ImageSize As Size
        Private ALNType As HorizontalAlignment
        Private isPasswordMasked As Boolean = False
        Private P1 As Pen
        Private B1 As SolidBrush

#End Region
#Region " Properties "

        Public Shadows Property TextAlignment() As HorizontalAlignment
            Get
                Return ALNType
            End Get
            Set(ByVal Val As HorizontalAlignment)
                ALNType = Val
                Invalidate()
            End Set
        End Property
        Public Shadows Property MaxLength() As Integer
            Get
                Return _maxchars
            End Get
            Set(ByVal Val As Integer)
                _maxchars = Val
                iTalkTB.MaxLength = MaxLength
                Invalidate()
            End Set
        End Property

        Public Shadows Property UseSystemPasswordChar() As Boolean
            Get
                Return isPasswordMasked
            End Get
            Set(ByVal Val As Boolean)
                iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar
                isPasswordMasked = Val
                Invalidate()
            End Set
        End Property
        Property [ReadOnly]() As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                If iTalkTB IsNot Nothing Then
                    iTalkTB.ReadOnly = value
                End If
            End Set
        End Property
        Property Multiline() As Boolean
            Get
                Return _Multiline
            End Get
            Set(ByVal value As Boolean)
                _Multiline = value
                If iTalkTB IsNot Nothing Then
                    iTalkTB.Multiline = value

                    If value Then
                        iTalkTB.Height = Height - 23
                    Else
                        Height = iTalkTB.Height + 23
                    End If
                End If
            End Set
        End Property

        Property Image() As Image
            Get
                Return _Image
            End Get
            Set(ByVal value As Image)
                If value Is Nothing Then
                    _ImageSize = Size.Empty
                Else
                    _ImageSize = value.Size
                End If

                _Image = value

                If Image Is Nothing Then
                    iTalkTB.Location = New Point(8, 10)
                Else
                    iTalkTB.Location = New Point(35, 11)
                End If
                Invalidate()
            End Set
        End Property

        Protected ReadOnly Property ImageSize() As Size
            Get
                Return _ImageSize
            End Get
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)
            Invalidate()
        End Sub

        Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
            MyBase.OnForeColorChanged(e)
            iTalkTB.ForeColor = ForeColor
            Invalidate()
        End Sub

        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
            MyBase.OnFontChanged(e)
            iTalkTB.Font = Font
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
        End Sub

        Private Sub _OnKeyDown(ByVal Obj As Object, ByVal e As KeyEventArgs)
            If e.Control AndAlso e.KeyCode = Keys.A Then
                iTalkTB.SelectAll()
                e.SuppressKeyPress = True
            End If
            If e.Control AndAlso e.KeyCode = Keys.C Then
                iTalkTB.Copy()
                e.SuppressKeyPress = True
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            If _Multiline Then
                iTalkTB.Height = Height - 23
            Else
                Height = iTalkTB.Height + 23
            End If

            Shape = New GraphicsPath
            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            iTalkTB.Focus()
        End Sub

        Sub _TextChanged() Handles iTalkTB.TextChanged
            Text = iTalkTB.Text
        End Sub

        Sub _BaseTextChanged() Handles MyBase.TextChanged
            iTalkTB.Text = Text
        End Sub

#End Region

        Sub AddTextBox()
            With iTalkTB
                .Location = New Point(7, 10)
                .Text = String.Empty
                .BorderStyle = BorderStyle.None
                .TextAlign = HorizontalAlignment.Left
                .Font = New Font("Tahoma", 11)
                .UseSystemPasswordChar = UseSystemPasswordChar
                .Multiline = False
            End With
            AddHandler iTalkTB.KeyDown, AddressOf _OnKeyDown
        End Sub

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            AddTextBox()
            Controls.Add(iTalkTB)

            P1 = New Pen(Color.FromArgb(180, 180, 180))
            B1 = New SolidBrush(Color.White)
            BackColor = Color.Transparent
            ForeColor = Color.DimGray

            Text = Nothing
            Font = New Font("Tahoma", 11)
            Size = New Size(135, 43)
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.AntiAlias

            With iTalkTB

                If Image Is Nothing Then
                    .Width = Width - 18
                Else
                    .Width = Width - 45
                End If

                .TextAlign = TextAlignment
                .UseSystemPasswordChar = UseSystemPasswordChar
            End With

            G.Clear(Color.Transparent)
            G.FillPath(B1, Shape) ' Draw background
            G.DrawPath(P1, Shape) ' Draw border

            If Image IsNot Nothing Then
                G.DrawImage(_Image, 5, 8, 24, 24)
                ' 24x24 is the perfect size of the image
            End If

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()
        End Sub
    End Class

#End Region
#Region " Small TextBox "

    <DefaultEvent("TextChanged")> Class iTalk_TextBox_Small
        Inherits Control

#Region " Variables "

        Public WithEvents iTalkTB As New TextBox
        Private Shape As GraphicsPath
        Private _maxchars As Integer = 32767
        Private _ReadOnly As Boolean
        Private _Multiline As Boolean
        Private ALNType As HorizontalAlignment
        Private isPasswordMasked As Boolean = False
        Private P1 As Pen
        Private B1 As SolidBrush

#End Region
#Region " Properties "

        Public Shadows Property TextAlignment() As HorizontalAlignment
            Get
                Return ALNType
            End Get
            Set(ByVal Val As HorizontalAlignment)
                ALNType = Val
                Invalidate()
            End Set
        End Property
        Public Shadows Property MaxLength() As Integer
            Get
                Return _maxchars
            End Get
            Set(ByVal Val As Integer)
                _maxchars = Val
                iTalkTB.MaxLength = MaxLength
                Invalidate()
            End Set
        End Property

        Public Shadows Property UseSystemPasswordChar() As Boolean
            Get
                Return isPasswordMasked
            End Get
            Set(ByVal Val As Boolean)
                iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar
                isPasswordMasked = Val
                Invalidate()
            End Set
        End Property
        Property [ReadOnly]() As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                If iTalkTB IsNot Nothing Then
                    iTalkTB.ReadOnly = value
                End If
            End Set
        End Property
        Property Multiline() As Boolean
            Get
                Return _Multiline
            End Get
            Set(ByVal value As Boolean)
                _Multiline = value
                If iTalkTB IsNot Nothing Then
                    iTalkTB.Multiline = value

                    If value Then
                        iTalkTB.Height = Height - 10
                    Else
                        Height = iTalkTB.Height + 10
                    End If
                End If
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)
            Invalidate()
        End Sub

        Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
            MyBase.OnForeColorChanged(e)
            iTalkTB.ForeColor = ForeColor
            Invalidate()
        End Sub

        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
            MyBase.OnFontChanged(e)
            iTalkTB.Font = Font
        End Sub
        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
        End Sub

        Private Sub _OnKeyDown(ByVal Obj As Object, ByVal e As KeyEventArgs)
            If e.Control AndAlso e.KeyCode = Keys.A Then
                iTalkTB.SelectAll()
                e.SuppressKeyPress = True
            End If
            If e.Control AndAlso e.KeyCode = Keys.C Then
                iTalkTB.Copy()
                e.SuppressKeyPress = True
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            If _Multiline Then
                iTalkTB.Height = Height - 10
            Else
                Height = iTalkTB.Height + 10
            End If

            Shape = New GraphicsPath
            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            iTalkTB.Focus()
        End Sub

        Sub _TextChanged() Handles iTalkTB.TextChanged
            Text = iTalkTB.Text
        End Sub

        Sub _BaseTextChanged() Handles MyBase.TextChanged
            iTalkTB.Text = Text
        End Sub

#End Region

        Sub AddTextBox()
            ' Initialize the TextBox
            With iTalkTB
                .Size = New Size(Width - 10, 33)
                .Location = New Point(7, 5)
                .Text = String.Empty
                .BorderStyle = BorderStyle.None
                .TextAlign = HorizontalAlignment.Left
                .Font = New Font("Tahoma", 9)
                .UseSystemPasswordChar = UseSystemPasswordChar
                .Multiline = False
            End With
            AddHandler iTalkTB.KeyDown, AddressOf _OnKeyDown
        End Sub

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            AddTextBox()
            Controls.Add(iTalkTB)

            P1 = New Pen(Color.FromArgb(180, 180, 180))
            B1 = New SolidBrush(Color.White)
            BackColor = Color.Transparent
            ForeColor = Color.DimGray

            Text = Nothing
            Font = New Font("Tahoma", 11)
            Size = New Size(135, 33)
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.AntiAlias

            With iTalkTB
                .Width = Width - 10
                .TextAlign = TextAlignment
                .UseSystemPasswordChar = UseSystemPasswordChar
            End With

            G.Clear(Color.Transparent)
            G.FillPath(B1, Shape) ' Draw background
            G.DrawPath(P1, Shape) ' Draw border

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()
        End Sub
    End Class

#End Region
#Region " RichTextBox "

    <DefaultEvent("TextChanged")> Class iTalk_RichTextBox
        Inherits Control

#Region " Variables "

        Public WithEvents iTalkRTB As New RichTextBox
        Private _ReadOnly As Boolean
        Private _WordWrap As Boolean
        Private _AutoWordSelection As Boolean
        Private Shape As GraphicsPath

#End Region
#Region " Properties "

        Overrides Property Text As String
            Get
                Return iTalkRTB.Text
            End Get
            Set(value As String)
                iTalkRTB.Text = value
                Invalidate()
            End Set
        End Property
        Property [ReadOnly]() As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                If iTalkRTB IsNot Nothing Then
                    iTalkRTB.ReadOnly = value
                End If
            End Set
        End Property
        Property [WordWrap]() As Boolean
            Get
                Return _WordWrap
            End Get
            Set(ByVal value As Boolean)
                _WordWrap = value
                If iTalkRTB IsNot Nothing Then
                    iTalkRTB.WordWrap = value
                End If
            End Set
        End Property
        Property [AutoWordSelection]() As Boolean
            Get
                Return _AutoWordSelection
            End Get
            Set(ByVal value As Boolean)
                _AutoWordSelection = value
                If iTalkRTB IsNot Nothing Then
                    iTalkRTB.AutoWordSelection = value
                End If
            End Set
        End Property
#End Region
#Region " EventArgs "

        Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
            MyBase.OnForeColorChanged(e)
            iTalkRTB.ForeColor = ForeColor
            Invalidate()
        End Sub

        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
            MyBase.OnFontChanged(e)
            iTalkRTB.Font = Font
        End Sub
        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
            MyBase.OnSizeChanged(e)
            iTalkRTB.Size = New Size(Width - 13, Height - 11)
        End Sub


        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)

            Shape = New GraphicsPath
            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With
        End Sub

        Sub _TextChanged() Handles MyBase.TextChanged
            iTalkRTB.Text = Text
        End Sub

#End Region

        Sub AddRichTextBox()
            With iTalkRTB
                .BackColor = Color.White
                .Size = New Size(Width - 10, 100)
                .Location = New Point(7, 5)
                .Text = String.Empty
                .BorderStyle = BorderStyle.None
                .Font = New Font("Tahoma", 10)
                .Multiline = True
            End With
        End Sub

        Sub New()
            MyBase.New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            AddRichTextBox()
            Controls.Add(iTalkRTB)
            BackColor = Color.Transparent
            ForeColor = Color.DimGray

            Text = Nothing
            Font = New Font("Tahoma", 10)
            Size = New Size(150, 100)
            WordWrap = True
            AutoWordSelection = False
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.AntiAlias

            G.Clear(Color.Transparent) ' Set control background to transparent
            G.FillPath(Brushes.White, Shape) ' Draw RTB background
            G.DrawPath(New Pen(Color.FromArgb(180, 180, 180)), Shape) ' Draw border

            G.Dispose()
            e.Graphics.DrawImage(B.Clone(), 0, 0)
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " NumericUpDown "

    Class iTalk_NumericUpDown
        Inherits Control

#Region " Enums "

        Enum _TextAlignment
            Near
            Center
        End Enum

#End Region
#Region " Variables "

        Private Shape As GraphicsPath
        Private P1 As Pen
        Private B1 As SolidBrush

        Private _Value, _Minimum, _Maximum As Long
        Private Xval, Yval As Integer
        Private KeyboardNum As Boolean
        Private MyStringAlignment As _TextAlignment

#End Region
#Region " Properties "

        Public Property Value As Long
            Get
                Return _Value
            End Get
            Set(value As Long)
                If value <= _Maximum And value >= _Minimum Then _Value = value
                Invalidate()
            End Set
        End Property

        Public Property Minimum As Long
            Get
                Return _Minimum
            End Get
            Set(value As Long)
                If value < _Maximum Then _Minimum = value
                If _Value < _Minimum Then _Value = Minimum
                Invalidate()
            End Set
        End Property

        Public Property Maximum As Long
            Get
                Return _Maximum
            End Get
            Set(value As Long)
                If value > _Minimum Then _Maximum = value
                If _Value > _Maximum Then _Value = _Maximum
                Invalidate()
            End Set
        End Property

        Public Property TextAlignment As _TextAlignment
            Get
                Return MyStringAlignment
            End Get
            Set(value As _TextAlignment)
                MyStringAlignment = value
                Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            Height = 28
            Shape = New GraphicsPath
            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            Xval = e.Location.X
            Yval = e.Location.Y
            Invalidate()

            If e.X < Width - 24 Then
                Cursor = Cursors.IBeam
            Else
                Cursor = Cursors.Default
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseClick(e)
            If Xval > Me.Width - 23 AndAlso Xval < Me.Width - 3 Then
                If Yval < 15 Then
                    If (Value + 1) <= _Maximum Then _Value += 1
                Else
                    If (Value - 1) >= _Minimum Then _Value -= 1
                End If
            Else
                KeyboardNum = Not KeyboardNum
                Focus()
            End If
            Invalidate()
        End Sub

        Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            MyBase.OnKeyPress(e)
            Try
                If KeyboardNum = True Then
                    _Value = CStr(CStr(_Value) & e.KeyChar.ToString)
                End If
                If _Value > _Maximum Then
                    _Value = _Maximum
                End If
            Catch ex As Exception
            End Try
        End Sub

        Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyUp(e)
            If e.KeyCode = Keys.Back Then
                Dim TemporaryValue As String = _Value.ToString()
                TemporaryValue = TemporaryValue.Remove(Convert.ToInt32(TemporaryValue.Length - 1))
                If (TemporaryValue.Length = 0) Then TemporaryValue = "0"
                _Value = Convert.ToInt32(TemporaryValue)
            End If
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
            MyBase.OnMouseWheel(e)
            If e.Delta > 0 Then
                If (Value + 1) <= _Maximum Then _Value += 1
                Invalidate()
            Else
                If (Value - 1) >= _Minimum Then _Value -= 1
                Invalidate()
            End If
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            P1 = New Pen(Color.FromArgb(180, 180, 180))
            B1 = New SolidBrush(Color.White)
            BackColor = Color.Transparent
            ForeColor = Color.DimGray

            _Minimum = 0
            _Maximum = 100

            Font = New Font("Tahoma", 11)
            Size = New Size(70, 28)
            MinimumSize = New Size(62, 28)
            DoubleBuffered = True
        End Sub

        Public Sub Increment(Value As Integer)
            Me._Value += Value
            Invalidate()
        End Sub

        Public Sub Decrement(Value As Integer)
            Me._Value -= Value
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.AntiAlias

            G.Clear(Color.Transparent) ' Set control background color
            G.FillPath(B1, Shape) ' Draw background
            G.DrawPath(P1, Shape) ' Draw border

            Dim ColorGradient As New LinearGradientBrush(New Rectangle(Width - 23, 4, 19, 19), Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90.0F)
            G.FillRectangle(ColorGradient, ColorGradient.Rectangle) '  Fills the body of the rectangle

            G.DrawRectangle(New Pen(Color.FromArgb(252, 252, 252)), New Rectangle(Width - 22, 5, 17, 17))
            G.DrawRectangle(New Pen(Color.FromArgb(180, 180, 180)), New Rectangle(Width - 23, 4, 19, 19))

            G.DrawLine(New Pen(Color.FromArgb(250, 252, 250)), New Point(Width - 22, Height - 16), New Point(Width - 5, Height - 16))
            G.DrawLine(New Pen(Color.FromArgb(180, 180, 180)), New Point(Width - 22, Height - 15), New Point(Width - 5, Height - 15))
            G.DrawLine(New Pen(Color.FromArgb(250, 250, 250)), New Point(Width - 22, Height - 14), New Point(Width - 5, Height - 14))

            G.DrawString("+", New Font("Tahoma", 8), Brushes.Gray, Width - 19, Height - 26)
            G.DrawString("-", New Font("Tahoma", 12), Brushes.Gray, Width - 19, Height - 20)

            Select Case MyStringAlignment
                Case _TextAlignment.Near
                    G.DrawString(Value, Font, New SolidBrush(ForeColor), New Rectangle(5, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
                Case _TextAlignment.Center
                    G.DrawString(Value, Font, New SolidBrush(ForeColor), New Rectangle(0, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose() : B.Dispose()
        End Sub
    End Class

#End Region
#Region " Left Chat Bubble "

    Public Class iTalk_ChatBubble_L
        Inherits Control

#Region " Variables "

        Private Shape As GraphicsPath
        Private _TextColor As Color = Color.FromArgb(52, 52, 52)
        Private _BubbleColor As Color = Color.FromArgb(217, 217, 217)
        Private _DrawBubbleArrow As Boolean = True

#End Region
#Region " Properties "

        Public Overrides Property ForeColor As Color
            Get
                Return Me._TextColor
            End Get
            Set(ByVal value As Color)
                Me._TextColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Property BubbleColor As Color
            Get
                Return Me._BubbleColor
            End Get
            Set(ByVal value As Color)
                Me._BubbleColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Shadows Property DrawBubbleArrow() As Boolean
            Get
                Return _DrawBubbleArrow
            End Get
            Set(ByVal Val As Boolean)
                _DrawBubbleArrow = Val
                Invalidate()
            End Set
        End Property

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)
            DoubleBuffered = True
            Size = New Size(152, 38)
            BackColor = Color.Transparent
            ForeColor = Color.FromArgb(52, 52, 52)
            Font = New Font("Segoe UI", 10)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            Shape = New GraphicsPath

            With Shape
                .AddArc(9, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(9, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With

            Invalidate()
            MyBase.OnResize(e)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G = Graphics.FromImage(B)

            With G
                .SmoothingMode = SmoothingMode.HighQuality
                .PixelOffsetMode = PixelOffsetMode.HighQuality
                .Clear(BackColor)

                .FillPath(New SolidBrush(_BubbleColor), Shape) ' Fill the body of the bubble with the specified color
                .DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(15, 4, Width - 17, Height - 5))

                ' Draw a polygon on the right side of the bubble
                If _DrawBubbleArrow = True Then
                    Dim p() As Point = {New Point(9, Height - 19), New Point(0, Height - 25), New Point(9, Height - 30)}
                    .FillPolygon(New SolidBrush(_BubbleColor), p)
                    .DrawPolygon(New Pen(New SolidBrush(_BubbleColor)), p)
                End If
            End With

            G.Dispose()
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " Right Chat Bubble "

    Public Class iTalk_ChatBubble_R
        Inherits Control

#Region " Variables "

        Private Shape As GraphicsPath
        Private _TextColor As Color = Color.FromArgb(52, 52, 52)
        Private _BubbleColor As Color = Color.FromArgb(192, 206, 215)
        Private _DrawBubbleArrow As Boolean = True

#End Region
#Region " Properties "

        Public Overrides Property ForeColor As Color
            Get
                Return Me._TextColor
            End Get
            Set(ByVal value As Color)
                Me._TextColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Property BubbleColor As Color
            Get
                Return Me._BubbleColor
            End Get
            Set(ByVal value As Color)
                Me._BubbleColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Shadows Property DrawBubbleArrow() As Boolean
            Get
                Return _DrawBubbleArrow
            End Get
            Set(ByVal Val As Boolean)
                _DrawBubbleArrow = Val
                Invalidate()
            End Set
        End Property

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)
            DoubleBuffered = True
            Size = New Size(152, 38)
            BackColor = Color.Transparent
            ForeColor = Color.FromArgb(52, 52, 52)
            Font = New Font("Segoe UI", 10)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            Shape = New GraphicsPath

            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 18, 0, 10, 10, -90, 90)
                .AddArc(Width - 18, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With

            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G = Graphics.FromImage(B)

            With G
                .SmoothingMode = SmoothingMode.HighQuality
                .PixelOffsetMode = PixelOffsetMode.HighQuality
                .Clear(BackColor)

                .FillPath(New SolidBrush(_BubbleColor), Shape) ' Fill the body of the bubble with the specified color
                .DrawString(Text, Font, New SolidBrush(ForeColor), (New Rectangle(6, 4, Width - 15, Height)))

                ' Draw a polygon on the right side of the bubble
                If _DrawBubbleArrow = True Then
                    Dim p() As Point = {New Point(Width - 8, Height - 19), New Point(Width, Height - 25), New Point(Width - 8, Height - 30)}
                    .FillPolygon(New SolidBrush(_BubbleColor), p)
                    .DrawPolygon(New Pen(New SolidBrush(_BubbleColor)), p)
                End If
            End With
            G.Dispose()
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " Separator "

    Public Class iTalk_Separator
        Inherits Control

#Region " Variables "

        Dim myBrush As New SolidBrush(Color.FromArgb(184, 183, 188))
        Dim myPen As New Pen(myBrush)

#End Region

        Sub New()
            SetStyle(ControlStyles.ResizeRedraw, True)
            Me.Size = New Point(120, 10)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.DrawLine(myPen, 0, 5, Width, 5) ' Draw the line
        End Sub
    End Class

#End Region
#Region " Panel "

    Class iTalk_Panel
        Inherits ContainerControl

        Private Shape As GraphicsPath

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            BackColor = Color.Transparent
            Me.Size = New Size(187, 117)
            Padding = New Padding(5, 5, 5, 5)
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)

            Shape = New GraphicsPath
            With Shape
                .AddArc(0, 0, 10, 10, 180, 90)
                .AddArc(Width - 11, 0, 10, 10, -90, 90)
                .AddArc(Width - 11, Height - 11, 10, 10, 0, 90)
                .AddArc(0, Height - 11, 10, 10, 90, 90)
                .CloseAllFigures()
            End With
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G = Graphics.FromImage(B)

            G.SmoothingMode = SmoothingMode.HighQuality

            G.Clear(Color.Transparent) ' Set control background to transparent
            G.FillPath(Brushes.White, Shape) ' Draw RTB background
            G.DrawPath(New Pen(Color.FromArgb(180, 180, 180)), Shape) ' Draw border

            G.Dispose()
            e.Graphics.DrawImage(B.Clone(), 0, 0)
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " GroupBox "

    Public Class iTalk_GroupBox
        Inherits ContainerControl

        Sub New()
            SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
            BackColor = Color.Transparent
            DoubleBuffered = True ' Reduce control flicker
            Me.Size = New Size(212, 104)
            Me.MinimumSize = New Size(136, 50)
            Me.Padding = New Padding(5, 28, 5, 5) ' Set padding so controls won't overlay when full-docked
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)
            Dim TitleBox As New Rectangle(51, 3, Width - 103, 18)
            Dim box As New Rectangle(0, 0, Width - 1, Height - 10)

            G.Clear(Color.Transparent)
            G.SmoothingMode = SmoothingMode.HighQuality ' Specifies antialiased rendering

            ' Draw the body of the GroupBox
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(New Rectangle(1, 12, Width - 3, box.Height - 1), 8))
            ' Draw the border of the GroupBox
            G.DrawPath(New Pen(Color.FromArgb(159, 159, 161)), RoundRectangle.RoundRect(New Rectangle(1, 12, Width - 3, Height - 13), 8))

            ' Draw the background of the title box
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(TitleBox, 1))
            ' Draw the border of the title box
            G.DrawPath(New Pen(Color.FromArgb(182, 180, 186)), RoundRectangle.RoundRect(TitleBox, 4))
            ' Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, New Font("Tahoma", 9, FontStyle.Regular), New SolidBrush(Color.FromArgb(53, 53, 53)), TitleBox, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

            e.Graphics.DrawImage(B.Clone(), 0, 0)
            G.Dispose()
            B.Dispose()
        End Sub
    End Class

#End Region
#Region " CheckBox "

    <DefaultEvent("CheckedChanged")> Class iTalk_CheckBox
        Inherits Control

#Region " Variables "

        Private Shape As GraphicsPath
        Private GB As LinearGradientBrush
        Private R1, R2 As Rectangle
        Private _Checked As Boolean
        Event CheckedChanged(ByVal sender As Object)

#End Region
#Region " Properties "

        Property Checked As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
                RaiseEvent CheckedChanged(Me)
                Invalidate()
            End Set
        End Property

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)

            BackColor = Color.Transparent
            DoubleBuffered = True ' Reduce control flicker
            Font = New Font("Segoe UI", 10)
            Size = New Size(120, 26)
        End Sub

        Protected Overrides Sub OnClick(ByVal e As EventArgs)
            _Checked = Not _Checked
            RaiseEvent CheckedChanged(Me)
            Invalidate()
            MyBase.OnClick(e)
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            If Width > 0 AndAlso Height > 0 Then
                Shape = New GraphicsPath

                R1 = New Rectangle(17, 0, Width, Height + 1)
                R2 = New Rectangle(0, 0, Width, Height)
                GB = New LinearGradientBrush(New Rectangle(0, 0, 25, 25), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90)

                With Shape
                    .AddArc(0, 0, 7, 7, 180, 90)
                    .AddArc(7, 0, 7, 7, -90, 90)
                    .AddArc(7, 7, 7, 7, 0, 90)
                    .AddArc(0, 7, 7, 7, 90, 90)
                    .CloseAllFigures()
                End With
                Height = 15
            End If

            Invalidate()
            MyBase.OnResize(e)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            With e.Graphics
                .Clear(Color.FromArgb(246, 246, 246))
                .SmoothingMode = SmoothingMode.AntiAlias

                .FillPath(GB, Shape) ' Fill the body of the CheckBox
                .DrawPath(New Pen(Color.FromArgb(160, 160, 160)), Shape) ' Draw the border

                .DrawString(Text, Font, New SolidBrush(Color.FromArgb(142, 142, 142)), R1, New StringFormat() With {.LineAlignment = StringAlignment.Center})

                If Checked Then
                    .DrawString("ü", New Font("Wingdings", 14), New SolidBrush(Color.FromArgb(142, 142, 142)), New Rectangle(-2, 1, Width, Height), New StringFormat() With {.LineAlignment = StringAlignment.Center})
                End If
            End With
            e.Dispose()
        End Sub
    End Class

#End Region
#Region " RadioButton "

    <DefaultEvent("CheckedChanged")> Class iTalk_RadioButton
        Inherits Control

#Region " Enums "

        Enum MouseState As Byte
            None = 0
            Over = 1
            Down = 2
            Block = 3
        End Enum

#End Region
#Region " Variables "

        Private _Checked As Boolean
        Event CheckedChanged(ByVal sender As Object)

#End Region
#Region " Properties "

        Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
                InvalidateControls()
                RaiseEvent CheckedChanged(Me)
                Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            Invalidate()
            MyBase.OnTextChanged(e)
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Height = 15
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            If Not _Checked Then Checked = True
            MyBase.OnMouseDown(e)
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.SupportsTransparentBackColor Or
                     ControlStyles.UserPaint, True)
            BackColor = Color.Transparent
            Font = New Font("Segoe UI", 10)
            Width = 132
        End Sub

        Private Sub InvalidateControls()
            If Not IsHandleCreated OrElse Not _Checked Then Return

            For Each _Control As Control In Parent.Controls
                If _Control IsNot Me AndAlso TypeOf _Control Is iTalk_RadioButton Then
                    DirectCast(_Control, iTalk_RadioButton).Checked = False
                End If
            Next
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            With e.Graphics

                .Clear(Color.FromArgb(246, 246, 246))
                .SmoothingMode = SmoothingMode.AntiAlias

                ' Fill the body of the ellipse with a gradient
                Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 14)), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90)
                .FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))

                Dim GP As New GraphicsPath()
                GP.AddEllipse(New Rectangle(0, 0, 14, 14))
                .SetClip(GP)
                .ResetClip()

                ' Draw ellipse border
                .DrawEllipse(New Pen(Color.FromArgb(160, 160, 160)), New Rectangle(New Point(0, 0), New Size(14, 14)))

                If _Checked Then ' Draw an ellipse inside the body
                    Dim EllipseColor As New SolidBrush(Color.FromArgb(142, 142, 142))
                    .FillEllipse(EllipseColor, New Rectangle(New Point(4, 4), New Size(6, 6)))
                End If
                .DrawString(Text, Font, New SolidBrush(Color.FromArgb(142, 142, 142)), 16, 8, New StringFormat() With {.LineAlignment = StringAlignment.Center})
            End With
            e.Dispose()
        End Sub
    End Class

#End Region
#Region " Notification Number "

    Class iTalk_NotificationNumber
        Inherits Control

#Region " Variables "

        Private _Value As Integer = 0
        Private _Maximum As Integer = 99

#End Region
#Region " Properties "

        Public Property Value() As Integer
            Get
                Select Case _Value
                    Case 0
                        Return 0
                    Case Else
                        Return _Value
                End Select
            End Get
            Set(ByVal i As Integer)
                Select Case i
                    Case Is > _Maximum
                        i = _Maximum
                End Select
                _Value = i
                Invalidate()
            End Set
        End Property

        Public Property Maximum() As Integer
            Get
                Return _Maximum
            End Get
            Set(ByVal i As Integer)
                Select Case i
                    Case Is < _Value
                        _Value = i
                End Select
                _Maximum = i
                Invalidate()
            End Set
        End Property

#End Region

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.UserPaint, True)

            Text = Nothing
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            ' Make the width and height of the control unchangeable
            Height = 20
            Width = 20
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            With e.Graphics
                .Clear(BackColor)
                .SmoothingMode = SmoothingMode.AntiAlias

                Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(18, 20)), Color.FromArgb(197, 69, 68), Color.FromArgb(176, 52, 52), 90.0F)

                .FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(18, 18)))
                .DrawEllipse(New Pen(Color.FromArgb(205, 70, 66)), New Rectangle(New Point(0, 0), New Size(18, 18))) ' Draw border
                .DrawString(_Value, New Font("Segoe UI", 8, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 253)), New Rectangle(0, 0, Width - 2, Height), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End With
            e.Dispose()
        End Sub
    End Class

#End Region
#Region " ListView "

    Class iTalk_Listview
        Inherits ListView

        <DllImport("uxtheme", CharSet:=CharSet.Unicode)>
        Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal textSubAppName As String, ByVal textSubIdList As String) As Integer
        End Function

        Public Sub New()
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.DoubleBuffered = True
            HeaderStyle = ColumnHeaderStyle.Nonclickable
            BorderStyle = Windows.Forms.BorderStyle.None ' Add the control to iTalk_Panel then full-dock it
        End Sub

        Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
            iTalk_Listview.SetWindowTheme(Me.Handle, "explorer", Nothing)
            MyBase.OnHandleCreated(e)
        End Sub
    End Class

#End Region
#Region " ComboBox "

    Class iTalk_ComboBox
        Inherits ComboBox

#Region " Variables "

        Private _StartIndex As Integer = 0
        Private _HoverSelectionColor As Color = Color.FromArgb(241, 241, 241)

#End Region
#Region " Custom Properties "

        Public Property StartIndex As Integer
            Get
                Return _StartIndex
            End Get
            Set(ByVal value As Integer)
                _StartIndex = value
                Try
                    MyBase.SelectedIndex = value
                Catch
                End Try
                Invalidate()
            End Set
        End Property

        Public Property HoverSelectionColor As Color
            Get
                Return _HoverSelectionColor
            End Get
            Set(value As Color)
                _HoverSelectionColor = value
                Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_HoverSelectionColor), e.Bounds)
            Else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            End If

            If Not e.Index = -1 Then
                e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, Brushes.DimGray, e.Bounds)
            End If
        End Sub

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            SuspendLayout()
            Update()
            ResumeLayout()
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
        End Sub

#End Region

        Sub New()
            SetStyle(DirectCast(139286, ControlStyles), True)
            SetStyle(ControlStyles.Selectable, False)

            DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            DropDownStyle = ComboBoxStyle.DropDownList

            BackColor = Color.FromArgb(246, 246, 246)
            ForeColor = Color.FromArgb(142, 142, 142)
            Size = New Size(135, 26)
            ItemHeight = 20
            DropDownHeight = 100
            Font = New Font("Segoe UI", 10, FontStyle.Regular)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim LGB As LinearGradientBrush
            Dim GP As GraphicsPath

            e.Graphics.Clear(BackColor)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            ' Create a curvy border
            GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5)
            ' Fills the body of the rectangle with a gradient
            LGB = New LinearGradientBrush(ClientRectangle, Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90.0F)

            e.Graphics.SetClip(GP)
            e.Graphics.FillRectangle(LGB, ClientRectangle)
            e.Graphics.ResetClip()

            ' Draw rectangle border
            e.Graphics.DrawPath(New Pen(Color.FromArgb(204, 204, 204)), GP)
            ' Draw string
            e.Graphics.DrawString(Text, Font, New SolidBrush(Color.FromArgb(142, 142, 142)), New Rectangle(3, 0, Width - 20, Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})

            ' Draw the dropdown arrow
            e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160), 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160), 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160)), New Point(Width - 14, 15), New Point(Width - 14, 14))

            GP.Dispose()
            LGB.Dispose()
        End Sub
    End Class

#End Region
#Region " Circular ProgressBar "

    Public Class iTalk_ProgressBar
        Inherits Control

#Region " Enums "

        Enum _ProgressShape
            Round
            Flat
        End Enum

#End Region
#Region " Variables "

        Private _Value As Long
        Private _Maximum As Long = 100
        Private _ProgressColor1 As Color = Color.FromArgb(92, 92, 92)
        Private _ProgressColor2 As Color = Color.FromArgb(92, 92, 92)
        Private ProgressShapeVal As _ProgressShape

#End Region
#Region " Custom Properties "

        Public Property Value() As Long
            Get
                Return _Value
            End Get
            Set(ByVal val As Long)
                If val > _Maximum Then val = _Maximum
                _Value = val
                Invalidate()
            End Set
        End Property

        Public Property Maximum() As Long
            Get
                Return _Maximum
            End Get
            Set(ByVal val As Long)
                If val < 1 Then val = 1
                _Maximum = val
                Invalidate()
            End Set
        End Property

        Public Property ProgressColor1 As Color
            Get
                Return _ProgressColor1
            End Get
            Set(value As Color)
                _ProgressColor1 = value
                Invalidate()
            End Set
        End Property

        Public Property ProgressColor2 As Color
            Get
                Return _ProgressColor2
            End Get
            Set(value As Color)
                _ProgressColor2 = value
                Invalidate()
            End Set
        End Property

        Public Property ProgressShape As _ProgressShape
            Get
                Return ProgressShapeVal
            End Get
            Set(value As _ProgressShape)
                ProgressShapeVal = value
                Invalidate()
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            SetStandardSize()
        End Sub

        Protected Overrides Sub OnSizeChanged(e As EventArgs)
            MyBase.OnSizeChanged(e)
            SetStandardSize()
        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal p As PaintEventArgs)
            MyBase.OnPaintBackground(p)
        End Sub

#End Region

        Sub New()
            Size = New Size(130, 130)
            Font = New Font("Segoe UI", 15)
            MinimumSize = New Size(100, 100)
            DoubleBuffered = True ' Reduce flicker
        End Sub

        Private Sub SetStandardSize()
            Dim _Size As Integer = Math.Max(Width, Height)
            Size = New Size(_Size, _Size)
        End Sub

        Public Sub Increment(Value As Integer)
            Me._Value += Value
            Invalidate()
        End Sub

        Public Sub Decrement(Value As Integer)
            Me._Value -= Value
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            Using B As New Bitmap(Width, Height) ' Create an image buffer
                Using G As Graphics = Graphics.FromImage(B)

                    G.SmoothingMode = SmoothingMode.AntiAlias
                    G.Clear(BackColor)

                    Using LGB As New LinearGradientBrush(ClientRectangle, _ProgressColor1, _ProgressColor2, LinearGradientMode.ForwardDiagonal)
                        Using P As New Pen(LGB, 14)

                            Select Case ProgressShapeVal
                                Case _ProgressShape.Round
                                    P.StartCap = LineCap.Round
                                    P.EndCap = LineCap.Round
                                Case _ProgressShape.Flat
                                    P.StartCap = LineCap.Flat
                                    P.EndCap = LineCap.Flat
                            End Select

                            G.DrawArc(P, CInt(35 / 2), CInt(35 / 2), Width - 35 - 2, Height - 35 - 2, -90, CInt((360 / _Maximum) * _Value))
                        End Using
                    End Using

                    ' Draw progress base/center object
                    Using LGB As New LinearGradientBrush(ClientRectangle, Color.FromArgb(52, 52, 52), Color.FromArgb(52, 52, 52), LinearGradientMode.Vertical)
                        G.FillEllipse(LGB, 24, 24, Width - 24 * 2 - 1, Height - 24 * 2 - 1)
                    End Using

                    ' Draw progress value
                    Dim MS As SizeF = G.MeasureString(CStr(CInt((100 / _Maximum) * _Value)), Font)
                    G.DrawString(CStr(CInt((100 / _Maximum) * _Value)), Font, Brushes.White, CInt(Width / 2 - MS.Width / 2), CInt(Height / 2 - MS.Height / 2))

                    e.Graphics.DrawImage(B, 0, 0) ' Create the output
                    ' Dispose drawing objects when finished
                    G.Dispose()
                    B.Dispose()
                End Using
            End Using
        End Sub
    End Class

#End Region
#Region " Progress Indicator "

    Class iTalk_ProgressIndicator
        Inherits Control

#Region " Variables "

        Private ReadOnly BaseColor As New SolidBrush(Color.DarkGray)
        Private ReadOnly AnimationColor As New SolidBrush(Color.DimGray)
        Private ReadOnly AnimationSpeed As New Timer()

        Private FloatPoint As PointF()
        Private BuffGraphics As BufferedGraphics
        Private IndicatorIndex As Integer
        Private ReadOnly GraphicsContext As BufferedGraphicsContext = BufferedGraphicsManager.Current

#End Region
#Region " Custom Properties "

        Public Property P_BaseColor() As Color
            Get
                Return BaseColor.Color
            End Get
            Set(val As Color)
                BaseColor.Color = val
            End Set
        End Property

        Public Property P_AnimationColor() As Color
            Get
                Return AnimationColor.Color
            End Get
            Set(val As Color)
                AnimationColor.Color = val
            End Set
        End Property

        Public Property P_AnimationSpeed() As Integer
            Get
                Return AnimationSpeed.Interval
            End Get
            Set(val As Integer)
                AnimationSpeed.Interval = val
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnSizeChanged(e As EventArgs)
            MyBase.OnSizeChanged(e)
            SetStandardSize()
            UpdateGraphics()
            SetPoints()
        End Sub

        Protected Overrides Sub OnEnabledChanged(e As EventArgs)
            MyBase.OnEnabledChanged(e)
            AnimationSpeed.Enabled = Me.Enabled
        End Sub

        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)
            AddHandler AnimationSpeed.Tick, AddressOf AnimationSpeed_Tick
            AnimationSpeed.Start()
        End Sub

        Private Sub AnimationSpeed_Tick(sender As Object, e As EventArgs)
            If IndicatorIndex.Equals(0) Then
                IndicatorIndex = FloatPoint.Length - 1
            Else
                IndicatorIndex -= 1
            End If
            Me.Invalidate(False)
        End Sub

#End Region

        Public Sub New()
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                        ControlStyles.UserPaint Or
                        ControlStyles.ResizeRedraw Or
                        ControlStyles.OptimizedDoubleBuffer, True)

            Size = New Size(80, 80)
            Text = String.Empty
            MinimumSize = New Size(80, 80)
            SetPoints()
            AnimationSpeed.Interval = 100
        End Sub

        Private Sub SetStandardSize()
            Dim _Size As Integer = Math.Max(Width, Height)
            Size = New Size(_Size, _Size)
        End Sub

        Private Sub SetPoints()
            Dim FPStack = New Stack(Of PointF)()
            Dim centerPoint As New PointF(Me.Width / 2.0F, Me.Height / 2.0F)
            Dim i As Single = 0

            While i < 360.0F
                SetValue(centerPoint, Me.Width / 2 - 15, i)
                Dim FP As PointF = EndPoint
                FP = New PointF(FP.X - 15 / 2.0F, FP.Y - 15 / 2.0F)
                FPStack.Push(FP)
                i += 360.0F / 8
            End While
            FloatPoint = FPStack.ToArray()
        End Sub

        Private Sub UpdateGraphics()
            If Me.Width > 0 AndAlso Me.Height > 0 Then
                GraphicsContext.MaximumBuffer = New Size(Me.Width + 1, Me.Height + 1)
                BuffGraphics = GraphicsContext.Allocate(Me.CreateGraphics(), Me.ClientRectangle)
                BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            BuffGraphics.Graphics.Clear(Me.BackColor)

            For i As Integer = 0 To FloatPoint.Length - 1
                If IndicatorIndex = i Then
                    BuffGraphics.Graphics.FillEllipse(AnimationColor, FloatPoint(i).X, FloatPoint(i).Y, 15, 15)
                Else
                    BuffGraphics.Graphics.FillEllipse(BaseColor, FloatPoint(i).X, FloatPoint(i).Y, 15, 15)
                End If
            Next
            BuffGraphics.Render(e.Graphics)
        End Sub

        Private Rise As Double, Run As Double
        Private _StartingFloatPoint As PointF

        Private Function AssignValues(Of X)(ByRef Run As X, Length As X) As X
            Run = Length
            Return Length
        End Function

        Private Sub SetValue(StartingFloatPoint As PointF, Length As Integer, Angle As Double)
            Dim CircleRadian As Double = Math.PI * Angle / 180.0

            _StartingFloatPoint = StartingFloatPoint
            Rise = AssignValues(Run, Length)
            Rise = Math.Sin(CircleRadian) * Rise
            Run = Math.Cos(CircleRadian) * Run
        End Sub

        Private ReadOnly Property EndPoint() As PointF
            Get
                Dim LocationX As Single = CSng(_StartingFloatPoint.Y + Rise)
                Dim LocationY As Single = CSng(_StartingFloatPoint.X + Run)

                Return New PointF(LocationY, LocationX)
            End Get
        End Property
    End Class

#End Region
#Region " TabControl "

    Class iTalk_TabControl
        Inherits TabControl

        ' NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        ' the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        ' high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        ' determined in the ImageList

        ' INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        ' Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        ' Check it out from here: http://www.gentleface.com/free_icon_set.html

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.UserPaint Or
                     ControlStyles.ResizeRedraw Or
                     ControlStyles.DoubleBuffer, True)

            DoubleBuffered = True
            SizeMode = TabSizeMode.Fixed
            ItemSize = New Size(44, 135)
            DrawMode = TabDrawMode.OwnerDrawFixed

            For Each Page As TabPage In Me.TabPages
                Page.BackColor = Color.FromArgb(246, 246, 246)
            Next
        End Sub

        Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
            MyBase.OnControlAdded(e)
            If TypeOf e.Control Is TabPage Then
                For Each i As TabPage In Me.Controls
                    i = New TabPage
                Next
                e.Control.BackColor = Color.FromArgb(246, 246, 246)
            End If
        End Sub

        Protected Overrides Sub CreateHandle()
            MyBase.CreateHandle()

            MyBase.DoubleBuffered = True
            SizeMode = TabSizeMode.Fixed
            Appearance = TabAppearance.Normal
            Alignment = TabAlignment.Left
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)

            With G

                .Clear(Color.FromArgb(246, 246, 246))
                .SmoothingMode = SmoothingMode.HighSpeed
                .CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
                .CompositingMode = Drawing2D.CompositingMode.SourceOver

                ' Draw tab selector background
                .FillRectangle(New SolidBrush(Color.FromArgb(54, 57, 64)), New Rectangle(-5, 0, ItemSize.Height + 4, Height))
                ' Draw vertical line at the end of the tab selector rectangle
                .DrawLine(New Pen(Color.FromArgb(25, 26, 28)), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height)

                For TabIndex As Integer = 0 To TabCount - 1
                    If TabIndex = SelectedIndex Then
                        Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))

                        ' Draw background of the selected tab
                        .FillRectangle(New SolidBrush(Color.FromArgb(35, 36, 38)), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3)
                        ' Draw a tab highlighter on the background of the selected tab
                        Dim TabHighlighter As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - IIf(TabIndex = 0, 1, 1)), New Size(4, GetTabRect(TabIndex).Height - 7))
                        .FillRectangle(New SolidBrush(Color.FromArgb(89, 169, 222)), TabHighlighter)
                        ' Draw tab text
                        .DrawString(TabPages(TabIndex).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), New SolidBrush(Color.FromArgb(254, 255, 255)), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                        If Me.ImageList IsNot Nothing Then
                            Dim Index As Integer = TabPages(TabIndex).ImageIndex
                            If Not Index = -1 Then
                                .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                            End If
                        End If

                    Else

                        Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))
                        ' Draw tab text
                        .DrawString(TabPages(TabIndex).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), New SolidBrush(Color.FromArgb(159, 162, 167)), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                        If Me.ImageList IsNot Nothing Then
                            Dim Index As Integer = TabPages(TabIndex).ImageIndex
                            If Not Index = -1 Then
                                .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                            End If
                        End If

                    End If
                Next
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality
                e.Graphics.DrawImage(B.Clone, 0, 0)
                G.Dispose()
                B.Dispose()
            End With
        End Sub
    End Class

#End Region
#Region " TrackBar "

    <DefaultEvent("ValueChanged")> Class iTalk_TrackBar
        Inherits Control

#Region " Enums "

        Enum ValueDivisor
            By1 = 1
            By10 = 10
            By100 = 100
            By1000 = 1000
        End Enum

#End Region
#Region " Variables "

        Private PipeBorder, TrackBarHandle As GraphicsPath
        Private TrackBarHandleRect, ValueRect As Rectangle
        Private VlaueLGB, TrackBarHandleLGB As LinearGradientBrush
        Private Cap As Boolean
        Private ValueDrawer As Integer

        Private _Minimum As Integer = 0
        Private _Maximum As Integer = 10
        Private _Value As Integer = 0
        Private _ValueColour As Color = Color.FromArgb(224, 224, 224)
        Private _DrawHatch As Boolean = True
        Private _DrawValueString As Boolean = False
        Private _JumpToMouse As Boolean = False
        Private DividedValue As ValueDivisor = ValueDivisor.By1

#End Region
#Region " Custom Properties "

        Public Property Minimum() As Integer
            Get
                Return _Minimum
            End Get
            Set(ByVal value As Integer)

                If value >= _Maximum Then value = _Maximum - 10
                If _Value < value Then _Value = value

                _Minimum = value
                Invalidate()
            End Set
        End Property

        Public Property Maximum() As Integer
            Get
                Return _Maximum
            End Get
            Set(ByVal value As Integer)

                If value <= _Minimum Then value = _Minimum + 10
                If _Value > value Then _Value = value

                _Maximum = value
                Invalidate()
            End Set
        End Property

        Event ValueChanged()
        Public Property Value() As Integer
            Get
                Return _Value
            End Get
            Set(ByVal value As Integer)
                If _Value <> value Then
                    If value < _Minimum Then
                        _Value = _Minimum
                    Else
                        If value > _Maximum Then
                            _Value = _Maximum
                        Else
                            _Value = value
                        End If
                    End If
                    Invalidate()
                    RaiseEvent ValueChanged()
                End If
            End Set
        End Property

        Public Property ValueDivison() As ValueDivisor
            Get
                Return DividedValue
            End Get
            Set(ByVal Value As ValueDivisor)
                DividedValue = Value
                Invalidate()
            End Set
        End Property

        <Browsable(False)> Public Property ValueToSet() As Single
            Get
                Return CSng(_Value / DividedValue)
            End Get
            Set(ByVal Val As Single)
                Value = CInt(Val * DividedValue)
            End Set
        End Property

        Public Property ValueColour As Color
            Get
                Return _ValueColour
            End Get
            Set(value As Color)
                _ValueColour = value
                Invalidate()
            End Set
        End Property

        Property DrawHatch() As Boolean
            Get
                Return _DrawHatch
            End Get
            Set(ByVal v As Boolean)
                _DrawHatch = v
                Invalidate()
            End Set
        End Property

        Property DrawValueString() As Boolean
            Get
                Return _DrawValueString
            End Get
            Set(ByVal v As Boolean)
                _DrawValueString = v
                If _DrawValueString = True Then
                    Height = 40
                Else
                    Height = 22
                End If
                Invalidate()
            End Set
        End Property

        Public Property JumpToMouse() As Boolean
            Get
                Return _JumpToMouse
            End Get
            Set(ByVal value As Boolean)
                _JumpToMouse = value
            End Set
        End Property

#End Region
#Region " EventArgs "

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            If Cap = True AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
                Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ValueDrawer = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
                TrackBarHandleRect = New Rectangle(ValueDrawer, 0, 10, 20)
                Cap = TrackBarHandleRect.Contains(e.Location)
                If _JumpToMouse Then
                    Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            Cap = False
        End Sub

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
             ControlStyles.UserPaint Or
             ControlStyles.ResizeRedraw Or
             ControlStyles.DoubleBuffer, True)

            _DrawHatch = True
            Size = New Size(80, 22)
            MinimumSize = New Size(37, 22)
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            If _DrawValueString = True Then
                Height = 40
            Else
                Height = 22
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim G As Graphics = e.Graphics
            Dim Hatch As New HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent)

            G.Clear(Parent.BackColor)
            G.SmoothingMode = SmoothingMode.AntiAlias

            PipeBorder = RoundRectangle.RoundRect(1, 6, Width - 3, 8, 3)

            Try
                ValueDrawer = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            Catch ex As Exception
            End Try

            TrackBarHandleRect = New Rectangle(ValueDrawer, 0, 10, 20)

            G.SetClip(PipeBorder) ' Set the clipping region of this Graphics to the specified GraphicsPath

            ValueRect = New Rectangle(1, 7, TrackBarHandleRect.X + TrackBarHandleRect.Width - 2, 7)
            VlaueLGB = New LinearGradientBrush(ValueRect, _ValueColour, _ValueColour, 90.0F)

            G.FillRectangle(VlaueLGB, ValueRect)

            If _DrawHatch = True Then
                G.FillRectangle(Hatch, ValueRect)
            End If

            G.ResetClip() ' Reset the clip region of this Graphics to an infinite region

            G.SmoothingMode = SmoothingMode.AntiAlias
            G.DrawPath(New Pen(Color.FromArgb(180, 180, 180)), PipeBorder) ' Draw pipe border

            TrackBarHandle = RoundRectangle.RoundRect(TrackBarHandleRect, 3)
            TrackBarHandleLGB = New LinearGradientBrush(ClientRectangle, SystemColors.Control, SystemColors.Control, 90.0F)

            ' Fill the handle body with the specified color gradient
            G.FillPath(TrackBarHandleLGB, TrackBarHandle)
            ' Draw handle borders
            G.DrawPath(New Pen(Color.FromArgb(180, 180, 180)), TrackBarHandle)

            If _DrawValueString = True Then
                G.DrawString(ValueToSet, Font, Brushes.Gray, 0, 25)
            End If
        End Sub
    End Class

#End Region
#Region " MenuStrip "

    Public Class iTalk_MenuStrip
        Inherits MenuStrip

        Public Sub New()
            Me.Renderer = New ControlRenderer()
        End Sub

        Public Overloads Property Renderer() As ControlRenderer
            Get
                Return DirectCast(MyBase.Renderer, ControlRenderer)
            End Get
            Set(ByVal value As ControlRenderer)
                MyBase.Renderer = value
            End Set
        End Property

    End Class

#End Region
#Region " ContextMenuStrip "

    Public Class iTalk_ContextMenuStrip
        Inherits ContextMenuStrip

        Public Sub New()
            Me.Renderer = New ControlRenderer()
        End Sub

        Public Overloads Property Renderer() As ControlRenderer
            Get
                Return DirectCast(MyBase.Renderer, ControlRenderer)
            End Get
            Set(ByVal value As ControlRenderer)
                MyBase.Renderer = value
            End Set
        End Property
    End Class

#End Region
#Region " StatusStrip "

    Public Class iTalk_StatusStrip
        Inherits StatusStrip

        Public Sub New()
            Me.Renderer = New ControlRenderer()
            SizingGrip = False
        End Sub

        Public Overloads Property Renderer() As ControlRenderer
            Get
                Return DirectCast(MyBase.Renderer, ControlRenderer)
            End Get
            Set(ByVal value As ControlRenderer)
                MyBase.Renderer = value
            End Set
        End Property
    End Class

#End Region
#Region " Info Icon "

    Class iTalk_Icon_Info
        Inherits Control
        Public Sub New()
            Me.ForeColor = Color.DimGray
            Me.BackColor = Color.FromArgb(246, 246, 246)
            Me.Size = New Size(33, 33)
            DoubleBuffered = True
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

            e.Graphics.FillEllipse(New SolidBrush(Color.Gray), New Rectangle(1, 1, 29, 29))
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(246, 246, 246)), New Rectangle(3, 3, 25, 25))

            e.Graphics.DrawString("¡", New Font("Segoe UI", 25, FontStyle.Bold), New SolidBrush(Color.Gray), New Rectangle(4, -14, Width, 43), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End Sub
    End Class

#End Region
#Region " Tick Icon "

    Class iTalk_Icon_Tick
        Inherits Control

        Sub New()
            Me.ForeColor = Color.DimGray
            Me.BackColor = Color.FromArgb(246, 246, 246)
            Me.Size = New Size(33, 33)
            DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

            e.Graphics.FillEllipse(New SolidBrush(Color.Gray), New Rectangle(1, 1, 29, 29))
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(246, 246, 246)), New Rectangle(3, 3, 25, 25))

            e.Graphics.DrawString("ü", New Font("Wingdings", 25, FontStyle.Bold), New SolidBrush(Color.Gray), New Rectangle(0, -3, Width, 43), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End Sub
    End Class

#End Region

End Namespace