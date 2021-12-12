
namespace Alg_Str
{
    internal class ListToDirection : ILinkedList
    {
        public Item CursItem;
        protected int Length;

        public ListToDirection()
        {
            Length = 0;
            CursItem = null;
        }

        public ListToDirection(int _value)
        {
            Length = 1;
            CursItem = new Item(_value);
        }

        /// <summary>
        /// Добавляет новый элемент в конец списка. Позция курсора не меняется.
        /// </summary>
        /// <param name="_value"> Элементу будет присвоено значение. </param>
        public void AddEnd(int _value)
        {
            if (CursItem == null)
            { CursItem = new Item(_value, null, null); }

            else
            {
                Item el = GetEdnIt();
                el.SetNextItem(new Item(_value, el, null));
            };

            Length++;
        }

        /// <summary>
        /// Добавляет новый элемент в начало списка. Позция курсора не меняется.
        /// </summary>
        /// <param name="_value"> Элементу будет присвоено значение. </param>
        public void AddHome(int _value)
        {
            Item HomeEl = GetHomeIt();
            Item newEl = new Item(_value, null, HomeEl);

            HomeEl.SetEarlyItem(newEl);

            Length++;
        }

        /// <summary>
        /// Добавляет новый элемент в список(справа от текущего).
        /// </summary>
        /// <param name="_value"> Значение элемента списка</param>
        /// <param name="_setCursNew"> установить на него позицию курсора? По умолчанию false</param>
        public void Add(int _value, bool _setCursNew = false)
        {
            Item el;

            if (CursItem != null)
            {
                el = new Item(_value, CursItem, CursItem.GetNext());
            }
            else
            {
                el = new Item(_value, null, null);
            }
            Length++;

            if (_setCursNew) CursItem = el;

        }
        /// <summary>
        /// Получить последний элемент списка.
        /// </summary>
        /// <returns> Item или null если пустой список</returns>
        private Item GetEdnIt()
        {
            Item el = CursItem;

            while (!el.ItEndIt())
            {
                el = el.GetNext();
            }

            return el;
        }

        /// <summary>
        /// Получить первый элемент списка
        /// </summary>
        /// <returns> Item или null если пустой список</returns>
        private Item GetHomeIt()
        {
            Item el = CursItem;

            while (!el.ItHomeIt())
            {
                el = el.GetEarly();
            }

            return el;
        }

        /// <summary>
        /// Получить количество элементов в списке.
        /// </summary>
        /// <returns>int элементов в списке</returns>
        public int GetCount()
        {
            //return Length;

            Item El = GetHomeIt();

            int i = 0;
            if (!El.ItEndIt()) i = 1;

            while (!El.ItEndIt())
            {
                i++;
                El = El.GetNext();
            }

            return i;

        }

        /// <summary>
        /// Добавить элемент с писок со начением
        /// </summary>
        /// <param name="_value"> Инициализирует элемент</param>
        public void AddNode(int _value)
        {
            AddEnd(_value);
        }

        /// <summary>
        /// Добавить элемент с писок со начением после указаного
        /// </summary>
        /// <param name="_value"> Инициализирует элемент</param>
        public void AddNodeAfter(Item node, int _value)
        {
            Item nextEl = node.GetNext();
            Item newEl = new Item(_value, node, node.GetNext());

            node.SetNextItem(newEl);
            nextEl.SetEarlyItem(newEl);

            Length++;
        }
        /// <summary>
        /// Удаялет элемент из списка по индексу.
        /// </summary>
        /// <param name="index">индекс удаляемого элемента.</param>
        public void RemoveNode(int index)
        {
            if (index > (Length - 1)) return;

            Item El = GetHomeIt();

            for (int i = 0; i < index; i++)
            {
                El = El.GetNext();
            }

            Item EarlyEl = El.GetEarly();
            if (El == CursItem)
            {
                CursItem = El.GetNext();
            }

            Item NextIt = El.GetNext();

            if (EarlyEl != null) EarlyEl.SetNextItem(NextIt);
            if (NextIt != null) NextIt.SetEarlyItem(EarlyEl);

            Length--;

        }

        /// <summary>
        /// Удаляет элемент из списка
        /// </summary>
        /// <param name="node">удаляемый элемент</param>
        public void RemoveNode(Item node)
        {
            Item NextIt = node.GetNext();
            Item EarlyEl = node.GetEarly();

            bool movCurs = false;

            movCurs = node == CursItem;

            if (EarlyEl != null)
            {
                EarlyEl.SetNextItem(NextIt);
                if (movCurs)
                {
                    CursItem = EarlyEl;
                }
            }
            if (NextIt != null)
            {
                NextIt.SetEarlyItem(EarlyEl);
                if (movCurs)
                {
                    CursItem = NextIt;
                }
            }

            Length--;
        }

        /// <summary>
        /// Поиск элемента по значению
        /// </summary>
        /// <param name="searchValue">значение для поиска</param>
        /// <returns>Найденый элемент или null</returns>
        public Item FindNode(int searchValue)
        {
            Item el = GetHomeIt();

            for (int i = 0; i < Length; i++)
            {
                if (el.value == searchValue)
                    return el;
            }

            return null;
        }

        /// <summary>
        /// Удаляет элемент по индексу. Если индекс не в размерности ничего не происходит.
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента.</param>
        /// <returns></returns>
        public Item GetItem(int index)
        {
            if (index > (Length - 1)) return null;

            Item El = GetHomeIt();

            for (int i = 0; i < index; i++)
            {
                El = El.GetNext();
            }

            return El;
        }
    }
}
