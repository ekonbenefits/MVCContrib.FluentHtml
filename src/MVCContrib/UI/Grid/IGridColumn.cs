using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvcContrib.UI.Grid
{
	/// <summary>
	/// Grid Column fluent interface
	/// </summary>
	public interface IGridColumn<T>
	{
		/// <summary>
		/// Specified an explicit name for the column.
		/// </summary>
		/// <param name="name">Name of column</param>
		/// <returns></returns>
		IGridColumn<T> Named(string name);
		/// <summary>
		/// If the property name is PascalCased, it should not be split part.
		/// </summary>
		/// <returns></returns>
		IGridColumn<T> DoNotSplit();
		/// <summary>
		/// A custom format to use when building the cell's value
		/// </summary>
		/// <param name="format">Format to use</param>
		/// <returns></returns>
		IGridColumn<T> Format(string format);
		/// <summary>
		/// Delegate used to hide the contents of the cells in a column.
		/// </summary>
		IGridColumn<T> CellCondition(Func<T, bool> func);

		/// <summary>
		/// Determines whether the column should be displayed
		/// </summary>
		/// <param name="isVisible"></param>
		/// <returns></returns>
		IGridColumn<T> Visible(bool isVisible);


		/// <summary>
		/// Determines whether or not the column should be encoded. Default is true.
		/// </summary>
		IGridColumn<T> Encode(bool shouldEncode);

		/// <summary>
		/// Do not HTML Encode the output
		/// </summary>
		/// <returns></returns>
		[Obsolete("Use Encode(false) instead.")]
		IGridColumn<T> DoNotEncode(); //TODO: Jeremy to remove after next release.

		/// <summary>
		/// Defines additional attributes for the column heading.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		IGridColumn<T> HeaderAttributes(IDictionary<string, object> attributes);

		/// <summary>
		/// Defines additional attributes for the cell. 
		/// </summary>
		/// <param name="attributes">Lambda expression that should return a dictionary containing the attributes for the cell</param>
		/// <returns></returns>
		IGridColumn<T> Attributes(Func<GridRowViewData<T>, IDictionary<string, object>> attributes);

		/// <summary>
		/// Specifies whether or not this column should be sortable. 
		/// The default is true. 
		/// </summary>
		/// <param name="isColumnSortable"></param>
		/// <returns></returns>
		IGridColumn<T> Sortable(bool isColumnSortable);

		/// <summary>
		/// Specifies a custom name that should be used when sorting on this column
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		IGridColumn<T> SortColumnName(string name);

		/// <summary>
		/// Custom header renderer
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)] //hide from intellisense in fluent interface
		Action<RenderingContext> CustomHeaderRenderer { get; set; }

		/// <summary>
		/// Custom item renderer
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)] //hide from intellisense in fluent interface
		Action<RenderingContext, T> CustomItemRenderer { get; set; }
	}
}