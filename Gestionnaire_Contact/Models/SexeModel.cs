namespace Gestionnaire_Contact.Models
{
    public class SexeModel
    {
        private string _sexe; //id
        public string Sexe {  get=> _sexe; set //VARCHAR(1)
            {
                if (_sexe == "M" || _sexe == "F")
                {
                    _sexe = value;
                }
                else if (_sexe != null || _sexe == "" || _sexe == " ")
                {
                    throw new ArgumentException("La valeur du sexe n'est pas.");
                }
                else
                {
                    throw new ArgumentException("La valeur du sexe n'est pas valide.");
                }
            }
        }
    }
}
