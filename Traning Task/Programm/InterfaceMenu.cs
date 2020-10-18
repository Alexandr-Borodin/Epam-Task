using System.Collections;


namespace Programm
{
    /// <summary>
    /// Menu which will show in user interface.
    /// </summary>
    public class InterfaceMenu
    {
        /// <summary>
        /// Stores menu points.
        /// </summary>
        private string[] menuPoints;

        /// <summary>
        /// Stores head of menu.
        /// </summary>
        public string Head { get; } = "....................Menu....................";

        /// <summary>
        /// Number of menu points.
        /// </summary>
        public int Length => menuPoints.Length;

        /// <summary>
        /// Indexer to get menu points.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index] => menuPoints[index];

        /// <summary>
        /// Constructor of InterfaceMenu.
        /// </summary>
        public InterfaceMenu()
        {
            menuPoints = new[]
            {
                "Add figure.",
                "Add figure automatically",
                "Show all figures.",
                "Show average perimeter and area fo all figures.",
                "Show largest area figure.",
                "Show figure type with largest average perimeter among all types of figure.",
                "Exit."
            };
        }

        /// <summary>
        /// Overload of GetEnumerator fo InterfaceMenu.
        /// </summary>
        /// <returns>GetEnumerator of string array "menuPoints".</returns>
        public IEnumerator GetEnumerator()
        {
            return menuPoints.GetEnumerator();
        }
    }
}