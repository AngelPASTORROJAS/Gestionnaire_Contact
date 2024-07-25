namespace Gestionnaire_Contact.Models
{
    public class ContactModel
    {
        #region Attributs
        private string _fullname;   // PK
        private string? _nom;
        private string? _prenom;
        private DateTime? _naissance;
        private string? _avatar;
        private int? _age;
        private string _sexe;       // FK
        #endregion

        #region Propriétés
        public string FullName { get=> _fullname; set=> _fullname=value; }
        public string? Nom { get=> _nom; set=> _nom=value; }
        public string? Prenom { get=> _prenom; set=> _prenom=value; }
        public DateTime? Naissance { get=> _naissance; set=> _naissance=value; }
        public string? Avatar { get=> _avatar; set=> _avatar=value; }
        public int? Age { get=> _age; set=> _age=value; }
        public string Sexe { get=> _sexe; set=> _sexe=value; }
        #endregion

    }
}
