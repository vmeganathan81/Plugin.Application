namespace Plugin.Application.Model
{
    /// <summary>
    /// Entity class that represents a Letter object
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Letter Unique identifier
        /// </summary>
        public int LetterID { get; set; }

        /// <summary>
        /// Name of Letter 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Remote File name in File Storage System
        /// </summary>
        public string RemoteFileName { get; set; }

        /// <summary>
        /// Category Letter Associated to
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Calculates unique HashCode based on the values of members
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            int hashLetterID = LetterID.GetHashCode();
            int hashName = Name.GetHashCode();
            int hashRemoteFileName = RemoteFileName.GetHashCode();
            int hashCategory = Category.GetHashCode();
            return hashLetterID ^ hashName ^ hashRemoteFileName ^ hashCategory;
        }
    }
}
