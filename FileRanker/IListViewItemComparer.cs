using System;
using System.Collections;
using System.Windows.Forms;

namespace FileRanker
{
    internal class ListViewItemComparer : IComparer, IListViewItemComparer
    {
        /// <summary>
        /// ��r������@
        /// </summary>
        public enum ComparerMode
        {
            /// <summary>
            /// ������Ƃ��Ĕ�r
            /// </summary>
            String,
            /// <summary>
            /// ���l�iInt32�^�j�Ƃ��Ĕ�r
            /// </summary>
            Integer,
            /// <summary>
            /// �����iDataTime�^�j�Ƃ��Ĕ�r
            /// </summary>
            DateTime
        };

        private int _column;
        private SortOrder _order;
        private ComparerMode _mode;
        private ComparerMode[] _columnModes;

        /// <summary>
        /// ���ёւ���ListView��̔ԍ�
        /// </summary>
        public int Column
        {
            set
            {
                //���݂Ɠ�����̎��́A�����~����؂�ւ���
                if (_column == value)
                {
                    if (_order == SortOrder.Ascending)
                    {
                        _order = SortOrder.Descending;
                    }
                    else if (_order == SortOrder.Descending)
                    {
                        _order = SortOrder.Ascending;
                    }
                }
                _column = value;
            }
            get
            {
                return _column;
            }
        }
        /// <summary>
        /// �������~����
        /// </summary>
        public SortOrder Order
        {
            set
            {
                _order = value;
            }
            get
            {
                return _order;
            }
        }
        /// <summary>
        /// ���ёւ��̕��@
        /// </summary>
        public ComparerMode Mode
        {
            set
            {
                _mode = value;
            }
            get
            {
                return _mode;
            }
        }
        /// <summary>
        /// �񂲂Ƃ̕��ёւ��̕��@
        /// </summary>
        public ComparerMode[] ColumnModes
        {
            set
            {
                _columnModes = value;
            }
        }

        /// <summary>
        /// ListViewItemComparer�N���X�̃R���X�g���N�^
        /// </summary>
        /// <param name="col">���ёւ����̔ԍ�</param>
        /// <param name="ord">�������~����</param>
        /// <param name="cmod">���ёւ��̕��@</param>
        public ListViewItemComparer(
            int col, SortOrder ord, ComparerMode cmod)
        {
            _column = col;
            _order = ord;
            _mode = cmod;
        }
        public ListViewItemComparer()
        {
            _column = 0;
            _order = SortOrder.Ascending;
            _mode = ComparerMode.String;
        }

        //x��y��菬�����Ƃ��̓}�C�i�X�̐��A�傫���Ƃ��̓v���X�̐��A
        //�����Ƃ���0��Ԃ�
        public int Compare(object x, object y)
        {
            if (_order == SortOrder.None)
            {
                //���ёւ��Ȃ���
                return 0;
            }

            int result = 0;
            //ListViewItem�̎擾
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            if (itemx.SubItems.Count <= _column) return 0;
            if (itemy.SubItems.Count <= _column) return 0;

            //���בւ��̕��@������
            if (_columnModes != null && _columnModes.Length > _column)
            {
                _mode = _columnModes[_column];
            }

            //���ёւ��̕��@�ʂɁAx��y���r����
            switch (_mode)
            {
                case ComparerMode.String:
                    //��������Ƃ��Ĕ�r
                    result = string.Compare(itemx.SubItems[_column].Text,
                        itemy.SubItems[_column].Text);
                    break;
                case ComparerMode.Integer:
                    //Int32�ɕϊ����Ĕ�r
                    //.NET Framework 2.0����́ATryParse���\�b�h���g�����Ƃ��ł���
                    result = int.Parse(itemx.SubItems[_column].Text).CompareTo(
                        int.Parse(itemy.SubItems[_column].Text));
                    break;
                case ComparerMode.DateTime:
                    //DateTime�ɕϊ����Ĕ�r
                    //.NET Framework 2.0����́ATryParse���\�b�h���g�����Ƃ��ł���
                    result = DateTime.Compare(
                        DateTime.Parse(itemx.SubItems[_column].Text),
                        DateTime.Parse(itemy.SubItems[_column].Text));
                    break;
            }

            //�~���̎��͌��ʂ�+-�t�ɂ���
            if (_order == SortOrder.Descending)
            {
                result = -result;
            }

            //���ʂ�Ԃ�
            return result;
        }
    }
}