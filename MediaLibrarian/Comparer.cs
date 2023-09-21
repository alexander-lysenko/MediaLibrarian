using System;
using System.Collections;
using System.Windows.Forms;

// Реализация ручной сортировки элементов по столбцам.
namespace MediaLibrarian
{
    internal class ListViewItemComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;

        public ListViewItemComparer()
        {
            _col = 0;
            _order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal;
            // Определение того, принадлежат ли сравниваемые данные типу "дата".
            try
            {
                // Анализ двух обрабатываемых объектов как параметра DateTime.
                var firstDate = DateTime.Parse((x as ListViewItem).SubItems[_col].Text);
                var secondDate = DateTime.Parse((y as ListViewItem).SubItems[_col].Text);
                // Сравнение двух дат.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // Если ни один из сравниваемых объектов не имеет допустимый формат даты, сравнение как строки.
            catch
            {
                // Сравнение двух элементов как строк.
                returnVal = string.CompareOrdinal(
                    (x as ListViewItem).SubItems[_col].Text,
                    (y as ListViewItem).SubItems[_col].Text
                );
            }

            // Определение того, является ли порядок сортировки порядком "по убыванию".
            if (_order == SortOrder.Descending)
                // Изменение значения, возвращенного String.Compare, на противоположное.
                returnVal *= -1;
            return returnVal;
        }
    }
}