
namespace Unisched.Core.Common
{
    /// <summary>
    /// Class that represents an item, that consists of a identification tag and a display name
    /// </summary>
    public class TaggedItem
    {
        private string displayName;
        private object tag;

        /// <summary>
        /// String that represents the item for a user.
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// Identification object of the item.
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        /// Constructor, initializes the item.
        /// </summary>
        /// <param name="displayName">String representation of the item.</param>
        /// <param name="tag">Identification of the item.</param>
        public TaggedItem(string displayName, object tag)
        {
            this.displayName = displayName;
            this.tag = tag;
        }

        public override string ToString()
        {
            return displayName;
        }
    }
}
