
namespace Alg_Str
{
    public class Item
    {
        public int value { get; set; }
        private Item NextItem;
        private Item EarlyItem;

        /// <summary>
        /// Создает элемент.
        /// </summary>
        public Item()
        {
            value = 0;
            NextItem = null;
            EarlyItem = null;
        }

        /// <summary>
        /// Создает элемент инициализирует его значением.
        /// </summary>
        /// <param name="_value">Значенеи.</param>
        public Item(int _value)
        {
            value = _value;
            NextItem = null;
            EarlyItem = null;
        }

        /// <summary>
        /// Создает элемент инициализирует указывает предыдущий и следующий элементы.
        /// </summary>
        /// <param name="_value">Значение.</param>
        /// <param name="_EarlyItem">Предыдущий элемент</param>
        /// <param name="_NextItem">Следующий элемент.</param>
        public Item(int _value, Item _EarlyItem, Item _NextItem)
        {
            value = _value;
            NextItem = _NextItem;
            EarlyItem = _EarlyItem;
        }

        /// <summary>
        /// Проверяет является ли данный элемент последним в списке справа.
        /// </summary>
        /// <param name="el">Элемент Item</param>
        /// <returns></returns>
        public bool ItEndIt()
        {
            return NextItem == null;
        }

        /// <summary>
        /// Проверяет является ли данный элемент последним в списке слева.
        /// </summary>
        /// <param name="el">Элемент Item</param>
        /// <returns></returns>
        public bool ItHomeIt()
        {
            return EarlyItem == null;
        }

        /// <summary>
        /// Получает следующий элемент списка справа.
        /// </summary>
        /// <returns>Item или null</returns>
        public Item GetNext()
        {
            return NextItem;
        }

        /// <summary>
        /// Получает следующий элемент списка слева.
        /// </summary>
        /// <returns>Item или null</returns>
        public Item GetEarly()
        {
            return EarlyItem;
        }

        /// <summary>
        /// Установить ссылку на слежующий элемент.
        /// </summary>
        /// <param name="_el">ссылка</param>
        public void SetNextItem(Item _el)
        {
            this.NextItem = _el;
        }

        /// <summary>
        /// Установить ссылку на предыдущий элемент.
        /// </summary>
        /// <param name="_el">ссылка</param>
        public void SetEarlyItem(Item _el)
        {
            this.EarlyItem = _el;
        }

    }

}
