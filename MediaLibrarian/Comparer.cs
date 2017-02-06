using System;
using System.Collections;
using System.Windows.Forms;
// Реализация ручной сортировки элементов по столбцам.
namespace MediaLibrarian
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal;
            // Определение того, принадлежат ли сравниваемые данные типу "дата".
            try
            {
                // Анализ двух обрабатываемых объектов как параметра DateTime.
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Сравнение двух дат.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // Если ни один из сравниваемых объектов не имеет допустимый формат даты, сравнение как строки.
            catch
            {
                // Сравнение двух элементов как строк.
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            // Определение того, является ли порядок сортировки порядком "по убыванию".
            if (order == SortOrder.Descending)
                // Изменение значения, возвращенного String.Compare, на противоположное.
                returnVal *= -1;
            return returnVal;
        }
    }
}