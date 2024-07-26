namespace Gestionnaire_Contact.Repositories
{
    /// <summary>
    /// Une interface définit un contrat ou un ensemble de
    ///     méthodes, 
    ///     propriétés, 
    ///     événements 
    ///     et indexeurs 
    /// que les classes qui implémentent cette interface doivent fournir.<br/><br/>
    /// 
    /// Les interfaces permettent de définir une structure commune pour les classes qui la implémentent,
    /// sans se préoccuper de la façon dont ces fonctionnalités sont implémentées.
    /// </summary>
    /// <typeparam name="T">Type du model</typeparam>
    /// <typeparam name="TKey">Type de l'identifiant</typeparam>
    public interface IRepository<T, TKey>
    {
        T GetById(TKey id);         // Read by id
        IEnumerable<T> GetAll();    // Read all
        void Add(T model);           // Create
        void Update(T model, TKey id);        // Update
        void Delete(TKey id);        // Delete
    }
}
