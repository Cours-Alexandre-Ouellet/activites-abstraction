namespace RepartitionLocaux
{
    /// <summary>
    /// Représente une salle de classe dans laquelle peut se tenir un cours.
    /// </summary>
    internal class Local
    {
        /// <summary>
        /// Code qui identifie le local de façon unique.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Crée un nouveau local avec uniquement un code unique.
        /// </summary>
        /// <param name="code">Le code unique au local.</param>
        public Local(string code)
        {
            Code = code;
        }
    }
}
