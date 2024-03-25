namespace RepartitionLocaux
{
    /// <summary>
    /// Principale classe du système responsable de résoudre les contraintes entre les affectations des cours à différents locaux et à différentes
    /// périodes.
    /// </summary>
    internal class ControleurAssignationLocaux
    {
        /// <summary>
        /// Liste des locaux disponibles dans l'établissement.
        /// </summary>
        public Local[] Locaux { get; private set; }

        /// <summary>
        /// Liste des cours qui se donnent dans l'établissement.
        /// </summary>
        public Cours[] Cours { get; private set; }

        /// <summary>
        /// Crée un nouveau contrôleur de l'assignation des locaux.
        /// </summary>
        /// <param name="locaux">La liste des locaux de l'établissement.</param>
        /// <param name="cours">La liste des cours de l'établissement.</param>
        ControleurAssignationLocaux(Local[] locaux, Cours[] cours)
        {
            Locaux = locaux;
            Cours = cours;
        }

        /// <summary>
        /// Détermine si les deux périodes admettent une intersection ou non.
        /// </summary>
        /// <param name="periode1">La première période dans la vérification.</param>
        /// <param name="periode2">La seconde période dans la vérification.</param>
        /// <returns>true si les deux périodes admettent une intersection, false autrement.</returns>
        private bool PeriodesIntersectent(Periode periode1, Periode periode2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cherche un local de disponible à la période indiquée. La valeur nulle est retournée si aucun local n'est disponible.
        /// </summary>
        /// <param name="periode">La période dans laquelle le local doit être disponible.</param>
        /// <returns>Le local qui est disponible à la période indiquée ou null si aucun local n'est disponible.</returns>
        private Local TrouverLocal(Periode periode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Affecte chaque cours à un local de sorte qu'il n'y ait pas deux cours qui se donnent en même temps dans le même local.
        /// </summary>
        public void AffecterLocaux()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Point d'entrée du programme.
        /// </summary>
        /// <param name="args">Arguments passés au programme.</param>
        public static void Main(string[] args)
        {
            throw new NotImplementedException();
        }
    }


}
