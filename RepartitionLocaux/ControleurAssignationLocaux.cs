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
            // Pour éviter l'imbrication de plusieurs niveaux, on utilise la technique des conditions de garde

            // Pour avoir une intersection, les deux périodes doivent se donner la même journée.
            if (periode1.JourSemaine != periode2.JourSemaine)
            {
                return false;
            }

            // Début de la période 1 pendant la période 2 (important de ne pas mettre de >= ou de <=)
            if (periode1.Debut > periode2.Debut && periode1.Debut < periode2.Fin)
            {
                return false;
            }

            // Fin de la période 1 pendant la période 2 (important de ne pas mettre de >= ou de <=)
            if (periode1.Fin > periode2.Debut && periode1.Fin < periode2.Fin)
            {
                return false;
            }

            // La période 2 est complètement inclue dans la période 1 (important de mettre >= et <=)
            if (periode2.Debut >= periode1.Debut && periode2.Fin <= periode1.Fin)
            {
                return false;
            }

            // Les cas suivants sont gérés implicitement : 
            // - La période 2 commence dans la période 1 => même situation que la période 1 termine dans la période 2
            // - La période 2 termine dans la période 1 => même situation que la période 1 commence dans la période 2
            // - La période 1 est inclue dans la période 2 => la période commence et termine dans la période 2, la première condition va le détecter
            // - Les deux périodes sont égales => avec les inégalités inclusives (>= et <=), ce cas sera détecter avec la vérification que la période 2
            //   est inclue dans la période 1

            // Aucune intersection : on retourne vrai
            return true;
        }

        /// <summary>
        /// Cherche un local de disponible à la période indiquée. La valeur nulle est retournée si aucun local n'est disponible.
        /// </summary>
        /// <param name="periode">La période dans laquelle le local doit être disponible.</param>
        /// <returns>Le local qui est disponible à la période indiquée ou null si aucun local n'est disponible.</returns>
        private Local TrouverLocal(Periode periode)
        {
            List<Local> locauxOccupes = new();

            // On construit la liste des locaux occupés
            foreach (Cours cours in Cours)
            {
                // On indique le local occupé seulement si le cours vérifié a déjà un local et que sa période intersecte avec 
                // la période pour laquelle l'on cherche une disponibilité.
                if (cours.Local != null && PeriodesIntersectent(periode, cours.Periode))
                {
                    locauxOccupes.Add(cours.Local);
                }
            }

            // On parcours les locaux, le premier qui n'est pas occupé est retourné comme disponible
            foreach (Local local in Locaux)
            {
                if (!locauxOccupes.Contains(local))
                {
                    return local;
                }
            }

            // On a rien retourné, donc tous les locaux sont occupés
            return null;
        }

        /// <summary>
        /// Affecte chaque cours à un local de sorte qu'il n'y ait pas deux cours qui se donnent en même temps dans le même local.
        /// </summary>
        public void AffecterLocaux()
        {
            foreach (Cours cours in Cours)
            {
                Local localDisponible = TrouverLocal(cours.Periode);

                if (localDisponible != null)
                {
                    cours.Local = localDisponible;
                    Console.WriteLine($"Le cours {cours.Sigle} est affecté au local {cours.Local.Code}.");
                }
                else
                {
                    Console.WriteLine($"Affectation impossible, il manque de locaux disponible à la période {cours.Periode}.");
                }

            }
        }

        /// <summary>
        /// Point d'entrée du programme.
        /// </summary>
        /// <param name="args">Arguments passés au programme.</param>
        public static void Main(string[] args)
        {
            // Locaux de test
            Local[] locaux =
            {
                new Local("C205"), 
                new Local("C209"),
                new Local("C210"), 
                new Local("C211")
            };

            // Cours de test
            Cours[] cours =
            {
                new Cours("420-1D6-VI", new Periode(1, 8.25f, 10.08f)),
                new Cours("420-1D6-VI", new Periode(2, 11.25f, 13.08f)),
                new Cours("201-1A3-VI", new Periode(1, 9.25f, 11.08f)),
                new Cours("420-1B4-VI", new Periode(1, 13.25f, 16.08f)),
                new Cours("420-1B4-VI", new Periode(3, 14.25f, 17.08f)),
            };

            // Réalisation de l'affectation
            ControleurAssignationLocaux controleurAssignationLocaux = new(locaux, cours);
            controleurAssignationLocaux.AffecterLocaux();
        }
    }


}
