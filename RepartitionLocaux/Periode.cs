namespace RepartitionLocaux
{
    /// <summary>
    /// Représente une période de temps entre deux heures de la même journée.
    /// </summary>
    internal class Periode
    {
        /// <summary>
        /// Jour de la semaine dans laquelle se déroule cette période. Lundi est le jour 1.
        /// </summary>
        public int JourSemaine { get; private set; }

        /// <summary>
        /// Heure de début de la période en notation décimale (1 h 30 = 1.5)
        /// </summary>
        public float Debut { get; private set; }

        /// <summary>
        /// Heure de fin de la période en notation décimale (1 h 30 = 1.5)
        /// </summary>
        public float Fin { get; private set; }

        public override string ToString()
        {
            return $"Informations de la période : jour : {JourSemaine}, debut : {Debut}, fin {Fin}.";
        }

        /// <summary>
        /// Crée un nouvelle période de temps.
        /// </summary>
        /// <param name="jourSemaine">Le jour de la semaine dans laquelle la période est située.</param>
        /// <param name="debut">L'heure début de la période.</param>
        /// <param name="fin">L'heure de fin de la période.</param>
        public Periode(int jourSemaine, float debut, float fin)
        {
            JourSemaine = jourSemaine;
            Debut = debut;
            Fin = fin;
        }
    }
}
