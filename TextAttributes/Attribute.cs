namespace TextAttributes
{
    /// <summary>
    /// Attribute it is a parametr of Record
    /// </summary>
    public class TextAttribute
	{
        /// <summary>
        /// Value, etc. Text that corresponding to Attribute
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Attribute Name - that name could be represented in text or it could be abstract, invented by user
        /// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Type of text representation
		/// </summary>
		public EType Type { get; set; }

		/// <summary>
		/// Visible in text or abstract
		/// </summary>
		public bool Displayed { get; set; }

        #region Constructors
        public TextAttribute()
		{

		}
        public TextAttribute(string Name)
        {
            this.Name = Name;
        }
        public TextAttribute(string Name, EType Type, bool Displayed)
        {
            this.Name = Name;
            this.Type = Type;
            this.Displayed = Displayed;
        }
        public TextAttribute(string Name, EType Type, bool Displayed, string Value)
		{
			this.Value = Value;
			this.Name = Name;
			this.Type = Type;
			this.Displayed = Displayed;
		}
        #endregion

        /// <summary>
        /// Type of Attribute represents in text
        /// </summary>
        public enum EType
        {
            Optional,
            Mandatory,
            Multiple
        }
    }

}
