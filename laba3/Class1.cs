using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    /// <summary>
    /// Класс, реализующий однонаправленный одномерный список
    /// </summary>
    /// <typeparam name="Type">Тип данных списка</typeparam>
    public class List<Type>
    {
        /// <summary>
        /// Класс, описывающий элемент списка
        /// </summary>
        private class ListItem
        {
            public Type Data;
            public ListItem NextListItem;
        }
        private ListItem FirstListItem;
        private int _length;
        public int Length
        {
            get
            {
                return _length;
            }
        }
        /// <summary>
        /// Метод добавления элемента в список
        /// </summary>
        /// <param name="data">Тип данных</param>
        public void Add(Type data)
        {
            // Создаём новый элемент списка с данными, которые мы передали в качестве аргумента
            var ListItem = new ListItem { Data = data };

            // Если первого эелмента нет, то создаём его без каких-либо ссылок к другим элементам и возвращаем 
            if (FirstListItem == null)
            {
                FirstListItem = ListItem;
                _length = 1;
                return;
            }

            // В другом слачае создаём новую переменную, хранящую копию 1-го элемента
            // В результате строк ниже он будет содержать элемент перед тем, который мы создаем.
            var PrevItem = FirstListItem;

            while (PrevItem.NextListItem != null)
            {
                PrevItem = PrevItem.NextListItem;
            }

            PrevItem.NextListItem = ListItem;
            _length += 1;
        }
        /// <summary>
        /// Метод удаления элемента из списка
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента</param>
        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            // Эта переменная предназначена для итерации ниже
            var itemBeforeTheOneToDelete = FirstListItem;

            // Ищем элдемент списка, перед которым мы хотим удалить элемент
            for (var i = 0; i < index - 1; i++)
            {
                itemBeforeTheOneToDelete = itemBeforeTheOneToDelete.NextListItem;
            }
            // Пропускаем ссылку на элемент, который мы хотим удалить
            itemBeforeTheOneToDelete.NextListItem = itemBeforeTheOneToDelete.NextListItem.NextListItem;

            _length--;
        }
        /// <summary>
        /// Метод проверки индекса
        /// </summary>
        /// <param name="index">Проверяемый индекс</param>
        private void ValidateIndex(int index)
        {
            if (FirstListItem == null) throw new Exception("Список пуст");
            if (index >= _length || index < 0) throw new Exception($"Нету элемента под индексом: {index}");
        }
        private Type GetItem(int index)
        {
            ValidateIndex(index);

            var item = FirstListItem;

            for (var i = 0; i < index; i++)
            {
                item = item.NextListItem;
            }

            return item.Data;
        }
        /// <summary>
        /// Создаём индексатор
        /// </summary>
        /// <param name="index">индекс</param>
        public Type this[int index]
        {
            get
            {
                return GetItem(index);
            }
        }
    }
}
