﻿using Krypton.Toolkit;

/// <summary>
/// Class for a DataGridViewPercentageCell
/// </summary>
public class DataGridViewPercentageCell : KryptonDataGridViewTextBoxCell
{
    /// <summary>
    /// Constructor
    /// </summary>
    public DataGridViewPercentageCell()
    {
        this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }

    /// <summary>
    /// Specify the type of object used for editing. This is how the WinForms
    /// framework figures out what type of edit control to make.
    /// </summary>
    public override Type EditType
    {
        get { return typeof(PercentageEditingControl); }
    }

    /// <summary>
    /// Overrides TypeValue
    /// </summary>
    public override Type ValueType
    {
        get { return typeof(double); }
    }

    /// <summary>
    /// Specify the default cell contents upon creation of a new cell.
    /// </summary>
    public override object DefaultNewRowValue
    {
        get { return 0; }
    }

    /// <summary>
    /// Overrides Paint
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clipBounds"></param>
    /// <param name="cellBounds"></param>
    /// <param name="rowIndex"></param>
    /// <param name="cellState"></param>
    /// <param name="value"></param>
    /// <param name="formattedValue"></param>
    /// <param name="errorText"></param>
    /// <param name="cellStyle"></param>
    /// <param name="advancedBorderStyle"></param>
    /// <param name="paintParts"></param>
    protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, System.Windows.Forms.DataGridViewElementStates cellState, object value, object formattedValue, string errorText, System.Windows.Forms.DataGridViewCellStyle cellStyle, System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle,
        System.Windows.Forms.DataGridViewPaintParts paintParts)
    {
        //Draw the bar
        int barWidth;
        if ((double)value >= 1.0)
        {
            barWidth = (int)(cellBounds.Width - 10);
        }
        else
        {
            barWidth = (int)((cellBounds.Width - 10) * (double)value);
        }

        if ((double)value > 0 && barWidth > 0)
        {
            Rectangle r = new Rectangle(cellBounds.X + 3, cellBounds.Y + 3, barWidth, cellBounds.Height - 8);

            using (LinearGradientBrush linearBrush = new LinearGradientBrush(r, KryptonManager.CurrentGlobalPalette.GetBackColor1(PaletteBackStyle.GridHeaderColumnList, PaletteState.Normal), KryptonManager.CurrentGlobalPalette.GetBackColor2(PaletteBackStyle.GridHeaderColumnList, PaletteState.Normal), LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(linearBrush, r);
            }

            using (Pen pen = new Pen(KryptonManager.CurrentGlobalPalette.GetBorderColor1(PaletteBorderStyle.GridHeaderColumnList, PaletteState.Normal)))
            {
                graphics.DrawRectangle(pen, r);
            }

            //TODO : implement customization like conditional formatting
            //using (LinearGradientBrush linearBrush = new LinearGradientBrush(r, Color.FromArgb(255, 140, 197, 66), Color.FromArgb(255, 247, 251, 242), LinearGradientMode.Horizontal))
            //{
            //    graphics.FillRectangle(linearBrush, r);
            //}

            //using (Pen pen = new Pen(Color.FromArgb(255, 140, 197, 66)))
            //{
            //    graphics.DrawRectangle(pen, r);

            //}
        }

        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
            DataGridViewPaintParts.None | DataGridViewPaintParts.ContentForeground);
    }
}