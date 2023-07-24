namespace bjorkvalle.UI.Models
{
    public class ProphetItem<T>
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this ProphetItem is disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Represents the optgroup HTML element this item is wrapped into. In a select list, multiple groups with the same name are supported. They are compared with reference equality.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether this ProphetItem is selected.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the text of the selected item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value of the selected item (key).
        /// </summary>
        public T Value { get; set; }
    }
}
