namespace RepartitionLocaux
{
    /// <summary>
    /// Un cours est une activité qui se déroule à une période donné dans un local donné. Chaque cours possède un sigle
    /// qui permet de l'identifier.
    /// </summary>
    internal class Cours
    {
        /// <summary>
        /// Le sigle qui permet d'identifier le cours de façon unique.
        /// </summary>
        public string Sigle { get; private set; }

        /// <summary>
        /// Période dans laquelle se déroule le cours.
        /// </summary>
        public Periode Periode { get; private set; }

        /// <summary>
        /// Local dans lequel se déroule le cours. 
        /// </summary>
        public Local Local { get; set; }

        /// <summary>
        /// Crée un nouveau cours pour lequel l'on connaît le sigle et la période à laquelle il se tient. Le local n'est pas 
        /// déterminé.
        /// </summary>
        /// <param name="sigle">Le sigle d'identification unique de ce cours.</param>
        /// <param name="periode">La période à laquelle le cours se donne.</param>
        public Cours (string sigle, Periode periode)
        {
            Sigle = sigle;
            Periode = periode;
            Local = null;
        }
    }
}
